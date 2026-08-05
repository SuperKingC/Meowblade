using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.RPC;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.Waiting;

public class UI_WaitingPanel : GComponent, IUiController
{
	public Controller TypeController;

	public GGraph Mask;

	public GGraph n3;

	public GMovieClip LoadingClip;

	public GGraph n11;

	public GMovieClip LoadingClip2;

	public GTextField progress;

	public GTextField info;

	public GTextField errorInfo;

	public UI_btn_Feedback customerServiceBtn;

	public UI_btn_Retry retryBtn;

	public GGroup n10;

	public Transition loading;

	public Transition buttonAppear;

	public const string URL = "ui://f36jspecwqiz1";

	public static string Name = "UI_WaitingPanel";

	private int _currentErrorPacketId = -1;

	private UnityRequestHelper.PostContinueEntry _args;

	private bool _showDownloadSpd;

	private Coroutine _updateCoroutine;

	private UnityRequestHelper.CheckNetworkReachabilityParam _checkConnection;

	private RPCConnection.WaitingGamePacket _pendingGamePacket;

	public static string GetURL()
	{
		return "ui://f36jspecwqiz1";
	}

	public static UI_WaitingPanel CreateInstance()
	{
		return (UI_WaitingPanel)(object)UIPackage.CreateObject("Waiting", "WaitingPanel");
	}

	public static UI_WaitingPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WaitingPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f36jspecwqiz1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		TypeController = ((GComponent)this).GetController("TypeController");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		n3 = (GGraph)((GComponent)this).GetChild("n3");
		LoadingClip = (GMovieClip)((GComponent)this).GetChild("LoadingClip");
		n11 = (GGraph)((GComponent)this).GetChild("n11");
		LoadingClip2 = (GMovieClip)((GComponent)this).GetChild("LoadingClip2");
		progress = (GTextField)((GComponent)this).GetChild("progress");
		info = (GTextField)((GComponent)this).GetChild("info");
		string id = "ui://f36jspecwqiz1".Replace("ui://", "") + "-" + ((GObject)info).id;
		((GObject)info).text = LanguagesManager.GetDesc(id);
		errorInfo = (GTextField)((GComponent)this).GetChild("errorInfo");
		customerServiceBtn = (UI_btn_Feedback)(object)((GComponent)this).GetChild("customerServiceBtn");
		retryBtn = (UI_btn_Retry)(object)((GComponent)this).GetChild("retryBtn");
		n10 = (GGroup)((GComponent)this).GetChild("n10");
		loading = ((GComponent)this).GetTransition("loading");
		buttonAppear = ((GComponent)this).GetTransition("buttonAppear");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		((GObject)this).visible = false;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		((GObject)this).sortingOrder = 99998;
	}

	public void OnShow()
	{
		_currentErrorPacketId = -1;
		_pendingGamePacket = null;
		RPCConnection.WaitingGamePacket[] waitingGamePackets = GameController.Contexts.Service<INetworkService>().GetWaitingGamePackets();
		RPCConnection.WaitingGamePacket[] array = waitingGamePackets;
		foreach (RPCConnection.WaitingGamePacket waitingGamePacket in array)
		{
			if (waitingGamePacket.PacketId == PacketIds.USER_ACTION_DOWNLOAD_ARCHIVE_REQUEST)
			{
				_currentErrorPacketId = waitingGamePacket.PacketId;
				_pendingGamePacket = waitingGamePacket;
			}
		}
		_showDownloadSpd = _currentErrorPacketId == PacketIds.USER_ACTION_DOWNLOAD_ARCHIVE_REQUEST;
		if (_showDownloadSpd)
		{
			TypeController.SetSelectedIndex(2);
			RefreshErrorInfo();
		}
	}

	public void UpdateVisible(bool waitingVisible)
	{
		((GObject)this).visible = waitingVisible;
		TypeController.selectedIndex = (_showDownloadSpd ? 2 : 0);
		if (_pendingGamePacket != null && _pendingGamePacket.RetryTimes > 0)
		{
			bool flag = _args != null && _args.NeedAbort;
			TypeController.SetSelectedIndex(flag ? 3 : 2);
		}
		if (_updateCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(_updateCoroutine);
			_updateCoroutine = null;
		}
		if (waitingVisible)
		{
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(UpdatePerSeconds());
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		SharedMessenger.AddListener<UnityRequestHelper.PostContinueEntry>("NETWORK_POST_RETRY", OnNetworkRetry);
		SharedMessenger.AddListener<UnityRequestHelper.CheckNetworkReachabilityParam>("NETWORK_CONNECTION_CHECK", OnCheckConnection);
		((GObject)customerServiceBtn).data = "跳小人界面";
		((GObject)customerServiceBtn).onClick.Set(new EventCallback1(OnClickCustomService));
		((GObject)retryBtn).onClick.Set(new EventCallback0(OnClickRetry));
	}

	public void UnregisterUiEventListeners()
	{
		SharedMessenger.RemoveListener<UnityRequestHelper.PostContinueEntry>("NETWORK_POST_RETRY", OnNetworkRetry);
		SharedMessenger.RemoveListener<UnityRequestHelper.CheckNetworkReachabilityParam>("NETWORK_CONNECTION_CHECK", OnCheckConnection);
		((GObject)customerServiceBtn).onClick.Clear();
		((GObject)retryBtn).onClick.Clear();
	}

	private void OnNetworkRetry(UnityRequestHelper.PostContinueEntry args)
	{
		int packetId = args.packetId;
		if (PacketIds.USER_ACTION_DOWNLOAD_ARCHIVE_REQUEST == packetId && (_currentErrorPacketId <= 0 || _currentErrorPacketId == packetId))
		{
			_args = args;
			_currentErrorPacketId = packetId;
			_checkConnection = null;
			int selectedIndex = (_args.NeedAbort ? 3 : 2);
			TypeController.SetSelectedIndex(selectedIndex);
			RefreshErrorInfo();
		}
	}

	private void OnCheckConnection(UnityRequestHelper.CheckNetworkReachabilityParam args)
	{
		if (_currentErrorPacketId == args.PacketId && TypeController.selectedIndex == 2)
		{
			_checkConnection = args;
			RefreshErrorInfo();
		}
	}

	private void OnClickRetry()
	{
		_args.Continue();
		UpdateVisible(waitingVisible: true);
		OnShow();
	}

	private void OnClickCustomService(EventContext context)
	{
		UiHelper.CustomerServiceOnlineClickLink(context);
	}

	private IEnumerator UpdatePerSeconds()
	{
		WaitForSeconds wait = new WaitForSeconds(1f);
		while (!((GObject)this).isDisposed && ((GObject)this).visible)
		{
			RefreshErrorInfo();
			yield return wait;
		}
	}

	private void RefreshErrorInfo()
	{
		if (_pendingGamePacket == null)
		{
			return;
		}
		bool flag = TypeController.selectedIndex == 2;
		string text = string.Empty;
		long num = DateTimeHelper.Now.ToUnixTimeSeconds();
		int num2 = (int)Mathf.Max((float)(_pendingGamePacket.TimeOutStamp - num), 0f);
		int rtt = UnityRequestHelper.Instance.GetRtt();
		int num3 = (GameController.Contexts.gameState.hasUser ? GameController.Contexts.gameState.user.value.UserId : 0);
		float netSpdKBps = UnityRequestHelper.Instance.NetSpdKBps;
		if (flag)
		{
			if (_checkConnection == null)
			{
				text = ((_pendingGamePacket.RetryTimes > 0) ? LanguagesManager.GetDesc("WaitingPanelNetworkRetryTip2").Format(num3, _currentErrorPacketId, _pendingGamePacket.RetryTimes, num2, $"{netSpdKBps:F2}", rtt) : LanguagesManager.GetDesc("WaitingPanelNetworkRetryTip1").Format(num3, _currentErrorPacketId, num2, $"{netSpdKBps:F2}", rtt));
			}
			else
			{
				num2 = (int)Mathf.Max((float)(_checkConnection.TimeEndStamp - num), 0f);
				text = LanguagesManager.GetDesc("WaitingPanelNetworkRetryTip4").Format(num3, num2, $"{netSpdKBps:F2}", rtt);
			}
		}
		else if (TypeController.selectedIndex == 3)
		{
			text = LanguagesManager.GetDesc("WaitingPanelNetworkRetryTip3").Format(num3, _currentErrorPacketId, _pendingGamePacket.RetryTimes - 1, $"{netSpdKBps:F2}", rtt);
		}
		((GObject)errorInfo).text = text;
	}
}
