using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Assets.Scripts.Managers;
using HotFix;
using RSG;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.RPC;
using UnityEngine;
using UnityEngine.Networking;

namespace Shift.Legion.ClientApi;

public class UnityRequestHelper : MonoBehaviour
{
	public class PostResult
	{
		public int ErrorCode;
	}

	public class CheckNetworkReachabilityParam
	{
		public int PacketId;

		public long TimeEndStamp;
	}

	public class PostContinueEntry
	{
		public int packetId;

		public int token;

		public RPCConnection rpc;

		public Promise<UnityWebRequest> Promise;

		public string url;

		public byte[] data;

		public GamePacket packet = null;

		public int retryTimes = 0;

		public bool NeedAbort => retryTimes > GetMaxRetryTimesForPacket(packetId);

		public void Continue()
		{
			int retryTime = 0;
			rpc.OnPacketRetry(token, retryTime);
			((MonoBehaviour)Instance).StartCoroutine(Instance.UnityPost(rpc, Promise, url, data, packet, retryTime));
		}
	}

	public static UnityRequestHelper Instance;

	private StringBuilder _stringBuilder = new StringBuilder();

	private string _cookies = string.Empty;

	private List<int> _rtts;

	private int _head;

	private const int MaxRttCount = 10;

	public float NetSpdKBps;

	private void Awake()
	{
		_stringBuilder = new StringBuilder();
		_cookies = string.Empty;
		Instance = this;
		InitRtt();
	}

	public void SetToken(string token)
	{
		_cookies = "SESSID=" + token;
	}

	public Promise<UnityWebRequest> Post(RPCConnection rpc, string url, byte[] data, GamePacket packet = null, int retryTimes = 0)
	{
		Promise<UnityWebRequest> val = new Promise<UnityWebRequest>();
		((MonoBehaviour)this).StartCoroutine(UnityPost(rpc, val, url, data, packet, retryTimes));
		return val;
	}

	private IEnumerator UnityPost(RPCConnection rpc, Promise<UnityWebRequest> promise, string url, byte[] data, GamePacket packet = null, int retryTimes = 0)
	{
		int packetId = (packet?.Header?.PacketId).GetValueOrDefault();
		int maxRetryTimes = GetMaxRetryTimesForPacket(packetId);
		if (retryTimes > 0)
		{
			OnPostRetry(rpc, promise, url, data, packet, retryTimes);
		}
		if (retryTimes > maxRetryTimes)
		{
			if (packet != null && packet?.Header.PacketId != packet?.Header?.PacketId && packet?.Header.PacketId != packet?.Header?.PacketId)
			{
				rpc.SendEnqueueErrorInfo(new HttpRequestException(string.Format("{0}{1}{2} ：{3}", LanguagesManager.GetDesc("CsharpCodeZhTcText705"), LanguagesManager.Comma, LanguagesManager.GetDesc("CsharpCodeZhTcText706"), packet?.Header?.PacketId)));
			}
			if (packetId == PacketIds.USER_ACTION_DOWNLOAD_ARCHIVE_REQUEST)
			{
				yield break;
			}
			retryTimes = 0;
		}
		UnityWebRequest val = new UnityWebRequest(url, "POST", (DownloadHandler)new DownloadHandlerBuffer(), (UploadHandler)new UploadHandlerRaw(data));
		val.uploadHandler.contentType = "application/octet-stream";
		UnityWebRequest uwr = val;
		uwr.SetRequestHeader("Accept", "*/*");
		uwr.SetRequestHeader("Accept-Encoding", "gzip, deflate");
		uwr.SetRequestHeader("User-Agent", Network.UserAgentInfo);
		uwr.SetRequestHeader("SIndex", rpc.SIndex);
		if (!string.IsNullOrEmpty(_cookies))
		{
			uwr.SetRequestHeader("Cookie", _cookies);
		}
		PostResult postResult = new PostResult();
		yield return SendWebRequest(uwr, packetId, retryTimes, postResult);
		if (uwr.isNetworkError || uwr.isHttpError || postResult.ErrorCode != 0)
		{
			uwr.Dispose();
			yield return (object)new WaitForSeconds(0.5f);
			CheckNetworkReachability(packetId).Then((Action<bool>)delegate
			{
				((MonoBehaviour)this).StartCoroutine(UnityPost(rpc, promise, url, data, packet, retryTimes + 1));
			}).Catch((Action<Exception>)delegate
			{
				if (packet != null)
				{
					rpc.SendEnqueueErrorInfoWithoutErrorLog(new Exception(string.Format("{0}{1}{2} ：{3}", LanguagesManager.GetDesc("CsharpCodeZhTcText707"), LanguagesManager.Comma, LanguagesManager.GetDesc("CsharpCodeZhTcText708"), packet?.Header?.PacketId)));
				}
				((MonoBehaviour)this).StartCoroutine(UnityPost(rpc, promise, url, data, packet, retryTimes + 1));
			});
		}
		else
		{
			promise.Resolve(uwr);
		}
	}

	private IPromise<bool> CheckNetworkReachability(int packetId)
	{
		Promise<bool> val = new Promise<bool>();
		((MonoBehaviour)this).StartCoroutine(CheckNetworkReachabilityCoroutine(val, packetId));
		return (IPromise<bool>)(object)val;
	}

	private IEnumerator CheckNetworkReachabilityCoroutine(Promise<bool> promise, int packetId)
	{
		string resServerUrl = HotUpdateProcess.Instance.RegionModel.Zone.url.res[0];
		_stringBuilder.Clear();
		_stringBuilder.Append(resServerUrl);
		_stringBuilder.Append("/cnc.txt?t=");
		_stringBuilder.Append(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
		string url = _stringBuilder.ToString();
		for (int i = 0; i < 5; i++)
		{
			int timeoutTime = 4;
			long timeEndStamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + timeoutTime;
			CheckNetworkReachabilityParam param = new CheckNetworkReachabilityParam
			{
				PacketId = packetId,
				TimeEndStamp = timeEndStamp
			};
			SharedMessenger.Broadcast("NETWORK_CONNECTION_CHECK", param);
			UnityWebRequest uwr = UnityWebRequest.Get(url);
			try
			{
				uwr.timeout = timeoutTime;
				yield return uwr.SendWebRequest();
				if (!uwr.isNetworkError && !uwr.isHttpError && uwr.downloadHandler.text.Trim() == "1")
				{
					promise.Resolve(true);
					yield break;
				}
			}
			finally
			{
				((IDisposable)uwr)?.Dispose();
			}
			yield return (object)new WaitForSeconds(0.5f);
		}
		promise.Reject((Exception)null);
	}

	private void InitRtt()
	{
		_rtts = new List<int>();
		_head = 0;
	}

	public int GetRtt()
	{
		if (_rtts.Count == 0)
		{
			return 0;
		}
		float num = 0f;
		foreach (int rtt in _rtts)
		{
			num += (float)rtt;
		}
		return (int)(num / (float)_rtts.Count);
	}

	private IEnumerator SendWebRequest(UnityWebRequest uwr, int pkId, int retryTimes, PostResult result)
	{
		int timeoutTime = (uwr.timeout = GetTimeOutTimeForPacket(pkId, retryTimes));
		UnityWebRequestAsyncOperation asyncOp = uwr.SendWebRequest();
		float startTime = Time.realtimeSinceStartup;
		result.ErrorCode = 0;
		float elapsedSeconds;
		ulong totalBytes;
		while (!((AsyncOperation)asyncOp).isDone)
		{
			float elapsed = Time.realtimeSinceStartup - startTime;
			if (elapsed > (float)timeoutTime)
			{
				result.ErrorCode = 1;
				break;
			}
			totalBytes = uwr.downloadedBytes;
			elapsedSeconds = Time.realtimeSinceStartup - startTime;
			NetSpdKBps = (float)totalBytes / (1024f * elapsedSeconds);
			yield return null;
		}
		elapsedSeconds = Time.realtimeSinceStartup - startTime;
		totalBytes = uwr.downloadedBytes;
		NetSpdKBps = (float)totalBytes / (1024f * elapsedSeconds);
		int rtt = (int)((Time.realtimeSinceStartup - startTime) * 1000f);
		if (_rtts.Count < 10)
		{
			_rtts.Add(rtt);
			_head++;
		}
		else
		{
			_head %= 10;
			_rtts[_head] = rtt;
			_head++;
		}
	}

	private static void OnPostRetry(RPCConnection rpc, Promise<UnityWebRequest> promise, string url, byte[] data, GamePacket packet, int retryTimes)
	{
		int valueOrDefault = (packet?.Header?.PacketId).GetValueOrDefault();
		int valueOrDefault2 = (packet?.Header?.Token).GetValueOrDefault();
		PostContinueEntry arg = new PostContinueEntry
		{
			packetId = valueOrDefault,
			rpc = rpc,
			Promise = promise,
			token = valueOrDefault2,
			url = url,
			data = data,
			packet = packet,
			retryTimes = retryTimes
		};
		SharedMessenger.Broadcast("NETWORK_POST_RETRY", arg);
		rpc.OnPacketRetry(valueOrDefault2, retryTimes);
	}

	private static int GetMaxRetryTimesForPacket(int packedId)
	{
		if (packedId == PacketIds.USER_ACTION_DOWNLOAD_ARCHIVE_REQUEST)
		{
			return 1;
		}
		return 5;
	}

	public static int GetTimeOutTimeForPacket(int packedId, int retryTime)
	{
		if (packedId == PacketIds.USER_ACTION_DOWNLOAD_ARCHIVE_REQUEST)
		{
			return (retryTime > 0) ? 8 : 5;
		}
		return 10;
	}
}
