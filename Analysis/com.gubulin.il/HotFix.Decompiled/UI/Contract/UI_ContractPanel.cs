using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.Managers;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;
using Spine;
using Spine.Unity;
using UI.AddCredit;
using UI.BlackMarketer;
using UI.GameEndPanels;
using UI.GiftBag;
using UI.MainCity;
using UI.MaskCover;
using UI.PublicResources;
using UI.Tips;
using UnityEngine;

namespace UI.Contract;

public class UI_ContractPanel : GComponent, IUiController
{
	private class LotteryUiParams
	{
		public int Type;

		public Dictionary<string, string> Soldiers;
	}

	public Controller pageController;

	public GLoader background;

	public UI_CardStage CardStage;

	public GLoader mapLoader;

	public GGroup backGroup;

	public GList cardslocationList;

	public UI_batteryLucency batteryLucency;

	public UI_CardHorn CardHorn;

	public UI_starDown bulletBack;

	public UI_starDown muzzleSmokeBack;

	public UI_CardCannon CardCannon;

	public UI_RookiePoolBackground RookiePoolBackground;

	public UI_cardLoaderBtn singleFakeCard;

	public GTextField tip;

	public GGraph tipPos;

	public UI_ShowDrawResultPanel ShowDrawResultPanel;

	public UI_RookiePoolContent RookiePoolContent;

	public UI_CardLoader CardLoader;

	public GButton backBtn;

	public UI_Title TitleCom;

	public GButton Help;

	public GComponent diamondAddBtn;

	public GComponent addTicketBtn;

	public GComponent addCouponBtn;

	public GGroup titleGroup;

	public GGraph slideFloor;

	public GGraph InterruptBack;

	public Transition alphaChange;

	public Transition showTitleGroup;

	public Transition showTip;

	public const string URL = "ui://avplaivdjd4z0";

	public static string Name = "UI_ContractPanel";

	public string CommonPool = "GACHA_1";

	public const string Draw10Tag = "十连抽";

	private UI_basisPool _goldenTipCard;

	private Coroutine _softGuideClick;

	private UI_GuideFinger _guideFinger;

	private bool _shouldShowSoftGuide;

	private Dictionary<string, Vector2> soldierPosDic = new Dictionary<string, Vector2> { 
	{
		"S039",
		new Vector2(296f, 650f)
	} };

	private bool checkingLotteryActivityStatus = false;

	private bool needAddNewbieGACHAActivityBtnForUiTagManager;

	private float time = 1f;

	public List<GButton> targetList = new List<GButton>();

	private List<KeyValuePair<int, string>> _cardDataList = new List<KeyValuePair<int, string>>();

	private List<KeyValuePair<GButton, SkeletonAnimation>> workerList = new List<KeyValuePair<GButton, SkeletonAnimation>>();

	private List<GButton> cardsList = new List<GButton>();

	private List<string> textureList = new List<string>();

	private readonly HashSet<string> _spines = new HashSet<string>();

	private bool isDrawing = false;

	public int cardNum;

	private List<SwipeGesture> SwipeGestureList = new List<SwipeGesture>();

	private SwipeGesture _swipeGesture;

	private List<KeyValuePair<GButton, KeyValuePair<Vector2, Vector2>>> cardAndPosrangeList = new List<KeyValuePair<GButton, KeyValuePair<Vector2, Vector2>>>();

	private Activity generalCardPool;

	private Activity specialCardPool;

	public string generalTicketId;

	public string specialTicketId;

	private List<KeyValuePair<Bonus, int>> awardList = new List<KeyValuePair<Bonus, int>>();

	private Dictionary<string, float> _finalClaimedBonus = new Dictionary<string, float>();

	private Activity usedForDraw;

	public bool soldierShowPanel;

	public List<KeyValuePair<int, string>> newSoldierIdList = new List<KeyValuePair<int, string>>();

	public List<Bonus> WaitingForOpenUiList = new List<Bonus>();

	public List<Bonus> RepetitiveUiList = new List<Bonus>();

	private GButton singleCard;

	private List<Activity> lotteryActivities = new List<Activity>();

	private Dictionary<string, string> activityIdToDynamicPoolId = new Dictionary<string, string>();

	private List<GGraph> soldierAni = new List<GGraph>();

	private GButton SingleFakeCard;

	private bool needBreakDrawAnimation;

	public GTweener cannonMoveY;

	public GTweener mainCurtainMoveX;

	public Coroutine CannonMoveCoroutine;

	public Coroutine mainCurtainMoveCoroutine;

	private Coroutine ShowCardCoroutine;

	private Coroutine SetWorkerAndCardPathCoroutine;

	private List<Coroutine> SetWorkerAndCardPaths = new List<Coroutine>();

	public List<UI_bullet> bullets = new List<UI_bullet>();

	public List<Coroutine> CreatBullet = new List<Coroutine>();

	public List<Coroutine> SetBulletPath = new List<Coroutine>();

	private List<GButton> cardsCache = new List<GButton>();

	private List<GButton> workersCache = new List<GButton>();

	private List<GameObject> advancedSfxs = new List<GameObject>();

	private Vector2 ShowDrawResultPanelContentInitialPos;

	private List<KeyValuePair<string, float>> newSoldierBonuses = new List<KeyValuePair<string, float>>();

	private List<KeyValuePair<string, float>> levelUpBonuses = new List<KeyValuePair<string, float>>();

	private List<KeyValuePair<string, float>> debrisBonuses = new List<KeyValuePair<string, float>>();

	private List<KeyValuePair<string, float>> singleBonuses = new List<KeyValuePair<string, float>>();

	private UI_ResultCom resultPanel;

	public UI_ProductionNumFloating NumFloatingGem;

	public UI_ProductionNumFloating NumFloatingGem1;

	public UI_ProductionNumFloating NumFloatingGem2;

	public IUiController parentUi;

	private List<string> springFestivalSoldiers = new List<string>();

	private List<string> qualifiedSoldiers = new List<string>();

	private HashSet<GGraph> soldierSpineGGraphs = new HashSet<GGraph>();

	private bool qualifiedPool;

	private bool springFestivalPool;

	private UI_ReturnItemsPopup ReturnItemsPopup;

	private Dictionary<string, int> refundItems = new Dictionary<string, int>();

	private UI_HelpPanel HelpPanel;

	private GTextField timeTextField;

	private Coroutine timeCoroutine;

	private Coroutine postRenderingCardsCoroutine;

	private bool toUnloadAni;

	public List<List<ModelsBonus>> NewbieGACHADrawResult = new List<List<ModelsBonus>>();

	public NewbieGACHAActivityPayload newbieGACHAActivityPayload;

	public bool needShowNewbieContent;

	private const string CardStageSpineName = "card_stage_bg";

	private const string CardGachaPortalSfxName = "ui_cardgacha_portal";

	private const float StagePortalSize = 100f;

	private const float StageSpineSize = 100f;

	private const string SkinName = "skin1";

	private const string StageIdle = "idle";

	private const string StageIdle2 = "idle2";

	private const string StageOpen = "open";

	private const string StageClose = "close";

	private GameObject cardStagePortalSfx;

	private SkeletonAnimation cardStageSkeletonAnimation;

	private const string CardHornName = "card-horn";

	private SkeletonAnimation cardHornFooSkeletonAnimation;

	private SkeletonAnimation cardHornBarSkeletonAnimation;

	private const float CardHornSize = 100f;

	private const string HornOpen = "open";

	private const string HornWork = "work";

	private const string CardCannonName = "card_cannon";

	private SkeletonAnimation cardCannonSkeletonAnimation;

	private const float CardCannonSize = 100f;

	private const string CannonOpen = "open";

	private const string CannonWork = "work";

	private const string CannonClose = "close";

	public static string GetURL()
	{
		return "ui://avplaivdjd4z0";
	}

	public static UI_ContractPanel CreateInstance()
	{
		return (UI_ContractPanel)(object)UIPackage.CreateObject("Contract", "ContractPanel");
	}

	public static UI_ContractPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ContractPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdjd4z0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Expected O, but got Unknown
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		pageController = ((GComponent)this).GetController("pageController");
		background = (GLoader)((GComponent)this).GetChild("background");
		CardStage = (UI_CardStage)(object)((GComponent)this).GetChild("CardStage");
		mapLoader = (GLoader)((GComponent)this).GetChild("mapLoader");
		backGroup = (GGroup)((GComponent)this).GetChild("backGroup");
		cardslocationList = (GList)((GComponent)this).GetChild("cardslocationList");
		batteryLucency = (UI_batteryLucency)(object)((GComponent)this).GetChild("batteryLucency");
		CardHorn = (UI_CardHorn)(object)((GComponent)this).GetChild("CardHorn");
		bulletBack = (UI_starDown)(object)((GComponent)this).GetChild("bulletBack");
		muzzleSmokeBack = (UI_starDown)(object)((GComponent)this).GetChild("muzzleSmokeBack");
		CardCannon = (UI_CardCannon)(object)((GComponent)this).GetChild("CardCannon");
		RookiePoolBackground = (UI_RookiePoolBackground)(object)((GComponent)this).GetChild("RookiePoolBackground");
		singleFakeCard = (UI_cardLoaderBtn)(object)((GComponent)this).GetChild("singleFakeCard");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://avplaivdjd4z0".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		tipPos = (GGraph)((GComponent)this).GetChild("tipPos");
		ShowDrawResultPanel = (UI_ShowDrawResultPanel)(object)((GComponent)this).GetChild("ShowDrawResultPanel");
		RookiePoolContent = (UI_RookiePoolContent)(object)((GComponent)this).GetChild("RookiePoolContent");
		CardLoader = (UI_CardLoader)(object)((GComponent)this).GetChild("CardLoader");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		TitleCom = (UI_Title)(object)((GComponent)this).GetChild("TitleCom");
		Help = (GButton)((GComponent)this).GetChild("Help");
		diamondAddBtn = (GComponent)((GComponent)this).GetChild("diamondAddBtn");
		addTicketBtn = (GComponent)((GComponent)this).GetChild("addTicketBtn");
		addCouponBtn = (GComponent)((GComponent)this).GetChild("addCouponBtn");
		titleGroup = (GGroup)((GComponent)this).GetChild("titleGroup");
		slideFloor = (GGraph)((GComponent)this).GetChild("slideFloor");
		InterruptBack = (GGraph)((GComponent)this).GetChild("InterruptBack");
		alphaChange = ((GComponent)this).GetTransition("alphaChange");
		showTitleGroup = ((GComponent)this).GetTransition("showTitleGroup");
		showTip = ((GComponent)this).GetTransition("showTip");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		lotteryActivities = new List<Activity>();
		activityIdToDynamicPoolId = new Dictionary<string, string>();
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 1;
		if (parameters.TryGetValue("Parent", out var value))
		{
			parentUi = (IUiController)value;
		}
		CommonPool = "GACHA_1";
		if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode5() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode5())
		{
			CommonPool = "GACHA_1_5";
		}
		else if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode6() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode7() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode6())
		{
			CommonPool = "GACHA_1_6";
			string newbieGachaActivityId = GameManagers.Instance.UserArchiveManager.GetNewbieGachaActivityId();
			List<string> list = new List<string> { "GACHA_1_6_4" };
			if (!string.IsNullOrEmpty(newbieGachaActivityId))
			{
				list.Add(newbieGachaActivityId);
				for (int num = list.Count - 1; num >= 0; num--)
				{
					string key = list[num];
					if (ActivityManager.Activities.TryGetValue(key, out var value2))
					{
						LotteryActivityPayload payload = (LotteryActivityPayload)value2.ContentPayload(GameManagers.Instance).First().Value;
						if (CanDrawNext(payload) || HasProgressReward(payload))
						{
							CommonPool = value2.ActivityId;
							break;
						}
					}
				}
			}
		}
		CheckLotteryActivityStatus();
		ShowDrawResultPanelContentInitialPos = new Vector2(208f, -1090f);
		((GObject)ShowDrawResultPanel).alpha = 0f;
		time = 1f;
		SetBuildingName();
		RenderCardsLocationList(10);
		((GObject)slideFloor).touchable = false;
		((GObject)InterruptBack).touchable = false;
		((GObject)ShowDrawResultPanel.mask).visible = false;
		showTitleGroup.Play((PlayCompleteCallback)delegate
		{
			((GObject)backBtn).touchable = true;
			((GObject)TitleCom).touchable = true;
			((GObject)Help).touchable = true;
			((GObject)diamondAddBtn).touchable = true;
			((GObject)addCouponBtn).touchable = true;
			((GObject)addTicketBtn).touchable = true;
			((GObject)CardLoader).touchable = true;
			foreach (GGraph soldierSpineGGraph in soldierSpineGGraphs)
			{
				((GObject)soldierSpineGGraph).visible = true;
			}
		});
		CardStageInit();
	}

	public void BeforeDestroy()
	{
		if (timeCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(timeCoroutine);
		}
		if (postRenderingCardsCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(postRenderingCardsCoroutine);
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		((GObject)backBtn).onClick.Add(new EventCallback0(End));
		((GObject)InterruptBack).onClick.Set(new EventCallback0(InterruptDrawAnimation));
		((GObject)ShowDrawResultPanel.againBtn).onClick.Add(new EventCallback1(AgainBtnEvent));
		((GObject)ShowDrawResultPanel.exitBtn).onClick.Add(new EventCallback0(ExitBtnEvent));
		((GObject)ShowDrawResultPanel.content1.ConfirmBtn).onClick.Add(new EventCallback0(ExitBtnEvent));
		((GObject)ShowDrawResultPanel.content1.againBtn).onClick.Add(new EventCallback1(AgainBtnEvent));
		_swipeGesture = new SwipeGesture((GObject)(object)slideFloor);
		_swipeGesture.onMove.Add(new EventCallback1(SlideCard));
		((GObject)slideFloor).onClick.Add(new EventCallback1(SlideCard));
		((GObject)diamondAddBtn.GetChild("addButton").asButton).onClick.Add(new EventCallback0(AddDiamond));
		((GObject)addCouponBtn.GetChild("addButton").asButton).onClick.Add(new EventCallback0(AddCoupon));
		((GObject)addTicketBtn.GetChild("addButton").asButton).onClick.Add(new EventCallback0(AddTicket));
		((GObject)Help).onClick.Add(new EventCallback0(ShowHelpPanel));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		GameManagers.Instance.Messenger.AddListener<Dictionary<string, int>>("CHIEFDOM_WARNING", ShowRefundItems);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		((GObject)backBtn).onClick.Remove(new EventCallback0(End));
		((GObject)InterruptBack).onClick.Remove(new EventCallback0(InterruptDrawAnimation));
		((GObject)ShowDrawResultPanel.againBtn).onClick.Remove(new EventCallback1(AgainBtnEvent));
		((GObject)ShowDrawResultPanel.exitBtn).onClick.Remove(new EventCallback0(ExitBtnEvent));
		((GObject)ShowDrawResultPanel.content1.ConfirmBtn).onClick.Remove(new EventCallback0(ExitBtnEvent));
		((GObject)ShowDrawResultPanel.content1.againBtn).onClick.Remove(new EventCallback1(AgainBtnEvent));
		_swipeGesture.onMove.Remove(new EventCallback1(SlideCard));
		((GObject)slideFloor).onClick.Remove(new EventCallback1(SlideCard));
		((GObject)diamondAddBtn.GetChild("addButton").asButton).onClick.Remove(new EventCallback0(AddDiamond));
		((GObject)addCouponBtn.GetChild("addButton").asButton).onClick.Remove(new EventCallback0(AddCoupon));
		((GObject)addTicketBtn.GetChild("addButton").asButton).onClick.Remove(new EventCallback0(AddTicket));
		((GObject)Help).onClick.Remove(new EventCallback0(ShowHelpPanel));
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		GameManagers.Instance.Messenger.RemoveListener<Dictionary<string, int>>("CHIEFDOM_WARNING", ShowRefundItems);
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("ContractPanel", this);
		instance.Unregister("LotteryPanel.DrawAgainBtn", ShowDrawResultPanel.content1.againBtn);
		instance.Unregister("LotteryPanel.ClaimBtn", ShowDrawResultPanel.content1.ConfirmBtn);
		instance.Unregister("LotteryPanel.GemDisplay", diamondAddBtn);
		instance.Unregister("LotteryPanel.TicketDisplay", addTicketBtn);
		instance.Unregister("LotteryPanel.AddGemBtn", diamondAddBtn.GetChild("addButton"));
		instance.Unregister("LotteryPanel.AddTicketBtn", addCouponBtn.GetChild("addButton"));
		instance.Unregister("LotteryPanel.InterruptBack", InterruptBack);
		instance.Unregister("LotteryPanel.ExitBtn", backBtn);
		instance.Unregister("LotteryPanel.TipPosClickGraph", tipPos);
		instance.Unregister("LotteryPanel.NewbieCard");
		instance.Unregister("LotteryPanel.NewbieCardSoldier");
		object obj = instance.FindObjectByTag("LotteryPanel.FirstLotteryResult");
		if (obj != null)
		{
			instance.Unregister("LotteryPanel.FirstLotteryResult", obj);
		}
		object obj2 = instance.FindObjectByTag("LotteryPanel.SecondLotteryResult");
		if (obj2 != null)
		{
			instance.Unregister("LotteryPanel.SecondLotteryResult", obj2);
		}
		object obj3 = instance.FindObjectByTag("LotteryPanel.FirstLotteryOption");
		if (obj3 != null)
		{
			instance.Unregister("LotteryPanel.FirstLotteryOption", obj3);
		}
		object obj4 = instance.FindObjectByTag("LotteryPanel.SecondLotteryOption");
		if (obj4 != null)
		{
			instance.Unregister("LotteryPanel.SecondLotteryOption", obj4);
		}
		object obj5 = instance.FindObjectByTag("LotteryPanel.NewbieLotteryOption");
		if (obj5 != null)
		{
			instance.Unregister("LotteryPanel.NewbieLotteryOption", obj5);
		}
		if (parentUi != null && parentUi is UI_MainCity)
		{
			UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
		}
		if (parentUi != null && parentUi is UI_GameEndPanelFail)
		{
			UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
		}
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("ContractPanel", this);
		instance.Register("LotteryPanel.DrawAgainBtn", ShowDrawResultPanel.content1.againBtn);
		instance.Register("LotteryPanel.ClaimBtn", ShowDrawResultPanel.content1.ConfirmBtn);
		instance.Register("LotteryPanel.GemDisplay", diamondAddBtn);
		instance.Register("LotteryPanel.TicketDisplay", addTicketBtn);
		instance.Register("LotteryPanel.AddGemBtn", diamondAddBtn.GetChild("addButton"));
		instance.Register("LotteryPanel.AddTicketBtn", addCouponBtn.GetChild("addButton"));
		instance.Register("LotteryPanel.InterruptBack", InterruptBack);
		instance.Register("LotteryPanel.ExitBtn", backBtn);
		instance.Register("LotteryPanel.TipPosClickGraph", tipPos);
	}

	private void RefreshCommonPoolShowGoldenCardTip()
	{
		if (_goldenTipCard == null || !ShouldShowGoldenTip(_goldenTipCard.CardType.selectedIndex))
		{
			return;
		}
		_goldenTipCard.showGoldTip.SetSelectedIndex(0);
		if (!GameManagers.Instance.UserArchiveManager.IsNewGuideMode5() && !GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode5() && !GameManagers.Instance.UserArchiveManager.IsNewGuideMode6() && !GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode6() && !GameManagers.Instance.UserArchiveManager.IsNewGuideMode7())
		{
			return;
		}
		Task<GetDrawCardCntResponse> task = GameController.Contexts.Service<INetworkService>().GetDrawCardCnt(CommonPool, "十连抽");
		task.GetAwaiter().OnCompleted(delegate
		{
			if (!((GObject)this).isDisposed)
			{
				GetDrawCardCntResponse result = task.Result;
				if (result.Result)
				{
					int drawCnt = result.DrawCnt;
					drawCnt++;
					List<int> list = "ContractShowGoldTipNumbers".ToConfiguration<List<int>>();
					bool flag = list.Contains(drawCnt);
					_goldenTipCard.showGoldTip.SetSelectedIndex(flag ? 1 : 0);
				}
			}
		});
	}

	private IEnumerator PostRenderingCards()
	{
		if (!checkingLotteryActivityStatus && lotteryActivities.Count < 1)
		{
			yield break;
		}
		while (checkingLotteryActivityStatus)
		{
			yield return (object)new WaitForEndOfFrame();
			if (((GObject)this).isDisposed)
			{
				yield break;
			}
		}
		List<string> checkingActivities = new List<string>();
		foreach (Activity lotteryActivity in lotteryActivities)
		{
			if (lotteryActivity.ActivityProgress(GameManagers.Instance).IsNew)
			{
				checkingActivities.Add(lotteryActivity.ActivityId);
			}
			foreach (KeyValuePair<string, ActivityContentPayload> contentPayloadKv in lotteryActivity.ContentPayload(GameManagers.Instance))
			{
				GameManagers.Instance.NewMsgIncomingManager.CheckActivityContent(lotteryActivity.ActivityId, contentPayloadKv.Key);
			}
		}
		GameManagers.Instance.ActivityManager.ReviewActivities(checkingActivities);
		UiTagManager uiTagManager = UiTagManager.Instance;
		for (int i = 0; i < CardLoader.cardList.numItems; i++)
		{
			object _cardData = ((GComponent)CardLoader.cardList).GetChildAt(i).data;
			if (_cardData != null)
			{
				int num;
				switch ((int)_cardData)
				{
				case 0:
				{
					UI_basisPool card = (UI_basisPool)(object)((GComponent)CardLoader.cardList).GetChildAt(i);
					uiTagManager.Register("LotteryPanel.FirstLotteryOption", card.singleBtn);
					uiTagManager.Register("LotteryPanel.SecondLotteryOption", card.runningBtn);
					continue;
				}
				case 5:
					num = (needAddNewbieGACHAActivityBtnForUiTagManager ? 1 : 0);
					break;
				default:
					num = 0;
					break;
				}
				if (num != 0)
				{
					UI_basisPool card2 = (UI_basisPool)(object)((GComponent)CardLoader.cardList).GetChildAt(i);
					uiTagManager.Register("LotteryPanel.NewbieLotteryOption", card2.runningBtn);
				}
			}
		}
		resultPanel = ((GComponent)ShowDrawResultPanel.resultList).GetChildAt(0) as UI_ResultCom;
		UpdateContractNote();
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
	}

	private void UpdateContractNote()
	{
		if (parentUi != null && parentUi is UI_BlackMarketerPanel)
		{
			((UI_BlackMarketerPanel)parentUi).UpdateItemCard(Name);
		}
	}

	private async Task<bool> GetDrawResult(LotteryActivityPayload optionPayload, string poolType)
	{
		Dictionary<string, int> ticketConfig;
		bool enough = optionPayload.CheckTicket(GameManagers.Instance, null, out ticketConfig);
		if (enough)
		{
			string activityId = optionPayload.Activity.ActivityId;
			string dynamicPoolId = null;
			activityIdToDynamicPoolId.TryGetValue(activityId, out dynamicPoolId);
			List<KeyValuePair<Bonus, int>> drawResult = await optionPayload.Draw(GameManagers.Instance, null, dynamicPoolId);
			awardList.Clear();
			FGUIManager.Instance.ContractPanel = this;
			newSoldierIdList.Clear();
			WaitingForOpenUiList.Clear();
			RepetitiveUiList.Clear();
			Shift.Legion.Common.Models.ActivityConfig activityProgress = optionPayload.Activity.ActivityProgress(GameManagers.Instance);
			activityProgress.Score += drawResult.Count;
			GameManagers.Instance.UserArchiveManager.SetActivityProgress(activityProgress);
			_finalClaimedBonus.Clear();
			List<string> proList = new List<string>();
			for (int i = 0; i < drawResult.Count; i++)
			{
				KeyValuePair<Bonus, int> bonusInfoKv = drawResult[i];
				Bonus bonus = bonusInfoKv.Key;
				awardList.Add(new KeyValuePair<Bonus, int>(bonus, bonusInfoKv.Value));
				proList.Add(bonus.ItemId);
				Dictionary<string, float> claimed = GetNewSoldiersId(bonus, i);
				foreach (KeyValuePair<string, float> kv in claimed)
				{
					if (!_finalClaimedBonus.TryGetValue(kv.Key, out var value))
					{
						value = 0f;
					}
					_finalClaimedBonus[kv.Key] = value + kv.Value;
				}
			}
			KeyValuePair<string, int> _costKeyValue = ticketConfig.First();
			int gemCost = 0;
			int chipCost = 0;
			if (_costKeyValue.Key == "Gem")
			{
				gemCost = _costKeyValue.Value;
			}
			else
			{
				chipCost = _costKeyValue.Value;
			}
			ThinkingDataHelper.Instance.GachaTrack(poolType, gemCost, chipCost, proList);
			if (activityId == CommonPool && activityProgress.Score == 1)
			{
				EventManager.LogEventOnFacebook(EventType.drawcard_first);
			}
		}
		else
		{
			CanNotDrawTip();
		}
		return enough;
	}

	private void UpdateDiamondNum()
	{
		((GObject)diamondAddBtn).visible = true;
		((GObject)diamondAddBtn.GetChild("num").asTextField).text = GameManagers.Instance.StockController.GetStock("Gem").ToString();
	}

	private void UpdateCouponNum(string itemId)
	{
		if (string.IsNullOrWhiteSpace(itemId))
		{
			((GObject)addCouponBtn).visible = false;
			return;
		}
		((GObject)addCouponBtn).visible = true;
		((GObject)addCouponBtn.GetChild("num").asTextField).text = GameManagers.Instance.StockController.GetStock(itemId).ShortNumberFormat();
	}

	private void UpdateTicketNum(string itemId)
	{
		if (string.IsNullOrWhiteSpace(itemId) || itemId == generalTicketId)
		{
			((GObject)addTicketBtn).visible = false;
			return;
		}
		((GObject)addTicketBtn).visible = true;
		((GObject)addTicketBtn.GetChild("num").asTextField).text = GameManagers.Instance.StockController.GetStock(itemId).ShortNumberFormat();
	}

	public void GetAllTarget()
	{
		targetList.Clear();
		for (int i = 0; i < 40; i++)
		{
			targetList.Add(mapLoader.component.GetChild($"target{i}").asButton);
		}
	}

	private void GetCards(int num)
	{
		_cardDataList.Clear();
		for (int i = 0; i < num; i++)
		{
			_cardDataList.Add(new KeyValuePair<int, string>(3, "S001"));
		}
	}

	private void GetDrawReward(EventContext context)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		GObject val = (GObject)context.sender;
		Activity activity = (Activity)val.data;
		GProgressBar progressBar = ((GObject)val.parent).asProgress;
		if (!activity.CanClaimBonus(GameManagers.Instance))
		{
			return;
		}
		if (activityIdToDynamicPoolId.TryGetValue(activity.ActivityId, out var value))
		{
			Task<ClaimDynamicCardPoolBonusResponse> task = GameController.Contexts.Service<INetworkService>().DynamicActivityClaim(value);
			task.GetAwaiter().OnCompleted(delegate
			{
				ClaimDynamicCardPoolBonusResponse result = task.Result;
				_postClaimProgressBonus(result.Result, result.ErrorCode, result.BonusList, result.Score, progressBar, activity);
			});
		}
		else
		{
			Task<ActivityClaimResponse> task2 = GameController.Contexts.Service<INetworkService>().ActivityClaim(activity.ActivityId);
			task2.GetAwaiter().OnCompleted(delegate
			{
				ActivityClaimResponse result = task2.Result;
				_postClaimProgressBonus(result.Result, result.ErrorCode, result.BonusList, result.Score, progressBar, activity);
			});
		}
	}

	private void GetDrawReward2(EventContext context)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		GObject val = (GObject)context.sender;
		Activity activity = (Activity)val.data;
		if (!activity.CanClaimBonus(GameManagers.Instance))
		{
			return;
		}
		Task<ActivityClaimResponse> task = GameController.Contexts.Service<INetworkService>().ActivityClaim(activity.ActivityId);
		task.GetAwaiter().OnCompleted(delegate
		{
			ActivityClaimResponse result = task.Result;
			if (result.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(result.ErrorCode);
			}
			else
			{
				List<ModelsBonus> bonusList = result.BonusList;
				if (bonusList == null || bonusList.Count < 0)
				{
					List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText174") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText175") };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder, arg3: false);
				}
				else
				{
					StockChangeRecord[] array = new StockChangeRecord[bonusList.Count];
					int num = 0;
					foreach (ModelsBonus item in bonusList)
					{
						array[num++] = new StockChangeRecord
						{
							ItemId = item.ItemId,
							Offset = item.Qty,
							Context = 4,
							ContextValue = activity.ActivityId,
							Type = 1
						};
					}
					GameManagers.Instance.StockController.ReadStockChangeRecords(array);
					string itemId = bonusList.First().ItemId;
					List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, itemId);
					Dictionary<string, int> dictionary = new Dictionary<string, int>();
					foreach (Modifier item2 in list)
					{
						if (item2.ModifierId == "Items")
						{
							foreach (KeyValuePair<string, object> item3 in item2.PayloadDictionary)
							{
								dictionary.Add(item3.Key, Convert.ToInt32(item3.Value));
							}
						}
					}
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_TakeItems.Name, new Dictionary<string, object>
					{
						{
							"Name",
							SchemaIndexHelper.GetNameById(GameManagers.Instance, itemId) ?? ""
						},
						{ "ShowSelectedReward", true },
						{
							"SelectItems",
							dictionary.ToList()
						},
						{ "NoClose", true },
						{ "SelectItemId", itemId }
					});
					float score = result.Score;
					Shift.Legion.Common.Models.ActivityConfig activityConfig = activity.ActivityProgress(GameManagers.Instance);
					activityConfig.Score = Convert.ToInt32(score);
					activityConfig.ClaimProgress = result.ClaimProgress;
					GameManagers.Instance.UserArchiveManager.SetActivityProgress(activityConfig);
					GetCardData();
				}
			}
		});
	}

	private void _postClaimProgressBonus(bool responseResult, int responseErrorCode, List<ModelsBonus> bonusList, float score, GProgressBar progressBar, Activity activity)
	{
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Unknown result type (might be due to invalid IL or missing references)
		//IL_0410: Expected O, but got Unknown
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Expected O, but got Unknown
		if (!responseResult)
		{
			ILRequestHelper.ShowErrorCode(responseErrorCode);
			return;
		}
		if (bonusList == null || bonusList.Count < 0)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText174") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText175") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder, arg3: false);
			return;
		}
		StockChangeRecord[] array = new StockChangeRecord[bonusList.Count];
		int num = 0;
		foreach (ModelsBonus bonus in bonusList)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = bonus.ItemId,
				Offset = bonus.Qty,
				Context = 4,
				ContextValue = activity.ActivityId,
				Type = 1
			};
		}
		GameManagers.Instance.StockController.ReadStockChangeRecords(array);
		string itemId = bonusList.First().ItemId;
		List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, itemId);
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (Modifier item in list)
		{
			if (!(item.ModifierId == "Items"))
			{
				continue;
			}
			foreach (KeyValuePair<string, object> item2 in item.PayloadDictionary)
			{
				dictionary.Add(item2.Key, Convert.ToInt32(item2.Value));
			}
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_TakeItems.Name, new Dictionary<string, object>
		{
			{
				"Name",
				SchemaIndexHelper.GetNameById(GameManagers.Instance, itemId) ?? ""
			},
			{ "ShowSelectedReward", true },
			{
				"SelectItems",
				dictionary.ToList()
			},
			{ "NoClose", true },
			{ "SelectItemId", itemId }
		});
		Shift.Legion.Common.Models.ActivityConfig activityConfig = activity.ActivityProgress(GameManagers.Instance);
		activityConfig.Score = Convert.ToInt32(score);
		GameManagers.Instance.UserArchiveManager.SetActivityProgress(activityConfig);
		if (score < activity.BonusProgress.First().Key)
		{
			((GComponent)progressBar).GetController("Tyep").selectedIndex = 0;
			((GComponent)progressBar).GetChild("sfxBack").visible = false;
			if (((GComponent)progressBar).GetTransition("BoxBreathing").playing)
			{
				((GComponent)progressBar).GetTransition("BoxBreathing").Stop();
				((GComponent)progressBar).GetChild("chest").SetScale(1f, 1f);
				((GComponent)progressBar).GetChild("sfxBack").SetScale(1f, 1f);
			}
			((GComponent)progressBar).GetChild("chest").onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(activity.BonusProgress.First().Value.First().Key, ((GObject)this).sortingOrder, noCheckBtn: true);
			});
		}
		else
		{
			((GComponent)progressBar).GetController("Tyep").selectedIndex = 1;
			FGUIManager.Instance.AddTextSpecialEffects(((GComponent)progressBar).GetChild("sfxBack").asGraph, "activated_fx", new Vector3(90f, 90f, 90f));
			soldierSpineGGraphs.Add(((GComponent)progressBar).GetChild("sfxBack").asGraph);
			((GComponent)progressBar).GetTransition("BoxBreathing").Play();
			((GComponent)progressBar).GetChild("chest").onClick.Set(new EventCallback1(GetDrawReward));
		}
		progressBar.TweenValue((double)score / (double)activity.BonusProgress.First().Key * 100.0, 0.5f);
		((GComponent)progressBar).GetChild("curNum").text = Convert.ToInt32(score).ToString();
		((GComponent)progressBar).GetChild("totalNum").text = Convert.ToInt32(activity.BonusProgress.First().Key).ToString();
	}

	private void SetBuildingName()
	{
		((GObject)TitleCom.buildingName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText168");
	}

	private void ShowHelpPanel()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		HelpPanel = UI_HelpPanel.CreateInstance();
		((GObject)HelpPanel.Mask).onClick.Add(new EventCallback0(CloseHelpPanel));
		((GComponent)GRoot.inst).AddChild((GObject)(object)HelpPanel);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)HelpPanel);
		FGUIManager.SetToFullScreen((GObject)(object)HelpPanel);
		HelpPanel.ShowDialog.Play();
	}

	private void CloseHelpPanel()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)HelpPanel.Mask).onClick.Remove(new EventCallback0(CloseHelpPanel));
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)HelpPanel, true);
	}

	public void ReturnPage0(bool resetPoolCard = false)
	{
		FGUIManager.Instance.StopNewSoldierUiIEnumerator();
		FGUIManager.Instance.ContractPanel = null;
		for (int i = 0; i < cardsList.Count; i++)
		{
			((GObject)cardsList[i]).alpha = 0f;
		}
		for (int j = 0; j < cardslocationList.numItems; j++)
		{
			((GComponent)cardslocationList).GetChildAt(j).alpha = 0f;
		}
		for (int k = 0; k < soldierAni.Count; k++)
		{
			((GObject)soldierAni[k]).displayObject.Dispose();
		}
		CardStageReset();
		CardHornReset();
		CardCannonReset();
		ClearAdvancedSfxs();
		pageController.selectedIndex = 0;
		((GObject)Help).alpha = 1f;
		((GObject)CardLoader).touchable = true;
		foreach (GGraph soldierSpineGGraph in soldierSpineGGraphs)
		{
			((GObject)soldierSpineGGraph).visible = true;
		}
		GetCardData();
		ResetSoftGuideClick();
	}

	private void StopSoftGuideClick()
	{
		if (_softGuideClick != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(_softGuideClick);
			_softGuideClick = null;
		}
		if (_guideFinger != null)
		{
			_guideFinger.CloseGuide();
			_guideFinger = null;
		}
	}

	private void ResetSoftGuideClick()
	{
		StopSoftGuideClick();
		if (!_shouldShowSoftGuide)
		{
			return;
		}
		for (int i = 0; i < CardLoader.cardList.numItems; i++)
		{
			UI_basisPool uI_basisPool = (UI_basisPool)(object)((GComponent)CardLoader.cardList).GetChildAt(i);
			int selectedIndex = uI_basisPool.CardType.selectedIndex;
			if (selectedIndex == 5)
			{
				break;
			}
			object data = ((GObject)uI_basisPool.runningBtn).data;
			if (data.GetType() == typeof(LotteryActivityPayload))
			{
				LotteryActivityPayload lotteryActivityPayload = (LotteryActivityPayload)data;
				if (lotteryActivityPayload.CheckTicket(GameManagers.Instance, null, out var _) && CanDrawNext(lotteryActivityPayload))
				{
					((MonoBehaviour)FGUIManager.Instance).StartCoroutine(SoftGuideClick(uI_basisPool.runningBtn, lotteryActivityPayload));
					break;
				}
			}
		}
	}

	private IEnumerator SoftGuideClick(UI_runningBtn btn, LotteryActivityPayload payload)
	{
		yield return (object)new WaitForSeconds(2f);
		if (((GObject)this).isDisposed)
		{
			yield break;
		}
		if (payload.CheckTicket(GameManagers.Instance, null, out var _))
		{
			if (_guideFinger != null)
			{
				_guideFinger.CloseGuide();
				_guideFinger = null;
			}
			_guideFinger = UI_GuideFinger.CreateInstance();
			_guideFinger.SoftGuideClick((GObject)(object)btn);
		}
		_softGuideClick = null;
	}

	private Dictionary<string, float> GetNewSoldiersId(Bonus bonus, int index)
	{
		Dictionary<string, float> dictionary = bonus.Claim(GameManagers.Instance, null, null, forceClaim: true, broadcastInform: false);
		if (GDMgr.Get<GDEItemData>(bonus.ItemId).ItemType == 10)
		{
			if (bonus.IsNewUnlock)
			{
				string value = "S" + bonus.ItemId.Substring(3);
				newSoldierIdList.Add(new KeyValuePair<int, string>(index, value));
				return dictionary;
			}
			foreach (KeyValuePair<string, float> item in dictionary)
			{
				if (item.Key.Contains("PotentialLevel"))
				{
					string value2 = "S" + bonus.ItemId.Substring(3);
					newSoldierIdList.Add(new KeyValuePair<int, string>(index, value2));
					break;
				}
			}
		}
		return dictionary;
	}

	private KeyValuePair<string, string> SetCastIconAndNum(List<KeyValuePair<string, int>> cost)
	{
		cost.Reverse();
		KeyValuePair<string, string> keyValuePair = default(KeyValuePair<string, string>);
		string text = "";
		string text2 = "";
		string text3 = "";
		if (cost.Count == 1)
		{
			text2 = cost[0].Key;
			text3 = cost[0].Value.ShortNumberFormat();
		}
		else
		{
			foreach (KeyValuePair<string, int> item in cost)
			{
				if (item.Key == "Gem")
				{
					text2 = item.Key;
					text3 = item.Value.ShortNumberFormat();
				}
				if (item.Key != "Gem" && GameManagers.Instance.StockController.GetStock(item.Key) >= item.Value)
				{
					text2 = item.Key;
					text3 = item.Value.ShortNumberFormat();
					break;
				}
			}
		}
		if (text2 != "Gem")
		{
			text = "x";
		}
		if (text2 != "GemTicket")
		{
			text2 = UiHelper.GetIcon(text2);
		}
		return new KeyValuePair<string, string>(text2, text + text3);
	}

	private void RenderAgainBtnCost(GButton button)
	{
		LotteryActivityPayload lotteryActivityPayload = (LotteryActivityPayload)((GObject)button).data;
		List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
		for (int i = 0; i < lotteryActivityPayload.Tickets.Count; i++)
		{
			foreach (KeyValuePair<string, int> item in lotteryActivityPayload.Tickets[i])
			{
				list.Add(new KeyValuePair<string, int>(item.Key, item.Value));
			}
		}
		KeyValuePair<string, string> keyValuePair = SetCastIconAndNum(list);
		((GComponent)button).GetChild("cost").text = keyValuePair.Value;
		((GComponent)button).GetChild("ticketIcon").asLoader.url = "ui://PublicResources/" + keyValuePair.Key;
	}

	private void RenderDrawPoolCard(int index, GObject obj)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_059b: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Expected O, but got Unknown
		//IL_0676: Unknown result type (might be due to invalid IL or missing references)
		//IL_0680: Expected O, but got Unknown
		//IL_060a: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f3: Expected O, but got Unknown
		//IL_0a83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8b: Expected O, but got Unknown
		//IL_0a90: Expected O, but got Unknown
		UI_basisPool uI_basisPool = (UI_basisPool)(object)obj.asCom;
		uI_basisPool.singleCost.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
		uI_basisPool.runningCost.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
		Activity activity = lotteryActivities[index];
		int num = int.Parse(activity.UiParams["Type"].ToString());
		if (ShouldShowGoldenTip(num))
		{
			_goldenTipCard = uI_basisPool;
		}
		if (ShouldShowHelpBtn(num))
		{
			int pageIndex = ((num == 6) ? 1 : 2);
			((GObject)uI_basisPool.Help).onClick.Set((EventCallback0)delegate
			{
				UnityUiService.Instance.OpenPanel(UI_HelpPanel2.Name, new Dictionary<string, object> { { "PageIndex", pageIndex } });
			});
		}
		if ((bool)((GObject)CardLoader.cardList).data)
		{
			uI_basisPool.CardType.selectedIndex = num;
			uI_basisPool.SetControllerPageText();
			if (uI_basisPool.CardType.selectedIndex == 2 || uI_basisPool.CardType.selectedIndex == 4 || uI_basisPool.CardType.selectedIndex == 1)
			{
				string uI = GDMgr.Get<GDEActivityData>(activity.ActivityId).UI;
				int num2 = activity.Data.UI.IndexOf(':');
				LotteryUiParams lotteryUiParams = JsonHelper.ToObject<LotteryUiParams>(uI.Substring(num2 + 1));
				if (lotteryUiParams.Soldiers.Count > 0)
				{
					Dictionary<string, string> soldiers = lotteryUiParams.Soldiers;
					if (soldiers != null)
					{
						if (soldiers.Count <= 1)
						{
							KeyValuePair<string, string> keyValuePair = soldiers.First();
							LoadSoldierOnCard((GButton)(object)uI_basisPool.QualifiedSoldierIconMiddle, keyValuePair.Key, keyValuePair.Value.ToString(), scaleDiy: true);
							springFestivalSoldiers.Add(keyValuePair.Key);
						}
						else
						{
							int num3 = 0;
							foreach (KeyValuePair<string, string> item in soldiers)
							{
								switch (num3)
								{
								case 0:
									LoadSoldierOnCard((GButton)(object)uI_basisPool.QualifiedSoldierIconUp, item.Key, item.Value.ToString());
									break;
								case 1:
									LoadSoldierOnCard((GButton)(object)uI_basisPool.QualifiedSoldierIconDown, item.Key, item.Value.ToString());
									break;
								}
								qualifiedSoldiers.Add(item.Key);
								num3++;
							}
						}
					}
				}
				if (timeCoroutine != null)
				{
					((MonoBehaviour)FGUIManager.Instance).StopCoroutine(timeCoroutine);
				}
				DateTimeOffset serverNow = DateTimeHelper.ServerNow;
				int num4 = 0;
				num4 = ((!activityIdToDynamicPoolId.TryGetValue(activity.ActivityId, out var _)) ? Convert.ToInt32(activity.CurRemainingTime(serverNow).TotalSeconds) : Convert.ToInt32(DateTimeHelper.GetDailyRefreshTime(serverNow, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours).AddDays(1.0).Subtract(serverNow)
					.TotalSeconds - 1800.0));
				((GObject)uI_basisPool.time).text = UiHelper.ParseTimeChinsesDH(num4) + LanguagesManager.GetDesc("CsharpCodeZhTcText176");
				if (timeCoroutine == null)
				{
					timeTextField = uI_basisPool.time;
					timeCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(RefreshTimeLimitRemaining(activity));
				}
			}
			else if (uI_basisPool.CardType.selectedIndex == 3 || uI_basisPool.CardType.selectedIndex == 1)
			{
				((GObject)uI_basisPool.time).text = LanguagesManager.GetDesc("CsharpCodeZhTcText177") + "：" + activity.Desc;
			}
		}
		if (uI_basisPool.CardType.selectedIndex == 1 || uI_basisPool.CardType.selectedIndex == 2 || uI_basisPool.CardType.selectedIndex == 3 || uI_basisPool.CardType.selectedIndex == 4)
		{
			if (activity.BonusProgress != null && activity.BonusProgress.Count > 0)
			{
				((GObject)uI_basisPool.ScoreProgress).visible = true;
				double num5 = activity.Score(GameManagers.Instance);
				double num6 = activity.BonusProgress.First().Key;
				((GProgressBar)uI_basisPool.ScoreProgress).value = (double)activity.Score(GameManagers.Instance) / (double)activity.BonusProgress.First().Key * 100.0;
				if (activity.Score(GameManagers.Instance) < activity.BonusProgress.First().Key)
				{
					uI_basisPool.ScoreProgress.Tyep.selectedIndex = 0;
					((GObject)uI_basisPool.ScoreProgress.sfxBack).visible = false;
					soldierSpineGGraphs.Add(uI_basisPool.ScoreProgress.sfxBack);
					((GObject)uI_basisPool.ScoreProgress.chest).onClick.Set((EventCallback0)delegate
					{
						FGUIManager.Instance.ItemTip(activity.BonusProgress.First().Value.First().Key, ((GObject)this).sortingOrder, noCheckBtn: true);
					});
				}
				else
				{
					uI_basisPool.ScoreProgress.Tyep.selectedIndex = 1;
					if (pageController.selectedIndex == 0)
					{
						((GObject)uI_basisPool.ScoreProgress.sfxBack).visible = true;
						FGUIManager.Instance.AddTextSpecialEffects(uI_basisPool.ScoreProgress.sfxBack, "activated_fx", new Vector3(90f, 90f, 90f));
						soldierSpineGGraphs.Add(uI_basisPool.ScoreProgress.sfxBack);
					}
					uI_basisPool.ScoreProgress.BoxBreathing.Play();
					((GObject)uI_basisPool.ScoreProgress.chest).data = activity;
					((GObject)uI_basisPool.ScoreProgress.chest).onClick.Set(new EventCallback1(GetDrawReward));
				}
				((GObject)uI_basisPool.ScoreProgress.curNum).text = Convert.ToInt32(activity.Score(GameManagers.Instance)).ToString();
				((GObject)uI_basisPool.ScoreProgress.totalNum).text = Convert.ToInt32(activity.BonusProgress.First().Key).ToString();
			}
			else
			{
				((GObject)uI_basisPool.ScoreProgress).visible = false;
			}
		}
		if (uI_basisPool.CardType.selectedIndex == 6 || uI_basisPool.CardType.selectedIndex == 7)
		{
			int score = activity.ActivityProgress(GameManagers.Instance).Score;
			int maxDrawCnt = (activity.ContentPayload(GameManagers.Instance).First().Value as LotteryActivityPayload).MaxDrawCnt;
			string richText = "ContractPanelRemainCountTip".ToLanguage();
			((GObject)uI_basisPool.drawCount).text = richText.Format(score, maxDrawCnt);
			uI_basisPool.StatusController.SetSelectedIndex((score >= maxDrawCnt) ? 1 : 0);
		}
		if (uI_basisPool.CardType.selectedIndex == 7)
		{
			RenderScoreProgressType7(uI_basisPool, activity);
		}
		((GObject)uI_basisPool).data = num;
		if (activity.GetStatus(GameManagers.Instance) != ActivityStatus.Disabled)
		{
			((GObject)uI_basisPool).enabled = true;
			Dictionary<string, ActivityContentPayload> dictionary = activity.ContentPayload(GameManagers.Instance);
			if (activity.ContentType != ActivityContentType.NewbieGACHA)
			{
				int num7 = 0;
				{
					EventCallback1 val = default(EventCallback1);
					foreach (KeyValuePair<string, ActivityContentPayload> item2 in dictionary)
					{
						string key = item2.Key;
						LotteryActivityPayload lotteryActivityPayload = (LotteryActivityPayload)item2.Value;
						List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
						for (int num8 = 0; num8 < lotteryActivityPayload.Tickets.Count; num8++)
						{
							foreach (KeyValuePair<string, int> item3 in lotteryActivityPayload.Tickets[num8])
							{
								list.Add(new KeyValuePair<string, int>(item3.Key, item3.Value));
								if (item3.Key != "Gem")
								{
									if (activity.Type == ActivityType.Lottery && activity.Period == ActivityPeriod.Permanent && generalTicketId == null)
									{
										generalTicketId = item3.Key;
									}
									else if (item3.Key != generalTicketId && specialTicketId == null)
									{
										specialTicketId = item3.Key;
									}
								}
							}
						}
						KeyValuePair<string, string> keyValuePair2 = SetCastIconAndNum(list);
						switch (num7)
						{
						case 0:
							((GObject)uI_basisPool.singleCost).text = keyValuePair2.Value;
							uI_basisPool.singleTicketIcon.url = "ui://PublicResources/" + keyValuePair2.Key;
							((GObject)uI_basisPool.singleBtn).data = lotteryActivityPayload;
							((GObject)uI_basisPool.singleBtn).onClick.Set(new EventCallback1(OnSingleClick));
							break;
						case 1:
						{
							((GObject)uI_basisPool.runningCost).text = keyValuePair2.Value;
							uI_basisPool.runningTicketIcon.url = "ui://PublicResources/" + keyValuePair2.Key;
							((GObject)uI_basisPool.runningBtn).data = lotteryActivityPayload;
							((GObject)uI_basisPool.runningBtn.note).visible = lotteryActivityPayload.CheckTicket(GameManagers.Instance, null, out var _);
							EventListener onClick = ((GObject)uI_basisPool.runningBtn).onClick;
							EventCallback1 obj2 = val;
							if (obj2 == null)
							{
								EventCallback1 val2 = delegate(EventContext context)
								{
									//IL_000c: Unknown result type (might be due to invalid IL or missing references)
									//IL_0016: Expected O, but got Unknown
									DrawBtnClickEvent((GButton)context.sender);
								};
								EventCallback1 val3 = val2;
								val = val2;
								obj2 = val3;
							}
							onClick.Set(obj2);
							break;
						}
						}
						num7++;
					}
					return;
				}
			}
			SetNewbieGACHACardClick(dictionary, uI_basisPool);
		}
		else
		{
			((GObject)uI_basisPool).enabled = false;
			if (activity.Period != ActivityPeriod.Permanent)
			{
				((GObject)uI_basisPool.time).text = LanguagesManager.GetDesc("CsharpCodeZhTcText21");
			}
		}
	}

	private void OnSingleClick(EventContext context)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		StopSoftGuideClick();
		GButton btn = (GButton)context.sender;
		if (((GObject)btn).grayed)
		{
			DrawBtnClickEvent(btn);
			return;
		}
		if (!GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1001").Contains("P110"))
		{
			DrawBtnClickEvent(btn);
			return;
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				"[size=50][color=#00FF33]                      " + LanguagesManager.GetDesc("CsharpCodeZhTcText178") + "[/color]\n[/size][size=7] [/size]\n" + LanguagesManager.GetDesc("CsharpCodeZhTcText179") + "2" + LanguagesManager.GetDesc("CsharpCodeZhTcText180") + "100%" + LanguagesManager.GetDesc("CsharpCodeZhTcText181") + "A" + LanguagesManager.GetDesc("CsharpCodeZhTcText182") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText183") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText184")
			},
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{
						"Confirm",
						delegate
						{
							DrawBtnClickEvent(btn);
						}
					},
					{ "Cancel", null }
				}
			},
			{ "PageIndex", 0 },
			{ "ClickSound", "Confirm" },
			{
				"Order",
				((GObject)this).sortingOrder
			}
		});
	}

	private IEnumerator RefreshTimeLimitRemaining(Activity activity)
	{
		while (true)
		{
			if (timeTextField != null && activity != null)
			{
				DateTimeOffset now = DateTimeHelper.ServerNow;
				string dynamicPoolId;
				int secondsToRefresh = ((!activityIdToDynamicPoolId.TryGetValue(activity.ActivityId, out dynamicPoolId)) ? Convert.ToInt32(activity.CurRemainingTime(now).TotalSeconds) : Convert.ToInt32(DateTimeHelper.GetDailyRefreshTime(now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours).AddDays(1.0).Subtract(now)
					.TotalSeconds - 1800.0));
				((GObject)timeTextField).text = UiHelper.ParseTimeChinsesDH(secondsToRefresh) + LanguagesManager.GetDesc("CsharpCodeZhTcText176");
				yield return (object)new WaitForSeconds(1f);
				dynamicPoolId = null;
			}
		}
	}

	private void LoadSoldierOnCard(GButton QualifiedSoldierIcon, string sid, string skinName, bool scaleDiy = false)
	{
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		GGraph spineBack = ((GComponent)QualifiedSoldierIcon).GetChild("spineBack").asGraph;
		if (((GObject)spineBack).data != null && (bool)((GObject)spineBack).data)
		{
			return;
		}
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		GameObject val = (GameObject)(object)((obj is GameObject) ? obj : null);
		SkeletonAnimation animation = ((val != null) ? val.GetComponent<SkeletonAnimation>() : null);
		SpawnManager.Instance.LoadSoldierSpine(val, sid + "_" + skinName, isMask: true).Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if ((Object)(object)asset != (Object)null && (Object)(object)animation != (Object)null && !((GObject)this).isDisposed)
			{
				((SkeletonRenderer)animation).skeletonDataAsset = asset;
				((SkeletonRenderer)animation).initialSkinName = skinName;
				((SkeletonRenderer)animation).Initialize(true);
				animation.AnimationState.AddAnimation(1, "idle", true, 0f);
				animation.timeScale = 0.2f;
				((GObject)spineBack).data = true;
			}
		});
		Vector3 soldierScale = default(Vector3);
		((Vector3)(ref soldierScale))._002Ector(40f, 40f, 40f);
		((GComponent)QualifiedSoldierIcon).GetController("Status").selectedIndex = GetSoldierInitPos(sid);
		if (scaleDiy)
		{
			soldierScale = GetSoldierScale(sid);
			if (soldierPosDic.ContainsKey(sid))
			{
				((GObject)spineBack).xy = soldierPosDic[sid];
			}
		}
		if ((Object)(object)val != (Object)null)
		{
			val.transform.localScale = soldierScale;
			val.transform.localPosition = -new Vector3(0f, 0f, 0f);
			val.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			GoWrapper val2 = new GoWrapper(val);
			((DisplayObject)val2).SetXY(0f, 0f);
			((DisplayObject)val2).pivot = new Vector2(0.5f, 0.5f);
			if (((GObject)QualifiedSoldierIcon).name == "QualifiedSoldierIconUp")
			{
				((DisplayObject)val2).scaleX = -1f;
			}
			else
			{
				((DisplayObject)val2).scaleX = 1f;
			}
			val2.supportStencil = true;
			spineBack.SetNativeObject((DisplayObject)(object)val2);
			soldierSpineGGraphs.Add(spineBack);
		}
	}

	private int GetSoldierInitPos(string sid)
	{
		return GameManagers.Instance.SoldierManager.GetSoldierFxSize(sid);
	}

	private Vector3 GetSoldierScale(string sid)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		int soldierFxSize = GameManagers.Instance.SoldierManager.GetSoldierFxSize(sid);
		Vector3 result = default(Vector3);
		((Vector3)(ref result))._002Ector(60f, 60f, 60f);
		switch (soldierFxSize)
		{
		case 0:
		case 1:
		case 2:
			((Vector3)(ref result))._002Ector(60f, 60f, 60f);
			break;
		case 3:
			((Vector3)(ref result))._002Ector(50f, 50f, 50f);
			break;
		}
		return result;
	}

	private void DrawBtnClickEvent(GButton btn)
	{
		StopSoftGuideClick();
		LotteryActivityPayload payload = (LotteryActivityPayload)((GObject)btn).data;
		if (!CanDrawNext(payload))
		{
			if (HasProgressReward(payload))
			{
				"ContractPanelDrawLimitTip2".ToLanguage().ToTip();
			}
			else
			{
				"ContractPanelDrawLimitTip".ToLanguage().ToTip();
			}
		}
		else if (!isDrawing)
		{
			isDrawing = true;
			Draw(btn);
		}
	}

	private void InitTicketsDisplay()
	{
		((GObject)diamondAddBtn).visible = false;
		((GObject)addCouponBtn).visible = false;
		((GObject)addTicketBtn).visible = false;
		diamondAddBtn.GetChild("diamond").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Gem");
		if (!string.IsNullOrWhiteSpace(generalTicketId))
		{
			addCouponBtn.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(generalTicketId);
		}
		if (!string.IsNullOrWhiteSpace(specialTicketId))
		{
			addTicketBtn.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(specialTicketId);
		}
	}

	public void CheckLotteryActivityStatus()
	{
		if (checkingLotteryActivityStatus)
		{
			return;
		}
		checkingLotteryActivityStatus = true;
		lotteryActivities.Clear();
		activityIdToDynamicPoolId.Clear();
		lotteryActivities = GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.Lottery);
		Task<GetDynamicCardPoolActivityResponse> task = GameController.Contexts.Service<INetworkService>().GetDynamicCardPoolActivities(-1L);
		task.GetAwaiter().OnCompleted(delegate
		{
			checkingLotteryActivityStatus = false;
			GetDynamicCardPoolActivityResponse result = task.Result;
			if (result != null)
			{
				if (!result.Result && result.ErrorCode != 10122009)
				{
					ILRequestHelper.ShowErrorCode(result.ErrorCode);
				}
				else if (!((GObject)this).isDisposed)
				{
					bool flag = GameManagers.Instance.UserArchiveManager.IsNewGuideMode5() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode5();
					bool flag2 = GameManagers.Instance.UserArchiveManager.IsNewGuideMode6() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode6();
					bool flag3 = GameManagers.Instance.UserArchiveManager.IsNewGuideMode7();
					if (result.DynamicCardPoolActivityData != null)
					{
						DynamicPoolInfo neutralCardPool = result.DynamicCardPoolActivityData.NeutralCardPool;
						string activityId = neutralCardPool.ActivityId;
						string templateId = neutralCardPool.TemplateId;
						if (!string.IsNullOrEmpty(templateId) && ActivityManager.Activities.TryGetValue(templateId, out var value))
						{
							lotteryActivities.Add(value);
							value.ActivityProgress(GameManagers.Instance).Score = neutralCardPool.Score;
							activityIdToDynamicPoolId[templateId] = activityId;
						}
						DynamicPoolInfo upCardPool = result.DynamicCardPoolActivityData.UpCardPool;
						string activityId2 = upCardPool.ActivityId;
						string templateId2 = upCardPool.TemplateId;
						if (!string.IsNullOrEmpty(templateId2) && ActivityManager.Activities.TryGetValue(templateId2, out var value2))
						{
							lotteryActivities.Add(value2);
							value2.ActivityProgress(GameManagers.Instance).Score = upCardPool.Score;
							activityIdToDynamicPoolId[templateId2] = activityId2;
						}
					}
					bool flag4 = false;
					int num = 3;
					Activity activity = null;
					for (int num2 = lotteryActivities.Count - 1; num2 >= 0; num2--)
					{
						Activity activity2 = lotteryActivities[num2];
						activity2.CheckStatus(GameManagers.Instance, out var newStatus, sendEvent: false);
						if (newStatus != ActivityStatus.Enabled)
						{
							lotteryActivities.RemoveAt(num2);
						}
						else
						{
							int item = int.Parse(activity2.UiParams["Type"].ToString());
							HashSet<int> hashSet = new HashSet<int> { 0, 6, 7 };
							if (hashSet.Contains(item) && activity2.ActivityId != CommonPool)
							{
								lotteryActivities.RemoveAt(num2);
							}
							else if (activity2.ContentType == ActivityContentType.NewbieGACHA)
							{
								string text = "NewbieGacha";
								if (flag)
								{
									text = "NewbieGacha5";
								}
								if (flag2 || flag3)
								{
									text = "NewbieGacha6";
								}
								if (activity2.ActivityId != text)
								{
									lotteryActivities.RemoveAt(num2);
								}
								else
								{
									Shift.Legion.Common.Models.ActivityConfig activityConfig = activity2.ActivityProgress(GameManagers.Instance);
									if (activityConfig.Progress.TryGetValue(NewbieGACHAActivityPayload.ProgressKey, out var value3))
									{
										if ((int)value3 == 3)
										{
											lotteryActivities.RemoveAt(num2);
										}
										else
										{
											activity = activity2;
											lotteryActivities.RemoveAt(num2);
										}
										num = (int)value3;
									}
									else
									{
										activity = activity2;
										lotteryActivities.RemoveAt(num2);
										num = 0;
									}
									flag4 = true;
								}
							}
						}
					}
					needAddNewbieGACHAActivityBtnForUiTagManager = num == 0;
					if (flag4 && !GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1002").Contains("P220"))
					{
						if (activity != null)
						{
							Dictionary<string, ActivityContentPayload> dictionary = activity.ContentPayload(GameManagers.Instance);
							newbieGACHAActivityPayload = (NewbieGACHAActivityPayload)dictionary.Values.ToList()[0];
							if (flag || flag2 || flag3)
							{
								lotteryActivities.Clear();
							}
							if (lotteryActivities.Count > 0)
							{
								lotteryActivities.Insert(1, activity);
							}
							else
							{
								lotteryActivities.Add(activity);
							}
						}
						ShowNewbieGACHAProgress(num);
					}
					if (!((GObject)this).isDisposed)
					{
						GetCardData(isInit: true);
						RefreshCommonPoolShowGoldenCardTip();
						ResetSoftGuideClick();
						if (postRenderingCardsCoroutine == null)
						{
							postRenderingCardsCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(PostRenderingCards());
						}
					}
				}
			}
		});
	}

	private void GetCardData(bool isInit = false)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		lotteryActivities.Sort(sortLotteryActivities);
		if (isInit)
		{
			soldierSpineGGraphs.Clear();
			qualifiedSoldiers.Clear();
			springFestivalSoldiers.Clear();
		}
		((GObject)CardLoader.cardList).data = isInit;
		CardLoader.cardList.itemRenderer = new ListItemRenderer(RenderDrawPoolCard);
		CardLoader.cardList.numItems = lotteryActivities.Count;
		InitTicketsDisplay();
		UpdateDiamondNum();
		UpdateCouponNum(generalTicketId);
		UpdateTicketNum(specialTicketId);
		if (isInit)
		{
			InitShouldShowSoftGuide();
		}
	}

	private void InitShouldShowSoftGuide()
	{
		_shouldShowSoftGuide = false;
		if (GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1003").Contains("P320"))
		{
			return;
		}
		GObject[] children = ((GComponent)CardLoader.cardList).GetChildren();
		foreach (GObject val in children)
		{
			UI_basisPool uI_basisPool = (UI_basisPool)(object)val;
			int selectedIndex = uI_basisPool.CardType.selectedIndex;
			if (selectedIndex == 6 || selectedIndex == 7)
			{
				_shouldShowSoftGuide = true;
				break;
			}
		}
	}

	private int sortLotteryActivities(Activity a, Activity b)
	{
		int num = int.Parse(a.UiParams["Type"].ToString());
		int num2 = int.Parse(b.UiParams["Type"].ToString());
		if (num == 0 || num == 6 || num == 7)
		{
			return -1;
		}
		if (num2 == 0)
		{
			return 1;
		}
		if (num == 5)
		{
			return -1;
		}
		if (num2 == 5)
		{
			return 1;
		}
		if (num == 4)
		{
			return -1;
		}
		if (num2 == 4)
		{
			return 1;
		}
		if (num == 2)
		{
			return -1;
		}
		if (num2 == 2)
		{
			return 1;
		}
		return 0;
	}

	private void JudgeTouchCard(Vector2 pos, bool isClick = false)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		if (cardAndPosrangeList.Count == 0)
		{
			return;
		}
		Vector2 val = ((GObject)GRoot.inst).GlobalToLocal(new Vector2(pos.x, pos.y));
		bool flag = false;
		for (int i = 0; i < cardAndPosrangeList.Count; i++)
		{
			if (cardAndPosrangeList[i].Value.Key.x < val.x && cardAndPosrangeList[i].Value.Value.x > val.x && cardAndPosrangeList[i].Value.Key.y < val.y && cardAndPosrangeList[i].Value.Value.y > val.y)
			{
				flag = true;
				if (isClick)
				{
					CardOverturn(i);
				}
				break;
			}
		}
		if (flag && !isClick)
		{
			for (int j = 0; j < awardList.Count; j++)
			{
				CardOverturn(j);
			}
		}
	}

	private void CardOverturn(int rewardIndex)
	{
		KeyValuePair<Bonus, int> keyValuePair = awardList[rewardIndex];
		Bonus key = keyValuePair.Key;
		int value = keyValuePair.Value;
		string itemId = key.ItemId;
		string text = "";
		string text2 = "";
		text2 = value switch
		{
			2 => "ui://avplaivdmxsj20", 
			1 => "ui://avplaivdvecsc", 
			_ => "ui://avplaivdoppx1k", 
		};
		bool flag = Shift.Legion.Common.Models.Item.ItemType(itemId) == 3;
		bool isNew = (key.IsNewUnlock ? true : false);
		int num = 0;
		List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, itemId);
		if (list[0].PayloadDictionary.TryGetValue("PotentialLevel", out var value2))
		{
			num = int.Parse(value2.ToString());
		}
		if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 3)
		{
			text2 = "ui://avplaivdldght5u";
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("title", SchemaIndexHelper.GetNameById(GameManagers.Instance, itemId));
		dictionary.Add("num", key.Qty);
		dictionary.Add("introduction", Shift.Legion.Common.Models.Item.PostScript(itemId));
		dictionary.Add("chipNote", flag);
		dictionary.Add("ItemId", itemId);
		dictionary.Add("PotentialLevel", num);
		dictionary.Add("IsShining", key.IsShining);
		PlayCardOverturn(cardAndPosrangeList[rewardIndex].Key, text2, isNew, dictionary);
	}

	private void SlideCard(EventContext context)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		bool isClick = context.type.Contains("onClick");
		JudgeTouchCard(context.inputEvent.position, isClick);
	}

	private void JudgShowAllCards()
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		if (--cardNum <= 0)
		{
			((GObject)slideFloor).touchable = false;
			((GObject)InterruptBack).touchable = true;
			((GObject)InterruptBack).onClick.Set(new EventCallback0(ShowDrawResult));
			((GObject)tip).text = LanguagesManager.GetDesc("CsharpCodeZhTcText169");
			((GObject)tip).visible = true;
			if (refundItems.Count > 0)
			{
				ReturnPopupInit();
			}
		}
	}

	private bool JudgeNewSoldierIdListContains(int index)
	{
		bool result = false;
		for (int i = 0; i < newSoldierIdList.Count; i++)
		{
			if (newSoldierIdList[i].Key == index)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	private void PlayCardOverturn(GButton button, string cardFront, bool isNew, Dictionary<string, object> dic, float delayTime = -1f)
	{
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		//IL_050c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0516: Expected O, but got Unknown
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Expected O, but got Unknown
		//IL_0481: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		if (!((GObject)button).touchable)
		{
			return;
		}
		((GObject)button).touchable = false;
		FGUIManager.Instance.OpenNewSoldierInterval = 0.8f;
		int portentilaLevel = (int)dic["PotentialLevel"];
		string _itemId = (string)dic["ItemId"];
		Soldier soldier = GameManagers.Instance.SoldierManager.Get("S" + _itemId.Substring(3));
		if (awardList.Count == 1)
		{
			Bonus firstBonus = awardList[0].Key;
			if (JudgeNewSoldierIdListContains(0))
			{
				WaitingForOpenUiList.Add(firstBonus);
			}
			else
			{
				((GComponent)(object)this).SetTimeout(1f).OnComplete((GTweenCallback)delegate
				{
					firstBonus.BroadcastInforms();
				});
			}
		}
		else
		{
			int childIndex = ((GComponent)cardslocationList).GetChildIndex((GObject)(object)button);
			Bonus bonus = awardList[childIndex].Key;
			if (JudgeNewSoldierIdListContains(childIndex))
			{
				WaitingForOpenUiList.Add(bonus);
			}
			else
			{
				((GComponent)(object)this).SetTimeout(1f).OnComplete((GTweenCallback)delegate
				{
					bonus.BroadcastInforms();
				});
			}
		}
		string text = "overturn0";
		switch ((int)dic["IsShining"])
		{
		case 2:
			text = "overturn2";
			break;
		case 1:
			text = "overturn1";
			break;
		}
		int materialItemType = Shift.Legion.Common.Models.Item.ItemType(_itemId);
		bool isQualified;
		if (materialItemType == 10 && qualifiedPool && qualifiedSoldiers.Contains("S" + _itemId.Substring(3)))
		{
			isQualified = true;
		}
		else if (materialItemType == 10 && springFestivalPool && springFestivalSoldiers.Contains("S" + _itemId.Substring(3)))
		{
			isQualified = true;
		}
		else
		{
			isQualified = false;
		}
		GoWrapper val2 = default(GoWrapper);
		((GComponent)button).GetTransition(text).Play((PlayCompleteCallback)delegate
		{
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			//IL_008f: Expected O, but got Unknown
			if (isNew)
			{
				((GObject)((GComponent)button).GetChild("newIcon").asImage).visible = true;
				((GComponent)button).GetTransition("bounce").Play();
			}
			if (isQualified)
			{
				((GComponent)button).GetTransition("ShowUpLogo").Play();
			}
			GTweener obj = ((GComponent)(object)this).SetTimeout(0.5f);
			GTweenCallback obj2 = val2;
			if (obj2 == null)
			{
				GTweenCallback val3 = delegate
				{
					JudgShowAllCards();
				};
				GTweenCallback val4 = val3;
				val2 = val3;
				obj2 = val4;
			}
			obj.OnComplete(obj2);
		});
		int _potentialLevel = (portentilaLevel + 2) / 2;
		GameObject canvasObject1 = null;
		if (materialItemType == 10)
		{
			canvasObject1 = (GameObject)Object.Instantiate(Resources.Load("SpineTest"));
			SkeletonAnimation animation = canvasObject1.GetComponent<SkeletonAnimation>();
			int potentialLevel = (portentilaLevel + 2) / 2;
			SpawnManager.Instance.LoadSoldierSpine(canvasObject1, $"{soldier.Id}_skin{potentialLevel}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
			{
				if ((Object)(object)animation != (Object)null && (Object)(object)asset != (Object)null && !((GObject)this).isDisposed)
				{
					((SkeletonRenderer)animation).skeletonDataAsset = asset;
					((SkeletonRenderer)animation).initialSkinName = $"skin{potentialLevel}";
					((SkeletonRenderer)animation).Initialize(true);
					animation.AnimationState.AddAnimation(1, "idle", true, 0f);
				}
			});
			Vector3 val = default(Vector3);
			if (soldier.Id == "S001" || soldier.Id == "S002" || soldier.Id == "S003" || soldier.Id == "S004" || soldier.Id == "S035" || soldier.Id == "S038")
			{
				((Vector3)(ref val))._002Ector(55f, 55f, 55f);
			}
			else
			{
				((Vector3)(ref val))._002Ector(40f, 40f, 40f);
			}
			canvasObject1.transform.localScale = val * 0.58f;
			canvasObject1.transform.localPosition = -new Vector3(0f, 0f, 0f);
			canvasObject1.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
		}
		((GComponent)button).GetTransition(text).SetHook("middle", (TransitionHook)delegate
		{
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Expected O, but got Unknown
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			((GObject)((GComponent)button).GetChild("icon").asLoader).SetScale(-1f, 1f);
			((GObject)button).icon = cardFront;
			GComponent component = ((GComponent)button).GetChild("icon").asLoader.component;
			if (materialItemType == 10)
			{
				component.GetChild("soldierGroup").visible = true;
				component.GetChild("chipContent").visible = false;
				component.GetChild("soldierName").text = soldier.Name;
				component.GetChild("soldierName").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
				component.GetChild("curLevel").asCom.GetController("Level").selectedIndex = portentilaLevel;
				val2 = new GoWrapper(canvasObject1);
				((DisplayObject)val2).SetXY(0f, 0f);
				((DisplayObject)val2).pivot = new Vector2(0.5f, 0.5f);
				component.GetChild("soldier").asGraph.SetNativeObject((DisplayObject)(object)val2);
				((GObject)component.GetChild("soldier").asGraph).SetXY(102f, 244f);
				soldierAni.Add(component.GetChild("soldier").asGraph);
			}
			else
			{
				component.GetController("Type").selectedIndex = _potentialLevel - 1;
				component.GetChild("SoldierName").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
				component.GetChild("SoldierName").text = soldier.Name;
				FGUIManager.Instance.SetItemIconAndFrame(component.GetChild("icon").asLoader, _itemId, textureList);
			}
		});
	}

	private void AgainBtnEvent(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		GButton val = (GButton)context.sender;
		LotteryActivityPayload payload = (LotteryActivityPayload)((GObject)val).data;
		if (!CanDrawNext(payload))
		{
			"ContractPanelDrawLimitTip".ToLanguage().ToTip();
			return;
		}
		((GObject)(GButton)context.sender).touchable = false;
		Draw((GButton)context.sender);
		((GObject)InterruptBack).onClick.Set(new EventCallback0(InterruptDrawAnimation));
	}

	private void ExitBtnEvent()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)InterruptBack).onClick.Set(new EventCallback0(InterruptDrawAnimation));
		ReturnPage0();
		((GObject)ShowDrawResultPanel).touchable = false;
		((GObject)ShowDrawResultPanel).alpha = 0f;
		((GComponent)ShowDrawResultPanel).GetChild("content10").y = ShowDrawResultPanelContentInitialPos.y;
		((GObject)ShowDrawResultPanel.content1).SetScale(0.25f, 0.25f);
		ShowDrawResultPanel.PageController.selectedIndex = 0;
		((GObject)ShowDrawResultPanel.mask).visible = false;
	}

	private void ShowDrawResult()
	{
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Expected O, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Expected O, but got Unknown
		if (refundItems.Count > 0)
		{
			return;
		}
		((GObject)InterruptBack).touchable = false;
		((GObject)tip).visible = false;
		((GObject)ShowDrawResultPanel).touchable = true;
		((GObject)ShowDrawResultPanel).alpha = 1f;
		((GObject)ShowDrawResultPanel.mask).visible = true;
		((GObject)ShowDrawResultPanel).sortingOrder = 0;
		((GObject)ShowDrawResultPanel.tip).visible = false;
		((GObject)diamondAddBtn).visible = true;
		((GObject)ShowDrawResultPanel.againBtn).touchable = true;
		((GObject)ShowDrawResultPanel.content1.againBtn).touchable = true;
		if (!string.IsNullOrWhiteSpace(specialTicketId) && specialTicketId != generalTicketId)
		{
			((GObject)addTicketBtn).visible = true;
		}
		else
		{
			((GObject)addTicketBtn).visible = false;
		}
		((GObject)addCouponBtn).visible = true;
		((GObject)diamondAddBtn).touchable = true;
		((GObject)addTicketBtn).touchable = true;
		((GObject)addCouponBtn).touchable = true;
		ClassifyDrawResult();
		if (awardList.Count > 1)
		{
			ShowDrawResultPanel.PageController.selectedIndex = 0;
			resultPanel.NewSoldierList.itemRenderer = new ListItemRenderer(RenderNewSoldierItem);
			resultPanel.NewSoldierList.numItems = newSoldierBonuses.Count;
			resultPanel.NewSoldierList.ResizeToFit(newSoldierBonuses.Count);
			if (resultPanel.NewSoldierList.numItems > 0)
			{
				GList newSoldierList = resultPanel.NewSoldierList;
				((GObject)newSoldierList).height = ((GObject)newSoldierList).height + 42f;
			}
			resultPanel.LevelUpList.itemRenderer = new ListItemRenderer(RenderLevelUpItem);
			resultPanel.LevelUpList.numItems = levelUpBonuses.Count;
			resultPanel.LevelUpList.ResizeToFit(levelUpBonuses.Count);
			if (resultPanel.LevelUpList.numItems > 0)
			{
				GList levelUpList = resultPanel.LevelUpList;
				((GObject)levelUpList).height = ((GObject)levelUpList).height + 42f;
			}
			resultPanel.DebrisList.itemRenderer = new ListItemRenderer(RenderDebrisItem);
			resultPanel.DebrisList.numItems = debrisBonuses.Count;
			resultPanel.DebrisList.ResizeToFit(debrisBonuses.Count);
			if (resultPanel.DebrisList.numItems > 0)
			{
				GList debrisList = resultPanel.DebrisList;
				((GObject)debrisList).height = ((GObject)debrisList).height + 42f;
			}
			((GComponent)ShowDrawResultPanel).GetTransition("showContent").Play();
			RenderAgainBtnCost((GButton)(object)ShowDrawResultPanel.againBtn);
		}
		else
		{
			ShowDrawResultPanel.PageController.selectedIndex = 1;
			ShowDrawResultPanel.content1.resultList.itemRenderer = new ListItemRenderer(RenderResultItem);
			ShowDrawResultPanel.content1.resultList.numItems = singleBonuses.Count;
			((GComponent)ShowDrawResultPanel).GetTransition("showContent1").Play();
			RenderAgainBtnCost((GButton)(object)ShowDrawResultPanel.content1.againBtn);
		}
	}

	private void ClassifyDrawResult()
	{
		List<KeyValuePair<string, float>> list = _finalClaimedBonus.ToList();
		for (int num = list.Count - 1; num >= 0; num--)
		{
			if (list[num].Key[0] == 'S' && list[num].Key.Length == 4)
			{
				list.RemoveAt(num);
			}
		}
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		for (int i = 0; i < list.Count; i++)
		{
			if (dictionary.ContainsKey(list[i].Key))
			{
				dictionary[list[i].Key] += list[i].Value;
			}
			else
			{
				dictionary.Add(list[i].Key, list[i].Value);
			}
		}
		if (awardList.Count > 1)
		{
			newSoldierBonuses.Clear();
			levelUpBonuses.Clear();
			debrisBonuses.Clear();
			List<KeyValuePair<string, float>> list2 = new List<KeyValuePair<string, float>>();
			List<KeyValuePair<string, float>> list3 = new List<KeyValuePair<string, float>>();
			List<KeyValuePair<string, float>> list4 = new List<KeyValuePair<string, float>>();
			foreach (KeyValuePair<string, float> item in dictionary)
			{
				if (item.Key.Contains("Unlock"))
				{
					list2.Add(item);
				}
				else if (item.Key.Contains("PotentialLevel"))
				{
					list3.Add(item);
				}
				else
				{
					list4.Add(item);
				}
			}
			IOrderedEnumerable<KeyValuePair<string, float>> collection = list2.OrderByDescending((KeyValuePair<string, float> bonus) => bonus.Value);
			newSoldierBonuses.AddRange(collection);
			IOrderedEnumerable<KeyValuePair<string, float>> collection2 = list3.OrderByDescending((KeyValuePair<string, float> bonus) => bonus.Value);
			levelUpBonuses.AddRange(collection2);
			IOrderedEnumerable<KeyValuePair<string, float>> collection3 = list4.OrderByDescending((KeyValuePair<string, float> bonus) => bonus.Value);
			debrisBonuses.AddRange(collection3);
			((GObject)resultPanel.separatedLine1).visible = false;
			((GObject)resultPanel.separatedLine2).visible = false;
			if (newSoldierBonuses.Count > 0 && levelUpBonuses.Count > 0 && debrisBonuses.Count > 0)
			{
				((GObject)resultPanel.separatedLine1).visible = true;
				((GObject)resultPanel.separatedLine2).visible = true;
			}
			else if (newSoldierBonuses.Count > 0 && levelUpBonuses.Count == 0 && debrisBonuses.Count > 0)
			{
				((GObject)resultPanel.separatedLine1).visible = true;
			}
			else if (newSoldierBonuses.Count == 0 && levelUpBonuses.Count > 0 && debrisBonuses.Count > 0)
			{
				((GObject)resultPanel.separatedLine2).visible = true;
			}
			else if (newSoldierBonuses.Count > 0 && levelUpBonuses.Count > 0 && debrisBonuses.Count == 0)
			{
				((GObject)resultPanel.separatedLine1).visible = true;
			}
			if (debrisBonuses.Count > 0)
			{
				((GObject)ShowDrawResultPanel.tip).visible = true;
			}
		}
		else
		{
			singleBonuses.Clear();
			singleBonuses.AddRange(dictionary);
		}
	}

	private void RenderResultItem(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		Controller controller = ((GComponent)asButton).GetController("PageController");
		string text = "";
		int level = 1;
		float num = 1f;
		((GComponent)asButton).GetChild("tip1").visible = false;
		string text2 = null;
		if (singleBonuses[index].Key.Contains("Unlock"))
		{
			controller.selectedIndex = 0;
			controller.selectedIndex = 0;
			string soldierId = singleBonuses[index].Key.Split('.')[1];
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
			text = soldier.Name;
			level = soldier.PotentialLevel;
			text2 = soldier.ItemId;
			RenderUnlockAndUpgradeItem(((GComponent)asButton).GetChild("icon").asLoader, text2, level, textureList);
		}
		else if (singleBonuses[index].Key.Contains("PotentialLevel"))
		{
			controller.selectedIndex = 2;
			string soldierId2 = singleBonuses[index].Key.Split('.')[1];
			Soldier soldier2 = GameManagers.Instance.SoldierManager.Get(soldierId2);
			text = soldier2.Name;
			level = soldier2.PotentialLevel;
			text2 = soldier2.ItemId;
			RenderUnlockAndUpgradeItem(((GComponent)asButton).GetChild("icon").asLoader, text2, level, textureList);
		}
		else
		{
			controller.selectedIndex = 1;
			text2 = singleBonuses[index].Key;
			text = SchemaIndexHelper.GetNameById(GameManagers.Instance, text2);
			num = singleBonuses[index].Value;
			foreach (KeyValuePair<string, float> singleBonuse in singleBonuses)
			{
				if (singleBonuse.Key.Contains("PotentialLevel"))
				{
					((GComponent)asButton).GetChild("tip1").visible = true;
					break;
				}
			}
			FGUIManager.Instance.SetItemIconAndFrame(((GComponent)asButton).GetChild("icon").asLoader, text2, textureList);
		}
		((GComponent)asButton).GetChild("name").text = text;
		((GComponent)asButton).GetChild("num").text = num.ToString();
		if (!singleBonuses[index].Key.Contains("Unlock") && !singleBonuses[index].Key.Contains("PotentialLevel"))
		{
			((GComponent)asButton).GetChild("icon").asLoader.fill = (FillType)1;
			((GComponent)asButton).GetChild("icon").asLoader.verticalAlign = (VertAlignType)0;
		}
		if (Shift.Legion.Common.Models.Item.ItemType(text2) == 10 && ((GComponent)asButton).GetChild("icon").asLoader.component != null)
		{
			GButton asButton2 = ((GObject)((GComponent)asButton).GetChild("icon").asLoader.component).asButton;
			FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)asButton2).GetChild("SoulStoneLevel").asCom, level, new List<int>());
			string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(level);
			((GComponent)asButton2).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
			UiHelper.LoadSoldierIconFrameMaterial(((GComponent)asButton2).GetChild("iconFrame").asLoader, level);
		}
	}

	private void RenderUnlockAndUpgradeItem(GLoader loader, string itemId, int level, List<string> textureList = null)
	{
		loader.url = "ui://kt6rg65ovv0ue7";
		if (loader.component != null)
		{
			GButton asButton = ((GObject)loader.component).asButton;
			((GComponent)asButton).GetChild("removeBack").visible = false;
			((GComponent)asButton).GetChild("lvFrame").visible = false;
			((GComponent)asButton).GetChild("assemblyNote").visible = false;
			((GComponent)asButton).GetChild("numNote").visible = false;
			((GComponent)asButton).GetChild("NumBack").visible = false;
			((GComponent)asButton).GetChild("removeNote").visible = false;
			((GComponent)asButton).GetChild("lv").visible = false;
			((GComponent)asButton).GetChild("num").visible = false;
			((GComponent)asButton).GetChild("classListCopy").visible = false;
			((GComponent)asButton).GetChild("classList").visible = false;
			((GComponent)asButton).GetChild("title").visible = false;
			((GComponent)asButton).GetChild("removeText").visible = false;
			((GComponent)asButton).GetChild("occupation").visible = false;
			((GComponent)asButton).GetChild("PotentialIcon").visible = false;
			Soldier soldier = GameManagers.Instance.SoldierManager.Get("S" + itemId.Substring(3));
			((GComponent)((GComponent)asButton).GetChild("racePicture").asButton).GetController("Type").selectedIndex = FGUIManager.Instance.GetRaceIcon(soldier.Faction);
			GObject child = ((GComponent)asButton).GetChild("icon");
			string iconPath = UiHelper.GetIconPath(itemId);
			child.asLoader.url = "ui://PublicResources/" + iconPath;
			string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(level);
			((GComponent)asButton).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
			UiHelper.LoadSoldierIconFrameMaterial(((GComponent)asButton).GetChild("iconFrame").asLoader, level);
			FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)asButton).GetChild("SoulStoneLevel").asCom, level, new List<int>());
		}
	}

	private void RenderNewSoldierItem(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		Controller controller = ((GComponent)asButton).GetController("PageController");
		string text = "";
		int num = 1;
		float num2 = 1f;
		controller.selectedIndex = 0;
		string soldierId = newSoldierBonuses[index].Key.Split('.')[1];
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
		text = soldier.Name;
		num = (int)newSoldierBonuses[index].Value;
		string itemId = soldier.ItemId;
		((GComponent)asButton).GetChild("name").text = text;
		((GComponent)asButton).GetChild("num").text = num2.ToString();
		RenderUnlockAndUpgradeItem(((GComponent)asButton).GetChild("icon").asLoader, itemId, num, textureList);
		if (((GComponent)asButton).GetChild("icon").asLoader.component != null)
		{
			GButton asButton2 = ((GObject)((GComponent)asButton).GetChild("icon").asLoader.component).asButton;
			FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)asButton2).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, new List<int>());
			string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
			((GComponent)asButton2).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
			UiHelper.LoadSoldierIconFrameMaterial(((GComponent)asButton2).GetChild("iconFrame").asLoader, soldier.PotentialLevel);
		}
	}

	private void RenderLevelUpItem(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		Controller controller = ((GComponent)asButton).GetController("PageController");
		string text = "";
		int num = 1;
		float num2 = 1f;
		controller.selectedIndex = 2;
		string soldierId = levelUpBonuses[index].Key.Split('.')[1];
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
		text = soldier.Name;
		num = (int)levelUpBonuses[index].Value;
		string itemId = soldier.ItemId;
		((GComponent)asButton).GetChild("name").text = text;
		((GComponent)asButton).GetChild("num").text = num2.ToString();
		RenderUnlockAndUpgradeItem(((GComponent)asButton).GetChild("icon").asLoader, itemId, num, textureList);
		if (((GComponent)asButton).GetChild("icon").asLoader.component != null)
		{
			GButton asButton2 = ((GObject)((GComponent)asButton).GetChild("icon").asLoader.component).asButton;
			FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)asButton2).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, new List<int>());
			string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
			((GComponent)asButton2).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
			UiHelper.LoadSoldierIconFrameMaterial(((GComponent)asButton2).GetChild("iconFrame").asLoader, soldier.PotentialLevel);
		}
	}

	private void RenderDebrisItem(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		Controller controller = ((GComponent)asButton).GetController("PageController");
		string text = "";
		int num = 1;
		float num2 = 1f;
		controller.selectedIndex = 1;
		string key = debrisBonuses[index].Key;
		text = SchemaIndexHelper.GetNameById(GameManagers.Instance, key);
		num2 = debrisBonuses[index].Value;
		((GComponent)asButton).GetChild("name").text = text;
		((GComponent)asButton).GetChild("num").text = num2.ToString();
		FGUIManager.Instance.SetItemIconAndFrame(((GComponent)asButton).GetChild("icon").asLoader, key, textureList);
		((GComponent)asButton).GetChild("icon").asLoader.fill = (FillType)1;
		((GComponent)asButton).GetChild("icon").asLoader.verticalAlign = (VertAlignType)0;
	}

	private void AddDiamond()
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
			}
		});
	}

	private void AddCoupon()
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
			}
		});
	}

	private void AddTicket()
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
			}
		});
	}

	public SkeletonAnimation LoadSkeleon(GGraph graph, string soldierId, float spineScale, int dir, string animationName)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		((GObject)graph).displayObject.Dispose();
		Object obj = Object.Instantiate(Resources.Load("SpineTest"));
		GameObject val = (GameObject)(object)((obj is GameObject) ? obj : null);
		SkeletonAnimation animation = ((val != null) ? val.GetComponent<SkeletonAnimation>() : null);
		SpawnManager.Instance.LoadAnimation(soldierId).Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if ((Object)(object)asset != (Object)null && (Object)(object)animation != (Object)null && !((GObject)this).isDisposed)
			{
				_spines.Add(soldierId);
				((SkeletonRenderer)animation).skeletonDataAsset = asset;
				((SkeletonRenderer)animation).Initialize(true);
				SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin_default");
				animation.AnimationState.AddAnimation(1, animationName, true, 0f);
				animation.timeScale = 1.5f;
			}
		});
		if ((Object)(object)val != (Object)null)
		{
			val.transform.localScale = new Vector3(spineScale, spineScale, spineScale);
			val.transform.localPosition = -new Vector3(0f, 0f, 0f);
			val.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			GoWrapper val2 = new GoWrapper(val);
			((DisplayObject)val2).SetXY(0f, 0f);
			((DisplayObject)val2).pivot = new Vector2(0.5f, 0.5f);
			((DisplayObject)val2).scaleX = dir;
			graph.SetNativeObject((DisplayObject)(object)val2);
		}
		return animation;
	}

	private UI_bullet Reload(int index, bool playReload = true)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		UI_bullet bullet = UI_bullet.CreateInstance_ILRuntime();
		((GComponent)batteryLucency).AddChild((GObject)(object)bullet);
		Vector2 xy = ((GComponent)batteryLucency).GetChild("point2").xy;
		((GObject)bullet).SetXY(xy.x, xy.y);
		if (!playReload)
		{
			((GObject)bullet).alpha = 0f;
			return bullet;
		}
		bullet.left_handed.Play(-1, 0f, (PlayCompleteCallback)null);
		GTweenCallback val = default(GTweenCallback);
		((GObject)bullet).TweenMove(((GObject)((GComponent)batteryLucency).GetChild("point1").asButton).xy, 0.25f).SetEase((EaseType)11).OnComplete((GTweenCallback)delegate
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0055: Expected O, but got Unknown
			GTweener obj = ((GObject)bullet).TweenMove(((GObject)((GComponent)batteryLucency).GetChild("point0").asButton).xy, 0.75f).SetEase((EaseType)11);
			GTweenCallback obj2 = val;
			if (obj2 == null)
			{
				GTweenCallback val2 = delegate
				{
					bullet.left_handed.Stop();
					if (index == 0)
					{
						((GObject)bullet).alpha = 1f;
					}
					else
					{
						((GObject)bullet).alpha = 0f;
					}
				};
				GTweenCallback val3 = val2;
				val = val2;
				obj2 = val3;
			}
			obj.OnComplete(obj2);
		});
		return bullet;
	}

	private void ShowRefundItems(Dictionary<string, int> _items)
	{
		if (_items.Count > 0)
		{
			refundItems = _items;
		}
	}

	private GComponent FindAddBtnByItemId(string _itemId)
	{
		if (_itemId == "Gem")
		{
			return diamondAddBtn;
		}
		if (_itemId == generalTicketId)
		{
			return addCouponBtn;
		}
		if (_itemId == specialTicketId)
		{
			return addTicketBtn;
		}
		return null;
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_053d: Unknown result type (might be due to invalid IL or missing references)
		int stock = GameManagers.Instance.StockController.GetStock(itemId);
		if (itemId == "Gem")
		{
			((GObject)diamondAddBtn.GetChild("num").asTextField).text = $"{stock}";
			int num = ((diamondAddBtn.GetChild("num").data != null) ? ((int)diamondAddBtn.GetChild("num").data) : stock);
			if (num != stock && stock > num)
			{
				int num2 = stock - num;
				if (NumFloatingGem == null)
				{
					NumFloatingGem = UI_ProductionNumFloating.CreateInstance_ILRuntime();
				}
				if (!((GObject)NumFloatingGem).onStage)
				{
					FGUIManager.Instance.AddNumFloatingForCouponBtn(NumFloatingGem, diamondAddBtn, stock - num);
				}
				else
				{
					((GObject)NumFloatingGem.Title).text = $"+{(int)((GObject)NumFloatingGem.Title).data + num2}";
					((GObject)NumFloatingGem.Title).data = (int)((GObject)NumFloatingGem.Title).data + num2;
				}
			}
			diamondAddBtn.GetChild("num").data = stock;
			diamondAddBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(diamondAddBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero);
			GetCardData();
		}
		else if (itemId == generalTicketId)
		{
			((GObject)addCouponBtn.GetChild("num").asTextField).text = stock.ShortNumberFormat() ?? "";
			int num3 = ((addCouponBtn.GetChild("num").data != null) ? ((int)addCouponBtn.GetChild("num").data) : stock);
			if (num3 != stock && stock > num3)
			{
				int num4 = stock - num3;
				if (NumFloatingGem1 == null)
				{
					NumFloatingGem1 = UI_ProductionNumFloating.CreateInstance_ILRuntime();
				}
				if (!((GObject)NumFloatingGem1).onStage)
				{
					FGUIManager.Instance.AddNumFloatingForCouponBtn(NumFloatingGem1, addCouponBtn, stock - num3);
				}
				else
				{
					((GObject)NumFloatingGem1.Title).text = $"+{(int)((GObject)NumFloatingGem1.Title).data + num4}";
					((GObject)NumFloatingGem1.Title).data = (int)((GObject)NumFloatingGem1.Title).data + num4;
				}
			}
			addCouponBtn.GetChild("num").data = stock;
			addCouponBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addCouponBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero);
			GetCardData();
		}
		else
		{
			if (!(itemId == specialTicketId))
			{
				return;
			}
			((GObject)addTicketBtn.GetChild("num").asTextField).text = stock.ShortNumberFormat() ?? "";
			int num5 = ((addTicketBtn.GetChild("num").data != null) ? ((int)addTicketBtn.GetChild("num").data) : stock);
			if (num5 != stock && stock > num5)
			{
				int num6 = stock - num5;
				if (NumFloatingGem2 == null)
				{
					NumFloatingGem2 = UI_ProductionNumFloating.CreateInstance_ILRuntime();
				}
				if (!((GObject)NumFloatingGem2).onStage)
				{
					FGUIManager.Instance.AddNumFloatingForCouponBtn(NumFloatingGem2, addTicketBtn, stock - num5);
				}
				else
				{
					((GObject)NumFloatingGem2.Title).text = $"+{(int)((GObject)NumFloatingGem2.Title).data + num6}";
					((GObject)NumFloatingGem2.Title).data = (int)((GObject)NumFloatingGem2.Title).data + num6;
				}
			}
			addTicketBtn.GetChild("num").data = stock;
			addTicketBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addTicketBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero);
			GetCardData();
		}
	}

	private void ReturnPopupInit()
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		ReturnItemsPopup = UI_ReturnItemsPopup.CreateInstance();
		((GObject)ReturnItemsPopup.Dialog).alpha = 1f;
		((GObject)ReturnItemsPopup.Mask).alpha = 1f;
		((GObject)ReturnItemsPopup.Dialog.SpineBack).visible = true;
		((GObject)ReturnItemsPopup.Dialog.n33).x = -100f;
		((GObject)ReturnItemsPopup.Dialog.n33).y = 312f;
		((GObject)ReturnItemsPopup.Dialog.SpineBack).x = 60f;
		((GObject)ReturnItemsPopup.Dialog.SpineBack).y = 466f;
		((GObject)ReturnItemsPopup.Dialog.receiveBtn).onClick.Add(new EventCallback0(PlayMissileSfx));
		((GComponent)GRoot.inst).AddChild((GObject)(object)ReturnItemsPopup);
		((GObject)ReturnItemsPopup).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)ReturnItemsPopup);
		string prefix;
		string text = FGUIManager.Instance.CutItemIdPrefix(refundItems.First().Key, out prefix);
		((GObject)ReturnItemsPopup).data = text;
		GComponent val = FindAddBtnByItemId(text);
		if (val != null)
		{
			val.GetChild("num").text = string.Format("{0}", (int)val.GetChild("num").data - refundItems.First().Value);
			((GObject)ReturnItemsPopup.missbleEndPos).SetXY(((GObject)val).x, 43f);
		}
		else
		{
			((GObject)ReturnItemsPopup.missbleEndPos).SetXY(1545f, 43f);
		}
		FGUIManager.Instance.SetItemIconAndFrame(ReturnItemsPopup.Dialog.Item.icon, text, textureList);
		((GObject)ReturnItemsPopup.Dialog.Item.num).text = $"{refundItems.First().Value}";
		SpineInit();
		ReturnItemsPopup.ShowDialog.Play();
		((GObject)diamondAddBtn).visible = true;
		((GObject)ShowDrawResultPanel.againBtn).touchable = true;
		((GObject)ShowDrawResultPanel.content1.againBtn).touchable = true;
		if (!string.IsNullOrWhiteSpace(specialTicketId) && specialTicketId != generalTicketId)
		{
			((GObject)addTicketBtn).visible = true;
		}
		else
		{
			((GObject)addTicketBtn).visible = false;
		}
		((GObject)addCouponBtn).visible = true;
		((GObject)diamondAddBtn).touchable = true;
		((GObject)addTicketBtn).touchable = true;
		((GObject)addCouponBtn).touchable = true;
	}

	private void CloseReturnPopup()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		OnStockChange(((GObject)ReturnItemsPopup).data.ToString(), 0, (StockInContext.AutoFill, ""));
		((GObject)ReturnItemsPopup.Dialog.receiveBtn).onClick.Remove(new EventCallback0(PlayMissileSfx));
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)ReturnItemsPopup, true);
		refundItems.Clear();
	}

	private void SpineInit()
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		GameObject canvasObject = default(GameObject);
		ref GameObject reference = ref canvasObject;
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		SpawnManager.Instance.LoadAnimation("Goblinworker_UI_001").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			toUnloadAni = true;
			if (ReturnItemsPopup != null && !((GObject)ReturnItemsPopup).isDisposed)
			{
				GameObject obj2 = canvasObject;
				SkeletonAnimation val2 = ((obj2 != null) ? obj2.GetComponent<SkeletonAnimation>() : null);
				if ((Object)(object)val2 != (Object)null && (Object)(object)asset != (Object)null)
				{
					((SkeletonRenderer)val2).skeletonDataAsset = asset;
					((SkeletonRenderer)val2).Initialize(true);
					SpineHelper.SetSkin((ISkeletonAnimation)(object)val2, "skin_fuben");
					val2.AnimationState.AddAnimation(0, "idle", true, 0f);
				}
			}
		});
		if ((Object)(object)canvasObject != (Object)null)
		{
			canvasObject.transform.localScale = new Vector3(130f, 130f, 130f);
			canvasObject.transform.localPosition = -new Vector3(0f, 0f, 0f);
			canvasObject.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			GoWrapper val = new GoWrapper(canvasObject);
			((DisplayObject)val).SetXY(0f, 0f);
			((DisplayObject)val).pivot = new Vector2(0.5f, 0.5f);
			((DisplayObject)val).scaleX = 1f;
			ReturnItemsPopup.Dialog.SpineBack.SetNativeObject((DisplayObject)(object)val);
		}
	}

	private void PlayMissileSfx()
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		((GObject)ReturnItemsPopup.Dialog).alpha = 0f;
		((GObject)ReturnItemsPopup.Dialog.SpineBack).visible = false;
		((GObject)ReturnItemsPopup.Mask).alpha = 0f;
		((GObject)ReturnItemsPopup.missibleSfxBack).SetPivot(0.5f, 0.5f, true);
		FGUIManager.Instance.AddTextSpecialEffects(ReturnItemsPopup.missibleSfxBack, "exp_missile_green", Vector3.zero);
		((GObject)ReturnItemsPopup.missibleSfxBack).TweenMove(((GObject)ReturnItemsPopup.missbleEndPos).xy, 0.5f);
		UiAudioManager.Instance.PlaySoundEffect("Missile");
		((GComponent)(object)this).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
		{
			CloseReturnPopup();
		});
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		string[] array = _spines.ToArray();
		string[] array2 = array;
		foreach (string model in array2)
		{
			SpawnManager.Instance.UnloadAnimation(model);
		}
		if (toUnloadAni)
		{
			SpawnManager.Instance.UnloadAnimation("Goblinworker_UI_001");
		}
		FGUIManager.Instance.StopNewSoldierUiIEnumerator();
		FGUIManager.Instance.ContractPanel = null;
	}

	private void CardsLocationListItemRenderer(int index, GObject obj)
	{
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Expected O, but got Unknown
		GButton button = obj.asButton;
		((GObject)button).touchable = true;
		((GObject)button).alpha = 0f;
		if (awardList.Count != 0)
		{
			Bonus key = awardList[index].Key;
			string itemId = key.ItemId;
			string url;
			string frontUrl;
			switch (key.IsShining)
			{
			case 2:
				url = "ui://avplaivdmxsj21";
				frontUrl = "ui://avplaivdmxsj20";
				break;
			case 1:
				url = "ui://avplaivdvecsb";
				frontUrl = "ui://avplaivdvecsc";
				break;
			default:
				url = "ui://avplaivdoppx1l";
				frontUrl = "ui://avplaivdoppx1k";
				break;
			}
			bool flag = Shift.Legion.Common.Models.Item.ItemType(itemId) == 3;
			bool showNewIcon = key.IsNewUnlock;
			int num = 0;
			List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, itemId);
			if (list[0].PayloadDictionary.TryGetValue("PotentialLevel", out var value))
			{
				num = int.Parse(value.ToString());
			}
			((GComponent)button).GetChild("icon").asLoader.fill = (FillType)1;
			int num2 = (num + 2) / 2;
			if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 3)
			{
				url = "ui://avplaivdldght5t";
				frontUrl = "ui://avplaivdldght5u";
				((GComponent)button).GetChild("icon").asLoader.fill = (FillType)0;
			}
			((GComponent)button).GetChild("icon").asLoader.url = url;
			((GObject)((GComponent)button).GetChild("newIcon").asImage).visible = false;
			((GObject)((GComponent)button).GetChild("upLogo").asImage).visible = false;
			((GObject)button).SetScale(1f, 1f);
			((GObject)((GComponent)button).GetChild("icon").asLoader).SetScale(1f, 1f);
			if (num2 < 3 && Shift.Legion.Common.Models.Item.ItemType(itemId) == 3)
			{
				((GComponent)button).GetChild("icon").asLoader.component.GetController("Type").selectedIndex = num2 - 1;
			}
			Dictionary<string, object> dic = new Dictionary<string, object>
			{
				{
					"title",
					SchemaIndexHelper.GetNameById(GameManagers.Instance, itemId) ?? ""
				},
				{ "num", key.Qty },
				{
					"introduction",
					Shift.Legion.Common.Models.Item.PostScript(itemId) ?? ""
				},
				{ "chipNote", flag },
				{ "ItemId", itemId },
				{ "IsShining", key.IsShining },
				{ "PotentialLevel", num }
			};
			((GObject)button).onClick.Set((EventCallback0)delegate
			{
				PlayCardOverturn(button, frontUrl, showNewIcon, dic);
			});
		}
	}

	public bool JudgeAnimationPlaying()
	{
		bool result = false;
		if (awardList.Count == 1)
		{
			result = ((GComponent)singleCard).GetTransition("overturn0").playing || ((GComponent)singleCard).GetTransition("overturn1").playing || ((GComponent)singleCard).GetTransition("overturn2").playing;
		}
		else
		{
			for (int i = 0; i < cardslocationList.numItems; i++)
			{
				if (((GComponent)((GComponent)cardslocationList).GetChildAt(i).asButton).GetTransition("overturn0").playing || ((GComponent)((GComponent)cardslocationList).GetChildAt(i).asButton).GetTransition("overturn1").playing || ((GComponent)((GComponent)cardslocationList).GetChildAt(i).asButton).GetTransition("overturn2").playing)
				{
					result = true;
					break;
				}
				if (i == cardslocationList.numItems - 1)
				{
					result = false;
				}
			}
		}
		return result;
	}

	public void InterruptDrawAnimation()
	{
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Expected O, but got Unknown
		((GObject)InterruptBack).touchable = false;
		needBreakDrawAnimation = true;
		if (showTitleGroup.playing)
		{
			showTitleGroup.Stop(true, true);
			foreach (GGraph soldierSpineGGraph in soldierSpineGGraphs)
			{
				((GObject)soldierSpineGGraph).visible = false;
			}
		}
		if (!needShowNewbieContent)
		{
			CardCannonSkip();
			CardStageAnimationSkip();
		}
		else
		{
			CardStageInitForNewbie();
		}
		CardHornAnimationSkip();
		for (int num = CreatBullet.Count - 1; num >= 0; num--)
		{
			FGUIManager.Instance.CloseIEnumerator(CreatBullet[num]);
		}
		CreatBullet.Clear();
		for (int num2 = SetBulletPath.Count - 1; num2 >= 0; num2--)
		{
			FGUIManager.Instance.CloseIEnumerator(SetBulletPath[num2]);
		}
		SetBulletPath.Clear();
		for (int num3 = bullets.Count - 1; num3 >= 0; num3--)
		{
			if (bullets[num3] != null)
			{
				((GObject)bullets[num3]).Dispose();
			}
		}
		bullets.Clear();
		pageController.selectedIndex = 2;
		((GObject)diamondAddBtn).visible = false;
		((GObject)addTicketBtn).visible = false;
		((GObject)addCouponBtn).visible = false;
		if (awardList.Count > 1)
		{
			((GObject)tip).text = LanguagesManager.GetDesc("CsharpCodeZhTcText185") + " " + LanguagesManager.GetDesc("CsharpCodeZhTcText186");
			((GObject)tip).visible = true;
		}
		if (cannonMoveY != null)
		{
			cannonMoveY.Kill(true);
			cannonMoveY = null;
		}
		if (mainCurtainMoveX != null)
		{
			mainCurtainMoveX.Kill(false);
			mainCurtainMoveX = null;
		}
		if (CannonMoveCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(CannonMoveCoroutine);
			CannonMoveCoroutine = null;
		}
		if (mainCurtainMoveCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(mainCurtainMoveCoroutine);
			mainCurtainMoveCoroutine = null;
		}
		UiAudioManager.Instance.StopSoundEffect();
		for (int num4 = cardsList.Count - 1; num4 >= 0; num4--)
		{
			((GObject)cardsList[num4]).Dispose();
		}
		cardsList.Clear();
		for (int num5 = cardsCache.Count - 1; num5 >= 0; num5--)
		{
			((GObject)cardsCache[num5]).Dispose();
		}
		cardsCache.Clear();
		for (int num6 = workerList.Count - 1; num6 >= 0; num6--)
		{
			((GObject)workerList[num6].Key).Dispose();
		}
		workerList.Clear();
		for (int num7 = workersCache.Count - 1; num7 >= 0; num7--)
		{
			((GObject)workersCache[num7]).Dispose();
		}
		workersCache.Clear();
		if (ShowCardCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(ShowCardCoroutine);
			ShowCardCoroutine = null;
		}
		for (int num8 = SetWorkerAndCardPaths.Count - 1; num8 >= 0; num8--)
		{
			FGUIManager.Instance.CloseIEnumerator(SetWorkerAndCardPaths[num8]);
		}
		SetWorkerAndCardPaths.Clear();
		((GObject)InterruptBack).TweenFade(((GObject)InterruptBack).alpha, 0.5f).OnComplete((GTweenCallback)delegate
		{
			if (!needShowNewbieContent)
			{
				SetCards(awardList.Count);
			}
		});
		RookiePoolBackground.Stop();
	}

	private void CanNotDrawTip()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				"    " + LanguagesManager.GetDesc("CsharpCodeZhTcText187") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText188") + "？"
			},
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{
						"Confirm",
						delegate
						{
							if (pageController.selectedIndex == 2)
							{
								((GObject)ShowDrawResultPanel.againBtn).touchable = true;
								((GObject)ShowDrawResultPanel.content1.againBtn).touchable = true;
							}
							GameController.Contexts.Service<IUiService>().OpenPanel(UI_BlackMarketerAddCredit.Name, new Dictionary<string, object>
							{
								{
									"Activity",
									FGUIManager.Instance.GetBlackMarketerActivity("UI_BlackMarketerAddCredit")
								},
								{
									"Order",
									((GObject)this).sortingOrder
								}
							});
						}
					},
					{ "Cancel", null }
				}
			},
			{ "PageIndex", 4 },
			{ "ClickSound", "Confirm" },
			{
				"Order",
				((GObject)this).sortingOrder
			}
		});
	}

	private async Task Draw(GButton btn)
	{
		LotteryActivityPayload optionPayload = (LotteryActivityPayload)((GObject)btn).data;
		int uiType = int.Parse(optionPayload.Activity.UiParams["Type"].ToString());
		qualifiedPool = false;
		springFestivalPool = false;
		switch (uiType)
		{
		case 2:
			qualifiedPool = true;
			break;
		case 4:
			springFestivalPool = true;
			break;
		}
		string poolType = uiType switch
		{
			0 => "常驻", 
			2 => "UP", 
			4 => "中立", 
			5 => "新手", 
			_ => "其他", 
		};
		_ = ((GObject)btn).parent.baseUserData;
		int _uiNotTouchableIndex = GameController.Contexts.Service<IUiService>().SetUiNotTouchable(Name);
		if (pageController.selectedIndex == 0)
		{
			if (await GetDrawResult(optionPayload, poolType))
			{
				UpdateContractNote();
				pageController.selectedIndex = 1;
				showTitleGroup.PlayReverse();
				foreach (GGraph itemGraph in soldierSpineGGraphs)
				{
					((GObject)itemGraph).visible = false;
				}
				((GObject)CardLoader).touchable = false;
				((GObject)InterruptBack).touchable = true;
				((GObject)backBtn).touchable = false;
				((GObject)TitleCom).touchable = false;
				((GObject)Help).touchable = false;
				((GObject)diamondAddBtn).touchable = false;
				((GObject)addCouponBtn).touchable = false;
				((GObject)addTicketBtn).touchable = false;
				needBreakDrawAnimation = false;
				bullets.Clear();
				CreatBullet.Clear();
				SetBulletPath.Clear();
				SetWorkerAndCardPaths.Clear();
				ClearAdvancedSfxs();
				((GObject)ShowDrawResultPanel.againBtn).data = optionPayload;
				((GObject)ShowDrawResultPanel.content1.againBtn).data = optionPayload;
				((GObject)ShowDrawResultPanel.againBtn).grayed = !CanDrawNext(optionPayload);
				((GObject)ShowDrawResultPanel.content1.againBtn).grayed = !CanDrawNext(optionPayload);
				CardStagOpen();
				ScriptApi.CreateTimer(1.5f, delegate
				{
					Fire(awardList.Count);
					isDrawing = false;
					GameController.Contexts.Service<IUiService>().SetUiTouchable(_uiNotTouchableIndex);
				});
			}
			else
			{
				isDrawing = false;
				GameController.Contexts.Service<IUiService>().SetUiTouchable(_uiNotTouchableIndex);
			}
		}
		else if (pageController.selectedIndex == 2)
		{
			if (await GetDrawResult(optionPayload, poolType))
			{
				UpdateContractNote();
				((GObject)ShowDrawResultPanel).touchable = false;
				((GObject)ShowDrawResultPanel).alpha = 0f;
				((GComponent)ShowDrawResultPanel).GetChild("content10").y = ShowDrawResultPanelContentInitialPos.y;
				((GObject)ShowDrawResultPanel.content1).SetScale(0.25f, 0.25f);
				ShowDrawResultPanel.PageController.selectedIndex = 0;
				((GObject)ShowDrawResultPanel.mask).visible = false;
				foreach (GGraph itemGraph2 in soldierSpineGGraphs)
				{
					((GObject)itemGraph2).visible = false;
				}
				for (int i = 0; i < soldierAni.Count; i++)
				{
					((GObject)soldierAni[i]).displayObject.Dispose();
				}
				((GObject)diamondAddBtn).touchable = false;
				((GObject)addTicketBtn).touchable = false;
				((GObject)addCouponBtn).touchable = false;
				((GObject)diamondAddBtn).visible = false;
				((GObject)addTicketBtn).visible = false;
				((GObject)addCouponBtn).visible = false;
				((GObject)InterruptBack).touchable = true;
				needBreakDrawAnimation = false;
				bullets.Clear();
				CreatBullet.Clear();
				SetBulletPath.Clear();
				SetWorkerAndCardPaths.Clear();
				ClearAdvancedSfxs();
				ShowCards(awardList.Count);
				isDrawing = false;
				((GObject)ShowDrawResultPanel.againBtn).grayed = !CanDrawNext(optionPayload);
				((GObject)ShowDrawResultPanel.content1.againBtn).grayed = !CanDrawNext(optionPayload);
			}
			else
			{
				isDrawing = false;
			}
			GameController.Contexts.Service<IUiService>().SetUiTouchable(_uiNotTouchableIndex);
		}
		RefreshCommonPoolShowGoldenCardTip();
	}

	private static bool ShouldShowGoldenTip(int uiType)
	{
		return uiType == 6;
	}

	private static bool ShouldShowHelpBtn(int uiType)
	{
		return uiType == 6 || uiType == 7;
	}

	private static bool CanDrawNext(LotteryActivityPayload payload)
	{
		int score = payload.Activity.ActivityProgress(GameManagers.Instance).Score;
		int maxDrawCnt = payload.MaxDrawCnt;
		if (maxDrawCnt <= 0)
		{
			return true;
		}
		return score < maxDrawCnt;
	}

	private static bool HasProgressReward(LotteryActivityPayload payload)
	{
		Activity activity = payload.Activity;
		Shift.Legion.Common.Models.ActivityConfig activityConfig = activity.ActivityProgress(GameManagers.Instance);
		int num = payload.Activity.BonusProgressList?.Count ?? 0;
		int num2 = activityConfig.ClaimProgress?.Count ?? 0;
		return num > num2;
	}

	private void ClearAdvancedSfxs()
	{
		for (int num = advancedSfxs.Count - 1; num >= 0; num--)
		{
			Object.Destroy((Object)(object)advancedSfxs[num]);
		}
		advancedSfxs.Clear();
	}

	private void RenderCardsLocationList(int num)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		SwipeGestureList.Clear();
		cardslocationList.itemRenderer = new ListItemRenderer(CardsLocationListItemRenderer);
		cardslocationList.numItems = num;
		UiTagManager instance = UiTagManager.Instance;
		object obj = instance.FindObjectByTag("LotteryPanel.FirstLotteryResult");
		if (obj != null)
		{
			instance.Unregister("LotteryPanel.FirstLotteryResult", obj);
		}
		object obj2 = instance.FindObjectByTag("LotteryPanel.SecondLotteryResult");
		if (obj2 != null)
		{
			instance.Unregister("LotteryPanel.SecondLotteryResult", obj2);
		}
	}

	private GButton GetCardForAnimation(int index, int length, out Vector2 pos)
	{
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		GButton val = null;
		for (int i = 0; i < cardsList.Count; i++)
		{
			((GObject)cardsList[i]).alpha = 0f;
		}
		if (cardsList.Count != 0)
		{
			val = cardsList[0];
			cardsList.RemoveAt(0);
			CardsLocationListItemRenderer(index, (GObject)(object)val);
		}
		else
		{
			UI_cardLoaderBtn uI_cardLoaderBtn = UI_cardLoaderBtn.CreateInstance();
			((GComponent)GRoot.inst).AddChild((GObject)(object)uI_cardLoaderBtn);
			val = (GButton)(object)uI_cardLoaderBtn;
			CardsLocationListItemRenderer(index, (GObject)(object)val);
		}
		if (length == 1)
		{
			pos = ((GObject)cardslocationList).TransformPoint(new Vector2(((GObject)cardslocationList).width / 2f, ((GObject)cardslocationList).height / 2f), (GObject)(object)batteryLucency);
			singleCard = val;
		}
		else
		{
			pos = ((GComponent)cardslocationList).GetChildAt(index).TransformPoint(new Vector2(((GComponent)cardslocationList).GetChildAt(index).width / 2f, ((GComponent)cardslocationList).GetChildAt(index).height / 2f), (GObject)(object)batteryLucency);
			GButton asButton = ((GComponent)cardslocationList).GetChildAt(index).asButton;
			((GObject)asButton).SetPivot(0f, 0f);
			Vector2 val2 = ((GObject)asButton).LocalToRoot(new Vector2(0f, 0f), GRoot.inst);
			cardAndPosrangeList.Add(new KeyValuePair<GButton, KeyValuePair<Vector2, Vector2>>(asButton, new KeyValuePair<Vector2, Vector2>(val2, val2 + new Vector2(((GObject)asButton).width, ((GObject)asButton).height))));
			((GObject)asButton).SetPivot(0.5f, 0.5f);
		}
		((GObject)val).alpha = 0f;
		((GObject)val).SetScale(0.5f, 0.5f);
		((GObject)val).SetPivot(0.5f, 0.5f, true);
		((GObject)val).touchable = false;
		((GObject)((GComponent)val).GetChild("icon").asLoader).SetScale(1f, 1f);
		return val;
	}

	private void Fire(int length)
	{
		if (((GObject)InterruptBack).touchable)
		{
			GetAllTarget();
			CardCannonOpen();
			float num = 0.45f;
			for (int i = 0; i < length; i++)
			{
				int num2 = i;
				UI_bullet bullet = null;
				CreatBullet.Add(((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetABullet(bullet, num2, 0.125f * (float)i)));
				SetBulletPath.Add(((MonoBehaviour)FGUIManager.Instance).StartCoroutine(SetABulletPath(num2, 0.5f + num)));
				num += 0.5f;
			}
			CannonMoveCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(CannonMove(num + 2.5f));
			mainCurtainMoveCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(MainCurtainMove(num + 2.5f));
		}
	}

	public void SetCards(int length)
	{
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		if (NewbieGACHADrawResult != null && NewbieGACHADrawResult.Count > 0)
		{
			RookiePoolContent.SkipAndShowImmediately(NewbieGACHADrawResult, this);
			return;
		}
		RenderCardsLocationList(length);
		for (int i = 0; i < cardslocationList.numItems; i++)
		{
			((GComponent)cardslocationList).GetChildAt(i).touchable = true;
		}
		((GObject)cardslocationList).touchable = false;
		cardNum = ((length > 10) ? 10 : length);
		cardsCache.Clear();
		workersCache.Clear();
		cardAndPosrangeList.Clear();
		for (int j = 0; j < length; j++)
		{
			int num = j;
			Vector2 pos;
			GButton cardForAnimation = GetCardForAnimation(num, length, out pos);
			if (length == 1)
			{
				SingleFakeCard = cardForAnimation;
			}
			((GComponent)batteryLucency).AddChild((GObject)(object)cardForAnimation);
			((GObject)cardForAnimation).alpha = 1f;
			((GObject)cardForAnimation).SetXY(pos.x, pos.y);
			((GObject)cardForAnimation).SetScale(1f, 1f);
			if (length > 1)
			{
				((GObject)((GComponent)cardslocationList).GetChildAt(num).asButton).alpha = 1f;
			}
			if (length == 1)
			{
				Vector2 val = ((GObject)cardForAnimation).LocalToRoot(new Vector2(0.5f, 0.5f), GRoot.inst);
				cardAndPosrangeList.Add(new KeyValuePair<GButton, KeyValuePair<Vector2, Vector2>>(cardForAnimation, new KeyValuePair<Vector2, Vector2>(val - new Vector2(((GObject)cardForAnimation).width / 2f, ((GObject)cardForAnimation).height / 2f), val + new Vector2(((GObject)cardForAnimation).width / 2f, ((GObject)cardForAnimation).height / 2f))));
				((GObject)cardForAnimation).alpha = 1f;
				((GObject)cardForAnimation).touchable = true;
			}
			else
			{
				((GObject)cardForAnimation).alpha = 0f;
			}
			cardsList.Add(cardForAnimation);
		}
		if (cardslocationList.numItems > 0)
		{
			UiTagManager instance = UiTagManager.Instance;
			if (length <= 1)
			{
				instance.Register("LotteryPanel.FirstLotteryResult", SingleFakeCard);
			}
			else
			{
				instance.Register("LotteryPanel.FirstLotteryResult", ((GComponent)cardslocationList).GetChildAt(0));
			}
			if (cardslocationList.numItems > 1)
			{
				instance.Register("LotteryPanel.SecondLotteryResult", ((GComponent)cardslocationList).GetChildAt(1));
			}
		}
		((GObject)cardslocationList).touchable = true;
		((GObject)slideFloor).touchable = true;
		((GObject)InterruptBack).touchable = false;
		if (newSoldierIdList.Count > 0)
		{
			FGUIManager.Instance.OpenNewSoldierUiIEnumerator();
		}
		for (int k = 0; k < cardslocationList.numItems; k++)
		{
			GButton asButton = ((GComponent)cardslocationList).GetChildAt(k).asButton;
			((GObject)asButton).SetPivot(0f, 0f);
			Vector2 val2 = ((GObject)asButton).LocalToRoot(new Vector2(0f, 0f), GRoot.inst);
			((GObject)asButton).SetPivot(0.5f, 0.5f);
		}
	}

	private void ShowCards(int length)
	{
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		RenderCardsLocationList(length);
		for (int i = 0; i < cardslocationList.numItems; i++)
		{
			((GComponent)cardslocationList).GetChildAt(i).touchable = true;
		}
		((GObject)cardslocationList).touchable = false;
		cardNum = ((length > 10) ? 10 : length);
		cardsCache.Clear();
		workersCache.Clear();
		float num = 0.3f;
		cardAndPosrangeList.Clear();
		for (int j = 0; j < length; j++)
		{
			int index = j;
			Vector2 pos;
			GButton cardForAnimation = GetCardForAnimation(index, length, out pos);
			cardsCache.Add(cardForAnimation);
			if (length == 1)
			{
				SingleFakeCard = cardForAnimation;
			}
			((GComponent)batteryLucency).AddChild((GObject)(object)cardForAnimation);
			string sackName = "sack3";
			string explosionName = "card_explosion";
			string launchName = "card_launch";
			Bonus key = awardList[index].Key;
			switch (key.IsShining)
			{
			case 2:
				sackName = "sack4";
				explosionName = "card_explosion_gold";
				launchName = "card_launch_gold";
				break;
			case 1:
				explosionName = "card_explosion_silver";
				launchName = "card_explosion_silver";
				break;
			}
			SetWorkerAndCardPaths.Add(((MonoBehaviour)FGUIManager.Instance).StartCoroutine(SetWorkerAndCardPath(index, sackName, explosionName, launchName, length, pos, cardForAnimation, num)));
			num += 0.3f;
		}
		if (cardslocationList.numItems > 0)
		{
			UiTagManager instance = UiTagManager.Instance;
			if (length <= 1)
			{
				instance.Register("LotteryPanel.FirstLotteryResult", SingleFakeCard);
			}
			else
			{
				instance.Register("LotteryPanel.FirstLotteryResult", ((GComponent)cardslocationList).GetChildAt(0));
			}
			if (cardslocationList.numItems > 1)
			{
				instance.Register("LotteryPanel.SecondLotteryResult", ((GComponent)cardslocationList).GetChildAt(1));
			}
		}
		ShowCardCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(ShowCardComplete(num + 1.5f));
	}

	private void RenderScoreProgressType7(UI_basisPool card, Activity activity)
	{
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		LotteryActivityPayload lotteryActivityPayload = (LotteryActivityPayload)activity.ContentPayload(GameManagers.Instance).First().Value;
		Shift.Legion.Common.Models.ActivityConfig activityConfig = lotteryActivityPayload.Activity.ActivityProgress(GameManagers.Instance);
		int score = activityConfig.Score;
		List<Activity.BonusPoint> bonusProgressList = lotteryActivityPayload.Activity.BonusProgressList;
		List<float> claimProgress = activityConfig.ClaimProgress;
		int num = -1;
		for (int i = 0; i < bonusProgressList.Count; i++)
		{
			Activity.BonusPoint bonusPoint = bonusProgressList[i];
			if (!claimProgress.Contains(bonusPoint.Score))
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			((GObject)card.ScoreProgress).visible = false;
			return;
		}
		int num2 = ((num > 0) ? bonusProgressList[num - 1].Score : 0);
		int num3 = score - num2;
		Activity.BonusPoint rewardBonus = bonusProgressList[num];
		int num4 = rewardBonus.Score - num2;
		((GObject)card.ScoreProgress.curNum).text = num3.ToString();
		((GObject)card.ScoreProgress.totalNum).text = num4.ToString();
		bool flag = num3 >= num4;
		((GProgressBar)card.ScoreProgress).value = (flag ? 100f : ((float)num3 / (float)num4 * 100f));
		card.ScoreProgress.Tyep.SetSelectedIndex(flag ? 1 : 0);
		if (!flag)
		{
			((GObject)card.ScoreProgress.sfxBack).visible = false;
			((GObject)card.ScoreProgress.chest).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(rewardBonus.BonusItems.First().Key, ((GObject)this).sortingOrder, noCheckBtn: true);
			});
			card.ScoreProgress.BoxBreathing.Stop();
			return;
		}
		if (pageController.selectedIndex == 0)
		{
			((GObject)card.ScoreProgress.sfxBack).visible = true;
			FGUIManager.Instance.AddTextSpecialEffects(card.ScoreProgress.sfxBack, "activated_fx", new Vector3(90f, 90f, 90f));
			soldierSpineGGraphs.Add(card.ScoreProgress.sfxBack);
		}
		card.ScoreProgress.BoxBreathing.Play();
		((GObject)card.ScoreProgress.chest).data = lotteryActivityPayload.Activity;
		((GObject)card.ScoreProgress.chest).onClick.Set(new EventCallback1(GetDrawReward2));
	}

	private IEnumerator CannonMove(float delay)
	{
		yield return (object)new WaitForSeconds(delay);
		pageController.selectedIndex = 2;
		((GObject)diamondAddBtn).visible = false;
		((GObject)addTicketBtn).visible = false;
		((GObject)addCouponBtn).visible = false;
		CardCannonClose();
		CannonMoveCoroutine = null;
	}

	private IEnumerator MainCurtainMove(float delay)
	{
		yield return (object)new WaitForSeconds(delay);
		CardStageClose();
		CardHornOpen();
		mainCurtainMoveX = ((GComponent)(object)CardStage).SetTimeout(1.527f).OnComplete((GTweenCallback)delegate
		{
			ShowCards(awardList.Count);
			mainCurtainMoveX = null;
		});
		mainCurtainMoveCoroutine = null;
	}

	public IEnumerator GetABullet(UI_bullet bullet, int num, float delay, bool playReload = true)
	{
		yield return (object)new WaitForSeconds(delay);
		bullet = Reload(num, playReload);
		bullets.Add(bullet);
	}

	private IEnumerator SetABulletPath(int num, float delay)
	{
		yield return (object)new WaitForSeconds(delay);
		UI_bullet bullet = bullets[num];
		Bonus bonus = awardList[num].Key;
		int materialItemType = Shift.Legion.Common.Models.Item.ItemType(bonus.ItemId);
		bool isQualified = (materialItemType == 10 && qualifiedPool && qualifiedSoldiers.Contains("S" + bonus.ItemId.Substring(3))) || ((materialItemType == 10 && springFestivalPool && springFestivalSoldiers.Contains("S" + bonus.ItemId.Substring(3))) ? true : false);
		((GObject)muzzleSmokeBack.graph).displayObject.Dispose();
		string explosionSfxName = ((!isQualified) ? "cannon_smoke_explosion" : "cannon_smoke_explosion_gold");
		FGUIManager.Instance.AddTextSpecialEffects(muzzleSmokeBack.graph, explosionSfxName, new Vector3(110f, 110f, 110f), "Default", 0.5f, delegate(GameObject cannonSmokeExplosion)
		{
			cannonSmokeExplosion.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
		});
		CardCannonWork();
		int index = Random.Range(0, targetList.Count);
		GButton button = targetList[index];
		targetList.RemoveAt(index);
		Vector2 pos = ((GObject)mapLoader.component).TransformPoint(((GObject)button).xy, (GObject)(object)batteryLucency);
		((GObject)bullet).alpha = 1f;
		bullet.right_handed.Play(-1, 0f, (PlayCompleteCallback)null);
		((GObject)bullet).TweenMove(pos, 1.5f).SetEase((EaseType)5);
		string fallingSfxName = ((!isQualified) ? "cannonball_falling" : "cannonball_falling_gold");
		GTweenCallback val = default(GTweenCallback);
		GTweenCallback val4 = default(GTweenCallback);
		((GObject)bullet).TweenFade(1f, 0.2f).OnComplete((GTweenCallback)delegate
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Expected O, but got Unknown
			//IL_0044: Expected O, but got Unknown
			GTweener obj = ((GObject)bullet).TweenScale(new Vector2(0.1f, 0.1f), 1.8f).SetEase((EaseType)5);
			GTweenCallback obj2 = val;
			if (obj2 == null)
			{
				GTweenCallback val2 = delegate
				{
					//IL_004d: Unknown result type (might be due to invalid IL or missing references)
					//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
					//IL_00be: Unknown result type (might be due to invalid IL or missing references)
					//IL_00c0: Expected O, but got Unknown
					//IL_00c5: Expected O, but got Unknown
					bullet.right_handed.Stop();
					((GObject)bullet.carrier).displayObject.Dispose();
					FGUIManager.Instance.AddTextSpecialEffects(bullet.carrier, fallingSfxName, new Vector3(500f, 500f, 500f), "Default", 0.5f, delegate(GameObject cannonballFalling)
					{
						cannonballFalling.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
						UiAudioManager.Instance.LoadSoundsForSfx(cannonballFalling, "BulletBlast", playLoop: false, 0.25f);
					});
					((GObject)bullet).alpha = 0f;
					GTweener obj3 = ((GObject)bullet).TweenFade(0f, 1f);
					GTweenCallback obj4 = val4;
					if (obj4 == null)
					{
						GTweenCallback val5 = delegate
						{
							((GObject)bullet).Dispose();
						};
						GTweenCallback val6 = val5;
						val4 = val5;
						obj4 = val6;
					}
					obj3.OnComplete(obj4);
				};
				GTweenCallback val3 = val2;
				val = val2;
				obj2 = val3;
			}
			obj.OnComplete(obj2);
		});
	}

	private IEnumerator ShowCardComplete(float delay)
	{
		yield return (object)new WaitForSeconds(delay);
		((GObject)cardslocationList).touchable = true;
		((GObject)slideFloor).touchable = true;
		((GObject)InterruptBack).touchable = false;
		if (newSoldierIdList.Count > 0)
		{
			FGUIManager.Instance.OpenNewSoldierUiIEnumerator();
		}
		ShowCardCoroutine = null;
		if (awardList.Count > 1)
		{
			((GObject)tip).text = LanguagesManager.GetDesc("CsharpCodeZhTcText185") + " " + LanguagesManager.GetDesc("CsharpCodeZhTcText186");
			((GObject)tip).visible = true;
		}
	}

	private IEnumerator SetWorkerAndCardPath(int index, string sackName, string explosionName, string launchName, int length, Vector2 pos, GButton card, float delay)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		yield return (object)new WaitForSeconds(delay);
		GTweenCallback val = default(GTweenCallback);
		GTweenCallback val9 = default(GTweenCallback);
		if (workerList.Count != 0)
		{
			KeyValuePair<GButton, SkeletonAnimation> button = workerList[0];
			workerList.RemoveAt(0);
			workersCache.Add(button.Key);
			((GObject)button.Key).SetXY(((GObject)batteryLucency.startPoint).x, ((GObject)batteryLucency.startPoint).y);
			((GComponent)button.Key).GetChild("icon").asLoader.url = "ui://PublicResources/" + sackName;
			((GComponent)batteryLucency).SetChildIndex((GObject)(object)button.Key, 100);
			button.Value.AnimationState.AddAnimation(1, "carry", true, 0f);
			GTweenCallback val8 = default(GTweenCallback);
			((GObject)button.Key).TweenMove(((GObject)batteryLucency.middle).xy, 0.37f).SetEase((EaseType)1).OnComplete((GTweenCallback)delegate
			{
				//IL_0048: Unknown result type (might be due to invalid IL or missing references)
				//IL_004d: Unknown result type (might be due to invalid IL or missing references)
				//IL_004f: Expected O, but got Unknown
				//IL_0054: Expected O, but got Unknown
				GTweener obj = ((GObject)button.Key).TweenMoveX(((GObject)batteryLucency.explodePoint).x, 0.93f).SetEase((EaseType)0);
				GTweenCallback obj2 = val;
				if (obj2 == null)
				{
					GTweenCallback val2 = delegate
					{
						//IL_003a: Unknown result type (might be due to invalid IL or missing references)
						//IL_0088: Unknown result type (might be due to invalid IL or missing references)
						//IL_0092: Unknown result type (might be due to invalid IL or missing references)
						//IL_0097: Unknown result type (might be due to invalid IL or missing references)
						//IL_0140: Unknown result type (might be due to invalid IL or missing references)
						//IL_0176: Unknown result type (might be due to invalid IL or missing references)
						//IL_017b: Unknown result type (might be due to invalid IL or missing references)
						//IL_017d: Expected O, but got Unknown
						//IL_0182: Expected O, but got Unknown
						//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
						//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
						//IL_01f9: Expected O, but got Unknown
						//IL_01fe: Expected O, but got Unknown
						FGUIManager.Instance.AddTextSpecialEffects(((GComponent)button.Key).GetChild("sack").asGraph, launchName, new Vector3(100f, 100f, 100f), "Default", 0.5f, delegate(GameObject launch)
						{
							launch.AddComponent<HotFix_DestroySelf>().destroyTime = 2f;
							UiAudioManager.Instance.LoadSoundsForSfx(launch, "BlastForPack");
						});
						Vector2 val4 = ((GObject)((GComponent)button.Key).GetChild("sack").asGraph).LocalToRoot(Vector2.zero, GRoot.inst);
						((GObject)card).SetXY(((GObject)button.Key).x, ((GObject)button.Key).y);
						((GObject)card).alpha = 1f;
						((GComponent)button.Key).GetChild("icon").asLoader.url = "";
						((GObject)card).SetXY(pos.x, pos.y);
						GTweener obj3 = ((GObject)card).TweenScale(Vector2.one, 0.33f).SetEase((EaseType)1);
						GTweenCallback val5 = default(GTweenCallback);
						GTweenCallback obj4 = val5;
						if (obj4 == null)
						{
							GTweenCallback val6 = delegate
							{
								//IL_0065: Unknown result type (might be due to invalid IL or missing references)
								//IL_009f: Unknown result type (might be due to invalid IL or missing references)
								//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
								//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
								//IL_00c7: Expected O, but got Unknown
								//IL_00cc: Expected O, but got Unknown
								if (length > 1)
								{
									((GObject)((GComponent)cardslocationList).GetChildAt(index).asButton).alpha = 1f;
								}
								FGUIManager.Instance.AddTextSpecialEffects(((GComponent)card).GetChild("specialEffectsBack").asGraph, explosionName, new Vector3(120f, 120f, 120f), "Default", 0.5f, delegate(GameObject explosion)
								{
									explosion.AddComponent<HotFix_DestroySelf>().destroyTime = 2f;
									UiAudioManager.Instance.LoadSoundsForSfx(explosion, "CardsShow");
								});
								GTweener obj7 = ((GObject)card).TweenScale(Vector2.one, 1f);
								GTweenCallback val10 = default(GTweenCallback);
								GTweenCallback obj8 = val10;
								if (obj8 == null)
								{
									GTweenCallback val11 = delegate
									{
										//IL_0050: Unknown result type (might be due to invalid IL or missing references)
										//IL_005a: Unknown result type (might be due to invalid IL or missing references)
										//IL_005f: Unknown result type (might be due to invalid IL or missing references)
										//IL_0071: Unknown result type (might be due to invalid IL or missing references)
										//IL_0094: Unknown result type (might be due to invalid IL or missing references)
										//IL_0099: Unknown result type (might be due to invalid IL or missing references)
										//IL_009e: Unknown result type (might be due to invalid IL or missing references)
										//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
										//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
										cardsList.Add(card);
										cardsCache.Remove(card);
										if (length == 1)
										{
											Vector2 val13 = ((GObject)card).LocalToRoot(new Vector2(0.5f, 0.5f), GRoot.inst);
											cardAndPosrangeList.Add(new KeyValuePair<GButton, KeyValuePair<Vector2, Vector2>>(card, new KeyValuePair<Vector2, Vector2>(val13 - new Vector2(((GObject)card).width / 2f, ((GObject)card).height / 2f), val13 + new Vector2(((GObject)card).width / 2f, ((GObject)card).height / 2f))));
											((GObject)card).alpha = 1f;
											((GObject)card).touchable = true;
										}
										else
										{
											((GObject)card).alpha = 0f;
										}
									};
									GTweenCallback val12 = val11;
									val10 = val11;
									obj8 = val12;
								}
								obj7.OnComplete(obj8);
							};
							GTweenCallback val7 = val6;
							val5 = val6;
							obj4 = val7;
						}
						obj3.OnComplete(obj4);
						button.Value.AnimationState.AddAnimation(1, "run", true, 0f);
						GTweener obj5 = ((GObject)button.Key).TweenMoveX(((GObject)batteryLucency.endPoint).x, 1.1f).SetEase((EaseType)0);
						GTweenCallback obj6 = val8;
						if (obj6 == null)
						{
							val9 = delegate
							{
								workersCache.Remove(button.Key);
								workerList.Add(button);
							};
							GTweenCallback val7 = val9;
							val8 = val9;
							obj6 = val7;
						}
						obj5.OnComplete(obj6);
					};
					GTweenCallback val3 = val2;
					val = val2;
					obj2 = val3;
				}
				obj.OnComplete(obj2);
			});
			yield break;
		}
		UI_worker button2 = UI_worker.CreateInstance();
		workersCache.Add((GButton)(object)button2);
		((GComponent)GRoot.inst).AddChild((GObject)(object)button2);
		((GComponent)batteryLucency).AddChild((GObject)(object)button2);
		((GComponent)batteryLucency).SetChildIndex((GObject)(object)button2, 100);
		((GObject)button2).SetXY(((GObject)batteryLucency.startPoint).x, ((GObject)batteryLucency.startPoint).y);
		((GComponent)button2).GetChild("icon").asLoader.url = "ui://PublicResources/" + sackName;
		SkeletonAnimation animation = LoadSkeleon(((GComponent)button2).GetChild("main").asGraph, "Goblinworker_001", 50f, -1, "carry");
		((GObject)button2).TweenMove(((GObject)batteryLucency.middle).xy, 0.37f).SetEase((EaseType)1).OnComplete((GTweenCallback)delegate
		{
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Expected O, but got Unknown
			//IL_004f: Expected O, but got Unknown
			GTweener obj = ((GObject)button2).TweenMoveX(((GObject)batteryLucency.explodePoint).x, 0.93f).SetEase((EaseType)0);
			GTweenCallback obj2 = val;
			if (obj2 == null)
			{
				GTweenCallback val2 = delegate
				{
					//IL_0052: Unknown result type (might be due to invalid IL or missing references)
					//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
					//IL_00af: Unknown result type (might be due to invalid IL or missing references)
					//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
					//IL_014e: Unknown result type (might be due to invalid IL or missing references)
					//IL_0184: Unknown result type (might be due to invalid IL or missing references)
					//IL_0189: Unknown result type (might be due to invalid IL or missing references)
					//IL_018b: Expected O, but got Unknown
					//IL_0190: Expected O, but got Unknown
					//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
					//IL_01de: Unknown result type (might be due to invalid IL or missing references)
					//IL_01e0: Expected O, but got Unknown
					//IL_01e5: Expected O, but got Unknown
					animation.AnimationState.AddAnimation(1, "run", true, 0f);
					GameObject val4 = FGUIManager.Instance.AddTextSpecialEffects(((GComponent)button2).GetChild("sack").asGraph, launchName, new Vector3(100f, 100f, 100f));
					val4.AddComponent<HotFix_DestroySelf>().destroyTime = 2f;
					UiAudioManager.Instance.LoadSoundsForSfx(val4, "BlastForPack");
					Vector2 val5 = ((GObject)((GComponent)button2).GetChild("sack").asGraph).LocalToRoot(Vector2.zero, GRoot.inst);
					((GObject)card).SetXY(((GObject)button2).x, ((GObject)button2).y);
					((GObject)card).alpha = 1f;
					((GComponent)button2).GetChild("icon").asLoader.url = "";
					((GObject)card).SetXY(pos.x, pos.y);
					GTweener obj3 = ((GObject)card).TweenScale(Vector2.one, 0.33f).SetEase((EaseType)1);
					GTweenCallback val6 = default(GTweenCallback);
					GTweenCallback obj4 = val6;
					if (obj4 == null)
					{
						GTweenCallback val7 = delegate
						{
							//IL_0065: Unknown result type (might be due to invalid IL or missing references)
							//IL_009f: Unknown result type (might be due to invalid IL or missing references)
							//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
							//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
							//IL_00c7: Expected O, but got Unknown
							//IL_00cc: Expected O, but got Unknown
							if (length > 1)
							{
								((GObject)((GComponent)cardslocationList).GetChildAt(index).asButton).alpha = 1f;
							}
							FGUIManager.Instance.AddTextSpecialEffects(((GComponent)card).GetChild("specialEffectsBack").asGraph, explosionName, new Vector3(120f, 120f, 120f), "Default", 0.5f, delegate(GameObject explosion)
							{
								explosion.AddComponent<HotFix_DestroySelf>().destroyTime = 2f;
								UiAudioManager.Instance.LoadSoundsForSfx(explosion, "CardsShow");
							});
							GTweener obj7 = ((GObject)card).TweenScale(Vector2.one, 1f);
							GTweenCallback val11 = default(GTweenCallback);
							GTweenCallback obj8 = val11;
							if (obj8 == null)
							{
								GTweenCallback val12 = delegate
								{
									//IL_0050: Unknown result type (might be due to invalid IL or missing references)
									//IL_005a: Unknown result type (might be due to invalid IL or missing references)
									//IL_005f: Unknown result type (might be due to invalid IL or missing references)
									//IL_0071: Unknown result type (might be due to invalid IL or missing references)
									//IL_0094: Unknown result type (might be due to invalid IL or missing references)
									//IL_0099: Unknown result type (might be due to invalid IL or missing references)
									//IL_009e: Unknown result type (might be due to invalid IL or missing references)
									//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
									//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
									cardsList.Add(card);
									cardsCache.Remove(card);
									if (length == 1)
									{
										Vector2 val14 = ((GObject)card).LocalToRoot(new Vector2(0.5f, 0.5f), GRoot.inst);
										cardAndPosrangeList.Add(new KeyValuePair<GButton, KeyValuePair<Vector2, Vector2>>(card, new KeyValuePair<Vector2, Vector2>(val14 - new Vector2(((GObject)card).width / 2f, ((GObject)card).height / 2f), val14 + new Vector2(((GObject)card).width / 2f, ((GObject)card).height / 2f))));
										((GObject)card).alpha = 1f;
										((GObject)card).touchable = true;
									}
									else
									{
										((GObject)card).alpha = 0f;
									}
								};
								GTweenCallback val13 = val12;
								val11 = val12;
								obj8 = val13;
							}
							obj7.OnComplete(obj8);
						};
						GTweenCallback val8 = val7;
						val6 = val7;
						obj4 = val8;
					}
					obj3.OnComplete(obj4);
					GTweener obj5 = ((GObject)button2).TweenMoveX(((GObject)batteryLucency.endPoint).x, 1.1f).SetEase((EaseType)0);
					GTweenCallback obj6 = val9;
					if (obj6 == null)
					{
						GTweenCallback val10 = delegate
						{
							workersCache.Remove((GButton)(object)button2);
							workerList.Add(new KeyValuePair<GButton, SkeletonAnimation>((GButton)(object)button2, animation));
						};
						GTweenCallback val8 = val10;
						val9 = val10;
						obj6 = val8;
					}
					obj5.OnComplete(obj6);
				};
				GTweenCallback val3 = val2;
				val = val2;
				obj2 = val3;
			}
			obj.OnComplete(obj2);
		});
	}

	private async void NewbieGACHADraw(GButton btn)
	{
		if (isDrawing)
		{
			return;
		}
		isDrawing = true;
		NewbieGACHAActivityPayload optionPayload = (NewbieGACHAActivityPayload)((GObject)btn).data;
		int _uiNotTouchableIndex = GameController.Contexts.Service<IUiService>().SetUiNotTouchable(Name);
		if (isDrawing)
		{
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		}
		newbieGACHAActivityPayload = optionPayload;
		if (!(await optionPayload.UpdateNewbieGACHAActivityProgress()))
		{
			isDrawing = false;
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			GameController.Contexts.Service<IUiService>().SetUiTouchable(_uiNotTouchableIndex);
			return;
		}
		Action drawAni = delegate
		{
			UpdateContractNote();
			pageController.selectedIndex = 1;
			foreach (GGraph soldierSpineGGraph in soldierSpineGGraphs)
			{
				((GObject)soldierSpineGGraph).visible = false;
			}
			((GObject)CardLoader).touchable = false;
			((GObject)InterruptBack).touchable = true;
			((GObject)backBtn).touchable = false;
			((GObject)TitleCom).touchable = false;
			((GObject)Help).touchable = false;
			((GObject)diamondAddBtn).touchable = false;
			((GObject)addCouponBtn).touchable = false;
			((GObject)addTicketBtn).touchable = false;
			needBreakDrawAnimation = false;
			bullets.Clear();
			CreatBullet.Clear();
			SetBulletPath.Clear();
			SetWorkerAndCardPaths.Clear();
			ClearAdvancedSfxs();
			CardStagOpen();
		};
		NewbieGACHADrawResult = optionPayload.GetNewbieGACHAActivityContent(isInit: false, out var bulletsCount);
		RookiePoolBackground.Fire(drawAni, this, bulletsCount);
		isDrawing = false;
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
		GameController.Contexts.Service<IUiService>().SetUiTouchable(_uiNotTouchableIndex);
	}

	private void SetNewbieGACHACardClick(Dictionary<string, ActivityContentPayload> activityContent, UI_basisPool card)
	{
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected O, but got Unknown
		foreach (KeyValuePair<string, ActivityContentPayload> item in activityContent)
		{
			string key = item.Key;
			NewbieGACHAActivityPayload newbieGACHAActivityPayload = (NewbieGACHAActivityPayload)item.Value;
			List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
			for (int i = 0; i < newbieGACHAActivityPayload.Tickets.Count; i++)
			{
				foreach (KeyValuePair<string, int> item2 in newbieGACHAActivityPayload.Tickets[i])
				{
					list.Add(new KeyValuePair<string, int>(item2.Key, item2.Value));
				}
			}
			KeyValuePair<string, string> keyValuePair = SetCastIconAndNum(list);
			((GObject)card.runningCost).text = keyValuePair.Value;
			card.runningTicketIcon.url = "ui://PublicResources/" + keyValuePair.Key;
			((GObject)card.runningBtn).data = newbieGACHAActivityPayload;
			((GObject)card.runningBtn.note).visible = newbieGACHAActivityPayload.CheckTicket(GameManagers.Instance, null, out var _);
			((GObject)card.runningBtn).onClick.Set((EventCallback1)delegate(EventContext context)
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_0011: Expected O, but got Unknown
				NewbieGACHADraw((GButton)context.sender);
			});
			((GObject)card.runningBtn).enabled = newbieGACHAActivityPayload.GetNewbieGACHAActivityProgress() <= 0;
		}
	}

	private void ShowNewbieGACHAProgress(int progress)
	{
		if (progress != 0 && progress != 3)
		{
			switch (progress)
			{
			case 1:
				needShowNewbieContent = true;
				FGUIManager.Instance.OpenIEnumerator(ShowNewbieDrawContent());
				break;
			case 2:
				needShowNewbieContent = true;
				FGUIManager.Instance.OpenIEnumerator(ShowNewbieDrawAllResult());
				break;
			}
		}
	}

	private IEnumerator ShowNewbieDrawContent()
	{
		NewbieGACHADrawResult = newbieGACHAActivityPayload?.GetNewbieGACHAActivityContent(isInit: true, out var _);
		((GObject)this).alpha = 0f;
		yield return null;
		InterruptDrawAnimation();
		((GObject)this).alpha = 1f;
		RookiePoolContent.SkipAndShowImmediately(NewbieGACHADrawResult, this);
	}

	private IEnumerator ShowNewbieDrawAllResult()
	{
		NewbieGACHADrawResult = newbieGACHAActivityPayload?.GetNewbieGACHAActivityContent(isInit: true, out var _);
		((GObject)this).alpha = 0f;
		yield return null;
		InterruptDrawAnimation();
		((GObject)this).alpha = 1f;
		RookiePoolContent.SkipAndShowImmediately(NewbieGACHADrawResult, this);
		RookiePoolContent.FlipAllSoulStoneAndSoldierCardsShowImmediately();
	}

	public void CardStageInit()
	{
		if (!((Object)(object)cardStageSkeletonAnimation != (Object)null) && !((GObject)this).isDisposed)
		{
			cardStageSkeletonAnimation = UiHelper.SpineLoad(CardStage.StageWrapper, "card_stage_bg", 100f, "skin1", "idle");
			_spines.Add("card_stage_bg");
		}
	}

	public void PortalParticleEffectInit()
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)cardStagePortalSfx != (Object)null) && !((GObject)this).isDisposed)
		{
			cardStagePortalSfx = FGUIManager.Instance.AddTextSpecialEffects(CardStage.PortalWrapper, "ui_cardgacha_portal", new Vector3(100f, 100f, 100f));
			if (cardStagePortalSfx != null)
			{
				cardStagePortalSfx.transform.localPosition = new Vector3(0f, 0f, 100f);
			}
		}
	}

	public void CardStagOpen()
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		if (((GObject)this).isDisposed || cardStageSkeletonAnimation == null || needBreakDrawAnimation)
		{
			return;
		}
		SkeletonAnimation obj = cardStageSkeletonAnimation;
		if (obj != null)
		{
			AnimationState animationState = obj.AnimationState;
			if (animationState != null)
			{
				animationState.SetAnimation(0, "open", false);
			}
		}
		((GComponent)(object)CardStage).SetTimeout(1.5f).OnComplete(new GTweenCallback(CardStageIdle2));
	}

	public void CardStageIdle2()
	{
		if (!((GObject)this).isDisposed && cardStageSkeletonAnimation != null && !needBreakDrawAnimation)
		{
			SkeletonAnimation obj = cardStageSkeletonAnimation;
			object obj2;
			if (obj == null)
			{
				obj2 = null;
			}
			else
			{
				AnimationState animationState = obj.AnimationState;
				obj2 = ((animationState != null) ? animationState.SetAnimation(0, "idle2", true) : null);
			}
			TrackEntry val = (TrackEntry)obj2;
			val.MixDuration = 0.2f;
			PortalParticleEffectInit();
		}
	}

	public void CardStageClose()
	{
		if (((GObject)this).isDisposed || cardStageSkeletonAnimation == null || needBreakDrawAnimation)
		{
			return;
		}
		SkeletonAnimation obj = cardStageSkeletonAnimation;
		if (obj != null)
		{
			AnimationState animationState = obj.AnimationState;
			if (animationState != null)
			{
				animationState.SetAnimation(1, "close", false);
			}
		}
		UiHelper.DestoryUiSfx(CardStage.PortalWrapper, cardStagePortalSfx, 0f);
	}

	public void CardStageReset()
	{
		if (!((GObject)this).isDisposed && cardStageSkeletonAnimation != null)
		{
			cardStageSkeletonAnimation = null;
			CardStageInit();
		}
	}

	public void CardStageAnimationSkip()
	{
		if (!((GObject)this).isDisposed && cardStageSkeletonAnimation != null)
		{
			UiHelper.DestoryUiSfx(CardStage.PortalWrapper, cardStagePortalSfx, 0f);
			AnimationState animationState = cardStageSkeletonAnimation.AnimationState;
			if (animationState != null)
			{
				animationState.SetAnimation(1, "close", false);
			}
			if (cardStageSkeletonAnimation.state != null)
			{
				cardStageSkeletonAnimation.state.GetCurrent(1).AnimationStart = 1.527f;
			}
		}
	}

	public void CardStageInitForNewbie()
	{
		if (!((GObject)this).isDisposed)
		{
			if (Object.op_Implicit((Object)(object)cardStageSkeletonAnimation))
			{
				cardStageSkeletonAnimation = null;
			}
			cardStageSkeletonAnimation = UiHelper.SpineLoad(CardStage.StageWrapper, "card_stage_bg", 100f, "skin1", "close", null, isMask: false, aniLoop: false);
			_spines.Add("card_stage_bg");
			if (cardStageSkeletonAnimation.state != null)
			{
				cardStageSkeletonAnimation.state.GetCurrent(0).AnimationStart = 1.527f;
			}
			CardHornOpen();
		}
	}

	public void CardHornReset()
	{
		if (!((GObject)this).isDisposed)
		{
			cardHornFooSkeletonAnimation = null;
			cardHornBarSkeletonAnimation = null;
			((GObject)CardHorn).visible = false;
			CardHorn.Type.selectedIndex = 0;
		}
	}

	public void CardHornOpen()
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		if (!((GObject)this).isDisposed && !needBreakDrawAnimation)
		{
			UiAudioManager.Instance.PlaySoundEffect("Trombone");
			cardHornFooSkeletonAnimation = UiHelper.SpineLoad(CardHorn.HornWrapperFoo, "card-horn", 100f, "skin1", "open", null, isMask: false, aniLoop: false);
			cardHornBarSkeletonAnimation = UiHelper.SpineLoad(CardHorn.HornWrapperBar, "card-horn", 100f, "skin1", "open", null, isMask: false, aniLoop: false, -1f);
			_spines.Add("card-horn");
			((GComponent)(object)CardHorn).SetTimeout(1.3333f).OnComplete(new GTweenCallback(CardHornWork));
		}
	}

	public void CardHornWork()
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		if (((GObject)this).isDisposed || needBreakDrawAnimation)
		{
			return;
		}
		((GObject)CardHorn).visible = true;
		SkeletonAnimation obj = cardHornFooSkeletonAnimation;
		if (obj != null)
		{
			AnimationState animationState = obj.AnimationState;
			if (animationState != null)
			{
				animationState.SetAnimation(0, "work", false);
			}
		}
		SkeletonAnimation obj2 = cardHornBarSkeletonAnimation;
		if (obj2 != null)
		{
			AnimationState animationState2 = obj2.AnimationState;
			if (animationState2 != null)
			{
				animationState2.SetAnimation(0, "work", false);
			}
		}
		((GComponent)(object)CardHorn).SetTimeout(2.5f).OnComplete((GTweenCallback)delegate
		{
			CardHorn.Type.selectedIndex = 1;
		});
	}

	public void CardHornAnimationSkip()
	{
		if (((GObject)this).isDisposed)
		{
			return;
		}
		((GObject)CardHorn).visible = true;
		if (!Object.op_Implicit((Object)(object)cardHornFooSkeletonAnimation))
		{
			cardHornFooSkeletonAnimation = UiHelper.SpineLoad(CardHorn.HornWrapperFoo, "card-horn", 100f, "skin1", "work", null, isMask: false, aniLoop: false);
			_spines.Add("card-horn");
		}
		SkeletonAnimation obj = cardHornFooSkeletonAnimation;
		if (obj != null)
		{
			AnimationState animationState = obj.AnimationState;
			if (animationState != null)
			{
				animationState.SetAnimation(0, "work", false);
			}
		}
		if (cardHornFooSkeletonAnimation?.state != null)
		{
			cardHornFooSkeletonAnimation.state.GetCurrent(0).AnimationStart = 1.9f;
		}
		if (!Object.op_Implicit((Object)(object)cardHornBarSkeletonAnimation))
		{
			cardHornBarSkeletonAnimation = UiHelper.SpineLoad(CardHorn.HornWrapperBar, "card-horn", 100f, "skin1", "work", null, isMask: false, aniLoop: false, -1f);
			_spines.Add("card-horn");
		}
		SkeletonAnimation obj2 = cardHornBarSkeletonAnimation;
		if (obj2 != null)
		{
			AnimationState animationState2 = obj2.AnimationState;
			if (animationState2 != null)
			{
				animationState2.SetAnimation(0, "work", false);
			}
		}
		if (cardHornBarSkeletonAnimation?.state != null)
		{
			cardHornBarSkeletonAnimation.state.GetCurrent(0).AnimationStart = 1.9f;
		}
		CardHorn.Type.selectedIndex = 1;
	}

	public void CardCannonReset()
	{
		if (!((GObject)this).isDisposed)
		{
			cardCannonSkeletonAnimation = null;
		}
	}

	public void CardCannonOpen()
	{
		if (!((GObject)this).isDisposed && !needBreakDrawAnimation)
		{
			cardCannonSkeletonAnimation = UiHelper.SpineLoad(CardCannon.CannonWrapper, "card_cannon", 100f, "skin1", "open", null, isMask: false, aniLoop: false);
			_spines.Add("card_cannon");
		}
	}

	public void CardCannonWork()
	{
		if (((GObject)this).isDisposed || needBreakDrawAnimation)
		{
			return;
		}
		CardCannon.Fire.Play();
		SkeletonAnimation obj = cardCannonSkeletonAnimation;
		if (obj != null)
		{
			AnimationState animationState = obj.AnimationState;
			if (animationState != null)
			{
				animationState.SetAnimation(0, "work", false);
			}
		}
	}

	public void CardCannonClose()
	{
		if (((GObject)this).isDisposed || needBreakDrawAnimation)
		{
			return;
		}
		SkeletonAnimation obj = cardCannonSkeletonAnimation;
		if (obj != null)
		{
			AnimationState animationState = obj.AnimationState;
			if (animationState != null)
			{
				animationState.SetAnimation(0, "close", false);
			}
		}
	}

	public void CardCannonSkip()
	{
		if (((GObject)this).isDisposed)
		{
			return;
		}
		if (!Object.op_Implicit((Object)(object)cardCannonSkeletonAnimation))
		{
			cardCannonSkeletonAnimation = UiHelper.SpineLoad(CardCannon.CannonWrapper, "card_cannon", 100f, "skin1", "close", null, isMask: false, aniLoop: false);
			_spines.Add("card_cannon");
		}
		SkeletonAnimation obj = cardCannonSkeletonAnimation;
		if (obj != null)
		{
			AnimationState animationState = obj.AnimationState;
			if (animationState != null)
			{
				animationState.SetAnimation(0, "close", false);
			}
		}
		if (cardCannonSkeletonAnimation?.state != null)
		{
			cardCannonSkeletonAnimation.state.GetCurrent(0).AnimationStart = 0.5f;
		}
	}
}
