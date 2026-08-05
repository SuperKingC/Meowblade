using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using Entitas;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.Managers;
using HotFix.Sources.Base.Scripts.UI;
using HotFix.Sources.Base.Scripts.UserTrack;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Services.UiService;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Enums.Sources;
using HotFix.Sources.ThirdParty.SDKs.Android;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;
using Spine.Unity;
using UI.AccountInfo;
using UI.LegendItemDungeon;
using UI.Tips;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UI;

namespace UI.LoginAndName;

public class UI_WechatLogin : GComponent, IUiController, IAnyLoadingPanelStatusListener
{
	private class LoginBtnModel
	{
		private string _prefix;

		public EventCallback0 ClickAction;

		public string GetImageUrl(string languageKey)
		{
			return "ui://PublicResources/" + languageKey + "_" + _prefix + "LoginBtn";
		}

		public LoginBtnModel(eLoginSDKCode sdkCode, EventCallback0 clickAction)
		{
			_prefix = sdkCode.ToString().Replace("LoginSDK", "");
			ClickAction = clickAction;
		}
	}

	public Controller pageSwitch;

	public GLoader background;

	public UI_SoldierSfxContent SoldierSfxContent;

	public UI_LogoIcon n68;

	public GGraph workerBack;

	public GGraph soldierBack1;

	public GGraph soldierBack2;

	public UI_LoginGroup LoginGroup;

	public UI_LoginGroup_New LoginGroup_New;

	public UI_allReceive startGameBtn;

	public GTextField legoinOrLoadTip;

	public GImage n14;

	public GGroup legionTip;

	public UI_noticeBtn noticeBtn;

	public UI_switchAccountBtn switchAccountBtn;

	public UI_customerServiceBtn customerServiceBtn;

	public UI_AgeRating AgeRating;

	public GGraph ringSfxBack;

	public UI_loginWindow accountPopupWindow;

	public UI_accountWindow accountWindow;

	public UI_NoticeTipPanel NoticeTipPanel;

	public UI_AgreementTipPanel AgreementTipPanel;

	public UI_UpdateProgressBar updateProgressBar;

	public GGraph soldierSfxBack;

	public UI_progressBtn ProgressBar;

	public GTextField ProgressText;

	public GLoader LicenseState;

	public GTextField VersionTitle;

	public GTextField VersionNumber;

	public GGroup VersionInfo;

	public GLoader Agreement;

	public UI_IcpNumber IcpNumber;

	public Transition loading;

	public const string URL = "ui://yb3s7uv7qbt510";

	public static string Name = "UI_WechatLogin";

	private bool _enterGameAfterLogin;

	private HashSet<string> _soldiers = new HashSet<string>();

	private SkeletonAnimation soldier1;

	private SkeletonAnimation soldier2;

	private SkeletonAnimation soldier0;

	private string[] soldierSfxLeftKinds = new string[4] { "S009", "S010", "S019", "S035" };

	private string[] soldierSfxRightKinds = new string[4] { "S011", "S027", "S022", "S014" };

	private int curSoldierLeftSfxKindsIndex;

	private int curSoldierRightSfxKindsIndex;

	private Dictionary<string, List<Vector2>> soldierSfxLeftPosDictionary = new Dictionary<string, List<Vector2>>();

	private Dictionary<string, List<Vector2>> soldierSfxRightPosDictionary = new Dictionary<string, List<Vector2>>();

	private Coroutine RefreshSoldierLeftSfxCoroutine;

	private Coroutine RefreshSoldierRightSfxCoroutine;

	private Coroutine RefreshGainBtnStatusCoroutine;

	private List<GGraph> soldierSfxGraphs = new List<GGraph>();

	private Coroutine UserNameRolling;

	private bool _panelClosed;

	private bool _isLogInAgain;

	private int curUserId = -1;

	private bool autoStart = false;

	private const string ICP_HOME = "IcpHomeUrl";

	private LoginResponse _response;

	private Coroutine _autoStartCoroutine;

	private bool _anyPopDisplayed;

	private Coroutine _waitLoginCoroutine;

	private bool NeedCheckPolicyFirst = false;

	private GameStateEntity _gameStateEntity;

	private int num = 0;

	private static List<string> HarmonyOSDevices = new List<string> { "HUAWEI SGT-AL00" };

	private Coroutine RefreshLoadingTips;

	private UI_ResetPanel ResetPanel;

	private Dictionary<string, LoginBtnModel> _LoginBtnDict = null;

	private const string xiaomiTipKey = "XiaomiTip";

	private const float XiaomiTipDelayTime = 5f;

	private Coroutine showXiaomiTipCoroutine;

	public static string GetURL()
	{
		return "ui://yb3s7uv7qbt510";
	}

	public static UI_WechatLogin CreateInstance()
	{
		return (UI_WechatLogin)(object)UIPackage.CreateObject("LoginAndName", "WechatLogin");
	}

	public static UI_WechatLogin CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WechatLogin).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7qbt510", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected O, but got Unknown
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Expected O, but got Unknown
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Expected O, but got Unknown
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		pageSwitch = ((GComponent)this).GetController("pageSwitch");
		background = (GLoader)((GComponent)this).GetChild("background");
		SoldierSfxContent = (UI_SoldierSfxContent)(object)((GComponent)this).GetChild("SoldierSfxContent");
		n68 = (UI_LogoIcon)(object)((GComponent)this).GetChild("n68");
		workerBack = (GGraph)((GComponent)this).GetChild("workerBack");
		soldierBack1 = (GGraph)((GComponent)this).GetChild("soldierBack1");
		soldierBack2 = (GGraph)((GComponent)this).GetChild("soldierBack2");
		LoginGroup = (UI_LoginGroup)(object)((GComponent)this).GetChild("LoginGroup");
		LoginGroup_New = (UI_LoginGroup_New)(object)((GComponent)this).GetChild("LoginGroup_New");
		startGameBtn = (UI_allReceive)(object)((GComponent)this).GetChild("startGameBtn");
		legoinOrLoadTip = (GTextField)((GComponent)this).GetChild("legoinOrLoadTip");
		string id = "ui://yb3s7uv7qbt510".Replace("ui://", "") + "-" + ((GObject)legoinOrLoadTip).id;
		((GObject)legoinOrLoadTip).text = LanguagesManager.GetDesc(id);
		n14 = (GImage)((GComponent)this).GetChild("n14");
		legionTip = (GGroup)((GComponent)this).GetChild("legionTip");
		noticeBtn = (UI_noticeBtn)(object)((GComponent)this).GetChild("noticeBtn");
		switchAccountBtn = (UI_switchAccountBtn)(object)((GComponent)this).GetChild("switchAccountBtn");
		customerServiceBtn = (UI_customerServiceBtn)(object)((GComponent)this).GetChild("customerServiceBtn");
		AgeRating = (UI_AgeRating)(object)((GComponent)this).GetChild("AgeRating");
		ringSfxBack = (GGraph)((GComponent)this).GetChild("ringSfxBack");
		accountPopupWindow = (UI_loginWindow)(object)((GComponent)this).GetChild("accountPopupWindow");
		accountWindow = (UI_accountWindow)(object)((GComponent)this).GetChild("accountWindow");
		NoticeTipPanel = (UI_NoticeTipPanel)(object)((GComponent)this).GetChild("NoticeTipPanel");
		AgreementTipPanel = (UI_AgreementTipPanel)(object)((GComponent)this).GetChild("AgreementTipPanel");
		updateProgressBar = (UI_UpdateProgressBar)(object)((GComponent)this).GetChild("updateProgressBar");
		soldierSfxBack = (GGraph)((GComponent)this).GetChild("soldierSfxBack");
		ProgressBar = (UI_progressBtn)(object)((GComponent)this).GetChild("ProgressBar");
		ProgressText = (GTextField)((GComponent)this).GetChild("ProgressText");
		LicenseState = (GLoader)((GComponent)this).GetChild("LicenseState");
		VersionTitle = (GTextField)((GComponent)this).GetChild("VersionTitle");
		string id2 = "ui://yb3s7uv7qbt510".Replace("ui://", "") + "-" + ((GObject)VersionTitle).id;
		((GObject)VersionTitle).text = LanguagesManager.GetDesc(id2);
		VersionNumber = (GTextField)((GComponent)this).GetChild("VersionNumber");
		string id3 = "ui://yb3s7uv7qbt510".Replace("ui://", "") + "-" + ((GObject)VersionNumber).id;
		((GObject)VersionNumber).text = LanguagesManager.GetDesc(id3);
		VersionInfo = (GGroup)((GComponent)this).GetChild("VersionInfo");
		Agreement = (GLoader)((GComponent)this).GetChild("Agreement");
		IcpNumber = (UI_IcpNumber)(object)((GComponent)this).GetChild("IcpNumber");
		loading = ((GComponent)this).GetTransition("loading");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Invalid comparison between Unknown and I4
		((GObject)background).visible = false;
		NeedCheckPolicyFirst = false;
		_anyPopDisplayed = false;
		HotUpdateProcess.Instance.Go_BarText.GetComponent<Text>().font = null;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		((GObject)this).sortingOrder = 1;
		((GProgressBar)ProgressBar).value = 0.0;
		SetLoginGroupVisible(visible: false);
		((GObject)startGameBtn).visible = false;
		startGameBtn.isQQ.SetSelectedIndex(Define.IsPlatformQQ() ? 1 : 0);
		InitStartGameBtn();
		AgeRatingInit();
		pageSwitch.selectedIndex = 0;
		switchAccountBtn.n4.strokeColor = Color32.op_Implicit(new Color32((byte)10, (byte)3, (byte)16, (byte)229));
		((GObject)switchAccountBtn).visible = !GameController.IsAutoLoginAccount;
		noticeBtn.n4.strokeColor = Color32.op_Implicit(new Color32((byte)10, (byte)3, (byte)16, (byte)229));
		SetVersionNumber();
		if (string.IsNullOrEmpty(GameController.Contexts.Service<INetworkService>().GetToken()))
		{
			_enterGameAfterLogin = true;
		}
		GetLoadingTips();
		UiAudioManager.Instance.PlayBackgroundMusic(UiAudioManager.BgmType.Login);
		((GObject)customerServiceBtn).visible = GameController.Configs.TryGetValue("CustomerServiceOnline", out var value) && value == "1";
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			customerServiceBtn.n7.url = "ui://yb3s7uv7qlo450";
		}
		if (TryAutoLoginAccount())
		{
			pageSwitch.selectedIndex = 1;
		}
		else if (SDKHelper.GetSdkType() == SDKManager.eSDKName.YYTX)
		{
			pageSwitch.selectedIndex = 1;
			((YYTXSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.YYTX]).Init();
		}
		else
		{
			if ((int)Application.platform == 11 && SDKManager.Instance.SDKMap.TryGetValue(SDKManager.eSDKName.WeChatSDK, out var value2))
			{
				((WeChatSDK)value2).Init("wxa6206f99c0f8caaf");
			}
			if (HotUpdateProcess.ChannelCode == "taptap" || HotUpdateProcess.ChannelCode == "tapplay")
			{
				((GObject)LoginGroup.n39).visible = false;
			}
			else if (HotUpdateProcess.ChannelCode == "toutiao-android" || HotUpdateProcess.ChannelCode == "gdt-android")
			{
				((GObject)LoginGroup.n39).visible = false;
				((GObject)LoginGroup.PolicyContainer).visible = true;
				((GObject)LoginGroup.agreeCheckBox).touchable = true;
				NeedCheckPolicyFirst = true;
			}
			if (HotUpdateProcess.Instance.IsRegionOutCN)
			{
				SetLoginBtnVisibleIntl();
			}
			else if (SDKManager.CheckVersion())
			{
				SetLoginBtnVisibleNew();
			}
			else
			{
				SetLoginBtnVisible();
			}
			if (GameController.Contexts.gameState.hasUser && GameController.Contexts.gameState.isDataReady)
			{
				StartGameBtnInit();
			}
			else if (HotUpdateProcess.Instance.IsRegionOutCN && (GameLocalDataManager.GetFirstInstallAndRegistMark() & 2) != 2)
			{
				autoStart = true;
				GuestBtnClick();
			}
			else if (HotUpdateProcess.ChannelCode == "bilibili" || HotUpdateProcess.ChannelCode == "xipu" || HotUpdateProcess.ChannelCode == "tapplay")
			{
				SetLoginGroupVisible(visible: true);
				pageSwitch.selectedIndex = 1;
			}
			else if (_enterGameAfterLogin)
			{
				GameController.Instance.TryAutoEnterGame();
				SetLoginGroupVisible(visible: true);
				ShowXiaomiTip();
			}
			else
			{
				GameController.Instance.TryAutoEnterGame();
				pageSwitch.selectedIndex = 1;
			}
		}
		ShowLicenseState();
		ShowIcpNumber();
	}

	private void ShowIcpNumber()
	{
		if (HotUpdateProcess.ChannelCode != "haoyoukuaibao" && HotUpdateProcess.ChannelCode != "bilibili")
		{
			((GObject)IcpNumber).visible = false;
			return;
		}
		((GObject)IcpNumber).visible = true;
		if (HotUpdateProcess.ChannelCode == "haoyoukuaibao" && HotUpdateProcess.Instance.Configs.TryGetValue("IcpHomeUrl", out var value))
		{
			IcpNumber.layout.selectedIndex = 0;
			((GObject)IcpNumber.IcpHomeUrl).text = value;
		}
		else if (HotUpdateProcess.ChannelCode == "bilibili")
		{
			IcpNumber.layout.selectedIndex = 1;
			((GObject)IcpNumber.CopyRightInfo).text = LanguagesManager.GetDesc("CopyRightInfo_BiliBili");
		}
	}

	private void ShowLicenseState()
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			((GObject)LicenseState).visible = false;
		}
	}

	private void OnIosWechatSignInSuccess()
	{
		if (_waitLoginCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(_waitLoginCoroutine);
			_waitLoginCoroutine = null;
		}
	}

	private bool TryAutoLoginAccount()
	{
		if (GameController.IsAutoLoginAccount)
		{
			Debug.LogError((object)"Error: Configs.AutoLoginAccount Should Set to 0");
		}
		return false;
	}

	private void InitStartGameBtn()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			FGUIManager.Instance.AddTextSpecialEffects(startGameBtn.FxWrapper1, "LoginEmbers", new Vector3(1f, 1f, 1f));
			GameObject val = FGUIManager.Instance.AddTextSpecialEffects(startGameBtn.FxWrapper2, "LoginEmbers", new Vector3(1f, 1f, 1f), "Default", 0.5f, delegate(GameObject leftGO)
			{
				//IL_0016: Unknown result type (might be due to invalid IL or missing references)
				leftGO.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
			});
		}
		catch (Exception)
		{
		}
	}

	private void SetVersionNumber()
	{
		string text = ((GameController.UserAgent == "pro" || GameController.UserAgent == "ios_pro") ? "" : GameController.UserAgent);
		((GObject)VersionNumber).text = Application.version + " " + text + " " + ChannelCode.GetChannelCodeMappedValue();
		if (!string.IsNullOrEmpty(HotUpdateProcess.GatewayHeader))
		{
			GTextField versionNumber = VersionNumber;
			((GObject)versionNumber).text = ((GObject)versionNumber).text + "_" + HotUpdateProcess.GatewayHeader;
		}
		if (!string.IsNullOrEmpty(HotUpdateProcess.GatewayCost))
		{
			GTextField versionNumber2 = VersionNumber;
			((GObject)versionNumber2).text = ((GObject)versionNumber2).text + "_" + HotUpdateProcess.GatewayCost;
		}
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			((GObject)VersionInfo).y = 1025f;
			GTextField versionNumber3 = VersionNumber;
			((GObject)versionNumber3).text = ((GObject)versionNumber3).text + " " + HotUpdateProcess.RegionKey + " " + HotUpdateProcess.ZoneKey + " " + HotUpdateProcess.LanguageKey;
		}
	}

	private void GetServerName()
	{
		Task<ServerInfoResponse> _serverInfo = GameController.Contexts.Service<INetworkService>().ServerInfo();
		_serverInfo.GetAwaiter().OnCompleted(delegate
		{
			if (!string.IsNullOrEmpty(_serverInfo.Result.Version) && !string.IsNullOrEmpty(_serverInfo.Result.Name))
			{
				string text = _serverInfo.Result.Version.Substring(0, 5);
				GTextField versionNumber = VersionNumber;
				((GObject)versionNumber).text = ((GObject)versionNumber).text + "_" + _serverInfo.Result.Name + "_" + text;
				FGUIManager.Instance.CustomerServiceQQ = _serverInfo.Result.CustomerServiceQQ;
			}
		});
	}

	public void RegisterUiEventListeners()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Invalid comparison between Unknown and I4
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected O, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Expected O, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected O, but got Unknown
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected O, but got Unknown
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected O, but got Unknown
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Expected O, but got Unknown
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected O, but got Unknown
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Expected O, but got Unknown
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Expected O, but got Unknown
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Expected O, but got Unknown
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		GameController.Contexts.Service<INetworkService>().AddLoginCompleteHandler(OnLoginSuccess);
		((GObject)startGameBtn).onClick.Add(new EventCallback0(StartGameBtnClick));
		((GObject)LoginGroup.wechatBtn).onClick.Add(new EventCallback0(WechatBtnClick));
		((GObject)LoginGroup.taptapBtn).onClick.Add(new EventCallback0(TapTapLoginBtnClick));
		if ((int)Application.platform == 8)
		{
			((GObject)LoginGroup.iosBtn).onClick.Add(new EventCallback0(AppleBtnClick));
		}
		((GObject)LoginGroup.accountBtn).onClick.Add(new EventCallback0(AccountBtnClick));
		((GObject)accountPopupWindow.exit).onClick.Add(new EventCallback0(PopupWindowClosed));
		((GObject)accountPopupWindow.enterGame).onClick.Add(new EventCallback0(EnterGameByAccount));
		((GObject)noticeBtn).onClick.Add(new EventCallback0(ShowAnnouncement));
		((GObject)customerServiceBtn).data = "游戏登录界面";
		((GObject)customerServiceBtn).onClick.Add(new EventCallback1(UiHelper.CustomerServiceOnlineClickLink));
		((GObject)NoticeTipPanel.exit).onClick.Add(new EventCallback0(CloseAnnouncement));
		((GObject)AgreementTipPanel.exit).onClick.Add(new EventCallback0(CloseAgreementTipPanel));
		((GObject)IcpNumber).onClick.Add(new EventCallback0(GoIcpHomePage));
		((GObject)LoginGroup.AgreementBtn).onClick.Add(new EventCallback0(AgreementBtnClick));
		((GObject)LoginGroup.AgreementBtn2).onClick.Add(new EventCallback0(GoAgreementPage));
		((GObject)LoginGroup_New.AgreementBtn).onClick.Add(new EventCallback0(AgreementBtnClick));
		((GObject)LoginGroup.PrivacyBtn).onClick.Add(new EventCallback0(PrivacyBtnClick));
		((GObject)LoginGroup.PrivacyBtn2).onClick.Add(new EventCallback0(GoPrivacyPolicyPage));
		((GObject)LoginGroup.agreeCheckBox).onClick.Add(new EventCallback0(MarkAgreeCheckBox));
		((GObject)LoginGroup_New.PrivacyBtn).onClick.Add(new EventCallback0(PrivacyBtnClick));
		((GObject)AgeRating).onClick.Add(new EventCallback0(AgeTipBtnClick));
		((GObject)switchAccountBtn).onClick.Add(new EventCallback0(ShowAccountInfo));
		((GObject)accountWindow.exit).onClick.Add(new EventCallback0(CloseAccountInfo));
		((GObject)accountWindow.switchAccountBtn).onClick.Add(new EventCallback0(LogInAgain));
		((GObject)accountWindow.CopyBtn).onClick.Add(new EventCallback0(CopyBuffer));
		((GObject)accountPopupWindow.GainBtn).onClick.Add(new EventCallback0(GetCode));
		((GObject)accountWindow.resetBtn).onClick.Add(new EventCallback0(ResetPanelInit));
		((GObject)this).onClick.Add(new EventCallback1(MainUiClick));
		SharedMessenger.AddListener<string>("LOGIN_FAIL", OnLoginFail);
		SharedMessenger.AddListener("LOGOUT", OnLogout);
		SharedMessenger.AddListener<string>("CLOSE_UI", OnOtherUiClosed);
		SharedMessenger.AddListener<string, Dictionary<string, object>>("OPEN_UI", OnOtherUiOpened);
		SharedMessenger.AddListener("IOS_WECHAT_LOGIN_SUCCESS", OnIosWechatSignInSuccess);
		SharedMessenger.AddListener("GET_PROGRESSBAR_NUM", UpdateProgressBar);
		_gameStateEntity = ((Context<GameStateEntity>)GameController.Contexts.gameState).CreateEntity();
		_gameStateEntity.AddAnyLoadingPanelStatusListener(this);
	}

	public void UpdateProgressBar()
	{
		int num = 35;
		int num2 = GDMgr.numMax();
		this.num++;
		((GProgressBar)ProgressBar).value = this.num * 100 / (num2 + num);
		((GObject)ProgressText).text = this.num * 100 / (num2 + num) + "%";
	}

	public void UnregisterUiEventListeners()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Invalid comparison between Unknown and I4
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected O, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected O, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected O, but got Unknown
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Expected O, but got Unknown
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Expected O, but got Unknown
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Expected O, but got Unknown
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Expected O, but got Unknown
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Expected O, but got Unknown
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Expected O, but got Unknown
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Expected O, but got Unknown
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		GameController.Contexts.Service<INetworkService>().RemoveLoginCompleteHandler(OnLoginSuccess);
		((GObject)startGameBtn).onClick.Remove(new EventCallback0(StartGameBtnClick));
		((GObject)LoginGroup.wechatBtn).onClick.Remove(new EventCallback0(WechatBtnClick));
		((GObject)LoginGroup.taptapBtn).onClick.Remove(new EventCallback0(TapTapLoginBtnClick));
		if ((int)Application.platform == 8)
		{
			((GObject)LoginGroup.iosBtn).onClick.Remove(new EventCallback0(AppleBtnClick));
		}
		((GObject)LoginGroup.accountBtn).onClick.Remove(new EventCallback0(AccountBtnClick));
		((GObject)accountPopupWindow.exit).onClick.Remove(new EventCallback0(PopupWindowClosed));
		((GObject)accountPopupWindow.enterGame).onClick.Remove(new EventCallback0(EnterGameByAccount));
		((GObject)noticeBtn).onClick.Remove(new EventCallback0(ShowAnnouncement));
		((GObject)customerServiceBtn).onClick.Remove(new EventCallback1(UiHelper.CustomerServiceOnlineClickLink));
		((GObject)NoticeTipPanel.exit).onClick.Remove(new EventCallback0(CloseAnnouncement));
		((GObject)AgreementTipPanel.exit).onClick.Remove(new EventCallback0(CloseAgreementTipPanel));
		((GObject)IcpNumber).onClick.Remove(new EventCallback0(GoIcpHomePage));
		((GObject)LoginGroup.AgreementBtn).onClick.Remove(new EventCallback0(AgreementBtnClick));
		((GObject)LoginGroup.AgreementBtn2).onClick.Remove(new EventCallback0(GoAgreementPage));
		((GObject)LoginGroup_New.AgreementBtn).onClick.Remove(new EventCallback0(AgreementBtnClick));
		((GObject)LoginGroup.PrivacyBtn).onClick.Remove(new EventCallback0(PrivacyBtnClick));
		((GObject)LoginGroup.PrivacyBtn2).onClick.Remove(new EventCallback0(GoPrivacyPolicyPage));
		((GObject)LoginGroup.agreeCheckBox).onClick.Remove(new EventCallback0(MarkAgreeCheckBox));
		((GObject)LoginGroup_New.PrivacyBtn).onClick.Remove(new EventCallback0(PrivacyBtnClick));
		((GObject)AgeRating).onClick.Remove(new EventCallback0(AgeTipBtnClick));
		((GObject)switchAccountBtn).onClick.Remove(new EventCallback0(ShowAccountInfo));
		((GObject)accountWindow.exit).onClick.Remove(new EventCallback0(CloseAccountInfo));
		((GObject)accountWindow.switchAccountBtn).onClick.Remove(new EventCallback0(LogInAgain));
		((GObject)accountWindow.CopyBtn).onClick.Remove(new EventCallback0(CopyBuffer));
		((GObject)accountPopupWindow.GainBtn).onClick.Remove(new EventCallback0(GetCode));
		((GObject)accountWindow.resetBtn).onClick.Remove(new EventCallback0(ResetPanelInit));
		((GObject)this).onClick.Remove(new EventCallback1(MainUiClick));
		SharedMessenger.RemoveListener<string>("LOGIN_FAIL", OnLoginFail);
		SharedMessenger.RemoveListener("LOGOUT", OnLogout);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnOtherUiClosed);
		SharedMessenger.RemoveListener<string, Dictionary<string, object>>("OPEN_UI", OnOtherUiOpened);
		SharedMessenger.RemoveListener("IOS_WECHAT_LOGIN_SUCCESS", OnIosWechatSignInSuccess);
		SharedMessenger.RemoveListener("GET_PROGRESSBAR_NUM", UpdateProgressBar);
		_gameStateEntity.RemoveAnyLoadingPanelStatusListener(this);
		((Entity)_gameStateEntity).Destroy();
	}

	public void BeforeDestroy()
	{
		if (UserNameRolling != null)
		{
			FGUIManager.Instance.CloseIEnumerator(UserNameRolling);
		}
		if (RefreshGainBtnStatusCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(RefreshGainBtnStatusCoroutine);
		}
		if (RefreshLoadingTips != null)
		{
			FGUIManager.Instance.CloseIEnumerator(RefreshLoadingTips);
		}
		if (showXiaomiTipCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(showXiaomiTipCoroutine);
		}
		((GObject)startGameBtn.FxWrapper1).displayObject.Dispose();
		((GObject)startGameBtn.FxWrapper2).displayObject.Dispose();
		UiAudioManager.Instance.StopBackgroundMusic(isPause: false, UiAudioManager.BgmType.Login);
		foreach (string soldier in _soldiers)
		{
			SpawnManager.Instance.UnloadAnimation(soldier);
		}
		Transform val = ((Component)Camera.main).transform.Find("LoginPrefab");
		if ((Object)(object)val != (Object)null)
		{
			((Component)val).gameObject.SetActive(false);
			Object.Destroy((Object)(object)((Component)val).gameObject, 3f);
		}
	}

	public void Destroy()
	{
		_panelClosed = true;
	}

	public void OnShow()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		LoadSoldierSpine();
		SoldierSfxDataInit();
		RefreshSoldierLeftSfxCoroutine = FGUIManager.Instance.OpenIEnumerator(RefreshSoldierLeftSfx());
		((GComponent)(object)this).SetTimeout(1f).OnComplete((GTweenCallback)delegate
		{
			RefreshSoldierRightSfxCoroutine = FGUIManager.Instance.OpenIEnumerator(RefreshSoldierRightSfx());
		});
		HotUpdateProcess.Instance.ChangeUIToFGUI();
	}

	private void FacebookBtnClick()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 11)
		{
			pageSwitch.selectedIndex = 1;
			((FacebookSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.FacebookSDK]).Login("");
			GameController.Contexts.Service<INetworkService>().SubmitDeviceLog(GameEvent.Login, SystemInfo.deviceUniqueIdentifier, new Dictionary<string, string> { { "LoginType", "Facebook" } });
		}
		else if ((int)Application.platform == 8)
		{
			pageSwitch.selectedIndex = 1;
			SDKManager.Instance.SDKMap_IOS[SDKManager.eSDKName.iOS].FacebookLogin();
		}
	}

	private void TapIntlBtnClick()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 11)
		{
			pageSwitch.selectedIndex = 1;
			((TapTapIntlSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.TapIntlSDK]).Login("");
			GameController.Contexts.Service<INetworkService>().SubmitDeviceLog(GameEvent.Login, SystemInfo.deviceUniqueIdentifier, new Dictionary<string, string> { { "LoginType", "TapTap" } });
		}
	}

	private bool IsWechatLoginByQRCode()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Invalid comparison between Unknown and I4
		string operatingSystem = SystemInfo.operatingSystem;
		string version = Application.version;
		bool flag = AndroidBasicPlugInManager.Instance.IsInstalledByZYT();
		return operatingSystem.Contains("HarmonyOS") || operatingSystem.Contains("OpenHarmony") || HarmonyOSDevices.Contains(SystemInfo.deviceModel) || flag || ((int)Application.platform == 11 && version.EndsWith(".88"));
	}

	private void WechatBtnClick()
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Invalid comparison between Unknown and I4
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Invalid comparison between Unknown and I4
		if (NeedCheckPolicyFirst && !((GObject)LoginGroup.agreeMark).visible)
		{
			ShowTipNeedCheckPolicyFirst();
			return;
		}
		pageSwitch.selectedIndex = 1;
		if (SDKManager.CheckVersion())
		{
			if (IsWechatLoginByQRCode())
			{
				((WeChatSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.WeChatSDK]).GetWechatLoginQRCode();
			}
			else if ((int)Application.platform == 8)
			{
				SDKManager.Instance.SDKMap_IOS[SDKManager.eSDKName.iOS].InitializeWechat("wxa6206f99c0f8caaf");
				SDKManager.Instance.SDKMap_IOS[SDKManager.eSDKName.iOS].SignInWithWechat();
				_waitLoginCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(WaitWechatLoginWithTimeout());
			}
			else if ((int)Application.platform == 11)
			{
				((WeChatSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.WeChatSDK]).Login();
			}
			else
			{
				GameController.Contexts.Service<INetworkService>().Authenticate("user1", "123456");
			}
			GameController.Contexts.Service<INetworkService>().SubmitDeviceLog(GameEvent.Login, SystemInfo.deviceUniqueIdentifier, new Dictionary<string, string> { { "LoginType", "WeChat" } });
		}
		else
		{
			GameController.Contexts.Service<INetworkService>().SubmitDeviceLog(GameEvent.Login, SystemInfo.deviceUniqueIdentifier, new Dictionary<string, string> { { "LoginType", "WeChat" } });
		}
	}

	private IEnumerator WaitWechatLoginWithTimeout()
	{
		yield return (object)new WaitForSeconds(3f);
		"WechatLoginFailedTip".ToLanguage().ToConfirmPopup(delegate
		{
			pageSwitch.SetSelectedIndex(0);
		}, null, (AlignType)0, 40, mirrorBtns: false, needCancelButton: false);
	}

	private async void TapTapLoginBtnClick()
	{
		if (NeedCheckPolicyFirst && !((GObject)LoginGroup.agreeMark).visible)
		{
			ShowTipNeedCheckPolicyFirst();
		}
		else if (FGUIManager.IsTapTap && FGUIManager.TapTapInitFinished)
		{
			pageSwitch.selectedIndex = 1;
			string versionStr = Application.version.Replace(".", "");
			if (versionStr.StartsWith("203") || versionStr.StartsWith("204") || versionStr.StartsWith("210") || versionStr.StartsWith("211"))
			{
				await TapTapSdkManager.Instance.GetTapTapLoginState();
			}
			else if (SDKManager.Instance.SDKMap.ContainsKey(SDKManager.eSDKName.TapTapSDK))
			{
				((TapTapSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.TapTapSDK]).CheckLoginState();
			}
			else
			{
				await TapTapSdkManager.Instance.GetTapTapLoginState();
			}
		}
	}

	private void GoogleLoginBtnClick()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 11)
		{
			pageSwitch.selectedIndex = 1;
			((GoogleSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.GoogleSDK]).Login("");
		}
		else if ((int)Application.platform == 8)
		{
			pageSwitch.selectedIndex = 1;
			SDKManager.Instance.SDKMap_IOS[SDKManager.eSDKName.iOS].GoogleLogin("");
		}
	}

	private void AppleBtnClick()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 8)
		{
			pageSwitch.selectedIndex = 1;
			if (HotUpdateProcess.Instance.IsRegionOutCN)
			{
				SDKManager.Instance.SDKMap_IOS[SDKManager.eSDKName.iOS].InitializeApple();
			}
			else
			{
				SDKManager.Instance.SDKMap_IOS[SDKManager.eSDKName.iOS].InitializeApple();
			}
		}
	}

	private void PopupWindowClosed()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		accountPopupWindow.inputUsername.onChanged.Remove(new EventCallback0(UpdateGainBtnStatus));
		((GObject)accountPopupWindow).visible = false;
		SetLoginGroupVisible(visible: true);
	}

	private void GuestBtnClick()
	{
		pageSwitch.selectedIndex = 1;
		GameLocalDataManager.GuestInfo guestInfo = GameLocalDataManager.GetGuestInfo();
		string value = guestInfo.GuestUserId;
		if (string.IsNullOrEmpty(value) || DateTimeHelper.GetTimeStamp(DateTimeHelper.ServerNow) > guestInfo.ExpireAt)
		{
			string text = Guid.NewGuid().ToString("N");
			GameLocalDataManager.UpdateGuestId(text);
			value = text;
		}
		Dictionary<string, string> obj = new Dictionary<string, string>
		{
			{ "GuestId", value },
			{
				"ChannelCode",
				HotUpdateProcess.ChannelCode
			}
		};
		GameController.Contexts.Service<INetworkService>().AuthenticateByPlatform(JsonHelper.ToJson(obj), "Guest", HotUpdateProcess.ChannelCode);
		GameController.Contexts.Service<INetworkService>().SubmitDeviceLog(GameEvent.Login, SystemInfo.deviceUniqueIdentifier, new Dictionary<string, string> { { "LoginType", "Guest" } });
	}

	private void AccountBtnClick()
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		if (NeedCheckPolicyFirst && !((GObject)LoginGroup.agreeMark).visible)
		{
			ShowTipNeedCheckPolicyFirst();
			return;
		}
		SetLoginGroupVisible(visible: false);
		((GObject)accountPopupWindow).visible = true;
		((GObject)accountPopupWindow.inputUsername).text = "";
		((GObject)accountPopupWindow.inputPassword).text = "";
		((GObject)accountPopupWindow.GainBtn).touchable = false;
		if (accountPopupWindow.GainBtn.PageController.selectedIndex != 2)
		{
			accountPopupWindow.GainBtn.PageController.selectedIndex = 0;
		}
		accountPopupWindow.inputUsername.onChanged.Add(new EventCallback0(UpdateGainBtnStatus));
	}

	private void UpdateGainBtnStatus()
	{
		if (accountPopupWindow.GainBtn.PageController.selectedIndex != 2)
		{
			if (((GObject)accountPopupWindow.inputUsername).text.Length >= 11)
			{
				((GObject)accountPopupWindow.GainBtn).touchable = true;
				accountPopupWindow.GainBtn.PageController.selectedIndex = 1;
			}
			else
			{
				((GObject)accountPopupWindow.GainBtn).touchable = false;
				accountPopupWindow.GainBtn.PageController.selectedIndex = 0;
			}
		}
	}

	private void StartGameBtnClick()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)startGameBtn).onClick.Remove(new EventCallback0(StartGameBtnClick));
		StartGame();
	}

	private async void ShowResetDataDialog(LoginResponse response, PreCheckResponse pcResponse)
	{
		while (!GameController.Contexts.gameState.isDataReady)
		{
			await Task.Delay(100);
		}
		UnityUiService.Instance.OpenPanel(UI_main_ResetAccountPanel.Name, new Dictionary<string, object>
		{
			{ "WechatLoginPanel", this },
			{ "LoginResponse", response },
			{ "PreCheckResponse", pcResponse }
		});
	}

	private void AgeRatingInit()
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			AgeRating.Type.selectedIndex = 0;
		}
		else
		{
			AgeRating.Type.selectedIndex = 1;
		}
	}

	private void LogInAgain()
	{
		if (startGameBtn.ShowSelf.playing)
		{
			startGameBtn.ShowSelf.Stop();
		}
		((GObject)noticeBtn).visible = false;
		((GObject)customerServiceBtn).visible = GameController.Configs.TryGetValue("CustomerServiceOnline", out var value) && value == "1";
		((GObject)AgeRating).visible = false;
		((GObject)switchAccountBtn).visible = false;
		CloseAccountInfo();
		if (!(HotUpdateProcess.ChannelCode == "xipu"))
		{
			SetLoginGroupVisible(visible: true);
		}
		SharedMessenger.Broadcast("SWITCH_ACCOUNT");
	}

	private GGraph GetSoldierSfxGraph()
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		GGraph val = null;
		for (int i = 0; i < soldierSfxGraphs.Count; i++)
		{
			if (((GObject)soldierSfxGraphs[i]).displayObject.isDisposed)
			{
				val = soldierSfxGraphs[i];
				break;
			}
		}
		if (val == null)
		{
			GGraph val2 = new GGraph();
			((GObject)val2).SetSize(100f, 100f);
			val2.DrawRect(100f, 100f, 0, Color.white, Color.white);
			((GObject)val2).alpha = 0f;
			((GObject)val2).SetPivot(0.5f, 0.5f, true);
			((GObject)val2).touchable = false;
			((GComponent)SoldierSfxContent).AddChild((GObject)(object)val2);
			soldierSfxGraphs.Add(val2);
			val = val2;
		}
		return val;
	}

	private IEnumerator RefreshSoldierLeftSfx()
	{
		while (!_panelClosed)
		{
			if (!SpawnManager.Instance.FxLoaded)
			{
				yield return (object)new WaitForSeconds(0.2f);
				continue;
			}
			curSoldierLeftSfxKindsIndex += Random.Range(1, 4);
			curSoldierLeftSfxKindsIndex = ((curSoldierLeftSfxKindsIndex > 3) ? (curSoldierLeftSfxKindsIndex % 4) : curSoldierLeftSfxKindsIndex);
			string soldierSfxKind = soldierSfxLeftKinds[curSoldierLeftSfxKindsIndex];
			string soldierSfxName = "ui_login_army_" + soldierSfxKind;
			Vector2 soldierSfxPos = soldierSfxLeftPosDictionary[soldierSfxKind][Random.Range(0, soldierSfxLeftPosDictionary[soldierSfxKind].Count)];
			GGraph _sfxBack = GetSoldierSfxGraph();
			((GObject)_sfxBack).SetXY(soldierSfxPos.x, soldierSfxPos.y);
			Vector3 sfxSize = new Vector3(100f, 100f, 100f);
			if (soldierSfxName == "ui_login_army_S010")
			{
				sfxSize = new Vector3(50f, 50f, 50f);
			}
			FGUIManager.Instance.AddTextSpecialEffects(_sfxBack, soldierSfxName, sfxSize, "Default", 0.5f, delegate(GameObject soldierSfx)
			{
				soldierSfx.AddComponent<HotFix_DestroySelf>().destroyTime = 3.3f;
			});
			((GComponent)(object)this).SetTimeout(3.3f).OnComplete((GTweenCallback)delegate
			{
				((GObject)_sfxBack).displayObject.Dispose();
			});
			yield return (object)new WaitForSeconds(1f);
		}
	}

	private IEnumerator RefreshSoldierRightSfx()
	{
		while (true)
		{
			if (!SpawnManager.Instance.FxLoaded)
			{
				yield return (object)new WaitForSeconds(0.2f);
				continue;
			}
			curSoldierRightSfxKindsIndex += Random.Range(1, 4);
			curSoldierRightSfxKindsIndex = ((curSoldierRightSfxKindsIndex > 3) ? (curSoldierRightSfxKindsIndex % 4) : curSoldierRightSfxKindsIndex);
			string soldierSfxKind = soldierSfxRightKinds[curSoldierRightSfxKindsIndex];
			string soldierSfxName = "ui_login_army_" + soldierSfxKind;
			Vector2 soldierSfxPos = soldierSfxRightPosDictionary[soldierSfxKind][Random.Range(0, soldierSfxRightPosDictionary[soldierSfxKind].Count)];
			GGraph _sfxBack = GetSoldierSfxGraph();
			((GObject)_sfxBack).SetXY(soldierSfxPos.x, soldierSfxPos.y);
			Vector3 sfxSize = new Vector3(100f, 100f, 100f);
			if (soldierSfxName == "ui_login_army_S027")
			{
				sfxSize = new Vector3(30f, 30f, 30f);
			}
			FGUIManager.Instance.AddTextSpecialEffects(_sfxBack, soldierSfxName, sfxSize, "Default", 0.5f, delegate(GameObject soldierSfx)
			{
				soldierSfx.AddComponent<HotFix_DestroySelf>().destroyTime = 2.3f;
			});
			((GComponent)(object)this).SetTimeout(2.3f).OnComplete((GTweenCallback)delegate
			{
				((GObject)_sfxBack).displayObject.Dispose();
			});
			yield return (object)new WaitForSeconds(1.5f);
		}
	}

	private void SoldierSfxDataInit()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Unknown result type (might be due to invalid IL or missing references)
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0498: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0506: Unknown result type (might be due to invalid IL or missing references)
		//IL_0532: Unknown result type (might be due to invalid IL or missing references)
		//IL_0548: Unknown result type (might be due to invalid IL or missing references)
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_058a: Unknown result type (might be due to invalid IL or missing references)
		curSoldierLeftSfxKindsIndex = Random.Range(0, 4);
		soldierSfxLeftPosDictionary.Add("S009", new List<Vector2>
		{
			new Vector2(114f, 387f),
			new Vector2(326f, 377f),
			new Vector2(129f, 308f),
			new Vector2(270f, 327f),
			new Vector2(106f, 258f),
			new Vector2(308f, 256f),
			new Vector2(408f, 305f)
		});
		soldierSfxLeftPosDictionary.Add("S010", new List<Vector2>
		{
			new Vector2(408f, 542f),
			new Vector2(463f, 479f),
			new Vector2(343f, 495f),
			new Vector2(307f, 454f),
			new Vector2(201f, 468f),
			new Vector2(240f, 548f),
			new Vector2(229f, 612f),
			new Vector2(357f, 627f),
			new Vector2(431f, 651f)
		});
		soldierSfxLeftPosDictionary.Add("S019", new List<Vector2>
		{
			new Vector2(246f, 732f),
			new Vector2(72f, 726f),
			new Vector2(94f, 771f),
			new Vector2(194f, 815f),
			new Vector2(270f, 854f),
			new Vector2(162f, 938f),
			new Vector2(78f, 867f)
		});
		soldierSfxLeftPosDictionary.Add("S035", new List<Vector2>
		{
			new Vector2(604f, 905f),
			new Vector2(686f, 937f),
			new Vector2(485f, 937f),
			new Vector2(458f, 850f),
			new Vector2(691f, 830f),
			new Vector2(563f, 804f),
			new Vector2(465f, 758f),
			new Vector2(523f, 837f),
			new Vector2(654f, 782f)
		});
		curSoldierRightSfxKindsIndex = Random.Range(0, 4);
		soldierSfxRightPosDictionary.Add("S011", new List<Vector2>
		{
			new Vector2(1141f, 817f),
			new Vector2(1088f, 777f),
			new Vector2(1240f, 782f),
			new Vector2(1314f, 842f),
			new Vector2(1231f, 904f),
			new Vector2(1124f, 930f),
			new Vector2(1028f, 844f)
		});
		soldierSfxRightPosDictionary.Add("S027", new List<Vector2>
		{
			new Vector2(1589f, 740f),
			new Vector2(1479f, 725f),
			new Vector2(1402f, 741f),
			new Vector2(1425f, 840f),
			new Vector2(1529f, 838f),
			new Vector2(1590f, 798f)
		});
		soldierSfxRightPosDictionary.Add("S022", new List<Vector2>
		{
			new Vector2(1631f, 495f),
			new Vector2(1770f, 502f),
			new Vector2(1848f, 521f),
			new Vector2(1650f, 615f),
			new Vector2(1553f, 644f),
			new Vector2(1397f, 588f)
		});
		soldierSfxRightPosDictionary.Add("S014", new List<Vector2>
		{
			new Vector2(1592f, 360f),
			new Vector2(1608f, 311f),
			new Vector2(1498f, 277f),
			new Vector2(1523f, 206f),
			new Vector2(1614f, 219f)
		});
	}

	private void LoadSoldierSpine()
	{
		LoadSpine("Goblinworker_Login", "skin_default", workerBack, 0.35f);
	}

	private void ShowAnnouncement()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		((GObject)NoticeTipPanel.noticeTip.tip).text = FGUIManager.Instance.messageTemp;
		HtmlParseOptions htmlParseOptions = NoticeTipPanel.noticeTip.tip.richTextField.htmlParseOptions;
		htmlParseOptions.linkUnderline = true;
		htmlParseOptions.ignoreWhiteSpace = true;
		((DisplayObject)NoticeTipPanel.noticeTip.tip.richTextField).onClickLink.Set(new EventCallback1(UiHelper.FguiTextClickLink));
		((GObject)NoticeTipPanel).visible = true;
		_anyPopDisplayed = true;
		CloseAutoStartCountDown();
	}

	private void AnnouncementInit()
	{
		if (GameLocalDataManager.HasKey("AnnouncementId"))
		{
			int num = GameLocalDataManager.GetInt("AnnouncementId");
			if (num < FGUIManager.Instance.curAnnouncementId)
			{
				GameLocalDataManager.SetInt("AnnouncementId", FGUIManager.Instance.curAnnouncementId);
				ShowAnnouncement();
			}
		}
		else
		{
			ShowAnnouncement();
			GameLocalDataManager.SetInt("AnnouncementId", FGUIManager.Instance.curAnnouncementId);
		}
	}

	private void CloseAnnouncement()
	{
		((GObject)NoticeTipPanel).visible = false;
	}

	private void ShowAccountInfo()
	{
		((GObject)accountWindow.userIdText).text = GameController.Contexts.gameState.user.value.UserId.ToString();
		((GObject)accountWindow.nameBtn.name).text = GameController.Contexts.gameState.user.value.Nickname;
		((GObject)accountWindow.serverName).text = GameController.Contexts.gameState.user.value.ServerName;
		OpenNameTextMobile((GComponent)(object)accountWindow.nameBtn);
		((GObject)accountWindow).visible = true;
	}

	private void ShowTipNeedCheckPolicyFirst()
	{
		SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("TipNeedCheckPolicyFirst") }, 121, arg3: false);
	}

	private void MarkAgreeCheckBox()
	{
		((GObject)LoginGroup.agreeMark).visible = !((GObject)LoginGroup.agreeMark).visible;
	}

	private void CloseAgreementTipPanel()
	{
		((GObject)AgreementTipPanel).visible = false;
	}

	private void ShowAgreementTipPanel(int typeIndex)
	{
		AgreementTipPanel.typeController.selectedIndex = typeIndex;
		AgreementTipPanel.SetControllerPageText();
		((GObject)AgreementTipPanel).visible = true;
		AgreementTipPanel.agreementText.UseLargeText.selectedIndex = 0;
		if (HotUpdateProcess.LanguageKey == "eng")
		{
			AgreementTipPanel.agreementText.UseLargeText.selectedIndex = 1;
		}
	}

	private void GoAgreementPage()
	{
		UiHelper.OpenUrl("https://m." + HotUpdateProcess.Instance.RegionModel.Zone.url.domain + "/user_agreement.html");
	}

	private void GoPrivacyPolicyPage()
	{
		UiHelper.OpenUrl("https://m." + HotUpdateProcess.Instance.RegionModel.Zone.url.domain + "/privacy_policy.html");
	}

	private void GoIcpHomePage()
	{
		if (HotUpdateProcess.Instance.Configs.TryGetValue("IcpHomeUrl", out var value))
		{
			UiHelper.OpenUrl(value);
		}
	}

	private void AgreementBtnClick()
	{
		ShowAgreementTipPanel(0);
	}

	private void PrivacyBtnClick()
	{
		ShowAgreementTipPanel(1);
	}

	private void AgeTipBtnClick()
	{
		if (AgeRating.Type.selectedIndex == 1)
		{
			ShowAgreementTipPanel(2);
		}
	}

	private void GetCode()
	{
		if (((GObject)accountPopupWindow.inputUsername).text.Length != 11 || ((GObject)accountPopupWindow.inputUsername).text[0] != '1')
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText77") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder, arg3: false);
			return;
		}
		GameController.Contexts.Service<INetworkService>().GetTelVerifyCode(((GObject)accountPopupWindow.inputUsername).text);
		if (RefreshGainBtnStatusCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(RefreshGainBtnStatusCoroutine);
		}
		RefreshGainBtnStatusCoroutine = FGUIManager.Instance.OpenIEnumerator(ReGainCode());
	}

	private IEnumerator ReGainCode()
	{
		int time = 60;
		((GObject)accountPopupWindow.GainBtn).touchable = false;
		accountPopupWindow.GainBtn.PageController.selectedIndex = 2;
		while (time > 0)
		{
			((GObject)accountPopupWindow.GainBtn.title).text = string.Format("{0}{1}", time, LanguagesManager.GetDesc("CsharpCodeZhTcText92"));
			yield return (object)new WaitForSeconds(1f);
			time--;
		}
		((GObject)accountPopupWindow.GainBtn).touchable = false;
		accountPopupWindow.GainBtn.PageController.selectedIndex = 0;
		((GObject)accountPopupWindow.GainBtn.title).text = LanguagesManager.GetDesc("CsharpCodeZhTcText78");
		UpdateGainBtnStatus();
		if (RefreshGainBtnStatusCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(RefreshGainBtnStatusCoroutine);
		}
	}

	private void OpenNameTextMobile(GComponent nameUi)
	{
		GObject child = nameUi.GetChild("name");
		if (child.width <= ((GObject)nameUi).width)
		{
			child.x = (((GObject)nameUi).width - child.width) / 2f;
			return;
		}
		child.x = 0f;
		if (UserNameRolling != null)
		{
			FGUIManager.Instance.CloseIEnumerator(UserNameRolling);
		}
		UserNameRolling = FGUIManager.Instance.OpenIEnumerator(FGUIManager.Instance.GoblinNameMobile((GComponent)(object)accountWindow.nameBtn, 30f));
	}

	private void CloseAccountInfo()
	{
		((GObject)accountWindow).visible = false;
		if (UserNameRolling != null)
		{
			FGUIManager.Instance.CloseIEnumerator(UserNameRolling);
		}
	}

	private void CopyBuffer()
	{
		GUIUtility.systemCopyBuffer = ((GObject)accountWindow.userIdText).text;
		List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText82") + "ID" + LanguagesManager.GetDesc("CsharpCodeZhTcText83") };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
	}

	private void LoadSpine(string spineName, string skinName, GGraph workUI, float spineScale)
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		GameObject val = (GameObject)(object)((obj is GameObject) ? obj : null);
		SkeletonAnimation skeletonGraphic = val.GetComponent<SkeletonAnimation>();
		SpawnManager.Instance.LoadAnimation(spineName).Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (!((GObject)this).isDisposed)
			{
				((SkeletonRenderer)skeletonGraphic).skeletonDataAsset = asset;
				((SkeletonRenderer)skeletonGraphic).Initialize(true);
				SpineHelper.SetSkin((ISkeletonAnimation)(object)skeletonGraphic, skinName);
				skeletonGraphic.AnimationState.AddAnimation(0, "idle", true, 0f);
				skeletonGraphic.timeScale = 1f;
				_soldiers.Add(spineName);
			}
		});
		val.transform.localScale = new Vector3(100f, 100f, 100f);
		val.transform.localPosition = -new Vector3(0f, 0f, 0f);
		val.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
		GoWrapper val2 = new GoWrapper(val);
		((DisplayObject)val2).SetXY(0f, 0f);
		((DisplayObject)val2).pivot = new Vector2(0.5f, 0.5f);
		((DisplayObject)val2).scaleX = spineScale;
		((DisplayObject)val2).scaleY = Mathf.Abs(spineScale);
		workUI.SetNativeObject((DisplayObject)(object)val2);
		if (spineName == "S023_login")
		{
			soldier1 = skeletonGraphic;
		}
		if (spineName == "S030_login")
		{
			soldier2 = skeletonGraphic;
		}
	}

	private void GetLoadingTips()
	{
		if (((GObject)legoinOrLoadTip).data != null)
		{
			string[] source = LanguagesManager.GetDesc("CsharpCodeZhTcText833").Split(',');
			RefreshLoadingTips = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(UpdateLoadingTips(source.ToList()));
		}
	}

	private IEnumerator UpdateLoadingTips(List<string> tips)
	{
		while (true)
		{
			int tipIndex = Random.Range(0, tips.Count);
			((GObject)legoinOrLoadTip).text = tips[tipIndex];
			if (tips.Count > 1)
			{
				tips.RemoveAt(tipIndex);
			}
			yield return (object)new WaitForSecondsRealtime(Random.Range(-0.25f, 0.25f) + 0.35f);
		}
	}

	private void ResetPanelInit()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		if (HotUpdateProcess.ChannelCode == "bilibili")
		{
			"目前无法重置数据".ToConfirmPopup(null, null, (AlignType)1, 40, mirrorBtns: false, needCancelButton: false);
			return;
		}
		ResetPanel = UI_ResetPanel.CreateInstance();
		((GObject)ResetPanel.Mask).onClick.Add(new EventCallback0(CloseResetPanel));
		((GObject)ResetPanel.Dialog.yesBtn).enabled = false;
		((GObject)ResetPanel.Dialog.inputUsername).text = "";
		ResetPanel.Dialog.inputUsername.maxLength = UiHelper.ResetTip.Length;
		((GObject)ResetPanel.Dialog.yesBtn).onClick.Add(new EventCallback0(ResetConfirmEvent));
		((GObject)ResetPanel.Dialog.DataBackUp).onClick.Add(new EventCallback0(OpenDataBackUpPanel));
		ResetPanel.Dialog.inputUsername.onChanged.Add(new EventCallback0(WarnningTip));
		((GComponent)GRoot.inst).AddChild((GObject)(object)ResetPanel);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)ResetPanel);
		((GObject)ResetPanel).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		ResetPanel.ShowDialog.Play();
	}

	private void CloseResetPanel()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		((GObject)ResetPanel.Mask).onClick.Remove(new EventCallback0(CloseResetPanel));
		((GObject)ResetPanel.Dialog.yesBtn).onClick.Remove(new EventCallback0(ResetConfirmEvent));
		ResetPanel.Dialog.inputUsername.onChanged.Remove(new EventCallback0(WarnningTip));
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)ResetPanel, true);
	}

	private void WarnningTip()
	{
		string text = ((GObject)ResetPanel.Dialog.inputUsername).text;
		if (text == UiHelper.ResetTip)
		{
			((GObject)ResetPanel.Dialog.yesBtn).enabled = true;
		}
		else
		{
			((GObject)ResetPanel.Dialog.yesBtn).enabled = false;
		}
	}

	private void OpenDataBackUpPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_DataBackUpPanel.Name, new Dictionary<string, object> { 
		{
			"DataBackUpPanelType",
			UI_DataBackUpPanel.DataBackUpPanelType.Optional
		} });
	}

	private static void ResetConfirmEvent()
	{
		Action action = delegate
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_DataBackUpPanel.Name, new Dictionary<string, object> { 
			{
				"DataBackUpPanelType",
				UI_DataBackUpPanel.DataBackUpPanelType.ForceDeletion
			} });
		};
		UiHelper.ResetUserArchive(action);
	}

	private async void ResetArchive(string token)
	{
		ConfirmResetArchiveResponse response = await GameController.Contexts.Service<INetworkService>().ConfirmResetArchive(token);
		if (!response.Result)
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
			return;
		}
		SharedMessenger.Broadcast("NEED_RESTART", new NeedRestartResponse
		{
			Tip = LanguagesManager.GetErrorMessage(response.ErrorCode),
			IsEnforced = true
		});
	}

	public void End(bool unloadResource = false)
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void ShowRestartTip()
	{
		UnityUiService.Instance.OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				LanguagesManager.GetDesc("CsharpCodeZhTcText84") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText85")
			},
			{
				"Buttons",
				new Dictionary<string, Action> { 
				{
					"Confirm",
					HotFix_Utils.Restart
				} }
			},
			{ "PageIndex", 4 },
			{ "ClickSound", "Confirm" },
			{ "Order", 999999 }
		}, multiMode: false, ignoreQueue: true);
	}

	private void ReturnToLogin()
	{
		if (HotUpdateProcess.ChannelCode == "xipu" || HotUpdateProcess.ChannelCode == "bilibili" || HotUpdateProcess.ChannelCode == "tapplay")
		{
			SDKManager.Instance.Logout();
		}
		pageSwitch.selectedIndex = 0;
		_enterGameAfterLogin = true;
		if (!(HotUpdateProcess.ChannelCode == "xipu"))
		{
			SetLoginGroupVisible(visible: true);
		}
		((GObject)noticeBtn).visible = false;
		((GObject)customerServiceBtn).visible = GameController.Configs.TryGetValue("CustomerServiceOnline", out var value) && value == "1";
		((GObject)switchAccountBtn).visible = false;
		((GObject)AgeRating).visible = false;
		autoStart = false;
	}

	private async void OnLoginFail(string errMsg = null)
	{
		UiHelper.LoginTypeStr = string.Empty;
		if (!string.IsNullOrEmpty(errMsg))
		{
			if (HotUpdateProcess.ChannelCode == "xipu" || HotUpdateProcess.ChannelCode == "bilibili" || HotUpdateProcess.ChannelCode == "tapplay")
			{
				errMsg.ToConfirmPopup(delegate
				{
					if (!TryAutoLoginAccount())
					{
						ReturnToLogin();
					}
				}, null, (AlignType)1, 40, mirrorBtns: false, needCancelButton: false);
				return;
			}
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { errMsg }, 121, arg3: false);
		}
		if (!GameController.IsAutoLoginAccount)
		{
			ReturnToLogin();
			return;
		}
		await Task.Delay(1000);
		TryAutoLoginAccount();
	}

	private void OnLogout()
	{
		ReturnToLogin();
	}

	private void OnLoginByAccountFail(string uiName)
	{
		pageSwitch.selectedIndex = 0;
		List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText400") };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
	}

	private void OnOtherUiClosed(string uiName)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)startGameBtn).onClick.Add(new EventCallback0(StartGameBtnClick));
	}

	private void OnOtherUiOpened(string uiName, Dictionary<string, object> parameters)
	{
		if (!(uiName == Name))
		{
			_anyPopDisplayed = true;
			CloseAutoStartCountDown();
		}
	}

	private void EnterGameByAccount()
	{
		if (string.IsNullOrWhiteSpace(((GObject)accountPopupWindow.inputUsername).text) || string.IsNullOrWhiteSpace(((GObject)accountPopupWindow.inputPassword).text))
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText79") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			return;
		}
		if (((GObject)accountPopupWindow.inputUsername).text.Length != 11 || ((GObject)accountPopupWindow.inputUsername).text[0] != '1')
		{
			List<string> arg2 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText80") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, 1, arg3: false);
			return;
		}
		string text = ((GObject)accountPopupWindow.inputUsername).text;
		string text2 = ((GObject)accountPopupWindow.inputPassword).text;
		GameController.Contexts.Service<INetworkService>().Authenticate(text, text2, IdentityType.Telephone);
		GameController.Contexts.Service<INetworkService>().SubmitDeviceLog(GameEvent.Login, SystemInfo.deviceUniqueIdentifier, new Dictionary<string, string>
		{
			{ "TelephoneNo.", text },
			{ "VerificationCode", text2 },
			{ "LoginType", "Telephone" }
		});
		PopupWindowClosed();
		pageSwitch.selectedIndex = 1;
	}

	private void SetLoginBtnVisibleIntl()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		if (_LoginBtnDict == null)
		{
			_LoginBtnDict = new Dictionary<string, LoginBtnModel>
			{
				{
					eLoginSDKCode.GoogleLoginSDK.ToString(),
					new LoginBtnModel(eLoginSDKCode.GoogleLoginSDK, new EventCallback0(GoogleLoginBtnClick))
				},
				{
					eLoginSDKCode.FacebookLoginSDK.ToString(),
					new LoginBtnModel(eLoginSDKCode.FacebookLoginSDK, new EventCallback0(FacebookBtnClick))
				},
				{
					eLoginSDKCode.TapTapLoginSDK.ToString(),
					new LoginBtnModel(eLoginSDKCode.TapTapLoginSDK, new EventCallback0(TapTapLoginBtnClick))
				},
				{
					eLoginSDKCode.TapTapIntlLoginSDK.ToString(),
					new LoginBtnModel(eLoginSDKCode.TapTapIntlLoginSDK, new EventCallback0(TapIntlBtnClick))
				},
				{
					eLoginSDKCode.AppleLoginSDK.ToString(),
					new LoginBtnModel(eLoginSDKCode.AppleLoginSDK, new EventCallback0(AppleBtnClick))
				},
				{
					eLoginSDKCode.AppleOriginalLoginSDK.ToString(),
					new LoginBtnModel(eLoginSDKCode.AppleOriginalLoginSDK, new EventCallback0(AppleBtnClick))
				},
				{
					eLoginSDKCode.GuestLoginSDK.ToString(),
					new LoginBtnModel(eLoginSDKCode.GuestLoginSDK, new EventCallback0(GuestBtnClick))
				},
				{
					eLoginSDKCode.TelephoneLoginSDK.ToString(),
					new LoginBtnModel(eLoginSDKCode.TelephoneLoginSDK, new EventCallback0(AccountBtnClick))
				}
			};
		}
		foreach (Intl_SDKInfo item in HotUpdateProcess.Instance.ChannelConfig.login)
		{
			string key = item.sdkCode.ToString();
			if (_LoginBtnDict.ContainsKey(key))
			{
				UI_CommonLoginBtn uI_CommonLoginBtn = LoginGroup_New.LoginBtnList.AddItemFromPool() as UI_CommonLoginBtn;
				uI_CommonLoginBtn.BtnLoader.url = _LoginBtnDict[key].GetImageUrl(HotUpdateProcess.LanguageKey);
				((GObject)uI_CommonLoginBtn).onClick.Add(_LoginBtnDict[key].ClickAction);
			}
			else
			{
				ILRuntimeDebug.LogError("WrongSdkCode,_loginSDK.sdkCode=" + item.sdkCode);
			}
		}
		if (GameController.Configs.TryGetValue("ML", out var value) && value == "1")
		{
			UI_CommonLoginBtn uI_CommonLoginBtn2 = LoginGroup_New.LoginBtnList.AddItemFromPool() as UI_CommonLoginBtn;
			uI_CommonLoginBtn2.BtnLoader.url = _LoginBtnDict[eLoginSDKCode.TelephoneLoginSDK.ToString()].GetImageUrl(HotUpdateProcess.LanguageKey);
			((GObject)uI_CommonLoginBtn2).onClick.Add(_LoginBtnDict[eLoginSDKCode.TelephoneLoginSDK.ToString()].ClickAction);
		}
		((GObject)LoginGroup_New.LoginBtnList).width = ((GComponent)LoginGroup_New.LoginBtnList).GetChildAt(0).width;
		LoginGroup_New.LoginBtnList.ResizeToFit(LoginGroup_New.LoginBtnList.numItems);
		((GComponent)LoginGroup_New.LoginBtnList).viewHeight = Mathf.Max(((GComponent)LoginGroup_New.LoginBtnList).viewHeight, 300f);
	}

	private void SetLoginBtnVisibleNew()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 8)
		{
			SDKManager.Instance.SDKMap_IOS[SDKManager.eSDKName.iOS].IsHaveWxURL();
			PlatformType platformType = PlatformType.WeChat;
			if (GameController.Configs.TryGetValue("ML", out var value) && value == "1")
			{
				if (HotUpdateProcess.Instance.IsRegionOutCN)
				{
					LoginGroup.PageController.selectedIndex = 14;
				}
				else if (!SDKManager.IsClientValid(platformType))
				{
					LoginGroup.PageController.selectedIndex = 5;
				}
				else
				{
					LoginGroup.PageController.selectedIndex = 1;
				}
			}
			else if (HotUpdateProcess.Instance.IsRegionOutCN)
			{
				LoginGroup.PageController.selectedIndex = 13;
			}
			else if (!SDKManager.IsClientValid(platformType))
			{
				LoginGroup.PageController.selectedIndex = 6;
			}
			else
			{
				LoginGroup.PageController.selectedIndex = 3;
			}
		}
		else if ((int)Application.platform == 11)
		{
			bool flag = false;
			if (GameController.Configs.TryGetValue("ML", out var value2) && value2 == "1")
			{
				if (FGUIManager.IsTapTap && FGUIManager.TapTapInitFinished)
				{
					if (HotUpdateProcess.ChannelCode == "taptap")
					{
						LoginGroup.PageController.selectedIndex = 7;
					}
					else
					{
						LoginGroup.PageController.selectedIndex = 9;
					}
				}
				else if (HotUpdateProcess.Instance.IsRegionOutCN)
				{
					LoginGroup.PageController.selectedIndex = 12;
				}
				else
				{
					LoginGroup.PageController.selectedIndex = 2;
				}
			}
			else if (FGUIManager.IsTapTap && FGUIManager.TapTapInitFinished)
			{
				if (HotUpdateProcess.ChannelCode == "taptap")
				{
					LoginGroup.PageController.selectedIndex = 8;
				}
				else
				{
					LoginGroup.PageController.selectedIndex = 10;
				}
			}
			else if (HotUpdateProcess.Instance.IsRegionOutCN)
			{
				LoginGroup.PageController.selectedIndex = 11;
			}
			else
			{
				LoginGroup.PageController.selectedIndex = 4;
			}
		}
		else
		{
			LoginGroup.PageController.selectedIndex = 0;
		}
	}

	private void SetLoginBtnVisible()
	{
	}

	private void OnLoginSuccess(object sender, LoginResponse response)
	{
		SentrySdk.AddBreadcrumb($"UI_WechatLogin OnLoginSuccess, UserId={response.User?.UserId}");
		if (response.User == null)
		{
			SharedMessenger.Broadcast("LOGIN_FAIL", LanguagesManager.GetDesc("CsharpCodeZhTcText67"));
			return;
		}
		_response = response;
		UiHelper.LoginTypeStr = response.CredentialsTypeStr;
		UserTrackHelper.Instance?.SetUserId(response.User.UserId);
		UnregisterUiEventListeners();
		SentrySdk.AddBreadcrumb("UI_WechatLogin Invoke GameController.OnLoginSuccess");
		GameController.Instance.OnLoginSuccess(response);
		GameController.Instance.SyncTime();
		RegisterUiEventListeners();
		if (GameController.Configs.TryGetValue("ShowFrameRateSwitch", out var value) && value == "1")
		{
			UiHelper.ShowFrameRateSwitch = true;
		}
		SentrySdk.AddBreadcrumb("UI_WechatLogin Invoke PreCheck");
		Task<PreCheckResponse> task = GameController.Contexts.Service<INetworkService>().PreCheck();
		task.GetAwaiter().OnCompleted(delegate
		{
			PreCheckResponse result = task.Result;
			if (result != null && result.ErrorCode == 0 && result.OfflineOldPlayer)
			{
				ShowResetDataDialog(response, result);
			}
			else
			{
				AfterLoginSuccess();
			}
		});
	}

	public async void AfterLoginSuccess()
	{
		if (HotUpdateProcess.ChannelCode == "bilibili")
		{
			BiliBiliSDK sdk = (BiliBiliSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.BiliBiliSDK];
			sdk.NotifyZone();
			sdk.StartHeart();
		}
		LoginResponse response = _response;
		if (response == null)
		{
			SharedMessenger.Broadcast("LOGIN_FAIL", LanguagesManager.GetDesc("CsharpCodeZhTcText67"));
			return;
		}
		while (!GameController.Contexts.gameState.isDataReady)
		{
			await Task.Delay(100);
		}
		PurchaseManager.Instance.InitUnityPurchasing();
		GetServerName();
		GameLocalDataManager.SetID(response.User.UserId);
		CertificationHelper.ShowCertificationDialogOnLoginSuccess();
		GameManagers.Instance.FriendsChatManager.LoadData();
		if ((int)Application.platform != 0 && (int)Application.platform != 7 && GameController.UserAgent != "dev")
		{
			HotFixManager.SetupLog();
		}
		if (curUserId < 0)
		{
			curUserId = response.User.UserId;
			await UiHelper.GetUserProfileUrl();
			await FGUIManager.Instance.GetDynamicStoreContentConfig();
			LegendItemsHelper.LoadReforgeLockSubEntries();
			await LegendItemsHelper.GetLegendItemsData();
			GameManagers.Instance.BpLockManager = new BlueprintLockManager();
			GameManagers.Instance.BpLockManager.Init();
			LegendItemDungeonUiHelper.GetTreasureHuntActivityProgress(await GameController.Contexts.Service<INetworkService>().GetTreasureHuntActivityProgress());
			await LegendItemsHelper.GetLegendItemsDrawCount();
			GetPVPRankSeasonInfoResponse rankSeasonInfoResponse = await GameController.Contexts.Service<INetworkService>().GetPVPRankSeasonInfo(-1L);
			if (rankSeasonInfoResponse.Result)
			{
				RankDataHelper.UpdateRankProgressOnSeasonChange(rankSeasonInfoResponse.SeasonInfo.TurnId);
				RankDataHelper.UpdatePvPPurchaseStat(rankSeasonInfoResponse.SeasonInfo.Id);
				RankDataHelper.UpdateRankSeasonInfo(rankSeasonInfoResponse.SeasonInfo);
				RankDataHelper.UpdateRankProgressOnLoginSuccess(rankSeasonInfoResponse.RankProgress);
				RankDataHelper.UpdateSeasonStoreActivity(rankSeasonInfoResponse.StoreActivityNormal, rankSeasonInfoResponse.StoreActivityTopTournament);
				RankDataHelper.GetPvPRankScoreItem();
				if (RankDataHelper.RankZoneChosen())
				{
					GetCurrentPvPRankGameResponse currentPvPRankGameInfo = await GameController.Contexts.Service<INetworkService>().GetCurrentPvPRankGameInfo();
					if (currentPvPRankGameInfo.Result)
					{
						RankDataHelper.RankStartGameInfo = new RankDataHelper.tRankStartGame(currentPvPRankGameInfo);
					}
					else
					{
						RankDataHelper.RankStartGameInfo = new RankDataHelper.tRankStartGame(null);
					}
				}
				RankDataHelper.SetCurHourValue();
			}
			else
			{
				RankDataHelper.RankStartGameInfo = new RankDataHelper.tRankStartGame(null);
			}
			if (RankDataHelper.IsServerWideBattleOpen)
			{
				IEnumerator coroutine = RankDataHelper.GetAllServersChampionshipInfoCoroutine();
				while (coroutine.MoveNext())
				{
					await Task.Delay(100);
				}
			}
			int lastLoginAt = GameLocalDataManager.GetLastUserLoginAt();
			DateTimeOffset dailyRefreshTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
			if (lastLoginAt < DateTimeHelper.GetTimeStamp(dailyRefreshTime))
			{
				await OnDailyFirstLogin();
			}
			UiHelper.LoadUiSpecialConfig();
			GameLocalDataManager.UpdateLastUserLoginAt();
			ThinkingDataHelper.Instance.UserLoginTrack();
			ThinkingDataHelper.Instance.EnableAutoTrack();
			if (HotUpdateProcess.ChannelCode == "xipu")
			{
				XiPuSDK sdk2 = (XiPuSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.XiPuSDK];
				sdk2.LoginRole();
				sdk2.ShowBallMenu();
			}
			LanguagesManager.LoadLegendItemTextTemplates();
			GameManagers.Instance.UserArchiveManager.UpdateAllLegendSlotCheckRecords();
			if (autoStart)
			{
				StartGame();
				return;
			}
			SetLoginGroupVisible(visible: false);
			pageSwitch.selectedIndex = 0;
			StartGameBtnInit();
			((GObject)noticeBtn).visible = true;
			((GObject)customerServiceBtn).visible = GameController.Configs.TryGetValue("CustomerServiceOnline", out var _customerServiceBtnVisible) && _customerServiceBtnVisible == "1";
			AgeRatingInit();
			AnnouncementInit();
			((GObject)switchAccountBtn).visible = !GameController.IsAutoLoginAccount;
			ShowXiaomiTip();
		}
		else
		{
			ShowRestartTip();
		}
	}

	private void StartGameBtnInit()
	{
		((GObject)startGameBtn).visible = true;
		startGameBtn.ShowSelf.Play();
		((GObject)startGameBtn.timeCountDown).visible = false;
		((GObject)startGameBtn.timeCountDownQQ).visible = false;
		if (!_anyPopDisplayed)
		{
			_autoStartCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(AutoStartCountDown());
		}
	}

	private void CloseAutoStartCountDown()
	{
		if (_autoStartCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(_autoStartCoroutine);
			_autoStartCoroutine = null;
			((GObject)startGameBtn.timeCountDown).visible = false;
			((GObject)startGameBtn.timeCountDownQQ).visible = false;
		}
	}

	private IEnumerator AutoStartCountDown()
	{
		((GObject)startGameBtn.timeCountDown).visible = true;
		((GObject)startGameBtn.timeCountDownQQ).visible = true;
		int timeRemain = 5;
		WaitForSeconds wait = new WaitForSeconds(1f);
		int i;
		for (i = timeRemain; i > 0; i--)
		{
			if (((GObject)this).isDisposed)
			{
				yield break;
			}
			((GObject)startGameBtn.timeCountDown).text = "StartGameCountDown".ToLanguage().Format(i);
			((GObject)startGameBtn.timeCountDownQQ).text = "StartGameCountDown".ToLanguage().Format(i);
			yield return wait;
		}
		((GObject)startGameBtn.timeCountDown).text = "StartGameCountDown".ToLanguage().Format(i);
		((GObject)startGameBtn.timeCountDownQQ).text = "StartGameCountDown".ToLanguage().Format(i);
		StartGameBtnClick();
	}

	private void ResetLegendItemsData()
	{
		LegendItemsHelper.ClearLegendItems();
		LegendItemDungeonUiHelper.ClearDungeonData();
	}

	private async Task OnDailyFirstLogin()
	{
		SwitchRecycleMultiplayerEnableResponse response = await GameController.Contexts.Service<INetworkService>().SwitchRecycleMultiplayerEnable(enable: true);
		if (response.Result)
		{
			GameManagers.Instance.RecycleManager.RecycleEnableMultiplayer.SetValue(response.Enable);
		}
	}

	private async Task CheckIsNewGuideMode()
	{
		if (!GameController.IsNewGuideMode || GameManagers.Instance.UserArchiveManager.IsNewGuideMode())
		{
			return;
		}
		SetAsNewGuideModeResponse response = await GameController.Contexts.Service<INetworkService>().SetAsNewGuideMode();
		if (!response.Result)
		{
			return;
		}
		GameManagers.Instance.UserArchiveManager.SetStoryNodeConfigVersion(response.StoryNodeConfigVersion);
		if (!ArchiveExtension_NewGuideMode.NewGuideModes.Contains(response.NewGuideMode))
		{
			return;
		}
		GameManagers.Instance.UserArchiveManager.SetNewGuideMode(response.NewGuideMode);
		List<string> stories = GameManagers.Instance.UserArchiveManager.GetUndergoingStories().ToList();
		for (int i = 0; i < stories.Count; i++)
		{
			GameManagers.Instance.UserArchiveManager.RemoveFromUndergoingStories(stories[i]);
		}
		List<string> playing_stories = GameManagers.Instance.UserArchiveManager.GetPlayingStories().ToList();
		for (int j = 0; j < playing_stories.Count; j++)
		{
			GameManagers.Instance.UserArchiveManager.RemovePlayingStory(playing_stories[j]);
		}
		for (int k = 0; k < response.UndergoingStories.Count; k++)
		{
			GameManagers.Instance.UserArchiveManager.AddUndergoingStory(response.UndergoingStories[k]);
		}
		foreach (Mission _m in MissionManager.NewbieMissions.Values)
		{
			_m.Pickup(GameManagers.Instance);
		}
		foreach (Mission _nsm in MissionManager.NewbieSummaryMissions.Values)
		{
			_nsm.Pickup(GameManagers.Instance);
		}
		GameManagers.Instance.MissionManager.RefreshCurNewbieMission();
		GameManagers.Instance.ActivityManager.InitDepartureGift();
		GameManagers.Instance.UserArchiveManager.SetCurrentLevelId(response.CurrentLevelId);
		GameLocalDataManager.SetInt("NewComerSpecialIconShow", 1);
		GameLocalDataManager.SetString("MouseEffectSetting", "on");
	}

	private void SetLoginGroupVisible(bool visible)
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			((GObject)LoginGroup_New).visible = visible;
			((GObject)LoginGroup).visible = false;
		}
		else if (HotUpdateProcess.ChannelCode == "tapplay")
		{
			TapTapSDK tapTapSDK = (TapTapSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.TapTapSDK];
			if (visible && tapTapSDK.UserProfile == null)
			{
				tapTapSDK.CheckLoginState();
			}
			((GObject)LoginGroup).visible = false;
			((GObject)LoginGroup_New).visible = false;
		}
		else if (HotUpdateProcess.ChannelCode == "bilibili")
		{
			BiliBiliSDK biliBiliSDK = (BiliBiliSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.BiliBiliSDK];
			if (visible && !biliBiliSDK.IsLoggedIn)
			{
				biliBiliSDK.Login();
			}
			((GObject)LoginGroup).visible = false;
			((GObject)LoginGroup_New).visible = false;
		}
		else if (HotUpdateProcess.ChannelCode == "xipu")
		{
			XiPuSDK xiPuSDK = (XiPuSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.XiPuSDK];
			if (visible && !xiPuSDK.IsLoggedIn)
			{
				xiPuSDK.Login();
			}
			((GObject)LoginGroup).visible = false;
			((GObject)LoginGroup_New).visible = false;
		}
		else
		{
			((GObject)LoginGroup).visible = visible;
			((GObject)LoginGroup_New).visible = false;
		}
	}

	private async void StartGame()
	{
		await CheckIsNewGuideMode();
		ProfilerPanelOpenTime.Init();
		if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode())
		{
			string guideMode = GameManagers.Instance.UserArchiveManager.GetNewGuideMode();
			ThinkingDataHelper.Instance.SetUserIsNewGuideModeOnce(guideMode);
		}
		else
		{
			ThinkingDataHelper.Instance.SetUserIsNewGuideModeOnce("Old");
		}
		((GObject)startGameBtn).visible = false;
		GetServerStatusResponse statusResponse = await GameController.Contexts.Service<INetworkService>().GetServerStatus();
		if (!statusResponse.Result || statusResponse.Status != 1)
		{
			ILRequestHelper.ShowErrorCode(statusResponse.ErrorCode);
			((GObject)startGameBtn).visible = true;
			((GObject)startGameBtn).onClick.Add(new EventCallback0(StartGameBtnClick));
			return;
		}
		if (RefreshSoldierLeftSfxCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(RefreshSoldierLeftSfxCoroutine);
		}
		if (RefreshSoldierRightSfxCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(RefreshSoldierRightSfxCoroutine);
		}
		pageSwitch.selectedIndex = 1;
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.UpdateStageCameraFrames(0.05f));
		while (!GameController.Contexts.gameState.isDataReady)
		{
			await Task.Delay(100);
		}
		FGUIManager.Instance.BattleAudioManagerInit();
		LegionHelper.PlayerOwnedSoldiersCombatPowerInit(GameManagers.Instance);
		if (Define.GvGMode3UnderDevelopment() && GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1011").Contains("P1130"))
		{
			Singleton<GvGMode3RoomManager>.Instance.GetGSObserverRecord(delegate
			{
				Singleton<GvGOuterTechManager>.Instance.InitGiftBag();
				CreateEnterGameCommand();
			});
		}
		else
		{
			CreateEnterGameCommand();
		}
	}

	private async void CreateEnterGameCommand()
	{
		CommandFactory.CreateEnterGameCommand();
		await GameController.Contexts.Service<INetworkService>().SubmitDeviceLog(GameEvent.EnterGame, SystemInfo.deviceUniqueIdentifier, new Dictionary<string, string> { 
		{
			"UserId",
			GameController.Contexts.gameState.user.value.UserId.ToString()
		} });
	}

	public void OnAnyLoadingPanelStatus(GameStateEntity entity, LoadingPanelStatus value)
	{
		if (value == LoadingPanelStatus.Showing)
		{
			End(unloadResource: true);
		}
	}

	private bool IsXiaomi()
	{
		bool result = false;
		for (int i = 0; i < UiHelper.xiaomiDeviceModel.Count; i++)
		{
			if (SystemInfo.deviceModel.ToLower().Contains(UiHelper.xiaomiDeviceModel[i].ToLower()))
			{
				result = true;
				break;
			}
		}
		return result;
	}

	private void ShowXiaomiTip()
	{
		if (UiHelper.xiaomiTipShowed || UI_ConfirmPopupDontShowAgain.IsDontShowAgain("XiaomiTip") || !IsXiaomi() || HotUpdateProcess.ChannelCode == "bilibili")
		{
			return;
		}
		if (UiHelper.needShowXiaomiTipOnLogin)
		{
			UiHelper.needShowXiaomiTipOnLogin = false;
			UiHelper.xiaomiTipShowed = true;
			showXiaomiTipDialog();
			return;
		}
		if (showXiaomiTipCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(showXiaomiTipCoroutine);
		}
		showXiaomiTipCoroutine = FGUIManager.Instance.OpenIEnumerator(ShowXiaomiTip_Enumerator(0f));
	}

	private void showXiaomiTipDialog()
	{
		string value = LanguagesManager.GetDesc("CsharpCodeZhTcText403") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText404") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText405") + "X" + LanguagesManager.GetDesc("CsharpCodeZhTcText406") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText407") + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText408") + " m." + HotUpdateProcess.Instance.RegionModel.Zone.url.domain + " " + LanguagesManager.GetDesc("CsharpCodeZhTcText409") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText410");
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_ConfirmPopupDontShowAgain.Name, new Dictionary<string, object>
		{
			{ "TipKey", "XiaomiTip" },
			{ "Content", value },
			{
				"Buttons",
				new Dictionary<string, Action> { 
				{
					"Confirm",
					delegate
					{
					}
				} }
			},
			{ "ClickSound", "Confirm" },
			{ "Order", 999999 }
		});
	}

	private void MainUiClick(EventContext context)
	{
		if (showXiaomiTipCoroutine != null)
		{
			UiHelper.xiaomiTipShowed = true;
			FGUIManager.Instance.CloseIEnumerator(showXiaomiTipCoroutine);
		}
		CloseAutoStartCountDown();
	}

	private IEnumerator ShowXiaomiTip_Enumerator(float curWaitTime)
	{
		if (curWaitTime >= 5f)
		{
			showXiaomiTipDialog();
			UiHelper.xiaomiTipShowed = true;
		}
		else
		{
			yield return (object)new WaitForSeconds(1f);
			curWaitTime += 1f;
			showXiaomiTipCoroutine = FGUIManager.Instance.OpenIEnumerator(ShowXiaomiTip_Enumerator(curWaitTime));
		}
	}
}
