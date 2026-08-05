using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using HotFix;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.RPC;
using Shift.Legion.ClientApi.RPC.Api;

namespace Shift.Legion.ClientApi;

public class Network
{
	private static string _UserAgentInfo;

	private readonly RPCConnection _gameRpcConnection;

	private readonly RPCConnection _userRpcConnection;

	public static string UserAgentInfo
	{
		get
		{
			return _UserAgentInfo;
		}
		set
		{
			_UserAgentInfo = value;
			BattleUnityRequestHelper.UserAgentInfo = value;
		}
	}

	public CommonApi CommonApi { get; }

	public UserApi UserApi { get; }

	public UserActionApi UserActionApi { get; }

	public MailApi MailApi { get; }

	public AnnouncementApi AnnouncementApi { get; }

	public StoreApi StoreApi { get; }

	public event EventHandler<NetworkError> OnError;

	public event EventHandler<NeedRestartResponse> OnNeedRestart;

	public event EventHandler<NeedReLoginResponse> OnNeedReLogin;

	public Network(Dictionary<string, string> configs)
	{
		SentrySdk.AddBreadcrumb("New Network");
		Interface_Battle.Init();
		MsgIndexer.Instance.Reset();
		List<Api> list = new List<Api>();
		CommonApi = new CommonApi();
		list.Add(CommonApi);
		UserActionApi = new UserActionApi();
		list.Add(UserActionApi);
		MailApi = new MailApi();
		list.Add(MailApi);
		StoreApi = new StoreApi();
		list.Add(StoreApi);
		_gameRpcConnection = new RPCConnection(configs["GameServerUrl"], 10, 6);
		_gameRpcConnection.RegisterPacketHandler(PacketIds.NEED_RESTART, NeedRestartHandler);
		_gameRpcConnection.RegisterPacketHandler(PacketIds.NEED_RE_LOGIN, NeedReLoginHandler);
		foreach (Api item in list)
		{
			item.InitRPCListeners(_gameRpcConnection);
		}
		UserApi = new UserApi(configs);
		_userRpcConnection = new RPCConnection(configs["AuthServerUrl"] + "packet", 10, 6);
		_userRpcConnection.RegisterPacketHandler(PacketIds.NEED_RESTART, NeedRestartHandler);
		_userRpcConnection.RegisterPacketHandler(PacketIds.NEED_RE_LOGIN, NeedReLoginHandler);
		UserApi.InitRPCListeners(_userRpcConnection);
		AnnouncementApi = new AnnouncementApi();
		AnnouncementApi.InitRPCListeners(_userRpcConnection);
	}

	private void NeedRestartHandler(RPCContext c)
	{
		NeedRestartResponse e = c.Payload.As<NeedRestartResponse>();
		this.OnNeedRestart?.Invoke(this, e);
	}

	private void NeedReLoginHandler(RPCContext c)
	{
		NeedReLoginResponse e = c.Payload.As<NeedReLoginResponse>();
		this.OnNeedReLogin?.Invoke(this, e);
	}

	public void SetToken(string token)
	{
		_gameRpcConnection.Token = token;
		_userRpcConnection.Token = token;
		_gameRpcConnection.SIndex = HotUpdateProcess.SIndex;
	}

	public RPCConnection.WaitingGamePacket[] GetWaitingGamePackets()
	{
		return _gameRpcConnection.GetWaitingGamePackets();
	}

	public void Update()
	{
		if (_gameRpcConnection.TotalRetryTimes > 15 && DateTimeOffset.UtcNow - _gameRpcConnection.LatestReceivedResponseTime > TimeSpan.FromSeconds(15.0))
		{
			this.OnNeedRestart?.Invoke(this, new NeedRestartResponse
			{
				IsEnforced = true,
				Tip = LanguagesManager.GetDesc("CsharpCodeZhTcText34") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText35") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText36")
			});
		}
		else
		{
			_gameRpcConnection.Update();
			_userRpcConnection.Update();
			CommonApi.KeepAlive();
			ProcessErrors(_gameRpcConnection);
			ProcessErrors(_userRpcConnection);
		}
	}

	private void ProcessErrors(RPCConnection connection)
	{
		int errorsCount = connection.GetErrorsCount();
		if (errorsCount > 0)
		{
			NetworkError[] array = new NetworkError[errorsCount];
			connection.GetErrors(array);
			NetworkError[] array2 = array;
			foreach (NetworkError errorType in array2)
			{
				FireErrorEvent(errorType);
			}
			connection.ClearErrors();
		}
	}

	protected void FireErrorEvent(NetworkError errorType)
	{
		this.OnError?.Invoke(this, errorType);
	}
}
