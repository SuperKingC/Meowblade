using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.Store;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.Sources.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models;
using Spine.Unity;
using UI.AddCredit;
using UI.BlackMarketer;
using UI.Certification;
using UI.GiftBag;
using UI.LegendItems;
using UI.MainCity;
using UI.MonthCard;
using UI.MtgGiftPacks;
using UI.PublicResources;
using UI.RecyclingCenter;
using UI.Screenshots;
using UI.SpecialActivity;
using UI.Tips;
using UI.UpGrade;
using UI.WeekActivityPass;
using UnityEngine;

namespace UI.GameActivity;

public class UI_ActivityPanel : GComponent, IUiController
{
	private class tabInfo
	{
		public GObject TabObject;

		public string TabName;

		public int OriTabIdx;

		public int CurTabIdx;
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<Task<ClaimVerifyIdentityBonusResponse>> _003C_003E9__88_0;

		public static GTweenCallback _003C_003E9__98_0;

		public static Func<Mission, bool> _003C_003E9__114_0;

		public static Func<Mission, bool> _003C_003E9__114_1;

		public static Func<ContinuousRechargeBonus, bool> _003C_003E9__167_0;

		public static Func<string, bool> _003C_003E9__168_0;

		public static Func<string, bool> _003C_003E9__168_1;

		public static Func<string, bool> _003C_003E9__168_2;

		public static Func<ContinuousRechargeBonus, bool> _003C_003E9__171_1;

		public static Func<Dictionary<string, float>, bool> _003C_003E9__214_0;

		public static Action<GameObject> _003C_003E9__216_1;

		public static Func<Mission, bool> _003C_003E9__225_0;

		public static Func<Mission, bool> _003C_003E9__225_1;

		public static Func<Mission, bool> _003C_003E9__225_2;

		public static Action<GameObject> _003C_003E9__228_4;

		public static Action<GameObject> _003C_003E9__244_0;

		public static Action<GameObject> _003C_003E9__326_1;

		public static Action<GameObject> _003C_003E9__334_1;

		public static Action<GameObject> _003C_003E9__341_1;

		public static Func<Mission, bool> _003C_003E9__344_0;

		public static Func<Mission, bool> _003C_003E9__344_1;

		public static Func<Mission, bool> _003C_003E9__344_2;

		public static Func<Mission, bool> _003C_003E9__344_3;

		public static Action<GameObject> _003C_003E9__359_1;

		public static Comparison<LimitedTimeTotalRechargeInfo> _003C_003E9__368_0;

		internal Task<ClaimVerifyIdentityBonusResponse> _003CClaimVerifyIdentityBonus_003Eb__88_0()
		{
			return GameController.Contexts.Service<INetworkService>().ClaimVerifyIdentityBonus();
		}

		internal void _003CInviteFriends_003Eb__98_0()
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ScreenshotsPanel.Name, null);
		}

		internal bool _003CCumulativeAimAchievementListSort_003Eb__114_0(Mission a)
		{
			return a.MissionState(GameManagers.Instance).Status == MissionStatus.Completed;
		}

		internal bool _003CCumulativeAimAchievementListSort_003Eb__114_1(Mission a)
		{
			return a.MissionState(GameManagers.Instance).Status == MissionStatus.Claimed;
		}

		internal bool _003CActivityTabInit_003Eb__167_0(ContinuousRechargeBonus bonus)
		{
			return bonus.BonusStatus != Shift.Legion.ClientApi.Protocol.UserAction.BonusStatus.HasClaimedBonus;
		}

		internal bool _003CRenderActivityTabBtn_003Eb__168_0(string levelId)
		{
			return GameManagers.Instance.UserArchiveManager.IsLevelCompleted(levelId);
		}

		internal bool _003CRenderActivityTabBtn_003Eb__168_1(string levelId)
		{
			return GameManagers.Instance.UserArchiveManager.IsLevelCompleted(levelId);
		}

		internal bool _003CRenderActivityTabBtn_003Eb__168_2(string levelId)
		{
			return GameManagers.Instance.UserArchiveManager.IsLevelCompleted(levelId);
		}

		internal bool _003CRenderRechargeCombo_003Eb__171_1(ContinuousRechargeBonus _data)
		{
			return _data.BonusStatus == Shift.Legion.ClientApi.Protocol.UserAction.BonusStatus.CanClaimBonus;
		}

		internal bool _003CGetSevenDaysActivityStoreItems_003Eb__214_0(Dictionary<string, float> costDict)
		{
			foreach (float value in costDict.Values)
			{
				if (value > 0f)
				{
					return false;
				}
			}
			return true;
		}

		internal void _003CRenderMissionTabList_003Eb__216_1(GameObject activatingWhite)
		{
			activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
		}

		internal bool _003CSevenAimAchievementListSort_003Eb__225_0(Mission a)
		{
			return a.MissionState(GameManagers.Instance).Status == MissionStatus.Completed;
		}

		internal bool _003CSevenAimAchievementListSort_003Eb__225_1(Mission a)
		{
			return a.MissionState(GameManagers.Instance).Status == MissionStatus.Undergoing;
		}

		internal bool _003CSevenAimAchievementListSort_003Eb__225_2(Mission a)
		{
			return a.MissionState(GameManagers.Instance).Status == MissionStatus.Claimed;
		}

		internal void _003CPlayGetExtraRewardSfx_003Eb__228_4(GameObject activatingWhite)
		{
			activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
		}

		internal void _003COnStockChange_003Eb__244_0(GameObject uiGreen)
		{
			uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
		}

		internal void _003CRenderLegendItemFundDailyAchievementItem_003Eb__326_1(GameObject activatingWhite)
		{
			activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
		}

		internal void _003CRenderChipFundDailyAchievementItem_003Eb__334_1(GameObject activatingWhite)
		{
			activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
		}

		internal void _003CRenderGemFundDailyAchievementItem_003Eb__341_1(GameObject activatingWhite)
		{
			activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
		}

		internal bool _003CGrowthFundActivityAimAchievementListSort_003Eb__344_0(Mission a)
		{
			return a.MissionState(GameManagers.Instance).Status == MissionStatus.Pending;
		}

		internal bool _003CGrowthFundActivityAimAchievementListSort_003Eb__344_1(Mission a)
		{
			return a.MissionState(GameManagers.Instance).Status == MissionStatus.Completed;
		}

		internal bool _003CGrowthFundActivityAimAchievementListSort_003Eb__344_2(Mission a)
		{
			return a.MissionState(GameManagers.Instance).Status == MissionStatus.Undergoing;
		}

		internal bool _003CGrowthFundActivityAimAchievementListSort_003Eb__344_3(Mission a)
		{
			return a.MissionState(GameManagers.Instance).Status == MissionStatus.Claimed;
		}

		internal void _003CRenderLegionCultivateFundDailyAchievementItem_003Eb__359_1(GameObject activatingWhite)
		{
			activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
		}

		internal int _003CRefreshPanel_003Eb__368_0(LimitedTimeTotalRechargeInfo a, LimitedTimeTotalRechargeInfo b)
		{
			return a.RMB.CompareTo(b.RMB);
		}
	}

	public Controller PageController;

	public Controller Type;

	public Controller CurrencyType;

	public GLoader background;

	public GGraph mask;

	public GButton backBtn;

	public UI_Title Title;

	public GComponent addCouponBtn;

	public GComponent addDiamondBtn;

	public GComponent addWorkerBtn;

	public GGroup baseCurrencyGroup;

	public GComponent addItemBtn1;

	public GComponent addItemBtn2;

	public GGroup customCurrencyGroup;

	public GList ActTabBottomList;

	public GList ActTabTopList;

	public GImage n6;

	public GGroup backAndCrack;

	public GImage n66;

	public GGroup back2nd;

	public UI_com_RechargeComboPanel FirstTimeRewardPanel;

	public UI_SevenDaysMissionPanel_New SevenDaysMissionPanel;

	public UI_SignInPanel SignInPanel;

	public UI_CumulativeCostPanel CumulativeCostPanel;

	public UI_CumulativeCostPanel_New BlackMarketTreasurePanel;

	public UI_OrcActivityPanel OrcActivityPanel;

	public UI_DailySignPanel DailySignPanel;

	public UI_ChipFundPanel ChipFundPanel;

	public UI_GemFundPanel GemFundPanel;

	public UI_GrowthFundPanel GrowthFundPanel;

	public UI_LegendItemFundPanel LegendItemFundPanel;

	public UI_LegionCultivateFundPanel LegionCultivateFundPanel;

	public UI_PatronPanel PatronPanel;

	public UI_SpringFestivalPanel SpringFestivalPanel;

	public UI_CertificationTabPanel CertificationPanel;

	public UI_main_DeparturePresent DeparturePresentPanel;

	public UI_com_SecretTreasury SecretTreasuryPanel;

	public UI_com_SpinWeekContainer SpinWeekSpin;

	public UI_com_WeekPassContainer WeekPassContainer;

	public UI_com_ShadowDemonGift ShadowDemonGift;

	public GList ActTabList;

	public GButton exit;

	public GGraph missibleSfxBack;

	public GGraph missbleEndPos;

	public GGraph topMask;

	public const string URL = "ui://29q48tv6oa38j";

	public static string Name = "UI_ActivityPanel";

	private List<KeyValuePair<string, string>> exhibitionBonusList = new List<KeyValuePair<string, string>>();

	private List<GButton> blackMarketTreasure_RechargeAchievementList = new List<GButton>();

	private List<KeyValuePair<int, Dictionary<string, float>>> blackMarketTreasureBonusProgress = new List<KeyValuePair<int, Dictionary<string, float>>>();

	private TreasureHouseRechargeInfo blackMarketTreasureRechargeInfo;

	private Coroutine BlackMarketTreasureTimeRemainingCoroutine;

	private List<KeyValuePair<string, string>> specialMissionBonusLis = new List<KeyValuePair<string, string>>();

	private HashSet<string> _soldiers = new HashSet<string>();

	private bool isVerifying = false;

	private bool identityVerifyClaimed;

	private Dictionary<int, InvitedWorker> curInvitedWorkers = new Dictionary<int, InvitedWorker>();

	private Dictionary<int, Dictionary<int, InvitedWorker>> curSelectedWorkers = new Dictionary<int, Dictionary<int, InvitedWorker>>();

	private Dictionary<int, InvitedWorker> curSlotsWorkers = new Dictionary<int, InvitedWorker>();

	private UI_InvitedWorkersPanel InvitedWorkersPanel;

	private UI_HelpPanel HelpPanel;

	private Coroutine PatronListRemainingCoroutine;

	private Coroutine FriendsListRemainingCoroutine;

	private List<GButton> RechargeAchievementList = new List<GButton>();

	private List<Mission> curRechargeAimAchievementList = new List<Mission>();

	private Dictionary<string, GObject> _TabNote;

	private UI_ActTabs _bmTab;

	private TaskCompletionSource<bool> _taskCompleteOnClose;

	private ActivityEntranceMode _tabFilterType;

	public const string TITLE_NAME = "TitleName";

	public const string TAB = "Tab";

	private const string ActivityBackBtn = "ActivityPanelBackBtn";

	public static ActivityEntranceMode[] RewardGroup = new ActivityEntranceMode[3]
	{
		ActivityEntranceMode.Rewards,
		ActivityEntranceMode.NewGuideModeRewards,
		ActivityEntranceMode.NewForeignRewards
	};

	public static List<string> SpinWeekActivities = new List<string>
	{
		UI_com_SpinWeekSpin.Name,
		UI_main_WeekActivityPass.Name
	};

	private Dictionary<string, tabInfo> _oriTabOrderInfo = new Dictionary<string, tabInfo>();

	private Dictionary<string, int> allTabName = new Dictionary<string, int>();

	private const string PatronPanelName = "UI_PatronPanel";

	private const string SpringFestivalPanelName = "UI_SpringFestivalPanel";

	private const string CumulativeCostPanelName = "UI_CumulativeCostPanel";

	private const string BlackMarketTreasurePanelName = "UI_CumulativeCostPanel_New";

	private const string FirstTimeRewardPanelName = "UI_FirstTimeRewardPanel";

	private const string SevenDaysMissionPanelName = "UI_SevenDaysMissionPanel";

	private const string SignInPanelName = "UI_SignInPanel";

	private const string CertificationPanelName = "UI_CertificationPanel";

	private const string DailySignInPanelName = "UI_DailySignPanel";

	private const string ChipFundPanelName = "UI_ChipFundPanel";

	private const string GemFundPanelName = "UI_GemFundPanel";

	private const string GrowthFundPanelName = "UI_GrowthFundPanel";

	private const string LegendItemFundPanelName = "UI_LegendItemFundPanel";

	private const string LegionCultivateFundPanelName = "UI_LegionCultivateFundPanel";

	private const string OrcActivityPanelName = "UI_OrcActivityPanel";

	private const string SecretTreasuryPanelName = "UI_com_SecretTreasury";

	private const string ShadowDemonGiftName = "UI_com_ShadowDemonGift";

	private bool isRenderingRechargeCombo;

	private List<SignInBonusData> DailySignBonusDatas = new List<SignInBonusData>();

	private int curDailySignInDay;

	private Activity dailySignInActivity;

	private const string DailySignInActivityUi = "UI_DailySignPanel";

	private List<GButton> dailySignButtons = new List<GButton>();

	private const int DailySignCount = 7;

	private Coroutine timeCoroutine;

	public const string ActivityId_MissionsOf7Days1 = "MissionsOf7Days1";

	private static List<List<string>> StoreItemIds_MissionsOf7Days1 = new List<List<string>>
	{
		new List<string> { "SevenDaysPack1", "SevenDaysPack2" },
		new List<string> { "SevenDaysPack3", "SevenDaysPack4" },
		new List<string> { "SevenDaysPack5", "SevenDaysPack6" },
		new List<string> { "SevenDaysPack7", "SevenDaysPack8" },
		new List<string> { "SevenDaysPack9", "SevenDaysPack10" },
		new List<string> { "SevenDaysPack11", "SevenDaysPack12" },
		new List<string> { "SevenDaysPack13", "SevenDaysPack14" }
	};

	private static List<List<Shift.Legion.Common.Models.Store.StoreItem>> StoreItems_MissionsOf7Days1 = new List<List<Shift.Legion.Common.Models.Store.StoreItem>>
	{
		new List<Shift.Legion.Common.Models.Store.StoreItem>(),
		new List<Shift.Legion.Common.Models.Store.StoreItem>(),
		new List<Shift.Legion.Common.Models.Store.StoreItem>(),
		new List<Shift.Legion.Common.Models.Store.StoreItem>(),
		new List<Shift.Legion.Common.Models.Store.StoreItem>(),
		new List<Shift.Legion.Common.Models.Store.StoreItem>(),
		new List<Shift.Legion.Common.Models.Store.StoreItem>()
	};

	private List<string> textureList = new List<string>();

	private int curSignInDay;

	private int curMissionDay;

	public int curSelectMissionDay;

	private List<GButton> SevenDayAchievementList = new List<GButton>();

	private List<Mission> curSevenDayAimAchievementList = new List<Mission>();

	private UI_ProductionNumFloating NumFloatingGem;

	private Activity SevenDayActivity;

	private Activity SignInActivity;

	private Activity FirstTimeRewardActivity;

	private Activity RechargeComboActivity;

	private Activity CumulativeCostActivity;

	private Activity BlackMarketTreasureActivity;

	private List<Activity> HomePageActivity = new List<Activity>();

	private List<ActivityContentPayload> SevenDayActivityContentPayloads = new List<ActivityContentPayload>();

	private Coroutine TimeLimitRemainingCoroutine;

	private List<SignInBonusData> SignInList = new List<SignInBonusData>();

	private Mission FirstTimeRewardMission;

	private List<Bonus> FirstTimeRewardMissionBonus = new List<Bonus>();

	private List<string> bonusName = new List<string>
	{
		LanguagesManager.GetDesc("CsharpCodeZhTcText217"),
		" " + LanguagesManager.GetDesc("CsharpCodeZhTcText229"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText218")
	};

	private IUiController parentUiController;

	private DateTimeOffset todayTimeOffset;

	private bool showPatron;

	private bool showSpringFestivalTab;

	private Dictionary<string, int> tabBackupDic = new Dictionary<string, int>();

	private Dictionary<int, string> tabDic = new Dictionary<int, string>();

	private int tabIndex;

	private List<string> TabFilter;

	private int NianTabIndex;

	private int PatronTabIndex;

	private int CertificationIndex;

	private int FirstTimeRewardIndex;

	private int SevenDaysMissionIndex;

	private int SignInIndex;

	private int DailySignInIndex;

	private int ChipFundIndex;

	private int GemFundIndex;

	private int GrowthFundIndex;

	private int LegendItemFundIndex;

	private int LegionCultivateFundIndex;

	private int CumulativeCostIndex;

	private int BlackMarketTreasureIndex;

	private int _departurePresentIndex;

	private int _secretTreasuryTabIndex;

	private bool NeedGoToCertification;

	private bool canDailySign;

	private KeyValuePair<string, Dictionary<string, float>> currentRechargeComboBonusKv;

	private const string GrowthFundCertStoreItem = "FundCertStoreItem3";

	private const string ChipFundCertStoreItem2 = "FundCertStoreItem2";

	private const string GemFundCertStoreItem = "FundCertStoreItem1";

	private const string LegendItemFundCertStoreItem = "FundCertStoreItem4";

	private const string LegionCultivateFundCertStoreItem = "FundCertStoreItem5";

	private Activity chipFundActivity;

	private Activity gemFundActivity;

	private Activity growthFundActivity;

	private Activity legendItemFundActivity;

	private Activity legionCultivateFundActivity;

	private List<Mission> curLegendItemFundAchievementList = new List<Mission>();

	private List<Mission> curChipFundAchievementList = new List<Mission>();

	private List<Mission> curGemFundAchievementList = new List<Mission>();

	private List<Mission> curGrowthFundAchievementList = new List<Mission>();

	private List<GButton> GrowthAchievementList = new List<GButton>();

	private List<Mission> curLegionCultivateFundAchievementList = new List<Mission>();

	private UI_ActTabs _secretTreasuryNote;

	private List<LimitedTimeTotalRechargeInfo> _secretTreasuryViewModel;

	private UI_ActTabs _shadowDemonActTab;

	private bool _initedShadowDemon;

	public bool PushGiftBagOnClose;

	private UI_ActTabs _spinWeekNote;

	public Action ETopMaskClicked;

	private GetWeeklyActivityResponse _spinWeekInfo;

	private ISpinWheelPage _spinWheelPage;

	private UI_ActTabs _weekActTab;

	private UI_main_WeekActivityPass _weekActPass;

	private string PanelName => LanguagesManager.GetDesc("CsharpCodeZhTcText219");

	private string GrowthFundTabName => LanguagesManager.GetDesc("CsharpCodeZhTcText230");

	private string ChipFundTabName => LanguagesManager.GetDesc("CsharpCodeZhTcText231");

	private string GemFundTabName => LanguagesManager.GetDesc("CsharpCodeZhTcText232");

	private string LegendItemFundTabName => LanguagesManager.GetDesc("CsharpCodeZhTcText233");

	private string LegionCultivateFundTabName => LanguagesManager.GetDesc("LegionCultivateFundTabName");

	private string DeparturePresentTabName => LanguagesManager.GetDesc("DeparturePresentTabName");

	private string CurPageName => PageController.GetPageName(PageController.selectedIndex);

	public DynamicSecretTreasuryActivity SecretTreasury => FGUIManager.Instance.DynamicSecretTreasury;

	public void SetButtonTitle()
	{
		for (int i = 0; i < ActTabList.numItems; i++)
		{
			GButton asButton = ((GComponent)ActTabList).GetChildAt(i).asButton;
			if (asButton != null)
			{
				asButton.title = LanguagesManager.GetDesc($"GameActivity-ActivityPanel-ActTab-title-{i}");
			}
		}
	}

	public static string GetURL()
	{
		return "ui://29q48tv6oa38j";
	}

	public static UI_ActivityPanel CreateInstance()
	{
		return (UI_ActivityPanel)(object)UIPackage.CreateObject("GameActivity", "ActivityPanel");
	}

	public static UI_ActivityPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ActivityPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6oa38j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Expected O, but got Unknown
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Expected O, but got Unknown
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Expected O, but got Unknown
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Expected O, but got Unknown
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		Type = ((GComponent)this).GetController("Type");
		CurrencyType = ((GComponent)this).GetController("CurrencyType");
		background = (GLoader)((GComponent)this).GetChild("background");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		Title = (UI_Title)(object)((GComponent)this).GetChild("Title");
		addCouponBtn = (GComponent)((GComponent)this).GetChild("addCouponBtn");
		addDiamondBtn = (GComponent)((GComponent)this).GetChild("addDiamondBtn");
		addWorkerBtn = (GComponent)((GComponent)this).GetChild("addWorkerBtn");
		baseCurrencyGroup = (GGroup)((GComponent)this).GetChild("baseCurrencyGroup");
		addItemBtn1 = (GComponent)((GComponent)this).GetChild("addItemBtn1");
		addItemBtn2 = (GComponent)((GComponent)this).GetChild("addItemBtn2");
		customCurrencyGroup = (GGroup)((GComponent)this).GetChild("customCurrencyGroup");
		ActTabBottomList = (GList)((GComponent)this).GetChild("ActTabBottomList");
		ActTabTopList = (GList)((GComponent)this).GetChild("ActTabTopList");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		backAndCrack = (GGroup)((GComponent)this).GetChild("backAndCrack");
		n66 = (GImage)((GComponent)this).GetChild("n66");
		back2nd = (GGroup)((GComponent)this).GetChild("back2nd");
		FirstTimeRewardPanel = (UI_com_RechargeComboPanel)(object)((GComponent)this).GetChild("FirstTimeRewardPanel");
		SevenDaysMissionPanel = (UI_SevenDaysMissionPanel_New)(object)((GComponent)this).GetChild("SevenDaysMissionPanel");
		SignInPanel = (UI_SignInPanel)(object)((GComponent)this).GetChild("SignInPanel");
		CumulativeCostPanel = (UI_CumulativeCostPanel)(object)((GComponent)this).GetChild("CumulativeCostPanel");
		BlackMarketTreasurePanel = (UI_CumulativeCostPanel_New)(object)((GComponent)this).GetChild("BlackMarketTreasurePanel");
		OrcActivityPanel = (UI_OrcActivityPanel)(object)((GComponent)this).GetChild("OrcActivityPanel");
		DailySignPanel = (UI_DailySignPanel)(object)((GComponent)this).GetChild("DailySignPanel");
		ChipFundPanel = (UI_ChipFundPanel)(object)((GComponent)this).GetChild("ChipFundPanel");
		GemFundPanel = (UI_GemFundPanel)(object)((GComponent)this).GetChild("GemFundPanel");
		GrowthFundPanel = (UI_GrowthFundPanel)(object)((GComponent)this).GetChild("GrowthFundPanel");
		LegendItemFundPanel = (UI_LegendItemFundPanel)(object)((GComponent)this).GetChild("LegendItemFundPanel");
		LegionCultivateFundPanel = (UI_LegionCultivateFundPanel)(object)((GComponent)this).GetChild("LegionCultivateFundPanel");
		PatronPanel = (UI_PatronPanel)(object)((GComponent)this).GetChild("PatronPanel");
		SpringFestivalPanel = (UI_SpringFestivalPanel)(object)((GComponent)this).GetChild("SpringFestivalPanel");
		CertificationPanel = (UI_CertificationTabPanel)(object)((GComponent)this).GetChild("CertificationPanel");
		DeparturePresentPanel = (UI_main_DeparturePresent)(object)((GComponent)this).GetChild("DeparturePresentPanel");
		SecretTreasuryPanel = (UI_com_SecretTreasury)(object)((GComponent)this).GetChild("SecretTreasuryPanel");
		SpinWeekSpin = (UI_com_SpinWeekContainer)(object)((GComponent)this).GetChild("SpinWeekSpin");
		WeekPassContainer = (UI_com_WeekPassContainer)(object)((GComponent)this).GetChild("WeekPassContainer");
		ShadowDemonGift = (UI_com_ShadowDemonGift)(object)((GComponent)this).GetChild("ShadowDemonGift");
		ActTabList = (GList)((GComponent)this).GetChild("ActTabList");
		exit = (GButton)((GComponent)this).GetChild("exit");
		missibleSfxBack = (GGraph)((GComponent)this).GetChild("missibleSfxBack");
		missbleEndPos = (GGraph)((GComponent)this).GetChild("missbleEndPos");
		topMask = (GGraph)((GComponent)this).GetChild("topMask");
	}

	private void RenderBlackMarketTreasurePanel()
	{
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		foreach (Activity item in HomePageActivity)
		{
			if (item.UiName == "UI_CumulativeCostPanel_New" && item.GetStatus(GameManagers.Instance) != ActivityStatus.Disabled)
			{
				BlackMarketTreasureActivity = item;
				break;
			}
		}
		if (BlackMarketTreasureActivity == null)
		{
			return;
		}
		DateTimeOffset serverNow = DateTimeHelper.ServerNow;
		if (BlackMarketTreasureActivity.GetStatus(GameManagers.Instance) == ActivityStatus.Disabled || serverNow.CompareTo(BlackMarketTreasureActivity.BeginTime[0]) == -1 || serverNow.CompareTo(BlackMarketTreasureActivity.EndTime[0]) == 1 || FGUIManager.Instance.BlackMarketTreasureData == null)
		{
			return;
		}
		blackMarketTreasureRechargeInfo = FGUIManager.Instance.BlackMarketTreasureData;
		_realRenderBlackMarketTreasurePanel();
		Task<GetTreasureHouseRechargeInfoResponse> task = GameController.Contexts.Service<INetworkService>().GetTreasureHouseRechargeInfo(-1L, FGUIManager.BlackMarketTreasureActivityId);
		task.GetAwaiter().OnCompleted(delegate
		{
			GetTreasureHouseRechargeInfoResponse result = task.Result;
			if (!result.Result)
			{
				ILRequestHelper.ShowErrorCode(result.ErrorCode);
			}
			else
			{
				blackMarketTreasureRechargeInfo = result.TreasureHouseRechargeInfo;
				_realRenderBlackMarketTreasurePanel();
			}
		});
		FGUIManager.Instance.AddTextSpecialEffects(BlackMarketTreasurePanel.topUpBtn.effPos, "ui_stroke_button_1", Vector3.one * 100f);
	}

	private void _realRenderBlackMarketTreasurePanel()
	{
		List<string> activityIds = new List<string> { BlackMarketTreasureActivity.ActivityId };
		if (BlackMarketTreasureActivity.ActivityProgress(GameManagers.Instance).IsNew)
		{
			GameManagers.Instance.ActivityManager.ReviewActivities(activityIds);
		}
		((GObject)BlackMarketTreasurePanel).alpha = 1f;
		StartCountDown();
		UpdateBonusExhibition();
		BlackMarketTreasureAchievementListSort();
		UpdateBlackMarketTreasureAchievements(blackMarketTreasureBonusProgress.Count);
		HiddenRechargeAchievementSFX();
	}

	private void StartCountDown()
	{
		if (BlackMarketTreasureTimeRemainingCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(BlackMarketTreasureTimeRemainingCoroutine);
		}
		BlackMarketTreasureTimeRemainingCoroutine = FGUIManager.Instance.OpenIEnumerator(RefreshBlackMarketTreasureTimeRemaining());
	}

	private IEnumerator RefreshBlackMarketTreasureTimeRemaining()
	{
		while (true)
		{
			TimeSpan remainingTimespan = blackMarketTreasureRechargeInfo.EndTime - DateTimeHelper.ServerNow;
			((GObject)BlackMarketTreasurePanel.Timer.limitTime).text = LanguagesManager.GetDesc("CsharpCodeZhTcText227") + UiHelper.ParseTimeChinsesDH(Convert.ToInt32(remainingTimespan.TotalSeconds));
			yield return (object)new WaitForSeconds(60f);
		}
	}

	private void UpdateBonusExhibition()
	{
	}

	private void RenderBonusExhibition(int index, GObject obj)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		KeyValuePair<string, string> keyValuePair = exhibitionBonusList[index];
		string itemId = keyValuePair.Key;
		((GComponent)asButton).GetChild("num").text = int.Parse(keyValuePair.Value).ShortNumberFormat() ?? "";
		((GComponent)asButton).GetChild("num").asTextField.strokeColor = new Color(0f, 0f, 0f, 0.55f);
		if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 10 || Shift.Legion.Common.Models.Item.ItemType(itemId) == 3)
		{
			((GObject)((GComponent)asButton).GetChild("icon").asLoader).SetScale(0.75f, 0.75f);
		}
		((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
		((GObject)((GComponent)asButton).GetChild("icon").asLoader).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(itemId, 2);
		});
	}

	private void BlackMarketTreasureAchievementListSort()
	{
		blackMarketTreasureBonusProgress.Clear();
		int num = (int)blackMarketTreasureRechargeInfo.TotalRecharge;
		List<KeyValuePair<int, Dictionary<string, float>>> list = new List<KeyValuePair<int, Dictionary<string, float>>>();
		List<KeyValuePair<int, Dictionary<string, float>>> list2 = new List<KeyValuePair<int, Dictionary<string, float>>>();
		List<KeyValuePair<int, Dictionary<string, float>>> list3 = new List<KeyValuePair<int, Dictionary<string, float>>>();
		Dictionary<string, ActivityContentPayload> dictionary = BlackMarketTreasureActivity.ContentPayload(GameManagers.Instance);
		if (dictionary.Count > 1)
		{
			ILRuntimeDebug.LogError("More Than 1 Valid TreasureHouseContentPayload For " + BlackMarketTreasureActivity.ActivityId);
		}
		foreach (ActivityContentPayload value in dictionary.Values)
		{
			TreasureHouseActivityPayload treasureHouseActivityPayload = (TreasureHouseActivityPayload)value;
			foreach (KeyValuePair<float, Dictionary<string, float>> item in treasureHouseActivityPayload.BonusConfig)
			{
				float key = item.Key;
				if ((float)num < key)
				{
					list3.Add(new KeyValuePair<int, Dictionary<string, float>>((int)key, item.Value));
				}
				else if (blackMarketTreasureRechargeInfo.HasClaimed.Contains(item.Key))
				{
					list2.Add(new KeyValuePair<int, Dictionary<string, float>>((int)key, item.Value));
				}
				else
				{
					list.Add(new KeyValuePair<int, Dictionary<string, float>>((int)key, item.Value));
				}
			}
		}
		blackMarketTreasureBonusProgress.AddRange(list);
		blackMarketTreasureBonusProgress.AddRange(list3);
		blackMarketTreasureBonusProgress.AddRange(list2);
	}

	private void UpdateBlackMarketTreasureAchievements(int num)
	{
		for (int num2 = blackMarketTreasure_RechargeAchievementList.Count - 1; num2 >= 0; num2--)
		{
			GButton val = blackMarketTreasure_RechargeAchievementList[num2];
			blackMarketTreasure_RechargeAchievementList.RemoveAt(num2);
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)val);
			((GObject)val).Dispose();
		}
		for (int i = 0; i < num; i++)
		{
			GButton val2 = (GButton)(object)UI_RechargeAimBtn.CreateInstance();
			((GComponent)GRoot.inst).AddChild((GObject)(object)val2);
			((GComponent)BlackMarketTreasurePanel.AchievementList).AddChild((GObject)(object)val2);
			((GObject)val2).SetXY(0f, (float)i * 143f);
			blackMarketTreasure_RechargeAchievementList.Add(val2);
			RenderBlackMarketTreasureAchievementCard(i, val2);
		}
		for (int j = 0; j < blackMarketTreasure_RechargeAchievementList.Count; j++)
		{
			if (j != 0)
			{
				((GObject)blackMarketTreasure_RechargeAchievementList[j]).AddRelation((GObject)(object)blackMarketTreasure_RechargeAchievementList[j - 1], (RelationType)9);
			}
			else
			{
				((GObject)blackMarketTreasure_RechargeAchievementList[j]).relations.ClearAll();
			}
		}
	}

	private void RenderBlackMarketTreasureAchievementCard(int index, GButton button)
	{
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected O, but got Unknown
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Expected O, but got Unknown
		KeyValuePair<int, Dictionary<string, float>> keyValuePair = blackMarketTreasureBonusProgress[index];
		int key = keyValuePair.Key;
		float totalRecharge = blackMarketTreasureRechargeInfo.TotalRecharge;
		bool flag = totalRecharge >= (float)key;
		string text = $"{key}";
		string text2 = $"{Convert.ToInt32(totalRecharge)}";
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			text = $"{(float)key / 100f:F2}";
			text2 = $"{totalRecharge / 100f:F2}";
			button.title = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcTotalRecharge"), text);
		}
		else
		{
			button.title = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcTotalRechargeCN"), text);
		}
		((GComponent)button).GetController("rewardStyle").selectedIndex = 1;
		((GObject)((GComponent)button).GetChild("num").asTextField).text = text2 + "/" + text;
		Controller controller = ((GComponent)button).GetController("ReceiveStatus");
		bool flag2 = blackMarketTreasureRechargeInfo.HasClaimed_List_Int.Contains(key);
		if (!flag)
		{
			controller.selectedIndex = 0;
		}
		else if (!flag2)
		{
			controller.selectedIndex = 1;
		}
		else
		{
			controller.selectedIndex = 2;
		}
		if (keyValuePair.Value.Count > 0)
		{
			GObject child = ((GComponent)button).GetChild("receiveBtn");
			bool flag3 = flag && !flag2;
			((GObject)child.asButton).data = index;
			((GComponent)child.asButton).GetChild("note").visible = flag3;
			((GObject)child.asButton).onClick.Set(new EventCallback1(ClaimBlackMarketTreasureBonus));
			((GObject)child.asButton).enabled = flag3;
			GObject child2 = ((GComponent)button).GetChild("rewardList");
			child2.asList.itemRenderer = new ListItemRenderer(RenderBlackMarketTreasureBonus);
			child2.asList.numItems = keyValuePair.Value.Count;
		}
	}

	private void RenderBlackMarketTreasureBonus(int index, GObject obj)
	{
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		GComponent asCom = obj.asCom;
		int index2 = (int)((GObject)((GObject)((GObject)asCom).parent).asList).parent.GetChild("receiveBtn").data;
		KeyValuePair<int, Dictionary<string, float>> keyValuePair = blackMarketTreasureBonusProgress[index2];
		Dictionary<string, float> value = keyValuePair.Value;
		int num = 0;
		int number = 0;
		string bonusItemId = "";
		foreach (KeyValuePair<string, float> item in value)
		{
			if (num++ == index)
			{
				number = (int)item.Value;
				bonusItemId = item.Key;
				break;
			}
		}
		((GObject)asCom.GetChild("rewardNum").asTextField).text = number.ShortNumberFormat() ?? "";
		asCom.GetChild("rewardNum").asTextField.strokeColor = new Color(0f, 0f, 0f, 0.55f);
		if (Shift.Legion.Common.Models.Item.ItemType(bonusItemId) == 3)
		{
			FGUIManager.Instance.SetItemIconAndFrame(asCom.GetChild("rewardIcon").asLoader, bonusItemId, textureList);
		}
		else
		{
			asCom.GetChild("rewardIcon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(bonusItemId);
		}
		if (Shift.Legion.Common.Models.Item.ItemType(bonusItemId) == 10 || Shift.Legion.Common.Models.Item.ItemType(bonusItemId) == 3)
		{
			((GObject)asCom.GetChild("rewardIcon").asLoader).SetScale(0.75f, 0.75f);
		}
		((GObject)asCom.GetChild("rewardIcon").asLoader).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(bonusItemId, 2);
		});
		if (Shift.Legion.Common.Models.Item.IsShining(bonusItemId) == 2 && !blackMarketTreasureRechargeInfo.HasClaimed_List_Int.Contains(keyValuePair.Key))
		{
			((GObject)asCom.GetChild("fxBack").asGraph).displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(asCom.GetChild("fxBack").asGraph, "activated_fx", new Vector3(75f, 75f, 75f));
		}
		else
		{
			((GObject)asCom.GetChild("fxBack").asGraph).displayObject.Dispose();
		}
	}

	private void ClaimBlackMarketTreasureBonus(EventContext eventContext)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		int index = (int)((GObject)(GButton)eventContext.sender).data;
		KeyValuePair<int, Dictionary<string, float>> keyValuePair = blackMarketTreasureBonusProgress[index];
		int score = keyValuePair.Key;
		Dictionary<string, float> bonusDict = keyValuePair.Value;
		ILRequestHelper<TreasureHouseBonusClaimResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().TreasureHouseBonusClaim(-1L, FGUIManager.BlackMarketTreasureActivityId, score), delegate(TreasureHouseBonusClaimResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				SharedMessenger.Broadcast("BLACKMARKET_TREASURE_BONUS_CLAIMED", score);
				blackMarketTreasureRechargeInfo.HasClaimed.Add(score);
				blackMarketTreasureRechargeInfo.HasClaimed_List_Int.Add(score);
				BlackMarketTreasureActivity.ClaimProgress(GameManagers.Instance).Add(score);
				if (bonusDict.Count > 0)
				{
					List<ModelsBonus> list = new List<ModelsBonus>();
					foreach (KeyValuePair<string, float> item2 in bonusDict)
					{
						ModelsBonus item = new ModelsBonus
						{
							ItemId = item2.Key,
							Qty = (int)item2.Value,
							IsShining = Shift.Legion.Common.Models.Item.IsShining(item2.Key)
						};
						list.Add(item);
					}
					FGUIManager.Instance.ClaimBonusFromApiModels(list);
					OnBlackMarketTreasureBonusClaimed(index);
					UpdateMoneyAndGemNum(list);
				}
			}
		});
	}

	private void RenderBlackMarketTreasureRechargeAchievementList()
	{
		for (int i = 0; i < blackMarketTreasure_RechargeAchievementList.Count; i++)
		{
			RenderBlackMarketTreasureAchievementCard(i, blackMarketTreasure_RechargeAchievementList[i]);
		}
	}

	private void OnBlackMarketTreasureBonusClaimed(int index)
	{
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		((GObject)BlackMarketTreasurePanel).touchable = false;
		GButton button = blackMarketTreasure_RechargeAchievementList[index];
		GList asList = ((GComponent)button).GetChild("rewardList").asList;
		for (int i = 0; i < asList.numItems; i++)
		{
			if (!((GComponent)asList).GetChildAt(i).asCom.GetChild("fxBack").displayObject.isDisposed)
			{
				((GComponent)asList).GetChildAt(i).asCom.GetChild("fxBack").displayObject.Dispose();
			}
		}
		((GObject)button).relations.ClearAll();
		if (index != blackMarketTreasure_RechargeAchievementList.Count - 1)
		{
			((GObject)blackMarketTreasure_RechargeAchievementList[index + 1]).RemoveRelation((GObject)(object)button, (RelationType)9);
		}
		blackMarketTreasure_RechargeAchievementList.RemoveAt(index);
		GTweenCallback val = default(GTweenCallback);
		((GComponent)button).GetTransition("disappear").Play((PlayCompleteCallback)delegate
		{
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Expected O, but got Unknown
			//IL_00ea: Expected O, but got Unknown
			blackMarketTreasure_RechargeAchievementList.Add(button);
			((GObject)button).SetXY(0f, (float)(blackMarketTreasure_RechargeAchievementList.Count * 143));
			((GObject)button).AddRelation((GObject)(object)blackMarketTreasure_RechargeAchievementList[blackMarketTreasure_RechargeAchievementList.Count - 2], (RelationType)9);
			((GObject)button).alpha = 1f;
			BlackMarketTreasureAchievementListSort();
			RenderBlackMarketTreasureRechargeAchievementList();
			GTweener obj = ((GObject)blackMarketTreasure_RechargeAchievementList[index]).TweenMoveY((float)(index * 143), 0.5f).SetEase((EaseType)5);
			GTweenCallback obj2 = val;
			if (obj2 == null)
			{
				GTweenCallback val2 = delegate
				{
					if (index != 0)
					{
						((GObject)blackMarketTreasure_RechargeAchievementList[index]).AddRelation((GObject)(object)blackMarketTreasure_RechargeAchievementList[index - 1], (RelationType)9);
					}
					((GObject)BlackMarketTreasurePanel).touchable = true;
				};
				GTweenCallback val3 = val2;
				val = val2;
				obj2 = val3;
			}
			obj.OnComplete(obj2);
			HiddenBlackMarketTreasureBonusClaimedSFX();
		});
	}

	private void HiddenBlackMarketTreasureBonusClaimedSFX()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(0f, 6f);
		Vector2 val2 = ((GObject)BlackMarketTreasurePanel.AimAchievementListTop).LocalToRoot(Vector2.zero, GRoot.inst);
		Vector2 val3 = ((GObject)BlackMarketTreasurePanel.AimAchievementListBottom).LocalToRoot(Vector2.zero, GRoot.inst);
		for (int i = 0; i < blackMarketTreasure_RechargeAchievementList.Count; i++)
		{
			Vector2 val4 = ((GObject)blackMarketTreasure_RechargeAchievementList[i]).LocalToRoot(Vector2.zero, GRoot.inst);
			bool visible = ((!(val4.y < val2.y + val.y) && !(val4.y > val3.y - ((GObject)blackMarketTreasure_RechargeAchievementList[i]).height + val.y)) ? true : false);
			GList asList = ((GComponent)blackMarketTreasure_RechargeAchievementList[i]).GetChild("rewardList").asList;
			for (int j = 0; j < asList.numItems; j++)
			{
				if (!((GComponent)asList).GetChildAt(j).asCom.GetChild("fxBack").displayObject.isDisposed)
				{
					((GComponent)asList).GetChildAt(j).asCom.GetChild("fxBack").displayObject.visible = visible;
				}
			}
		}
	}

	private void RenderCumulativeCostPanel()
	{
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		foreach (Activity item in HomePageActivity)
		{
			if (item.UiName == "UI_CumulativeCostPanel")
			{
				CumulativeCostActivity = item;
				break;
			}
		}
		if (CumulativeCostActivity != null)
		{
			List<string> activityIds = new List<string> { CumulativeCostActivity.ActivityId };
			if (CumulativeCostActivity.ActivityProgress(GameManagers.Instance).IsNew)
			{
				GameManagers.Instance.ActivityManager.ReviewActivities(activityIds);
			}
			((GObject)CumulativeCostPanel).alpha = 1f;
			UpdateSpecialMission();
			CumulativeAimAchievementListSort();
			UpdateCumulativeAchievenments(curRechargeAimAchievementList.Count);
			HiddenRechargeAchievementSFX();
			FGUIManager.Instance.AddTextSpecialEffects(CumulativeCostPanel.topUpBtn.effPos, "ui_stroke_button_1", Vector3.one * 100f);
		}
	}

	private void UpdateSpecialMission()
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		MissionSerialActivityPayload missionSerialActivityPayload = (MissionSerialActivityPayload)CumulativeCostActivity.ContentPayload(GameManagers.Instance).Values.First();
		Mission mission = missionSerialActivityPayload.SpecialMission(GameManagers.Instance);
		specialMissionBonusLis.Clear();
		specialMissionBonusLis.AddRange(mission.DisplayBonus.ToList());
		CumulativeCostPanel.rewardList.itemRenderer = new ListItemRenderer(RenderCumulativeRewardItem);
		CumulativeCostPanel.rewardList.numItems = specialMissionBonusLis.Count;
	}

	private void RenderCumulativeRewardItem(int index, GObject obj)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		KeyValuePair<string, string> keyValuePair = specialMissionBonusLis[index];
		string itemId = keyValuePair.Key;
		((GComponent)asButton).GetChild("num").text = int.Parse(keyValuePair.Value).ShortNumberFormat() ?? "";
		((GComponent)asButton).GetChild("num").asTextField.strokeColor = new Color(0f, 0f, 0f, 0.55f);
		if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 10 || Shift.Legion.Common.Models.Item.ItemType(itemId) == 3)
		{
			((GObject)((GComponent)asButton).GetChild("icon").asLoader).SetScale(0.75f, 0.75f);
		}
		((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
		((GObject)((GComponent)asButton).GetChild("icon").asLoader).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(itemId, 2);
		});
	}

	private void SelectSpringFestival21()
	{
	}

	private void RenderSpringFestival21()
	{
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Expected O, but got Unknown
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Expected O, but got Unknown
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		if (!showSpringFestivalTab)
		{
			return;
		}
		Activity springFestivalActivity = FGUIManager.Instance.GetSpringFestivalActivity();
		if (springFestivalActivity == null)
		{
			return;
		}
		((GObject)SpringFestivalPanel).alpha = 1f;
		springFestivalActivity.ActivityProgress(GameManagers.Instance).IsNew = false;
		foreach (KeyValuePair<string, ActivityContentPayload> item in springFestivalActivity.ContentPayload(GameManagers.Instance))
		{
			GameManagers.Instance.NewMsgIncomingManager.CheckActivityContent(springFestivalActivity.ActivityId, item.Key);
		}
		bool flag = springFestivalActivity.HasAnyNewMsg(GameManagers.Instance);
		bool isNew = springFestivalActivity.ActivityProgress(GameManagers.Instance).IsNew;
		if (NianTabIndex > -1)
		{
			((GComponent)((GComponent)ActTabList).GetChildAt(NianTabIndex).asButton).GetChild("note").visible = flag || isNew;
		}
		((GObject)SpringFestivalPanel.title).text = springFestivalActivity.Name;
		((GObject)SpringFestivalPanel.NianSpineCom).touchable = false;
		for (int i = 0; i < 5; i++)
		{
			string iconName = "";
			if (((GComponent)SpringFestivalPanel).GetChild($"item{i}").data != null)
			{
				iconName = ((GComponent)SpringFestivalPanel).GetChild($"item{i}").data.ToString();
			}
			FGUIManager.Instance.SetItemIconAndFrame(((GComponent)SpringFestivalPanel).GetChild($"item{i}").asLoader, iconName, textureList);
			((GObject)((GComponent)SpringFestivalPanel).GetChild($"item{i}").asLoader).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(iconName, ((GObject)this).sortingOrder);
			});
		}
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		GameObject val = (GameObject)(object)((obj is GameObject) ? obj : null);
		SkeletonAnimation animation = val.GetComponent<SkeletonAnimation>();
		SpawnManager.Instance.LoadSoldierSpine(val, "S039_skin5", isMask: true).Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if ((Object)(object)asset != (Object)null)
			{
				((SkeletonRenderer)animation).skeletonDataAsset = asset;
				((SkeletonRenderer)animation).Initialize(true);
				SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin5");
				animation.AnimationState.AddAnimation(1, "idle2", true, 0f);
				animation.timeScale = 0.2f;
				((GObject)((GComponent)SpringFestivalPanel.NianSpineCom).GetChild("spineBack").asGraph).data = true;
			}
		});
		Vector3 localScale = default(Vector3);
		((Vector3)(ref localScale))._002Ector(60f, 60f, 60f);
		val.transform.localScale = localScale;
		val.transform.localPosition = -new Vector3(0f, 0f, 0f);
		val.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
		GoWrapper val2 = new GoWrapper(val);
		((DisplayObject)val2).SetXY(0f, 0f);
		((DisplayObject)val2).pivot = new Vector2(0.5f, 0.5f);
		((DisplayObject)val2).scaleX = 1f;
		val2.supportStencil = true;
		((GComponent)SpringFestivalPanel.NianSpineCom).GetChild("spineBack").asGraph.SetNativeObject((DisplayObject)(object)val2);
		((GObject)SpringFestivalPanel.captureBtn).data = springFestivalActivity;
		((GObject)SpringFestivalPanel.captureBtn).onClick.Set(new EventCallback1(CaptureNian));
	}

	private void CaptureNian(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		Activity activity = (Activity)((GObject)context.sender).data;
		string uiName = activity.UiName;
		int num = int.Parse(activity.UiParams["Type"].ToString());
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "Type", num },
			{ "Activity", activity },
			{ "Parent", this },
			{
				"SortingOrder",
				((GObject)this).sortingOrder
			}
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(uiName, parameters);
		End();
	}

	private void CertificationTabNoteUpdate()
	{
		User value = GameController.Contexts.gameState.user.value;
		bool flag = (value.Verified == 0 || value.Verified == 3) && !FGUIManager.Instance.certificationTabChecked;
		bool flag2 = value.Verified == 1;
		if (CertificationIndex > -1)
		{
			((GComponent)((GComponent)ActTabList).GetChildAt(CertificationIndex).asButton).GetChild("note").visible = flag || flag2;
		}
	}

	private void SelectCertificationPanel()
	{
		if (!FGUIManager.Instance.certificationTabChecked)
		{
			FGUIManager.Instance.certificationTabChecked = true;
		}
		CertificationTabNoteUpdate();
	}

	private void RenderCertificationPanel()
	{
		User value = GameController.Contexts.gameState.user.value;
		if (value.Verified == 4 || value.Verified == 5 || value.Verified == 2)
		{
			identityVerifyClaimed = true;
		}
		else
		{
			UpdateCertificationPanel();
		}
	}

	private void UpdateCertificationPanel()
	{
		CertificationTabNoteUpdate();
		RefreshCertificationPanel();
	}

	private void RefreshCertificationPanel()
	{
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		((GObject)CertificationPanel).alpha = 1f;
		((GObject)CertificationPanel.inputRealName).text = "";
		((GObject)CertificationPanel.inputIdCardNumber).text = "";
		User value = GameController.Contexts.gameState.user.value;
		if (value.Verified == 0 || value.Verified == 3)
		{
			CertificationPanel.PageController.selectedIndex = 0;
		}
		else if (value.Verified == 1)
		{
			CertificationPanel.PageController.selectedIndex = 1;
			((GObject)CertificationPanel.SfxBack).SetPivot(0f, 0f, true);
			FGUIManager.Instance.AddTextSpecialEffects(CertificationPanel.SfxBack, "stroke_card_trail_square", new Vector3(110f, 110f, 110f));
			((GObject)CertificationPanel.inputRealName).text = ConstStr.USER_VERIFIED;
			((GObject)CertificationPanel.inputIdCardNumber).text = ConstStr.USER_VERIFIED;
		}
		else if (value.Verified == 4 || value.Verified == 5 || value.Verified == 2)
		{
			CertificationPanel.PageController.selectedIndex = 2;
			((GObject)CertificationPanel.inputRealName).text = ConstStr.USER_VERIFIED;
			((GObject)CertificationPanel.inputIdCardNumber).text = ConstStr.USER_VERIFIED;
		}
		string text = "";
		if (((GObject)CertificationPanel.CertificationGiftPack.Icon).data != null)
		{
			text = ((GObject)CertificationPanel.CertificationGiftPack.Icon).data.ToString();
		}
		CertificationPanel.CertificationGiftPack.Icon.icon.url = "ui://PublicResources/" + text;
		((GObject)CertificationPanel.CertificationGiftPack.num).text = "500";
		CertificationPanel.CertificationGiftPack.num.strokeColor = new Color(0f, 0f, 0f, 0.55f);
		if (value.Verified == 4 || value.Verified == 5 || value.Verified == 2)
		{
			if (((GObject)CertificationPanel.ReceivedBtn).data != null && (bool)((GObject)CertificationPanel.ReceivedBtn).data)
			{
				((GComponent)CertificationPanel.ReceivedBtn).GetController("PageController").selectedIndex = 0;
				((GComponent)CertificationPanel.ReceivedBtn).GetTransition("stamp").Play();
				((GObject)CertificationPanel.ReceivedBtn).data = false;
			}
			else
			{
				((GComponent)CertificationPanel.ReceivedBtn).GetController("PageController").selectedIndex = 1;
			}
		}
	}

	private async void CertificationEvent()
	{
		if (isVerifying)
		{
			return;
		}
		isVerifying = true;
		string realName = ((GObject)CertificationPanel.inputRealName).text;
		string idCardNumber = ((GObject)CertificationPanel.inputIdCardNumber).text;
		if (string.IsNullOrEmpty(realName) || string.IsNullOrEmpty(idCardNumber))
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText148") }, 998, arg3: false);
			isVerifying = false;
			return;
		}
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		VerifyIdentityResponse verifyResult = await GameController.Contexts.Service<INetworkService>().VerifyIdentity(idCardNumber, realName);
		if (verifyResult.Result)
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText149") }, 998, arg3: false);
			ThinkingDataHelper.Instance.Track("realname_verify");
			User user = GameController.Contexts.gameState.user.value;
			user.Verified = verifyResult.VerifyStatus;
			UpdateCertificationPanel();
		}
		else
		{
			User user2 = GameController.Contexts.gameState.user.value;
			user2.Verified = verifyResult.VerifyStatus;
			ShowFailedResult(user2.Verified, verifyResult.Code, verifyResult.RemainVerifyCnt, FGUIManager.Instance.CustomerServiceQQ);
			isVerifying = false;
		}
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
	}

	private void ShowFailedResult(int curStatus, int _code, int _count, string _qqId = "961307252")
	{
		End();
		string certificationDesc = LanguagesManager.GetCertificationDesc(_code, _count, _qqId);
		int num = ((curStatus == 2) ? 3 : 2);
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "Type", num },
			{ "Text", certificationDesc }
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_CertificationTipPopup.Name, parameters);
	}

	private void ClaimVerifyIdentityBonus(EventContext context)
	{
		ILRequestHelper<ClaimVerifyIdentityBonusResponse>.Request(context, () => GameController.Contexts.Service<INetworkService>().ClaimVerifyIdentityBonus(), delegate(ClaimVerifyIdentityBonusResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				foreach (KeyValuePair<string, int> item in response.ClaimResult)
				{
					Bonus.Get(item.Key, item.Value).Claim(GameManagers.Instance);
				}
				User value = GameController.Contexts.gameState.user.value;
				value.Verified = 4;
				((GObject)CertificationPanel.ReceivedBtn).data = true;
				UpdateCertificationPanel();
			}
		});
	}

	private void SelectPatronPanel()
	{
		if (showPatron)
		{
			GameController.Contexts.Service<INetworkService>().ReviewInvitedWorkers();
			if (PatronTabIndex > -1)
			{
				((GComponent)((GComponent)ActTabList).GetChildAt(PatronTabIndex).asButton).GetChild("newLogo").visible = false;
			}
		}
	}

	private void RenderPatronPanel(bool isInit = false)
	{
		if (showPatron)
		{
			int invitingSlots = GameManagers.Instance.FriendsManager.InvitingSlots;
			GetInvitedWorkers(isInit);
		}
	}

	private void InviteTip(EventContext context)
	{
		int num = GameManagers.Instance.FriendsManager.FriendsLimit - GameManagers.Instance.FriendsManager.FriendsList.Count;
		string arg = "#92CF55";
		if (num <= 0)
		{
			arg = "#ff0000";
		}
		string text = $"[color={arg}]{num}[/color]/{GameManagers.Instance.FriendsManager.FriendsLimit}";
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				text ?? ""
			},
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{
						"Confirm",
						delegate
						{
							InviteFriends();
						}
					},
					{ "Cancel", null }
				}
			},
			{ "PageIndex", 5 },
			{ "ClickSound", "Confirm" },
			{
				"Order",
				((GObject)this).sortingOrder
			}
		});
	}

	private async void GetInvitedWorkers(bool isInit)
	{
		curInvitedWorkers.Clear();
		curSelectedWorkers.Clear();
		curSlotsWorkers.Clear();
		Dictionary<int, InvitedWorker> workers = await GameManagers.Instance.FriendsManager.GetInvitedWorkers();
		if (workers.Count > 0)
		{
			string _tip = "";
			foreach (KeyValuePair<int, InvitedWorker> workerData in workers)
			{
				if (workerData.Value.Status == InvitedWorkerActivateStatus.New)
				{
					string prefix = ((_tip.Length <= 0) ? LanguagesManager.GetDesc("CsharpCodeZhTcText357") : "");
					_tip = _tip + prefix + workerData.Value.Nickname + "、";
				}
				Dictionary<int, Tuple<int, string, int>> slotsConfig = GameManagers.Instance.FriendsManager.InvitingSlotsConfig.GetValue();
				Dictionary<int, Tuple<int, string, int>>.ValueCollection _values = slotsConfig.Values;
				bool containsId = false;
				foreach (Tuple<int, string, int> _value in _values)
				{
					if (_value.Item1 == workerData.Key)
					{
						containsId = true;
						break;
					}
				}
				if (containsId)
				{
					curSlotsWorkers.Add(workerData.Key, workerData.Value);
				}
				else
				{
					curInvitedWorkers.Add(workerData.Key, workerData.Value);
				}
			}
			if (!string.IsNullOrWhiteSpace(_tip))
			{
				if (_tip[_tip.Length - 1] == '、')
				{
					int newLength = _tip.Length - 1;
					_tip = _tip.Substring(0, newLength);
				}
				_tip = _tip + LanguagesManager.GetDesc("CsharpCodeZhTcText361") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText362");
				FGUIManager.Instance.ShowDialogTip(_tip, ((GObject)this).sortingOrder);
			}
		}
		Dictionary<int, Tuple<int, string, int>> invitingSlotsConfig = GameManagers.Instance.FriendsManager.InvitingSlotsConfig.GetValue();
		for (int i = 0; i < 6; i++)
		{
			if (i >= GameManagers.Instance.FriendsManager.InvitingSlots)
			{
				continue;
			}
			if (invitingSlotsConfig.ContainsKey(i))
			{
				Tuple<int, string, int> _key = invitingSlotsConfig[i];
				if (workers.ContainsKey(_key.Item1))
				{
					InvitedWorker _value2 = workers[_key.Item1];
					curSelectedWorkers.Add(i, new Dictionary<int, InvitedWorker> { { _key.Item1, _value2 } });
				}
				else
				{
					curSelectedWorkers.Add(i, new Dictionary<int, InvitedWorker> { { -1, null } });
				}
			}
			else
			{
				curSelectedWorkers.Add(i, new Dictionary<int, InvitedWorker> { { -1, null } });
			}
		}
		if (isInit)
		{
			((GObject)PatronPanel).alpha = 1f;
			bool hasNew = GameManagers.Instance.FriendsManager.HasNewInvitedWorkers;
			if (PatronTabIndex > -1)
			{
				((GComponent)((GComponent)ActTabList).GetChildAt(PatronTabIndex).asButton).GetChild("newLogo").visible = hasNew;
			}
		}
		else
		{
			Dictionary<int, InvitedWorker> newExpiredWorkers = GameManagers.Instance.FriendsManager.NewExpiredInvitedWorkers;
			if (newExpiredWorkers != null)
			{
				string _tip2 = "";
				for (int j = 0; j < newExpiredWorkers.Values.Count; j++)
				{
					string prefix2 = ((_tip2.Length <= 0) ? LanguagesManager.GetDesc("CsharpCodeZhTcText357") : "");
					_tip2 = _tip2 + prefix2 + newExpiredWorkers.Values.ToList()[j].Nickname + "、";
				}
				if (!string.IsNullOrWhiteSpace(_tip2))
				{
					if (_tip2[_tip2.Length - 1] == '、')
					{
						int newLength2 = _tip2.Length - 1;
						_tip2 = _tip2.Substring(0, newLength2);
					}
					_tip2 += LanguagesManager.GetDesc("CsharpCodeZhTcText358");
					FGUIManager.Instance.ShowDialogTip(_tip2, ((GObject)this).sortingOrder);
				}
			}
		}
		RenderPatronList();
		if (!isInit)
		{
			await GameController.Contexts.Service<INetworkService>().ReviewInvitedWorkers();
			((GComponent)((GComponent)ActTabList).GetChildAt(4).asButton).GetChild("newLogo").visible = false;
		}
	}

	private void InviteFriends()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		if (FriendsManager.ShouldShowCopyInvitingCodeWindow())
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_CopyInvitingCodeWindow.Name, null);
			return;
		}
		Screen.orientation = (ScreenOrientation)1;
		GTweener obj = ((GComponent)(object)this).SetTimeout(2f);
		object obj2 = _003C_003Ec._003C_003E9__98_0;
		if (obj2 == null)
		{
			GTweenCallback val = delegate
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_ScreenshotsPanel.Name, null);
			};
			_003C_003Ec._003C_003E9__98_0 = val;
			obj2 = (object)val;
		}
		obj.OnComplete((GTweenCallback)obj2);
	}

	private void InvitedWorkersPanelInit(EventContext context)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		if (curInvitedWorkers.Count > 0)
		{
			int num = Convert.ToInt32(((GObject)context.sender).data);
			InvitedWorkersPanel = UI_InvitedWorkersPanel.CreateInstance();
			((GObject)InvitedWorkersPanel).data = num;
			((GObject)InvitedWorkersPanel.Dialog).y = 118f;
			GObject child = ((GComponent)((GComponent)PatronPanel.PatronList).GetChildAt(num).asButton).GetChild("IconBtn");
			float x = child.TransformPoint(Vector2.zero, (GObject)(object)this).x;
			if (num < 4)
			{
				((GObject)InvitedWorkersPanel.Dialog).x = x + 138f;
			}
			else
			{
				((GObject)InvitedWorkersPanel.Dialog).x = x - ((GObject)InvitedWorkersPanel.Dialog).width;
			}
			((GObject)InvitedWorkersPanel.Mask).onClick.Add(new EventCallback0(CloseInvitedWorkersPanel));
			((GComponent)GRoot.inst).AddChild((GObject)(object)InvitedWorkersPanel);
			InvitedWorkersListRender();
			FGUIManager.SetUiPanelSizeAndXy((GObject)(object)InvitedWorkersPanel);
			InvitedWorkersPanel.ShowDialog.Play();
		}
	}

	private void CloseInvitedWorkersPanel()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)InvitedWorkersPanel.Mask).onClick.Remove(new EventCallback0(CloseInvitedWorkersPanel));
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)InvitedWorkersPanel, true);
	}

	private void InvitedWorkersListRender()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		InvitedWorkersPanel.Dialog.FriendsList.itemRenderer = new ListItemRenderer(RenderInvitedWorker);
		InvitedWorkersPanel.Dialog.FriendsList.numItems = curInvitedWorkers.Count;
		if (curInvitedWorkers.Count <= 0)
		{
			InvitedWorkersPanel.Dialog.Status.selectedIndex = 0;
			((GObject)InvitedWorkersPanel.Dialog.tip2).x = 275f;
		}
		else
		{
			InvitedWorkersPanel.Dialog.Status.selectedIndex = 1;
		}
	}

	private void RenderInvitedWorker(int index, GObject obj)
	{
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		if (curInvitedWorkers.Count > 0)
		{
			KeyValuePair<int, InvitedWorker> keyValuePair = curInvitedWorkers.ToList()[index];
			InvitedWorker value = keyValuePair.Value;
			UI_VisitorItem uI_VisitorItem = obj as UI_VisitorItem;
			if (string.IsNullOrWhiteSpace(value.Avatar))
			{
				uI_VisitorItem.Icon.HeadPortrait.icon.url = "ui://PublicResources/Clap1";
			}
			else
			{
				UiHelper.GetImageByUnityWebRequest(uI_VisitorItem.Icon.HeadPortrait.icon, value.Avatar);
			}
			((GObject)uI_VisitorItem.level).text = value.Level.ToString();
			((GObject)uI_VisitorItem.name).text = value.Nickname;
			int value2 = (int)(value.ExpireAt - DateTimeHelper.Now).TotalSeconds;
			((GObject)uI_VisitorItem.CurEarnings).text = UiHelper.ParseTimeChnForGift(Convert.ToInt32(value2)) ?? "";
			((GObject)uI_VisitorItem).data = keyValuePair.Key;
			((GObject)uI_VisitorItem).onClick.Set(new EventCallback1(ChangeSlotWorker));
		}
	}

	private async void ChangeSlotWorker(EventContext context)
	{
		int selectIndex = Convert.ToInt32(((GObject)context.sender).data);
		int _slotIndex = Convert.ToInt32(((GObject)InvitedWorkersPanel).data);
		if ((await GameController.Contexts.Service<INetworkService>().AssignInvitedWorker(_slotIndex, selectIndex, null, -1)).Result)
		{
			curSelectedWorkers[_slotIndex] = new Dictionary<int, InvitedWorker> { 
			{
				selectIndex,
				curInvitedWorkers[selectIndex]
			} };
			GameManagers.Instance.FriendsManager.AssignInvitedWorker(_slotIndex, selectIndex);
			CloseInvitedWorkersPanel();
			RenderPatronPanel();
		}
	}

	private void RenderPatronList()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		PatronPanel.PatronList.itemRenderer = new ListItemRenderer(PatronRender);
		PatronPanel.PatronList.numItems = 6;
	}

	private void PatronRender(int index, GObject obj)
	{
		//IL_0636: Unknown result type (might be due to invalid IL or missing references)
		//IL_0640: Expected O, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_05b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Expected O, but got Unknown
		//IL_05ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f6: Expected O, but got Unknown
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Expected O, but got Unknown
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Expected O, but got Unknown
		UI_PatronBtn uI_PatronBtn = obj as UI_PatronBtn;
		Dictionary<int, int> invitingSlotUnlockRequiredUserLevelDict = GameManagers.Instance.ConfigDataManager.InvitingSlotUnlockRequiredUserLevelDict;
		if (index < GameManagers.Instance.FriendsManager.InvitingSlots)
		{
			if (GameManagers.Instance.FriendsManager.InvitingSlotsConfig.GetValue().ContainsKey(index) && Enumerable.First(curSelectedWorkers.ToList()[index].Value).Key != -1)
			{
				((GObject)uI_PatronBtn).data = Enumerable.First(curSelectedWorkers.ToList()[index].Value);
				int num = (int)(curSelectedWorkers[index].Values.First().ExpireAt - DateTimeHelper.Now).TotalDays;
				int num2 = (int)(curSelectedWorkers[index].Values.First().ExpireAt - DateTimeHelper.Now).TotalSeconds;
				if (num2 >= 86400)
				{
					uI_PatronBtn.InviterStatus.selectedIndex = 0;
				}
				else
				{
					uI_PatronBtn.InviterStatus.selectedIndex = 1;
				}
				((GObject)uI_PatronBtn.inviterStatusText).text = ((num > 365) ? LanguagesManager.GetDesc("CsharpCodeZhTcText359") : (LanguagesManager.GetDesc("CsharpCodeZhTcText227") + UiHelper.ParseTimeChnForGift(num2)));
				((GObject)uI_PatronBtn.name).text = curSelectedWorkers[index].Values.First().Nickname ?? "";
				if (string.IsNullOrWhiteSpace(curSelectedWorkers[index].Values.First().Avatar))
				{
					uI_PatronBtn.IconBtn.HeadPortrait.icon.url = "ui://PublicResources/Clap1";
				}
				else
				{
					UiHelper.GetImageByUnityWebRequest(uI_PatronBtn.IconBtn.HeadPortrait.icon, curSelectedWorkers[index].Values.First().Avatar);
				}
				((GComponent)uI_PatronBtn).GetChild("IconBtn").data = index;
				((GComponent)uI_PatronBtn).GetChild("IconBtn").onClick.Set(new EventCallback1(InvitedWorkersPanelInit));
				((GObject)uI_PatronBtn.level).text = curSelectedWorkers[index].Values.First().Level.ToString();
				if (curSelectedWorkers[index].Values.First().Status == InvitedWorkerActivateStatus.Activated)
				{
					((GComponent)uI_PatronBtn).GetChild("IconBtn").touchable = false;
					uI_PatronBtn.Status.selectedIndex = 1;
					((GComponent)uI_PatronBtn).GetChild("gainBtn").onClick.Set(new EventCallback0(ShowHelpPanel));
				}
				else
				{
					((GComponent)uI_PatronBtn).GetChild("IconBtn").touchable = true;
					uI_PatronBtn.Status.selectedIndex = 0;
					((GComponent)uI_PatronBtn).GetChild("leaseBtn").data = index;
					((GComponent)uI_PatronBtn).GetChild("leaseBtn").onClick.Set(new EventCallback1(LeaseWorker));
				}
			}
			else if (Enumerable.First(curSelectedWorkers.ToList()[index].Value).Key != -1)
			{
				((GObject)uI_PatronBtn).data = Enumerable.First(curSelectedWorkers.ToList()[index].Value);
				((GComponent)uI_PatronBtn).GetChild("IconBtn").touchable = true;
				uI_PatronBtn.Status.selectedIndex = 0;
				int num3 = (int)(curSelectedWorkers[index].Values.First().ExpireAt - DateTimeHelper.Now).TotalDays;
				int num4 = (int)(curSelectedWorkers[index].Values.First().ExpireAt - DateTimeHelper.Now).TotalSeconds;
				if (num4 >= 86400)
				{
					uI_PatronBtn.InviterStatus.selectedIndex = 0;
				}
				else
				{
					uI_PatronBtn.InviterStatus.selectedIndex = 1;
				}
				((GObject)uI_PatronBtn.inviterStatusText).text = ((num3 > 365) ? LanguagesManager.GetDesc("CsharpCodeZhTcText359") : (LanguagesManager.GetDesc("CsharpCodeZhTcText227") + UiHelper.ParseTimeChnForGift(num4)));
				((GObject)uI_PatronBtn.name).text = curSelectedWorkers[index].Values.First().Nickname ?? "";
				if (string.IsNullOrWhiteSpace(curSelectedWorkers[index].Values.First().Avatar))
				{
					uI_PatronBtn.IconBtn.HeadPortrait.icon.url = "ui://PublicResources/Clap1";
				}
				else
				{
					UiHelper.GetImageByUnityWebRequest(uI_PatronBtn.IconBtn.HeadPortrait.icon, curSelectedWorkers[index].Values.First().Avatar);
				}
				((GObject)uI_PatronBtn.level).text = curSelectedWorkers[index].Values.First().Level.ToString();
				((GComponent)uI_PatronBtn).GetChild("IconBtn").data = index;
				((GComponent)uI_PatronBtn).GetChild("IconBtn").onClick.Set(new EventCallback1(InvitedWorkersPanelInit));
				((GComponent)uI_PatronBtn).GetChild("leaseBtn").data = index;
				((GComponent)uI_PatronBtn).GetChild("leaseBtn").onClick.Set(new EventCallback1(LeaseWorker));
			}
			else
			{
				uI_PatronBtn.Status.selectedIndex = 2;
				((GObject)uI_PatronBtn.tip).text = LanguagesManager.GetDesc("CsharpCodeZhTcText360");
				((GComponent)uI_PatronBtn).GetChild("InviteBtn").onClick.Set(new EventCallback1(InviteTip));
			}
			return;
		}
		uI_PatronBtn.Status.selectedIndex = 3;
		bool flag = invitingSlotUnlockRequiredUserLevelDict.ContainsKey(index + 1);
		string text = "";
		if (flag)
		{
			text = invitingSlotUnlockRequiredUserLevelDict[index + 1].ToString();
		}
		else
		{
			foreach (KeyValuePair<int, int> item in invitingSlotUnlockRequiredUserLevelDict)
			{
				if (item.Value > index + 1)
				{
					text = item.Value.ToString();
				}
			}
		}
		((GObject)uI_PatronBtn.tip).text = text + LanguagesManager.GetDesc("CsharpCodeZhTcText363");
	}

	private void ShowHelpPanel()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		HelpPanel = UI_HelpPanel.CreateInstance();
		((GObject)HelpPanel.Dialog).SetXY(1034f, 564f);
		((GObject)HelpPanel.Mask).onClick.Add(new EventCallback0(CloseHelpPanel));
		((GComponent)GRoot.inst).AddChild((GObject)(object)HelpPanel);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)HelpPanel);
		HelpPanel.ShowDialog.Play();
	}

	private void CloseHelpPanel()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)HelpPanel.Mask).onClick.Remove(new EventCallback0(CloseHelpPanel));
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)HelpPanel, true);
	}

	private IEnumerator RefreshPatronListRemaining()
	{
		while (true)
		{
			for (int i = 0; i < PatronPanel.PatronList.numItems; i++)
			{
				KeyValuePair<int, InvitedWorker> keyValuePair = (KeyValuePair<int, InvitedWorker>)((GObject)((GComponent)PatronPanel.PatronList).GetChildAt(i).asButton).data;
				int num = (int)(keyValuePair.Value.ExpireAt - DateTimeHelper.Now).TotalDays;
				int num2 = (int)(keyValuePair.Value.ExpireAt - DateTimeHelper.Now).TotalSeconds;
				if (num2 >= 86400)
				{
					((GComponent)((GComponent)PatronPanel.PatronList).GetChildAt(i).asButton).GetController("InviterStatus").selectedIndex = 0;
				}
				else
				{
					((GComponent)((GComponent)PatronPanel.PatronList).GetChildAt(i).asButton).GetController("InviterStatus").selectedIndex = 1;
				}
				((GComponent)((GComponent)PatronPanel.PatronList).GetChildAt(i).asButton).GetChild("inviterStatusText").text = ((num > 365) ? LanguagesManager.GetDesc("CsharpCodeZhTcText359") : (LanguagesManager.GetDesc("CsharpCodeZhTcText227") + UiHelper.ParseTimeChnForGift(num2)));
			}
		}
	}

	private IEnumerator RefreshFriendsListRemaining()
	{
		while (true)
		{
			if (InvitedWorkersPanel == null)
			{
				continue;
			}
			for (int i = 0; i < InvitedWorkersPanel.Dialog.FriendsList.numItems; i++)
			{
				int key = Convert.ToInt32(((GObject)((GComponent)InvitedWorkersPanel.Dialog.FriendsList).GetChildAt(i).asButton).data);
				if (curInvitedWorkers.ContainsKey(key))
				{
					int time = (int)(curInvitedWorkers[key].ExpireAt - DateTimeHelper.Now).TotalSeconds;
					((GComponent)((GComponent)InvitedWorkersPanel.Dialog.FriendsList).GetChildAt(i).asButton).GetChild("time").text = UiHelper.ParseTimeChnForGift(time) ?? "";
				}
			}
		}
	}

	private async void LeaseWorker(EventContext context)
	{
		Vector2 aimXy = ((GObject)context.sender).TransformPoint(Vector2.one / 2f, (GObject)(object)this);
		int selectIndex = Convert.ToInt32(((GObject)context.sender).data);
		KeyValuePair<int, InvitedWorker> selectUser = (KeyValuePair<int, InvitedWorker>)((GObject)((GComponent)PatronPanel.PatronList).GetChildAt(selectIndex).asButton).data;
		if ((await GameController.Contexts.Service<INetworkService>().ActivateInvitedWorker(selectUser.Key)).Result)
		{
			selectUser.Value.Status = InvitedWorkerActivateStatus.Activated;
			if (GameManagers.Instance.FriendsManager.InvitedWorkers.TryGetValue(selectUser.Key, out var invitedWorker))
			{
				invitedWorker.Status = InvitedWorkerActivateStatus.Activated;
			}
			PlayMissileSfx(aimXy);
			RenderPatronPanel();
		}
	}

	private void PlayMissileSfx(Vector2 aimXy)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		((GObject)missibleSfxBack).SetXY(aimXy.x, aimXy.y);
		((GObject)missibleSfxBack).SetPivot(0.5f, 0.5f, true);
		FGUIManager.Instance.AddTextSpecialEffects(missibleSfxBack, "exp_missile_green", Vector3.zero);
		((GObject)missibleSfxBack).TweenMove(((GObject)missbleEndPos).xy, 0.5f).OnComplete((GTweenCallback)delegate
		{
			UpdateManPower(addWorkerBtn);
		});
		UiAudioManager.Instance.PlaySoundEffect("Missile");
	}

	private void CumulativeAimAchievementListSort()
	{
		MissionSerialActivityPayload missionSerialActivityPayload = (MissionSerialActivityPayload)CumulativeCostActivity.ContentPayload(GameManagers.Instance).Values.First();
		List<Mission> list = new List<Mission>();
		list.AddRange(missionSerialActivityPayload.Missions(GameManagers.Instance));
		curRechargeAimAchievementList.Clear();
		float totalRecharge = GameManagers.Instance.UserArchiveManager.GetTotalRecharge();
		int rechargeThreshold = 500;
		if (totalRecharge >= 5000f)
		{
			rechargeThreshold = 50000;
		}
		else if (totalRecharge >= 500f)
		{
			rechargeThreshold = 5000;
		}
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			rechargeThreshold = 7800;
			if (totalRecharge >= 75000f)
			{
				rechargeThreshold = 750000;
			}
			else if (totalRecharge >= 7800f)
			{
				rechargeThreshold = 75000;
			}
		}
		else
		{
			int[] array = new int[9] { 30000, 50000, 100000, 200000, 300000, 400000, 500000, 600000, 700000 };
			int[] array2 = new int[9] { 60000, 100000, 200000, 300000, 400000, 500000, 600000, 700000, 800000 };
			for (int i = 0; i < array.Length; i++)
			{
				if (totalRecharge >= (float)array[i])
				{
					rechargeThreshold = array2[i];
				}
			}
		}
		IEnumerable<Mission> collection = list.Where((Mission a) => a.MissionState(GameManagers.Instance).Status == MissionStatus.Completed);
		IEnumerable<Mission> collection2 = list.Where((Mission a) => a.MissionState(GameManagers.Instance).Status == MissionStatus.Claimed);
		IEnumerable<Mission> collection3 = list.Where((Mission a) => a.MissionState(GameManagers.Instance).Status == MissionStatus.Undergoing && a.TargetValue(GameManagers.Instance) <= (float)rechargeThreshold);
		curRechargeAimAchievementList.AddRange(collection);
		curRechargeAimAchievementList.AddRange(collection3);
		curRechargeAimAchievementList.AddRange(collection2);
	}

	private void UpdateCumulativeAchievenments(int num)
	{
		for (int num2 = RechargeAchievementList.Count - 1; num2 >= 0; num2--)
		{
			GButton val = RechargeAchievementList[num2];
			RechargeAchievementList.RemoveAt(num2);
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)val);
			((GObject)val).Dispose();
		}
		for (int i = 0; i < num; i++)
		{
			GButton val2 = (GButton)(object)UI_RechargeAimBtn.CreateInstance();
			((GComponent)GRoot.inst).AddChild((GObject)(object)val2);
			((GComponent)CumulativeCostPanel.AchievementList).AddChild((GObject)(object)val2);
			((GObject)val2).SetXY(0f, (float)i * 143f);
			RechargeAchievementList.Add(val2);
			RenderCumulativeAchievementCard(i, val2);
		}
		for (int j = 0; j < RechargeAchievementList.Count; j++)
		{
			if (j != 0)
			{
				((GObject)RechargeAchievementList[j]).AddRelation((GObject)(object)RechargeAchievementList[j - 1], (RelationType)9);
			}
			else
			{
				((GObject)RechargeAchievementList[j]).relations.ClearAll();
			}
		}
	}

	private void RenderCumulativeAchievementCard(int index, GButton button)
	{
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		float num = curRechargeAimAchievementList[index].TargetValue(GameManagers.Instance);
		float num2 = curRechargeAimAchievementList[index].CurrentValue(GameManagers.Instance);
		string text = $"{Convert.ToInt32(num)}";
		string text2 = $"{Convert.ToInt32(num2)}";
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			text = $"{num / 100f:F2}";
			text2 = $"{num2 / 100f:F2}";
		}
		((GComponent)button).GetController("rewardStyle").selectedIndex = 0;
		button.title = curRechargeAimAchievementList[index].Data.Desc ?? "";
		((GObject)((GComponent)button).GetChild("num").asTextField).text = text2 + "/" + text;
		Controller controller = ((GComponent)button).GetController("ReceiveStatus");
		if (curRechargeAimAchievementList[index].MissionState(GameManagers.Instance).Status == MissionStatus.Undergoing)
		{
			controller.selectedIndex = 0;
		}
		if (curRechargeAimAchievementList[index].MissionState(GameManagers.Instance).Status == MissionStatus.Completed)
		{
			controller.selectedIndex = 1;
		}
		if (curRechargeAimAchievementList[index].MissionState(GameManagers.Instance).Status == MissionStatus.Claimed)
		{
			controller.selectedIndex = 2;
		}
		if (curRechargeAimAchievementList[index].BonusList != null && curRechargeAimAchievementList[index].BonusList.Count > 0)
		{
			((GObject)((GComponent)button).GetChild("receiveBtn").asButton).data = index;
			((GComponent)button).GetChild("rewardList").asList.itemRenderer = new ListItemRenderer(RenderRechargeAchievementReward);
			((GComponent)button).GetChild("rewardList").asList.numItems = curRechargeAimAchievementList[index].BonusList.Count;
			((GComponent)((GComponent)button).GetChild("receiveBtn").asButton).GetChild("note").visible = curRechargeAimAchievementList[index].CanClaimBonus(GameManagers.Instance);
			((GObject)((GComponent)button).GetChild("receiveBtn").asButton).onClick.Set(new EventCallback1(GetRechargeReward));
			((GObject)((GComponent)button).GetChild("receiveBtn").asButton).enabled = curRechargeAimAchievementList[index].CanClaimBonus(GameManagers.Instance);
		}
	}

	private void RenderRechargeAchievementReward(int index, GObject obj)
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected O, but got Unknown
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		GComponent asCom = obj.asCom;
		int index2 = (int)((GObject)((GObject)((GObject)asCom).parent).asList).parent.GetChild("receiveBtn").data;
		((GObject)asCom.GetChild("rewardNum").asTextField).text = curRechargeAimAchievementList[index2].BonusList[index].Qty.ShortNumberFormat() ?? "";
		asCom.GetChild("rewardNum").asTextField.strokeColor = new Color(0f, 0f, 0f, 0.55f);
		Bonus bonus = curRechargeAimAchievementList[index2].BonusList[index];
		string itemId = bonus.ItemId;
		if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 3)
		{
			FGUIManager.Instance.SetItemIconAndFrame(asCom.GetChild("rewardIcon").asLoader, itemId, textureList);
		}
		else
		{
			FGUIManager.Instance.SetItemIconAndFrame(asCom.GetChild("rewardIcon").asLoader, itemId, null, "", frameVisible: false);
		}
		if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 10 || Shift.Legion.Common.Models.Item.ItemType(itemId) == 3)
		{
			((GObject)asCom.GetChild("rewardIcon").asLoader).SetScale(0.75f, 0.75f);
		}
		((GObject)asCom.GetChild("rewardIcon").asLoader).onClick.Set((EventCallback0)delegate
		{
			if (!FGUIManager.TryShowOptionalBlueprint(itemId))
			{
				FGUIManager.Instance.ItemTip(itemId, 2, noCheckBtn: false, reserveRes: false, this);
			}
		});
		if (bonus.IsShining == 2 && curRechargeAimAchievementList[index2].MissionState(GameManagers.Instance).Status != MissionStatus.Claimed)
		{
			((GObject)asCom.GetChild("fxBack").asGraph).displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(asCom.GetChild("fxBack").asGraph, "activated_fx", new Vector3(75f, 75f, 75f));
		}
		else
		{
			((GObject)asCom.GetChild("fxBack").asGraph).displayObject.Dispose();
		}
	}

	private void GetRechargeReward(EventContext eventContext)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		int index = (int)((GObject)(GButton)eventContext.sender).data;
		Mission mission = curRechargeAimAchievementList[index];
		ILRequestHelper<MissionClaimResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().MissionClaim(mission.Id), delegate(MissionClaimResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				SharedMessenger.Broadcast("MISSION_CLAIMED", mission);
				if (response.BonusList != null && response.BonusList.Count > 0)
				{
					FGUIManager.Instance.ClaimBonusFromApiModels(response.BonusList);
					ThinkingDataHelper.Instance.TotalRewardTrack(mission.TargetValue(GameManagers.Instance));
					RechargeAchievenmentClaimed(index);
					UpdatePanelShowNote(null);
					UpdateMoneyAndGemNum(response.BonusList);
				}
				else
				{
					List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText234") };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, 103, arg3: false);
				}
			}
		});
	}

	private void RenderRechargeAchievementList()
	{
		for (int i = 0; i < RechargeAchievementList.Count; i++)
		{
			RenderCumulativeAchievementCard(i, RechargeAchievementList[i]);
		}
	}

	private void RechargeAchievenmentClaimed(int index)
	{
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		((GObject)CumulativeCostPanel).touchable = false;
		GButton button = RechargeAchievementList[index];
		GList asList = ((GComponent)button).GetChild("rewardList").asList;
		for (int i = 0; i < asList.numItems; i++)
		{
			if (!((GComponent)asList).GetChildAt(i).asCom.GetChild("fxBack").displayObject.isDisposed)
			{
				((GComponent)asList).GetChildAt(i).asCom.GetChild("fxBack").displayObject.Dispose();
			}
		}
		((GObject)button).relations.ClearAll();
		if (index != RechargeAchievementList.Count - 1)
		{
			((GObject)RechargeAchievementList[index + 1]).RemoveRelation((GObject)(object)button, (RelationType)9);
		}
		RechargeAchievementList.RemoveAt(index);
		GTweenCallback val = default(GTweenCallback);
		((GComponent)button).GetTransition("disappear").Play((PlayCompleteCallback)delegate
		{
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Expected O, but got Unknown
			//IL_00ea: Expected O, but got Unknown
			RechargeAchievementList.Add(button);
			((GObject)button).SetXY(0f, (float)(RechargeAchievementList.Count * 143));
			((GObject)button).AddRelation((GObject)(object)RechargeAchievementList[RechargeAchievementList.Count - 2], (RelationType)9);
			((GObject)button).alpha = 1f;
			CumulativeAimAchievementListSort();
			RenderRechargeAchievementList();
			GTweener obj = ((GObject)RechargeAchievementList[index]).TweenMoveY((float)(index * 143), 0.5f).SetEase((EaseType)5);
			GTweenCallback obj2 = val;
			if (obj2 == null)
			{
				GTweenCallback val2 = delegate
				{
					if (index != 0)
					{
						((GObject)RechargeAchievementList[index]).AddRelation((GObject)(object)RechargeAchievementList[index - 1], (RelationType)9);
					}
					((GObject)CumulativeCostPanel).touchable = true;
				};
				GTweenCallback val3 = val2;
				val = val2;
				obj2 = val3;
			}
			obj.OnComplete(obj2);
			HiddenRechargeAchievementSFX();
		});
	}

	private void HiddenRechargeAchievementSFX()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(0f, 6f);
		Vector2 val2 = ((GObject)CumulativeCostPanel.AimAchievementListTop).LocalToRoot(Vector2.zero, GRoot.inst);
		Vector2 val3 = ((GObject)CumulativeCostPanel.AimAchievementListBottom).LocalToRoot(Vector2.zero, GRoot.inst);
		for (int i = 0; i < RechargeAchievementList.Count; i++)
		{
			Vector2 val4 = ((GObject)RechargeAchievementList[i]).LocalToRoot(Vector2.zero, GRoot.inst);
			bool visible = ((!(val4.y < val2.y + val.y) && !(val4.y > val3.y - ((GObject)RechargeAchievementList[i]).height + val.y)) ? true : false);
			GList asList = ((GComponent)RechargeAchievementList[i]).GetChild("rewardList").asList;
			for (int j = 0; j < asList.numItems; j++)
			{
				if (!((GComponent)asList).GetChildAt(j).asCom.GetChild("fxBack").displayObject.isDisposed)
				{
					((GComponent)asList).GetChildAt(j).asCom.GetChild("fxBack").displayObject.visible = visible;
				}
			}
		}
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		if (TimeLimitRemainingCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(TimeLimitRemainingCoroutine);
		}
		if (PatronListRemainingCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(PatronListRemainingCoroutine);
		}
		if (FriendsListRemainingCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(FriendsListRemainingCoroutine);
		}
		if (BlackMarketTreasureTimeRemainingCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(BlackMarketTreasureTimeRemainingCoroutine);
		}
		UiHelper.ReleaseUnityWebRequestImage();
		OnDestroySecretTreasury();
		OnDestroySpinWeek();
		OnDestroyWeekActPass();
		OnDestroyShadowDemonActivity();
		DeparturePresentPanel.OnDestroy();
		UiTagManager.Instance.Unregister("ActivityPanelBackBtn");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 1;
		_TabNote = new Dictionary<string, GObject>();
		if (parameters.TryGetValue("SortingOrder", out var value))
		{
			((GObject)this).sortingOrder = (int)value;
		}
		if (parameters.TryGetValue("Parent", out var value2))
		{
			parentUiController = (IUiController)value2;
		}
		if (parameters.TryGetValue("Tab", out var value3))
		{
			tabIndex = (int)value3;
		}
		for (int i = 0; i < ((GComponent)ActTabList).numChildren; i++)
		{
			string pageName = PageController.GetPageName(i);
			_oriTabOrderInfo.Add(pageName, new tabInfo
			{
				TabObject = ((GComponent)ActTabList).GetChildAt(i),
				TabName = pageName,
				OriTabIdx = i,
				CurTabIdx = i
			});
		}
		if (parameters.ContainsKey("TabFilter"))
		{
			TabFilter = (List<string>)parameters["TabFilter"];
			foreach (string item in _oriTabOrderInfo.Keys.ToList())
			{
				if (!TabFilter.Contains(item))
				{
					_oriTabOrderInfo.Remove(item);
				}
			}
		}
		else
		{
			TabFilter = new List<string>();
		}
		if (parameters.TryGetValue("TabFilterType", out var value4))
		{
			_tabFilterType = (ActivityEntranceMode)value4;
		}
		else
		{
			_tabFilterType = ActivityEntranceMode.Rewards;
		}
		if (_tabFilterType == ActivityEntranceMode.NewcomerSpecial || _tabFilterType == ActivityEntranceMode.NewForeignNewcomerSpecial)
		{
			HashSet<string> hashSet = new HashSet<string>(TabFilter);
			hashSet.ExceptWith(SpinWeekActivities);
			if (hashSet.Count <= 0)
			{
				_tabFilterType = ActivityEntranceMode.SpinWeek;
			}
		}
		if (parameters.TryGetValue("GoToCertification", out var value5))
		{
			NeedGoToCertification = (bool)value5;
		}
		if (parameters.TryGetValue("Type", out var value6))
		{
			Type.selectedIndex = (int)value6;
			((GObject)exit).onClick.Set(new EventCallback0(End));
		}
		if (parameters.TryGetValue("TaskCompletionSource", out var value7))
		{
			_taskCompleteOnClose = (TaskCompletionSource<bool>)value7;
		}
		if (GameController.Configs.TryGetValue("PatP", out var value8) && value8 == "0")
		{
			showPatron = false;
		}
		else
		{
			showPatron = true;
		}
		if (GameController.Configs.TryGetValue("SF21", out var value9) && value9 == "1")
		{
			showSpringFestivalTab = true;
		}
		else
		{
			showSpringFestivalTab = false;
		}
		UiTagManager.Instance.Register("ActivityPanelBackBtn", backBtn);
		((GObject)ActTabList).visible = false;
		SetBuildingName(parameters.TryGetValue("TitleName", out var value10) ? value10.ToString() : string.Empty);
		IUiService uiService = Contexts.sharedInstance.Service<IUiService>();
		int changeId = uiService.SetUiNotTouchable(Name);
		uiService.ShowWaitingAnimation(show: true);
		GameManagers.Instance.ActivityManager.CheckActivities(null, new List<ActivityType>
		{
			ActivityType.HomePageActivity,
			ActivityType.Funds
		}, delegate
		{
			HomePageActivity = GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.HomePageActivity);
			HomePageActivity.AddRange(GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.Funds));
			if (HotUpdateProcess.Instance.IsRegionOutCN)
			{
				HomePageActivity.AddRange(GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.IntlRechargeStatsSubstitute));
				for (int num = HomePageActivity.Count - 1; num >= 0; num--)
				{
					Activity activity = HomePageActivity[num];
					if (GameManagers.Instance.UserArchiveManager.IsForeignNewGuideMode() && activity.ActivityId == "MissionsOf7Days1")
					{
						HomePageActivity.RemoveAt(num);
					}
				}
			}
			RenderFirstTimeRewardPanel();
			RenderSevenDaysMissionPanel();
			RenderSignInPanel(isInit: true);
			RenderCumulativeCostPanel();
			RenderBlackMarketTreasurePanel();
			RenderDailySignInPanel();
			RenderChipFundPanel();
			RenderGemFundPanel();
			RenderGrowthFundPanel();
			RenderLegendItemFundPanel();
			RenderLegionCultivateFundPanel();
			RenderPatronPanel(isInit: true);
			RenderSpringFestival21();
			RenderCertificationPanel();
			ActivityTabInit();
			InitSecretTreasury();
			RenderSpinWeekActivity();
			RenderWeekActPass();
			InitShadowDemonActivity();
			SetActivityTabStatus();
			HiddenSFX();
			HiddenRechargeAchievementSFX();
			if (TimeLimitRemainingCoroutine != null)
			{
				FGUIManager.Instance.CloseIEnumerator(TimeLimitRemainingCoroutine);
			}
			TimeLimitRemainingCoroutine = FGUIManager.Instance.OpenIEnumerator(RefreshTimeLimitRemaining());
			UpdatePanelShowNote(null);
			uiService.ShowWaitingAnimation(show: false);
			uiService.SetUiTouchable(changeId);
			SharedMessenger.Broadcast("SPECIAL_OPEN_UI", Name);
		});
	}

	public void OnShow()
	{
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
	}

	public void TryBringToFont()
	{
		if (((GObject)((GObject)this).parent).parent != null && ((GObject)((GObject)this).parent).parent is Window)
		{
			GComponent parent = ((GObject)((GObject)this).parent).parent;
			Window val = (Window)(object)((parent is Window) ? parent : null);
			val.BringToFront();
			((GObject)val).sortingOrder = 3000;
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Expected O, but got Unknown
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Expected O, but got Unknown
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Expected O, but got Unknown
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Expected O, but got Unknown
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected O, but got Unknown
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Expected O, but got Unknown
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Expected O, but got Unknown
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_0441: Expected O, but got Unknown
		//IL_0459: Unknown result type (might be due to invalid IL or missing references)
		//IL_0463: Expected O, but got Unknown
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_048a: Expected O, but got Unknown
		//IL_049d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Expected O, but got Unknown
		((GObject)backBtn).onClick.Add(new EventCallback0(End));
		((GObject)SignInPanel.TurnPageLeftBtn).onClick.Add(new EventCallback0(SignInListScrollLeft));
		((GObject)SignInPanel.TurnPageRightBtn).onClick.Add(new EventCallback0(SignInListScrollRight));
		addDiamondBtn.GetChild("addButton").onClick.Add(new EventCallback0(DiamondBtnEvent));
		addCouponBtn.GetChild("addButton").onClick.Add(new EventCallback0(MoneyBtnEvent));
		((GObject)addWorkerBtn).onClick.Add(new EventCallback0(OpenWorkerOverview));
		addWorkerBtn.GetChild("addButton").onClick.Add(new EventCallback1(WorkerBtnEvent));
		addWorkerBtn.GetChild("ExclamationMarkBtn").onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)FirstTimeRewardPanel.RechargeBtn).onClick.Add(new EventCallback1(FirstRecharge));
		SetupDayTabsForRechargeCombo();
		((GObject)CertificationPanel.certificationBtn).onClick.Add(new EventCallback0(CertificationEvent));
		((GObject)CertificationPanel.CertificationGiftPack).onClick.Add(new EventCallback1(ClaimVerifyIdentityBonus));
		((GComponent)SevenDaysMissionPanel.MissionAchievementList).scrollPane.onScroll.Add(new EventCallback0(HiddenSFX));
		((GComponent)CumulativeCostPanel.AchievementList).scrollPane.onScroll.Add(new EventCallback0(HiddenRechargeAchievementSFX));
		((GComponent)GrowthFundPanel.AchievementList).scrollPane.onScroll.Add(new EventCallback0(HiddenrGrowthAchievementSFX));
		((GObject)DailySignPanel.ReceiveClick).onClick.Add(new EventCallback1(ReceiveDailySignBonus));
		((GObject)ChipFundPanel.InvestBtn).onClick.Add(new EventCallback1(ShowGiftBag));
		((GObject)GemFundPanel.InvestBtn).onClick.Add(new EventCallback1(ShowGiftBag));
		((GObject)GrowthFundPanel.Invest).onClick.Add(new EventCallback1(ShowGiftBag));
		((GObject)LegendItemFundPanel.InvestBtn).onClick.Add(new EventCallback1(ShowGiftBag));
		((GObject)LegionCultivateFundPanel.InvestBtn).onClick.Add(new EventCallback1(ShowGiftBag));
		PageController.onChanged.Set(new EventCallback0(OnPageChanged));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<Mission>("MISSION_COMPLETE", UpdatePanelShowNote);
		SharedMessenger.AddListener<Cache_OrcActivityRedDot>(Cache_OrcActivityRedDot.ON_REDDOT_CHANGE, OnOrcTabRedDotChange);
		SharedMessenger.AddListener<Cache_NoviceRechargeRedDot>("Cache_NoviceRechargeRedDot", OnNoviceRechargeRedDotChange);
		SharedMessenger.AddListener<Cache_DeparturePresentRedDot>("ON_DEPARTURE_PRESENT_RED_DOT_CHANGE", OnDeparturePresentRedDotChange);
		SharedMessenger.AddListener<Cache_BlackMarketTreasureRedDot>(Cache_BlackMarketTreasureRedDot.ON_REDDOT_CHANGE, OnBlackMarketTreasureRedDotChange);
		SharedMessenger.AddListener("OPEN_WORKER_OVERVIEW_PANEL", OpenWorkerOverview);
		SharedMessenger.AddListener<float>("ON_RECHARGE", OnRecharge);
		SharedMessenger.AddListener<string>("CLOSE_UI", OnUiClosed);
		SharedMessenger.AddListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OrderShipSuccessEvent);
		OrcActivityPanel.RegisterUiEventListeners();
		((GObject)BlackMarketTreasurePanel.topUpBtn).onClick.Set(new EventCallback0(OnClickGoTopUp));
		((GObject)CumulativeCostPanel.topUpBtn).onClick.Set(new EventCallback0(OnClickGoTopUp));
		((GObject)SecretTreasuryPanel.showRuleBtn).onClick.Set(new EventCallback0(OnClickShowSecretTreasury));
		((GObject)SecretTreasuryPanel.topupBtn).onClick.Set(new EventCallback0(OnClickGoTopUp));
		((GComponent)SecretTreasuryPanel.AchievementList).scrollPane.onScroll.Set(new EventCallback0(RefreshAchievementSFX));
		((GObject)topMask).onClick.Set(new EventCallback0(OnClickTopMask));
		GameManagers.Instance.Messenger.AddListener<GetWeeklyActivityResponse>("SPIN_WEEK_ACTIVITY_PROGRESS_CHANGE", OnSpinWeekProgressChange);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Expected O, but got Unknown
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Expected O, but got Unknown
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Expected O, but got Unknown
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Expected O, but got Unknown
		((GObject)backBtn).onClick.Remove(new EventCallback0(End));
		((GObject)SignInPanel.TurnPageLeftBtn).onClick.Remove(new EventCallback0(SignInListScrollLeft));
		((GObject)SignInPanel.TurnPageRightBtn).onClick.Remove(new EventCallback0(SignInListScrollRight));
		addDiamondBtn.GetChild("addButton").onClick.Remove(new EventCallback0(DiamondBtnEvent));
		addCouponBtn.GetChild("addButton").onClick.Remove(new EventCallback0(MoneyBtnEvent));
		((GObject)addWorkerBtn).onClick.Remove(new EventCallback0(OpenWorkerOverview));
		addWorkerBtn.GetChild("addButton").onClick.Remove(new EventCallback1(WorkerBtnEvent));
		addWorkerBtn.GetChild("ExclamationMarkBtn").onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)FirstTimeRewardPanel.RechargeBtn).onClick.Remove(new EventCallback1(FirstRecharge));
		DestroyDayTabsForRechargeCombo();
		((GObject)CertificationPanel.certificationBtn).onClick.Remove(new EventCallback0(CertificationEvent));
		((GObject)CertificationPanel.CertificationGiftPack).onClick.Remove(new EventCallback1(ClaimVerifyIdentityBonus));
		((GComponent)SevenDaysMissionPanel.MissionAchievementList).scrollPane.onScroll.Remove(new EventCallback0(HiddenSFX));
		((GComponent)CumulativeCostPanel.AchievementList).scrollPane.onScroll.Remove(new EventCallback0(HiddenRechargeAchievementSFX));
		((GComponent)GrowthFundPanel.AchievementList).scrollPane.onScroll.Remove(new EventCallback0(HiddenrGrowthAchievementSFX));
		((GObject)DailySignPanel.ReceiveClick).onClick.Remove(new EventCallback1(ReceiveDailySignBonus));
		((GObject)ChipFundPanel.InvestBtn).onClick.Remove(new EventCallback1(ShowGiftBag));
		((GObject)GemFundPanel.InvestBtn).onClick.Remove(new EventCallback1(ShowGiftBag));
		((GObject)GrowthFundPanel.Invest).onClick.Remove(new EventCallback1(ShowGiftBag));
		((GObject)LegendItemFundPanel.InvestBtn).onClick.Remove(new EventCallback1(ShowGiftBag));
		((GObject)LegionCultivateFundPanel.InvestBtn).onClick.Remove(new EventCallback1(ShowGiftBag));
		PageController.onChanged.Clear();
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<Mission>("MISSION_COMPLETE", UpdatePanelShowNote);
		SharedMessenger.RemoveListener<Cache_OrcActivityRedDot>(Cache_OrcActivityRedDot.ON_REDDOT_CHANGE, OnOrcTabRedDotChange);
		SharedMessenger.RemoveListener<Cache_NoviceRechargeRedDot>("Cache_NoviceRechargeRedDot", OnNoviceRechargeRedDotChange);
		SharedMessenger.RemoveListener<Cache_DeparturePresentRedDot>("ON_DEPARTURE_PRESENT_RED_DOT_CHANGE", OnDeparturePresentRedDotChange);
		SharedMessenger.RemoveListener<Cache_BlackMarketTreasureRedDot>(Cache_BlackMarketTreasureRedDot.ON_REDDOT_CHANGE, OnBlackMarketTreasureRedDotChange);
		SharedMessenger.RemoveListener("OPEN_WORKER_OVERVIEW_PANEL", OpenWorkerOverview);
		SharedMessenger.RemoveListener<float>("ON_RECHARGE", OnRecharge);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnUiClosed);
		SharedMessenger.RemoveListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OrderShipSuccessEvent);
		OrcActivityPanel.UnregisterUiEventListeners();
		((GObject)BlackMarketTreasurePanel.topUpBtn).onClick.Clear();
		((GObject)CumulativeCostPanel.topUpBtn).onClick.Clear();
		((GObject)SecretTreasuryPanel.showRuleBtn).onClick.Clear();
		((GObject)SecretTreasuryPanel.topupBtn).onClick.Clear();
		((GComponent)SecretTreasuryPanel.AchievementList).scrollPane.onScroll.Clear();
		((GObject)topMask).onClick.Clear();
		GameManagers.Instance.Messenger.RemoveListener<GetWeeklyActivityResponse>("SPIN_WEEK_ACTIVITY_PROGRESS_CHANGE", OnSpinWeekProgressChange);
	}

	public static void UpdateManPower(GComponent addWorkerBtn)
	{
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		addWorkerBtn.GetChild("CurrentWorkerAmount").text = Dungeon.GetFreeManPower(GameManagers.Instance).ToString();
		addWorkerBtn.GetChild("AllWorkerAmount").text = Dungeon.GetTotalManPower(GameManagers.Instance).ToString();
		if (GameManagers.Instance.LeaseholdManager.GetLeaseholdManPower() > 0)
		{
			addWorkerBtn.GetChild("AllWorkerAmount").asTextField.color = Color32.op_Implicit(new Color32((byte)175, (byte)246, (byte)39, byte.MaxValue));
			addWorkerBtn.GetChild("ExclamationMarkBtn").data = new Dictionary<string, object>
			{
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText153") + Environment.NewLine + string.Format("{0}：{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText164"), Dungeon.GetTotalManPower(GameManagers.Instance) - GameManagers.Instance.LeaseholdManager.GetLeaseholdManPower())
				},
				{
					"Pos",
					(object)new Vector2(1718f, 88f)
				}
			};
			addWorkerBtn.GetChild("ExclamationMarkBtn").visible = true;
		}
		else
		{
			addWorkerBtn.GetChild("AllWorkerAmount").asTextField.color = Color32.op_Implicit(new Color32((byte)243, (byte)221, (byte)170, byte.MaxValue));
			addWorkerBtn.GetChild("ExclamationMarkBtn").visible = false;
		}
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

	private void OpenWorkerOverview()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Order", ((GObject)this).sortingOrder);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_WorkersOverviewPanel.Name, dictionary);
	}

	private void OnUiClosed(string uiName)
	{
		if (uiName == UI_BlackMarketerAddCredit.Name || uiName == UI_MtgGiftPacksPanel.Name)
		{
			RefreshUiAfterRecharge();
			UpdatePanelShowNote(null);
		}
	}

	private void RefreshUiAfterRecharge()
	{
		if (FirstTimeRewardIndex != -1)
		{
			RenderFirstTimeRewardPanel();
		}
		if (SevenDaysMissionIndex != -1)
		{
			RenderSevenDaysMissionPanel();
		}
		if (CumulativeCostIndex != -1)
		{
			RenderCumulativeCostPanel();
		}
		if (BlackMarketTreasureIndex != -1)
		{
			RenderBlackMarketTreasurePanel();
		}
		if (_secretTreasuryTabIndex != -1)
		{
			TryRefreshSecretTreasuryUiOnShipSuccessEvent();
		}
	}

	private void OnPageChanged()
	{
		OnPageChangedShowDemon();
	}

	public void ChangePageIndex()
	{
		switch (CurPageName)
		{
		case "UI_DailySignPanel":
			SelectDailySignInPanel();
			break;
		case "UI_PatronPanel":
			SelectPatronPanel();
			break;
		case "UI_SpringFestivalPanel":
			SelectSpringFestival21();
			break;
		case "UI_CertificationPanel":
			SelectCertificationPanel();
			break;
		case "UI_CumulativeCostPanel_New":
			RenderBlackMarketTreasurePanel();
			break;
		case "UI_OrcActivityPanel":
			SelectOrcActivityPanel();
			break;
		case "UI_com_SecretTreasury":
			FGUIManager.Instance.GetDynamicSecretTreasuryActivity(RefreshPanel);
			break;
		}
	}

	private void ActivityTabInit()
	{
		SetButtonTitle();
		NianTabIndex = -1;
		PatronTabIndex = -1;
		CertificationIndex = -1;
		FirstTimeRewardIndex = -1;
		SevenDaysMissionIndex = -1;
		SignInIndex = -1;
		DailySignInIndex = -1;
		ChipFundIndex = -1;
		GemFundIndex = -1;
		GrowthFundIndex = -1;
		LegendItemFundIndex = -1;
		LegionCultivateFundIndex = -1;
		CumulativeCostIndex = -1;
		BlackMarketTreasureIndex = -1;
		_departurePresentIndex = -1;
		_secretTreasuryTabIndex = -1;
		List<int> list = new List<int>();
		for (int i = 0; i < PageController.pageCount; i++)
		{
			string pageName = PageController.GetPageName(i);
			bool flag = true;
			switch (pageName)
			{
			case "UI_PatronPanel":
				flag = showPatron;
				break;
			case "UI_SpringFestivalPanel":
				flag = showSpringFestivalTab;
				break;
			case "UI_CumulativeCostPanel_New":
			{
				DateTimeOffset serverNow = DateTimeHelper.ServerNow;
				flag = BlackMarketTreasureActivity != null && BlackMarketTreasureActivity.GetStatus(GameManagers.Instance) != ActivityStatus.Disabled && serverNow.CompareTo(BlackMarketTreasureActivity.BeginTime[0]) != -1 && serverNow.CompareTo(BlackMarketTreasureActivity.EndTime[0]) != 1 && (blackMarketTreasureRechargeInfo == null || blackMarketTreasureRechargeInfo.EndTime.CompareTo(DateTimeHelper.ServerNow) == 1);
				break;
			}
			case "UI_FirstTimeRewardPanel":
			{
				flag = FirstTimeRewardActivity != null;
				if (flag)
				{
					break;
				}
				NoviceRechargeData noviceRechargeData = FGUIManager.Instance.NoviceRechargeData;
				if (noviceRechargeData != null && RechargeComboActivity != null)
				{
					flag = noviceRechargeData.Progress.Values.Any((ContinuousRechargeBonus bonus) => bonus.BonusStatus != Shift.Legion.ClientApi.Protocol.UserAction.BonusStatus.HasClaimedBonus);
				}
				break;
			}
			case "UI_SevenDaysMissionPanel":
				flag = SevenDayActivity != null;
				break;
			case "UI_SignInPanel":
				flag = SignInActivity != null;
				break;
			case "UI_CertificationPanel":
				flag = !identityVerifyClaimed && !HotUpdateProcess.Instance.IsRegionOutCN;
				break;
			case "UI_ChipFundPanel":
				flag = chipFundActivity != null;
				break;
			case "UI_GemFundPanel":
				flag = gemFundActivity != null;
				break;
			case "UI_GrowthFundPanel":
				flag = growthFundActivity != null;
				break;
			case "UI_LegendItemFundPanel":
				flag = legendItemFundActivity != null;
				break;
			case "UI_LegionCultivateFundPanel":
				flag = legionCultivateFundActivity != null;
				break;
			default:
				if (pageName == UI_OrcActivityPanel.Name)
				{
					flag = UI_OrcActivityPanel.IsAvailable;
					if (flag)
					{
						OrcActivityPanel.Init(this);
					}
				}
				else if (pageName == UI_main_DeparturePresent.Name)
				{
					flag = UI_main_DeparturePresent.UiVisible();
					if (flag)
					{
						DeparturePresentPanel.Init(this);
						DeparturePresentPanel.Render();
					}
				}
				else if (pageName == UI_com_SecretTreasury.Name)
				{
					flag = SecretTreasury?.IsEnable() ?? false;
				}
				else if (pageName == UI_com_SpinWeekSpin.Name)
				{
					flag = HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi.ActivityEntranceController.IsSpinWeekSpinVisible();
				}
				else if (pageName == UI_main_WeekActivityPass.Name)
				{
					flag = HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi.ActivityEntranceController.IsWeekActPassVisible();
				}
				else if (pageName == UI_com_ShadowDemonGift.Name)
				{
					flag = HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi.ActivityEntranceController.IsShadowDemonGiftVisible();
				}
				break;
			}
			if (TabFilter.Count > 0 && !TabFilter.Contains(pageName))
			{
				flag = false;
			}
			if (flag)
			{
				allTabName.Add(PageController.GetPageName(i), i);
			}
			else
			{
				list.Add(i);
			}
		}
		for (int num = ActTabList.numItems - 1; num >= 0; num--)
		{
			if (list.Contains(num))
			{
				((GComponent)ActTabList).RemoveChildAt(num, true);
				list.Remove(num);
				string text = string.Empty;
				foreach (KeyValuePair<string, tabInfo> item in _oriTabOrderInfo)
				{
					if (item.Value.OriTabIdx == num)
					{
						text = item.Key;
					}
				}
				if (!string.IsNullOrEmpty(text))
				{
					_oriTabOrderInfo.Remove(text);
					TabFilter.Remove(text);
				}
			}
		}
		string text2 = string.Empty;
		if (TabFilter.Count > 0)
		{
			for (int num2 = 0; num2 < TabFilter.Count; num2++)
			{
				int num3 = num2;
				tabInfo tabInfo = _oriTabOrderInfo[TabFilter[num2]];
				((GComponent)ActTabList).SetChildIndex(tabInfo.TabObject, num3);
				tabInfo.CurTabIdx = num3;
			}
			foreach (string item2 in TabFilter)
			{
				tabInfo tabInfo2 = _oriTabOrderInfo[item2];
				if (RenderActivityTabBtn(tabInfo2.TabName, tabInfo2.CurTabIdx, tabInfo2.OriTabIdx, tabInfo2.TabObject) && string.IsNullOrEmpty(text2))
				{
					text2 = tabInfo2.TabName;
				}
			}
		}
		else
		{
			int numChildren = ((GComponent)ActTabList).numChildren;
			for (int num4 = 0; num4 < numChildren; num4++)
			{
				RenderActivityTabBtn(allTabName.ToList()[num4].Key, num4, num4, ((GComponent)ActTabList).GetChildAt(num4));
			}
		}
		((GObject)ActTabList).visible = true;
		if (tabIndex == 0)
		{
			PageController.selectedIndex = Enumerable.First(allTabName).Value;
			if (TabFilter.Count > 0 && !string.IsNullOrEmpty(text2))
			{
				PageController.selectedIndex = _oriTabOrderInfo[text2].OriTabIdx;
			}
		}
		else
		{
			PageController.selectedIndex = tabIndex;
		}
		if (DailySignInIndex > -1)
		{
			((GComponent)((GComponent)ActTabList).GetChildAt(DailySignInIndex).asButton).GetChild("note").visible = canDailySign;
		}
	}

	private bool RenderActivityTabBtn(string tabName, int curIndex, int oriIndex, GObject obj)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		UI_ActTabs uI_ActTabs = obj.asButton as UI_ActTabs;
		((GComponent)uI_ActTabs).GetController("backController").selectedIndex = oriIndex % 2;
		((GObject)uI_ActTabs).data = oriIndex;
		((GObject)uI_ActTabs).onClick.Set(new EventCallback1(ActivityTabClick));
		GObject child = ((GComponent)uI_ActTabs).GetChild("note");
		bool flag = GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1001").Contains("P105");
		bool flag2 = GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1001").Contains("P120");
		bool flag3 = GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1002").Contains("P205");
		bool flag4 = GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1002").Contains("P215");
		bool flag5 = GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1006").Contains("P610");
		if (tabName == "UI_CumulativeCostPanel")
		{
			CumulativeCostIndex = curIndex;
			if (CumulativeCostActivity.LevelCase.All((string levelId) => GameManagers.Instance.UserArchiveManager.IsLevelCompleted(levelId)))
			{
				((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 0;
				((GObject)uI_ActTabs).touchable = true;
			}
			else
			{
				((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 1;
				((GComponent)uI_ActTabs).GetController("TipFormat").selectedIndex = 10;
				((GObject)uI_ActTabs).touchable = false;
			}
		}
		else
		{
			switch (tabName)
			{
			case "UI_CumulativeCostPanel_New":
				BlackMarketTreasureIndex = curIndex;
				_bmTab = uI_ActTabs;
				((GComponent)uI_ActTabs).GetController("TipFormat").selectedIndex = 9;
				if (BlackMarketTreasureActivity.LevelCase.All((string levelId) => GameManagers.Instance.UserArchiveManager.IsLevelCompleted(levelId)))
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 0;
					((GObject)uI_ActTabs).touchable = true;
					bool flag6 = (child.visible = CacheManager.Instance.Get<Cache_BlackMarketTreasureRedDot>().IsShowRedDot);
					_TabNote.Add(Cache_BlackMarketTreasureRedDot.ON_REDDOT_CHANGE, child);
					((GObject)uI_ActTabs.cornerMark).visible = !flag6;
					((GObject)uI_ActTabs.timeLimit).visible = true;
				}
				else
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 1;
					((GObject)uI_ActTabs).touchable = false;
				}
				break;
			case "UI_PatronPanel":
				PatronTabIndex = curIndex;
				if (flag3)
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 0;
					((GObject)uI_ActTabs).touchable = true;
				}
				else
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 1;
					((GObject)uI_ActTabs).touchable = false;
				}
				break;
			case "UI_SpringFestivalPanel":
				NianTabIndex = curIndex;
				if (flag4)
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 0;
					((GObject)uI_ActTabs).touchable = true;
				}
				else
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 1;
					((GObject)uI_ActTabs).touchable = false;
				}
				break;
			case "UI_CertificationPanel":
				CertificationIndex = curIndex;
				if (NeedGoToCertification)
				{
					tabIndex = curIndex;
				}
				break;
			case "UI_FirstTimeRewardPanel":
			{
				FirstTimeRewardIndex = curIndex;
				if (flag)
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 0;
					((GObject)uI_ActTabs).touchable = true;
				}
				else
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 1;
					((GObject)uI_ActTabs).touchable = false;
				}
				((GComponent)uI_ActTabs).GetController("TipFormat").selectedIndex = 11;
				MissionStatus status = FirstTimeRewardMission.MissionState(GameManagers.Instance).Status;
				if (status == MissionStatus.Claimed)
				{
					((GObject)((GObject)uI_ActTabs).asCom.GetChild("title").asTextField).text = LanguagesManager.GetDesc("GameActivity-ActivityPanel-ActTab-title-RechargeCombo");
				}
				bool isShowRedDot4 = CacheManager.Instance.Get<Cache_NoviceRechargeRedDot>().IsShowRedDot;
				child.visible = isShowRedDot4;
				_TabNote.Add("Cache_NoviceRechargeRedDot", child);
				break;
			}
			case "UI_SevenDaysMissionPanel":
				SevenDaysMissionIndex = curIndex;
				break;
			case "UI_SignInPanel":
				SignInIndex = curIndex;
				break;
			case "UI_CumulativeCostPanel":
				CumulativeCostIndex = curIndex;
				break;
			case "UI_DailySignPanel":
				DailySignInIndex = curIndex;
				if (flag)
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 0;
					((GObject)uI_ActTabs).touchable = true;
				}
				else
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 1;
					((GObject)uI_ActTabs).touchable = false;
				}
				((GComponent)uI_ActTabs).GetController("TipFormat").selectedIndex = 11;
				break;
			case "UI_ChipFundPanel":
				ChipFundIndex = curIndex;
				if (flag2)
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 0;
					((GObject)uI_ActTabs).touchable = true;
				}
				else
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 1;
					((GObject)uI_ActTabs).touchable = false;
				}
				((GComponent)uI_ActTabs).GetChild("title").text = ChipFundTabName;
				((GComponent)uI_ActTabs).GetController("TipFormat").selectedIndex = 3;
				break;
			case "UI_LegendItemFundPanel":
				LegendItemFundIndex = curIndex;
				if (flag5)
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 0;
					((GObject)uI_ActTabs).touchable = true;
				}
				else
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 1;
					((GObject)uI_ActTabs).touchable = false;
				}
				((GComponent)uI_ActTabs).GetChild("title").text = LegendItemFundTabName;
				((GComponent)uI_ActTabs).GetController("TipFormat").selectedIndex = 8;
				break;
			case "UI_GemFundPanel":
				GemFundIndex = curIndex;
				if (flag2)
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 0;
					((GObject)uI_ActTabs).touchable = true;
				}
				else
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 1;
					((GObject)uI_ActTabs).touchable = false;
				}
				((GComponent)uI_ActTabs).GetChild("title").text = GemFundTabName;
				((GComponent)uI_ActTabs).GetController("TipFormat").selectedIndex = 3;
				break;
			case "UI_GrowthFundPanel":
				GrowthFundIndex = curIndex;
				if (flag2)
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 0;
					((GObject)uI_ActTabs).touchable = true;
				}
				else
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 1;
					((GObject)uI_ActTabs).touchable = false;
				}
				((GComponent)uI_ActTabs).GetChild("title").text = GrowthFundTabName;
				((GComponent)uI_ActTabs).GetController("TipFormat").selectedIndex = 3;
				break;
			case "UI_LegionCultivateFundPanel":
				LegionCultivateFundIndex = curIndex;
				if (legionCultivateFundActivity.LevelCase.All((string levelId) => GameManagers.Instance.UserArchiveManager.IsLevelCompleted(levelId)))
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 0;
					((GObject)uI_ActTabs).touchable = true;
				}
				else
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 1;
					((GObject)uI_ActTabs).touchable = false;
				}
				((GComponent)uI_ActTabs).GetChild("title").text = LegionCultivateFundTabName;
				((GComponent)uI_ActTabs).GetController("TipFormat").selectedIndex = 11;
				break;
			default:
				if (tabName == UI_OrcActivityPanel.Name)
				{
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 0;
					((GObject)uI_ActTabs).touchable = true;
					((GComponent)uI_ActTabs).GetController("TipFormat").selectedIndex = 3;
					bool isShowRedDot = CacheManager.Instance.Get<Cache_OrcActivityRedDot>().IsShowRedDot;
					child.visible = isShowRedDot;
					_TabNote.Add(Cache_OrcActivityRedDot.ON_REDDOT_CHANGE, child);
				}
				else if (tabName == UI_main_DeparturePresent.Name)
				{
					_departurePresentIndex = curIndex;
					((GComponent)uI_ActTabs).GetChild("title").text = DeparturePresentTabName;
					((GComponent)uI_ActTabs).GetController("Status").selectedIndex = 0;
					((GObject)uI_ActTabs).touchable = true;
					bool isShowRedDot2 = CacheManager.Instance.Get<Cache_DeparturePresentRedDot>().IsShowRedDot;
					child.visible = isShowRedDot2;
					_TabNote.Add("ON_DEPARTURE_PRESENT_RED_DOT_CHANGE", child);
				}
				else if (tabName == UI_com_SecretTreasury.Name)
				{
					_secretTreasuryTabIndex = oriIndex;
					_secretTreasuryNote = uI_ActTabs;
					((GObject)uI_ActTabs).touchable = true;
				}
				else if (tabName == UI_com_SpinWeekSpin.Name)
				{
					_spinWeekNote = uI_ActTabs;
					((GObject)uI_ActTabs).touchable = true;
				}
				else if (tabName == UI_main_WeekActivityPass.Name)
				{
					_weekActTab = uI_ActTabs;
					((GObject)uI_ActTabs).touchable = true;
				}
				else if (tabName == UI_com_ShadowDemonGift.Name)
				{
					_shadowDemonActTab = uI_ActTabs;
					bool touchable = GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1001").Contains("P115");
					((GObject)uI_ActTabs).touchable = touchable;
				}
				break;
			}
		}
		((UI_ActTabs)(object)obj).SetControllerPageText();
		return ((GObject)uI_ActTabs).touchable;
	}

	public void RenderFirstTimeRewardPanel()
	{
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected O, but got Unknown
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected O, but got Unknown
		foreach (Activity item in HomePageActivity)
		{
			if (item.UiName == "UI_FirstTimeRewardPanel")
			{
				FirstTimeRewardActivity = item;
				break;
			}
		}
		List<string> activityIds = new List<string> { FirstTimeRewardActivity.ActivityId };
		if (FirstTimeRewardActivity.ActivityProgress(GameManagers.Instance).IsNew)
		{
			GameManagers.Instance.ActivityManager.ReviewActivities(activityIds);
		}
		MissionSerialActivityPayload missionSerialActivityPayload = (MissionSerialActivityPayload)FirstTimeRewardActivity.ContentPayload(GameManagers.Instance).Values.First();
		FirstTimeRewardMission = missionSerialActivityPayload.Missions(GameManagers.Instance).First();
		if (FirstTimeRewardMission.MissionState(GameManagers.Instance).Status == MissionStatus.Undergoing)
		{
			FirstTimeRewardPanel.PageController.selectedIndex = 0;
			FirstTimeRewardPanel.RechargeStatus.selectedIndex = 0;
		}
		else if (FirstTimeRewardMission.MissionState(GameManagers.Instance).Status == MissionStatus.Completed)
		{
			FirstTimeRewardPanel.PageController.selectedIndex = 0;
			FirstTimeRewardPanel.RechargeStatus.selectedIndex = 1;
		}
		else if (FirstTimeRewardMission.MissionState(GameManagers.Instance).Status == MissionStatus.Claimed)
		{
			((GObject)FirstTimeRewardPanel.RechargeBtn).data = FirstTimeRewardMission;
			FirstTimeRewardActivity = null;
			if (FirstTimeRewardIndex != -1)
			{
				if (ActivityManager.Activities.ContainsKey("NoviceRecharge_Demo"))
				{
					RechargeComboActivity = ActivityManager.Activities["NoviceRecharge_Demo"];
				}
				RenderRechargeCombo();
			}
			return;
		}
		((GObject)FirstTimeRewardPanel).alpha = 1f;
		FirstTimeRewardMissionBonus.Clear();
		FirstTimeRewardMissionBonus.AddRange(FirstTimeRewardMission.BonusList);
		((GObject)FirstTimeRewardPanel.MainReward.price).text = LanguagesManager.GetDesc("CsharpCodeZhTcText210");
		((GObject)FirstTimeRewardPanel.MainReward.num).text = $"{FirstTimeRewardMission.BonusList.First().Qty}";
		FirstTimeRewardPanel.MainReward.num.strokeColor = new Color(0f, 0f, 0f, 0.55f);
		string itemId = FirstTimeRewardMission.BonusList.First().ItemId;
		FirstTimeRewardPanel.MainReward.icon.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
		((GObject)FirstTimeRewardPanel.MainReward.icon).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(FirstTimeRewardMission.BonusList.First().ItemId, 2);
		});
		FirstTimeRewardPanel.rewardList.itemRenderer = new ListItemRenderer(RenderRechargeReward);
		FirstTimeRewardPanel.rewardList.numItems = FirstTimeRewardMissionBonus.Count - 1;
		((GObject)FirstTimeRewardPanel.RechargeBtn).data = FirstTimeRewardMission;
		FirstTimeRewardPanel.SetButtonTitle();
	}

	private void RenderRechargeCombo()
	{
		NoviceRechargeData noviceRechargeData = FGUIManager.Instance.NoviceRechargeData;
		if (noviceRechargeData == null)
		{
			ILRuntimeDebug.LogError("Find No NoviceRechargeData, RenderRechargeCombo Aborted");
			return;
		}
		((GObject)FirstTimeRewardPanel).alpha = 1f;
		FirstTimeRewardPanel.PageController.selectedIndex = 1;
		if (FirstTimeRewardIndex > -1 && ((GComponent)ActTabList).GetChildAt(FirstTimeRewardIndex) is UI_ActTabs uI_ActTabs)
		{
			((GObject)uI_ActTabs.title).text = LanguagesManager.GetDesc("GameActivity-ActivityPanel-ActTab-title-RechargeCombo");
		}
		if (isRenderingRechargeCombo)
		{
			return;
		}
		isRenderingRechargeCombo = true;
		_realRenderRechargeCombo();
		Task<NoviceRechargeData> noviceRechargeData2 = FGUIManager.Instance.GetNoviceRechargeData();
		noviceRechargeData2.GetAwaiter().OnCompleted(delegate
		{
			isRenderingRechargeCombo = false;
			_realRenderRechargeCombo();
			if (FirstTimeRewardIndex > -1)
			{
				bool visible = noviceRechargeData.Progress.Values.Any((ContinuousRechargeBonus _data) => _data.BonusStatus == Shift.Legion.ClientApi.Protocol.UserAction.BonusStatus.CanClaimBonus);
				GObject child = ((GComponent)((GComponent)ActTabList).GetChildAt(FirstTimeRewardIndex).asButton).GetChild("note");
				child.visible = visible;
			}
		});
	}

	private void _realRenderRechargeCombo()
	{
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		for (int i = 0; i < FirstTimeRewardPanel.dayTab.numItems; i++)
		{
			UI_btn_Daychange uI_btn_Daychange = ((GComponent)FirstTimeRewardPanel.dayTab).GetChildAt(i) as UI_btn_Daychange;
			string key = (i + 1).ToString();
			Shift.Legion.ClientApi.Protocol.UserAction.BonusStatus bonusStatus = FGUIManager.Instance.NoviceRechargeData.Progress[key].BonusStatus;
			uI_btn_Daychange.note.selectedIndex = 0;
			switch (bonusStatus)
			{
			case Shift.Legion.ClientApi.Protocol.UserAction.BonusStatus.CanClaimBonus:
				uI_btn_Daychange.note.selectedIndex = 1;
				if (num == -1)
				{
					num = i;
				}
				break;
			case Shift.Legion.ClientApi.Protocol.UserAction.BonusStatus.CanRecharge:
				if (num2 == -1)
				{
					num2 = i;
				}
				break;
			case Shift.Legion.ClientApi.Protocol.UserAction.BonusStatus.Closed:
				if (num3 == -1)
				{
					num3 = i;
				}
				break;
			}
			uI_btn_Daychange.status.selectedIndex = 0;
		}
		int num4 = 0;
		if (num != -1)
		{
			num4 = num;
		}
		else if (num2 != -1)
		{
			num4 = num2;
		}
		else if (num3 != -1)
		{
			num4 = num3;
		}
		UI_btn_Daychange uI_btn_Daychange2 = ((GComponent)FirstTimeRewardPanel.dayTab).GetChildAt(num4) as UI_btn_Daychange;
		uI_btn_Daychange2.status.selectedIndex = 1;
		UpdateFirstTimeRewardPanelBonusByDayNum(num4 + 1);
		UpdateFirstTimeRewardPanelRechargeStatusByDayNum(num4 + 1);
		FirstTimeRewardPanel.SetButtonTitle();
	}

	private void SetupDayTabsForRechargeCombo()
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		UI_btn_Daychange uI_btn_Daychange = null;
		for (int i = 0; i < FirstTimeRewardPanel.dayTab.numItems && ((GComponent)FirstTimeRewardPanel.dayTab).GetChildAt(i) is UI_btn_Daychange uI_btn_Daychange2; i++)
		{
			int num = i + 1;
			((GObject)uI_btn_Daychange2.blur_DayNum).text = string.Format(LanguagesManager.GetDesc("DayNum_PlaceHolder"), num);
			((GObject)uI_btn_Daychange2.focus_DayNum).text = string.Format(LanguagesManager.GetDesc("DayNum_PlaceHolder"), num);
			((GObject)uI_btn_Daychange2).data = i;
			((GObject)uI_btn_Daychange2).onClick.Set(new EventCallback1(onClickFirstTimeRewardPanelDayTab));
		}
	}

	private void DestroyDayTabsForRechargeCombo()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		for (int i = 0; i < FirstTimeRewardPanel.dayTab.numItems && ((GComponent)FirstTimeRewardPanel.dayTab).GetChildAt(i) is UI_btn_Daychange uI_btn_Daychange; i++)
		{
			((GObject)uI_btn_Daychange).onClick.Remove(new EventCallback1(onClickFirstTimeRewardPanelDayTab));
		}
	}

	private void RenderSignInPanel(bool isInit = false)
	{
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		bool flag = false;
		foreach (Activity item in HomePageActivity)
		{
			if (item.UiName == "UI_SignInPanel")
			{
				SignInActivity = item;
				SignInSerialActivityPayload signInSerialActivityPayload = (SignInSerialActivityPayload)SignInActivity.ContentPayload(GameManagers.Instance).Values.First();
				flag = signInSerialActivityPayload.CanSignIn(GameManagers.Instance);
				curSignInDay = (flag ? (signInSerialActivityPayload.TotalSignInCount(GameManagers.Instance) + 1) : signInSerialActivityPayload.TotalSignInCount(GameManagers.Instance));
				SignInList = signInSerialActivityPayload.SignInList;
				break;
			}
		}
		List<string> activityIds = new List<string> { SignInActivity.ActivityId };
		if (SignInActivity.ActivityProgress(GameManagers.Instance).IsNew)
		{
			GameManagers.Instance.ActivityManager.ReviewActivities(activityIds);
		}
		if (isInit)
		{
			if (curSignInDay >= SignInList.Count && !flag && !SignInActivity.CanClaimBonus(GameManagers.Instance))
			{
				SignInActivity = null;
				return;
			}
			((GObject)SignInPanel).alpha = 1f;
		}
		((GObject)SignInPanel.SignInLabelList).data = isInit;
		SignInPanel.SignInLabelList.itemRenderer = new ListItemRenderer(RenderSignInLabel);
		SignInPanel.SignInLabelList.numItems = SignInList.Count;
		int num = 0;
		if (curSignInDay > SignInList.Count)
		{
			num = SignInList.Count - 1;
		}
		else if (curSignInDay - 1 > 0 && curSignInDay <= SignInList.Count)
		{
			num = curSignInDay - 1;
		}
		((GComponent)SignInPanel.SignInLabelList).scrollPane.ScrollToView(((GComponent)SignInPanel.SignInLabelList).GetChildAt(num), false);
		SignInSerialActivityPayload signInSerialActivityPayload2 = (SignInSerialActivityPayload)SignInActivity.ContentPayload(GameManagers.Instance).Values.First();
		float num2 = signInSerialActivityPayload2.TotalSignInCount(GameManagers.Instance);
		foreach (KeyValuePair<float, Dictionary<string, float>> item2 in SignInActivity.BonusProgress)
		{
			if (item2.Key >= SignInActivity.Score(GameManagers.Instance))
			{
				num2 = item2.Key;
				break;
			}
		}
		RenderCumulativeReward();
	}

	private void SelectDailySignInPanel()
	{
		if (timeCoroutine == null)
		{
			timeCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(RefreshDailySignBonusRemaining());
		}
	}

	private void RenderDailySignInPanel()
	{
		canDailySign = false;
		foreach (Activity item in HomePageActivity)
		{
			if (item.UiName == "UI_DailySignPanel")
			{
				dailySignInActivity = item;
				LoopSignInSerialActivityPayload loopSignInSerialActivityPayload = (LoopSignInSerialActivityPayload)dailySignInActivity.ContentPayload(GameManagers.Instance).Values.First();
				canDailySign = loopSignInSerialActivityPayload.CanSignIn(GameManagers.Instance);
				curDailySignInDay = loopSignInSerialActivityPayload.TotalSignInCount(GameManagers.Instance);
				List<SignInBonusData> signInList = loopSignInSerialActivityPayload.SignInList;
				if (curDailySignInDay == 0)
				{
					DailySignBonusDatas = signInList;
					break;
				}
				List<SignInBonusData> range = signInList.GetRange(curDailySignInDay, signInList.Count - curDailySignInDay);
				List<SignInBonusData> range2 = signInList.GetRange(0, curDailySignInDay);
				DailySignBonusDatas.AddRange(range);
				DailySignBonusDatas.AddRange(range2);
				break;
			}
		}
		if (dailySignInActivity == null)
		{
			return;
		}
		List<string> activityIds = new List<string> { dailySignInActivity.ActivityId };
		if (dailySignInActivity.ActivityProgress(GameManagers.Instance).IsNew)
		{
			GameManagers.Instance.ActivityManager.ReviewActivities(activityIds);
		}
		((GObject)DailySignPanel).alpha = 1f;
		LoadDailySignBtns();
		DailySignPanel.Status.selectedIndex = ((!canDailySign) ? 1 : 0);
		if (!canDailySign)
		{
			((GObject)DailySignPanel.Time).visible = true;
			DateTimeOffset dailyRefreshTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
			int num = 24 + (dailyRefreshTime - DateTimeHelper.Now).Hours;
			string desc = LanguagesManager.GetDesc("CsharpCodeZhTcText220");
			if (desc.Contains("{0}"))
			{
				((GObject)DailySignPanel.Time).text = string.Format(desc, num);
			}
			else
			{
				((GObject)DailySignPanel.Time).text = $"{num}{desc}";
			}
		}
		for (int i = 0; i < DailySignBonusDatas.Count && i <= 6; i++)
		{
			RenderDailySignBtn(i);
		}
	}

	private void DailySignBtnMove()
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		DailySignPanel.Status.selectedIndex = 1;
		GButton receivedBtn = ((GComponent)dailySignButtons[0]).GetChild("ReceivedBtn").asButton;
		((GObject)receivedBtn).visible = true;
		GTweenCallback val = default(GTweenCallback);
		GTweenCallback val4 = default(GTweenCallback);
		((GComponent)receivedBtn).GetTransition("stamp").Play((PlayCompleteCallback)delegate
		{
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002f: Expected O, but got Unknown
			GTweener obj = ((GComponent)(object)this).SetTimeout(0.375f);
			GTweenCallback obj2 = val;
			if (obj2 == null)
			{
				GTweenCallback val2 = delegate
				{
					//IL_005c: Unknown result type (might be due to invalid IL or missing references)
					//IL_0061: Unknown result type (might be due to invalid IL or missing references)
					//IL_0063: Expected O, but got Unknown
					//IL_0068: Expected O, but got Unknown
					((GComponent)((GObject)receivedBtn).parent.GetChild("Mask").asButton).GetChild("Mask").TweenFade(0.6f, 0.625f);
					GTweener obj3 = ((GObject)receivedBtn).TweenFade(0f, 0.625f);
					GTweenCallback obj4 = val4;
					if (obj4 == null)
					{
						GTweenCallback val5 = delegate
						{
							((GObject)receivedBtn).visible = false;
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
			((GComponent)receivedBtn).GetController("PageController").selectedIndex = 1;
			DailySignPanel.Move.Play();
			for (int num = 0; num < dailySignButtons.Count; num++)
			{
				if (num <= 3)
				{
					float num2 = 0f;
					switch (num)
					{
					case 3:
						num2 = 0.4f;
						break;
					case 2:
						num2 = 0.2f;
						break;
					case 1:
						num2 = 0f;
						break;
					}
					((GComponent)((GComponent)dailySignButtons[num]).GetChild("Mask").asButton).GetChild("Mask").TweenFade(num2, 0.625f);
				}
			}
		});
	}

	private void LoadDailySignBtns()
	{
		for (int i = 0; i < 7; i++)
		{
			dailySignButtons.Add(((GComponent)DailySignPanel).GetChild($"Day{i}").asButton);
		}
	}

	private void RenderDailySignBtn(int index)
	{
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		GButton val = dailySignButtons[index];
		SignInBonusData signInBonusData = DailySignBonusDatas[index];
		GObject child = ((GComponent)((GComponent)val).GetChild("Mask").asButton).GetChild("Mask");
		if (index == 0)
		{
			child.alpha = 0f;
		}
		else if (index == 3 || index == 4 || index == 5 || index == 6)
		{
			child.alpha = 0.6f;
		}
		else
		{
			switch (index)
			{
			case 2:
				child.alpha = 0.4f;
				break;
			case 1:
				child.alpha = 0.2f;
				break;
			}
		}
		Bonus bonus = signInBonusData.BonusList.First();
		((GComponent)val).GetChild("num").text = bonus.Qty.ShortNumberFormat() ?? "";
		((GComponent)val).GetChild("num").asTextField.strokeColor = new Color(0f, 0f, 0f, 0.55f);
		string itemId = bonus.ItemId;
		string icon = UiHelper.GetIcon(itemId);
		((GComponent)val).GetChild("icon").asLoader.url = "ui://PublicResources/" + icon;
		((GObject)val).onClick.Set((EventCallback0)delegate
		{
			UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
			FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder + 1);
		});
	}

	private void ReceiveDailySignBonus(EventContext context)
	{
		UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
		LoopSignInSerialActivityPayload signInActivityPayload = (LoopSignInSerialActivityPayload)dailySignInActivity.ContentPayload(GameManagers.Instance).Values.First();
		ILRequestHelper<SignInClaimResponse>.Request(context, () => GameController.Contexts.Service<INetworkService>().SignInClaim(signInActivityPayload.Activity.ActivityId), delegate(SignInClaimResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				List<Bonus> list = signInActivityPayload.SignIn(GameManagers.Instance);
				if (list != null)
				{
					for (int i = 0; i < list.Count; i++)
					{
						string itemId = list[i].ItemId;
						List<string> arg = new List<string> { string.Format("{0}{1}X{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText221"), SchemaIndexHelper.GetNameById(GameManagers.Instance, itemId), list[i].Qty) };
						SharedMessenger.Broadcast("SHOW_TIPS", arg, 103, arg3: false);
					}
				}
				canDailySign = false;
				UpdatePanelShowNote(null);
				DailySignBtnMove();
			}
		});
	}

	private IEnumerator RefreshDailySignBonusRemaining()
	{
		while (true)
		{
			DateTimeOffset currentRefreshTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
			int _hours = 24 + (currentRefreshTime - DateTimeHelper.Now).Hours;
			string tip = LanguagesManager.GetDesc("CsharpCodeZhTcText220");
			if (tip.Contains("{0}"))
			{
				((GObject)DailySignPanel.Time).text = string.Format(tip, _hours);
			}
			else
			{
				((GObject)DailySignPanel.Time).text = $"{_hours}{tip}";
			}
			yield return (object)new WaitForSeconds(60f);
		}
	}

	private void RenderSevenDaysMissionPanel()
	{
		foreach (Activity item in HomePageActivity)
		{
			if (item.UiName == "UI_SevenDaysMissionPanel")
			{
				SevenDayActivity = item;
				SevenDayActivityContentPayloads.Clear();
				SevenDayActivityContentPayloads.AddRange(SevenDayActivity.ContentPayload(GameManagers.Instance).Values);
				break;
			}
		}
		ActivityStatus status = SevenDayActivity.GetStatus(GameManagers.Instance);
		if (status == ActivityStatus.Disabled || status == ActivityStatus.Pending)
		{
			return;
		}
		List<string> activityIds = new List<string> { SevenDayActivity.ActivityId };
		if (SevenDayActivity.ActivityProgress(GameManagers.Instance).IsNew)
		{
			GameManagers.Instance.ActivityManager.ReviewActivities(activityIds);
		}
		((GObject)SevenDaysMissionPanel).alpha = 1f;
		DateTimeOffset now = DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime());
		DateTimeOffset activityBeginAt = SevenDayActivity.CurBeginTime(GameManagers.Instance, now);
		curMissionDay = GetActivityCurrentDay(activityBeginAt, now, 7);
		curSelectMissionDay = curMissionDay;
		RenderMissionTabList(isInit: true);
		bool flag = true;
		for (int i = 0; i < SevenDayActivityContentPayloads.Count; i++)
		{
			MissionSerialActivityPayload missionSerialActivityPayload = (MissionSerialActivityPayload)SevenDayActivityContentPayloads[i];
			flag = missionSerialActivityPayload.AllBonusClaimed(GameManagers.Instance);
			if (!flag)
			{
				break;
			}
		}
		if (flag)
		{
			SevenDayActivity = null;
			return;
		}
		RenderWelfare(curSelectMissionDay);
		RenderMissionAchievementList(curSelectMissionDay);
		HiddenSFX();
	}

	public static int GetActivityCurrentDay(DateTimeOffset activityBeginAt, DateTimeOffset now, int maxDayTime)
	{
		DateTimeOffset dailyRefreshTime = DateTimeHelper.GetDailyRefreshTime(activityBeginAt, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
		DateTimeOffset dailyRefreshTime2 = DateTimeHelper.GetDailyRefreshTime(now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
		int num = (dailyRefreshTime2 - dailyRefreshTime).Days + 1;
		return Mathf.Min(num, maxDayTime);
	}

	public void UpdatePanelShowNote(Mission mission)
	{
		if (ActTabList.numItems == 0)
		{
			return;
		}
		foreach (Activity item in HomePageActivity)
		{
			Shift.Legion.Common.Models.ActivityConfig activityConfig = item.ActivityProgress(GameManagers.Instance);
			activityConfig.IsNew = false;
			bool flag = item.HasAnyNewMsg(GameManagers.Instance);
			switch (item.UiName)
			{
			case "UI_DailySignPanel":
				if (DailySignInIndex > -1)
				{
					((GComponent)((GComponent)ActTabList).GetChildAt(DailySignInIndex).asButton).GetChild("note").visible = flag;
				}
				break;
			case "UI_FirstTimeRewardPanel":
				if (FirstTimeRewardIndex > -1 && FirstTimeRewardActivity != null)
				{
					((GComponent)((GComponent)ActTabList).GetChildAt(FirstTimeRewardIndex).asButton).GetChild("note").visible = flag;
				}
				break;
			case "UI_SevenDaysMissionPanel":
				if (SevenDaysMissionIndex > -1)
				{
					((GComponent)((GComponent)ActTabList).GetChildAt(SevenDaysMissionIndex).asButton).GetChild("note").visible = flag;
				}
				break;
			case "UI_SignInPanel":
				if (SignInIndex > -1)
				{
					((GComponent)((GComponent)ActTabList).GetChildAt(SignInIndex).asButton).GetChild("note").visible = flag;
				}
				break;
			case "UI_CumulativeCostPanel":
				if (CumulativeCostIndex > -1)
				{
					((GComponent)((GComponent)ActTabList).GetChildAt(CumulativeCostIndex).asButton).GetChild("note").visible = flag;
				}
				break;
			case "UI_InstanceZonesPanel":
				if (NianTabIndex > -1)
				{
					((GComponent)((GComponent)ActTabList).GetChildAt(NianTabIndex).asButton).GetChild("note").visible = flag || item.ActivityProgress(GameManagers.Instance).IsNew;
				}
				break;
			case "UI_ChipFundPanel":
				if (ChipFundIndex > -1)
				{
					((GComponent)((GComponent)ActTabList).GetChildAt(ChipFundIndex).asButton).GetChild("note").visible = flag || item.ActivityProgress(GameManagers.Instance).IsNew;
				}
				break;
			case "UI_LegendItemFundPanel":
				if (LegendItemFundIndex > -1)
				{
					((GComponent)((GComponent)ActTabList).GetChildAt(LegendItemFundIndex).asButton).GetChild("note").visible = flag || item.ActivityProgress(GameManagers.Instance).IsNew;
				}
				break;
			case "UI_GemFundPanel":
				if (GemFundIndex > -1)
				{
					((GComponent)((GComponent)ActTabList).GetChildAt(GemFundIndex).asButton).GetChild("note").visible = flag || item.ActivityProgress(GameManagers.Instance).IsNew;
				}
				break;
			case "UI_GrowthFundPanel":
				if (GrowthFundIndex > -1)
				{
					((GComponent)((GComponent)ActTabList).GetChildAt(GrowthFundIndex).asButton).GetChild("note").visible = flag || item.ActivityProgress(GameManagers.Instance).IsNew;
				}
				break;
			case "UI_LegionCultivateFundPanel":
				if (LegionCultivateFundIndex > -1)
				{
					((GComponent)((GComponent)ActTabList).GetChildAt(LegionCultivateFundIndex).asButton).GetChild("note").visible = flag || item.ActivityProgress(GameManagers.Instance).IsNew;
				}
				break;
			}
		}
		if (CertificationIndex > -1)
		{
			User value = GameController.Contexts.gameState.user.value;
			bool flag2 = (value.Verified == 0 || value.Verified == 3) && !FGUIManager.Instance.certificationTabChecked;
			bool flag3 = value.Verified == 1;
			((GComponent)((GComponent)ActTabList).GetChildAt(CertificationIndex).asButton).GetChild("note").visible = flag2 || flag3;
		}
		if (_departurePresentIndex > -1)
		{
			CacheManager.Instance.Get<Cache_DeparturePresentRedDot>().ForceUpdate();
		}
	}

	private void OrderShipSuccessEvent(List<Bonus> result, List<Bonus> bonuses)
	{
		RenderWelfare(curSelectMissionDay);
		UpdateFundActivityPanel();
		UpdateMoneyAndGemNum(result);
		TryUpdateDeparturePresent();
		void TryUpdateDeparturePresent()
		{
			if (_oriTabOrderInfo.TryGetValue(UI_main_DeparturePresent.Name, out var value) && value.OriTabIdx == PageController.selectedIndex)
			{
				DeparturePresentPanel.OnShipOrderSuccess();
			}
		}
	}

	private void SetMissionDayPanel(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		object data = ((GObject)context.sender).data;
		curSelectMissionDay = (int)data;
		RenderMissionTabList(isInit: true);
		RenderWelfare(curSelectMissionDay);
		RenderMissionAchievementList(curSelectMissionDay);
		HiddenSFX();
	}

	private void OnRecharge(float totalRecharge)
	{
		RefreshUiAfterRecharge();
		UpdatePanelShowNote(null);
	}

	private void RedeemSevenDaysGift(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		GObject val = (GObject)context.sender;
		Shift.Legion.Common.Models.Store.StoreItem storeItem = (Shift.Legion.Common.Models.Store.StoreItem)val.data;
		if (val.grayed)
		{
			List<string> list = new List<string>();
			if (storeItem.IsFree)
			{
				list.Add(LanguagesManager.GetDesc("SevenDaysBonusRedeemTip_NeedCompleteAllMissions"));
			}
			else
			{
				list.Add(LanguagesManager.GetDesc("SevenDaysBonusRedeemTip_NeedClaimFreeBonusFirst"));
			}
			SharedMessenger.Broadcast("SHOW_TIPS", list, 1, arg3: false);
		}
		else
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_TakeItems.Name, new Dictionary<string, object>
			{
				{
					"Name",
					storeItem.Name ?? ""
				},
				{ "CanBuy", true },
				{ "GiftBag", storeItem },
				{ "Parent", this }
			});
		}
	}

	private static void GoToBlackMarketerAddCredit()
	{
		if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_MtgGiftPacksPanel.Name, new Dictionary<string, object>());
			return;
		}
		List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
	}

	private async void FirstRecharge(EventContext context)
	{
		Mission mission = (Mission)((GObject)context.sender).data;
		if (mission.MissionState(GameManagers.Instance).Status == MissionStatus.Undergoing)
		{
			GoToBlackMarketerAddCredit();
		}
		else if (mission.MissionState(GameManagers.Instance).Status == MissionStatus.Completed)
		{
			ILRequestHelper<MissionClaimResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().MissionClaim(mission.Id), delegate(MissionClaimResponse response)
			{
				if (!response.Result)
				{
					List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText222") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText223") };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
				}
				else
				{
					SharedMessenger.Broadcast("MISSION_CLAIMED", mission);
					List<Bonus> list = new List<Bonus>();
					Dictionary<string, float> dictionary = new Dictionary<string, float>();
					foreach (ModelsBonus bonus2 in response.BonusList)
					{
						Bonus bonus = Bonus.Get(bonus2.ItemId, bonus2.Qty, bonus2.Type, bonus2.IsShining);
						bonus.Claim(GameManagers.Instance, dictionary, null, forceClaim: true, broadcastInform: false);
						list.Add(bonus);
					}
					FGUIManager.Instance.OpenTakeItemsPanelForPack(LanguagesManager.GetDesc("CsharpCodeZhTcText211"), list, dictionary.ToList(), "ui://Tips/艺术字-确认黄-text", this);
					ThinkingDataHelper.Instance.FirstpayRewardTrack();
					RenderFirstTimeRewardPanel();
					UpdatePanelShowNote(null);
				}
			}, 1f);
		}
		else
		{
			if (mission.MissionState(GameManagers.Instance).Status != MissionStatus.Claimed)
			{
				return;
			}
			if (FirstTimeRewardPanel.RechargeStatus.selectedIndex == 0)
			{
				GoToBlackMarketerAddCredit();
			}
			else
			{
				if (FirstTimeRewardPanel.RechargeStatus.selectedIndex != 1)
				{
					return;
				}
				ILRequestHelper<NoviceRechargeBonusClaimResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().ClaimNoviceRechargeBonus(-1L, "NoviceRecharge_Demo", currentRechargeComboBonusKv.Key), delegate(NoviceRechargeBonusClaimResponse response)
				{
					if (!response.Result)
					{
						ILRequestHelper.ShowErrorCode(response.ErrorCode);
						RenderRechargeCombo();
					}
					else
					{
						SharedMessenger.Broadcast("RECHARGE_COMBO_BONUS_CLAIMED");
						List<Bonus> list = new List<Bonus>();
						Dictionary<string, float> dictionary = new Dictionary<string, float>();
						foreach (KeyValuePair<string, float> item in currentRechargeComboBonusKv.Value)
						{
							Bonus bonus = Bonus.Get(item.Key, item.Value);
							bonus.Claim(GameManagers.Instance, dictionary, null, forceClaim: true, broadcastInform: false);
							list.Add(bonus);
						}
						FGUIManager.Instance.OpenTakeItemsPanelForPack(LanguagesManager.GetDesc("RechargeCombo_BonusTitle_Placeholder"), list, dictionary.ToList(), "ui://Tips/艺术字-确认黄-text", this);
						RenderRechargeCombo();
					}
				}, 1f);
			}
		}
	}

	private void onClickFirstTimeRewardPanelDayTab(EventContext context)
	{
		UI_btn_Daychange uI_btn_Daychange = (UI_btn_Daychange)(object)context.sender;
		int num = (int)((GObject)uI_btn_Daychange).data;
		for (int i = 0; i < FirstTimeRewardPanel.dayTab.numItems; i++)
		{
			UI_btn_Daychange uI_btn_Daychange2 = ((GComponent)FirstTimeRewardPanel.dayTab).GetChildAt(i) as UI_btn_Daychange;
			if (i == num)
			{
				uI_btn_Daychange2.status.selectedIndex = 1;
			}
			else
			{
				uI_btn_Daychange2.status.selectedIndex = 0;
			}
		}
		int dayNum = num + 1;
		UpdateFirstTimeRewardPanelRechargeStatusByDayNum(dayNum);
		UpdateFirstTimeRewardPanelBonusByDayNum(dayNum);
	}

	private void UpdateFirstTimeRewardPanelRechargeStatusByDayNum(int dayNum)
	{
		NoviceRechargeData noviceRechargeData = FGUIManager.Instance.NoviceRechargeData;
		if (noviceRechargeData == null)
		{
			ILRuntimeDebug.LogError("Find No NoviceRechargeData, UpdateFirstTimeRewardPanelRechargeStatusByDayNum Aborted");
			return;
		}
		if (noviceRechargeData.Progress == null)
		{
			ILRuntimeDebug.LogError("Find No NoviceRechargeData.Progress, UpdateFirstTimeRewardPanelRechargeStatusByDayNum Aborted");
			return;
		}
		string text = dayNum.ToString();
		if (!noviceRechargeData.Progress.ContainsKey(text))
		{
			ILRuntimeDebug.LogError("Find No NoviceRechargeData.Progress[" + text + "], UpdateFirstTimeRewardPanelRechargeStatusByDayNum Aborted");
		}
		ContinuousRechargeBonus continuousRechargeBonus = noviceRechargeData.Progress[text];
		switch (continuousRechargeBonus.BonusStatus)
		{
		case Shift.Legion.ClientApi.Protocol.UserAction.BonusStatus.CanRecharge:
			FirstTimeRewardPanel.RechargeStatus.selectedIndex = 0;
			break;
		case Shift.Legion.ClientApi.Protocol.UserAction.BonusStatus.CanClaimBonus:
			FirstTimeRewardPanel.RechargeStatus.selectedIndex = 1;
			break;
		case Shift.Legion.ClientApi.Protocol.UserAction.BonusStatus.HasClaimedBonus:
			FirstTimeRewardPanel.RechargeStatus.selectedIndex = 2;
			break;
		case Shift.Legion.ClientApi.Protocol.UserAction.BonusStatus.Closed:
			FirstTimeRewardPanel.RechargeStatus.selectedIndex = 3;
			break;
		}
	}

	private void UpdateFirstTimeRewardPanelBonusByDayNum(int dayNum)
	{
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		if (RechargeComboActivity == null)
		{
			return;
		}
		Dictionary<float, Dictionary<string, float>> bonusProgress = RechargeComboActivity.BonusProgress;
		Dictionary<string, float> dictionary = null;
		foreach (KeyValuePair<float, Dictionary<string, float>> item in bonusProgress)
		{
			if (Math.Abs(item.Key - (float)dayNum) < float.Epsilon)
			{
				dictionary = item.Value;
				break;
			}
		}
		if (dictionary != null)
		{
			currentRechargeComboBonusKv = new KeyValuePair<string, Dictionary<string, float>>(dayNum.ToString(), dictionary);
			KeyValuePair<string, float> mainBonusKv = Enumerable.First(dictionary);
			((GObject)FirstTimeRewardPanel.MainReward.price).text = Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, mainBonusKv.Key);
			((GObject)FirstTimeRewardPanel.MainReward.num).text = $"{(int)mainBonusKv.Value}";
			FirstTimeRewardPanel.MainReward.num.strokeColor = new Color(0f, 0f, 0f, 0.55f);
			FirstTimeRewardPanel.MainReward.icon.url = "ui://PublicResources/" + UiHelper.GetIcon(mainBonusKv.Key);
			((GObject)FirstTimeRewardPanel.MainReward.icon).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(mainBonusKv.Key, 2);
			});
			FirstTimeRewardPanel.rewardList.itemRenderer = new ListItemRenderer(RenderRechargeComboReward);
			FirstTimeRewardPanel.rewardList.numItems = dictionary.Count - 1;
		}
	}

	private void ActivityTabClick(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		object data = ((GObject)context.sender).data;
		int index = (int)data;
		ChangeSelectIndex(index);
		SetActivityTabStatus();
	}

	private void DiamondBtnEvent()
	{
		if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
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
		else
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
	}

	public static void OnClickGoTopUp()
	{
		GoToBlackMarketerAddCredit();
	}

	public void MoneyBtnEvent()
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

	private void SignInEvent(EventContext eventContext)
	{
		UiAudioManager.Instance.PlaySoundEffect("CoinDrop");
		eventContext.StopPropagation();
		SignInSerialActivityPayload signInActivityPayload = (SignInSerialActivityPayload)SignInActivity.ContentPayload(GameManagers.Instance).Values.First();
		ILRequestHelper<SignInClaimResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().SignInClaim(signInActivityPayload.Activity.ActivityId), delegate(SignInClaimResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else if (response.TotalSignIn < curSignInDay)
			{
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText213") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder + 1, arg3: false);
			}
			else
			{
				Action action = delegate
				{
					RenderSignInPanel();
				};
				OnSignInCompleted(signInActivityPayload, action);
			}
		});
	}

	private void OnSignInCompleted(SignInSerialActivityPayload payload, Action action)
	{
		ILRequestHelper<SignInClaimResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().SignInClaim(SignInActivity.ActivityId), delegate(SignInClaimResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				List<Bonus> list = payload.SignIn(GameManagers.Instance);
				if (list != null)
				{
					SignInSerialActivityPayload signInSerialActivityPayload = (SignInSerialActivityPayload)SignInActivity.ContentPayload(GameManagers.Instance).Values.First();
					ThinkingDataHelper.Instance.SignInTrack("签到福利", signInSerialActivityPayload.TotalSignInCount(GameManagers.Instance));
				}
				action();
				UpdatePanelShowNote(null);
				UpdateMoneyAndGemNum(list);
			}
		}, 1f);
	}

	private void RenderMissionAchievementList(int day)
	{
		SevenAimAchievementListSort(day);
		UpdateSevenDayAchievenments(curSevenDayAimAchievementList.Count);
	}

	private void RenderMissionAchievementCard(int index, GButton button)
	{
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03df: Expected O, but got Unknown
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Expected O, but got Unknown
		button.title = curSevenDayAimAchievementList[index].Data.Desc ?? "";
		((GObject)((GComponent)button).GetChild("num").asTextField).text = $"{curSevenDayAimAchievementList[index].CurrentValue(GameManagers.Instance)}/{curSevenDayAimAchievementList[index].TargetValue(GameManagers.Instance)}";
		Controller controller = ((GComponent)button).GetController("ReceiveStatus");
		if (curSevenDayAimAchievementList[index].MissionState(GameManagers.Instance).Status == MissionStatus.Undergoing)
		{
			controller.selectedIndex = 0;
		}
		if (curSevenDayAimAchievementList[index].MissionState(GameManagers.Instance).Status == MissionStatus.Completed)
		{
			controller.selectedIndex = 1;
		}
		if (curSevenDayAimAchievementList[index].MissionState(GameManagers.Instance).Status == MissionStatus.Claimed)
		{
			controller.selectedIndex = 2;
		}
		if (curSevenDayAimAchievementList[index].BonusList != null && curSevenDayAimAchievementList[index].BonusList.Count > 0)
		{
			((GObject)((GComponent)button).GetChild("rewardNum").asTextField).text = curSevenDayAimAchievementList[index].BonusList[0].Qty.ShortNumberFormat() ?? "";
			Bonus bonus = curSevenDayAimAchievementList[index].BonusList[0];
			string itemId = bonus.ItemId;
			((GComponent)button).GetChild("rewardIcon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
			((GObject)((GComponent)button).GetChild("rewardIcon").asLoader).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(bonus.ItemId, 2);
			});
			if (bonus.IsShining == 2 && curSevenDayAimAchievementList[index].MissionState(GameManagers.Instance).Status != MissionStatus.Claimed)
			{
				((GObject)((GComponent)button).GetChild("fxBack").asGraph).displayObject.Dispose();
				FGUIManager.Instance.AddTextSpecialEffects(((GComponent)button).GetChild("fxBack").asGraph, "activated_fx", new Vector3(75f, 75f, 75f));
			}
			else
			{
				((GObject)((GComponent)button).GetChild("fxBack").asGraph).displayObject.Dispose();
			}
			if (curSelectMissionDay > curMissionDay)
			{
				((GComponent)button).GetChild("receiveBtn").grayed = true;
				((GComponent)button).GetChild("receiveBtn").touchable = true;
				((GComponent)button).GetChild("gotoBtn").grayed = true;
				((GComponent)button).GetChild("gotoBtn").touchable = false;
			}
			else
			{
				((GComponent)((GComponent)button).GetChild("receiveBtn").asButton).GetChild("note").visible = curSevenDayAimAchievementList[index].CanClaimBonus(GameManagers.Instance);
				((GObject)((GComponent)button).GetChild("receiveBtn").asButton).data = index;
				((GObject)((GComponent)button).GetChild("gotoBtn").asButton).data = curSevenDayAimAchievementList[index];
				((GObject)((GComponent)button).GetChild("receiveBtn").asButton).enabled = curSevenDayAimAchievementList[index].CanClaimBonus(GameManagers.Instance);
			}
			((GObject)((GComponent)button).GetChild("receiveBtn").asButton).onClick.Set(new EventCallback1(GetReward));
			((GObject)((GComponent)button).GetChild("gotoBtn").asButton).onClick.Set((EventCallback1)delegate(EventContext context)
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				GoToRelativeUi((Mission)((GObject)context.sender).data, (GObject)(object)this);
			});
		}
	}

	public static void GoToRelativeUi(Mission mission, GObject senderPanel)
	{
		int sortingOrder = senderPanel.sortingOrder;
		if (mission.JumpContext == "UI_WorkShopPanel" || mission.JumpContext == "UI_CollectionPanel" || mission.JumpContext == "UI_RecruitingCamp" || mission.JumpContext == "UI_MilitaryIntelligencePanel")
		{
			if (!mission.JumpContextParams.ContainsKey("BuildingType"))
			{
				List<string> list = new List<string>();
				list.Add(LanguagesManager.GetDesc("CsharpCodeZhTcText224") + ":" + mission.Id + LanguagesManager.GetDesc("CsharpCodeZhTcText225") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText226") + "BuildingType");
				List<string> arg = list;
				SharedMessenger.Broadcast("SHOW_TIPS", arg, sortingOrder, arg3: false);
				return;
			}
			string type = mission.JumpContextParams["BuildingType"].ToString();
			if (GameManagers.Instance.BuildingManager.GetBuildingByType(type).Status == BuildingStatus.Banned)
			{
				List<string> arg2 = new List<string>
				{
					LanguagesManager.GetDesc("CsharpCodeZhTcText21"),
					LanguagesManager.GetDesc("CsharpCodeZhTcText22")
				};
				SharedMessenger.Broadcast("SHOW_TIPS", arg2, sortingOrder, arg3: false);
			}
			else if (GameManagers.Instance.BuildingManager.GetBuildingByType(type).Status == BuildingStatus.Ready)
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("Parent", senderPanel);
				dictionary.Add("Building", GameManagers.Instance.BuildingManager.GetBuildingByType(type));
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary);
			}
			else if (GameManagers.Instance.BuildingManager.GetBuildingByType(type).Level == 0)
			{
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				dictionary2.Add("Building", GameManagers.Instance.BuildingManager.GetBuildingByType(type));
				dictionary2.Add("Parent", senderPanel);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary2);
			}
			else
			{
				mission.GoToRelativeUi();
			}
		}
		else if (mission.JumpContext == "UI_GiftBagPanel" || mission.JumpContext == "UI_MonthCardPanel")
		{
			if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(mission.JumpContext, new Dictionary<string, object>
				{
					{
						"Activity",
						FGUIManager.Instance.GetBlackMarketerActivity(mission.JumpContext)
					},
					{ "Order", sortingOrder },
					{ "Parent", senderPanel }
				});
			}
			else
			{
				List<string> arg3 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg3, sortingOrder, arg3: false);
			}
		}
		else if (mission.JumpContext == "UI_BlackMarketerAddCredit")
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_BlackMarketerAddCredit.Name, new Dictionary<string, object>
			{
				{
					"Activity",
					FGUIManager.Instance.GetBlackMarketerActivity(mission.JumpContext)
				},
				{ "Order", sortingOrder }
			});
		}
		else if (mission.JumpContext == "UI_ContractPanel")
		{
			if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(mission.JumpContext, new Dictionary<string, object> { { "Parent", senderPanel } });
			}
			else
			{
				List<string> arg4 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg4, sortingOrder, arg3: false);
			}
		}
		else if (mission.JumpContext == "UI_Technology")
		{
			List<string> unlockedMainCityCom = GameManagers.Instance.UserArchiveManager.GetUnlockedMainCityCom();
			if (GameManagers.Instance.BuildingManager.GetBuildingByType("15").Status == BuildingStatus.Banned || !unlockedMainCityCom.Contains("MainCity.TechnologyBtn"))
			{
				List<string> arg5 = new List<string>
				{
					LanguagesManager.GetDesc("CsharpCodeZhTcText21"),
					LanguagesManager.GetDesc("CsharpCodeZhTcText22")
				};
				SharedMessenger.Broadcast("SHOW_TIPS", arg5, sortingOrder, arg3: false);
			}
			else
			{
				mission.GoToRelativeUi();
			}
		}
		else if (mission.JumpContext == "UI_LegendItemsDrawPanel" || mission.JumpContext == "UI_LegendItemsStorePanel" || mission.JumpContext == "UI_LegendItemsPanel" || mission.JumpContext == "UI_LegendItemDungeonPanel")
		{
			if (!UI_BlackMarketerPanel.IsLegendItemDrawOpen())
			{
				List<string> arg6 = new List<string> { LanguagesManager.GetDesc("CsharpNeedUnlockLegendItem") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg6, sortingOrder, arg3: false);
				return;
			}
			if (mission.JumpContext == "UI_LegendItemsPanel")
			{
				UI_LegendItemsPanel.OpenPanelInfo = new LegendItemsPanelInfo(LegendItemsShowType.Show, -1L);
			}
			mission.GoToRelativeUi();
		}
		else if (mission.JumpContext == "UI_RecyclingCenterPanel")
		{
			Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType("17");
			if (buildingByType.Status == BuildingStatus.Banned)
			{
				List<string> arg7 = new List<string> { LanguagesManager.GetDesc("CsharpNeedUnlockRecycleCenter") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg7, sortingOrder, arg3: false);
			}
			else if (buildingByType.Status == BuildingStatus.Ready)
			{
				Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
				dictionary3.Add("Parent", senderPanel);
				dictionary3.Add("Building", buildingByType);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary3);
			}
			else if (buildingByType.Level == 0)
			{
				Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
				dictionary4.Add("Building", buildingByType);
				dictionary4.Add("Parent", senderPanel);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary4);
			}
			else
			{
				Dictionary<string, object> parameters = new Dictionary<string, object>();
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_RecyclingCenterPanel.Name, parameters);
			}
		}
		else if (mission.JumpContext.Contains("PVPEntrance"))
		{
			SharedMessenger.Broadcast("OPEN_PVP_PANEL");
		}
		else
		{
			mission.GoToRelativeUi();
		}
	}

	private async Task<List<Shift.Legion.Common.Models.Store.StoreItem>> GetSevenDaysActivityStoreItems(MissionSerialActivityPayload missionSerialActivityPayload)
	{
		int dayNumIdx = missionSerialActivityPayload.DayNum - 1;
		List<Shift.Legion.Common.Models.Store.StoreItem> storeItemList = StoreItems_MissionsOf7Days1[dayNumIdx];
		Shift.Legion.Common.Models.Store.StoreItem storeItem_Free;
		Shift.Legion.Common.Models.Store.StoreItem storeItem_Pay;
		if (storeItemList.Count == 2)
		{
			storeItem_Free = storeItemList[0];
			storeItem_Pay = storeItemList[1];
		}
		else
		{
			List<string> storeItemIdList = StoreItemIds_MissionsOf7Days1[dayNumIdx];
			storeItem_Free = new Shift.Legion.Common.Models.Store.StoreItem(GameManagers.Instance, storeItemIdList[0]);
			storeItem_Pay = new Shift.Legion.Common.Models.Store.StoreItem(GameManagers.Instance, storeItemIdList[1]);
			storeItemList.Add(storeItem_Free);
			storeItemList.Add(storeItem_Pay);
		}
		GetMissionActivityStoreItemsResponse bonusStoreItemsResponse = await GameController.Contexts.Service<INetworkService>().GetMissionActivityStoreItems("MissionsOf7Days1", missionSerialActivityPayload.PageName);
		if (!bonusStoreItemsResponse.Result)
		{
			ILRequestHelper.ShowErrorCode(bonusStoreItemsResponse.ErrorCode);
			return null;
		}
		List<StoreItemList> incomingStoreItemDataDict = bonusStoreItemsResponse.StoreItemsDict;
		if (incomingStoreItemDataDict != null && incomingStoreItemDataDict.Count > 0)
		{
			Shift.Legion.ClientApi.Protocol.Store.StoreItem incomingStoreItemData = incomingStoreItemDataDict.First().Items.First();
			Shift.Legion.Common.Models.Store.StoreItem targetStoreItem = ((!incomingStoreItemData.Price.Any(delegate(Dictionary<string, float> costDict)
			{
				foreach (float value in costDict.Values)
				{
					if (value > 0f)
					{
						return false;
					}
				}
				return true;
			})) ? storeItem_Pay : storeItem_Free);
			targetStoreItem.Icon = incomingStoreItemData.Icon;
			targetStoreItem.Rarity = incomingStoreItemData.Rarity;
			targetStoreItem.Category = (StoreCategory)incomingStoreItemData.Category;
			targetStoreItem.DoubleAtFirst = incomingStoreItemData.DoubleAtFirst;
			targetStoreItem.BonusAtFirst = incomingStoreItemData.BonusAtFirst;
			targetStoreItem.Tags = incomingStoreItemData.Tags;
			targetStoreItem.ValidTime = incomingStoreItemData.ValidTime;
			targetStoreItem.KickOffTimestamp = incomingStoreItemData.KickOffTimestamp;
			targetStoreItem.ExpireTimestamp = incomingStoreItemData.ExpireTimestamp;
			targetStoreItem.Content = incomingStoreItemData.Content;
			targetStoreItem.DisplayContent = incomingStoreItemData.DisplayContent;
			targetStoreItem.OriginPrice = incomingStoreItemData.OriginPrice;
			targetStoreItem.Price = incomingStoreItemData.Price;
			targetStoreItem.Discount = incomingStoreItemData.Discount;
			targetStoreItem.PurchaseLimit = incomingStoreItemData.PurchaseLimit;
			targetStoreItem.PurchaseLimitPeriod = (PurchaseLimitType)incomingStoreItemData.PurchaseLimitPeriod;
			targetStoreItem.IsExpo = incomingStoreItemData.IsExpo;
			targetStoreItem.Substitution = incomingStoreItemData.Substitution;
			targetStoreItem.IsResident = incomingStoreItemData.IsResident;
			targetStoreItem.UserLevelFilter = incomingStoreItemData.UserLevelFilter;
			targetStoreItem.DungeonLevelFilter = incomingStoreItemData.DungeonLevelFilter;
			targetStoreItem.GameLevelFilter = incomingStoreItemData.GameLevelFilter;
			targetStoreItem.OwnedItemFilter = incomingStoreItemData.OwnedItemFilter;
			targetStoreItem.PurchaseFilter = incomingStoreItemData.PurchaseFilter;
		}
		return new List<Shift.Legion.Common.Models.Store.StoreItem> { storeItem_Free, storeItem_Pay };
	}

	public async void RenderWelfare(int day)
	{
		if (SevenDayActivity == null)
		{
			return;
		}
		MissionSerialActivityPayload missionSerialActivityPayload = (MissionSerialActivityPayload)SevenDayActivityContentPayloads[day - 1];
		List<Shift.Legion.Common.Models.Store.StoreItem> _storeItems = await GetSevenDaysActivityStoreItems(missionSerialActivityPayload);
		if (_storeItems == null || _storeItems.Count <= 0)
		{
			return;
		}
		Shift.Legion.Common.Models.Store.StoreItem _storeItem_Free = _storeItems[0];
		Shift.Legion.Common.Models.Store.StoreItem _storeItem_Pay = _storeItems[1];
		((GObject)SevenDaysMissionPanel.MissionGiftPack_Free.num).text = "";
		((GObject)SevenDaysMissionPanel.MissionGiftPack_Free.name).text = _storeItem_Free.Name ?? "";
		((GObject)SevenDaysMissionPanel.MissionGiftPack_Pay.num).text = "";
		((GObject)SevenDaysMissionPanel.MissionGiftPack_Pay.name).text = _storeItem_Pay.Name ?? "";
		int allMissionsCnt = missionSerialActivityPayload.Missions(GameManagers.Instance).Count;
		int completeMissionCnt = missionSerialActivityPayload.TotalCompletedMissions(GameManagers.Instance);
		((GObject)SevenDaysMissionPanel.tip2).text = $"{completeMissionCnt}/{allMissionsCnt}";
		SevenDaysMissionPanel.MissionGiftPack_Free.IsFree.selectedIndex = 0;
		SevenDaysMissionPanel.MissionGiftPack_Free.bg.selectedIndex = 0;
		SevenDaysMissionPanel.MissionGiftPack_Pay.IsFree.selectedIndex = 1;
		SevenDaysMissionPanel.MissionGiftPack_Pay.bg.selectedIndex = 1;
		SevenDaysMissionPanel.MissionGiftPack_Free.RedeemBtn.RedeemType.selectedIndex = 0;
		SevenDaysMissionPanel.MissionGiftPack_Pay.RedeemBtn.RedeemType.selectedIndex = 1;
		if (completeMissionCnt < allMissionsCnt)
		{
			SevenDaysMissionPanel.MissionGiftPack_Free.ClaimStatus.selectedIndex = 0;
			SevenDaysMissionPanel.MissionGiftPack_Pay.ClaimStatus.selectedIndex = 0;
		}
		else
		{
			SevenDaysMissionPanel.MissionGiftPack_Free.ClaimStatus.selectedIndex = 1;
		}
		if (_storeItem_Free.IsSoldOut)
		{
			SevenDaysMissionPanel.MissionGiftPack_Free.ClaimStatus.selectedIndex = 2;
			SevenDaysMissionPanel.MissionGiftPack_Free.Discount.GetController("TurnOff").selectedIndex = 1;
			SevenDaysMissionPanel.MissionGiftPack_Pay.ClaimStatus.selectedIndex = 1;
		}
		else
		{
			SevenDaysMissionPanel.MissionGiftPack_Free.Discount.GetController("TurnOff").selectedIndex = 0;
			SevenDaysMissionPanel.MissionGiftPack_Pay.ClaimStatus.selectedIndex = 0;
		}
		SevenDaysMissionPanel.MissionGiftPack_Free.DisplayTimer.selectedIndex = 0;
		SevenDaysMissionPanel.MissionGiftPack_Pay.DisplayTimer.selectedIndex = 0;
		if (_storeItem_Pay.IsSoldOut)
		{
			SevenDaysMissionPanel.MissionGiftPack_Pay.ClaimStatus.selectedIndex = 2;
		}
		else if (_storeItem_Pay.IsExpired)
		{
			SevenDaysMissionPanel.MissionGiftPack_Pay.ClaimStatus.selectedIndex = 3;
		}
		else
		{
			int expireTimeSpan = _storeItem_Pay.ExpireTimestamp - (int)GameController.Instance.GetServerTime();
			if (expireTimeSpan > 0)
			{
				SevenDaysMissionPanel.MissionGiftPack_Pay.DisplayTimer.selectedIndex = 1;
				((GObject)SevenDaysMissionPanel.MissionGiftPack_Pay.Timer).text = LanguagesManager.GetDesc("CsharpCodeZhTcText227") + UiHelper.ParseTimeChinsesDH(Convert.ToInt32(expireTimeSpan));
			}
		}
		SevenDaysMissionPanel.MissionGiftPack_Free.Discount.GetController("PageController").selectedIndex = 3;
		if (Mathf.Abs(_storeItem_Pay.Discount - 1f) > float.Epsilon && _storeItem_Pay.Discount > float.Epsilon)
		{
			((GObject)SevenDaysMissionPanel.MissionGiftPack_Pay.Discount).visible = true;
			UiHelper.SetStoreItemDiscount(_storeItem_Pay, SevenDaysMissionPanel.MissionGiftPack_Pay.Discount, ribbonVisible: false);
		}
		else
		{
			((GObject)SevenDaysMissionPanel.MissionGiftPack_Pay.Discount).visible = false;
		}
		KeyValuePair<string, float> _storeItem_Pay_PriceKv = FGUIManager.Instance.GetPriceItemId(_storeItem_Pay);
		KeyValuePair<string, float> _storeItem_Free_PriceKv = FGUIManager.Instance.GetPriceItemId(_storeItem_Free);
		string _storeItem_Pay_OriginalPrice = $"{Convert.ToInt32(_storeItem_Pay.OriginPrice.First().Values.First())}";
		string _storeItem_Free_OriginalPrice = $"{Convert.ToInt32(_storeItem_Free.OriginPrice.First().Values.First())}";
		string _storeItem_Pay_Price = $"{Convert.ToInt32(_storeItem_Pay_PriceKv.Value)}";
		string _storeItem_Free_Price = $"{Convert.ToInt32(_storeItem_Free_PriceKv.Value)}";
		ProductLocalInfo productLocalInfo_Pay = null;
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			((GObject)SevenDaysMissionPanel.MissionGiftPack_Pay.priceGroup).visible = false;
			((GObject)SevenDaysMissionPanel.MissionGiftPack_Pay.priceGroupIntl).visible = true;
			((GObject)SevenDaysMissionPanel.MissionGiftPack_Free.priceGroup).visible = false;
			((GObject)SevenDaysMissionPanel.MissionGiftPack_Free.priceGroupIntl).visible = false;
			if (!string.IsNullOrEmpty(_storeItem_Pay.ReferenceId) && PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(_storeItem_Pay.ReferenceId, out productLocalInfo_Pay))
			{
				_storeItem_Pay_Price = productLocalInfo_Pay.FormattedPrice;
				_storeItem_Pay_OriginalPrice = $"{productLocalInfo_Pay.CurrencySymbol}{productLocalInfo_Pay.Price / _storeItem_Pay.InternationalDiscount:F2}";
			}
			else
			{
				_storeItem_Pay_Price = "--";
			}
		}
		else
		{
			((GObject)SevenDaysMissionPanel.MissionGiftPack_Pay.priceGroup).visible = true;
			((GObject)SevenDaysMissionPanel.MissionGiftPack_Pay.priceGroupIntl).visible = false;
			((GObject)SevenDaysMissionPanel.MissionGiftPack_Free.priceGroup).visible = true;
			((GObject)SevenDaysMissionPanel.MissionGiftPack_Free.priceGroupIntl).visible = false;
		}
		string CurrencySymbol = _storeItem_Pay_PriceKv.Key;
		SevenDaysMissionPanel.MissionGiftPack_Pay.curCurrencyIcon.url = "ui://PublicResources/" + CurrencySymbol;
		SevenDaysMissionPanel.MissionGiftPack_Pay.initCurrencyIcon.url = "ui://PublicResources/" + CurrencySymbol;
		SevenDaysMissionPanel.MissionGiftPack_Free.curCurrencyIcon.url = "ui://PublicResources/" + CurrencySymbol;
		SevenDaysMissionPanel.MissionGiftPack_Free.initCurrencyIcon.url = "ui://PublicResources/" + CurrencySymbol;
		((GObject)SevenDaysMissionPanel.MissionGiftPack_Pay.initPrice).text = _storeItem_Pay_OriginalPrice;
		((GObject)SevenDaysMissionPanel.MissionGiftPack_Pay.curPrice).text = _storeItem_Pay_Price;
		((GObject)SevenDaysMissionPanel.MissionGiftPack_Free.initPrice).text = _storeItem_Free_OriginalPrice;
		((GObject)SevenDaysMissionPanel.MissionGiftPack_Free.curPrice).text = _storeItem_Free_Price;
		((GObject)SevenDaysMissionPanel.MissionGiftPack_Pay.curIntlPriceText).text = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcText958"), _storeItem_Pay_Price);
		((GObject)SevenDaysMissionPanel.MissionGiftPack_Pay.originIntlPriceText).text = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcText955"), _storeItem_Pay_OriginalPrice);
		string storeItemIcon_Pay = _storeItem_Pay.Icon;
		string storeItemIcon_Free = _storeItem_Free.Icon;
		((GObject)SevenDaysMissionPanel.MissionGiftPack_Pay.Icon).touchable = true;
		((GObject)SevenDaysMissionPanel.MissionGiftPack_Free.Icon).touchable = true;
		string storeItemContent_Pay = Enumerable.First(_storeItem_Pay.Content).Key;
		string storeItemContent_Free = Enumerable.First(_storeItem_Free.Content).Key;
		SevenDaysMissionPanel.MissionGiftPack_Pay.Icon.Type.selectedIndex = (_storeItem_Pay.Name.Contains("A" + LanguagesManager.GetDesc("CsharpCodeZhTcText124")) ? 1 : 0);
		SevenDaysMissionPanel.MissionGiftPack_Free.Icon.Type.selectedIndex = (_storeItem_Free.Name.Contains("A" + LanguagesManager.GetDesc("CsharpCodeZhTcText124")) ? 1 : 0);
		SevenDaysMissionPanel.MissionGiftPack_Pay.Icon.icon.url = "ui://PublicResources/" + storeItemIcon_Pay;
		((GObject)SevenDaysMissionPanel.MissionGiftPack_Pay.Icon).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(storeItemContent_Pay, 2);
		});
		SevenDaysMissionPanel.MissionGiftPack_Free.Icon.icon.url = "ui://PublicResources/" + storeItemIcon_Free;
		((GObject)SevenDaysMissionPanel.MissionGiftPack_Free.Icon).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(storeItemContent_Free, 2);
		});
		((GObject)SevenDaysMissionPanel.MissionGiftPack_Pay.RedeemBtn).data = _storeItem_Pay;
		((GObject)SevenDaysMissionPanel.MissionGiftPack_Free.RedeemBtn).data = _storeItem_Free;
		((GObject)SevenDaysMissionPanel.MissionGiftPack_Pay.RedeemBtn).onClick.Set(new EventCallback1(RedeemSevenDaysGift));
		((GObject)SevenDaysMissionPanel.MissionGiftPack_Free.RedeemBtn).onClick.Set(new EventCallback1(RedeemSevenDaysGift));
	}

	private void RenderMissionTabList(bool isInit = false)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		SevenDaysMissionPanel.missionTabList.itemRenderer = new ListItemRenderer(RenderMissionTab);
		SevenDaysMissionPanel.missionTabList.numItems = SevenDayActivityContentPayloads.Count;
		double num = (double)(curMissionDay - 1) / 6.0;
		if (isInit)
		{
			((GProgressBar)SevenDaysMissionPanel.MissionProgress).value = num * 100.0;
		}
		else
		{
			((GProgressBar)SevenDaysMissionPanel.MissionProgress).TweenValue(num * 100.0, 0.5f).OnComplete((GTweenCallback)delegate
			{
				//IL_0046: Unknown result type (might be due to invalid IL or missing references)
				FGUIManager.Instance.AddTextSpecialEffects(((GComponent)((GComponent)SevenDaysMissionPanel.missionTabList).GetChildAt(curSelectMissionDay - 1).asButton).GetChild("SfxBack").asGraph, "activating_white", new Vector3(200f, 120f, 180f), "Default", 0.5f, delegate(GameObject activatingWhite)
				{
					activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
				});
				((GComponent)SevenDaysMissionPanel.missionTabList).GetChildAt(curSelectMissionDay - 1).asButton.FireClick(false, false);
			});
		}
		if (TimeLimitRemainingCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(TimeLimitRemainingCoroutine);
		}
		TimeLimitRemainingCoroutine = FGUIManager.Instance.OpenIEnumerator(RefreshTimeLimitRemaining());
	}

	private async void RenderMissionTab(int index, GObject obj)
	{
		GButton tab = obj.asButton;
		ActivityContentPayload _activityContentPayload = SevenDayActivityContentPayloads[index];
		MissionSerialActivityPayload _missionSerialActivityPayload = (MissionSerialActivityPayload)_activityContentPayload;
		((GComponent)tab).GetChild("day").text = _missionSerialActivityPayload.PageName;
		if (_missionSerialActivityPayload.DisplayBonus != null && _missionSerialActivityPayload.DisplayBonus.Count > 0)
		{
			string showItemId = Enumerable.First(_missionSerialActivityPayload.DisplayBonus).Key;
			((GComponent)tab).GetChild("icon").asLoader.url = "ui://PublicResources/" + showItemId;
		}
		Controller typeController = ((GComponent)tab).GetController("Type");
		Controller selectController = ((GComponent)tab).GetController("SelectState");
		((GObject)tab).data = _missionSerialActivityPayload.DayNum;
		if (curSelectMissionDay == _missionSerialActivityPayload.DayNum)
		{
			if (index == 0)
			{
				selectController.selectedIndex = 1;
			}
			else
			{
				selectController.selectedIndex = 2;
			}
		}
		else
		{
			selectController.selectedIndex = 0;
		}
		((GComponent)tab).GetChild("note").visible = curMissionDay >= _missionSerialActivityPayload.DayNum && _missionSerialActivityPayload.HasPendingBonus(GameManagers.Instance);
		if (index + 1 > curMissionDay)
		{
			typeController.selectedIndex = 2;
		}
		else
		{
			typeController.selectedIndex = ((index != 0) ? 1 : 0);
		}
		((GObject)tab).onClick.Set(new EventCallback1(SetMissionDayPanel));
		GetMissionActivityStoreItemsResponse bonusStoreItemsResponse = await GameController.Contexts.Service<INetworkService>().GetMissionActivityStoreItems(_missionSerialActivityPayload.Activity.ActivityId, _missionSerialActivityPayload.PageName);
		if (!bonusStoreItemsResponse.Result)
		{
			ILRequestHelper.ShowErrorCode(bonusStoreItemsResponse.ErrorCode);
			return;
		}
		List<StoreItemList> incomingStoreItemDataDict = bonusStoreItemsResponse.StoreItemsDict;
		if (incomingStoreItemDataDict != null && incomingStoreItemDataDict.Count > 0)
		{
			Shift.Legion.ClientApi.Protocol.Store.StoreItem incomingStoreItemData = incomingStoreItemDataDict.First().Items.First();
			Shift.Legion.Common.Models.Store.StoreItem _storeItem = new Shift.Legion.Common.Models.Store.StoreItem(GameManagers.Instance, incomingStoreItemData.StoreItemId)
			{
				Icon = incomingStoreItemData.Icon,
				Rarity = incomingStoreItemData.Rarity,
				Category = (StoreCategory)incomingStoreItemData.Category,
				DoubleAtFirst = incomingStoreItemData.DoubleAtFirst,
				BonusAtFirst = incomingStoreItemData.BonusAtFirst,
				Tags = incomingStoreItemData.Tags,
				ValidTime = incomingStoreItemData.ValidTime,
				KickOffTimestamp = incomingStoreItemData.KickOffTimestamp,
				ExpireTimestamp = incomingStoreItemData.ExpireTimestamp,
				Content = incomingStoreItemData.Content,
				DisplayContent = incomingStoreItemData.DisplayContent,
				OriginPrice = incomingStoreItemData.OriginPrice,
				Price = incomingStoreItemData.Price,
				Discount = incomingStoreItemData.Discount,
				PurchaseLimit = incomingStoreItemData.PurchaseLimit,
				PurchaseLimitPeriod = (PurchaseLimitType)incomingStoreItemData.PurchaseLimitPeriod,
				IsExpo = incomingStoreItemData.IsExpo,
				Substitution = incomingStoreItemData.Substitution,
				IsResident = incomingStoreItemData.IsResident,
				UserLevelFilter = incomingStoreItemData.UserLevelFilter,
				DungeonLevelFilter = incomingStoreItemData.DungeonLevelFilter,
				GameLevelFilter = incomingStoreItemData.GameLevelFilter,
				OwnedItemFilter = incomingStoreItemData.OwnedItemFilter,
				PurchaseFilter = incomingStoreItemData.PurchaseFilter
			};
			if (_storeItem.IsExpired || _storeItem.IsSoldOut)
			{
				((GComponent)tab).GetChild("tick").visible = true;
				((GComponent)tab).GetChild("tick").data = true;
			}
			else
			{
				((GComponent)tab).GetChild("tick").visible = false;
				((GComponent)tab).GetChild("tick").data = false;
			}
		}
	}

	private void HiddenSFX()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(0f, -4f);
		Vector2 val2 = default(Vector2);
		((Vector2)(ref val2))._002Ector(0f, 4f);
		Vector2 val3 = ((GObject)SevenDaysMissionPanel.AimAchievementListTop).LocalToRoot(Vector2.zero, GRoot.inst);
		Vector2 val4 = ((GObject)SevenDaysMissionPanel.AimAchievementListBottom).LocalToRoot(Vector2.zero, GRoot.inst);
		for (int i = 0; i < SevenDayAchievementList.Count; i++)
		{
			Vector2 val5 = ((GObject)SevenDayAchievementList[i]).LocalToRoot(Vector2.zero, GRoot.inst);
			if (!((GComponent)SevenDayAchievementList[i]).GetChild("fxBack").displayObject.isDisposed)
			{
				if (val5.y < val3.y + val.y || val5.y > val4.y - ((GObject)SevenDayAchievementList[i]).height + val2.y)
				{
					((GComponent)SevenDayAchievementList[i]).GetChild("fxBack").displayObject.visible = false;
				}
				else
				{
					((GComponent)SevenDayAchievementList[i]).GetChild("fxBack").displayObject.visible = true;
				}
			}
		}
	}

	private void AchievenmentClaimed(int index)
	{
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		((GObject)SevenDaysMissionPanel).touchable = false;
		GButton button = SevenDayAchievementList[index];
		if (!((GObject)((GComponent)button).GetChild("fxBack").asGraph).displayObject.isDisposed)
		{
			((GObject)((GComponent)button).GetChild("fxBack").asGraph).displayObject.Dispose();
		}
		((GObject)button).relations.ClearAll();
		if (index != SevenDayAchievementList.Count - 1)
		{
			((GObject)SevenDayAchievementList[index + 1]).RemoveRelation((GObject)(object)button, (RelationType)9);
		}
		SevenDayAchievementList.RemoveAt(index);
		GTweenCallback val = default(GTweenCallback);
		((GComponent)button).GetTransition("disappear").Play((PlayCompleteCallback)delegate
		{
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Expected O, but got Unknown
			//IL_016f: Expected O, but got Unknown
			SevenDayAchievementList.Add(button);
			((GObject)button).SetXY(0f, (float)(SevenDayAchievementList.Count * 143));
			((GObject)button).AddRelation((GObject)(object)SevenDayAchievementList[SevenDayAchievementList.Count - 2], (RelationType)9);
			((GObject)button).alpha = 1f;
			SevenAimAchievementListSort(curSelectMissionDay);
			RenderAchievementList();
			RenderMissionTabList();
			MissionSerialActivityPayload missionSerialActivityPayload = (MissionSerialActivityPayload)SevenDayActivityContentPayloads[curSelectMissionDay - 1];
			if (missionSerialActivityPayload.TotalCompletedMissions(GameManagers.Instance) >= missionSerialActivityPayload.Missions(GameManagers.Instance).Count)
			{
				RenderWelfare(curSelectMissionDay);
				UpdatePanelShowNote(null);
			}
			GTweener obj = ((GObject)SevenDayAchievementList[index]).TweenMoveY((float)(index * 143), 0.5f).SetEase((EaseType)5);
			GTweenCallback obj2 = val;
			if (obj2 == null)
			{
				GTweenCallback val2 = delegate
				{
					if (index != 0)
					{
						((GObject)SevenDayAchievementList[index]).AddRelation((GObject)(object)SevenDayAchievementList[index - 1], (RelationType)9);
					}
					((GObject)SevenDaysMissionPanel).touchable = true;
				};
				GTweenCallback val3 = val2;
				val = val2;
				obj2 = val3;
			}
			obj.OnComplete(obj2);
			HiddenSFX();
		});
	}

	private void RenderAchievementList()
	{
		for (int i = 0; i < SevenDayAchievementList.Count; i++)
		{
			RenderMissionAchievementCard(i, SevenDayAchievementList[i]);
		}
	}

	private void UpdateSevenDayAchievenments(int num)
	{
		for (int num2 = SevenDayAchievementList.Count - 1; num2 >= 0; num2--)
		{
			GButton val = SevenDayAchievementList[num2];
			SevenDayAchievementList.RemoveAt(num2);
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)val);
			((GObject)val).Dispose();
		}
		for (int i = 0; i < num; i++)
		{
			GButton val2 = (GButton)(object)UI_targetBtn.CreateInstance();
			((GComponent)GRoot.inst).AddChild((GObject)(object)val2);
			((GComponent)SevenDaysMissionPanel.MissionAchievementList).AddChild((GObject)(object)val2);
			((GObject)val2).SetXY(0f, (float)i * 143f);
			SevenDayAchievementList.Add(val2);
			RenderMissionAchievementCard(i, val2);
		}
		for (int j = 0; j < SevenDayAchievementList.Count; j++)
		{
			if (j != 0)
			{
				((GObject)SevenDayAchievementList[j]).AddRelation((GObject)(object)SevenDayAchievementList[j - 1], (RelationType)9);
			}
			else
			{
				((GObject)SevenDayAchievementList[j]).relations.ClearAll();
			}
		}
	}

	private void GetReward(EventContext eventContext)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		if (curSelectMissionDay > curMissionDay)
		{
			List<string> arg = new List<string> { string.Format(LanguagesManager.GetDesc("SevenDaysMissionClaimTip_NotInTime"), curSelectMissionDay) };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			return;
		}
		int index = (int)((GObject)(GButton)eventContext.sender).data;
		Mission mission = curSevenDayAimAchievementList[index];
		UiAudioManager.Instance.PlaySoundEffect("CoinDrop");
		eventContext.StopPropagation();
		ILRequestHelper<MissionClaimResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().MissionClaim(mission.Id), delegate(MissionClaimResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				SharedMessenger.Broadcast("MISSION_CLAIMED", mission);
				foreach (ModelsBonus bonus2 in response.BonusList)
				{
					Bonus bonus = Bonus.Get(bonus2.ItemId, bonus2.Qty, bonus2.Type, bonus2.IsShining);
					bonus.Claim(GameManagers.Instance);
				}
				if (response.BonusList.Count > 0)
				{
					ThinkingDataHelper.Instance.DailyTaskTrack(mission.Id);
					AchievenmentClaimed(index);
					UpdatePanelShowNote(null);
					UpdateMoneyAndGemNum(response.BonusList);
				}
			}
		});
	}

	public void UpdateMoneyAndGemNum(List<ModelsBonus> bonusList)
	{
		if (bonusList == null)
		{
			return;
		}
		for (int i = 0; i < bonusList.Count; i++)
		{
			if (bonusList[i].ItemId == "Money")
			{
				UpdateMoney(addCouponBtn);
			}
			else if (bonusList[i].ItemId == "Gem")
			{
				UpdateGemstone(addDiamondBtn, ref NumFloatingGem);
			}
		}
		RefreshCurrencyGroup();
	}

	public void UpdateMoneyAndGemNum(List<Bonus> bonusList)
	{
		if (bonusList == null)
		{
			return;
		}
		for (int i = 0; i < bonusList.Count; i++)
		{
			if (bonusList[i].ItemId == "Money")
			{
				UpdateMoney(addCouponBtn);
			}
			else if (bonusList[i].ItemId == "Gem")
			{
				UpdateGemstone(addDiamondBtn, ref NumFloatingGem);
			}
		}
		RefreshCurrencyGroup();
	}

	private void SevenAimAchievementListSort(int day)
	{
		MissionSerialActivityPayload missionSerialActivityPayload = (MissionSerialActivityPayload)SevenDayActivityContentPayloads[day - 1];
		List<Mission> list = new List<Mission>();
		list.AddRange(missionSerialActivityPayload.Missions(GameManagers.Instance));
		curSevenDayAimAchievementList.Clear();
		IEnumerable<Mission> collection = list.Where((Mission a) => a.MissionState(GameManagers.Instance).Status == MissionStatus.Completed);
		IEnumerable<Mission> collection2 = list.Where((Mission a) => a.MissionState(GameManagers.Instance).Status == MissionStatus.Undergoing);
		IEnumerable<Mission> collection3 = list.Where((Mission a) => a.MissionState(GameManagers.Instance).Status == MissionStatus.Claimed);
		curSevenDayAimAchievementList.AddRange(collection);
		curSevenDayAimAchievementList.AddRange(collection2);
		curSevenDayAimAchievementList.AddRange(collection3);
	}

	private void RenderCumulativeReward()
	{
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Expected O, but got Unknown
		SignInSerialActivityPayload signInSerialActivityPayload = (SignInSerialActivityPayload)SignInActivity.ContentPayload(GameManagers.Instance).Values.First();
		float num = signInSerialActivityPayload.TotalSignInCount(GameManagers.Instance);
		KeyValuePair<string, float> keyValuePair = default(KeyValuePair<string, float>);
		bool flag = SignInActivity.CanClaimBonus(GameManagers.Instance);
		foreach (KeyValuePair<float, Dictionary<string, float>> item in SignInActivity.BonusProgress)
		{
			if (!flag && item.Key >= SignInActivity.Score(GameManagers.Instance))
			{
				num = item.Key;
				keyValuePair = Enumerable.First(item.Value);
				break;
			}
			if (flag && !SignInActivity.ClaimProgress(GameManagers.Instance).Contains(item.Key))
			{
				num = item.Key;
				keyValuePair = Enumerable.First(item.Value);
				break;
			}
		}
		((GObject)SignInPanel.cumulativeReward.num).text = ((int)keyValuePair.Value).ShortNumberFormat() ?? "";
		((GObject)SignInPanel.cumulativeDays).text = string.Format("{0}{1}", num, LanguagesManager.GetDesc("CsharpCodeZhTcText228"));
		string key = keyValuePair.Key;
		if (!string.IsNullOrEmpty(key))
		{
			SignInPanel.cumulativeReward.icon.url = "ui://PublicResources/" + UiHelper.GetIcon(key);
			((GObject)SignInPanel.cumulativeReward).data = key;
		}
		SignInPanel.Status.selectedIndex = 0;
		((GObject)SignInPanel.cumulativeTitle).text = LanguagesManager.GetDesc("CsharpCodeZhTcText215");
		if (flag)
		{
			SignInPanel.Status.selectedIndex = 1;
			((GComponent)SignInPanel.cumulativeReward.ReceivedBtn).GetController("PageController").selectedIndex = 0;
			((GObject)SignInPanel.cumulativeReward.squareSfxBack).SetXY(0f, 0f);
			FGUIManager.Instance.AddTextSpecialEffects(SignInPanel.cumulativeReward.squareSfxBack, "stroke_card_trail_square", new Vector3(110f, 110f, 110f));
			FGUIManager.Instance.AddTextSpecialEffects(SignInPanel.cumulativeReward.activatedSfxBack, "activated_fx", new Vector3(90f, 90f, 90f));
			((GObject)SignInPanel.cumulativeTitle).text = LanguagesManager.GetDesc("CsharpCodeZhTcText216");
			SignInPanel.cumulativeReward.receiveController.selectedIndex = 2;
			((GObject)SignInPanel.cumulativeReward.icon).data = true;
		}
		else if (num <= (float)signInSerialActivityPayload.TotalSignInCount(GameManagers.Instance))
		{
			((GComponent)SignInPanel.cumulativeReward.ReceivedBtn).GetController("PageController").selectedIndex = 1;
			SignInPanel.cumulativeReward.receiveController.selectedIndex = 1;
			((GObject)SignInPanel.cumulativeReward.icon).data = false;
		}
		else
		{
			((GComponent)SignInPanel.cumulativeReward.ReceivedBtn).GetController("PageController").selectedIndex = 0;
			SignInPanel.cumulativeReward.receiveController.selectedIndex = 0;
			((GObject)SignInPanel.cumulativeReward.icon).data = false;
		}
		((GObject)SignInPanel.cumulativeReward.icon).onClick.Set(new EventCallback1(GetExtraReward));
	}

	private void GetExtraReward(EventContext context)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		if (((GObject)this).isDisposed)
		{
			return;
		}
		UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
		bool flag = (bool)((GObject)context.sender).data;
		if (SignInPanel != null && !((GObject)SignInPanel).isDisposed)
		{
			string text = ((GObject)SignInPanel.cumulativeReward).data?.ToString();
			if (string.IsNullOrEmpty(text))
			{
				ILRuntimeDebug.LogError($"SignInActivity {SignInActivity.ActivityId} GetExtraReward Failed, itemId={text}, canGetReward={flag}");
			}
			else if (flag)
			{
				PlayGetExtraRewardSfx();
			}
			else
			{
				FGUIManager.Instance.ItemTip(text, 2);
			}
		}
	}

	private void PlayGetExtraRewardSfx()
	{
		ILRequestHelper<ActivityClaimResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().ActivityClaim(SignInActivity.ActivityId), delegate(ActivityClaimResponse response)
		{
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Expected O, but got Unknown
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else if (response.ActivityId != SignInActivity.ActivityId)
			{
				ILRequestHelper.ShowErrorCode(82100004);
			}
			else
			{
				if (response.ClaimProgress != null)
				{
					SignInActivity.ActivityProgress(GameManagers.Instance).ClaimProgress = response.ClaimProgress;
				}
				if (response.BonusList != null && response.BonusList.Count > 0)
				{
					FGUIManager.Instance.ClaimBonusFromApiModels(response.BonusList);
				}
				GameManagers.Instance.UserArchiveManager.SetActivityProgress(SignInActivity.ActivityProgress(GameManagers.Instance));
				((GComponent)SignInPanel.cumulativeReward.ReceivedBtn).GetTransition("stamp").Play((PlayCompleteCallback)delegate
				{
					//IL_004e: Unknown result type (might be due to invalid IL or missing references)
					//IL_0058: Expected O, but got Unknown
					((GComponent)SignInPanel.cumulativeReward.ReceivedBtn).GetController("PageController").selectedIndex = 1;
					((GObject)SignInPanel.cumulativeReward).TweenFade(((GObject)SignInPanel.cumulativeReward).alpha, 0.3f).OnComplete((GTweenCallback)delegate
					{
						//IL_0025: Unknown result type (might be due to invalid IL or missing references)
						//IL_0085: Unknown result type (might be due to invalid IL or missing references)
						//IL_008f: Expected O, but got Unknown
						FGUIManager.Instance.AddTextSpecialEffects(SignInPanel.cumulativeSfxBack, "activating_white", new Vector3(180f, 180f, 180f), "Default", 0.5f, delegate(GameObject activatingWhite)
						{
							activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
						});
						((GObject)SignInPanel.cumulativeSfxBack).TweenFade(((GObject)SignInPanel.cumulativeSfxBack).alpha, 0.15f).OnComplete((GTweenCallback)delegate
						{
							RenderCumulativeReward();
							UpdatePanelShowNote(null);
						});
					});
				});
			}
		}, 1f);
	}

	private void RenderSignInLabel(int index, GObject obj)
	{
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04be: Expected O, but got Unknown
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		bool flag = (bool)((GObject)SignInPanel.SignInLabelList).data;
		if (index + 1 == curSignInDay)
		{
			((GComponent)asButton).GetController("pageController").selectedIndex = 1;
		}
		else
		{
			((GComponent)asButton).GetController("pageController").selectedIndex = 0;
		}
		GButton mainBtn = ((GComponent)asButton).GetChild("mainBtn").asButton;
		GButton rewardBtn = ((GComponent)mainBtn).GetChild("rewardBtn").asButton;
		GButton asButton2 = ((GComponent)rewardBtn).GetChild("ReceivedBtn").asButton;
		string desc = LanguagesManager.GetDesc("CsharpNewArrivalRewardName", returnKey: false);
		if (string.IsNullOrEmpty(desc))
		{
			((GComponent)mainBtn).GetChild("day").text = string.Format("{0}{1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText145"), index + 1, LanguagesManager.GetDesc("CsharpCodeZhTcText228"));
		}
		else
		{
			((GComponent)mainBtn).GetChild("day").text = string.Format(desc, index + 1);
		}
		if (index + 1 == 2)
		{
			((GComponent)mainBtn).GetChild("dayTip2").visible = true;
		}
		else if (index + 1 == 7)
		{
			((GComponent)mainBtn).GetChild("dayTip7").visible = true;
		}
		((GComponent)rewardBtn).GetChild("num").text = Enumerable.First(SignInList[index].DisplayBonus).Value ?? "";
		string itemId = Enumerable.First(SignInList[index].DisplayBonus).Key;
		if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 3)
		{
			FGUIManager.Instance.SetItemIconAndFrame(((GComponent)rewardBtn).GetChild("icon").asLoader, itemId, textureList);
		}
		else
		{
			((GComponent)rewardBtn).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
		}
		if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 10 || Shift.Legion.Common.Models.Item.ItemType(itemId) == 3)
		{
			((GObject)((GComponent)rewardBtn).GetChild("icon").asLoader).SetScale(0.75f, 0.75f);
		}
		((GObject)((GComponent)rewardBtn).GetChild("icon").asLoader).onClick.Set((EventCallback0)delegate
		{
			UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
			FGUIManager.Instance.ItemTip(itemId, 2);
		});
		SignInSerialActivityPayload signInSerialActivityPayload = (SignInSerialActivityPayload)SignInActivity.ContentPayload(GameManagers.Instance).Values.First();
		if (index + 1 == curSignInDay)
		{
			if (signInSerialActivityPayload.CanSignIn(GameManagers.Instance))
			{
				((GComponent)mainBtn).GetController("receiveController").selectedIndex = 0;
				((GComponent)asButton2).GetController("PageController").selectedIndex = 0;
				((GComponent)rewardBtn).GetController("receiveController").selectedIndex = 0;
			}
			else if (flag)
			{
				((GComponent)mainBtn).GetController("receiveController").selectedIndex = 1;
				((GComponent)rewardBtn).GetController("receiveController").selectedIndex = 1;
				((GComponent)asButton2).GetController("PageController").selectedIndex = 1;
			}
			else
			{
				((GComponent)asButton2).GetController("PageController").selectedIndex = 0;
				((GComponent)asButton2).GetTransition("stamp").Play((PlayCompleteCallback)delegate
				{
					((GComponent)mainBtn).GetController("receiveController").selectedIndex = 1;
					((GComponent)rewardBtn).GetController("receiveController").selectedIndex = 1;
				});
			}
		}
		else if (index + 1 > curSignInDay)
		{
			((GComponent)mainBtn).GetController("receiveController").selectedIndex = 2;
			((GComponent)asButton2).GetController("PageController").selectedIndex = 0;
			((GComponent)rewardBtn).GetController("receiveController").selectedIndex = 0;
		}
		else
		{
			((GComponent)mainBtn).GetController("receiveController").selectedIndex = 1;
			((GComponent)rewardBtn).GetController("receiveController").selectedIndex = 1;
			((GComponent)asButton2).GetController("PageController").selectedIndex = 1;
		}
		((GObject)((GComponent)mainBtn).GetChild("SignInBtn").asButton).data = index;
		((GObject)((GComponent)mainBtn).GetChild("SignInBtn").asButton).onClick.Set(new EventCallback1(SignInEvent));
	}

	private void RenderRechargeComboReward(int index, GObject obj)
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_0130: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		Dictionary<string, float> value = currentRechargeComboBonusKv.Value;
		int num = 0;
		string itemId;
		EventCallback0 val = default(EventCallback0);
		foreach (KeyValuePair<string, float> item in value)
		{
			if (num++ != index + 1)
			{
				continue;
			}
			itemId = item.Key;
			float value2 = item.Value;
			((GComponent)asButton).GetChild("price").text = Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, itemId);
			((GComponent)asButton).GetChild("num").text = ((int)value2).ShortNumberFormat() ?? "";
			((GComponent)asButton).GetChild("num").asTextField.strokeColor = new Color(0f, 0f, 0f, 0.55f);
			((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
			EventListener onClick = ((GObject)((GComponent)asButton).GetChild("icon").asLoader).onClick;
			EventCallback0 obj2 = val;
			if (obj2 == null)
			{
				EventCallback0 val2 = delegate
				{
					FGUIManager.Instance.ItemTip(itemId, 2);
				};
				EventCallback0 val3 = val2;
				val = val2;
				obj2 = val3;
			}
			onClick.Set(obj2);
			break;
		}
	}

	private void RenderRechargeReward(int index, GObject obj)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		Bonus bonus = FirstTimeRewardMissionBonus[index + 1];
		GButton asButton = obj.asButton;
		((GComponent)asButton).GetChild("price").text = bonusName[index];
		((GComponent)asButton).GetChild("num").text = bonus.Qty.ShortNumberFormat() ?? "";
		((GComponent)asButton).GetChild("num").asTextField.strokeColor = new Color(0f, 0f, 0f, 0.55f);
		string itemId = bonus.ItemId;
		((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
		((GObject)((GComponent)asButton).GetChild("icon").asLoader).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(itemId, 2);
		});
	}

	private void SetActivityTabStatus()
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < ActTabList.numItems; i++)
		{
			if (((GComponent)ActTabList).GetChildAt(i) is UI_ActTabs uI_ActTabs)
			{
				if ((int)((GObject)uI_ActTabs).data == PageController.selectedIndex)
				{
					uI_ActTabs.Type.selectedIndex = 1;
					uI_ActTabs.title.strokeColor = new Color(0f, 0f, 0f, 0.6f);
				}
				else
				{
					uI_ActTabs.Type.selectedIndex = 0;
					uI_ActTabs.title.strokeColor = new Color(0f, 0f, 0f, 0.8f);
				}
			}
		}
	}

	private void ChangeSelectIndex(int index)
	{
		if (index != PageController.selectedIndex)
		{
			PageController.selectedIndex = index;
			ChangePageIndex();
			RefreshCurrencyGroup();
		}
	}

	private void SignInListScrollLeft()
	{
		((GComponent)SignInPanel.SignInLabelList).scrollPane.ScrollLeft(1f, true);
	}

	private void SignInListScrollRight()
	{
		((GComponent)SignInPanel.SignInLabelList).scrollPane.ScrollRight(1f, true);
	}

	public void End()
	{
		if (timeCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(timeCoroutine);
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		if (_taskCompleteOnClose != null)
		{
			SharedMessenger.Broadcast("CUSTOM_ACTION_FINISH", _taskCompleteOnClose, arg2: true);
		}
		if (UnityUiService.Instance.GetShowingUi(UI_MainCity.Name) is UI_MainCity uI_MainCity)
		{
			uI_MainCity.RefreshNewComerSpecialIcon();
		}
	}

	private void SetBuildingName(string titleName)
	{
		if (!string.IsNullOrEmpty(titleName))
		{
			((GObject)Title.buildingName).text = titleName;
		}
		else
		{
			((GObject)Title.buildingName).text = (RewardGroup.Contains(_tabFilterType) ? PanelName : LanguagesManager.GetDesc("ActivityPanelNameNewComer"));
		}
		UpdateGemstone(addDiamondBtn, ref NumFloatingGem);
		UpdateMoney(addCouponBtn, isInit: true);
		UpdateManPower(addWorkerBtn);
		addDiamondBtn.GetChild("diamond").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Gem");
		addCouponBtn.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Money");
	}

	public static void UpdateGemstone(GComponent addDiamondBtn, ref UI_ProductionNumFloating NumFloatingGem)
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

	public static void UpdateMoney(GComponent addCouponBtn, bool isInit = false)
	{
		int stock = GameManagers.Instance.StockController.GetStock("Money");
		if (!isInit && addCouponBtn.GetChild("num").data != null && (int)addCouponBtn.GetChild("num").data != stock)
		{
			int num = (int)addCouponBtn.GetChild("num").data;
			FGUIManager.Instance.AddNumFloatingForCouponBtn(UI_ProductionNumFloating.CreateInstance_ILRuntime(), addCouponBtn, stock - num, 1, dispose: true);
		}
		((GObject)addCouponBtn.GetChild("num").asTextField).text = stock.ToString();
		addCouponBtn.GetChild("num").data = stock;
	}

	private void OnOrcTabRedDotChange(Cache_OrcActivityRedDot cache)
	{
		if (_TabNote.TryGetValue(Cache_OrcActivityRedDot.ON_REDDOT_CHANGE, out var value) && !value.isDisposed)
		{
			value.visible = cache.IsShowRedDot;
		}
	}

	private void OnNoviceRechargeRedDotChange(Cache_NoviceRechargeRedDot cache)
	{
		if (_TabNote.TryGetValue("Cache_NoviceRechargeRedDot", out var value) && !value.isDisposed)
		{
			value.visible = cache.IsShowRedDot;
		}
	}

	private void OnDeparturePresentRedDotChange(Cache_DeparturePresentRedDot cache)
	{
		if (_TabNote.TryGetValue("ON_DEPARTURE_PRESENT_RED_DOT_CHANGE", out var value) && !value.isDisposed)
		{
			value.visible = cache.IsShowRedDot;
		}
	}

	private void OnBlackMarketTreasureRedDotChange(Cache_BlackMarketTreasureRedDot cache)
	{
		if (_TabNote.TryGetValue(Cache_BlackMarketTreasureRedDot.ON_REDDOT_CHANGE, out var value) && !value.isDisposed)
		{
			value.visible = cache.IsShowRedDot;
		}
		if (_bmTab != null)
		{
			((GObject)_bmTab.cornerMark).visible = !cache.IsShowRedDot;
		}
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		switch (itemId)
		{
		case "Gem":
			UpdateGemstone(addDiamondBtn, ref NumFloatingGem);
			addDiamondBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addDiamondBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
			{
				uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
			break;
		case "Money":
			UpdateMoney(addCouponBtn);
			break;
		case "ManPower":
			UpdateManPower(addWorkerBtn);
			break;
		}
	}

	private IEnumerator RefreshTimeLimitRemaining()
	{
		while (true)
		{
			if (!(((GObject)SevenDaysMissionPanel.MissionGiftPack_Pay.RedeemBtn).data is Shift.Legion.Common.Models.Store.StoreItem sevenDaysMissions_storeItem_Pay))
			{
				if (PageController.selectedIndex == 2)
				{
					yield break;
				}
				SevenDaysMissionPanel.MissionGiftPack_Pay.DisplayTimer.selectedIndex = 0;
				yield return (object)new WaitForSeconds(30f);
				continue;
			}
			if (sevenDaysMissions_storeItem_Pay.IsSoldOut)
			{
				SevenDaysMissionPanel.MissionGiftPack_Pay.DisplayTimer.selectedIndex = 0;
				SevenDaysMissionPanel.MissionGiftPack_Pay.ClaimStatus.selectedIndex = 2;
				yield break;
			}
			if (sevenDaysMissions_storeItem_Pay.IsExpired)
			{
				break;
			}
			bool limitTime = false;
			int remainingTime = 0;
			if (sevenDaysMissions_storeItem_Pay.ExpireTimestamp > 0)
			{
				limitTime = true;
				remainingTime = sevenDaysMissions_storeItem_Pay.ExpireTimestamp - (int)GameController.Instance.GetServerTime();
			}
			if (limitTime)
			{
				SevenDaysMissionPanel.MissionGiftPack_Pay.DisplayTimer.selectedIndex = 1;
				((GObject)SevenDaysMissionPanel.MissionGiftPack_Pay.Timer.limitTime).text = LanguagesManager.GetDesc("CsharpCodeZhTcText227") + UiHelper.ParseTimeChinsesDH(Convert.ToInt32(remainingTime));
			}
			else
			{
				SevenDaysMissionPanel.MissionGiftPack_Pay.DisplayTimer.selectedIndex = 0;
			}
			yield return (object)new WaitForSeconds(0.5f);
		}
		SevenDaysMissionPanel.MissionGiftPack_Pay.DisplayTimer.selectedIndex = 0;
		SevenDaysMissionPanel.MissionGiftPack_Pay.ClaimStatus.selectedIndex = 3;
	}

	private void ShowGiftBag(EventContext context)
	{
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		if (CurPageName == "UI_ChipFundPanel")
		{
			if (ChipFundPanel.InvestBtn.Type.selectedIndex != 0)
			{
				return;
			}
		}
		else if (CurPageName == "UI_GemFundPanel")
		{
			if (GemFundPanel.InvestBtn.Type.selectedIndex != 0)
			{
				return;
			}
		}
		else if (CurPageName == "UI_GrowthFundPanel")
		{
			if (GrowthFundPanel.Invest.Type.selectedIndex != 0)
			{
				return;
			}
		}
		else if (CurPageName == "UI_LegendItemFundPanel")
		{
			if (LegendItemFundPanel.InvestBtn.Type.selectedIndex != 0)
			{
				return;
			}
		}
		else if (CurPageName == "UI_LegionCultivateFundPanel" && LegionCultivateFundPanel.InvestBtn.Type.selectedIndex != 0)
		{
			return;
		}
		object data = ((GObject)context.sender).data;
		Shift.Legion.Common.Models.Store.StoreItem storeItem = (Shift.Legion.Common.Models.Store.StoreItem)data;
		ProductLocalInfo value = null;
		if (PurchaseManager.Instance.ProductLocalInfoDictionary != null && !string.IsNullOrEmpty(storeItem.ReferenceId))
		{
			PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value);
		}
		PurchaseManager.Instance.InvokePurchase(storeItem, value, 1, (Action)null, doubleCheck: true);
	}

	private void BonusItemClick(EventContext context)
	{
		UI_FundRewardBtn uI_FundRewardBtn = (UI_FundRewardBtn)(object)context.sender;
		if (uI_FundRewardBtn.receiveController.selectedIndex == 1)
		{
			return;
		}
		Mission _mission = (Mission)((GObject)uI_FundRewardBtn).data;
		KeyValuePair<string, string> keyValuePair = Enumerable.First(_mission.DisplayBonus);
		int bonusItemIndex = 0;
		if (CurPageName == "UI_ChipFundPanel")
		{
			bonusItemIndex = curChipFundAchievementList.IndexOf(_mission);
		}
		else if (CurPageName == "UI_GemFundPanel")
		{
			bonusItemIndex = curGemFundAchievementList.IndexOf(_mission);
		}
		else if (CurPageName == "UI_LegendItemFundPanel")
		{
			bonusItemIndex = curLegendItemFundAchievementList.IndexOf(_mission);
		}
		if (uI_FundRewardBtn.receiveController.selectedIndex == 0)
		{
			FGUIManager.Instance.ItemTip(keyValuePair.Key, ((GObject)this).sortingOrder, noCheckBtn: true);
		}
		else
		{
			if (uI_FundRewardBtn.receiveController.selectedIndex != 2)
			{
				return;
			}
			ILRequestHelper<MissionClaimResponse>.Request(context, () => GameController.Contexts.Service<INetworkService>().MissionClaim(_mission.Id), delegate(MissionClaimResponse response)
			{
				if (!response.Result)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
				else
				{
					SharedMessenger.Broadcast("MISSION_CLAIMED", _mission);
					if (response.BonusList != null && response.BonusList.Count > 0)
					{
						FGUIManager.Instance.ClaimBonusFromApiModels(response.BonusList);
						if (CurPageName == "UI_ChipFundPanel")
						{
							RenderChipFundBonus(bonusItemIndex);
						}
						else if (CurPageName == "UI_GemFundPanel")
						{
							RenderGemFundBonus(bonusItemIndex);
						}
						else if (CurPageName == "UI_LegendItemFundPanel")
						{
							RenderLegendItemFundBonus(bonusItemIndex);
						}
						UpdatePanelShowNote(null);
						UpdateMoneyAndGemNum(response.BonusList);
					}
					else
					{
						List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText234") };
						SharedMessenger.Broadcast("SHOW_TIPS", arg, 103, arg3: false);
					}
					FlushActivityRedNoteCache();
					UpdatePanelShowNote(null);
				}
			});
		}
	}

	public void UpdateFundActivityPanel()
	{
		IUiService uiService = Contexts.sharedInstance.Service<IUiService>();
		int changeId = uiService.SetUiNotTouchable(Name);
		uiService.ShowWaitingAnimation(show: true);
		GameManagers.Instance.ActivityManager.CheckActivities(null, new List<ActivityType>
		{
			ActivityType.HomePageActivity,
			ActivityType.Funds
		}, delegate
		{
			HomePageActivity = GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.HomePageActivity);
			HomePageActivity.AddRange(GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.Funds));
			if (CurPageName == "UI_ChipFundPanel")
			{
				RenderChipFundPanel();
			}
			else if (CurPageName == "UI_GemFundPanel")
			{
				RenderGemFundPanel();
			}
			else if (CurPageName == "UI_GrowthFundPanel")
			{
				RenderGrowthFundPanel();
			}
			else if (CurPageName == "UI_LegendItemFundPanel")
			{
				RenderLegendItemFundPanel();
			}
			else if (CurPageName == "UI_LegionCultivateFundPanel")
			{
				RenderLegionCultivateFundPanel();
			}
			UpdatePanelShowNote(null);
			uiService.ShowWaitingAnimation(show: false);
			uiService.SetUiTouchable(changeId);
		});
	}

	private bool AllBonusClaimed(List<Mission> allMissions)
	{
		for (int i = 0; i < allMissions.Count; i++)
		{
			MissionStatus status = allMissions[i].MissionState(GameManagers.Instance).Status;
			if (status != MissionStatus.Claimed)
			{
				return false;
			}
		}
		return true;
	}

	private void RenderLegendItemFundPanel()
	{
		foreach (Activity item in HomePageActivity)
		{
			if (item.UiName == "UI_LegendItemFundPanel")
			{
				legendItemFundActivity = item;
				break;
			}
		}
		if (legendItemFundActivity != null)
		{
			List<string> activityIds = new List<string> { legendItemFundActivity.ActivityId };
			if (legendItemFundActivity.ActivityProgress(GameManagers.Instance).IsNew)
			{
				GameManagers.Instance.ActivityManager.ReviewActivities(activityIds);
			}
			MissionSerialActivityPayload missionSerialActivityPayload = (MissionSerialActivityPayload)legendItemFundActivity.ContentPayload(GameManagers.Instance).Values.First();
			List<Mission> allMissions = missionSerialActivityPayload.Missions(GameManagers.Instance);
			if (AllBonusClaimed(allMissions))
			{
				legendItemFundActivity = null;
				return;
			}
			LegendItemFundActivityAimAchievementListSort(allMissions);
			RenderLegendItemFundBonus();
			((GObject)LegendItemFundPanel).alpha = 1f;
		}
	}

	private void RenderLegendItemFundBonus(int curIndex = -1)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		((GObject)LegendItemFundPanel.Bonus).data = curIndex;
		LegendItemFundPanel.Bonus.itemRenderer = new ListItemRenderer(RenderLegendItemFundDailyAchievementItem);
		LegendItemFundPanel.Bonus.numItems = curLegendItemFundAchievementList.Count;
	}

	private void RenderLegendItemFundDailyAchievementItem(int index, GObject obj)
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		UI_FundBonusBtn _btn = obj as UI_FundBonusBtn;
		Mission mission = curLegendItemFundAchievementList[index];
		int num = Convert.ToInt32(mission.TargetValue(GameManagers.Instance));
		_btn.Day.selectedIndex = num - 1;
		_btn.SetControllerPageText();
		MissionStatus status = mission.MissionState(GameManagers.Instance).Status;
		((GObject)_btn.Content.squareSfxBack).SetXY(0f, 0f);
		switch (status)
		{
		case MissionStatus.Completed:
			_btn.Content.receiveController.selectedIndex = 2;
			FGUIManager.Instance.AddTextSpecialEffects(_btn.Content.squareSfxBack, "stroke_card_trail_square", new Vector3(120f, 120f, 120f));
			FGUIManager.Instance.AddTextSpecialEffects(_btn.Content.activatedSfxBack, "activated_fx", new Vector3(90f, 90f, 90f));
			break;
		case MissionStatus.Undergoing:
			_btn.Content.receiveController.selectedIndex = 0;
			break;
		case MissionStatus.Claimed:
		{
			int num2 = (int)((GObject)LegendItemFundPanel.Bonus).data;
			if (num2 == index)
			{
				GGraph cumulativeSfxBack = _btn.Content.cumulativeSfxBack;
				GButton receivedBtn = _btn.Content.ReceivedBtn;
				((GComponent)receivedBtn).GetController("PageController").selectedIndex = 0;
				((GComponent)receivedBtn).GetTransition("stamp").Play((PlayCompleteCallback)delegate
				{
					//IL_0020: Unknown result type (might be due to invalid IL or missing references)
					//IL_008a: Unknown result type (might be due to invalid IL or missing references)
					//IL_008f: Unknown result type (might be due to invalid IL or missing references)
					//IL_0091: Expected O, but got Unknown
					//IL_0096: Expected O, but got Unknown
					FGUIManager.Instance.AddTextSpecialEffects(cumulativeSfxBack, "activating_white", new Vector3(180f, 180f, 180f), "Default", 0.5f, delegate(GameObject activatingWhite)
					{
						activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
					});
					GTweener obj2 = ((GComponent)(object)this).SetTimeout(0.25f);
					GTweenCallback val = default(GTweenCallback);
					GTweenCallback obj3 = val;
					if (obj3 == null)
					{
						GTweenCallback val2 = delegate
						{
							_btn.Content.receiveController.selectedIndex = 1;
							((GComponent)_btn.Content.ReceivedBtn).GetController("PageController").selectedIndex = 1;
						};
						GTweenCallback val3 = val2;
						val = val2;
						obj3 = val3;
					}
					obj2.OnComplete(obj3);
				});
			}
			else
			{
				_btn.Content.receiveController.selectedIndex = 1;
				((GComponent)_btn.Content.ReceivedBtn).GetController("PageController").selectedIndex = 1;
			}
			break;
		}
		}
		KeyValuePair<string, string> keyValuePair = Enumerable.First(mission.DisplayBonus);
		_btn.Content.icon.url = "ui://PublicResources/" + UiHelper.GetIcon(keyValuePair.Key);
		((GObject)_btn.Content.num).text = $"{Convert.ToInt32(keyValuePair.Value)}";
		((GObject)_btn.Content).data = mission;
		((GObject)_btn.Content).onClick.Set(new EventCallback1(BonusItemClick));
	}

	private void LegendItemFundActivityAimAchievementListSort(List<Mission> allMissions)
	{
		Mission mission = allMissions.First();
		SetLegendItemFundStatus("FundCertStoreItem4");
		curLegendItemFundAchievementList.Clear();
		curLegendItemFundAchievementList.AddRange(allMissions);
	}

	private void SetLegendItemFundStatus(string itemId)
	{
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		Dictionary<string, int> purchaseStat = GameManagers.Instance.StoreManager.PurchaseStat.GetValue().PurchaseStat;
		if (!purchaseStat.TryGetValue(itemId, out var value) || value <= 0)
		{
			LegendItemFundPanel.PageController.selectedIndex = 0;
			Shift.Legion.Common.Models.Store.StoreItem storeItem = Shift.Legion.Common.Models.Store.StoreItem.Get(GameManagers.Instance, itemId);
			KeyValuePair<string, float> priceItemId = FGUIManager.Instance.GetPriceItemId(storeItem);
			string key = priceItemId.Key;
			string text = $"{Convert.ToInt32(priceItemId.Value)}";
			bool flag = key == "RMB";
			ProductLocalInfo value2 = null;
			if (HotUpdateProcess.Instance.IsRegionOutCN && flag)
			{
				((GObject)LegendItemFundPanel.priceIcon).visible = false;
				text = ((string.IsNullOrEmpty(storeItem.ReferenceId) || !PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value2)) ? "--" : value2.FormattedPrice);
			}
			else
			{
				((GObject)LegendItemFundPanel.priceIcon).visible = true;
			}
			LegendItemFundPanel.region.SetSelectedIndex(HotUpdateProcess.Instance.IsRegionOutCN ? 1 : 0);
			((GObject)LegendItemFundPanel.priceSea).text = text;
			((GObject)LegendItemFundPanel.price).text = text;
			((GObject)LegendItemFundPanel.priceIcon).text = "<img src='ui://PublicResources/" + key + "' width='60' height='60'/>";
			LegendItemFundPanel.InvestBtn.Type.selectedIndex = 0;
			((GObject)LegendItemFundPanel.InvestBtn).data = storeItem;
			((GObject)LegendItemFundPanel.InvestBtn).onClick.Set(new EventCallback1(ShowGiftBag));
		}
		else
		{
			LegendItemFundPanel.PageController.selectedIndex = 1;
			LegendItemFundPanel.InvestBtn.Type.selectedIndex = 1;
		}
	}

	private void RenderChipFundPanel()
	{
		foreach (Activity item in HomePageActivity)
		{
			if (item.UiName == "UI_ChipFundPanel")
			{
				chipFundActivity = item;
				break;
			}
		}
		if (chipFundActivity != null)
		{
			List<string> activityIds = new List<string> { chipFundActivity.ActivityId };
			if (chipFundActivity.ActivityProgress(GameManagers.Instance).IsNew)
			{
				GameManagers.Instance.ActivityManager.ReviewActivities(activityIds);
			}
			MissionSerialActivityPayload missionSerialActivityPayload = (MissionSerialActivityPayload)chipFundActivity.ContentPayload(GameManagers.Instance).Values.First();
			List<Mission> allMissions = missionSerialActivityPayload.Missions(GameManagers.Instance);
			if (AllBonusClaimed(allMissions))
			{
				chipFundActivity = null;
				return;
			}
			ChipFundActivityAimAchievementListSort(allMissions);
			RenderChipFundBonus();
			((GObject)ChipFundPanel).alpha = 1f;
		}
	}

	private void SetChipFundStatus(string itemId)
	{
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		Dictionary<string, int> purchaseStat = GameManagers.Instance.StoreManager.PurchaseStat.GetValue().PurchaseStat;
		if (!purchaseStat.TryGetValue(itemId, out var value) || value <= 0)
		{
			ChipFundPanel.PageController.selectedIndex = 0;
			Shift.Legion.Common.Models.Store.StoreItem storeItem = Shift.Legion.Common.Models.Store.StoreItem.Get(GameManagers.Instance, itemId);
			KeyValuePair<string, float> priceItemId = FGUIManager.Instance.GetPriceItemId(storeItem);
			string key = priceItemId.Key;
			string text = $"{Convert.ToInt32(priceItemId.Value)}";
			bool flag = key == "RMB";
			ProductLocalInfo value2 = null;
			if (HotUpdateProcess.Instance.IsRegionOutCN && flag)
			{
				((GObject)ChipFundPanel.priceIcon).visible = false;
				text = ((string.IsNullOrEmpty(storeItem.ReferenceId) || !PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value2)) ? "--" : value2.FormattedPrice);
			}
			else
			{
				((GObject)ChipFundPanel.priceIcon).visible = true;
			}
			((GObject)ChipFundPanel.price).text = text;
			ChipFundPanel.region.SetSelectedIndex(HotUpdateProcess.Instance.IsRegionOutCN ? 1 : 0);
			((GObject)ChipFundPanel.priceSea).text = text;
			((GObject)ChipFundPanel.priceIcon).text = "<img src='ui://PublicResources/" + key + "' width='60' height='60'/>";
			ChipFundPanel.InvestBtn.Type.selectedIndex = 0;
			((GObject)ChipFundPanel.InvestBtn).data = storeItem;
			((GObject)ChipFundPanel.InvestBtn).onClick.Set(new EventCallback1(ShowGiftBag));
		}
		else
		{
			ChipFundPanel.PageController.selectedIndex = 1;
			ChipFundPanel.InvestBtn.Type.selectedIndex = 1;
		}
	}

	private void ChipFundActivityAimAchievementListSort(List<Mission> allMissions)
	{
		Mission mission = allMissions.First();
		SetChipFundStatus("FundCertStoreItem2");
		curChipFundAchievementList.Clear();
		curChipFundAchievementList.AddRange(allMissions);
	}

	private void RenderChipFundBonus(int curIndex = -1)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		((GObject)ChipFundPanel.Bonus).data = curIndex;
		ChipFundPanel.Bonus.itemRenderer = new ListItemRenderer(RenderChipFundDailyAchievementItem);
		ChipFundPanel.Bonus.numItems = curChipFundAchievementList.Count;
	}

	private void RenderChipFundDailyAchievementItem(int index, GObject obj)
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		UI_FundBonusBtn _btn = obj as UI_FundBonusBtn;
		Mission mission = curChipFundAchievementList[index];
		int num = Convert.ToInt32(mission.TargetValue(GameManagers.Instance));
		_btn.Day.selectedIndex = num - 1;
		_btn.SetControllerPageText();
		MissionStatus status = mission.MissionState(GameManagers.Instance).Status;
		((GObject)_btn.Content.squareSfxBack).SetXY(0f, 0f);
		switch (status)
		{
		case MissionStatus.Completed:
			_btn.Content.receiveController.selectedIndex = 2;
			FGUIManager.Instance.AddTextSpecialEffects(_btn.Content.squareSfxBack, "stroke_card_trail_square", new Vector3(120f, 120f, 120f));
			FGUIManager.Instance.AddTextSpecialEffects(_btn.Content.activatedSfxBack, "activated_fx", new Vector3(90f, 90f, 90f));
			break;
		case MissionStatus.Undergoing:
			_btn.Content.receiveController.selectedIndex = 0;
			break;
		case MissionStatus.Claimed:
		{
			int num2 = (int)((GObject)ChipFundPanel.Bonus).data;
			if (num2 == index)
			{
				GGraph cumulativeSfxBack = _btn.Content.cumulativeSfxBack;
				GButton receivedBtn = _btn.Content.ReceivedBtn;
				((GComponent)receivedBtn).GetController("PageController").selectedIndex = 0;
				((GComponent)receivedBtn).GetTransition("stamp").Play((PlayCompleteCallback)delegate
				{
					//IL_0020: Unknown result type (might be due to invalid IL or missing references)
					//IL_008a: Unknown result type (might be due to invalid IL or missing references)
					//IL_008f: Unknown result type (might be due to invalid IL or missing references)
					//IL_0091: Expected O, but got Unknown
					//IL_0096: Expected O, but got Unknown
					FGUIManager.Instance.AddTextSpecialEffects(cumulativeSfxBack, "activating_white", new Vector3(180f, 180f, 180f), "Default", 0.5f, delegate(GameObject activatingWhite)
					{
						activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
					});
					GTweener obj2 = ((GComponent)(object)this).SetTimeout(0.25f);
					GTweenCallback val = default(GTweenCallback);
					GTweenCallback obj3 = val;
					if (obj3 == null)
					{
						GTweenCallback val2 = delegate
						{
							_btn.Content.receiveController.selectedIndex = 1;
							((GComponent)_btn.Content.ReceivedBtn).GetController("PageController").selectedIndex = 1;
						};
						GTweenCallback val3 = val2;
						val = val2;
						obj3 = val3;
					}
					obj2.OnComplete(obj3);
				});
			}
			else
			{
				_btn.Content.receiveController.selectedIndex = 1;
				((GComponent)_btn.Content.ReceivedBtn).GetController("PageController").selectedIndex = 1;
			}
			break;
		}
		}
		KeyValuePair<string, string> keyValuePair = Enumerable.First(mission.DisplayBonus);
		_btn.Content.icon.url = "ui://PublicResources/" + UiHelper.GetIcon(keyValuePair.Key);
		((GObject)_btn.Content.num).text = $"{Convert.ToInt32(keyValuePair.Value)}";
		((GObject)_btn.Content).data = mission;
		((GObject)_btn.Content).onClick.Set(new EventCallback1(BonusItemClick));
	}

	private void ChipFundBonusClick(EventContext context)
	{
	}

	private void RenderGemFundPanel()
	{
		foreach (Activity item in HomePageActivity)
		{
			if (item.UiName == "UI_GemFundPanel")
			{
				gemFundActivity = item;
				break;
			}
		}
		if (gemFundActivity != null)
		{
			List<string> activityIds = new List<string> { gemFundActivity.ActivityId };
			if (gemFundActivity.ActivityProgress(GameManagers.Instance).IsNew)
			{
				GameManagers.Instance.ActivityManager.ReviewActivities(activityIds);
			}
			MissionSerialActivityPayload missionSerialActivityPayload = (MissionSerialActivityPayload)gemFundActivity.ContentPayload(GameManagers.Instance).Values.First();
			List<Mission> allMissions = missionSerialActivityPayload.Missions(GameManagers.Instance);
			if (AllBonusClaimed(allMissions))
			{
				gemFundActivity = null;
				return;
			}
			GemFundActivityAimAchievementListSort(allMissions);
			RenderGemFundBonus();
			((GObject)GemFundPanel).alpha = 1f;
		}
	}

	private void SetGemFundStatus(string itemId)
	{
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		Dictionary<string, int> purchaseStat = GameManagers.Instance.StoreManager.PurchaseStat.GetValue().PurchaseStat;
		if (!purchaseStat.TryGetValue(itemId, out var value) || value <= 0)
		{
			GemFundPanel.PageController.selectedIndex = 0;
			Shift.Legion.Common.Models.Store.StoreItem storeItem = Shift.Legion.Common.Models.Store.StoreItem.Get(GameManagers.Instance, itemId);
			KeyValuePair<string, float> priceItemId = FGUIManager.Instance.GetPriceItemId(storeItem);
			string key = priceItemId.Key;
			string text = $"{Convert.ToInt32(priceItemId.Value)}";
			bool flag = key == "RMB";
			ProductLocalInfo value2 = null;
			if (HotUpdateProcess.Instance.IsRegionOutCN && flag)
			{
				((GObject)GemFundPanel.priceIcon).visible = false;
				text = ((string.IsNullOrEmpty(storeItem.ReferenceId) || !PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value2)) ? "--" : value2.FormattedPrice);
			}
			else
			{
				((GObject)GemFundPanel.priceIcon).visible = true;
			}
			GemFundPanel.region.SetSelectedIndex(HotUpdateProcess.Instance.IsRegionOutCN ? 1 : 0);
			((GObject)GemFundPanel.priceSea).text = text;
			((GObject)GemFundPanel.price).text = text;
			((GObject)GemFundPanel.priceIcon).text = "<img src='ui://PublicResources/" + key + "' width='60' height='60'/>";
			GemFundPanel.InvestBtn.Type.selectedIndex = 0;
			((GObject)GemFundPanel.InvestBtn).data = storeItem;
			((GObject)GemFundPanel.InvestBtn).onClick.Set(new EventCallback1(ShowGiftBag));
		}
		else
		{
			GemFundPanel.PageController.selectedIndex = 1;
			GemFundPanel.InvestBtn.Type.selectedIndex = 1;
		}
	}

	private void GemFundActivityAimAchievementListSort(List<Mission> allMissions)
	{
		Mission mission = allMissions.First();
		SetGemFundStatus("FundCertStoreItem1");
		curGemFundAchievementList.Clear();
		curGemFundAchievementList.AddRange(allMissions);
	}

	private void RenderGemFundBonus(int curIndex = -1)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		((GObject)GemFundPanel.Bonus).data = curIndex;
		GemFundPanel.Bonus.itemRenderer = new ListItemRenderer(RenderGemFundDailyAchievementItem);
		GemFundPanel.Bonus.numItems = curGemFundAchievementList.Count;
	}

	private void RenderGemFundDailyAchievementItem(int index, GObject obj)
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		UI_FundBonusBtn _btn = obj as UI_FundBonusBtn;
		Mission mission = curGemFundAchievementList[index];
		int num = Convert.ToInt32(mission.TargetValue(GameManagers.Instance));
		_btn.Day.selectedIndex = num - 1;
		_btn.SetControllerPageText();
		((GObject)_btn.Content.squareSfxBack).SetXY(0f, 0f);
		switch (mission.MissionState(GameManagers.Instance).Status)
		{
		case MissionStatus.Completed:
			_btn.Content.receiveController.selectedIndex = 2;
			FGUIManager.Instance.AddTextSpecialEffects(_btn.Content.squareSfxBack, "stroke_card_trail_square", new Vector3(120f, 120f, 120f));
			FGUIManager.Instance.AddTextSpecialEffects(_btn.Content.activatedSfxBack, "activated_fx", new Vector3(90f, 90f, 90f));
			break;
		case MissionStatus.Undergoing:
			_btn.Content.receiveController.selectedIndex = 0;
			break;
		case MissionStatus.Claimed:
		{
			int num2 = (int)((GObject)GemFundPanel.Bonus).data;
			if (num2 == index)
			{
				GGraph cumulativeSfxBack = _btn.Content.cumulativeSfxBack;
				GButton receivedBtn = _btn.Content.ReceivedBtn;
				((GComponent)receivedBtn).GetController("PageController").selectedIndex = 0;
				((GComponent)receivedBtn).GetTransition("stamp").Play((PlayCompleteCallback)delegate
				{
					//IL_0020: Unknown result type (might be due to invalid IL or missing references)
					//IL_008a: Unknown result type (might be due to invalid IL or missing references)
					//IL_008f: Unknown result type (might be due to invalid IL or missing references)
					//IL_0091: Expected O, but got Unknown
					//IL_0096: Expected O, but got Unknown
					FGUIManager.Instance.AddTextSpecialEffects(cumulativeSfxBack, "activating_white", new Vector3(180f, 180f, 180f), "Default", 0.5f, delegate(GameObject activatingWhite)
					{
						activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
					});
					GTweener obj2 = ((GComponent)(object)this).SetTimeout(0.25f);
					GTweenCallback val = default(GTweenCallback);
					GTweenCallback obj3 = val;
					if (obj3 == null)
					{
						GTweenCallback val2 = delegate
						{
							_btn.Content.receiveController.selectedIndex = 1;
							((GComponent)_btn.Content.ReceivedBtn).GetController("PageController").selectedIndex = 1;
						};
						GTweenCallback val3 = val2;
						val = val2;
						obj3 = val3;
					}
					obj2.OnComplete(obj3);
				});
			}
			else
			{
				_btn.Content.receiveController.selectedIndex = 1;
				((GComponent)_btn.Content.ReceivedBtn).GetController("PageController").selectedIndex = 1;
			}
			break;
		}
		}
		KeyValuePair<string, string> keyValuePair = Enumerable.First(mission.DisplayBonus);
		_btn.Content.icon.url = "ui://PublicResources/" + UiHelper.GetIcon(keyValuePair.Key);
		((GObject)_btn.Content.num).text = $"{Convert.ToInt32(keyValuePair.Value)}";
		_btn.Content.num.strokeColor = new Color(0f, 0f, 0f, 0.55f);
		((GObject)_btn.Content).data = mission;
		((GObject)_btn.Content).onClick.Set(new EventCallback1(BonusItemClick));
	}

	private void RenderGrowthFundPanel()
	{
		foreach (Activity item in HomePageActivity)
		{
			if (item.UiName == "UI_GrowthFundPanel")
			{
				growthFundActivity = item;
				break;
			}
		}
		if (growthFundActivity != null)
		{
			List<string> activityIds = new List<string> { growthFundActivity.ActivityId };
			if (growthFundActivity.ActivityProgress(GameManagers.Instance).IsNew)
			{
				GameManagers.Instance.ActivityManager.ReviewActivities(activityIds);
			}
			MissionSerialActivityPayload missionSerialActivityPayload = (MissionSerialActivityPayload)growthFundActivity.ContentPayload(GameManagers.Instance).Values.First();
			List<Mission> allMissions = missionSerialActivityPayload.Missions(GameManagers.Instance);
			if (AllBonusClaimed(allMissions))
			{
				growthFundActivity = null;
				return;
			}
			GrowthFundActivityAimAchievementListSort(allMissions);
			UpdateGrowthAchievenments(curGrowthFundAchievementList.Count);
			HiddenrGrowthAchievementSFX();
			((GObject)GrowthFundPanel).alpha = 1f;
		}
	}

	private void GrowthFundActivityAimAchievementListSort(List<Mission> allMissions = null)
	{
		if (allMissions == null)
		{
			MissionSerialActivityPayload missionSerialActivityPayload = (MissionSerialActivityPayload)growthFundActivity.ContentPayload(GameManagers.Instance).Values.First();
			allMissions = missionSerialActivityPayload.Missions(GameManagers.Instance);
		}
		List<Mission> list = new List<Mission>();
		list.AddRange(allMissions);
		SetGrowthFundStatus("FundCertStoreItem3");
		curGrowthFundAchievementList.Clear();
		IEnumerable<Mission> collection = list.Where((Mission a) => a.MissionState(GameManagers.Instance).Status == MissionStatus.Pending);
		IEnumerable<Mission> collection2 = list.Where((Mission a) => a.MissionState(GameManagers.Instance).Status == MissionStatus.Completed);
		IEnumerable<Mission> collection3 = list.Where((Mission a) => a.MissionState(GameManagers.Instance).Status == MissionStatus.Undergoing);
		IEnumerable<Mission> collection4 = list.Where((Mission a) => a.MissionState(GameManagers.Instance).Status == MissionStatus.Claimed);
		curGrowthFundAchievementList.AddRange(collection);
		curGrowthFundAchievementList.AddRange(collection2);
		curGrowthFundAchievementList.AddRange(collection3);
		curGrowthFundAchievementList.AddRange(collection4);
	}

	private void SetGrowthFundStatus(string itemId)
	{
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		Dictionary<string, int> purchaseStat = GameManagers.Instance.StoreManager.PurchaseStat.GetValue().PurchaseStat;
		if (!purchaseStat.TryGetValue(itemId, out var value) || value <= 0)
		{
			GrowthFundPanel.PageController.selectedIndex = 0;
			Shift.Legion.Common.Models.Store.StoreItem storeItem = Shift.Legion.Common.Models.Store.StoreItem.Get(GameManagers.Instance, itemId);
			KeyValuePair<string, float> priceItemId = FGUIManager.Instance.GetPriceItemId(storeItem);
			string key = priceItemId.Key;
			string text = $"{Convert.ToInt32(priceItemId.Value)}";
			bool flag = key == "RMB";
			ProductLocalInfo value2 = null;
			if (HotUpdateProcess.Instance.IsRegionOutCN && flag)
			{
				((GObject)GrowthFundPanel.priceIcon).visible = false;
				text = ((string.IsNullOrEmpty(storeItem.ReferenceId) || !PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value2)) ? "--" : value2.FormattedPrice);
			}
			else
			{
				((GObject)GrowthFundPanel.priceIcon).visible = true;
			}
			((GObject)GrowthFundPanel.price).text = text;
			((GObject)GrowthFundPanel.priceIcon).text = "<img src='ui://PublicResources/" + key + "' width='60' height='60'/>";
			GrowthFundPanel.region.SetSelectedIndex(HotUpdateProcess.Instance.IsRegionOutCN ? 1 : 0);
			((GObject)GrowthFundPanel.priceSea).text = text;
			GrowthFundPanel.Invest.Type.selectedIndex = 0;
			((GObject)GrowthFundPanel.Invest).data = storeItem;
			((GObject)GrowthFundPanel.Invest).onClick.Set(new EventCallback1(ShowGiftBag));
		}
		else
		{
			GrowthFundPanel.PageController.selectedIndex = 1;
			GrowthFundPanel.Invest.Type.selectedIndex = 1;
		}
	}

	private void UpdateGrowthAchievenments(int num)
	{
		for (int num2 = GrowthAchievementList.Count - 1; num2 >= 0; num2--)
		{
			GButton val = GrowthAchievementList[num2];
			GrowthAchievementList.RemoveAt(num2);
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)val);
			((GObject)val).Dispose();
		}
		for (int i = 0; i < num; i++)
		{
			GButton val2 = (GButton)(object)UI_LevelUpAimBtn.CreateInstance();
			((GComponent)GRoot.inst).AddChild((GObject)(object)val2);
			((GComponent)GrowthFundPanel.AchievementList).AddChild((GObject)(object)val2);
			((GObject)val2).SetXY(0f, (float)i * 143f);
			GrowthAchievementList.Add(val2);
			RenderGrowthAchievementCard(i, val2);
		}
		for (int j = 0; j < GrowthAchievementList.Count; j++)
		{
			if (j != 0)
			{
				((GObject)GrowthAchievementList[j]).AddRelation((GObject)(object)GrowthAchievementList[j - 1], (RelationType)9);
			}
			else
			{
				((GObject)GrowthAchievementList[j]).relations.ClearAll();
			}
		}
	}

	private void RenderGrowthAchievementCard(int index, GButton button)
	{
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Expected O, but got Unknown
		Mission mission = curGrowthFundAchievementList[index];
		button.title = mission.Data.Desc ?? "";
		Controller controller = ((GComponent)button).GetController("ReceiveStatus");
		MissionStatus status = mission.MissionState(GameManagers.Instance).Status;
		if (status == MissionStatus.Undergoing || status == MissionStatus.Pending)
		{
			controller.selectedIndex = 0;
		}
		if (status == MissionStatus.Completed)
		{
			controller.selectedIndex = 1;
		}
		if (status == MissionStatus.Claimed)
		{
			controller.selectedIndex = 2;
		}
		if (mission.BonusList != null && mission.BonusList.Count > 0)
		{
			((GObject)((GComponent)button).GetChild("rewardNum").asTextField).text = mission.BonusList[0].Qty.ShortNumberFormat() ?? "";
			Bonus bonus = mission.BonusList[0];
			string itemId = bonus.ItemId;
			GLoader asLoader = ((GComponent)button).GetChild("rewardIcon").asLoader;
			asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
			((GObject)asLoader).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(bonus.ItemId, 2);
			});
			GGraph asGraph = ((GComponent)button).GetChild("fxBack").asGraph;
			if (bonus.IsShining == 2 && status != MissionStatus.Claimed)
			{
				((GObject)asGraph).displayObject.Dispose();
				FGUIManager.Instance.AddTextSpecialEffects(asGraph, "activated_fx", new Vector3(75f, 75f, 75f));
			}
			else
			{
				((GObject)asGraph).displayObject.Dispose();
			}
			GButton asButton = ((GComponent)button).GetChild("ReceiveBtn").asButton;
			((GComponent)asButton).GetChild("note").visible = mission.CanClaimBonus(GameManagers.Instance);
			((GObject)asButton).data = index;
			((GObject)asButton).onClick.Set(new EventCallback1(GetGrowthReward));
			((GObject)asButton).enabled = mission.CanClaimBonus(GameManagers.Instance);
		}
	}

	private void HiddenrGrowthAchievementSFX()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(0f, 6f);
		Vector2 val2 = ((GObject)GrowthFundPanel.AimAchievementListTop).LocalToRoot(Vector2.zero, GRoot.inst);
		Vector2 val3 = ((GObject)GrowthFundPanel.AimAchievementListBottom).LocalToRoot(Vector2.zero, GRoot.inst);
		for (int i = 0; i < GrowthAchievementList.Count; i++)
		{
			Vector2 val4 = ((GObject)GrowthAchievementList[i]).LocalToRoot(Vector2.zero, GRoot.inst);
			bool visible = ((!(val4.y < val2.y + val.y) && !(val4.y > val3.y - ((GObject)GrowthAchievementList[i]).height + val.y)) ? true : false);
			GObject child = ((GComponent)GrowthAchievementList[i]).GetChild("fxBack");
			if (!child.displayObject.isDisposed)
			{
				child.displayObject.visible = visible;
			}
		}
	}

	private void GetGrowthReward(EventContext eventContext)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		int index = (int)((GObject)(GButton)eventContext.sender).data;
		Mission mission = curGrowthFundAchievementList[index];
		ILRequestHelper<MissionClaimResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().MissionClaim(mission.Id), delegate(MissionClaimResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				SharedMessenger.Broadcast("MISSION_CLAIMED", mission);
				foreach (ModelsBonus bonus2 in response.BonusList)
				{
					Bonus bonus = Bonus.Get(bonus2.ItemId, bonus2.Qty, bonus2.Type, bonus2.IsShining);
					bonus.Claim(GameManagers.Instance);
				}
				if (response.BonusList.Count > 0)
				{
					GrowthAchievenmentClaimed(index);
					UpdatePanelShowNote(null);
					UpdateMoneyAndGemNum(response.BonusList);
				}
				FlushActivityRedNoteCache();
				UpdatePanelShowNote(null);
			}
		});
	}

	private void FlushActivityRedNoteCache()
	{
		if (chipFundActivity != null)
		{
			foreach (ActivityContentPayload value in chipFundActivity.ContentPayload(GameManagers.Instance).Values)
			{
				MissionSerialActivityPayload missionSerialActivityPayload = (MissionSerialActivityPayload)value;
				missionSerialActivityPayload.FlushCache();
			}
		}
		if (gemFundActivity != null)
		{
			foreach (ActivityContentPayload value2 in gemFundActivity.ContentPayload(GameManagers.Instance).Values)
			{
				MissionSerialActivityPayload missionSerialActivityPayload2 = (MissionSerialActivityPayload)value2;
				missionSerialActivityPayload2.FlushCache();
			}
		}
		if (growthFundActivity != null)
		{
			foreach (ActivityContentPayload value3 in growthFundActivity.ContentPayload(GameManagers.Instance).Values)
			{
				MissionSerialActivityPayload missionSerialActivityPayload3 = (MissionSerialActivityPayload)value3;
				missionSerialActivityPayload3.FlushCache();
			}
		}
		if (legionCultivateFundActivity == null)
		{
			return;
		}
		foreach (ActivityContentPayload value4 in legionCultivateFundActivity.ContentPayload(GameManagers.Instance).Values)
		{
			MissionSerialActivityPayload missionSerialActivityPayload4 = (MissionSerialActivityPayload)value4;
			missionSerialActivityPayload4.FlushCache();
		}
	}

	private void GrowthAchievenmentClaimed(int index)
	{
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		((GObject)GrowthFundPanel).touchable = false;
		GButton button = GrowthAchievementList[index];
		if (!((GObject)((GComponent)button).GetChild("fxBack").asGraph).displayObject.isDisposed)
		{
			((GObject)((GComponent)button).GetChild("fxBack").asGraph).displayObject.Dispose();
		}
		((GObject)button).relations.ClearAll();
		if (index != GrowthAchievementList.Count - 1)
		{
			((GObject)GrowthAchievementList[index + 1]).RemoveRelation((GObject)(object)button, (RelationType)9);
		}
		GrowthAchievementList.RemoveAt(index);
		GTweenCallback val = default(GTweenCallback);
		((GComponent)button).GetTransition("disappear").Play((PlayCompleteCallback)delegate
		{
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected O, but got Unknown
			//IL_00eb: Expected O, but got Unknown
			GrowthAchievementList.Add(button);
			((GObject)button).SetXY(0f, (float)(GrowthAchievementList.Count * 143));
			((GObject)button).AddRelation((GObject)(object)GrowthAchievementList[GrowthAchievementList.Count - 2], (RelationType)9);
			((GObject)button).alpha = 1f;
			GrowthFundActivityAimAchievementListSort();
			RenderGrowthAchievementList();
			GTweener obj = ((GObject)GrowthAchievementList[index]).TweenMoveY((float)(index * 143), 0.5f).SetEase((EaseType)5);
			GTweenCallback obj2 = val;
			if (obj2 == null)
			{
				GTweenCallback val2 = delegate
				{
					if (index != 0)
					{
						((GObject)GrowthAchievementList[index]).AddRelation((GObject)(object)GrowthAchievementList[index - 1], (RelationType)9);
					}
					((GObject)GrowthFundPanel).touchable = true;
				};
				GTweenCallback val3 = val2;
				val = val2;
				obj2 = val3;
			}
			obj.OnComplete(obj2);
			HiddenrGrowthAchievementSFX();
		});
	}

	private void RenderGrowthAchievementList()
	{
		for (int i = 0; i < GrowthAchievementList.Count; i++)
		{
			RenderGrowthAchievementCard(i, GrowthAchievementList[i]);
		}
	}

	private void RenderLegionCultivateFundPanel()
	{
		foreach (Activity item in HomePageActivity)
		{
			if (item.UiName == "UI_LegionCultivateFundPanel")
			{
				legionCultivateFundActivity = item;
				break;
			}
		}
		if (legionCultivateFundActivity != null)
		{
			List<string> activityIds = new List<string> { legionCultivateFundActivity.ActivityId };
			if (legionCultivateFundActivity.ActivityProgress(GameManagers.Instance).IsNew)
			{
				GameManagers.Instance.ActivityManager.ReviewActivities(activityIds);
			}
			MissionSerialActivityPayload missionSerialActivityPayload = (MissionSerialActivityPayload)legionCultivateFundActivity.ContentPayload(GameManagers.Instance).Values.First();
			List<Mission> allMissions = missionSerialActivityPayload.Missions(GameManagers.Instance);
			if (AllBonusClaimed(allMissions))
			{
				legionCultivateFundActivity = null;
				return;
			}
			LegionCultivateFundActivityAimAchievementListSort(allMissions);
			RenderLegionCultivateFundBonus();
			((GObject)LegionCultivateFundPanel).alpha = 1f;
		}
	}

	private void RenderLegionCultivateFundBonus(int curIndex = -1)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		((GObject)LegionCultivateFundPanel.Bonus).data = curIndex;
		LegionCultivateFundPanel.Bonus.itemRenderer = new ListItemRenderer(RenderLegionCultivateFundDailyAchievementItem);
		LegionCultivateFundPanel.Bonus.numItems = curLegionCultivateFundAchievementList.Count;
	}

	private void SetLegionCultivateFundStatus(string itemId)
	{
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		Dictionary<string, int> purchaseStat = GameManagers.Instance.StoreManager.PurchaseStat.GetValue().PurchaseStat;
		if (!purchaseStat.TryGetValue(itemId, out var value) || value <= 0)
		{
			LegionCultivateFundPanel.PageController.selectedIndex = 0;
			Shift.Legion.Common.Models.Store.StoreItem storeItem = Shift.Legion.Common.Models.Store.StoreItem.Get(GameManagers.Instance, itemId);
			KeyValuePair<string, float> priceItemId = FGUIManager.Instance.GetPriceItemId(storeItem);
			string key = priceItemId.Key;
			string text = $"{Convert.ToInt32(priceItemId.Value)}";
			bool flag = key == "RMB";
			ProductLocalInfo value2 = null;
			if (HotUpdateProcess.Instance.IsRegionOutCN && flag)
			{
				((GObject)LegionCultivateFundPanel.priceIcon).visible = false;
				text = ((string.IsNullOrEmpty(storeItem.ReferenceId) || !PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value2)) ? "--" : value2.FormattedPrice);
			}
			else
			{
				((GObject)LegionCultivateFundPanel.priceIcon).visible = true;
			}
			LegionCultivateFundPanel.region.SetSelectedIndex(HotUpdateProcess.Instance.IsRegionOutCN ? 1 : 0);
			((GObject)LegionCultivateFundPanel.priceSea).text = text;
			((GObject)LegionCultivateFundPanel.price).text = text;
			((GObject)LegionCultivateFundPanel.priceIcon).text = "<img src='ui://PublicResources/" + key + "' width='60' height='60'/>";
			LegionCultivateFundPanel.InvestBtn.Type.selectedIndex = 0;
			((GObject)LegionCultivateFundPanel.InvestBtn).data = storeItem;
			((GObject)LegionCultivateFundPanel.InvestBtn).onClick.Set(new EventCallback1(ShowGiftBag));
		}
		else
		{
			LegionCultivateFundPanel.PageController.selectedIndex = 1;
			LegionCultivateFundPanel.InvestBtn.Type.selectedIndex = 1;
		}
	}

	private void LegionCultivateFundActivityAimAchievementListSort(List<Mission> allMissions)
	{
		SetLegionCultivateFundStatus("FundCertStoreItem5");
		curLegionCultivateFundAchievementList.Clear();
		curLegionCultivateFundAchievementList.AddRange(allMissions);
	}

	private void RenderLegionCultivateFundDailyAchievementItem(int index, GObject obj)
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		UI_FundBonusBtn2 _btn = obj as UI_FundBonusBtn2;
		Mission mission = curLegionCultivateFundAchievementList[index];
		int num = Convert.ToInt32(mission.TargetValue(GameManagers.Instance));
		_btn.Day.selectedIndex = num - 1;
		_btn.SetControllerPageText();
		((GObject)_btn.Content.squareSfxBack).SetXY(0f, 0f);
		switch (mission.MissionState(GameManagers.Instance).Status)
		{
		case MissionStatus.Completed:
			_btn.Content.receiveController.selectedIndex = 2;
			FGUIManager.Instance.AddTextSpecialEffects(_btn.Content.squareSfxBack, "stroke_card_trail_square", new Vector3(120f, 120f, 120f));
			FGUIManager.Instance.AddTextSpecialEffects(_btn.Content.activatedSfxBack, "activated_fx", new Vector3(90f, 90f, 90f));
			break;
		case MissionStatus.Undergoing:
			_btn.Content.receiveController.selectedIndex = 0;
			break;
		case MissionStatus.Claimed:
		{
			int num2 = (int)((GObject)LegionCultivateFundPanel.Bonus).data;
			if (num2 == index)
			{
				GGraph cumulativeSfxBack = _btn.Content.cumulativeSfxBack;
				GButton receivedBtn = _btn.Content.ReceivedBtn;
				((GComponent)receivedBtn).GetController("PageController").selectedIndex = 0;
				((GComponent)receivedBtn).GetTransition("stamp").Play((PlayCompleteCallback)delegate
				{
					//IL_0020: Unknown result type (might be due to invalid IL or missing references)
					//IL_008a: Unknown result type (might be due to invalid IL or missing references)
					//IL_008f: Unknown result type (might be due to invalid IL or missing references)
					//IL_0091: Expected O, but got Unknown
					//IL_0096: Expected O, but got Unknown
					FGUIManager.Instance.AddTextSpecialEffects(cumulativeSfxBack, "activating_white", new Vector3(180f, 180f, 180f), "Default", 0.5f, delegate(GameObject activatingWhite)
					{
						activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
					});
					GTweener obj2 = ((GComponent)(object)this).SetTimeout(0.25f);
					GTweenCallback val = default(GTweenCallback);
					GTweenCallback obj3 = val;
					if (obj3 == null)
					{
						GTweenCallback val2 = delegate
						{
							_btn.Content.receiveController.selectedIndex = 1;
							((GComponent)_btn.Content.ReceivedBtn).GetController("PageController").selectedIndex = 1;
						};
						GTweenCallback val3 = val2;
						val = val2;
						obj3 = val3;
					}
					obj2.OnComplete(obj3);
				});
			}
			else
			{
				_btn.Content.receiveController.selectedIndex = 1;
				((GComponent)_btn.Content.ReceivedBtn).GetController("PageController").selectedIndex = 1;
			}
			break;
		}
		}
		KeyValuePair<string, string> keyValuePair = Enumerable.First(mission.DisplayBonus);
		_btn.Content.icon.url = "ui://PublicResources/" + UiHelper.GetIcon(keyValuePair.Key);
		((GObject)_btn.Content.num).text = $"{Convert.ToInt32(keyValuePair.Value)}";
		_btn.Content.num.strokeColor = new Color(0f, 0f, 0f, 0.55f);
		((GObject)_btn.Content).data = mission;
		((GObject)_btn.Content).onClick.Set(new EventCallback1(LegionCultivateFundBonusItemClick));
	}

	private void LegionCultivateFundBonusItemClick(EventContext context)
	{
		UI_FundRewardBtn2 uI_FundRewardBtn = (UI_FundRewardBtn2)(object)context.sender;
		if (uI_FundRewardBtn.receiveController.selectedIndex == 1)
		{
			return;
		}
		Mission _mission = (Mission)((GObject)uI_FundRewardBtn).data;
		KeyValuePair<string, string> keyValuePair = Enumerable.First(_mission.DisplayBonus);
		int bonusItemIndex = curLegionCultivateFundAchievementList.IndexOf(_mission);
		if (uI_FundRewardBtn.receiveController.selectedIndex == 0)
		{
			FGUIManager.Instance.ItemTip(keyValuePair.Key, ((GObject)this).sortingOrder, noCheckBtn: true);
		}
		else
		{
			if (uI_FundRewardBtn.receiveController.selectedIndex != 2)
			{
				return;
			}
			UiAudioManager.Instance.PlaySoundEffect("CoinDrop");
			context.StopPropagation();
			ILRequestHelper<MissionClaimResponse>.Request(context, () => GameController.Contexts.Service<INetworkService>().MissionClaim(_mission.Id), delegate(MissionClaimResponse response)
			{
				if (!response.Result)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
				else
				{
					SharedMessenger.Broadcast("MISSION_CLAIMED", _mission);
					if (response.BonusList != null && response.BonusList.Count > 0)
					{
						FGUIManager.Instance.ClaimBonusFromApiModels(response.BonusList);
						RenderLegionCultivateFundBonus(bonusItemIndex);
						UpdatePanelShowNote(null);
						UpdateMoneyAndGemNum(response.BonusList);
					}
					else
					{
						List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText234") };
						SharedMessenger.Broadcast("SHOW_TIPS", arg, 103, arg3: false);
					}
					FlushActivityRedNoteCache();
					UpdatePanelShowNote(null);
				}
			});
		}
	}

	private void SelectOrcActivityPanel()
	{
		FGUIManager.Instance.OpenIEnumerator(OrcActivityPanel.ScrollToCurrentPotentialNode());
	}

	private void InitSecretTreasury()
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		if (SecretTreasury != null && SecretTreasury.IsEnable() && _secretTreasuryNote != null)
		{
			((GObject)_secretTreasuryNote.title).text = LanguagesManager.GetDesc("ActivityName_SecretTreasury");
			FGUIManager.Instance.AddTextSpecialEffects(SecretTreasuryPanel.topupBtn.effPos, "ui_stroke_button_1", Vector3.one * 100f);
			UI_SpecialActivityPanel.UpdateBackgroundFromLink(SecretTreasury.ActivityBgUrl, SecretTreasuryPanel.activityBg);
			UpdateTabs();
			UnityUiService.Instance.PreLoadPackage("SpecialActivity", RefreshPanel);
		}
	}

	private void TryRefreshSecretTreasuryUiOnShipSuccessEvent()
	{
		if (PageController.selectedIndex == _secretTreasuryTabIndex)
		{
			FGUIManager.Instance.GetDynamicSecretTreasuryActivity(RefreshPanel);
		}
	}

	private void RefreshPanel()
	{
		if (SecretTreasury == null)
		{
			return;
		}
		((GObject)SecretTreasuryPanel.ActivityTime).text = GetActivityTimeDesc(SecretTreasury.BeginTime, SecretTreasury.EndTime);
		List<LimitedTimeTotalRechargeInfo> list = new List<LimitedTimeTotalRechargeInfo>();
		foreach (SecretTreasuryBonus bonusConfig in SecretTreasury.BonusConfigs)
		{
			LimitedTimeTotalRechargeInfo limitedTimeTotalRechargeInfo = new LimitedTimeTotalRechargeInfo
			{
				Rewards = new Dictionary<string, int>(),
				RMB = bonusConfig.Level
			};
			foreach (RItem bonu in bonusConfig.Bonus)
			{
				limitedTimeTotalRechargeInfo.Rewards.Add(bonu.ItemId, bonu.cnt);
			}
			list.Add(limitedTimeTotalRechargeInfo);
		}
		_secretTreasuryViewModel = list;
		_secretTreasuryViewModel.Sort((LimitedTimeTotalRechargeInfo a, LimitedTimeTotalRechargeInfo b) => a.RMB.CompareTo(b.RMB));
		_secretTreasuryViewModel.InsertionSort(LimitedTimeTotalRechargeInfoCompare);
		RefreshAchievements((GComponent)(object)SecretTreasuryPanel.AchievementList, _secretTreasuryViewModel);
	}

	private void RefreshAchievements(GComponent viewContainer, List<LimitedTimeTotalRechargeInfo> viewModels)
	{
		float topY = GetTopY(_secretTreasuryViewModel);
		for (int num = viewContainer.numChildren - 1; num >= 0; num--)
		{
			GObject childAt = viewContainer.GetChildAt(num);
			viewContainer.RemoveChild(childAt, true);
		}
		for (int i = 0; i < viewModels.Count; i++)
		{
			GButton val = (GButton)(object)UI_RechargeBonus.CreateInstance();
			viewContainer.AddChild((GObject)(object)val);
			((GObject)val).SetXY(0f, (float)(i * 143) + topY);
			UI_RechargeBonus card = (UI_RechargeBonus)(object)val;
			LimitedTimeTotalRechargeInfo limitedTimeTotalRechargeInfo = viewModels[i];
			float toTotalRecharge = SecretTreasury.ToTotalRecharge;
			float targetTotalRechargeTier = limitedTimeTotalRechargeInfo.RMB;
			ArchiveExtension_DynamicActivity_LTTR.BonusState state = SecretTreasury.GetState(limitedTimeTotalRechargeInfo.RMB);
			UI_SpecialActivityPanel.RenderCumulativeAchievementCard(i, toTotalRecharge, targetTotalRechargeTier, card, limitedTimeTotalRechargeInfo, state, OnClickClaimReward);
		}
		RefreshAchievementSFX();
	}

	private void OnClickClaimReward(EventContext eventContext, UI_RechargeBonus card)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		int index = (int)((GObject)(GButton)eventContext.sender).data;
		int level = _secretTreasuryViewModel[index].RMB;
		Task<ClaimDynamicSecretTreasuryResponse> task = GameController.Contexts.Service<INetworkService>().ClaimDynamicSecretTreasury(level);
		GTweenCallback val = default(GTweenCallback);
		task.GetAwaiter().OnCompleted(delegate
		{
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Expected O, but got Unknown
			ClaimDynamicSecretTreasuryResponse result = task.Result;
			if (result.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(result.ErrorCode);
			}
			else
			{
				SecretTreasury.Claim(level);
				GameManagers.Instance.StockController.ReadStockChangeRecords(result.StockChangeRecords);
				GvGMode3RoomManager.DisplayStockChangeTips(result.StockChangeRecords);
				((GObject)SecretTreasuryPanel).touchable = false;
				UI_RechargeBonus button = card;
				float topY = GetTopY(_secretTreasuryViewModel);
				button.disappear.Play((PlayCompleteCallback)delegate
				{
					//IL_0175: Unknown result type (might be due to invalid IL or missing references)
					//IL_017a: Unknown result type (might be due to invalid IL or missing references)
					//IL_017d: Expected O, but got Unknown
					//IL_0182: Expected O, but got Unknown
					((GObject)button).SetXY(0f, (float)(((GObject)card).parent.numChildren * 143) + topY);
					((GObject)button).alpha = 1f;
					button.ReceiveStatus.SetSelectedIndex(2);
					((GObject)button.receiveBtn.note).visible = false;
					((GObject)button.receiveBtn).enabled = false;
					GComponent parent = ((GObject)card).parent;
					int num = parent.GetChildIndex((GObject)(object)card) + 1;
					bool flag = num < parent.numChildren;
					for (int i = 0; i < parent.numChildren; i++)
					{
						GObject childAt = parent.GetChildAt(i);
						childAt.TweenMoveY(childAt.y - 143f, 0.5f).SetEase((EaseType)5);
					}
					if (!flag)
					{
						((GObject)SecretTreasuryPanel).touchable = true;
						RefreshPanel();
						UpdateTabs();
					}
					else
					{
						GTweener obj = ((GObject)this).TweenFade(1f, 0.5f);
						GTweenCallback obj2 = val;
						if (obj2 == null)
						{
							GTweenCallback val2 = delegate
							{
								((GObject)SecretTreasuryPanel).touchable = true;
								RefreshPanel();
								UpdateTabs();
							};
							GTweenCallback val3 = val2;
							val = val2;
							obj2 = val3;
						}
						obj.OnComplete(obj2);
					}
				});
			}
		});
	}

	private int LimitedTimeTotalRechargeInfoCompare(LimitedTimeTotalRechargeInfo a, LimitedTimeTotalRechargeInfo b)
	{
		ArchiveExtension_DynamicActivity_LTTR.BonusState state = SecretTreasury.GetState(a.RMB);
		ArchiveExtension_DynamicActivity_LTTR.BonusState state2 = SecretTreasury.GetState(b.RMB);
		return GetOrder(state).CompareTo(GetOrder(state2));
	}

	private static int GetOrder(ArchiveExtension_DynamicActivity_LTTR.BonusState state)
	{
		return state switch
		{
			ArchiveExtension_DynamicActivity_LTTR.BonusState.Undergoing => 1, 
			ArchiveExtension_DynamicActivity_LTTR.BonusState.Pending => 0, 
			ArchiveExtension_DynamicActivity_LTTR.BonusState.Claimed => 2, 
			_ => throw new ArgumentOutOfRangeException("state", state, null), 
		};
	}

	private float GetTopY(List<LimitedTimeTotalRechargeInfo> viewModels)
	{
		float result = 0f;
		foreach (string key in viewModels[0].Rewards.Keys)
		{
			if (UI_SpecialActivityPanel.useBubbleItemID.Contains(key))
			{
				result = 53f;
			}
		}
		return result;
	}

	private void OnClickShowSecretTreasury()
	{
		SecretTreasury.ActivityDesc.ToConfirmPopup(null, null, (AlignType)0, 32, mirrorBtns: false, needCancelButton: false);
	}

	public static string GetActivityTimeDesc(DateTimeOffset beginTime, DateTimeOffset endTime)
	{
		string arg;
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			object[] args = new object[2]
			{
				UiHelper.GetDateStringMMddHH(beginTime.DateTime),
				UiHelper.GetDateStringMMddHH(endTime.DateTime)
			};
			arg = string.Format(LanguagesManager.GetDesc("CsharpEventStartEndTime"), args);
		}
		else
		{
			string text = "yyyy" + LanguagesManager.GetDesc("CsharpCodeZhTcText557") + "MM" + LanguagesManager.GetDesc("CsharpCodeZhTcText397") + "dd" + LanguagesManager.GetDesc("CsharpCodeZhTcText398") + "HH:mm";
			arg = beginTime.DateTime.ToString(text) + LanguagesManager.GetDesc("CsharpCodeZhTcText558") + "\n" + endTime.DateTime.ToString(text) + LanguagesManager.GetDesc("CsharpCodeZhTcText559");
		}
		return HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format("SecretTreasuryActivityDateDesc".ToLanguage(), arg);
	}

	private void UpdateTabs()
	{
		((GObject)_secretTreasuryNote.note).visible = SecretTreasury.HasAnyInform();
	}

	private void OnDestroySecretTreasury()
	{
		UnityUiService.Instance.UnloadPackage("SpecialActivity");
	}

	private void RefreshAchievementSFX()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(0f, 6f);
		Vector2 val2 = ((GObject)SecretTreasuryPanel.AimAchievementListTop).LocalToRoot(Vector2.zero, GRoot.inst);
		Vector2 val3 = ((GObject)SecretTreasuryPanel.AimAchievementListBottom).LocalToRoot(Vector2.zero, GRoot.inst);
		for (int i = 0; i < ((GComponent)SecretTreasuryPanel.AchievementList).numChildren; i++)
		{
			UI_RechargeBonus uI_RechargeBonus = (UI_RechargeBonus)(object)((GComponent)SecretTreasuryPanel.AchievementList).GetChildAt(i);
			Vector2 val4 = ((GObject)uI_RechargeBonus).LocalToRoot(Vector2.zero, GRoot.inst);
			bool visible = ((!(val4.y < val2.y + val.y) && !(val4.y > val3.y - ((GObject)uI_RechargeBonus).height + val.y)) ? true : false);
			GList bonusList = uI_RechargeBonus.BonusList;
			GObject[] children = ((GComponent)bonusList).GetChildren();
			foreach (GObject val5 in children)
			{
				UI.SpecialActivity.UI_RechargeRewardItem uI_RechargeRewardItem = (UI.SpecialActivity.UI_RechargeRewardItem)(object)val5;
				if (!((GObject)uI_RechargeRewardItem.fxBack).displayObject.isDisposed)
				{
					((GObject)uI_RechargeRewardItem.fxBack).displayObject.visible = visible;
				}
			}
		}
	}

	public void InitShadowDemonActivity()
	{
		if (HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi.ActivityEntranceController.IsShadowDemonGiftVisible() && _shadowDemonActTab != null)
		{
			Activity shadowDemonGift = ActivityManager.ShadowDemonGift;
			if (shadowDemonGift != null)
			{
				Dictionary<string, ActivityContentPayload> source = shadowDemonGift.ContentPayload(GameManagers.Instance);
				SoliderDevelopPayload payload = Enumerable.First(source).Value as SoliderDevelopPayload;
				RefreshShadowDemonActivityTab();
				_initedShadowDemon = true;
				ShadowDemonGift.Init(this, payload);
			}
		}
	}

	public void RefreshShadowDemonActivityTab()
	{
		((GObject)_shadowDemonActTab.note).visible = ActivityEntranceRedDotController.IsShadowDemonGiftNoteVisible();
	}

	private void OnDestroyShadowDemonActivity()
	{
		if (_initedShadowDemon)
		{
			ShadowDemonGift.OnDestroy();
			if (PushGiftBagOnClose)
			{
				SharedMessenger.Broadcast("ON_PUSH_GIFT_BAG_REFRESH_EXT", arg1: true);
			}
		}
	}

	private void OnPageChangedShowDemon()
	{
		if (_initedShadowDemon)
		{
			ShadowDemonGift.RefreshUnlockState();
		}
	}

	private void RenderSpinWeekActivity()
	{
		if (_spinWeekNote != null)
		{
			_spinWeekInfo = ActivityManager.SpinWeekActivity;
			int activityType = (int)_spinWeekInfo.ActivityType;
			SpinWeekSpin.Type.SetSelectedIndex(activityType);
			_spinWheelPage = (ISpinWheelPage)SpinWeekSpin.pageLoader.component;
			_spinWheelPage.Parent = this;
			_spinWheelPage.Init();
			_spinWheelPage.RegisterUiEventListeners();
			UpdateSpinWeekTabs();
		}
	}

	public void SetPanelMask(bool isBlock)
	{
		((GObject)topMask).visible = isBlock;
	}

	private void OnClickTopMask()
	{
		ETopMaskClicked?.Invoke();
		SetPanelMask(isBlock: false);
	}

	private void UpdateSpinWeekTabs()
	{
		((GObject)_spinWeekNote.note).visible = _spinWeekInfo.HasAnyInform();
	}

	private void OnSpinWeekProgressChange(GetWeeklyActivityResponse response)
	{
		_spinWeekInfo = response;
		UpdateSpinWeekTabs();
		RefreshCurrencyGroup();
	}

	private void OnDestroySpinWeek()
	{
		_spinWheelPage?.UnregisterUiEventListeners();
	}

	public void RefreshCurrencyGroup()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		string curPageName = CurPageName;
		if (curPageName == UI_com_SpinWeekSpin.Name)
		{
			CurrencyType.SetSelectedIndex(1);
			RenderCurrencyBtn(addItemBtn1, "Gem", new EventCallback0(DiamondBtnEvent));
			RenderCurrencyBtn(addItemBtn2, _spinWeekInfo.ActivityConfig.LotteryItemId, new EventCallback0(OnClickOpenGiftBag));
		}
		else
		{
			CurrencyType.SetSelectedIndex(0);
		}
	}

	private void RenderCurrencyBtn(GComponent item, string itemName, EventCallback0 onBtnClick)
	{
		UI_addDiamondBtn uI_addDiamondBtn = (UI_addDiamondBtn)(object)item;
		int stock = GameManagers.Instance.StockController.GetStock(itemName);
		((GObject)uI_addDiamondBtn.num).text = stock.ToString();
		if (!(((GObject)uI_addDiamondBtn).data is string text) || !(text == itemName))
		{
			((GObject)uI_addDiamondBtn).data = itemName;
			uI_addDiamondBtn.diamond.url = UiHelper.GetItemIconPath(itemName);
			((GObject)uI_addDiamondBtn.addButton).onClick.Set(onBtnClick);
		}
	}

	private void OnClickOpenGiftBag()
	{
		_spinWheelPage.OnClickGiftPackBtn();
	}

	private void RenderWeekActPass()
	{
		if (HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi.ActivityEntranceController.IsWeekActPassVisible() && _weekActTab != null)
		{
			UnityUiService.Instance.PreLoadPackage("WeekActivityPass", delegate
			{
				_weekActPass = UI_main_WeekActivityPass.CreateInstance();
				((GComponent)WeekPassContainer).AddChild((GObject)(object)_weekActPass);
				_weekActPass.RegisterUiEventListeners();
				_weekActPass.Init(this);
				UpdateWeekActPassTabs();
			});
		}
	}

	public void UpdateWeekActPassTabs()
	{
		((GObject)_weekActTab.note).visible = ActivityEntranceRedDotController.IsWeekActPassNoteVisible();
	}

	private void OnDestroyWeekActPass()
	{
		_weekActPass?.UnregisterUiEventListeners();
		UnityUiService.Instance.UnloadPackage("WeekActivityPass");
	}
}
