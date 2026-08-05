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
using GameMaths;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.MainCity;
using HotFix.Sources.Base.Scripts.UI;
using HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi;
using HotFix.Sources.Base.Scripts.Utils;
using HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Models;
using HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.RPC.Api;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Spine.Unity;
using UI.AccountInfo;
using UI.AddCredit;
using UI.BlackMarketer;
using UI.Collection;
using UI.Contract;
using UI.Dungeons;
using UI.GameActivity;
using UI.GiftBag;
using UI.GvGExpeditionHall;
using UI.GvGMode3Collecting;
using UI.LegendItems;
using UI.Legion;
using UI.Mail;
using UI.MilitaryIntelligence;
using UI.MonthCard;
using UI.PrinceOfTheDevils;
using UI.ProgressionMission;
using UI.PublicResources;
using UI.RecyclingCenter;
using UI.SpecialActivity;
using UI.Technology;
using UI.Tips;
using UI.UpGrade;
using UI.Warehouse;
using UI.WorkShop;
using UI.WorldMap;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace UI.MainCity;

public class UI_MainCity : GComponent, IUiController, IAnyLoadingPanelStatusListener, IAnyOfflineBonusesListener
{
	public enum MailIconType
	{
		Empty,
		Mail,
		Chat
	}

	public GGraph rayMask;

	public GImage n121;

	public GImage n122;

	public GLoader bottomBack;

	public UI_MainBattleBtn MainBattleBtn;

	public GComponent addWorkerBtn;

	public UI_ActivityBtn AcitivityBtn;

	public UI_HeadPortrait headPortraitBtn;

	public UI_LegendItemBtn LegendItems;

	public UI_DailyBtn DailyBtn;

	public UI_LotteryBtn LotteryBtn;

	public UI_LegionsBtn LegionsBtn;

	public UI_HelpBtn DungeonsBtn;

	public GLoader ChatBtn;

	public GGraph n107;

	public GList ChatContentList;

	public GGroup messageGroup;

	public GComponent addDiamondBtn;

	public GComponent addCouponBtn;

	public GButton TurnPageLeftBtn;

	public GButton TurnPageRightBtn;

	public UI_PushGiftBtn PushGiftBtn;

	public UI_mailbox_t MailBox_T;

	public UI_ForumEntryBtn ForumEntryBtn;

	public UI_RechargeActivityBtn RechargeActivityBtn;

	public UI_RechargeActivityBtn02 ShadowDemonBtn;

	public UI_btn_ReturningRewards ReturningRewards;

	public UI_ProgressionMissionBtn n126;

	public UI_ChallengeMissionBtn n127;

	public GLoader QQVip;

	public GLoader QQGiftBtn;

	public GLoader QQBigPlayerBtn;

	public Transition ButtleBtnAnim;

	public const string URL = "ui://j611zmym6wel1l";

	public static string Name = "UI_MainCity";

	private const float _bigmapRatio = 80f;

	private Vector3 _cameraTempPos;

	private float _previousPosX;

	private float _previousPosY;

	private float _offsetX;

	private float _offsetZ;

	private float _lastPosX;

	private float _lastPosY;

	public float _cameraRangeX;

	public float _cameraRangeZ;

	private bool _isZoom;

	private GameStateEntity _gameStateEntity;

	private Coroutine _spinWeekCountDown;

	private Coroutine _shadowDemonCountDown;

	public MailIconType MailIconStatus;

	private int timerid_JudgeShowNote = 0;

	public bool MoneyNumInit;

	public string userName;

	private List<string> textureList = new List<string>();

	public UI_ProductionNumFloating NumFloatingMoney;

	public UI_ProductionNumFloating NumFloatingGem;

	private Dictionary<string, GButton> entranceList = new Dictionary<string, GButton>();

	public SkeletonAnimation MailSpineAnimation;

	public SkeletonAnimation ForumEntrySpineAnimation;

	private Coroutine _progressionCountDown;

	private Coroutine _challengeCountDown;

	private bool _isFirstInitProgression;

	private bool _isFirstInitChallenge;

	private bool _progressionTempNote;

	private bool _challengeTempNote;

	private int _currentDay;

	private HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi.ActivityEntranceController _activityEntranceController => GameManagers.Instance.ActivityManager.EntranceController;

	private ActivityEntranceRedDotController _activityEntranceRedDotController => GameManagers.Instance.ActivityManager.RedDotController;

	public static string GetURL()
	{
		return "ui://j611zmym6wel1l";
	}

	public static UI_MainCity CreateInstance()
	{
		return (UI_MainCity)(object)UIPackage.CreateObject("MainCity", "MainCity");
	}

	public static UI_MainCity CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MainCity).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmym6wel1l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Expected O, but got Unknown
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		rayMask = (GGraph)((GComponent)this).GetChild("rayMask");
		n121 = (GImage)((GComponent)this).GetChild("n121");
		n122 = (GImage)((GComponent)this).GetChild("n122");
		bottomBack = (GLoader)((GComponent)this).GetChild("bottomBack");
		MainBattleBtn = (UI_MainBattleBtn)(object)((GComponent)this).GetChild("MainBattleBtn");
		addWorkerBtn = (GComponent)((GComponent)this).GetChild("addWorkerBtn");
		AcitivityBtn = (UI_ActivityBtn)(object)((GComponent)this).GetChild("AcitivityBtn");
		headPortraitBtn = (UI_HeadPortrait)(object)((GComponent)this).GetChild("headPortraitBtn");
		LegendItems = (UI_LegendItemBtn)(object)((GComponent)this).GetChild("LegendItems");
		DailyBtn = (UI_DailyBtn)(object)((GComponent)this).GetChild("DailyBtn");
		LotteryBtn = (UI_LotteryBtn)(object)((GComponent)this).GetChild("LotteryBtn");
		LegionsBtn = (UI_LegionsBtn)(object)((GComponent)this).GetChild("LegionsBtn");
		DungeonsBtn = (UI_HelpBtn)(object)((GComponent)this).GetChild("DungeonsBtn");
		ChatBtn = (GLoader)((GComponent)this).GetChild("ChatBtn");
		n107 = (GGraph)((GComponent)this).GetChild("n107");
		ChatContentList = (GList)((GComponent)this).GetChild("ChatContentList");
		messageGroup = (GGroup)((GComponent)this).GetChild("messageGroup");
		addDiamondBtn = (GComponent)((GComponent)this).GetChild("addDiamondBtn");
		addCouponBtn = (GComponent)((GComponent)this).GetChild("addCouponBtn");
		TurnPageLeftBtn = (GButton)((GComponent)this).GetChild("TurnPageLeftBtn");
		TurnPageRightBtn = (GButton)((GComponent)this).GetChild("TurnPageRightBtn");
		PushGiftBtn = (UI_PushGiftBtn)(object)((GComponent)this).GetChild("PushGiftBtn");
		MailBox_T = (UI_mailbox_t)(object)((GComponent)this).GetChild("MailBox_T");
		ForumEntryBtn = (UI_ForumEntryBtn)(object)((GComponent)this).GetChild("ForumEntryBtn");
		RechargeActivityBtn = (UI_RechargeActivityBtn)(object)((GComponent)this).GetChild("RechargeActivityBtn");
		ShadowDemonBtn = (UI_RechargeActivityBtn02)(object)((GComponent)this).GetChild("ShadowDemonBtn");
		ReturningRewards = (UI_btn_ReturningRewards)(object)((GComponent)this).GetChild("ReturningRewards");
		n126 = (UI_ProgressionMissionBtn)(object)((GComponent)this).GetChild("n126");
		n127 = (UI_ChallengeMissionBtn)(object)((GComponent)this).GetChild("n127");
		QQVip = (GLoader)((GComponent)this).GetChild("QQVip");
		QQGiftBtn = (GLoader)((GComponent)this).GetChild("QQGiftBtn");
		QQBigPlayerBtn = (GLoader)((GComponent)this).GetChild("QQBigPlayerBtn");
		ButtleBtnAnim = ((GComponent)this).GetTransition("ButtleBtnAnim");
	}

	public void OnBigMapDrag(EventContext context)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		if (!FGUIManager.Instance.LimitCameraInMainCity() && !_isZoom)
		{
			_cameraTempPos = Vector3.op_Implicit(GameController.Contexts.Service<ICameraService>().Position);
			_previousPosX = context.inputEvent.position.x;
			_previousPosY = context.inputEvent.position.y;
			_offsetX = (0f - (_previousPosX - _lastPosX)) / 80f;
			_offsetZ = (0f - (_previousPosY - _lastPosY)) / 80f;
			CameraMove(_cameraTempPos.x + _offsetX, _cameraTempPos.z - _offsetZ);
			_lastPosX = _previousPosX;
			_lastPosY = _previousPosY;
		}
	}

	public void OnBigMapDragBegin(EventContext context)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if (!FGUIManager.Instance.LimitCameraInMainCity())
		{
			_lastPosX = context.inputEvent.position.x;
			_lastPosY = context.inputEvent.position.y;
			context.CaptureTouch();
		}
	}

	public void OnBigMapDragEnd(EventContext context)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if (!FGUIManager.Instance.LimitCameraInMainCity())
		{
			_lastPosX = context.inputEvent.position.x;
			_lastPosY = context.inputEvent.position.y;
			context.CaptureTouch();
		}
	}

	public void MainCityMapInit()
	{
		CameraMoveRange();
	}

	public void CameraMoveRange()
	{
		_cameraRangeX = FGUIManager.Instance.difference;
	}

	public void CameraMove(float posX, float posZ)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		Vector3 position = GameController.Contexts.Service<ICameraService>().Position;
		if (posX < _cameraRangeX && posX > 0f - _cameraRangeX)
		{
			Vector3 val = default(Vector3);
			((Vector3)(ref val))._002Ector(posX, position.y, position.z);
			GameController.Contexts.Service<ICameraService>().SetPosition(Vector3.op_Implicit(Vector3.Slerp(Vector3.op_Implicit(position), val, 1f)));
		}
		FGUIManager.Instance.ChangeMaincityTurnBtnStatus();
		FGUIManager.Instance.BuildingIndicatorStatusUpdate();
	}

	public void RegisterUiEventListeners()
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected O, but got Unknown
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Expected O, but got Unknown
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Expected O, but got Unknown
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Expected O, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected O, but got Unknown
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Expected O, but got Unknown
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Expected O, but got Unknown
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Expected O, but got Unknown
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Expected O, but got Unknown
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Expected O, but got Unknown
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Expected O, but got Unknown
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Expected O, but got Unknown
		_gameStateEntity = ((Context<GameStateEntity>)GameController.Contexts.gameState).CreateEntity();
		_gameStateEntity.AddAnyLoadingPanelStatusListener(this);
		_gameStateEntity.AddAnyOfflineBonusesListener(this);
		FGUIManager.Instance.MaincityUi = this;
		((GObject)TurnPageRightBtn).data = 1;
		((GObject)TurnPageLeftBtn).data = -1;
		((GObject)TurnPageLeftBtn).onClick.Add(new EventCallback1(ArriveMaincityBorder));
		((GObject)TurnPageRightBtn).onClick.Add(new EventCallback1(ArriveMaincityBorder));
		((GObject)AcitivityBtn.Content).onClick.Add(new EventCallback0(ActivityBtnEvent));
		((GObject)DungeonsBtn.Content).onClick.Add(new EventCallback1(DungeonsBtnEvent));
		((GObject)LegionsBtn.Content).onClick.Add(new EventCallback1(LegionsBtnEvent));
		((GObject)DailyBtn.Content).onClick.Add(new EventCallback1(DailyBtnEvent));
		((GObject)LotteryBtn.Content).onClick.Add(new EventCallback1(LotteryBtnEvent));
		((GObject)ChatBtn).onClick.Add(new EventCallback0(ChatBtnEvent));
		((GObject)MainBattleBtn).onClick.Add(new EventCallback0(MainBattleBtnEvent));
		((GObject)addWorkerBtn).onClick.Add(new EventCallback0(OpenWorkerOverview));
		addWorkerBtn.GetChild("addButton").onClick.Add(new EventCallback1(WorkerBtnEvent));
		addWorkerBtn.GetChild("ExclamationMarkBtn").onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		addDiamondBtn.GetChild("addButton").onClick.Add(new EventCallback0(DiamondBtnEvent));
		addCouponBtn.GetChild("addButton").onClick.Add(new EventCallback0(MoneyBtnEvent));
		((GObject)MailBox_T.Content).onClick.Add(new EventCallback0(MailBoxBtnEvent));
		((GObject)ForumEntryBtn).onClick.Add(new EventCallback0(ForumEntryBtnEvent));
		((GObject)RechargeActivityBtn).onClick.Add(new EventCallback0(OnClickRechargeActivity));
		((GObject)ShadowDemonBtn).onClick.Set(new EventCallback0(OnClickShadowDemonBtn));
		((GObject)rayMask).onClick.Add(new EventCallback1(OpenRoom));
		((GObject)rayMask).onTouchBegin.Add(new EventCallback1(OnBigMapDragBegin));
		((GObject)rayMask).onTouchEnd.Add(new EventCallback1(OnBigMapDragEnd));
		((GObject)rayMask).onTouchMove.Add(new EventCallback1(OnBigMapDrag));
		((GObject)headPortraitBtn.supremeIconBtn).onClick.Add(new EventCallback0(OpenMonthCardUi));
		((GObject)headPortraitBtn.bullyIconBtn).onClick.Add(new EventCallback0(OpenMonthCardUi));
		((GObject)headPortraitBtn.AccountInfoBack).onClick.Add(new EventCallback0(OpenAccountInfoPanel));
		((GObject)headPortraitBtn.articleExperience).onClick.Add(new EventCallback0(ScreenShot));
		((GObject)LegendItems.Content).onClick.Add(new EventCallback0(OpenLegendItems));
		PushGiftBtn.RegisterUiEventListeners();
		ReturningRewards.Register();
		SharedMessenger.AddListener<Building>("WORKERS_ALLOCATION_DISPLAY_CHANGED", OnProductionConfigChanged);
		SharedMessenger.AddListener("CAMERA_TO_MAIN_CITY_LEFT", CameraToMainCityLeft);
		SharedMessenger.AddListener("CAMERA_TO_MAIN_CITY_RIGHT", CameraToMainCityRight);
		SharedMessenger.AddListener<int>("USER_GAIN_EXP", InitHeadPortraitValue);
		SharedMessenger.AddListener<int>("USER_LEVEL_UP", InitHeadPortraitValue);
		SharedMessenger.AddListener<string>("CLOSE_UI", CheckIsMainCityTop);
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<string>("MAIN_CITY_COM_UNLOCKED", ChangeMainCityBtnStatus);
		SharedMessenger.AddListener<Mission>("MISSION_COMPLETE", UpdateActivityShowNote);
		SharedMessenger.AddListener<string>("LEASEHOLD_UNREGISTERD", SetMonthCardIcon);
		SharedMessenger.AddListener<string, DateTimeOffset>("LEASEHOLD_REGISTERD", UpdateMonthCardIcon);
		SharedMessenger.AddListener<List<string>>("REGION_PROD_AUTO_CLAIMED", RefreshMoneyNum);
		SharedMessenger.AddListener("REFRESH_USERNAME", RefreshUserName);
		SharedMessenger.AddListener<Cache_OrcActivityRedDot>(Cache_OrcActivityRedDot.ON_REDDOT_CHANGE, OnChangeOrcActivityRedDot);
		SharedMessenger.AddListener<Cache_NoviceRechargeRedDot>("Cache_NoviceRechargeRedDot", OnNoviceRechargeRedDot);
		SharedMessenger.AddListener<Cache_NoviceRechargeRedDot>("Cache_NoviceRechargeRedDotSET", OnNoviceRechargeRedDotSet);
		SharedMessenger.AddListener<Cache_BlackMarketTreasureRedDot>(Cache_BlackMarketTreasureRedDot.ON_REDDOT_CHANGE, OnBlackMarketTreasureRedDot);
		SharedMessenger.AddListener<Cache_DeparturePresentRedDot>("ON_DEPARTURE_PRESENT_RED_DOT_CHANGE", OnDeparturePresentRedDotChange);
		SharedMessenger.AddListener<Cache_CertificationRedDot>("ON_CERTIFICATION_RED_DOT_CHANGE", OnCertificationRedDotChange);
		SharedMessenger.AddListener("OPEN_PVP_PANEL", OnOpenPvP);
		SharedMessenger.AddListener("OPEN_WORKER_OVERVIEW_PANEL", OpenWorkerOverview);
		GameManagers.Instance.Messenger.AddListener<FriendsChatSession>("FRIENDS_CHAT_SESSION_UPDATE", OnFriendsChatUpdate);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected O, but got Unknown
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected O, but got Unknown
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected O, but got Unknown
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected O, but got Unknown
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Expected O, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected O, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Expected O, but got Unknown
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Expected O, but got Unknown
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected O, but got Unknown
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Expected O, but got Unknown
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Expected O, but got Unknown
		_gameStateEntity.RemoveAnyLoadingPanelStatusListener(this);
		_gameStateEntity.RemoveAnyOfflineBonusesListener(this);
		((Entity)_gameStateEntity).Destroy();
		FGUIManager.Instance.MaincityUi = null;
		((GObject)TurnPageLeftBtn).onClick.Remove(new EventCallback1(ArriveMaincityBorder));
		((GObject)TurnPageRightBtn).onClick.Remove(new EventCallback1(ArriveMaincityBorder));
		((GObject)AcitivityBtn.Content).onClick.Remove(new EventCallback0(ActivityBtnEvent));
		((GObject)DungeonsBtn.Content).onClick.Remove(new EventCallback1(DungeonsBtnEvent));
		((GObject)LegionsBtn.Content).onClick.Remove(new EventCallback1(LegionsBtnEvent));
		((GObject)DailyBtn.Content).onClick.Remove(new EventCallback1(DailyBtnEvent));
		((GObject)LotteryBtn.Content).onClick.Remove(new EventCallback1(LotteryBtnEvent));
		((GObject)ChatBtn).onClick.Remove(new EventCallback0(ChatBtnEvent));
		((GObject)addWorkerBtn).onClick.Remove(new EventCallback0(OpenWorkerOverview));
		addWorkerBtn.GetChild("addButton").onClick.Remove(new EventCallback1(WorkerBtnEvent));
		addWorkerBtn.GetChild("ExclamationMarkBtn").onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		addDiamondBtn.GetChild("addButton").onClick.Remove(new EventCallback0(DiamondBtnEvent));
		addCouponBtn.GetChild("addButton").onClick.Remove(new EventCallback0(MoneyBtnEvent));
		((GObject)MailBox_T.Content).onClick.Remove(new EventCallback0(MailBoxBtnEvent));
		((GObject)ForumEntryBtn).onClick.Remove(new EventCallback0(ForumEntryBtnEvent));
		((GObject)RechargeActivityBtn).onClick.Remove(new EventCallback0(OnClickRechargeActivity));
		((GObject)ShadowDemonBtn).onClick.Clear();
		((GObject)rayMask).onClick.Remove(new EventCallback1(OpenRoom));
		((GObject)rayMask).onTouchBegin.Remove(new EventCallback1(OnBigMapDragBegin));
		((GObject)rayMask).onTouchEnd.Remove(new EventCallback1(OnBigMapDragEnd));
		((GObject)rayMask).onTouchMove.Remove(new EventCallback1(OnBigMapDrag));
		((GObject)headPortraitBtn.supremeIconBtn).onClick.Remove(new EventCallback0(OpenMonthCardUi));
		((GObject)headPortraitBtn.bullyIconBtn).onClick.Remove(new EventCallback0(OpenMonthCardUi));
		((GObject)headPortraitBtn.AccountInfoBack).onClick.Remove(new EventCallback0(OpenAccountInfoPanel));
		((GObject)headPortraitBtn.articleExperience).onClick.Remove(new EventCallback0(ScreenShot));
		((GObject)LegendItems.Content).onClick.Remove(new EventCallback0(OpenLegendItems));
		PushGiftBtn.UnregisterUiEventListeners();
		ReturningRewards.Unregister();
		SharedMessenger.RemoveListener<Building>("WORKERS_ALLOCATION_DISPLAY_CHANGED", OnProductionConfigChanged);
		SharedMessenger.RemoveListener("CAMERA_TO_MAIN_CITY_LEFT", CameraToMainCityLeft);
		SharedMessenger.RemoveListener("CAMERA_TO_MAIN_CITY_RIGHT", CameraToMainCityRight);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", CheckIsMainCityTop);
		SharedMessenger.RemoveListener<int>("USER_GAIN_EXP", InitHeadPortraitValue);
		SharedMessenger.RemoveListener<int>("USER_LEVEL_UP", InitHeadPortraitValue);
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<string>("MAIN_CITY_COM_UNLOCKED", ChangeMainCityBtnStatus);
		SharedMessenger.RemoveListener<Mission>("MISSION_COMPLETE", UpdateActivityShowNote);
		SharedMessenger.RemoveListener<string>("LEASEHOLD_UNREGISTERD", SetMonthCardIcon);
		SharedMessenger.RemoveListener<string, DateTimeOffset>("LEASEHOLD_REGISTERD", UpdateMonthCardIcon);
		SharedMessenger.RemoveListener<List<string>>("REGION_PROD_AUTO_CLAIMED", RefreshMoneyNum);
		SharedMessenger.RemoveListener("REFRESH_USERNAME", RefreshUserName);
		SharedMessenger.RemoveListener<Cache_OrcActivityRedDot>(Cache_OrcActivityRedDot.ON_REDDOT_CHANGE, OnChangeOrcActivityRedDot);
		SharedMessenger.RemoveListener<Cache_NoviceRechargeRedDot>("Cache_NoviceRechargeRedDot", OnNoviceRechargeRedDot);
		SharedMessenger.RemoveListener<Cache_NoviceRechargeRedDot>("Cache_NoviceRechargeRedDotSET", OnNoviceRechargeRedDotSet);
		SharedMessenger.RemoveListener<Cache_BlackMarketTreasureRedDot>(Cache_BlackMarketTreasureRedDot.ON_REDDOT_CHANGE, OnBlackMarketTreasureRedDot);
		SharedMessenger.RemoveListener<Cache_DeparturePresentRedDot>("ON_DEPARTURE_PRESENT_RED_DOT_CHANGE", OnDeparturePresentRedDotChange);
		SharedMessenger.RemoveListener<Cache_CertificationRedDot>("ON_CERTIFICATION_RED_DOT_CHANGE", OnCertificationRedDotChange);
		SharedMessenger.RemoveListener("OPEN_PVP_PANEL", OnOpenPvP);
		SharedMessenger.RemoveListener("OPEN_WORKER_OVERVIEW_PANEL", OpenWorkerOverview);
		GameManagers.Instance.Messenger.RemoveListener<FriendsChatSession>("FRIENDS_CHAT_SESSION_UPDATE", OnFriendsChatUpdate);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		Singleton<CameraService>.Instance.SwitchToScene("MainCity.Right");
		((GObject)ForumEntryBtn).visible = false;
		userName = GameController.Contexts.gameState.user.value.Nickname;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		((GObject)((GComponent)((GComponent)ChatContentList).GetChildAt(0).asButton).GetChild("ChatContent").asTextField).text = FGUIManager.Instance.messageTemp;
		((GObject)((GComponent)((GComponent)ChatContentList).GetChildAt(0).asButton).GetChild("sender").asTextField).text = FGUIManager.Instance.senderTemp;
		((GComponent)headPortraitBtn).GetChild("title").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
		((GComponent)headPortraitBtn).GetChild("level").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
		GemAndMoneyBtnInit();
		InitInitHeadPortraitBtnInfo();
		InitHeadPortraitValue();
		MainCityMapInit();
		SetAcitivityBtnSfx();
		InitActivityEntrance();
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("MainCity.ChatContentList", ChatContentList);
		instance.Register("MainCity.LegionBtn", LegionsBtn.Content);
		instance.Register("MainCity.GoToBattleBtn", MainBattleBtn);
		instance.Register("MainCity.LotteryBtn", LotteryBtn.Content);
		instance.Register("MainCity.DungeonBtn", DungeonsBtn.Content);
		instance.Register("MainCity.TechnologyBtn", DailyBtn.Content);
		instance.Register("MainCity.ActivitiesBtn", AcitivityBtn.Content);
		instance.Register("MainCity.MailBoxBtn", MailBox_T.Content);
		instance.Register("MainCity.LegendItems", LegendItems.Content);
		entranceList.Add("MainCity.LegionBtn", (GButton)(object)LegionsBtn);
		entranceList.Add("MainCity.LotteryBtn", (GButton)(object)LotteryBtn);
		entranceList.Add("MainCity.DungeonBtn", (GButton)(object)DungeonsBtn);
		entranceList.Add("MainCity.TechnologyBtn", (GButton)(object)DailyBtn);
		entranceList.Add("MainCity.ActivitiesBtn", (GButton)(object)AcitivityBtn);
		entranceList.Add("MainCity.MailBoxBtn", (GButton)(object)MailBox_T);
		entranceList.Add("MainCity.LegendItems", (GButton)(object)LegendItems);
		List<string> unlockedMainCityCom = GameManagers.Instance.UserArchiveManager.GetUnlockedMainCityCom();
		foreach (KeyValuePair<string, GButton> entrance in entranceList)
		{
			if (unlockedMainCityCom.Contains(entrance.Key))
			{
				((GComponent)entrance.Value).GetController("Status").selectedIndex = 1;
				((GComponent)entrance.Value).GetChild("Content").SetScale(1f, 1f);
				((GComponent)entrance.Value).GetChild("note").alpha = 1f;
			}
			else
			{
				((GComponent)entrance.Value).GetController("Status").selectedIndex = 0;
			}
		}
		SetMonthCardIcon(null);
		UpdateMainCityUI(isInit: true);
		PushGiftBtn.Init();
		FGUIManager.Instance.GetBlackMarketData();
		((GObject)this).touchable = FGUIManager.Instance.MainCityUiTouchable;
		FGUIManager.Instance.BuildingsTitleAppear();
		FGUIManager.Instance.BuildingsTitleFadeOut();
		FGUIManager.Instance.ChangeMaincityTurnBtnStatus();
		FGUIManager.Instance.GetBlackMarketPurchaseLimitData();
		FGUIManager.Instance.BuildingIndicatorInit();
		if (FGUIManager.Instance.LimitCameraInMainCity())
		{
			((GObject)TurnPageLeftBtn).alpha = 0f;
			((GObject)TurnPageRightBtn).alpha = 0f;
			((GObject)TurnPageLeftBtn).touchable = false;
			((GObject)TurnPageRightBtn).touchable = false;
		}
		else
		{
			((GObject)TurnPageLeftBtn).alpha = 1f;
			((GObject)TurnPageRightBtn).alpha = 1f;
			((GObject)TurnPageLeftBtn).touchable = true;
			((GObject)TurnPageRightBtn).touchable = true;
		}
		SetForumEntrySpine();
		MailBoxBtnInit();
		SetMailSpine();
		FGUIManager.Instance.UpdateMailBtnNote();
		instance.Register("MainCity.PageLeft", TurnPageLeftBtn);
		instance.Register("MainCity.PageRight", TurnPageRightBtn);
		UiAudioManager.Instance.PlayBackgroundMusic(UiAudioManager.BgmType.MainCity);
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
		((GObject)LegendItems).visible = VersionManager.LegendItemSwitch;
		CheckInvitedWorkers();
		FGUIManager.Instance.activityEntranceController?.ShowSpecialActivityEntrance();
		InitProgressionMission();
		RefreshNewComerSpecialIcon();
		RefreshShadowDemonGiftIcon();
		ReturningRewards.OnShow();
		if (GameController.Configs.TryGetValue("ShowMainCityForumEntry", out var value) && value == "1")
		{
			SetForumEntrySpine();
			((GObject)ForumEntryBtn).visible = true;
		}
	}

	public void SetTurnPageBtnPos(GButton _turnBtn, float xDeviation, Action action)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = Vector2.op_Implicit(GameController.Contexts.Service<ICameraService>().WorldToScreenPoint(Vector3.zero));
		val.y = (float)Screen.height - val.y;
		Vector2 val2 = ((GObject)this).GlobalToLocal(Vector2.op_Implicit(val));
		((GObject)_turnBtn).x = val2.x + xDeviation;
		action?.Invoke();
	}

	private void CheckInvitedWorkers()
	{
		string text = "";
		foreach (InvitedWorker value in GameManagers.Instance.FriendsManager.InvitedWorkers.Values)
		{
			if (value.Status == InvitedWorkerActivateStatus.New)
			{
				value.Status = InvitedWorkerActivateStatus.UnChecked;
				string text2 = ((text.Length <= 0) ? LanguagesManager.GetDesc("CsharpCodeZhTcText357") : "");
				text = text + text2 + value.Nickname + "、";
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			if (text[text.Length - 1] == '、')
			{
				int length = text.Length - 1;
				text = text.Substring(0, length);
			}
			text = text + LanguagesManager.GetDesc("CsharpCodeZhTcText361") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText362");
			FGUIManager.Instance.ShowDialogTip(text, 9999);
		}
		string text3 = "";
		Dictionary<int, InvitedWorker> newExpiredInvitedWorkers = GameManagers.Instance.FriendsManager.NewExpiredInvitedWorkers;
		int[] array = newExpiredInvitedWorkers.Keys.ToArray();
		foreach (int key in array)
		{
			InvitedWorker invitedWorker = newExpiredInvitedWorkers[key];
			string text4 = ((text3.Length <= 0) ? LanguagesManager.GetDesc("CsharpCodeZhTcText357") : "");
			text3 = text3 + text4 + invitedWorker.Nickname + "、";
			newExpiredInvitedWorkers.Remove(key);
		}
		if (!string.IsNullOrEmpty(text3))
		{
			if (text3[text3.Length - 1] == '、')
			{
				int length2 = text3.Length - 1;
				text3 = text3.Substring(0, length2);
			}
			text3 += LanguagesManager.GetDesc("CsharpCodeZhTcText358");
			FGUIManager.Instance.ShowDialogTip(text3, 9999);
		}
	}

	public void BeforeDestroy()
	{
		ReturningRewards.BeforeDestroy();
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("MainCity.ChatContentList", ChatContentList);
		instance.Unregister("MainCity.LegionBtn", LegionsBtn.Content);
		instance.Unregister("MainCity.GoToBattleBtn", MainBattleBtn);
		instance.Unregister("MainCity.LotteryBtn", LotteryBtn.Content);
		instance.Unregister("MainCity.DungeonBtn", DungeonsBtn.Content);
		instance.Unregister("MainCity.PageLeft", TurnPageLeftBtn);
		instance.Unregister("MainCity.PageRight", TurnPageRightBtn);
		instance.Unregister("MainCity.TechnologyBtn", DailyBtn.Content);
		instance.Unregister("MainCity.ActivitiesBtn", AcitivityBtn.Content);
		instance.Unregister("MainCity.MailBoxBtn", MailBox_T.Content);
		instance.Unregister("MainCity.LegendItems", LegendItems.Content);
		entranceList.Clear();
		UiAudioManager.Instance.StopBackgroundMusic();
	}

	private void OpenLegendItems()
	{
		if (VersionManager.LegendItemSwitch && FGUIManager.Instance.JudgeFreeWorkerNum(needTip: true))
		{
			UI_LegendItemsPanel.OpenPanelInfo = new LegendItemsPanelInfo(LegendItemsShowType.Show, -1L);
			LegendItemsHelper.OpenLegendItemBlueprintListPanel(Action);
		}
		static void Action()
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemsPanel.Name, parameters);
		}
	}

	public void CheckIsMainCityTop(string str)
	{
		if (UnityUiService.Instance.CheckIsMainCityShowed())
		{
			UpdateMainCityUI(isInit: false, str);
			UnityUiService.Instance.SetEdgeMaskVisible(UnityUiService.Instance.edgeMaskPanel.ratio <= 1f);
		}
	}

	public void UpdateMainCityUI(bool isInit, string fromContext = null)
	{
		if (!(GameController.Contexts.Service<BaseSceneService>().CurrentScene == "BattleField"))
		{
			GameManagers.Instance?.PullData();
			UpdateManPower();
			UpdateGemstone();
			UpdateMoney();
			JudgeShowNote();
			JudgeRechargeActivityShortCut(!isInit);
			RefreshShadowDemonGiftIcon();
			FGUIManager.Instance.UpdateBuildingNote();
			FGUIManager.Instance.BuildingsTitleFadeOut();
			if (!string.IsNullOrEmpty(fromContext))
			{
				FGUIManager.Instance.activityEntranceController?.UpdateNotise();
			}
		}
	}

	private void MailBoxBtnInit()
	{
		if (GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1001").Contains("P120"))
		{
			MailBox_T.Status.selectedIndex = 1;
			((GObject)MailBox_T.Content).SetScale(1f, 1f);
			((GObject)MailBox_T.note).alpha = 1f;
		}
	}

	private void ChangeMainCityBtnStatus(string btnName)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		if (entranceList.ContainsKey(btnName))
		{
			((GComponent)entranceList[btnName]).GetController("Status").selectedIndex = 1;
			FGUIManager.Instance.AddTextSpecialEffects(((GComponent)entranceList[btnName]).GetChild("SfxBack").asGraph, "workplaceSmoke_2", new Vector3(2.5f, 2.5f, 2.5f), "Default", 0.5f, delegate(GameObject workplaceSmoke2)
			{
				workplaceSmoke2.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
				UiAudioManager.Instance.LoadSoundsForSfx(workplaceSmoke2, "BalloonBlast");
			});
			((GComponent)(object)this).SetTimeout(0.33f).OnComplete((GTweenCallback)delegate
			{
				JudgeShowNote();
			});
		}
	}

	private string GetIMEI()
	{
		return "";
	}

	private void ScreenShot()
	{
	}

	private bool GetPvpEntranceVisible()
	{
		if (GameController.Configs.TryGetValue("PvpEntrance", out var value))
		{
			return value == "1";
		}
		return false;
	}

	public void OpenAccountInfoPanel()
	{
		UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_AccountInfoPanel.Name, null);
	}

	public void UpdateMoneyAndGemNum(List<Bonus> bonusList)
	{
		for (int i = 0; i < bonusList.Count; i++)
		{
			if (bonusList[i].ItemId == "Money")
			{
				UpdateMoney();
			}
			else if (bonusList[i].ItemId == "Gem")
			{
				UpdateGemstone();
			}
		}
	}

	private void UpdateMonthCardIcon(string itemId, DateTimeOffset dateTime)
	{
		SetMonthCardIcon(itemId);
	}

	private void OpenWorkerOverview()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Order", ((GObject)this).sortingOrder);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_WorkersOverviewPanel.Name, dictionary);
	}

	private void SetForumEntrySpine()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		GameObject val = (GameObject)(object)((obj is GameObject) ? obj : null);
		SkeletonDataAsset skeletonDataAsset = Addressables.LoadAssetAsync<SkeletonDataAsset>((object)"ForumEntry_SkeletonData").WaitForCompletion();
		ForumEntrySpineAnimation = val.GetComponent<SkeletonAnimation>();
		((SkeletonRenderer)ForumEntrySpineAnimation).skeletonDataAsset = skeletonDataAsset;
		((SkeletonRenderer)ForumEntrySpineAnimation).Initialize(true);
		SpineHelper.SetSkin((ISkeletonAnimation)(object)ForumEntrySpineAnimation, "skin1");
		ForumEntrySpineAnimation.AnimationState.AddAnimation(0, "idle", true, 0f);
		val.transform.localScale = new Vector3(105f, 105f, 105f);
		GoWrapper val2 = new GoWrapper(val);
		((DisplayObject)val2).scaleX = 1f;
		ForumEntryBtn.SpineBack.SetNativeObject((DisplayObject)(object)val2);
	}

	private void SetMailSpine()
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		((GObject)MailBox_T.SfxBack).alpha = 0f;
		GameObject MailSpineObject = default(GameObject);
		ref GameObject reference = ref MailSpineObject;
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		SpawnManager.Instance.LoadAnimation("icon_main_mail").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (!((GObject)this).isDisposed)
			{
				UI_MainCity uI_MainCity = this;
				GameObject obj2 = MailSpineObject;
				uI_MainCity.MailSpineAnimation = ((obj2 != null) ? obj2.GetComponent<SkeletonAnimation>() : null);
				if ((Object)(object)MailSpineAnimation != (Object)null && (Object)(object)asset != (Object)null)
				{
					((SkeletonRenderer)MailSpineAnimation).skeletonDataAsset = asset;
					((SkeletonRenderer)MailSpineAnimation).Initialize(true);
					SpineHelper.SetSkin((ISkeletonAnimation)(object)MailSpineAnimation, "skin1");
					MailSpineAnimation.AnimationState.AddAnimation(0, "idle_close", true, 0f);
				}
			}
		});
		if ((Object)(object)MailSpineObject != (Object)null)
		{
			MailSpineObject.transform.localScale = new Vector3(70f, 70f, 70f);
			MailSpineObject.transform.localPosition = -new Vector3(0f, 0f, 0f);
			MailSpineObject.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			GoWrapper val = new GoWrapper(MailSpineObject);
			((DisplayObject)val).SetXY(0f, 0f);
			((DisplayObject)val).pivot = new Vector2(0.5f, 0.5f);
			((DisplayObject)val).scaleX = 1f;
			MailBox_T.Content.SpineBack.SetNativeObject((DisplayObject)(object)val);
			((GObject)MailBox_T.Content.SpineBack).SetXY(100f, 145f);
			((GObject)MailBox_T).SetXY(8f, 960f);
		}
	}

	private void RefreshUserName()
	{
		userName = GameController.Contexts.gameState.user.value.Nickname;
		InitInitHeadPortraitBtnInfo();
	}

	private void OnChangeOrcActivityRedDot(Cache_OrcActivityRedDot cache)
	{
		UpdateActivityShowNote(null);
	}

	private void OnDeparturePresentRedDotChange(Cache_DeparturePresentRedDot cache)
	{
		UpdateActivityShowNote(null);
	}

	private void OnCertificationRedDotChange(Cache_CertificationRedDot cache)
	{
		UpdateActivityShowNote(null);
	}

	private void OnNoviceRechargeRedDot(Cache_NoviceRechargeRedDot cache)
	{
		UpdateActivityShowNote(null);
		JudgeRechargeActivityShortCut(useCache: true);
	}

	private void OnNoviceRechargeRedDotSet(Cache_NoviceRechargeRedDot cache)
	{
		RefreshNewComerSpecialIcon();
		RefreshShadowDemonGiftIcon();
	}

	private void OnBlackMarketTreasureRedDot(Cache_BlackMarketTreasureRedDot cache)
	{
		UpdateActivityShowNote(null);
	}

	private void SetMonthCardIcon(string itemId)
	{
		((GObject)headPortraitBtn.bullyIcon).grayed = GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime("OverlordContract") <= 0;
		((GObject)headPortraitBtn.supremeIcon).grayed = GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime("PrimeContract") <= 0;
	}

	private void OpenMonthCardUi()
	{
		UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
		if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_MonthCardPanel.Name, new Dictionary<string, object> { 
			{
				"Activity",
				FGUIManager.Instance.GetBlackMarketerActivity("UI_MonthCardPanel")
			} });
		}
		else
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder + 1, arg3: false);
		}
	}

	private void SetAcitivityBtnSfx()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.Instance.AddTextSpecialEffects(AcitivityBtn.Content.SfxBack, "rubby_light", new Vector3(90f, 110f, 55f));
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		switch (itemId)
		{
		case "Gem":
			UpdateGemstone();
			addDiamondBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addDiamondBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero);
			break;
		case "ManPower":
			UpdateManPower();
			break;
		case "Money":
			UpdateMoney();
			break;
		}
		WaitTo_JudgeShowNote();
	}

	private void WaitTo_JudgeShowNote()
	{
		if (timerid_JudgeShowNote <= 0)
		{
			timerid_JudgeShowNote = ScriptApi.CreateTimer(0.5f, JudgeShowNote);
			return;
		}
		TimerEntity entityWithId = Contexts.sharedInstance.timer.GetEntityWithId(timerid_JudgeShowNote);
		if (entityWithId != null)
		{
			entityWithId.ReplaceRepeat(1);
			entityWithId.ReplaceDuration(0.5f);
			entityWithId.ReplaceElapsedTime(0f);
			entityWithId.ReplaceCallbackAction(JudgeShowNote);
		}
		else
		{
			timerid_JudgeShowNote = ScriptApi.CreateTimer(0.5f, JudgeShowNote);
		}
	}

	private void GemAndMoneyBtnInit()
	{
		UpdateManPower();
		UpdateGemstone();
		UpdateMoney(isInit: true);
		addDiamondBtn.GetChild("diamond").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Gem");
		addCouponBtn.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Money");
	}

	public void ForumEntryBtnEvent()
	{
		if (UiHelper.LoginTypeStr == UserLoginCredentialsType.Guest.ToString())
		{
			UiHelper.GuestsAccessRestrictTip();
		}
		else
		{
			"CsharpCodeZhTcText424".ToLanguage().ToConfirmPopup(OnConfirm, null, (AlignType)1, 44);
		}
		static void OnConfirm()
		{
			ILRequestHelper<GetBBSKeyResponse>.Request((EventContext)null, (Func<Task<GetBBSKeyResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetBBSKey()), (Action<GetBBSKeyResponse>)delegate(GetBBSKeyResponse response)
			{
				//IL_007b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0081: Invalid comparison between Unknown and I4
				if (response != null)
				{
					if (!response.Result)
					{
						ILRequestHelper.ShowErrorCode(response.ErrorCode);
					}
					else
					{
						string text = $"UserId={response.UserId}&Timestamp={response.Timestamp}&Key={response.BBSKey}&Language={HotUpdateProcess.LanguageKey}";
						string url = response.BBSURL + "/?" + text;
						if ((int)Application.platform == 2)
						{
							UiHelper.OpenUrl(url);
						}
						else
						{
							UiHelper.UniWebViewOpenUrl(url, LanguagesManager.GetDesc("CsharpCodeZhTcText15"));
						}
					}
				}
			});
		}
	}

	public void MailBoxBtnEvent()
	{
		if (FGUIManager.Instance.JudgeFreeWorkerNum(needTip: true))
		{
			int num = ((MailIconStatus == MailIconType.Chat) ? 1 : 0);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_MailPanel.Name, new Dictionary<string, object> { { "DefaultTab", num } });
		}
	}

	public static void DungeonsBtnEvent(EventContext context)
	{
		if (FGUIManager.Instance.JudgeFreeWorkerNum(needTip: true))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_DungeonsPanel.Name, null);
		}
	}

	public void LegionsBtnEvent(EventContext context)
	{
		if (FGUIManager.Instance.JudgeFreeWorkerNum(needTip: true))
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("Style", "Self");
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegionPanel.Name, dictionary);
		}
	}

	public void DailyBtnEvent(EventContext context)
	{
		if (FGUIManager.Instance.JudgeFreeWorkerNum(needTip: true))
		{
			if (GameManagers.Instance.BuildingManager.GetBuildingByType("15").Status == BuildingStatus.Banned)
			{
				List<string> arg = new List<string>
				{
					LanguagesManager.GetDesc("CsharpCodeZhTcText21"),
					LanguagesManager.GetDesc("CsharpCodeZhTcText22")
				};
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			}
			else
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_Technology.Name, null);
			}
		}
	}

	public void LotteryBtnEvent(EventContext context)
	{
		if (FGUIManager.Instance.JudgeFreeWorkerNum(needTip: true))
		{
			if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_ContractPanel.Name, new Dictionary<string, object> { { "Parent", this } });
			}
			else
			{
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			}
		}
	}

	public void ActivityBtnEvent()
	{
		ActivityBtnEventExt();
	}

	private void ActivityBtnEventExt(Dictionary<string, object> additionalParam = null)
	{
		if (!FGUIManager.Instance.JudgeFreeWorkerNum(needTip: true))
		{
			return;
		}
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>
			{
				{
					"TabFilter",
					_activityEntranceController.GetActivityTabFilter(ActivityEntranceMode.NewForeignRewards)
				},
				{
					"TabFilterType",
					ActivityEntranceMode.NewForeignRewards
				}
			};
			if (additionalParam != null)
			{
				foreach (KeyValuePair<string, object> item in additionalParam)
				{
					dictionary.Add(item.Key, item.Value);
				}
			}
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ActivityPanel.Name, dictionary);
			return;
		}
		Dictionary<string, object> dictionary2 = new Dictionary<string, object> { 
		{
			"TabFilterType",
			ActivityEntranceMode.Rewards
		} };
		if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode3() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode4() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode5() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode6() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode7())
		{
			dictionary2.Add("TabFilter", _activityEntranceController.GetActivityTabFilter(ActivityEntranceMode.Rewards));
		}
		else
		{
			dictionary2.Add("TabFilter", _activityEntranceController.GetActivityTabFilter(ActivityEntranceMode.NewGuideModeRewards));
		}
		if (additionalParam != null)
		{
			foreach (KeyValuePair<string, object> item2 in additionalParam)
			{
				dictionary2.Add(item2.Key, item2.Value);
			}
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_ActivityPanel.Name, dictionary2);
	}

	public void ChatBtnEvent()
	{
	}

	public void End()
	{
		ScriptApi.CreateTimer(0.75f, delegate
		{
			for (int i = 0; i < textureList.Count; i++)
			{
				AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
			}
		});
	}

	public void MainBattleBtnEvent()
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected O, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected O, but got Unknown
		if (UiHelper.LoginTypeStr == UserLoginCredentialsType.Guest.ToString() && GameManagers.Instance.ChapterManager.IsChapterDone("C1001"))
		{
			UiHelper.GuestsAccessRestrictTip();
		}
		else
		{
			if (!FGUIManager.Instance.JudgeFreeWorkerNum(needTip: true))
			{
				return;
			}
			((GObject)MainBattleBtn).onClick.Remove(new EventCallback0(MainBattleBtnEvent));
			foreach (KeyValuePair<string, Region> region in WorldMapManager.Regions)
			{
				if (region.Value.Status(GameManagers.Instance) == RegionStatus.Unlocked)
				{
					((GObject)MainBattleBtn).onClick.Add(new EventCallback0(MainBattleBtnEvent));
					Dictionary<string, object> parameters = new Dictionary<string, object>();
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_WorldMapPanel.Name, parameters);
					return;
				}
			}
			bool flag = false;
			string text = "";
			string currentLevelId = GameManagers.Instance.UserArchiveManager.GetCurrentLevelId();
			if (!string.IsNullOrWhiteSpace(currentLevelId))
			{
				Level levelInstance = GameManagers.Instance.ChapterManager.GetLevelInstance(currentLevelId);
				if (levelInstance.ChapterId == "C1000" || levelInstance.ChapterId == "C10000" || levelInstance.ChapterId == "C10001" || levelInstance.ChapterId == "C1000" || levelInstance.ChapterId == "C10002")
				{
					flag = false;
					text = "";
				}
				else
				{
					flag = true;
					text = "";
				}
				End();
				Dictionary<string, object> parameters2 = new Dictionary<string, object>();
				((GObject)MainBattleBtn).onClick.Add(new EventCallback0(MainBattleBtnEvent));
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_WorldMapPanel.Name, parameters2);
				FGUIManager.Instance.IsFirstMakeWar = false;
			}
			else
			{
				((GObject)MainBattleBtn).onClick.Add(new EventCallback0(MainBattleBtnEvent));
				Dictionary<string, object> parameters3 = new Dictionary<string, object>();
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_WorldMapPanel.Name, parameters3);
			}
		}
	}

	private void ArriveMaincityBorder(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		int num = (int)((GObject)(GButton)context.sender).data;
		FGUIManager.Instance.SetMainCityCameraMoveInfo(GameController.Contexts.Service<ICameraService>().Position.x, (float)num * FGUIManager.Instance.difference, 1f);
		ScriptApi.CreateTimer(1f, delegate
		{
			FGUIManager.Instance.BuildingsTitleAppear();
			FGUIManager.Instance.BuildingsTitleFadeOut();
		});
	}

	public void WorkerBtnEvent(EventContext context)
	{
		if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_MonthCardPanel.Name, new Dictionary<string, object>
			{
				{
					"Activity",
					FGUIManager.Instance.GetBlackMarketerActivity("UI_MonthCardPanel")
				},
				{
					"Order",
					((GObject)this).sortingOrder
				},
				{ "Parent", this }
			});
		}
		else
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
		context.StopPropagation();
	}

	private void DiamondBtnEvent()
	{
		if (FGUIManager.Instance.JudgeFreeWorkerNum(needTip: true))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_BlackMarketerAddCredit.Name, new Dictionary<string, object>
			{
				{
					"Activity",
					FGUIManager.Instance.GetBlackMarketerActivity("UI_BlackMarketerAddCredit")
				},
				{
					"Order",
					((GObject)this).sortingOrder
				},
				{ "Parent", this }
			});
		}
	}

	private void MoneyBtnEvent()
	{
		if (FGUIManager.Instance.JudgeFreeWorkerNum(needTip: true))
		{
			if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_GiftBagPanel.Name, new Dictionary<string, object>
				{
					{
						"Activity",
						FGUIManager.Instance.GetBlackMarketerActivity("UI_GiftBagPanel")
					},
					{
						"Order",
						((GObject)this).sortingOrder
					},
					{ "Parent", this }
				});
			}
			else
			{
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			}
		}
	}

	private void OnProductionConfigChanged(Building building)
	{
		UpdateManPower();
	}

	public void BattleBtnClick()
	{
	}

	public void UpdateManPower()
	{
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		Dungeon value = GameController.Contexts.game.dungeon.value;
		addWorkerBtn.GetChild("CurrentWorkerAmount").text = Dungeon.GetFreeManPower(GameManagers.Instance).ToString();
		addWorkerBtn.GetChild("AllWorkerAmount").text = Dungeon.GetTotalManPower(GameManagers.Instance).ToString();
		if (GameManagers.Instance.LeaseholdManager.GetLeaseholdManPower() > 0)
		{
			int num = (int)((((GObject)GRoot.inst).width - 1920f) * 0.5f) + 1920 - 350;
			addWorkerBtn.GetChild("AllWorkerAmount").asTextField.color = Color32.op_Implicit(new Color32((byte)175, (byte)246, (byte)39, byte.MaxValue));
			addWorkerBtn.GetChild("separate").asTextField.color = Color32.op_Implicit(new Color32((byte)175, (byte)246, (byte)39, byte.MaxValue));
			addWorkerBtn.GetChild("ExclamationMarkBtn").data = new Dictionary<string, object>
			{
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText153") + Environment.NewLine + string.Format("{0}：{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText164"), Dungeon.GetTotalManPower(GameManagers.Instance) - GameManagers.Instance.LeaseholdManager.GetLeaseholdManPower())
				},
				{
					"Pos",
					(object)new Vector2((float)num, 88f)
				}
			};
			addWorkerBtn.GetChild("ExclamationMarkBtn").visible = true;
		}
		else
		{
			addWorkerBtn.GetChild("AllWorkerAmount").asTextField.color = Color32.op_Implicit(new Color32((byte)219, (byte)160, (byte)76, byte.MaxValue));
			addWorkerBtn.GetChild("separate").asTextField.color = Color32.op_Implicit(new Color32((byte)219, (byte)160, (byte)76, byte.MaxValue));
			addWorkerBtn.GetChild("ExclamationMarkBtn").visible = false;
		}
	}

	public void UpdateGemstone()
	{
		int stock = GameManagers.Instance.StockController.GetStock("Gem");
		((GObject)addDiamondBtn.GetChild("num").asTextField).text = stock.ToString();
		int num = ((addDiamondBtn.GetChild("num").data != null) ? ((int)addDiamondBtn.GetChild("num").data) : stock);
		if (num != stock && stock > num)
		{
			int num2 = stock - num;
			if (NumFloatingGem == null)
			{
				NumFloatingGem = UI_ProductionNumFloating.CreateInstance_ILRuntime();
			}
			if (NumFloatingGem == null)
			{
				return;
			}
			if (!((GObject)NumFloatingGem).onStage)
			{
				FGUIManager.Instance.AddNumFloatingForCouponBtn(NumFloatingGem, addDiamondBtn, stock - num);
			}
			else
			{
				((GObject)NumFloatingGem.Title).text = $"+{(int)((GObject)NumFloatingGem.Title).data + num2}";
				((GObject)NumFloatingGem.Title).data = (int)((GObject)NumFloatingGem.Title).data + num2;
			}
		}
		addDiamondBtn.GetChild("num").data = stock;
	}

	private void RefreshMoneyNum(List<string> str)
	{
		UpdateMoney();
	}

	public void PlayUpdateMoneySfx(int moneyNum)
	{
		if (addCouponBtn.GetChild("num").data != null)
		{
			int num = (int)addCouponBtn.GetChild("num").data + moneyNum;
			FGUIManager.Instance.AddNumFloatingForCouponBtn(UI_ProductionNumFloating.CreateInstance_ILRuntime(), addCouponBtn, moneyNum, 1, dispose: true);
			((GObject)addCouponBtn.GetChild("num").asTextField).text = num.ToString();
			addCouponBtn.GetChild("num").data = num;
		}
	}

	public void UpdateMoney(bool isInit = false)
	{
		if (!MoneyNumInit)
		{
			((GObject)addCouponBtn.GetChild("num").asTextField).text = "——";
			return;
		}
		int stock = GameManagers.Instance.StockController.GetStock("Money");
		if (!isInit && addCouponBtn.GetChild("num").data != null && (int)addCouponBtn.GetChild("num").data != stock)
		{
			int num = (int)addCouponBtn.GetChild("num").data;
			int value = stock - num;
			FGUIManager.Instance.AddNumFloatingForCouponBtn(UI_ProductionNumFloating.CreateInstance_ILRuntime(), addCouponBtn, value, 1, dispose: true);
		}
		((GObject)addCouponBtn.GetChild("num").asTextField).text = stock.ToString();
		addCouponBtn.GetChild("num").data = stock;
	}

	public void ChangeName(string userName)
	{
	}

	public void ChangeHeadIcon(Sprite icon)
	{
	}

	private void UpdateActivityShowNote(Mission mission)
	{
		UpdateActivityShowNoteUseCache();
	}

	private void UpdateActivityShowNoteUseCache(bool useCache = false)
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			_activityEntranceRedDotController.GetEntranceRedDotVisible(ActivityEntranceMode.NewForeignRewards, SetActivityNote, useCache);
		}
		else if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode3() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode4() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode5() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode6() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode7())
		{
			_activityEntranceRedDotController.GetEntranceRedDotVisible(ActivityEntranceMode.Rewards, SetActivityNote, useCache);
		}
		else
		{
			_activityEntranceRedDotController.GetEntranceRedDotVisible(ActivityEntranceMode.NewGuideModeRewards, SetActivityNote, useCache);
		}
	}

	private void SetActivityNote(bool display)
	{
		((GObject)AcitivityBtn.note).visible = display;
	}

	private void JudgeShowNote()
	{
		if (((GObject)this).isDisposed)
		{
			return;
		}
		((GObject)DailyBtn.note).visible = GameManagers.Instance.NewMsgIncomingManager.HasNewTechPoint();
		((GObject)LegionsBtn.note).visible = GameManagers.Instance.NewMsgIncomingManager.AnySoldierHasNewMsg() || GameManagers.Instance.NewMsgIncomingManager.AnySoldierPieceHasNewMsg();
		((GObject)DungeonsBtn.note).visible = GameManagers.Instance.NewMsgIncomingManager.HasAnyBuildingsToAccept() || GameManagers.Instance.NewMsgIncomingManager.HasAnyBuildingToUpgrade();
		((GObject)LotteryBtn.note).visible = false;
		List<Activity> activitiesByType = GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.Lottery, null, isSort: false);
		foreach (Activity item in activitiesByType)
		{
			if (item.HasAnyNewMsg(GameManagers.Instance))
			{
				((GObject)LotteryBtn.note).visible = true;
				break;
			}
		}
		((GObject)MainBattleBtn.note).visible = GameManagers.Instance.NewMsgIncomingManager.HasAnyNewUnlockedRegion();
		UpdateActivityShowNoteUseCache(useCache: true);
		NeutralDungeonData neutralDungeonData = FGUIManager.Instance.NeutralDungeonData;
		if (neutralDungeonData != null)
		{
			((VirtualBuildingController)GameManagers.Instance.BuildingManager.GetBuildingByType<Shift.Legion.Common.Models.MilitaryIntelligence>("14").Controller).SetNeutralDungeonTipVisible(neutralDungeonData.HasUnlocked() && neutralDungeonData.Activity.CanPlay(GameManagers.Instance));
		}
	}

	private void JudgeRechargeActivityShortCut(bool useCache)
	{
		RechargeActivityBtn.status.selectedIndex = 0;
		NoviceRechargeData noviceRechargeData = FGUIManager.Instance.NoviceRechargeData;
		if (noviceRechargeData != null)
		{
			DateTimeOffset serverNow = DateTimeHelper.ServerNow;
			if (!DateTimeHelper.TryParse(noviceRechargeData.FirstRechargeEnableTime, out var dateTime))
			{
				dateTime = default(DateTimeOffset);
			}
			if (!DateTimeHelper.TryParse(noviceRechargeData.ContinusRechargeEnableTime, out var dateTime2))
			{
				dateTime2 = default(DateTimeOffset);
			}
			if (serverNow.CompareTo(dateTime) < 1)
			{
				RechargeActivityBtn.status.selectedIndex = 0;
			}
			else if (serverNow.CompareTo(dateTime2) < 1)
			{
				RechargeActivityBtn.status.selectedIndex = 1;
			}
		}
		if (((GObject)RechargeActivityBtn).visible)
		{
			if (HotUpdateProcess.Instance.IsRegionOutCN)
			{
				_activityEntranceRedDotController.GetEntranceRedDotVisible(ActivityEntranceMode.NewForeignNewcomerSpecial, SetRechargeActivityNote, useCache);
			}
			else
			{
				_activityEntranceRedDotController.GetEntranceRedDotVisible(ActivityEntranceMode.NewcomerSpecial, SetRechargeActivityNote, useCache);
			}
		}
		void SetRechargeActivityNote(bool display)
		{
			RechargeActivityBtn.note.selectedIndex = (display ? 1 : 0);
		}
	}

	public void OnClickRechargeActivity()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>
		{
			{ "Parent", this },
			{
				"SortingOrder",
				((GObject)this).sortingOrder
			}
		};
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			string value = ((RechargeActivityBtn.Type.selectedIndex == 1) ? "SpinWeekActivityName".ToLanguage() : string.Empty);
			dictionary.Add("TitleName", value);
		}
		OnClickRechargeActivityExt(dictionary);
	}

	private void OnClickShadowDemonBtn()
	{
		Dictionary<string, object> additionalParam = new Dictionary<string, object> { { "Tab", 19 } };
		if (ShowNewComerSpecial())
		{
			OnClickRechargeActivityExt(additionalParam);
		}
		else
		{
			ActivityBtnEventExt(additionalParam);
		}
	}

	public static void OnClickRechargeActivityExt(Dictionary<string, object> additionalParam)
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>
			{
				{
					"TabFilter",
					GameManagers.Instance.ActivityManager.EntranceController.GetActivityTabFilter(ActivityEntranceMode.NewForeignNewcomerSpecial)
				},
				{
					"TabFilterType",
					ActivityEntranceMode.NewForeignNewcomerSpecial
				}
			};
			if (additionalParam != null)
			{
				foreach (KeyValuePair<string, object> item in additionalParam)
				{
					dictionary.Add(item.Key, item.Value);
				}
			}
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ActivityPanel.Name, dictionary);
		}
		else
		{
			if (!GameManagers.Instance.UserArchiveManager.IsNewGuideMode3() && !GameManagers.Instance.UserArchiveManager.IsNewGuideMode4() && !GameManagers.Instance.UserArchiveManager.IsNewGuideMode5() && !GameManagers.Instance.UserArchiveManager.IsNewGuideMode6() && !GameManagers.Instance.UserArchiveManager.IsNewGuideMode7())
			{
				return;
			}
			Dictionary<string, object> dictionary2 = new Dictionary<string, object>
			{
				{
					"TabFilter",
					GameManagers.Instance.ActivityManager.EntranceController.GetActivityTabFilter(ActivityEntranceMode.NewcomerSpecial)
				},
				{
					"TabFilterType",
					ActivityEntranceMode.NewcomerSpecial
				}
			};
			if (additionalParam != null)
			{
				foreach (KeyValuePair<string, object> item2 in additionalParam)
				{
					dictionary2.Add(item2.Key, item2.Value);
				}
			}
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ActivityPanel.Name, dictionary2);
		}
	}

	public void OpenRechargeActivityWithTabId()
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "Parent", this },
				{
					"SortingOrder",
					((GObject)this).sortingOrder
				},
				{
					"TabFilter",
					_activityEntranceController.GetActivityTabFilter(ActivityEntranceMode.NewForeignNewcomerSpecial)
				},
				{
					"TabFilterType",
					ActivityEntranceMode.NewForeignNewcomerSpecial
				},
				{ "Tab", 15 }
			};
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ActivityPanel.Name, parameters);
		}
		else
		{
			Dictionary<string, object> parameters2 = new Dictionary<string, object>
			{
				{ "Parent", this },
				{
					"SortingOrder",
					((GObject)this).sortingOrder
				},
				{
					"TabFilter",
					_activityEntranceController.GetActivityTabFilter(ActivityEntranceMode.NewcomerSpecial)
				},
				{
					"TabFilterType",
					ActivityEntranceMode.NewcomerSpecial
				},
				{ "Tab", 15 }
			};
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ActivityPanel.Name, parameters2);
		}
	}

	private void OpenRoom(EventContext context)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(context.inputEvent.x, context.inputEvent.y);
		val.y = (float)Screen.height - val.y;
		Ray val2 = default(Ray);
		val2 = Camera.main.ScreenPointToRay(Vector2.op_Implicit(val));
		RaycastHit val3 = default(RaycastHit);
		if (!Physics.Raycast(val2, ref val3, 200f))
		{
			return;
		}
		HitArea.HitData hitData = ((Component)((RaycastHit)(ref val3)).collider).gameObject.GetComponent<HitArea>().hitData;
		if (hitData.name == "Product" || hitData.name == "Wall")
		{
			return;
		}
		if (hitData.name == "CollectionWorkShop" || hitData.name == "WorkShop")
		{
			if (GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id).Status == BuildingStatus.Banned)
			{
				List<string> arg = new List<string>
				{
					LanguagesManager.GetDesc("CsharpCodeZhTcText21"),
					LanguagesManager.GetDesc("CsharpCodeZhTcText22")
				};
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			}
			else if (GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id).Status == BuildingStatus.Ready)
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("Parent", this);
				dictionary.Add("Building", GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id));
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary);
			}
			else if (GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id).Level == 0)
			{
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				dictionary2.Add("Building", GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id));
				dictionary2.Add("Parent", this);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary2);
			}
			else if (hitData.name == "CollectionWorkShop")
			{
				if (hitData.id == "12")
				{
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvGMode3CollectingPanel.Name, null);
					return;
				}
				Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
				dictionary3.Add("BuildingType", hitData.id);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_CollectionPanel.Name, dictionary3);
			}
			else if (hitData.name == "WorkShop")
			{
				Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
				dictionary4.Add("BuildingType", hitData.id);
				dictionary4.Add("ProductId", null);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_WorkShopPanel.Name, dictionary4);
			}
		}
		else if (hitData.name == "Knapsack")
		{
			if (GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id).Status == BuildingStatus.Banned)
			{
				List<string> arg2 = new List<string>
				{
					LanguagesManager.GetDesc("CsharpCodeZhTcText21"),
					LanguagesManager.GetDesc("CsharpCodeZhTcText22")
				};
				SharedMessenger.Broadcast("SHOW_TIPS", arg2, 1, arg3: false);
			}
			else if (GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id).Status == BuildingStatus.Ready)
			{
				Dictionary<string, object> dictionary5 = new Dictionary<string, object>();
				dictionary5.Add("Parent", this);
				dictionary5.Add("Building", GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id));
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary5);
			}
			else if (GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id).Level == 0)
			{
				Dictionary<string, object> dictionary6 = new Dictionary<string, object>();
				dictionary6.Add("Building", GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id));
				dictionary6.Add("Parent", this);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary6);
			}
			else if (FGUIManager.Instance.JudgeFreeWorkerNum(needTip: true))
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_WarehousePanel.Name, null);
			}
		}
		else
		{
			if (hitData.name == "UI_LobbyOfWar")
			{
				return;
			}
			if (hitData.name == "UI_RecruitingCamp")
			{
				if (GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id).Status == BuildingStatus.Banned)
				{
					List<string> arg3 = new List<string>
					{
						LanguagesManager.GetDesc("CsharpCodeZhTcText21"),
						LanguagesManager.GetDesc("CsharpCodeZhTcText22")
					};
					SharedMessenger.Broadcast("SHOW_TIPS", arg3, 1, arg3: false);
				}
				else if (GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id).Status == BuildingStatus.Ready)
				{
					Dictionary<string, object> dictionary7 = new Dictionary<string, object>();
					dictionary7.Add("Parent", this);
					dictionary7.Add("Building", GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id));
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary7);
				}
				else if (GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id).Level == 0)
				{
					Dictionary<string, object> dictionary8 = new Dictionary<string, object>();
					dictionary8.Add("Building", GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id));
					dictionary8.Add("Parent", this);
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary8);
				}
				else if (FGUIManager.Instance.JudgeFreeWorkerNum(needTip: true))
				{
					GameController.Contexts.Service<IUiService>().OpenPanel(hitData.name, null);
				}
			}
			else if (hitData.name == "UI_MilitaryIntelligence7")
			{
				Dictionary<string, object> dictionary9 = new Dictionary<string, object>();
				Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id);
				if (buildingByType.Status == BuildingStatus.Banned)
				{
					List<string> arg4 = new List<string>
					{
						LanguagesManager.GetDesc("CsharpCodeZhTcText21"),
						LanguagesManager.GetDesc("CsharpCodeZhTcText22")
					};
					SharedMessenger.Broadcast("SHOW_TIPS", arg4, 1, arg3: false);
				}
				else if (buildingByType.Status == BuildingStatus.Ready)
				{
					dictionary9.Add("Parent", this);
					dictionary9.Add("Building", buildingByType);
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary9);
				}
				else if (buildingByType.Level == 0)
				{
					dictionary9.Add("Building", buildingByType);
					dictionary9.Add("Parent", this);
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary9);
				}
				else if (FGUIManager.Instance.JudgeFreeWorkerNum(needTip: true))
				{
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_MilitaryIntelligencePanel.Name, dictionary9);
				}
			}
			else if (hitData.name == UI_GvGExpeditionHallPanel.Name)
			{
				Building buildingByType2 = GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id);
				if (buildingByType2.Status == BuildingStatus.Banned)
				{
					Dictionary<string, object> parameters = new Dictionary<string, object>
					{
						{
							"Building",
							GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id)
						},
						{ "Parent", this }
					};
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, parameters);
				}
				else if (buildingByType2.Status == BuildingStatus.Ready)
				{
					Dictionary<string, object> dictionary10 = new Dictionary<string, object>();
					dictionary10.Add("Parent", this);
					dictionary10.Add("Building", GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id));
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary10);
				}
				else if (buildingByType2.Level == 0)
				{
					Dictionary<string, object> parameters2 = new Dictionary<string, object>
					{
						{
							"Building",
							GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id)
						},
						{ "Parent", this }
					};
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, parameters2);
				}
				else
				{
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGExpeditionHallPanel.Name, null);
				}
			}
			else if (hitData.name == "UI_BlackMarketer")
			{
				if (GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id).Status == BuildingStatus.Banned)
				{
					List<string> arg5 = new List<string>
					{
						LanguagesManager.GetDesc("CsharpCodeZhTcText21"),
						LanguagesManager.GetDesc("CsharpCodeZhTcText22")
					};
					SharedMessenger.Broadcast("SHOW_TIPS", arg5, 1, arg3: false);
				}
				else if (GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id).Status == BuildingStatus.Ready)
				{
					Dictionary<string, object> dictionary11 = new Dictionary<string, object>();
					dictionary11.Add("Parent", this);
					dictionary11.Add("Building", GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id));
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary11);
				}
				else if (GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id).Level == 0)
				{
					Dictionary<string, object> dictionary12 = new Dictionary<string, object>();
					dictionary12.Add("Building", GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id));
					dictionary12.Add("Parent", this);
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary12);
				}
				else
				{
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_BlackMarketerPanel.Name, null);
				}
			}
			else if (hitData.name == "UI_PrinceOfTheDevils")
			{
				if (FGUIManager.Instance.JudgeFreeWorkerNum(needTip: true))
				{
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_PrinceOfTheDevilsPanel.Name, new Dictionary<string, object> { { "Parent", this } });
				}
			}
			else if (hitData.name == "UI_RecyclingCenterPanel")
			{
				if (GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id).Status == BuildingStatus.Banned)
				{
					List<string> arg6 = new List<string>
					{
						LanguagesManager.GetDesc("CsharpCodeZhTcText21"),
						LanguagesManager.GetDesc("CsharpCodeZhTcText22")
					};
					SharedMessenger.Broadcast("SHOW_TIPS", arg6, 1, arg3: false);
				}
				else if (GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id).Status == BuildingStatus.Ready)
				{
					Dictionary<string, object> dictionary13 = new Dictionary<string, object>();
					dictionary13.Add("Parent", this);
					dictionary13.Add("Building", GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id));
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary13);
				}
				else if (GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id).Level == 0)
				{
					Dictionary<string, object> dictionary14 = new Dictionary<string, object>();
					dictionary14.Add("Building", GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id));
					dictionary14.Add("Parent", this);
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary14);
				}
				else
				{
					Dictionary<string, object> parameters3 = new Dictionary<string, object>();
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_RecyclingCenterPanel.Name, parameters3);
				}
			}
			else if (!(hitData.name == "SpringFestival2021"))
			{
				if (hitData.name == "ActivityEntrance")
				{
					Dictionary<string, object> parameters4 = new Dictionary<string, object>();
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_SpecialActivityPanel.Name, parameters4);
				}
				else if (hitData.name == "PVPEntrance")
				{
					OpenSomeRoomAction(hitData.id, RankDataHelper.ChoosePvpLadderOrAllServersChampionship);
				}
				else if (hitData.name == "VideoEntrance")
				{
					GvG3VideoEntrance.Instance.OnClick();
				}
				else if (hitData.name == "GiftOfLordEntrance")
				{
					GiftOfLordEntrance.Instance.OnClick();
				}
				else
				{
					GameController.Contexts.Service<IUiService>().OpenPanel(hitData.name, null);
				}
			}
		}
	}

	private void OnOpenPvP()
	{
		OpenSomeRoomAction("18", RankDataHelper.ChoosePvpLadderOrAllServersChampionship);
	}

	private void OpenSomeRoomAction(string buildingType, Action action)
	{
		if (GameManagers.Instance.BuildingManager.GetBuildingByType(buildingType).Status == BuildingStatus.Banned)
		{
			List<string> arg = new List<string>
			{
				LanguagesManager.GetDesc("CsharpCodeZhTcText21"),
				LanguagesManager.GetDesc("CsharpCodeZhTcText22")
			};
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
		else if (!GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1002").Contains("P220"))
		{
			UI_main_PvPEntranceUnlockTip.OpenPvPEntranceUnlockTip();
		}
		else if (GameManagers.Instance.BuildingManager.GetBuildingByType(buildingType).Status == BuildingStatus.Ready)
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "Parent", this },
				{
					"Building",
					GameManagers.Instance.BuildingManager.GetBuildingByType(buildingType)
				}
			};
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, parameters);
		}
		else if (GameManagers.Instance.BuildingManager.GetBuildingByType(buildingType).Level == 0)
		{
			Dictionary<string, object> parameters2 = new Dictionary<string, object>
			{
				{
					"Building",
					GameManagers.Instance.BuildingManager.GetBuildingByType(buildingType)
				},
				{ "Parent", this }
			};
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, parameters2);
		}
		else
		{
			action();
		}
	}

	private void InitHeadPortraitValue(int _exp = 0)
	{
		int userLevel = GameManagers.Instance.UserArchiveManager.GetUserLevel();
		((GObject)((GComponent)headPortraitBtn).GetChild("level").asTextField).text = userLevel.ToString();
		double num = GameManagers.Instance.ConfigDataManager.GetUserCurLevelExp();
		double num2 = GameManagers.Instance.UserArchiveManager.GetUserExp();
		double num3 = GameManagers.Instance.ConfigDataManager.GetUserNextLevelExp();
		double value = (num2 - num) / (num3 - num) * 100.0;
		((GProgressBar)headPortraitBtn.articleExperience).value = value;
		((GObject)headPortraitBtn.articleExperience.experience).text = $"{Convert.ToInt32(num2 - num)}/{Convert.ToInt32(num3 - num)}";
	}

	private void InitInitHeadPortraitBtnInfo()
	{
		FGUIManager.Instance.OpenIEnumerator(FGUIManager.Instance.GetUserNickName(GameController.Contexts.gameState.user.value.UserId, ((GObject)headPortraitBtn).asCom.GetChild("title").asTextField));
	}

	private void CameraToMainCityLeft()
	{
		GameController.Contexts.Service<ICameraService>().SwitchToScene("MainCity.Left");
		FGUIManager.Instance.BuildingIndicatorInit();
	}

	private void CameraToMainCityRight()
	{
		GameController.Contexts.Service<ICameraService>().SwitchToScene("MainCity.Right");
		FGUIManager.Instance.BuildingIndicatorInit();
	}

	public void OnAnyLoadingPanelStatus(GameStateEntity entity, LoadingPanelStatus value)
	{
		switch (value)
		{
		case LoadingPanelStatus.Closed:
			FGUIManager.Instance.ChangeMaincityTurnBtnStatus();
			break;
		case LoadingPanelStatus.Opening:
			break;
		case LoadingPanelStatus.Showing:
			FGUIManager.Instance.BuildingsTitleAppear();
			break;
		case LoadingPanelStatus.Closing:
			FGUIManager.Instance.BuildingsTitleAppear();
			FGUIManager.Instance.BuildingsTitleFadeOut();
			break;
		default:
			throw new ArgumentOutOfRangeException("value", value, null);
		}
	}

	private void CloseLoadingPanel(string uiId)
	{
		if (uiId == UI_LoadingPanel.Name)
		{
			FGUIManager.Instance.BuildingsTitleAppear();
			FGUIManager.Instance.BuildingsTitleFadeOut();
		}
	}

	public void OnAnyOfflineBonuses(GameStateEntity entity, List<Bonus> value)
	{
		FGUIManager.Instance.ShowNewOfflineBonuses();
	}

	private void InitActivityEntrance()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		((GObject)RechargeActivityBtn).visible = false;
		FGUIManager.Instance.AddTextSpecialEffects(RechargeActivityBtn.effPos, "ui_stroke_button_2", new Vector3(100f, 100f, 100f));
	}

	public void RefreshNewComerSpecialIcon()
	{
		_activityEntranceController.CheckEntranceVisible(delegate(ActivityEntranceVisible entranceVisible)
		{
			int num = GameLocalDataManager.GetInt("NewComerSpecialIconShow");
			bool flag = num == 0 || num == 2;
			List<string> visibleUis;
			if (HotUpdateProcess.Instance.IsRegionOutCN)
			{
				((GObject)RechargeActivityBtn).visible = flag && entranceVisible.Visible[ActivityEntranceMode.NewForeignNewcomerSpecial];
				visibleUis = entranceVisible.GetVisibleUis(ActivityEntranceMode.NewForeignNewcomerSpecial);
			}
			else
			{
				if (!GameManagers.Instance.UserArchiveManager.IsNewGuideMode3() && !GameManagers.Instance.UserArchiveManager.IsNewGuideMode4() && !GameManagers.Instance.UserArchiveManager.IsNewGuideMode5() && !GameManagers.Instance.UserArchiveManager.IsNewGuideMode6() && !GameManagers.Instance.UserArchiveManager.IsNewGuideMode7())
				{
					flag = false;
				}
				((GObject)RechargeActivityBtn).visible = flag && entranceVisible.Visible[ActivityEntranceMode.NewcomerSpecial];
				visibleUis = entranceVisible.GetVisibleUis(ActivityEntranceMode.NewcomerSpecial);
			}
			if (HotUpdateProcess.Instance.IsRegionOutCN)
			{
				HashSet<string> hashSet = new HashSet<string>(visibleUis);
				hashSet.ExceptWith(UI_ActivityPanel.SpinWeekActivities);
				bool flag2 = hashSet.Count > 0;
				bool flag3 = HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi.ActivityEntranceController.IsSpinWeekSpinVisible();
				RechargeActivityBtn.Type.SetSelectedIndex((!flag2) ? 1 : 0);
				if (flag3)
				{
					RechargeActivityBtn.isShowCountDown.SetSelectedIndex((!flag2) ? 1 : 0);
					if (_spinWeekCountDown != null)
					{
						((MonoBehaviour)FGUIManager.Instance).StopCoroutine(_spinWeekCountDown);
					}
					_spinWeekCountDown = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(SpinWeekCountDown());
				}
			}
		});
	}

	private void RefreshShadowDemonGiftIcon()
	{
		bool flag = false;
		if (HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi.ActivityEntranceController.IsShadowDemonGiftVisible())
		{
			flag = true;
			DateTimeOffset endAt = ActivityManager.ShadowDemonGift.ActivityProgress(GameManagers.Instance).EndAt;
			long serverTime = GameController.Instance.GetServerTime();
			if (serverTime >= endAt.ToUnixTimeSeconds())
			{
				flag = false;
			}
			if (flag)
			{
				bool flag2 = ActivityEntranceRedDotController.IsShadowDemonGiftNoteVisible();
				ShadowDemonBtn.note.SetSelectedIndex(flag2 ? 1 : 0);
				ShadowDemonBtn.isShowCountDown.SetSelectedIndex(1);
				if (_shadowDemonCountDown != null)
				{
					((MonoBehaviour)FGUIManager.Instance).StopCoroutine(_shadowDemonCountDown);
				}
				_shadowDemonCountDown = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(ShadowDemonCountDown(endAt.ToUnixTimeSeconds()));
			}
		}
		((GObject)ShadowDemonBtn).visible = flag;
	}

	private static bool ShowNewComerSpecial()
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			return true;
		}
		return GameManagers.Instance.UserArchiveManager.IsNewGuideMode3() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode4() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode5() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode6() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode7();
	}

	private void OnFriendsChatUpdate(FriendsChatSession session)
	{
		FGUIManager.Instance.UpdateMailBtnNote();
	}

	private IEnumerator SpinWeekCountDown()
	{
		WaitForSeconds wait = new WaitForSeconds(1f);
		while (!((GObject)this).isDisposed)
		{
			long endTime = GameController.Instance.GetServerTime();
			if (ActivityManager.SpinWeekActivity != null)
			{
				endTime = ActivityManager.SpinWeekActivity.ActivityConfig.EndTime;
			}
			long remainTime = endTime - GameController.Instance.GetServerTime();
			((GObject)RechargeActivityBtn.Time).text = UiHelper.ParseTimeChinsesDH((int)remainTime);
			if (remainTime <= 0)
			{
				RechargeActivityBtn.isShowCountDown.SetSelectedIndex(0);
				_spinWeekCountDown = null;
				RefreshNewComerSpecialIcon();
				break;
			}
			yield return wait;
		}
	}

	private IEnumerator ShadowDemonCountDown(long endTime)
	{
		WaitForSeconds wait = new WaitForSeconds(1f);
		while (!((GObject)this).isDisposed)
		{
			long remainTime = endTime - GameController.Instance.GetServerTime();
			((GObject)ShadowDemonBtn.Time).text = UiHelper.ParseTimeChinsesDH((int)remainTime);
			if (remainTime <= 0)
			{
				ShadowDemonBtn.isShowCountDown.SetSelectedIndex(0);
				_shadowDemonCountDown = null;
				RefreshShadowDemonGiftIcon();
				break;
			}
			yield return wait;
		}
	}

	private void InitProgressionMission()
	{
		if (!GameManagers.Instance.UserArchiveManager.IsForeignNewGuideMode())
		{
			return;
		}
		_isFirstInitProgression = true;
		_isFirstInitChallenge = true;
		_currentDay = -1;
		Task<GetCreateAccountDay.Response> createDayTask = GameController.Contexts.Service<INetworkService>().GetCreateAccountDay();
		createDayTask.GetAwaiter().OnCompleted(delegate
		{
			GetCreateAccountDay.Response result = createDayTask.Result;
			GameManagers.Instance.UserArchiveManager.SetDailyAtCreateAccount(result.Timestamp);
			SharedMessenger.AddListener<string, ActivityStatus>("ACTIVITY_STATUS_CHANGED", OnActivityStatusChange);
			SharedMessenger.AddListener<float>("ON_RECHARGE", OnRecharge);
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetInitCoroutine());
			SharedMessenger.AddListener<Mission>("MISSION_COMPLETE", RefreshIconNode);
			SharedMessenger.AddListener("MISSION_CLAIMED", delegate(Mission mission)
			{
				EffectHelper.CoroutineDelay(0.1f, delegate
				{
					RefreshIconNode(mission);
				});
			});
		});
	}

	private IEnumerator GetInitCoroutine()
	{
		WaitForSeconds wait = new WaitForSeconds(60f);
		while (true)
		{
			RefreshIcon();
			yield return wait;
		}
	}

	private void OnActivityStatusChange(string activityId, ActivityStatus newStatus)
	{
		if (activityId == ActivityManager.ChallengeMission.ActivityId || activityId == ActivityManager.ProgressionMission.ActivityId)
		{
			RefreshIcon();
		}
	}

	private void RefreshIconNode(Mission mission)
	{
		RefreshChallengeMissionIconNote();
		RefreshProgressionMissionNote(_currentDay);
	}

	private void OnRecharge(float amount)
	{
		RefreshStatusChallengeMissionIcon();
	}

	private void RefreshIcon()
	{
		Task<GetMissionOf7Foreign.Response> task = GameController.Contexts.Service<INetworkService>().GetMissionOf7ForeignRequest();
		task.GetAwaiter().OnCompleted(delegate
		{
			GetMissionOf7Foreign.Response result = task.Result;
			if (result.ErrorCode == 0)
			{
				RefreshStatusProgressMissionIcon(result);
			}
		});
		RefreshStatusChallengeMissionIcon();
	}

	private void RefreshProgressionMissionNote(int currentDay)
	{
		UI_ProgressionMissionPanel.FindFistShowTab(currentDay, out var hasUnclaimedReward);
		((GObject)n126.n8).visible = hasUnclaimedReward || _progressionTempNote;
	}

	private void RefreshStatusProgressMissionIcon(GetMissionOf7Foreign.Response result)
	{
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		double serverRealtimeSeconds = GameController.Instance.GetServerRealtimeSeconds();
		bool flag = (double)result.EndTime > serverRealtimeSeconds && (double)result.BeginTime < serverRealtimeSeconds;
		((GObject)n126).visible = flag;
		if (flag)
		{
			if (_isFirstInitProgression)
			{
				InitTempNoteProgressionMission(result);
			}
			int currentDay = result.GetCurrentDay();
			_currentDay = currentDay;
			RefreshProgressionMissionNote(currentDay);
			TimeSpan timeSpan = TimeSpan.FromDays(3.0);
			double num = (double)result.EndTime - serverRealtimeSeconds;
			bool flag2 = num < timeSpan.TotalSeconds;
			if (flag2 && _progressionCountDown == null)
			{
				_progressionCountDown = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(CountDownCoroutine(n126.countDown, result.EndTime, null));
			}
			n126.isShowCountDown.selectedIndex = (flag2 ? 1 : 0);
			((GObject)n126).onClick.Set((EventCallback1)delegate(EventContext x)
			{
				_progressionTempNote = false;
				RefreshProgressionMissionNote(currentDay);
				x.StopPropagation();
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_ProgressionMissionPanel.Name, null);
			});
		}
	}

	private void RefreshChallengeMissionIconNote()
	{
		UI_ChallengeMissionPanel.FindDefaultOpenTab(out var hasUnclaimedReward);
		long endTimeStamp;
		bool isLevelComplete;
		bool flag = IsChallengeOpen(out endTimeStamp, out isLevelComplete);
		if (flag && isLevelComplete)
		{
			((GObject)n127.n8).visible = hasUnclaimedReward || _challengeTempNote;
		}
		else
		{
			((GObject)n127.n8).visible = false;
		}
	}

	private void RefreshStatusChallengeMissionIcon()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		long endTimeStamp;
		bool isLevelComplete;
		bool flag = IsChallengeOpen(out endTimeStamp, out isLevelComplete);
		((GObject)n127).visible = flag;
		if (!flag)
		{
			return;
		}
		if (_isFirstInitChallenge)
		{
			InitTempNoteChallengeMission();
		}
		RefreshChallengeMissionIconNote();
		((GObject)n127).onClick.Set((EventCallback1)delegate(EventContext x)
		{
			if (isLevelComplete)
			{
				_challengeTempNote = false;
				RefreshChallengeMissionIconNote();
				x.StopPropagation();
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_ChallengeMissionPanel.Name, null);
			}
		});
		int num = GetRemainTime();
		bool flag2 = (double)num < TimeSpan.FromDays(3.0).TotalSeconds;
		if (flag2 && _challengeCountDown == null)
		{
			_challengeCountDown = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(CountDownCoroutine(n127.countDownLock, endTimeStamp, n127.endSoon));
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(CountDownCoroutine(n127.countDownUnlock, endTimeStamp, null));
		}
		n127.isUnLocked.selectedIndex = (isLevelComplete ? 1 : 0);
		((GObject)n127.countDownUnlock).visible = isLevelComplete && flag2;
		((GObject)n127.countDownLock).visible = !isLevelComplete && flag2;
		((GObject)n127.endSoon).visible = !isLevelComplete && flag2;
		int GetRemainTime()
		{
			double serverRealtimeSeconds = GameController.Instance.GetServerRealtimeSeconds();
			double num2 = (double)endTimeStamp - serverRealtimeSeconds;
			return (int)num2;
		}
	}

	private void InitTempNoteProgressionMission(GetMissionOf7Foreign.Response result)
	{
		_isFirstInitProgression = false;
		int score = result.Score;
		for (int i = 10; i <= score; i += 10)
		{
			if (result.BonusClaimedProgress.TryGetValue(i.ToString(), out var value) && !value.PayBonus.Claimed)
			{
				_progressionTempNote = true;
				return;
			}
		}
		double serverRealtimeSeconds = GameController.Instance.GetServerRealtimeSeconds();
		double num = (double)result.EndTime - serverRealtimeSeconds;
		if (!(num < TimeSpan.FromDays(3.0).TotalSeconds))
		{
			return;
		}
		int currentDay = result.GetCurrentDay();
		for (int j = 0; j < currentDay; j++)
		{
			int key = j + 1;
			MissionSerialConfig missionSerialConfig = UI_ProgressionMissionPanel.MissionData.MissionConfig[key];
			foreach (HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.MissionConfig item in missionSerialConfig.MissionSerial)
			{
				Mission mission = MissionManager.Missions[item.MissionId];
				mission.CanClaimBonus(GameManagers.Instance);
				if (mission.MissionState(GameManagers.Instance).Status == MissionStatus.Undergoing)
				{
					_progressionTempNote = true;
					return;
				}
			}
		}
	}

	private void InitTempNoteChallengeMission()
	{
		_isFirstInitChallenge = false;
		IsChallengeOpen(out var endTimeStamp, out var _);
		double serverRealtimeSeconds = GameController.Instance.GetServerRealtimeSeconds();
		double num = (double)endTimeStamp - serverRealtimeSeconds;
		bool challengeTempNote = num < TimeSpan.FromDays(3.0).TotalSeconds;
		_challengeTempNote = challengeTempNote;
	}

	private static IEnumerator CountDownCoroutine(GTextField gText, long endTime, GTextField insertText)
	{
		int remainTime = GetRemainTime();
		WaitForSeconds wait = new WaitForSeconds(1f);
		while (remainTime > 0 && !((GObject)gText).isDisposed)
		{
			((GObject)gText).text = UiHelper.ParseTimeSpanUniversal(remainTime);
			bool doInsert = remainTime / 3 % 2 == 0;
			if (insertText != null)
			{
				((GObject)insertText).alpha = (doInsert ? 1f : 0f);
				((GObject)gText).alpha = ((!doInsert) ? 1f : 0f);
			}
			yield return wait;
		}
		int GetRemainTime()
		{
			double serverRealtimeSeconds = GameController.Instance.GetServerRealtimeSeconds();
			double num = (double)endTime - serverRealtimeSeconds;
			return (int)num;
		}
	}

	public static bool IsChallengeOpen(out long endTimeStamp, out bool isLevelComplete)
	{
		bool flag = false;
		string activityId = ActivityManager.ChallengeMission.ActivityId;
		ActivityConfig activityProgressOrNew = GameManagers.Instance.UserArchiveManager.GetActivityProgressOrNew(activityId);
		ActivityStatus status = ActivityManager.ChallengeMission.GetStatus(GameManagers.Instance);
		double serverRealtimeSeconds = GameController.Instance.GetServerRealtimeSeconds();
		float num = ActivityManager.ChallengeMission.ChallengeMissionData.ContentCaseConfig.AccountDaysCase[1];
		int daysDuration = ActivityManager.ChallengeMission.ChallengeMissionData.DaysDuration;
		isLevelComplete = ActivityManager.ChallengeMission.CheckEnableCase(GameManagers.Instance);
		DateTimeOffset dateTimeOffset = DateTimeHelper.Parse(serverRealtimeSeconds);
		DateTimeOffset dateTimeOffset2 = DateTimeHelper.Parse(0);
		switch (status)
		{
		case ActivityStatus.Enabled:
		{
			DateTimeOffset dailyRefreshTime = DateTimeHelper.GetDailyRefreshTime(activityProgressOrNew.BeginAt);
			dateTimeOffset2 = dailyRefreshTime.AddDays(daysDuration);
			flag = dailyRefreshTime < dateTimeOffset && dateTimeOffset < dateTimeOffset2;
			break;
		}
		case ActivityStatus.Pending:
		{
			float totalRecharge = GameManagers.Instance.UserArchiveManager.GetTotalRecharge();
			bool flag2 = totalRecharge > 0.01f;
			int dailyAtCreateAccount = GameManagers.Instance.UserArchiveManager.GetDailyAtCreateAccount();
			DateTimeOffset dateTimeOffset3 = DateTimeHelper.Parse(dailyAtCreateAccount);
			bool flag3 = dateTimeOffset < dateTimeOffset3.Add(TimeSpan.FromDays(num));
			flag = flag2 && flag3;
			if (flag)
			{
				dateTimeOffset2 = dateTimeOffset.AddDays(daysDuration);
			}
			break;
		}
		}
		endTimeStamp = dateTimeOffset2.ToUnixTimeSeconds();
		return flag;
	}
}
