using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Interface;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.Announcement;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvGServer.Models.BaseSocket;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Ship;
using Shift.Legion.GvGServer.Models.Map;
using UI.GvG3Medal;
using UI.GvG3StoreEntrance;
using UI.GvG3Video;
using UI.GvGBattlePass3;
using UI.GvGLoading;
using UI.GvGOuterTech;
using UI.GvGSettlement;
using UI.GvGShipPopup;
using UI.GvGWorldMap3;
using UI.MainCity;
using UI.Tips;
using UI.UpGrade;
using UnityEngine;

namespace UI.GvGExpeditionHall;

public class UI_GvGExpeditionHallPanel : GComponent, IUiController
{
	public Controller SignInState;

	public Controller SignInPeriodState;

	public Controller IsEmpty;

	public Controller IZConfig;

	public GLoader background;

	public GImage n144;

	public GLoader n145;

	public UI_dec_SceneAnimation n140;

	public UI_com_OuterTechEntryBtn OuterTechEntryBtn;

	public UI_com_ShipEntry ShipEntryBtn;

	public UI_btn_Medal Medal;

	public GButton BackBtn;

	public GButton HelpBtn;

	public UI_com_Title Title;

	public UI_btn_ExpeditionStore ExpeditionStore;

	public UI_btn_Video Video;

	public UI_btn_Announcement Announcements;

	public UI_com_IZInfo IZInfo;

	public UI_com_AvatarFramesPanel ProfileDisplay;

	public GImage n141;

	public GTextField IZName;

	public UI_com_SignedRoomInfo SignedRoomInfo;

	public GList tabList;

	public GTextField RequirementText;

	public UI_btn_SelectRoomBtn SelectRoomBtn;

	public GGroup NotSignedGroup;

	public UI_com_SignInInfo SignInInfo;

	public GTextField EnterRoomText;

	public UI_btn_EnterRoomBtn EnterRoomBtn;

	public UI_btn_ConfirmSettledBtn ConfirmSettledBtn;

	public UI_btn_QuickStart QuickStart;

	public GGroup SignedGroup;

	public UI_NormalBonusPanel NormalBonusPanel;

	public UI_SpecialBonusPanel SpecialBonusPanel;

	public UI_SelectRoomPanel SelectRoomPanel;

	public UI_SelectCampPanel SelectCampPanel;

	public UI_main_CancelApplicationPanel CancelApplicationPanel;

	public UI_main_DungeonDissolvePanel DungeonDissolvePanel;

	public UI_DataComponent DataComponent;

	public UI_main_AnnouncementsPanel AnnouncementsPanel;

	public UI_QuickStartConfirmPanel QuickStartConfirmPanel;

	public const string URL = "ui://k19peou7m0gmt";

	public static string Name = "UI_GvGExpeditionHallPanel";

	private int IZIndexOfSpecialRewards = -1;

	private GvGExpeditionHallModel Data;

	private List<IGvGExpeditionPopup> _SubPanels;

	private Coroutine CheckNoticeCoroutine;

	private bool IsEnteringRoom;

	private UI_btn_scenario_01 _btnIz1;

	private UI_btn_scenario_02 _btnIz2;

	private Coroutine SpecialRewardsExhibitAnimCoroutine = null;

	private int UpdateSignedRoomDataCooldown;

	private const string QUICK_START = "QUICK_START";

	private const string QUICK_START_NO_REMIND = "QUICK_START_NO_REMIND";

	private const string QUICK_START_NO_ENTER_IZ = "QUICK_START_NO_ENTER_IZ";

	private List<IGvGExpeditionPopup> SubPanels
	{
		get
		{
			if (_SubPanels == null)
			{
				_SubPanels = new List<IGvGExpeditionPopup> { NormalBonusPanel, SpecialBonusPanel, SelectCampPanel, SelectRoomPanel };
			}
			return _SubPanels;
		}
	}

	public static string GetURL()
	{
		return "ui://k19peou7m0gmt";
	}

	public static UI_GvGExpeditionHallPanel CreateInstance()
	{
		return (UI_GvGExpeditionHallPanel)(object)UIPackage.CreateObject("GvGExpeditionHall", "GvGExpeditionHallPanel");
	}

	public static UI_GvGExpeditionHallPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGExpeditionHallPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7m0gmt", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SignInState = ((GComponent)this).GetController("SignInState");
		SignInPeriodState = ((GComponent)this).GetController("SignInPeriodState");
		IsEmpty = ((GComponent)this).GetController("IsEmpty");
		IZConfig = ((GComponent)this).GetController("IZConfig");
		background = (GLoader)((GComponent)this).GetChild("background");
		n144 = (GImage)((GComponent)this).GetChild("n144");
		n145 = (GLoader)((GComponent)this).GetChild("n145");
		n140 = (UI_dec_SceneAnimation)(object)((GComponent)this).GetChild("n140");
		OuterTechEntryBtn = (UI_com_OuterTechEntryBtn)(object)((GComponent)this).GetChild("OuterTechEntryBtn");
		ShipEntryBtn = (UI_com_ShipEntry)(object)((GComponent)this).GetChild("ShipEntryBtn");
		Medal = (UI_btn_Medal)(object)((GComponent)this).GetChild("Medal");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		HelpBtn = (GButton)((GComponent)this).GetChild("HelpBtn");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		ExpeditionStore = (UI_btn_ExpeditionStore)(object)((GComponent)this).GetChild("ExpeditionStore");
		Video = (UI_btn_Video)(object)((GComponent)this).GetChild("Video");
		Announcements = (UI_btn_Announcement)(object)((GComponent)this).GetChild("Announcements");
		IZInfo = (UI_com_IZInfo)(object)((GComponent)this).GetChild("IZInfo");
		ProfileDisplay = (UI_com_AvatarFramesPanel)(object)((GComponent)this).GetChild("ProfileDisplay");
		n141 = (GImage)((GComponent)this).GetChild("n141");
		IZName = (GTextField)((GComponent)this).GetChild("IZName");
		SignedRoomInfo = (UI_com_SignedRoomInfo)(object)((GComponent)this).GetChild("SignedRoomInfo");
		tabList = (GList)((GComponent)this).GetChild("tabList");
		RequirementText = (GTextField)((GComponent)this).GetChild("RequirementText");
		SelectRoomBtn = (UI_btn_SelectRoomBtn)(object)((GComponent)this).GetChild("SelectRoomBtn");
		NotSignedGroup = (GGroup)((GComponent)this).GetChild("NotSignedGroup");
		SignInInfo = (UI_com_SignInInfo)(object)((GComponent)this).GetChild("SignInInfo");
		EnterRoomText = (GTextField)((GComponent)this).GetChild("EnterRoomText");
		EnterRoomBtn = (UI_btn_EnterRoomBtn)(object)((GComponent)this).GetChild("EnterRoomBtn");
		ConfirmSettledBtn = (UI_btn_ConfirmSettledBtn)(object)((GComponent)this).GetChild("ConfirmSettledBtn");
		QuickStart = (UI_btn_QuickStart)(object)((GComponent)this).GetChild("QuickStart");
		SignedGroup = (GGroup)((GComponent)this).GetChild("SignedGroup");
		NormalBonusPanel = (UI_NormalBonusPanel)(object)((GComponent)this).GetChild("NormalBonusPanel");
		SpecialBonusPanel = (UI_SpecialBonusPanel)(object)((GComponent)this).GetChild("SpecialBonusPanel");
		SelectRoomPanel = (UI_SelectRoomPanel)(object)((GComponent)this).GetChild("SelectRoomPanel");
		SelectCampPanel = (UI_SelectCampPanel)(object)((GComponent)this).GetChild("SelectCampPanel");
		CancelApplicationPanel = (UI_main_CancelApplicationPanel)(object)((GComponent)this).GetChild("CancelApplicationPanel");
		DungeonDissolvePanel = (UI_main_DungeonDissolvePanel)(object)((GComponent)this).GetChild("DungeonDissolvePanel");
		DataComponent = (UI_DataComponent)(object)((GComponent)this).GetChild("DataComponent");
		AnnouncementsPanel = (UI_main_AnnouncementsPanel)(object)((GComponent)this).GetChild("AnnouncementsPanel");
		QuickStartConfirmPanel = (UI_QuickStartConfirmPanel)(object)((GComponent)this).GetChild("QuickStartConfirmPanel");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		IsEnteringRoom = false;
		string text = Application.version.Replace(".", "");
		if (text.StartsWith("166"))
		{
			"GvG3166VersionForceUpdate".ToLanguage().ToConfirmPopup(delegate
			{
				UiHelper.OpenUrl(HotUpdateProcess.Instance.Configs["ClientUpgradeUrl"] ?? "");
				End();
			}, null, (AlignType)0);
			return;
		}
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		OuterTechEntryBtn.Init();
		Singleton<GvGOuterTechManager>.Instance.SyncSpeedPlan(UpdateSpeedPlanStatus);
		ILRequestHelper<GvGMode3RoomOperationDiabledResponse>.Request((EventContext)null, (Func<Task<GvGMode3RoomOperationDiabledResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3RoomOperationDisabled()), (Action<GvGMode3RoomOperationDiabledResponse>)delegate(GvGMode3RoomOperationDiabledResponse response)
		{
			if (!response.Result)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
				{
					{
						"Content",
						LanguagesManager.TryParseMultiLanguageTip(response.ServerStatusMessage)
					},
					{
						"Buttons",
						new Dictionary<string, Action> { { "Confirm", End } }
					},
					{ "PageIndex", 4 },
					{ "ClickSound", "Confirm" },
					{ "Order", 999999 }
				});
			}
			else
			{
				InitAnnouncementsPanel(response.GvGAnnouncements);
				RealInit();
			}
		});
		Singleton<GvG3StoreManager>.Instance.GetIzGvGStoreActivatedAsync(delegate
		{
		});
		_btnIz1 = (UI_btn_scenario_01)(object)((GComponent)tabList).GetChildAt(0);
		_btnIz2 = (UI_btn_scenario_02)(object)((GComponent)tabList).GetChildAt(1);
	}

	private void RealInit()
	{
		Data = new GvGExpeditionHallModel();
		foreach (IGvGExpeditionPopup subPanel in SubPanels)
		{
			subPanel.Init(Data, this);
		}
		ProfileDisplay.Init();
		RefreshDataAndUpdate();
		UpdateNotice();
		CheckNoticeCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(CheckNotice());
		ShipEntryBtn.Init();
	}

	private void InitAnnouncementsPanel(IEnumerable<GvGAnnouncement> announcements)
	{
		GvGAnnouncement announcement = announcements.OrderByDescending((GvGAnnouncement a) => a.Id).ToList().FirstOrDefault();
		AnnouncementsPanel.Init(announcement, SetAnnouncementBtnVisible);
		void SetAnnouncementBtnVisible(bool btnVisible)
		{
			if (!((GObject)this).isDisposed)
			{
				((GObject)Announcements).visible = btnVisible;
			}
		}
	}

	private IEnumerator CheckNotice()
	{
		Video.CheckRedDot();
		yield return null;
		Singleton<GvG3StoreManager>.Instance.CheckStellarKeyStoreNotice();
		yield return (object)new WaitForSeconds(2f);
		Singleton<GvG3StoreManager>.Instance.CheckGvGStoreNotice();
		yield return (object)new WaitForSeconds(1f);
		Singleton<GvG3StoreManager>.Instance.CheckSoulKeyStoreNotice();
		CheckNoticeCoroutine = null;
	}

	private void UpdateNotice()
	{
		((GObject)ExpeditionStore.RedDot).visible = Singleton<GvG3StoreManager>.Instance.HasSoulKeyStoreNotice_Free || Singleton<GvG3StoreManager>.Instance.HasSoulKeyStoreNotice_Paid || Singleton<GvG3StoreManager>.Instance.HasGvGStoreNotice;
		((GObject)ExpeditionStore.NewHiddenStoreTip).visible = Singleton<GvG3StoreManager>.Instance.HasStellarKeyStoreNotice;
	}

	public void RefreshDataAndUpdate()
	{
		Data.ClearCache();
		Data.GetData(delegate
		{
			if (Data.IsSigned)
			{
				Data.SelectedIZIndex = Data.IZConfigs.IndexOf(Data.SignedInIZ);
			}
			Update();
		});
		Singleton<GvGOuterTechManager>.Instance.SyncSpeedPlan(Update);
	}

	public void RegisterUiEventListeners()
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Expected O, but got Unknown
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Expected O, but got Unknown
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Expected O, but got Unknown
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Expected O, but got Unknown
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Expected O, but got Unknown
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Expected O, but got Unknown
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Expected O, but got Unknown
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Expected O, but got Unknown
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Expected O, but got Unknown
		foreach (IGvGExpeditionPopup subPanel in SubPanels)
		{
			subPanel.RegisterUiEventListeners();
		}
		((GObject)BackBtn).onClick.Set(new EventCallback0(End));
		tabList.selectionController.onChanged.Set(new EventCallback1(OnSelectionChange));
		((GObject)IZInfo.NormalBonusBtn).onClick.Set(new EventCallback1(OnOpenNormalBonus));
		((GObject)IZInfo.SpecialBonusBtn).onClick.Set(new EventCallback1(OnOpenSpecialBonus));
		((GObject)SelectRoomBtn).onClick.Set(new EventCallback1(OnOpenSelectRoomPanel));
		((GObject)SignInInfo.GoToRoomDetailBtn).onClick.Set(new EventCallback1(OnOpenSelectRoomPanel));
		((GObject)SignedRoomInfo.TipBubble.GoToBuildShipBtn).onClick.Set(new EventCallback1(OnGoToBuildShip));
		((GObject)SignedRoomInfo.TipBubble.GoToBuildNewWorkshopBtn).onClick.Set(new EventCallback1(OnGoToBuildNewWorkshop));
		((GObject)SignedRoomInfo.TipBubble.GoToBuildSkyPortalBtn).onClick.Set(new EventCallback1(OnGoToBuildSkyPortal));
		((GObject)SignedRoomInfo.TipBubble.GoToOuterTechLottery).onClick.Set(new EventCallback0(OnGoToOuterTechLottery));
		((GObject)SignedRoomInfo.TipBubble.GoToSpeedPlanClaim).onClick.Set(new EventCallback0(OnGoToSpeedPlanClaim));
		((GObject)SignedRoomInfo.SettlementInfoBtn).onClick.Set(new EventCallback1(OpenSettlementPanel_Info));
		((GObject)SignedRoomInfo.SettlementBubble.GoToSettlementBtn).onClick.Set(new EventCallback1(OpenSettlementPanel_Bonus));
		((GObject)SignedRoomInfo.SettlementBubble.GoToWarOrderBtn).onClick.Set(new EventCallback1(OpenGvG3BattlePass));
		SignedRoomInfo.SignInPeriodState.onChanged.Set(new EventCallback0(OnSignInPeriodStateChange));
		((GObject)EnterRoomBtn).onClick.Set(new EventCallback1(OnEnterRoom));
		((GObject)ConfirmSettledBtn).onClick.Set(new EventCallback0(OnCloseLastIZRoom));
		((GObject)QuickStart).onClick.Set(new EventCallback0(OnQuickStartClick));
		((GObject)HelpBtn).onClick.Set(new EventCallback1(OnOpenHelpPanel));
		ShipEntryBtn.RegisterUiEventListeners();
		OuterTechEntryBtn.RegisterUiEventListeners();
		((GObject)ExpeditionStore).onClick.Set(new EventCallback0(OnOpenStore));
		((GObject)Medal).onClick.Set(new EventCallback0(OnCheckMedals));
		((GObject)Video).onClick.Set(new EventCallback0(OnCheckVideos));
		((GObject)Announcements).onClick.Set(new EventCallback0(OnAnnouncementsClick));
		AnnouncementsPanel.RegisterUiEventListeners();
		QuickStartConfirmPanel.RegisterUiEventListeners();
		S2C_SystemPause.OnPushEvent = (Action<S2C_SystemPause.Request>)Delegate.Combine(S2C_SystemPause.OnPushEvent, new Action<S2C_SystemPause.Request>(OnSystemPause));
		S2C_SystemIZOver.OnPushEvent = (Action<S2C_SystemIZOver.Request>)Delegate.Combine(S2C_SystemIZOver.OnPushEvent, new Action<S2C_SystemIZOver.Request>(OnSystemClose));
		S2C_ShipPlanChangeSoldier.OnPushEvent = (Action<S2C_ShipPlanChangeSoldier.Request>)Delegate.Combine(S2C_ShipPlanChangeSoldier.OnPushEvent, new Action<S2C_ShipPlanChangeSoldier.Request>(OnSoldierStockLimitChange));
		UI_SelectRoomPanel selectRoomPanel = SelectRoomPanel;
		selectRoomPanel.OnStateChange = (Action)Delegate.Combine(selectRoomPanel.OnStateChange, new Action(Update));
		Singleton<GvG3StoreManager>.Instance.RegisterUiEventListeners();
		GvG3StoreManager instance = Singleton<GvG3StoreManager>.Instance;
		instance.OnChangeSoulKeyStoreNotice = (Action)Delegate.Combine(instance.OnChangeSoulKeyStoreNotice, new Action(UpdateNotice));
		GvG3StoreManager instance2 = Singleton<GvG3StoreManager>.Instance;
		instance2.OnChangeGvGStoreNotice = (Action)Delegate.Combine(instance2.OnChangeGvGStoreNotice, new Action(UpdateNotice));
		GvG3StoreManager instance3 = Singleton<GvG3StoreManager>.Instance;
		instance3.OnChangeStellarKeyStoreNotice = (Action)Delegate.Combine(instance3.OnChangeStellarKeyStoreNotice, new Action(UpdateNotice));
		SharedMessenger.AddListener<string>("CLOSE_UI", OnCloseAnyUI);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		foreach (IGvGExpeditionPopup subPanel in SubPanels)
		{
			subPanel.UnregisterUiEventListeners();
		}
		((GObject)BackBtn).onClick.Clear();
		tabList.selectionController.onChanged.Remove(new EventCallback1(OnSelectionChange));
		((GObject)IZInfo.NormalBonusBtn).onClick.Clear();
		((GObject)IZInfo.SpecialBonusBtn).onClick.Clear();
		((GObject)SelectRoomBtn).onClick.Clear();
		((GObject)SignInInfo.GoToRoomDetailBtn).onClick.Clear();
		((GObject)SignedRoomInfo.TipBubble.GoToBuildShipBtn).onClick.Clear();
		((GObject)SignedRoomInfo.TipBubble.GoToBuildNewWorkshopBtn).onClick.Clear();
		((GObject)SignedRoomInfo.TipBubble.GoToBuildSkyPortalBtn).onClick.Clear();
		((GObject)SignedRoomInfo.TipBubble.GoToOuterTechLottery).onClick.Clear();
		((GObject)SignedRoomInfo.TipBubble.GoToSpeedPlanClaim).onClick.Clear();
		((GObject)SignedRoomInfo.SettlementBubble.GoToSettlementBtn).onClick.Clear();
		((GObject)SignedRoomInfo.SettlementBubble.GoToWarOrderBtn).onClick.Clear();
		SignedRoomInfo.SignInPeriodState.onChanged.Clear();
		((GObject)EnterRoomBtn).onClick.Clear();
		((GObject)ConfirmSettledBtn).onClick.Clear();
		((GObject)QuickStart).onClick.Clear();
		((GObject)HelpBtn).onClick.Clear();
		ShipEntryBtn.UnregisterUiEventListeners();
		OuterTechEntryBtn.UnregisterUiEventListeners();
		((GObject)ExpeditionStore).onClick.Clear();
		((GObject)Medal).onClick.Clear();
		((GObject)Video).onClick.Clear();
		((GObject)Announcements).onClick.Clear();
		AnnouncementsPanel.UnregisterUiEventListeners();
		QuickStartConfirmPanel.UnregisterUiEventListeners();
		S2C_SystemPause.OnPushEvent = (Action<S2C_SystemPause.Request>)Delegate.Remove(S2C_SystemPause.OnPushEvent, new Action<S2C_SystemPause.Request>(OnSystemPause));
		S2C_SystemIZOver.OnPushEvent = (Action<S2C_SystemIZOver.Request>)Delegate.Remove(S2C_SystemIZOver.OnPushEvent, new Action<S2C_SystemIZOver.Request>(OnSystemClose));
		S2C_ShipPlanChangeSoldier.OnPushEvent = (Action<S2C_ShipPlanChangeSoldier.Request>)Delegate.Remove(S2C_ShipPlanChangeSoldier.OnPushEvent, new Action<S2C_ShipPlanChangeSoldier.Request>(OnSoldierStockLimitChange));
		UI_SelectRoomPanel selectRoomPanel = SelectRoomPanel;
		selectRoomPanel.OnStateChange = (Action)Delegate.Remove(selectRoomPanel.OnStateChange, new Action(Update));
		Singleton<GvG3StoreManager>.Instance.UnregisterUiEventListeners();
		GvG3StoreManager instance = Singleton<GvG3StoreManager>.Instance;
		instance.OnChangeSoulKeyStoreNotice = (Action)Delegate.Remove(instance.OnChangeSoulKeyStoreNotice, new Action(UpdateNotice));
		GvG3StoreManager instance2 = Singleton<GvG3StoreManager>.Instance;
		instance2.OnChangeGvGStoreNotice = (Action)Delegate.Remove(instance2.OnChangeGvGStoreNotice, new Action(UpdateNotice));
		GvG3StoreManager instance3 = Singleton<GvG3StoreManager>.Instance;
		instance3.OnChangeStellarKeyStoreNotice = (Action)Delegate.Remove(instance3.OnChangeStellarKeyStoreNotice, new Action(UpdateNotice));
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnCloseAnyUI);
	}

	private void OnSelectionChange(EventContext context)
	{
		int selectedIndex = tabList.selectedIndex;
		Data.SelectedIZIndex = selectedIndex;
		Update();
	}

	private void OnOpenNormalBonus(EventContext context)
	{
		NormalBonusPanel.IsShow.selectedIndex = 1;
		NormalBonusPanel.OnActivate();
	}

	private void OnOpenSpecialBonus(EventContext context)
	{
		SpecialBonusPanel.IsShow.selectedIndex = 1;
		SpecialBonusPanel.OnActivate();
	}

	private void OnOpenSelectRoomPanel(EventContext context)
	{
		SelectRoomPanel.IsShow.selectedIndex = 1;
		SelectRoomPanel.OnActivate();
	}

	public void OnOpenSelectCampPanel(Dictionary<string, GvGMode3CampInfo> campInfos)
	{
		SelectCampPanel.IsShow.selectedIndex = 1;
		SelectCampPanel.CampInfos = campInfos;
		SelectCampPanel.OnActivate();
	}

	private void OnSignInPeriodStateChange()
	{
		if (SignedRoomInfo.SignInPeriodState.selectedIndex == 3)
		{
			SignedRoomInfo.InitSystemMessage();
		}
		else
		{
			SignedRoomInfo.OnDestroy();
		}
		if (SignedRoomInfo.SignInPeriodState.selectedIndex == 2 || SignedRoomInfo.SignInPeriodState.selectedIndex == 3)
		{
			SetQuickStartBtnState();
		}
	}

	private void OnGoToBuildShip(EventContext context)
	{
		if (SignedRoomInfo.TipBubble.ShipState.selectedIndex == 1)
		{
			"GvGFirstShipBuildingTips".ToShowLanguageTip();
		}
		else if (SignedRoomInfo.TipBubble.ShipState.selectedIndex == 0)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_BuildShipPanel.Name, new Dictionary<string, object>
			{
				{
					"BuildableShipType",
					Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetBuildableShipType()
				},
				{
					"OnBuildStarted",
					new UICallbackParam<Action<UI_main_BuildConfirmPanel.BuildParam>>(delegate
					{
						Data.SyncRecordData(Update);
					})
				}
			});
		}
	}

	private void OnGoToBuildNewWorkshop(EventContext context)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Building", GameManagers.Instance.BuildingManager.GetBuildingByType("9"));
		dictionary.Add("Parent", this);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary);
	}

	private void OnGoToBuildSkyPortal(EventContext context)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Building", GameManagers.Instance.BuildingManager.GetBuildingByType("12"));
		dictionary.Add("Parent", this);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary);
	}

	private void OnGoToOuterTechLottery()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Page", 1);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvGOuterTechPanel.Name, dictionary);
	}

	private void OnGoToSpeedPlanClaim()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Page", 1);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvGOuterTechPanel.Name, dictionary);
	}

	private void OnCloseAnyUI(string uiName)
	{
		if (Data != null && Data.IsInit)
		{
			ShipEntryBtn.Render();
			Data.SyncRecordData(Update);
		}
	}

	private void OnEnterRoom(EventContext context)
	{
		if (!Data.IsInit)
		{
			return;
		}
		if (!Data.IsSigned)
		{
			ILRuntimeDebug.LogError("未报名不能进入副本");
			return;
		}
		if (!Data.IsRoomStarted)
		{
			ILRuntimeDebug.LogError("副本未开始不能进入副本");
			return;
		}
		Singleton<GvG3StoreManager>.Instance.GetIzGvGStoreActivatedAsync(delegate(StoreActivateMode mode)
		{
			if (mode == StoreActivateMode.Manual)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
				{
					{
						"Content",
						"GvG3StoreIsManualActiveTip".ToLanguage()
					},
					{
						"Buttons",
						new Dictionary<string, Action>
						{
							{
								"Confirm",
								delegate
								{
									StartEnterRoom();
								}
							},
							{
								"Cancel",
								delegate
								{
								}
							}
						}
					},
					{ "PageIndex", 0 },
					{ "ClickSound", "Confirm" },
					{ "Order", 999 }
				});
			}
			else
			{
				StartEnterRoom();
			}
		});
	}

	private void StartEnterRoom()
	{
		if (!IsEnteringRoom)
		{
			IsEnteringRoom = true;
			((GObject)EnterRoomBtn).grayed = true;
			((GObject)EnterRoomBtn).touchable = false;
			EnterWorldMap();
		}
	}

	private void OpenSettlementPanel_Info(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvGSettlementPanel.Name, new Dictionary<string, object>
		{
			{ "PageController", 0 },
			{
				"OnClose",
				new UICallbackParam<Action>(UpdateRoomSettlementInfo)
			}
		});
	}

	private void OpenSettlementPanel_Bonus(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvGSettlementPanel.Name, new Dictionary<string, object>
		{
			{ "PageController", 1 },
			{
				"OnClose",
				new UICallbackParam<Action>(UpdateRoomSettlementInfo)
			}
		});
	}

	private void OpenGvG3BattlePass(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3BattlePass.Name, new Dictionary<string, object> { 
		{
			"OnClose",
			new UICallbackParam<Action>(UpdateRoomSettlementInfo)
		} });
	}

	private void OnCloseLastIZRoom()
	{
		if (Data.IsIZReadyToClose)
		{
			ConfirmCloseLastIZRoom();
		}
		else
		{
			GotoSettlementUi();
		}
	}

	private void GotoSettlementUi()
	{
		SettlementReady item = new SettlementReady(Data.IsSettlementBonusClaimed, delegate
		{
			OpenSettlementPanel_Bonus(null);
		});
		SettlementReady item2 = new SettlementReady(Data.IsBattlePassClosed, delegate
		{
			OpenGvG3BattlePass(null);
		});
		List<SettlementReady> list = new List<SettlementReady> { item, item2 };
		foreach (SettlementReady item3 in list)
		{
			if (!item3.IsReady())
			{
				break;
			}
		}
	}

	private void ConfirmCloseLastIZRoom()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"TipTextAlign",
				(object)(AlignType)1
			},
			{
				"Content",
				"GvG3CloseLastIZRoomTips".ToLanguage()
			},
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{
						"Confirm",
						delegate
						{
							((GObject)ConfirmSettledBtn).enabled = false;
							Singleton<GvGMode3RoomManager>.Instance.CloseLastIZRoom(delegate
							{
								RefreshDataAndUpdate();
							}, delegate
							{
								((GObject)ConfirmSettledBtn).enabled = true;
							});
						}
					},
					{ "Cancel", null }
				}
			},
			{ "PageIndex", 0 },
			{ "FontSize", 44 },
			{ "Order", 999999 }
		});
	}

	private void OnSystemPause(S2C_SystemPause.Request req)
	{
		GameController.Contexts.Service<IUiService>().PushBackupAndCloseAllUIs(new List<string>
		{
			UI_main_GvGLoadingPanel.Name,
			UI_main_GvGLoading2Panel.Name,
			UI_UniversalConfirmPopup.Name
		}, toBackupStack: false);
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(DelayRecover_ForceStop());
	}

	private IEnumerator DelayRecover_ForceStop()
	{
		yield return null;
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_MainCity.Name, null);
		while (!GameController.Contexts.Service<IUiService>().HasShowingUi(UI_MainCity.Name))
		{
			yield return null;
		}
	}

	private void OnSystemClose(S2C_SystemIZOver.Request request)
	{
		Singleton<GvGMode3RoomManager>.Instance.ObserverRecord = null;
		RefreshDataAndUpdate();
	}

	private void EnterWorldMap()
	{
		UI_main_GvGLoading2Panel.Open(UI_main_GvGLoading2Panel.eLoadingType.Enter, delegate
		{
			GameLocalDataManager.ClearSpeedPlanLastClaim();
			GameLocalDataManager.ClearSpeedPlanLastPurchase();
			Singleton<GvGMode3RoomManager>.Instance.StopwatchLogInterval("开了GvGLoading");
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvGWorldMap3.Name, null);
		});
	}

	private void OnOpenHelpPanel(EventContext context)
	{
		UiHelper.OpenHelpPage("远征大厅", "远征相关", "远征大厅");
	}

	private void OnOpenStore()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3StoreEntrance.Name, null);
	}

	private void OnCheckMedals()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3Medal.Name, null);
	}

	private void OnCheckVideos()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3Video.Name, null);
	}

	private void OnAnnouncementsClick()
	{
		AnnouncementsPanel.Render();
	}

	public void OnSoldierStockLimitChange(S2C_ShipPlanChangeSoldier.Request req)
	{
		foreach (RItem item in req.SoldierStockLimitChange)
		{
			if (req.IsReturnSoldier)
			{
				GameManagers.Instance.UserArchiveManager.ClearGvGShipPlanSoldierStockChangeInfo(item.ItemId);
			}
		}
		foreach (RItem item2 in req.CurStock)
		{
			GameManagers.Instance.StockController.SetStock(item2.ItemId, item2.cnt, StockInContext.AutoFill);
		}
	}

	private void Update()
	{
		if (Data.IsIZInSettlement)
		{
			((GObject)IZInfo).visible = false;
			SignInState.selectedIndex = 1;
			SignInPeriodState.selectedIndex = (int)Data.SignInPeriodState;
			UpdateRoomSettlementInfo();
		}
		else
		{
			if (Data.IZConfigs == null || Data.IZConfigs.Count == 0)
			{
				return;
			}
			UpdateSignedRoomInfo();
			string iZConfigId = Data.IZConfigs[Data.SelectedIZIndex].IZConfigId;
			bool flag = Data.IsSigned && Data.SignedInIZ.IZConfigId == iZConfigId;
			SignInState.selectedIndex = (flag ? 1 : 0);
			SignInPeriodState.selectedIndex = (int)Data.SignInPeriodState;
			bool flag2 = WorldMapConfigHelper.IsBrawlFightEvent(iZConfigId);
			IZConfig.SetSelectedIndex(flag2 ? 1 : 0);
			bool flag3 = (!Data.IsSigned || Data.SignInPeriodState == eSignInPeriodState.FirstSignInPeriod) && !Data.IsIZInSettlement;
			((GObject)IZInfo).visible = flag3;
			if (flag3)
			{
				UpdateIZInfo();
			}
		}
		RefreshTabList();
	}

	private void RefreshTabList()
	{
		bool flag = !Data.IsIZInSettlement;
		flag &= !Data.IsSigned || Data.SignInPeriodState == eSignInPeriodState.FirstSignInPeriod;
		((GObject)tabList).visible = flag;
	}

	private void UpdateRoomSettlementInfo()
	{
		if (Data.IsIZInSettlement)
		{
			SignedRoomInfo.SettlementBubble.SettlementState.selectedIndex = (Data.IsSettlementBonusClaimed ? 1 : 0);
			SignedRoomInfo.SettlementBubble.WarOrderState.selectedIndex = (Data.IsBattlePassClosed ? 1 : 0);
			ConfirmSettledBtn.Type.SetSelectedIndex(Data.IsIZReadyToClose ? 1 : 0);
		}
	}

	private void UpdateSignedRoomInfo()
	{
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		if (Data.IsSigned)
		{
			UI_com_SignedRoomInfo signedRoomInfo = SignedRoomInfo;
			GvGProcessInfo signedInRoom = Data.SignedInRoom;
			GvGMode3IslandManagerInfo gvGMode3IslandManagerInfo = (GvGMode3IslandManagerInfo)signedInRoom.GetInfo();
			((GObject)IZName).text = Data.IZConfigs[Data.SelectedIZIndex].Title;
			((GObject)signedRoomInfo.CampName).text = gvGMode3IslandManagerInfo.GetCampName(Data.SignedCampId) ?? "";
			signedRoomInfo.Camp.SetSelectedIndex(Data.SignedCampId);
			((GObject)EnterRoomText).text = string.Format(((GObject)DataComponent.EnterRoomText).text, gvGMode3IslandManagerInfo.IZInfo.ShowName, UiHelper.ParseFullTime(gvGMode3IslandManagerInfo.IZInfo.Start), UiHelper.ParseFullTime(gvGMode3IslandManagerInfo.IZInfo.Stop));
			Singleton<GvGMode3RoomManager>.Instance.RecordIzTitle(gvGMode3IslandManagerInfo.IZInfo.ShowName);
			UpdateSignedRoomState();
			if (!Timers.inst.Exists(new TimerCallback(UpdateSignedRoomStatePerSercond)))
			{
				Timers.inst.Add(1f, 0, new TimerCallback(UpdateSignedRoomStatePerSercond));
			}
			UpdateSignInInfo();
			UpdateTipBubble();
			UpdateMessageList();
		}
	}

	private void UpdateIZInfo()
	{
		((GObject)IZInfo).visible = SignInState.selectedIndex == 0 || SignInPeriodState.selectedIndex == 0;
		((GObject)IZInfo).visible = true;
		UI_com_IZInfo iZInfo = IZInfo;
		GvGIZConfigModel gvGIZConfigModel = Data.IZConfigs[Data.SelectedIZIndex];
		GvGMode3IslandManagerInfo gvGMode3IslandManagerInfo = (GvGMode3IslandManagerInfo)(Data.SignedInRoom?.GetInfo());
		((GObject)IZName).text = gvGIZConfigModel.Title;
		Singleton<GvGMode3RoomManager>.Instance.RecordIzTitle((gvGMode3IslandManagerInfo == null) ? gvGIZConfigModel.Title : gvGMode3IslandManagerInfo.IZInfo.ShowName);
		((GObject)iZInfo.DescContainer.Desc).text = LanguagesManager.GetDesc($"GvGMode3_GamePlayDesc{Data.SelectedIZIndex + 1}");
		((GObject)iZInfo.Benefit).text = LanguagesManager.GetDesc($"GvGMode3_CoreGamePlay{Data.SelectedIZIndex + 1}");
		((GObject)iZInfo.Difficulty).text = gvGIZConfigModel.CostTime;
		IsEmpty.selectedIndex = ((gvGIZConfigModel.ProcessCount == 0) ? 1 : 0);
		if (Data.IsSigned && Data.SignedInIZ.IZConfigId != Data.IZConfigs[Data.SelectedIZIndex].IZConfigId)
		{
			IsEmpty.selectedIndex = 1;
		}
		UpdateNormalRewardList();
		UpdateSpecialRewardBtn();
		if (IZIndexOfSpecialRewards != Data.SelectedIZIndex)
		{
			SetSpecialRewardsExhibitAnim();
		}
	}

	private void SetSpecialRewardsExhibitAnim()
	{
		IZInfo.SpecialBonusBtn.RewardType.selectedIndex = 1;
		if (SpecialRewardsExhibitAnimCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(SpecialRewardsExhibitAnimCoroutine);
			SpecialRewardsExhibitAnimCoroutine = null;
		}
		SpecialRewardsExhibitAnimCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(SpecialRewardsExhibitAnim());
	}

	private IEnumerator SpecialRewardsExhibitAnim()
	{
		List<SpecialRewardItem> items = Data.GetGvGStoreRewardsPreview();
		int itemCount = items.Count;
		int i = 0;
		UiHelper.LoadBlueprintIcon(iconName: UiHelper.GetIcon(items[i].ItemId), gLoader: IZInfo.SpecialBonusBtn.RewardDemo);
		while (!((GObject)IZInfo).isDisposed)
		{
			IZInfo.SpecialBonusBtn.ShelveReward.Play();
			yield return (object)new WaitForSeconds(0.3f);
			i = (i + 1) % itemCount;
			UiHelper.LoadBlueprintIcon(iconName: UiHelper.GetIcon(items[i].ItemId), gLoader: IZInfo.SpecialBonusBtn.RewardDemo);
			IZInfo.SpecialBonusBtn.UnshelveReward.Play();
			yield return (object)new WaitForSeconds(1.5f);
		}
	}

	private void UpdateSpecialRewardBtn()
	{
		GvGIZConfigModel gvGIZConfigModel = Data.IZConfigs[Data.SelectedIZIndex];
		if (gvGIZConfigModel.SpecialRewards2 == null || gvGIZConfigModel.SpecialRewards2.Count == 0)
		{
			ILRuntimeDebug.LogError("[UI_GvGExpeditionHallPanel] UpdateSpecialRewardBtn SpecialRewards is null");
		}
	}

	private void UpdateNormalRewardList()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		if (!((GObject)IZInfo.NormalBonusList).isDisposed)
		{
			GvGIZConfigModel gvGIZConfigModel = Data.IZConfigs[Data.SelectedIZIndex];
			GList normalBonusList = IZInfo.NormalBonusList;
			normalBonusList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
			{
				RenderRewardItem(i, (UI_NormalItemSmall)(object)o);
			};
			normalBonusList.numItems = gvGIZConfigModel.Rewards.Count;
		}
	}

	private void RenderRewardItem(int i, UI_NormalItemSmall item)
	{
		GvGIZConfigModel gvGIZConfigModel = Data.IZConfigs[Data.SelectedIZIndex];
		RItem rItem = gvGIZConfigModel.Rewards[i];
		string itemId = rItem.ItemId;
		int num = Shift.Legion.Common.Models.Item.Level(GameManagers.Instance, itemId);
		FGUIManager.Instance.SetItemIconAndFrame(item.icon, itemId);
	}

	private void UpdateSignedRoomStatePerSercond(object param)
	{
		if (Data.IsSigned)
		{
			UpdateTiBubbleBuildingState();
			if (UpdateSignedRoomDataCooldown <= 0)
			{
				Data.UpdateSignedRoomData(UpdateSignedRoomState);
				UpdateSignedRoomDataCooldown = 5;
			}
			else
			{
				UpdateSignedRoomState();
				UpdateSignedRoomDataCooldown--;
			}
		}
	}

	private void UpdateSignedRoomState()
	{
		UI_com_SignedRoomInfo signedRoomInfo = SignedRoomInfo;
		GvGProcessInfo signedInRoom = Data.SignedInRoom;
		GvGMode3IslandManagerInfo gvGMode3IslandManagerInfo = (GvGMode3IslandManagerInfo)signedInRoom.GetInfo();
		((GObject)signedRoomInfo.UserCount).text = $"{gvGMode3IslandManagerInfo.UserCount}/{gvGMode3IslandManagerInfo.UserMaxCount}";
		signedRoomInfo.IsEnoughUser.selectedIndex = ((gvGMode3IslandManagerInfo.UserCount >= gvGMode3IslandManagerInfo.UserMinCount) ? 1 : 0);
		signedRoomInfo.IsRoomStarted.selectedIndex = (Data.IsRoomStarted ? 1 : 0);
		signedRoomInfo.ReadyState.selectedIndex = (Data.IsReady ? 1 : 0);
		RefreshTabList();
		SignInPeriodState.selectedIndex = (int)Data.SignInPeriodState;
		int time = Mathf.Max(gvGMode3IslandManagerInfo.IZInfo.Start - (int)GameController.Instance.GetServerTime(), 0);
		((GObject)signedRoomInfo.CountDown).text = UiHelper.ParseTime(time);
		if (SignInPeriodState.selectedIndex == 1 && ((GObject)IZInfo).visible)
		{
			((GObject)IZInfo).visible = false;
		}
	}

	private void UpdateTipBubble()
	{
		UI_com_TipBubble tipBubble = SignedRoomInfo.TipBubble;
		((GObject)tipBubble.ShipText).text = ((GObject)DataComponent.BuildShip).text;
		tipBubble.EnterIZBefore.selectedIndex = ((Singleton<GvGOuterTechManager>.Instance.IsAvailable && Data.EnterIZBefore) ? 1 : 0);
		if (!Data.IsShipReady)
		{
			if (Data.GvGMode3Record.Ships.Count == 0)
			{
				tipBubble.ShipState.selectedIndex = 0;
			}
			else
			{
				GvGMode3ShipModel gvGMode3ShipModel = Data.GvGMode3Record.Ships[0];
				if ((gvGMode3ShipModel.PermanentData.ShipBuildState == 2 || gvGMode3ShipModel.PermanentData.ShipBuildState == 3) && gvGMode3ShipModel.PermanentData.TargetBuildCompleteTime > (int)GameController.Instance.GetServerTime())
				{
					tipBubble.ShipState.selectedIndex = 1;
				}
				else
				{
					tipBubble.ShipState.selectedIndex = 2;
				}
			}
			((GObject)tipBubble.ShipStateText).text = "(0/1)";
		}
		else
		{
			tipBubble.ShipState.selectedIndex = 3;
			((GObject)tipBubble.ShipStateText).text = "(1/1)";
		}
		UpdateTiBubbleBuildingState();
		tipBubble.TechState.selectedIndex = (Data.IsTechReady ? 1 : 0);
		((GObject)tipBubble.TechStateText).text = (Data.IsTechReady ? "(1/1)" : "(0/1)");
		UpdateSpeedPlanStatus();
	}

	private void UpdateTiBubbleBuildingState()
	{
		UI_com_TipBubble tipBubble = SignedRoomInfo.TipBubble;
		((GObject)tipBubble.SkyPortalStateText).text = ((Data.SkyPortalState == eUIBuildingMissionState.Built) ? "(1/1)" : "(0/1)");
		tipBubble.SkyPortalState.selectedIndex = (int)Data.SkyPortalState;
		((GObject)tipBubble.NewWorkshopStateText).text = ((Data.NewWorkShopState == eUIBuildingMissionState.Built) ? "(1/1)" : "(0/1)");
		tipBubble.NewWorkshopState.selectedIndex = (int)Data.NewWorkShopState;
	}

	private void UpdateMessageList()
	{
	}

	private void UpdateSignInInfo()
	{
		if (Data.IsSigned)
		{
			UI_com_SignInInfo signInInfo = SignInInfo;
			GvGProcessInfo signedInRoom = Data.SignedInRoom;
			GvGMode3IslandManagerInfo gvGMode3IslandManagerInfo = (GvGMode3IslandManagerInfo)signedInRoom.GetInfo();
			((GObject)signInInfo.RoomName).text = gvGMode3IslandManagerInfo.IZInfo.ShowName;
			((GObject)signInInfo.StartTime).text = UiHelper.ParseFullTime(gvGMode3IslandManagerInfo.IZInfo.Start);
			((GObject)signInInfo.CampName).text = gvGMode3IslandManagerInfo.GetCampName(Data.SignedCampId) ?? "";
			signInInfo.Camp.selectedIndex = Data.SignedCampId;
		}
	}

	private void SetQuickStartBtnState()
	{
		int selectedIndex = 0;
		if (SignInPeriodState.selectedIndex == 2)
		{
			selectedIndex = 2;
		}
		else if (SignInPeriodState.selectedIndex == 3)
		{
			int curIZId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId;
			selectedIndex = GameLocalDataManager.GetInt(string.Format("{0}_{1}", "QUICK_START", curIZId));
		}
		QuickStart.State.SetSelectedIndex(selectedIndex);
	}

	private void OnQuickStartClick()
	{
		if (QuickStart.State.selectedIndex == 2)
		{
			"QUICK_START_NO_ENTER_IZ".ToShowLanguageTip();
			return;
		}
		int curIZId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId;
		int num = GameLocalDataManager.GetInt(string.Format("{0}_{1}", "QUICK_START", curIZId));
		int num2 = GameLocalDataManager.GetInt(string.Format("{0}_{1}", "QUICK_START_NO_REMIND", curIZId));
		int num3 = ((num != 1) ? 1 : 0);
		if (num2 == 1 || num3 == 0)
		{
			GameLocalDataManager.SetInt(string.Format("{0}_{1}", "QUICK_START", curIZId), num3);
			QuickStart.State.SetSelectedIndex(num3);
		}
		else
		{
			QuickStartConfirmPanel.Init(noRemind: false, delegate
			{
				QuickStart.State.SetSelectedIndex(1);
			});
		}
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
		UnityUiService.Instance.OnGvGClose();
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
		ShipEntryBtn.OnDestroy();
		OuterTechEntryBtn.OnDestroy();
		SignedRoomInfo.OnDestroy();
		ProfileDisplay.OnDestroy();
		if (SpecialRewardsExhibitAnimCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(SpecialRewardsExhibitAnimCoroutine);
		}
		if (CheckNoticeCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(CheckNoticeCoroutine);
		}
		StopAutoUpdateSignedRoomState();
		foreach (IGvGExpeditionPopup subPanel in SubPanels)
		{
			subPanel.OnInactivate();
		}
		if (Data != null)
		{
			Data.Release();
		}
	}

	private void StopAutoUpdateSignedRoomState()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		if (Timers.inst.Exists(new TimerCallback(UpdateSignedRoomStatePerSercond)))
		{
			Timers.inst.Remove(new TimerCallback(UpdateSignedRoomStatePerSercond));
		}
	}

	public void Destroy()
	{
	}

	private void UpdateSpeedPlanStatus()
	{
		OuterTechEntryBtn.AccStatus.selectedIndex = (Singleton<GvGOuterTechManager>.Instance.IsSpeedPlanAvailable ? 1 : 0);
		if (!Singleton<GvGOuterTechManager>.Instance.IsSpeedPlanAvailable || (Singleton<GvGOuterTechManager>.Instance.SpeedPlan.ClaimedCount <= 0 && Singleton<GvGOuterTechManager>.Instance.SpeedPlan.CouldClaimCount <= 0))
		{
			SignedRoomInfo.TipBubble.SpeedPlanEnabled.selectedIndex = 0;
			return;
		}
		SignedRoomInfo.TipBubble.SpeedPlanEnabled.selectedIndex = 1;
		if (Singleton<GvGOuterTechManager>.Instance.SpeedPlan.Claimed)
		{
			SignedRoomInfo.TipBubble.SpeedPlanClaimed.selectedIndex = 1;
			((GObject)SignedRoomInfo.TipBubble.SpeedPlanClaimCnt).text = "(1/1)";
		}
		else
		{
			SignedRoomInfo.TipBubble.SpeedPlanClaimed.selectedIndex = 0;
			((GObject)SignedRoomInfo.TipBubble.SpeedPlanClaimCnt).text = "(0/1)";
		}
	}
}
