using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using HotFix;
using ObjectPool;
using RSG;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Sources.Extensions;
using UnityEngine.Networking;

namespace Shift.Legion.ClientApi.RPC;

public class RPCConnection
{
	public class WaitingGamePacket
	{
		public int PacketId;

		public int RetryTimes;

		public long BeginStamp;

		public long TimeOutStamp => UnityRequestHelper.GetTimeOutTimeForPacket(PacketId, RetryTimes) + BeginStamp;
	}

	private readonly string _serverUrl;

	private readonly int _retryTimesLimit;

	protected readonly Log LogSource = new Log("Network");

	private int _sendingRequest;

	private readonly Queue<GamePacket> _outBoundPackets = new Queue<GamePacket>();

	private readonly Queue<GamePacket> _incomingPackets = new Queue<GamePacket>();

	private readonly List<NetworkError> _errors = new List<NetworkError>();

	private readonly Dictionary<int, List<PacketHandler>> _packetHandlers = new Dictionary<int, List<PacketHandler>>();

	protected readonly object PacketIdLock = new object();

	protected static int NextPacketId;

	protected readonly Dictionary<int, RPCContextDelegate> WaitingForResponse = new Dictionary<int, RPCContextDelegate>();

	protected readonly Dictionary<int, int> RpcTimeRecord = new Dictionary<int, int>();

	private readonly Dictionary<int, WaitingGamePacket> _waitingGamePackets = new Dictionary<int, WaitingGamePacket>();

	private GamePacket _currentPacket;

	private DateTimeOffset _latestReceivedResponseTime = DateTimeOffset.UtcNow;

	private int _totalRetryTimes;

	private string _token;

	public string SIndex = string.Empty;

	public DateTimeOffset LatestReceivedResponseTime => _latestReceivedResponseTime;

	public int TotalRetryTimes => _totalRetryTimes;

	public string Token
	{
		get
		{
			return _token;
		}
		set
		{
			_token = value;
			UnityRequestHelper.Instance.SetToken(_token);
			BattleUnityRequestHelper.Instance.SetToken(_token);
		}
	}

	public RPCConnection(string serverUrl, int retryTimesLimit = 20, int requestTimeout = 10)
	{
		_serverUrl = serverUrl;
		_retryTimesLimit = retryTimesLimit;
	}

	public void QueueRequest(IPacketBody message, RPCContextDelegate callback = null)
	{
		if (message != null && (_outBoundPackets.Count <= 5 || message.PacketId != 1))
		{
			if (message is IRequestPacket requestPacket)
			{
				requestPacket.MsgIndex = MsgIndexer.Instance.GetNext();
			}
			object packetIdLock = PacketIdLock;
			int nextPacketId;
			lock (packetIdLock)
			{
				nextPacketId = NextPacketId;
				NextPacketId++;
			}
			if (callback != null)
			{
				WaitingForResponse.Add(nextPacketId, callback);
				RpcTimeRecord.Add(nextPacketId, (int)DateTimeHelper.Now.ToUnixTimeMilliseconds());
			}
			Header h = CreateHeader(message.PacketId, nextPacketId);
			GamePacket packet = new GamePacket(h, message);
			QueuePacket(packet);
			OnPacketBegin(nextPacketId, message.PacketId);
		}
	}

	public bool RegisterPacketHandler(int packetId, PacketHandler handler)
	{
		if (_packetHandlers.TryGetValue(packetId, out var value))
		{
			if (value.Contains(handler))
			{
				return false;
			}
		}
		else
		{
			value = new List<PacketHandler>();
			_packetHandlers.Add(packetId, value);
		}
		value.Add(handler);
		return true;
	}

	public bool RemoveNetHandler(int packetId, PacketHandler handler)
	{
		List<PacketHandler> value;
		return _packetHandlers.TryGetValue(packetId, out value) && value.Remove(handler);
	}

	private void OnPostTaskCompleted()
	{
		_sendingRequest--;
	}

	public void Update()
	{
		if (_outBoundPackets.Count > 0)
		{
			while (_outBoundPackets.Count > 0 && _sendingRequest < 3)
			{
				GamePacket gamePacket = _outBoundPackets.Dequeue();
				byte[] data = gamePacket.Encode();
				_sendingRequest++;
				try
				{
					SendPacket(data, gamePacket);
				}
				catch (Exception)
				{
				}
			}
		}
		if (_incomingPackets.Count <= 0)
		{
			return;
		}
		Queue<GamePacket> incomingPackets = _incomingPackets;
		Queue<GamePacket> queue;
		lock (incomingPackets)
		{
			queue = new Queue<GamePacket>(incomingPackets.ToArray());
			incomingPackets.Clear();
		}
		while (queue.Count > 0)
		{
			GamePacket gamePacket2 = queue.Dequeue();
			Header header = gamePacket2.Header;
			byte[] payload = (byte[])gamePacket2.Body;
			int packetId = header.PacketId;
			RPCContext rPCContext = ObjectPool<RPCContext>.Spawn((Func<RPCContext>)(() => new RPCContext()));
			rPCContext.Header = header;
			rPCContext.PacketId = packetId;
			rPCContext.Payload = payload;
			HandlePacket(packetId, rPCContext);
			if (WaitingForResponse.TryGetValue(header.Token, out var value))
			{
				try
				{
					value(rPCContext);
				}
				catch (Exception)
				{
				}
				WaitingForResponse.Remove(header.Token);
				RPCRecord(gamePacket2);
			}
			rPCContext.Header = null;
			rPCContext.Payload = null;
			rPCContext.Callback = null;
			rPCContext.ResponseReceived = false;
			rPCContext.Request = null;
			rPCContext.PacketId = 0;
			rPCContext.Context = 0;
			rPCContext.UnSpawn();
		}
	}

	private void SendPacket(byte[] data, GamePacket packet)
	{
		DoPost(_serverUrl, data, packet).Then((Action<bool>)delegate
		{
			data = null;
			int token = packet.Header.Token;
			OnPacketEnd(token);
		}).Catch((Action<Exception>)delegate(Exception ex)
		{
			WaitingForResponse.Remove(packet.Header.Token);
			EnqueueErrorInfo(new NetworkError(NetworkErrorTypes.NETWORK_ISSUE, ex));
			RPCRecord(packet, ex.Message.ToString());
			int token = packet.Header.Token;
			OnPacketEnd(token);
		}).Finally((Action)OnPostTaskCompleted);
	}

	private bool HandlePacket(int id, RPCContext context)
	{
		if (!_packetHandlers.TryGetValue(id, out var value) || value.Count == 0)
		{
			return false;
		}
		if (value == null || value.Count == 0)
		{
			ILRuntimeDebug.LogError("!!!!!!! Received packet " + id + ", but there are no handlers for it.");
			return false;
		}
		for (int i = 0; i < value.Count; i++)
		{
			value[i]?.Invoke(context);
		}
		return true;
	}

	private bool CanIgnoreUnhandledPacket(int id)
	{
		return id switch
		{
			0 => true, 
			1 => true, 
			_ => false, 
		};
	}

	private Promise<bool> DoPost(string apiUrl, byte[] data, GamePacket packet = null)
	{
		Promise<bool> promise = new Promise<bool>();
		if (!string.IsNullOrEmpty(SIndex))
		{
			MsgSecurityClient.Do(MsgSecurityAction.Encryption, ref data);
		}
		UnityRequestHelper.Instance.Post(this, apiUrl, data, packet).Then((Action<UnityWebRequest>)delegate(UnityWebRequest uwr)
		{
			int num = (int)uwr.responseCode;
			switch (num)
			{
			case 401:
				if (packet?.Header.PacketId != PacketIds.USER_PING && packet?.Header.PacketId != PacketIds.SYNC_TIME)
				{
					EnqueueErrorInfo(new NetworkError(NetworkErrorTypes.ERROR_INVALID_TOKEN, new AuthenticationException()));
				}
				promise.Resolve(true);
				if (packet != null)
				{
					WaitingForResponse.Remove(packet.Header.Token);
					RPCRecord(packet, "Unauthorized");
				}
				break;
			case 200:
			{
				byte[] data2 = uwr.downloadHandler.data;
				if (_currentPacket == null)
				{
					_currentPacket = new GamePacket();
				}
				if (!string.IsNullOrEmpty(SIndex))
				{
					MsgSecurityClient.Do(MsgSecurityAction.Decryption, ref data2);
				}
				_currentPacket.Decode(data2, 0, data2.Length);
				if (!_currentPacket.IsLoaded())
				{
					promise.Reject((Exception)new HttpRequestException($"网络异常：{packet?.Header?.PacketId}.001"));
				}
				else
				{
					PacketReceived(_currentPacket);
					_currentPacket = null;
					_totalRetryTimes = 0;
					_latestReceivedResponseTime = DateTimeOffset.UtcNow;
					data2 = null;
					uwr.Dispose();
					promise.Resolve(true);
				}
				break;
			}
			default:
				promise.Reject((Exception)new HttpRequestException($"网络异常：{packet?.Header?.PacketId}.{num}"));
				break;
			}
		}).Catch((Action<Exception>)delegate(Exception ex)
		{
			promise.Reject(ex);
		});
		return promise;
	}

	public void PacketReceived(GamePacket p)
	{
		object incomingPackets = _incomingPackets;
		lock (incomingPackets)
		{
			_incomingPackets.Enqueue(p);
		}
	}

	protected Header CreateHeader(int serviceId, int token)
	{
		return new Header
		{
			PacketId = serviceId,
			Token = token
		};
	}

	protected void QueuePacket(GamePacket packet)
	{
		object outBoundPackets = _outBoundPackets;
		lock (outBoundPackets)
		{
			_outBoundPackets.Enqueue(packet);
		}
	}

	public void EnqueueErrorInfo(NetworkError error, RPCContext context = null)
	{
		if (error.Type != NetworkErrorTypes.ERROR_OK)
		{
			ILRuntimeDebug.LogError($"Enqueuing NetworkError {error.Type}: {error.Exception}");
			_errors.Add(error);
		}
	}

	public void EnqueueErrorInfoWithoutErrorLog(NetworkError error, RPCContext context = null)
	{
		if (error.Type != NetworkErrorTypes.ERROR_OK)
		{
			_errors.Add(error);
		}
	}

	public int GetErrorsCount()
	{
		return _errors.Count;
	}

	public void GetErrors([Out] NetworkError[] errors)
	{
		_errors.CopyTo(errors);
	}

	public void ClearErrors()
	{
		_errors.Clear();
	}

	public void SendEnqueueErrorInfo(HttpRequestException ex)
	{
		EnqueueErrorInfo(new NetworkError(NetworkErrorTypes.NETWORK_ISSUE, ex));
	}

	public void SendEnqueueErrorInfoWithoutErrorLog(Exception ex)
	{
		EnqueueErrorInfoWithoutErrorLog(new NetworkError(NetworkErrorTypes.NETWORK_ISSUE, ex));
	}

	private void RPCRecord(GamePacket packet, string msg = "")
	{
		if (HotUpdateProcess.RPCRecord && RpcTimeRecord.TryGetValue(packet.Header.Token, out var value))
		{
			int num = (int)DateTimeHelper.Now.ToUnixTimeMilliseconds() - value;
			if (num > 1000)
			{
				ThinkingDataHelper.Instance.RPCRecord(packet.Header.PacketId, packet.Header.Token, num, msg);
			}
		}
		RpcTimeRecord.Remove(packet.Header.Token);
	}

	public WaitingGamePacket[] GetWaitingGamePackets()
	{
		return _waitingGamePackets.Values.ToArray();
	}

	public void OnPacketBegin(int token, int packetId)
	{
		WaitingGamePacket value = new WaitingGamePacket
		{
			BeginStamp = DateTimeHelper.Now.ToUnixTimeSeconds(),
			PacketId = packetId,
			RetryTimes = 0
		};
		_waitingGamePackets[token] = value;
	}

	public void OnPacketRetry(int token, int retryTime)
	{
		if (_waitingGamePackets.TryGetValue(token, out var value))
		{
			value.RetryTimes = retryTime;
			value.BeginStamp = DateTimeHelper.Now.ToUnixTimeSeconds();
		}
	}

	public void OnPacketEnd(int token)
	{
		_waitingGamePackets.Remove(token);
	}
}
