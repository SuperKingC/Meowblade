using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using FairyGUI;
using GameDataEditor;
using GameMaths;
using HotFix;
using HotFix.Sources.Base.Scripts.AudioManager;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.UI;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol.UserAction;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;
using Shift.Legion.ClientApi;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.Store;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.RPC.Api;
using Shift.Legion.ClientApi.Sources.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;
using Spine.Unity;
using UI;
using UI.Contract;
using UI.DebrisCompound;
using UI.GameActivity;
using UI.GameEndPanels;
using UI.Guide;
using UI.LegendItemBlueprint;
using UI.LegendItemInfo;
using UI.Legion;
using UI.MainCity;
using UI.MaskCover;
using UI.MilitaryIntelligence;
using UI.MonthCard;
using UI.PublicResources;
using UI.SoldierCultivate;
using UI.Souvenir;
using UI.Technology;
using UI.Tips;
using UI.UnlockSoldierShow;
using UI.UpGrade;
using UI.UpPropGrade;
using UI.UpgradePotential;
using UI.Warehouse;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;

public class FGUIManager : MonoBehaviour
{
	public delegate void LongPress(int index, UI_ExperiencePage page);

	private class CoroutineWithData
	{
		public object Result;

		private IEnumerator target;

		private readonly MonoBehaviour Owner;

		public Coroutine Coroutine { get; private set; }

		public CoroutineWithData(MonoBehaviour owner, IEnumerator target)
		{
			Owner = owner;
			this.target = target;
			Coroutine = Owner.StartCoroutine(Run());
		}

		public void Stop()
		{
			Owner.StopCoroutine(Coroutine);
		}

		private IEnumerator Run()
		{
			while (target.MoveNext())
			{
				Result = target.Current;
				yield return Result;
			}
		}
	}

	public class UserInfoCache
	{
		public string NickName;

		public Texture2D Avatar;
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static EventCallback0 _003C_003E9__77_0;

		public static Func<Task<EnterGameResponse>> _003C_003E9__85_0;

		public static Action<EnterGameResponse> _003C_003E9__85_1;

		public static GComponentCreator _003C_003E9__93_0;

		public static Func<Task<GetBBSKeyResponse>> _003C_003E9__95_1;

		public static Action _003C_003E9__148_0;

		public static Action _003C_003E9__148_1;

		public static Predicate<Modifier> _003C_003E9__151_0;

		public static Predicate<Modifier> _003C_003E9__151_1;

		public static Func<Task<GetDynamicSecretTreasuryResponse>> _003C_003E9__221_0;

		public static Func<GDEStoreContentConfigData, string> _003C_003E9__223_0;

		public static Func<GDEStoreContentConfigData, GDEStoreContentConfigData> _003C_003E9__223_1;

		public static Func<Shift.Legion.Common.Models.Store.StoreItem, Shift.Legion.Common.Models.Store.StoreItem> _003C_003E9__227_0;

		public static Func<Shift.Legion.Common.Models.Store.StoreItem, int> _003C_003E9__227_1;

		public static Func<Shift.Legion.Common.Models.Store.StoreItem, float> _003C_003E9__227_2;

		public static Func<Shift.Legion.Common.Models.Store.StoreItem, int> _003C_003E9__227_3;

		public static TweenCallback _003C_003E9__241_2;

		public static Action _003C_003E9__277_0;

		public static TweenCallback _003C_003E9__303_0;

		public static Action<bool> _003C_003E9__351_0;

		public static Action<float> _003C_003E9__351_1;

		public static Action<bool> _003C_003E9__356_0;

		public static Action<float> _003C_003E9__356_1;

		internal void _003CStart_003Eb__77_0()
		{
			UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
		}

		internal Task<EnterGameResponse> _003CFGUI_OnApplicationPause_003Eb__85_0()
		{
			return GameController.Contexts.Service<INetworkService>().EnterGame();
		}

		internal void _003CFGUI_OnApplicationPause_003Eb__85_1(EnterGameResponse response)
		{
			GameManagers.Instance.UserArchiveManager.SetDailyLoginStats(response.DailyLoginStats);
			GameManagers.Instance.Messenger.Broadcast("ON_DAILY_LOGIN_STATS", response.DailyLoginStats);
			if (!response.Result || response.Bonuses == null || response.Bonuses.Count < 1)
			{
				GameManagers.Instance.Messenger.Broadcast<List<string>, bool>("BUILDING_NEED_RESUME_PRODUCE", null, arg2: false);
				return;
			}
			GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
			List<Bonus> list = new List<Bonus>();
			foreach (ModelsBonus bonuse in response.Bonuses)
			{
				list.Add(Bonus.Get(bonuse.ItemId, bonuse.Qty));
			}
			GameController.Contexts.gameState.ReplaceOfflineSeconds(response.OfflineSeconds);
			GameController.Contexts.gameState.ReplaceOfflineBonuses(list);
			Instance.GvGMode3OfflineBonusInfo = new GvGMode3OfflineBonusModel
			{
				GvGFetchGapTime = response.GvGFetchGapTime,
				FullItemId = response.FullItemId
			};
			GameManagers.Instance.Messenger.Broadcast<List<string>, bool>("BUILDING_NEED_RESUME_PRODUCE", null, arg2: false);
		}

		internal GComponent _003ConPlayReplay_003Eb__93_0()
		{
			return HotFixManager.Instance.appdomain.Instantiate<GComponent>(typeof(UI_Btn_BattleSkip).FullName, (object[])null);
		}

		internal Task<GetBBSKeyResponse> _003COpenForumUserProfilePage_003Eb__95_1()
		{
			return GameController.Contexts.Service<INetworkService>().GetBBSKey();
		}

		internal void _003COpenMonthCardOverdueTipPanel_003Eb__148_0()
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_MonthCardPanel.Name, new Dictionary<string, object> { 
			{
				"Activity",
				Instance.GetBlackMarketerActivity("UI_MonthCardPanel")
			} });
		}

		internal void _003COpenMonthCardOverdueTipPanel_003Eb__148_1()
		{
			SharedMessenger.Broadcast("OPEN_WORKER_OVERVIEW_PANEL");
		}

		internal bool _003COpenTakeItems_003Eb__151_0(Modifier modifer)
		{
			return modifer.ModifierId == "UIParams";
		}

		internal bool _003COpenTakeItems_003Eb__151_1(Modifier modifer)
		{
			return modifer.ModifierId == "UIParams";
		}

		internal Task<GetDynamicSecretTreasuryResponse> _003CGetDynamicSecretTreasuryActivity_003Eb__221_0()
		{
			return GameController.Contexts.Service<INetworkService>().GetDynamicSecretTreasury();
		}

		internal string _003CGetDynamicStoreContentConfig_003Eb__223_0(GDEStoreContentConfigData c)
		{
			return c.Key;
		}

		internal GDEStoreContentConfigData _003CGetDynamicStoreContentConfig_003Eb__223_1(GDEStoreContentConfigData c)
		{
			return c;
		}

		internal Shift.Legion.Common.Models.Store.StoreItem _003CGiftBagSort_003Eb__227_0(Shift.Legion.Common.Models.Store.StoreItem storeItem)
		{
			return storeItem;
		}

		internal int _003CGiftBagSort_003Eb__227_1(Shift.Legion.Common.Models.Store.StoreItem time)
		{
			return Mathf.Abs(time.ExpireTimestamp - (int)GameController.Instance.GetServerTime());
		}

		internal float _003CGiftBagSort_003Eb__227_2(Shift.Legion.Common.Models.Store.StoreItem discount)
		{
			return discount.Discount;
		}

		internal int _003CGiftBagSort_003Eb__227_3(Shift.Legion.Common.Models.Store.StoreItem purchaseLimit)
		{
			return (int)purchaseLimit.PurchaseLimitPeriod;
		}

		internal void _003CSetMainCityCameraMoveInfo_003Eb__241_2()
		{
			((GObject)GRoot.inst).touchable = true;
		}

		internal void _003CShowDialogTip_003Eb__277_0()
		{
		}

		internal void _003CPlayCampSlotCastAnimationBefore_003Eb__303_0()
		{
		}

		internal void _003CDownloadGvG2ZipReplay_003Eb__351_0(bool isSuccess)
		{
			if (!isSuccess)
			{
			}
		}

		internal void _003CDownloadGvG2ZipReplay_003Eb__351_1(float progress)
		{
			float barValue = progress * 65f;
			UnityUiService.Instance.SetWaitingPanelDownloadProgress(barValue, LanguagesManager.GetDesc("CsharpCodeZhTcText52"));
		}

		internal void _003CDownloadZipReplay_003Eb__356_0(bool isSuccess)
		{
			if (!isSuccess)
			{
			}
		}

		internal void _003CDownloadZipReplay_003Eb__356_1(float progress)
		{
			float barValue = progress * 65f;
			UnityUiService.Instance.SetWaitingPanelDownloadProgress(barValue, LanguagesManager.GetDesc("CsharpCodeZhTcText52"));
		}
	}

	public static FGUIManager Instance;

	private DateTimeOffset _latestRunningTime;

	private bool isPlayingTips = false;

	private List<Dictionary<string, object>> tipsPlaylist = new List<Dictionary<string, object>>();

	private Dictionary<GObject, bool> UIsScaleAdaptation;

	public string messageTemp;

	public string senderTemp;

	public GameObject mainCity;

	public Dictionary<string, GameObject> mainCityPos = new Dictionary<string, GameObject>();

	public float difference;

	public float cameraFrameX;

	public string userName;

	private Camera _StageCamera;

	public Dictionary<string, double> BothHealthBarValues = new Dictionary<string, double>();

	public bool MainCityUiTouchable;

	public IEnumerator LongPressEvent;

	public LongPress myLongPress;

	public string uiGreen = "common_ui_green";

	public string uiRed = "common_ui_red";

	public float OpenNewSoldierInterval = 0.8f;

	public UI_ContractPanel ContractPanel;

	public IEnumerator ShowNewSoldierEnumerator;

	public IEnumerator CanCloseLoadingUITiming;

	public float CloseLoadingUITime = 2.5f;

	private List<string> spriteList = new List<string>();

	public int curLegionSizeLimit;

	public Dictionary<string, IEnumerator> buildingFlowLight = new Dictionary<string, IEnumerator>();

	public Dictionary<string, IEnumerator> slotFlowLight = new Dictionary<string, IEnumerator>();

	public List<KeyValuePair<UIPanel, Building>> buildingTitleList = new List<KeyValuePair<UIPanel, Building>>();

	public Dictionary<string, UIPanel> buildingUpgradeStageDic = new Dictionary<string, UIPanel>();

	public Dictionary<string, GObject> buildingRedDot = new Dictionary<string, GObject>();

	public UI_MainCity MaincityUi;

	public Dictionary<string, tKeyValue<UI_buildingDirectionIndicator, int>> buildingIndicators = new Dictionary<string, tKeyValue<UI_buildingDirectionIndicator, int>>();

	public Dictionary<int, GameObject> formationMarks;

	public bool IsFirstMakeWar;

	public bool IsShowMonthCardFirst;

	public bool IsShowMonthCardOverdueTip;

	public UI_SoldierCultivate SoldierCultivatePanel;

	public UI_UpgradeSuccessPanel UpgradeSuccessPanel;

	public UI_WarehousePanel WarehousePanel;

	public UI_DebrisCompoundPanel DebrisCompoundPanel;

	public UI_Technology TechnologyPanel;

	public UI_LegionPanel LegionPanel;

	public UI_DamageMeter DamageMeter;

	public UI_MaskCover MaskCover;

	public UI_GameEndPanelVictory GameEndPanelVictoryPanel;

	public Tuple<string, string, int, Dictionary<string, string>> BlueprintUpGradeInfo;

	public bool leaseholdChanged = false;

	public List<ClientMail> MailsList = new List<ClientMail>();

	public NewsTicker MyTicker;

	private int inviterNameRepeatCnt = 0;

	public Dictionary<string, GoblinController> inviterAndWorkers = new Dictionary<string, GoblinController>();

	public int curAnnouncementId;

	public bool certificationTabChecked;

	public Shader _FairyGUIFlowWithMask;

	public Shader _FairyGUIFlowCrossingUp;

	public Shader _FairyGUI_Image;

	public Shader _IdleLegion_CharacterFX;

	public Texture2D _noise_2_orange;

	public Texture2D _frame_avatar_square_mask;

	public Texture2D card_recycle_mask;

	public Texture2D shine_fx_recyclecard;

	public Texture2D scroll_monthcard_mask;

	public Texture2D shine_fx_monthcard;

	public static Dictionary<string, string> spriteSheets;

	public Dictionary<string, Shift.Legion.ClientApi.Protocol.Store.StoreItem[]> BlackMarket_StoreItem;

	public List<Shift.Legion.ClientApi.Protocol.Store.StoreItem> BlackMarket_PurchaseLimit;

	public string CustomerServiceQQ;

	public ActivityEntranceController activityEntranceController;

	public static List<string> orderID;

	private GComponent isoComponent;

	private UI_Btn_BattleSkip _UI_Btn_BattleSkip = null;

	private Dictionary<string, object> BuildingSpriteDic = new Dictionary<string, object>();

	public Coroutine uiAndSceneAdaptationsOnChangeScreenSizeCoroutine;

	public float lastUpdateScreenTime;

	private float lastScreenWidth = -1f;

	private float lastScreenHeight = -1f;

	private static float MaincityWidth;

	private static float MaincityHeight;

	public List<SimpleDynamicPromotionActivity> SimpleDynamicPromotionActivities;

	public LimitedTimeTotalRechargeActivity LimitedTimeTotalRechargeCurrentActivity;

	public List<SimpleDynamicSigninActivity> SimpleDynamicSigninActivities;

	public List<SimpleDynamicCardPoolActivity> SimpleDynamicCardPoolActivities;

	public TreasureHouseRechargeInfo BlackMarketTreasureData;

	public const string NoviceRechargeActivityId = "NoviceRecharge_Demo";

	public NoviceRechargeData NoviceRechargeData;

	public NeutralDungeonData NeutralDungeonData;

	private Task<NeutralDungeonData> _loadingTask;

	public List<SimpleDynamicCardPoolActivity> WorldBossActivities;

	public List<DynamicIslandComeAgainActivity> IslandComeAgainActivities;

	public PlayerReturnActivity PlayerReturnActivity;

	public DynamicSecretTreasuryActivity DynamicSecretTreasury;

	public List<Shift.Legion.Common.Models.Store.StoreItem> pushStoreItems = new List<Shift.Legion.Common.Models.Store.StoreItem>();

	public Shift.Legion.Common.Models.Store.StoreItem NewPushStoreItem;

	public List<string> curPushStoreItemsId = new List<string>();

	public Activity curPushGiftBagActivity;

	private const float TurnPageBtnOffset = 65f;

	public GvGMode3OfflineBonusModel GvGMode3OfflineBonusInfo;

	private Dictionary<GComponent, GComponent> _cache_SoliderSoulStone;

	public Dictionary<string, Coroutine> NameTextMobileCoroutines = new Dictionary<string, Coroutine>();

	public Dictionary<int, UserInfoCache> UserInfosCache;

	private Dictionary<string, List<Texture2D>> _needReleaseTexture2Ds;

	public GameObject temp_BattleAudioManager;

	public BattleAudioManager BattleAudioManager;

	private int total_download_cnt = 0;

	private int retry_times = 0;

	private int lastUpdateGVGDisableTimestamp = 0;

	public Camera StageCamera
	{
		get
		{
			if ((Object)(object)_StageCamera == (Object)null)
			{
				_StageCamera = GameObject.Find("Stage Camera").GetComponent<Camera>();
			}
			return _StageCamera;
		}
	}

	public bool SkipShowTechUpgradeTip { get; set; }

	public static string BlackMarketTreasureActivityId => HotUpdateProcess.Instance.IsRegionOutCN ? "TotalRecharge2_International" : "TotalRecharge2";

	public static string NeutralDungeonActivityId
	{
		get
		{
			if (HotUpdateProcess.RegionKey == "sea")
			{
				return "NeutralDungeon_Demo_sea";
			}
			return "NeutralDungeon_Demo";
		}
	}

	public static bool IsTapTap { get; set; }

	public static bool TapTapInitFinished { get; set; }

	private void Awake()
	{
		uiGreen = "common_ui_green";
		uiRed = "common_ui_red";
		spriteSheets = new Dictionary<string, string>
		{
			{ "image/battlefieldb.ab", "battlefieldb" },
			{ "image/battlefieldc.ab", "battlefieldc" },
			{ "image/buildingicons.ab", "buildingicons" },
			{ "image/item.ab", "item" }
		};
		MailsList = new List<ClientMail>();
		tipsPlaylist = new List<Dictionary<string, object>>();
		UIsScaleAdaptation = new Dictionary<GObject, bool>();
		mainCityPos = new Dictionary<string, GameObject>();
		BothHealthBarValues = new Dictionary<string, double>();
		spriteList = new List<string>();
		buildingFlowLight = new Dictionary<string, IEnumerator>();
		slotFlowLight = new Dictionary<string, IEnumerator>();
		buildingTitleList = new List<KeyValuePair<UIPanel, Building>>();
		buildingUpgradeStageDic = new Dictionary<string, UIPanel>();
		buildingRedDot = new Dictionary<string, GObject>();
		buildingIndicators = new Dictionary<string, tKeyValue<UI_buildingDirectionIndicator, int>>();
		inviterAndWorkers = new Dictionary<string, GoblinController>();
		pushStoreItems = new List<Shift.Legion.Common.Models.Store.StoreItem>();
		curPushStoreItemsId = new List<string>();
		NameTextMobileCoroutines = new Dictionary<string, Coroutine>();
		UserInfosCache = new Dictionary<int, UserInfoCache>();
		BuildingSpriteDic = new Dictionary<string, object>();
		_needReleaseTexture2Ds = new Dictionary<string, List<Texture2D>>();
		BlackMarket_StoreItem = null;
		BlackMarket_PurchaseLimit = null;
		Instance = this;
		lastUpdateScreenTime = 0f;
		if (((GObject)GRoot.inst).width / ((GObject)GRoot.inst).height <= 2.3703704f)
		{
			lastScreenWidth = Screen.width;
			lastScreenHeight = Screen.height;
		}
		StageCamera.clearFlags = (CameraClearFlags)3;
	}

	private void Start()
	{
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Expected O, but got Unknown
		Timers.catchCallbackExceptions = false;
		Input.multiTouchEnabled = false;
		IsFirstMakeWar = true;
		IsShowMonthCardFirst = true;
		IsShowMonthCardOverdueTip = true;
		MainCityUiTouchable = true;
		if (AssetsManager.Instance.spriteSheets == null || AssetsManager.Instance.spriteSheets.Count <= 0)
		{
			AssetsManager.Instance.spriteSheets = DictionaryExtensions.DeepCopy<string, string>(spriteSheets);
		}
		SharedMessenger.AddListener<string, Dictionary<string, object>>("OPEN_FGUI", OpenFUI);
		SharedMessenger.AddListener<List<Announcement>>("ANNOUNCEMENT_RECEIVED", UpdateAnnouncement);
		SharedMessenger.AddListener<string>("CLOSE_UI", CloseNewSoldierUIOnContract);
		SharedMessenger.AddListener<string>("CLOSE_UI", UpdateWorkshopSlot);
		SharedMessenger.AddListener<string>("CLOSE_UI", CheckIsClearUi);
		SharedMessenger.AddListener<List<string>, int, bool>("SHOW_TIPS", ShowTips);
		SharedMessenger.AddListener<string, int, int>("CHAT_MESSAGE_RECEIVED", UpdateMessage);
		SharedMessenger.AddListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", ReLoadBuildings);
		SharedMessenger.AddListener<int>("USER_LEVEL_UP", OnUserLevelUp);
		SharedMessenger.AddListener<List<string>, int, bool>("SHOW_INSTRUCTIONS", ShowInstructions);
		SharedMessenger.AddListener<string, int>("TECH_UPGRADED", OpenTechUi);
		SharedMessenger.AddListener<string, List<Bonus>, Dictionary<string, float>>("CHEST_CLAIMED", OpenTakeItems);
		SharedMessenger.AddListener<int, List<Bonus>>("TIME_MACHINE_LAUNCHED", OpenSandClock);
		SharedMessenger.AddListener<string, int>("BUILDING_UPGRADED", RecycleBuidler);
		SharedMessenger.AddListener<string, int>("BUILDING_UPGRADED", BuildingUpgradeBarFade);
		SharedMessenger.AddListener<string, int>("BUILDING_UPGRADED", MaincityUiRemoveBuildingIndicator);
		SharedMessenger.AddListener<string, int>("BUILDING_UPGRADED", UpdateBuildingsTitle);
		SharedMessenger.AddListener<string>("BUILDING_CONSTRUCTING_COMPLETE", BuildingUpgradeBarEndSet);
		SharedMessenger.AddListener<string>("BUILDING_CONSTRUCTING_COMPLETE", MaincityUiAddBuildingIndicator);
		SharedMessenger.AddListener<string, bool>("CHAPTER_COMPLETE", OnChapterComplete);
		SharedMessenger.AddListener<string, int>("ITEM_UPGRADE", OnItemUpgrade);
		SharedMessenger.AddListener<string, int, Dictionary<string, int>>("SOLDIER_SUMMONING", OnSoldierSummoning);
		SharedMessenger.AddListener<string, DateTimeOffset>("LEASEHOLD_REGISTERD", SetLeaseholdChanged);
		SharedMessenger.AddListener<List<ClientMail>>("MAILS_RECEIVED", UpdateMails);
		SharedMessenger.AddListener<int>("DUNGEON_LEVEL_UP", ShowDungeonLevelUpTip);
		SharedMessenger.AddListener<List<string>, bool>("BUILDING_NEED_PAUSE_PRODUCE", OnInformingPauseProduce);
		SharedMessenger.AddListener<List<string>, bool>("BUILDING_NEED_RESUME_PRODUCE", OnInformingResumeProduce);
		SharedMessenger.AddListener<NewsTicker>("NEWS_TICKER_PULLED", UpdateTicker);
		SharedMessenger.AddListener<Cache_PrinceRedDot>(Cache_PrinceRedDot.ON_PAGE_REDDOT_CHANGE, OnPrinceRedDotChange);
		SharedMessenger.AddListener<string>("PLAY_REPLAY", onPlayReplay);
		SharedMessenger.AddListener<string>("STOP_REPLAY", onStopReplay);
		EventListener onClick = ((GObject)GRoot.inst).onClick;
		object obj = _003C_003Ec._003C_003E9__77_0;
		if (obj == null)
		{
			EventCallback0 val = delegate
			{
				UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
			};
			_003C_003Ec._003C_003E9__77_0 = val;
			obj = (object)val;
		}
		onClick.Add((EventCallback0)obj);
		AssetsManager.Instance.LoadAsset<Shader>("FairyGUIFlowCrossingUp").Then((Action<Shader>)delegate(Shader shader)
		{
			_FairyGUIFlowCrossingUp = shader;
		});
		AssetsManager.Instance.LoadAsset<Shader>("FairyGUIFlowWithMask").Then((Action<Shader>)delegate(Shader shader)
		{
			_FairyGUIFlowWithMask = shader;
		});
		_FairyGUI_Image = Shader.Find("FairyGUI/Image");
		_IdleLegion_CharacterFX = Shader.Find("IdleLegion/CharacterFX");
		AssetsManager.Instance.LoadAsset<Texture2D>("noise_2_orange").Then((Action<Texture2D>)delegate(Texture2D asset)
		{
			_noise_2_orange = asset;
		});
		AssetsManager.Instance.LoadAsset<Texture2D>("frame_avatar_square_mask").Then((Action<Texture2D>)delegate(Texture2D asset)
		{
			_frame_avatar_square_mask = asset;
		});
		AssetsManager.Instance.LoadAsset<Texture2D>("card_recycle_mask").Then((Action<Texture2D>)delegate(Texture2D asset)
		{
			card_recycle_mask = asset;
		});
		AssetsManager.Instance.LoadAsset<Texture2D>("shine_fx_recyclecard").Then((Action<Texture2D>)delegate(Texture2D asset)
		{
			shine_fx_recyclecard = asset;
		});
		AssetsManager.Instance.LoadAsset<Texture2D>("scroll_monthcard_mask").Then((Action<Texture2D>)delegate(Texture2D asset)
		{
			scroll_monthcard_mask = asset;
		});
		AssetsManager.Instance.LoadAsset<Texture2D>("shine_fx_monthcard").Then((Action<Texture2D>)delegate(Texture2D asset)
		{
			shine_fx_monthcard = asset;
		});
	}

	private void OnInformingResumeProduce(List<string> buildingTypes, bool needRefund)
	{
		foreach (Building value2 in GameManagers.Instance.BuildingManager.Buildings.Values)
		{
			if (!(value2 is WorkShop workShop) || (buildingTypes != null && !buildingTypes.Contains(value2.BuildingType)) || !(workShop.Controller is WorkshopController workshopController))
			{
				continue;
			}
			Dictionary<string, ProductionConfig> productionConfigs = workShop.ProductionConfigs;
			foreach (KeyValuePair<string, ProductionConfig> item in productionConfigs)
			{
				int num = int.Parse(item.Key);
				ProductionConfig value = item.Value;
				if (value.Workers < 1 || value.ProductList.Count < 1)
				{
					continue;
				}
				GameObject val = workshopController.WorkbenchNominal[num];
				if (value2 is MoltenCore)
				{
					RecycleWorkbench component = val.GetComponent<RecycleWorkbench>();
					if (needRefund)
					{
						component.InterruptProduce();
					}
					component.IsPaused = false;
				}
				else
				{
					Workbench component2 = val.GetComponent<Workbench>();
					if (needRefund && component2.workerController.IsWorking)
					{
						component2.InterruptProduce();
					}
					component2.IsPaused = false;
				}
			}
		}
	}

	private void OnInformingPauseProduce(List<string> buildingTypes, bool needRefund)
	{
		foreach (Building value2 in GameManagers.Instance.BuildingManager.Buildings.Values)
		{
			if (!(value2 is WorkShop workShop) || (buildingTypes != null && !buildingTypes.Contains(value2.BuildingType)) || !(workShop.Controller is WorkshopController workshopController))
			{
				continue;
			}
			Dictionary<string, ProductionConfig> productionConfigs = workShop.ProductionConfigs;
			foreach (KeyValuePair<string, ProductionConfig> item in productionConfigs)
			{
				int num = int.Parse(item.Key);
				ProductionConfig value = item.Value;
				if (value.Workers < 1 || value.ProductList.Count < 1)
				{
					continue;
				}
				GameObject val = workshopController.WorkbenchNominal[num];
				if (value2 is MoltenCore)
				{
					RecycleWorkbench component = val.GetComponent<RecycleWorkbench>();
					component.IsPaused = true;
					if (needRefund)
					{
						component.InterruptProduce();
					}
				}
				else
				{
					Workbench component2 = val.GetComponent<Workbench>();
					component2.IsPaused = true;
					if (needRefund && component2.workerController.IsWorking)
					{
						component2.InterruptProduce();
					}
				}
			}
		}
	}

	public void OnDestroy()
	{
		Instance = this;
		SharedMessenger.RemoveListener<string, Dictionary<string, object>>("OPEN_FGUI", OpenFUI);
		SharedMessenger.RemoveListener<List<Announcement>>("ANNOUNCEMENT_RECEIVED", UpdateAnnouncement);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", CloseNewSoldierUIOnContract);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", UpdateWorkshopSlot);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", CheckIsClearUi);
		SharedMessenger.RemoveListener<string, int, int>("CHAT_MESSAGE_RECEIVED", UpdateMessage);
		SharedMessenger.RemoveListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", ReLoadBuildings);
		SharedMessenger.RemoveListener<int>("USER_LEVEL_UP", OnUserLevelUp);
		SharedMessenger.RemoveListener<List<string>, int, bool>("SHOW_TIPS", ShowTips);
		SharedMessenger.RemoveListener<List<string>, int, bool>("SHOW_INSTRUCTIONS", ShowInstructions);
		SharedMessenger.RemoveListener<string, int>("TECH_UPGRADED", OpenTechUi);
		SharedMessenger.RemoveListener<string, List<Bonus>, Dictionary<string, float>>("CHEST_CLAIMED", OpenTakeItems);
		SharedMessenger.RemoveListener<int, List<Bonus>>("TIME_MACHINE_LAUNCHED", OpenSandClock);
		SharedMessenger.RemoveListener<string, int>("BUILDING_UPGRADED", RecycleBuidler);
		SharedMessenger.RemoveListener<string, int>("BUILDING_UPGRADED", BuildingUpgradeBarFade);
		SharedMessenger.RemoveListener<string, int>("BUILDING_UPGRADED", MaincityUiRemoveBuildingIndicator);
		SharedMessenger.RemoveListener<string, int>("BUILDING_UPGRADED", UpdateBuildingsTitle);
		SharedMessenger.RemoveListener<string>("BUILDING_CONSTRUCTING_COMPLETE", BuildingUpgradeBarEndSet);
		SharedMessenger.RemoveListener<string>("BUILDING_CONSTRUCTING_COMPLETE", MaincityUiAddBuildingIndicator);
		SharedMessenger.RemoveListener<string, bool>("CHAPTER_COMPLETE", OnChapterComplete);
		SharedMessenger.RemoveListener<string, int>("ITEM_UPGRADE", OnItemUpgrade);
		SharedMessenger.RemoveListener<string, int, Dictionary<string, int>>("SOLDIER_SUMMONING", OnSoldierSummoning);
		SharedMessenger.RemoveListener<string, DateTimeOffset>("LEASEHOLD_REGISTERD", SetLeaseholdChanged);
		SharedMessenger.RemoveListener<List<ClientMail>>("MAILS_RECEIVED", UpdateMails);
		SharedMessenger.RemoveListener<int>("DUNGEON_LEVEL_UP", ShowDungeonLevelUpTip);
		SharedMessenger.RemoveListener<NewsTicker>("NEWS_TICKER_PULLED", UpdateTicker);
		SharedMessenger.RemoveListener<Cache_PrinceRedDot>(Cache_PrinceRedDot.ON_PAGE_REDDOT_CHANGE, OnPrinceRedDotChange);
		SharedMessenger.RemoveListener<string>("PLAY_REPLAY", onPlayReplay);
		SharedMessenger.RemoveListener<string>("STOP_REPLAY", onStopReplay);
	}

	private void OnDisable()
	{
	}

	public void ShowUnstableConnect()
	{
		SharedMessenger.Broadcast("NEED_RESTART", new NeedRestartResponse
		{
			IsEnforced = true,
			Tip = LanguagesManager.GetDesc("CsharpCodeZhTcText34") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText35") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText36")
		});
	}

	public void FGUI_OnApplicationFocus(bool isFocus)
	{
		long num = DateTimeHelper.Now.ToUnixTimeSeconds() - GameController.Instance.LocalUpdateTime;
		if (num > 600 && GameController.Contexts.gameState.isGameEntered)
		{
			ShowUnstableConnect();
			return;
		}
		SharedMessenger.Broadcast("APP_FOCUS", isFocus);
		if (isFocus && GameController.Contexts.gameState.isMainCityInitialized)
		{
			GameManagers.Instance.StockController.NeedGetAllProduceStatus = true;
			GameManagers.Instance.StockController.NeedSyncProduce = true;
			GameController.Instance.SyncTime();
		}
	}

	public void FGUI_OnApplicationPause(bool isPause)
	{
		SharedMessenger.Broadcast("APP_PAUSE", isPause);
		if (isPause)
		{
			return;
		}
		if (GameController.Contexts.gameState.isMainCityInitialized)
		{
			if (HotUpdateProcess.Instance.IsRegionOutCN && HotUpdateProcess.Instance.IsOffline)
			{
				return;
			}
			ILRequestHelper<EnterGameResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().EnterGame(), delegate(EnterGameResponse response)
			{
				GameManagers.Instance.UserArchiveManager.SetDailyLoginStats(response.DailyLoginStats);
				GameManagers.Instance.Messenger.Broadcast("ON_DAILY_LOGIN_STATS", response.DailyLoginStats);
				if (!response.Result || response.Bonuses == null || response.Bonuses.Count < 1)
				{
					GameManagers.Instance.Messenger.Broadcast<List<string>, bool>("BUILDING_NEED_RESUME_PRODUCE", null, arg2: false);
				}
				else
				{
					GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
					List<Bonus> list = new List<Bonus>();
					foreach (ModelsBonus bonuse in response.Bonuses)
					{
						list.Add(Bonus.Get(bonuse.ItemId, bonuse.Qty));
					}
					GameController.Contexts.gameState.ReplaceOfflineSeconds(response.OfflineSeconds);
					GameController.Contexts.gameState.ReplaceOfflineBonuses(list);
					Instance.GvGMode3OfflineBonusInfo = new GvGMode3OfflineBonusModel
					{
						GvGFetchGapTime = response.GvGFetchGapTime,
						FullItemId = response.FullItemId
					};
					GameManagers.Instance.Messenger.Broadcast<List<string>, bool>("BUILDING_NEED_RESUME_PRODUCE", null, arg2: false);
				}
			}, 1f);
		}
		if (GameController.WillRestart)
		{
			OpenUiAndSceneAdaptationsOnChangeScreenSizeIEnumerator();
		}
	}

	public void FGUI_OnApplicationQuit()
	{
		SharedMessenger.Broadcast("APP_QUIT");
	}

	public void OpenFUI(string uiName, Dictionary<string, object> uiParams)
	{
		if (uiName == UI_Guide.Name)
		{
			((Component)this).gameObject.AddComponent<FindAim>();
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(uiName, uiParams);
	}

	private void OnUserLevelUp(int level)
	{
		if (!GameManagers.Instance.UserArchiveManager.IsNewGuideMode() || level != 1)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UserLevelUpPopup.Name, null);
		}
		UpdateBuildingsTitleOnUserLevelUp();
		CacheManager.Instance.Get<Cache_StoreContentConfigData>().UpdateBlackMarketStoreItemsOnUserLevelUp();
	}

	private void Close_UI_Btn_BattleSkip()
	{
		if (_UI_Btn_BattleSkip != null)
		{
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)_UI_Btn_BattleSkip, true);
			((GObject)_UI_Btn_BattleSkip).Dispose();
			_UI_Btn_BattleSkip = null;
		}
	}

	private void onStopReplay(string battleId)
	{
		if (battleId == "5be0b7bd-9eb6-4da8-9c63-e5552527e890")
		{
			Close_UI_Btn_BattleSkip();
		}
	}

	private void onPlayReplay(string battleId)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		if (!(battleId == "5be0b7bd-9eb6-4da8-9c63-e5552527e890"))
		{
			return;
		}
		object obj = _003C_003Ec._003C_003E9__93_0;
		if (obj == null)
		{
			GComponentCreator val = () => HotFixManager.Instance.appdomain.Instantiate<GComponent>(typeof(UI_Btn_BattleSkip).FullName, (object[])null);
			_003C_003Ec._003C_003E9__93_0 = val;
			obj = (object)val;
		}
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oygntv4vg", (GComponentCreator)obj);
		_UI_Btn_BattleSkip = UI_Btn_BattleSkip.CreateInstance_ILRuntime();
		((GObject)_UI_Btn_BattleSkip).onClick.Add((EventCallback0)delegate
		{
			GameController.Contexts.Service<ReplayPlayerService>().Skip();
			Close_UI_Btn_BattleSkip();
		});
		((GComponent)GRoot.inst).AddChild((GObject)(object)_UI_Btn_BattleSkip);
		((GObject)_UI_Btn_BattleSkip).SetXY(((GObject)GRoot.inst).width * 0.9f - ((GObject)_UI_Btn_BattleSkip).width / 2f, ScreenAmendY());
	}

	private void UpdateTicker(NewsTicker ticker)
	{
		if (MyTicker != null)
		{
			if (ticker.Id != MyTicker.Id)
			{
				MyTicker = ticker;
			}
		}
		else
		{
			MyTicker = ticker;
		}
	}

	public void OpenForumUserProfilePage(int targetUserId)
	{
		if (UiHelper.LoginTypeStr == UserLoginCredentialsType.Guest.ToString())
		{
			UiHelper.GuestsAccessRestrictTip();
		}
		else
		{
			if (targetUserId == 0)
			{
				return;
			}
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					"            " + LanguagesManager.GetDesc("CsharpCodeZhTcText37") + "\n                  " + LanguagesManager.GetDesc("CsharpCodeZhTcText38")
				},
				{
					"Buttons",
					new Dictionary<string, Action>
					{
						{
							"Confirm",
							delegate
							{
								ILRequestHelper<GetBBSKeyResponse>.Request((EventContext)null, (Func<Task<GetBBSKeyResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetBBSKey()), (Action<GetBBSKeyResponse>)delegate(GetBBSKeyResponse response)
								{
									if (response != null)
									{
										if (!response.Result)
										{
											ILRequestHelper.ShowErrorCode(response.ErrorCode);
										}
										else
										{
											string text = $"others-profile/{targetUserId}";
											if (targetUserId == response.UserId)
											{
												text = "user/profile";
											}
											string text2 = $"UserId={response.UserId}&Timestamp={response.Timestamp}&Key={UiHelper.UrlEncode(response.BBSKey)}&Language={HotUpdateProcess.LanguageKey}";
											string url = response.BBSURL + "/?" + text2 + "#/" + text;
											UiHelper.UniWebViewOpenUrl(url, LanguagesManager.GetDesc("CsharpCodeZhTcText15"));
										}
									}
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
	}

	public bool TechIdisNotMainKey(string id)
	{
		return id != TechnologyManager.DominionArtifactKey && id != TechnologyManager.DoomArtifactKey && id != TechnologyManager.SlaveryArtifactKey;
	}

	private void OnChapterComplete(string lastChapterId, bool newCompleteFlag)
	{
	}

	private void ShowTips(List<string> content, int order, bool showMask)
	{
		Dictionary<string, object> item = new Dictionary<string, object>
		{
			{ "TipText", content },
			{ "Order", order },
			{ "ShowMask", showMask }
		};
		tipsPlaylist.Add(item);
		if (!isPlayingTips)
		{
			isPlayingTips = true;
			PlayTips();
		}
	}

	private void ShowTipsLeft(List<string> content, int order, bool showMask, bool alginLeft = false)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>
		{
			{ "TipText", content },
			{ "Order", order },
			{ "ShowMask", showMask }
		};
		if (alginLeft)
		{
			dictionary.Add("Left", "");
		}
		tipsPlaylist.Add(dictionary);
		if (!isPlayingTips)
		{
			isPlayingTips = true;
			PlayTips();
		}
	}

	private void PlayTips()
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		if (tipsPlaylist.Count > 0)
		{
			Dictionary<string, object> parameters = tipsPlaylist.First();
			tipsPlaylist.RemoveAt(0);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_SomeTipPanel.Name, parameters, multiMode: true);
			Timers.inst.Add(0.3f, 1, (TimerCallback)delegate
			{
				PlayTips();
			});
		}
		else
		{
			isPlayingTips = false;
		}
	}

	private void ShowInstructions(List<string> content, int order, bool showMask)
	{
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "TipText", content },
			{ "Order", order },
			{ "ShowMask", showMask }
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_InstructionsWindow.Name, parameters);
	}

	public void OnSoldierChanged(FakeSoldier curSoldier, FakeSoldier fakeSoldier)
	{
		List<string> content = new List<string>
		{
			string.Format("{0} +{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText39"), Convert.ToInt32(curSoldier.Attack - fakeSoldier.Attack)),
			string.Format("{0} +{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText40"), Convert.ToInt32(curSoldier.Defense - fakeSoldier.Defense)),
			string.Format("{0} +{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText41"), Convert.ToInt32(curSoldier.Health - fakeSoldier.Health))
		};
		ShowTipsLeft(content, 107, showMask: false, alginLeft: true);
	}

	public void OnSoldierChanged(string soldierId, int beforeLevel, int afterLevel)
	{
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
		FakeSoldier fakeSoldier = new FakeSoldier(soldierId, soldier.Level, soldier.EvoLevel, afterLevel);
		FakeSoldier fakeSoldier2 = new FakeSoldier(soldierId, soldier.Level, soldier.EvoLevel, beforeLevel);
		List<string> content = new List<string>
		{
			string.Format("{0} +{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText39"), Convert.ToInt32(fakeSoldier.Attack - fakeSoldier2.Attack)),
			string.Format("{0} +{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText40"), Convert.ToInt32(fakeSoldier.Defense - fakeSoldier2.Defense)),
			string.Format("{0} +{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText41"), Convert.ToInt32(fakeSoldier.Health - fakeSoldier2.Health))
		};
		ShowTipsLeft(content, 107, showMask: false, alginLeft: true);
	}

	public GameObject AddTextSpecialEffects(GGraph spine, string SFXName, Vector3 size, string SortingLayerName = "Default", float x = 0.5f, Action<GameObject> onLoaded = null)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		if (spine == null || ((GObject)spine).isDisposed)
		{
			return null;
		}
		GameObject val = SpawnManager.Instance.InstantiatePool(SFXName, Vector3.zero, 2);
		if ((Object)(object)val != (Object)null)
		{
			Renderer component = val.GetComponent<Renderer>();
			if ((Object)(object)component != (Object)null)
			{
				component.sortingLayerName = SortingLayerName;
			}
			for (int i = 0; i < ((Component)val.transform).GetComponentsInChildren<Renderer>().Length; i++)
			{
				((Component)val.transform).GetComponentsInChildren<Renderer>()[i].sortingLayerName = SortingLayerName;
			}
			if (size == Vector3.zero)
			{
				val.transform.localScale = new Vector3(75f, 75f, 75f);
			}
			else
			{
				val.transform.localScale = size;
			}
			if ((Object)(object)val != (Object)null)
			{
				DisplayObject displayObject = ((GObject)spine).displayObject;
				GoWrapper val2 = new GoWrapper(val);
				((DisplayObject)val2).SetXY(0f, 0f);
				((DisplayObject)val2).pivot = new Vector2(x, 0.5f);
				spine.SetNativeObject((DisplayObject)(object)val2);
				displayObject.Dispose();
			}
		}
		onLoaded?.Invoke(val);
		return val;
	}

	public void RecycleBuidler(string buildingType, int level)
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_042f: Unknown result type (might be due to invalid IL or missing references)
		Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType(buildingType);
		HitArea component = buildingByType.GameObject.GetComponent<HitArea>();
		if (level == 1)
		{
			((Component)component.hitData.builders.transform.GetChild(6)).gameObject.SetActive(false);
			component.hitData.builders.transform.GetChild(6).localScale = new Vector3(0f, 0.5f, 0.5f);
			((Component)((Component)component.hitData.builders.transform.GetChild(6)).transform.GetChild(0)).gameObject.SetActive(false);
			component.hitData.builders.SetActive(false);
			if (buildingFlowLight.ContainsKey(buildingType))
			{
				((MonoBehaviour)this).StopCoroutine(buildingFlowLight[buildingType]);
				buildingFlowLight.Remove(buildingType);
			}
			if (slotFlowLight.ContainsKey(buildingType))
			{
				((MonoBehaviour)this).StopCoroutine(slotFlowLight[buildingType]);
				slotFlowLight.Remove(buildingType);
			}
			if (buildingByType.Feature == "WorkShop")
			{
				((Renderer)component.hitData.decoration.GetComponent<SpriteRenderer>()).material.shader = Shader.Find("Sprites/Default");
			}
			return;
		}
		if (buildingByType.Feature == "Storehouse" || buildingByType.Feature == "MoltenCore")
		{
			((Component)component.hitData.builders.transform.GetChild(6)).gameObject.SetActive(false);
			component.hitData.builders.transform.GetChild(6).localScale = new Vector3(0f, 0.5f, 0.5f);
			((Component)((Component)component.hitData.builders.transform.GetChild(6)).transform.GetChild(0)).gameObject.SetActive(false);
			component.hitData.builders.SetActive(false);
		}
		else
		{
			component.hitData.builders.SetActive(false);
			if (buildingByType.Feature == "WorkShop")
			{
				for (int i = ((WorkShop)buildingByType).SomeLevelSlot(level - 1); i < ((WorkShop)buildingByType).Slot; i++)
				{
					((Component)((Component)component).gameObject.GetComponent<WorkshopController>().WorkbenchNominal[i].transform.Find("Progress")).gameObject.SetActive(false);
				}
				((Renderer)((Component)component.hitData.builders.transform.GetChild(6)).gameObject.GetComponent<SpriteRenderer>()).enabled = true;
			}
			else if (buildingByType.Feature == "Camp")
			{
				for (int j = ((Camp)buildingByType).SomeLevelSlot(level - 1); j < ((Camp)buildingByType).Slot; j++)
				{
					if (j >= 5)
					{
						((Component)((Component)((Component)component).gameObject.GetComponent<CampController>().SlotControllers[j % 5]).transform.Find("Progress")).gameObject.SetActive(false);
					}
					else
					{
						((Component)((Component)component).gameObject.GetComponent<CampController>().GetSlotGameObject(j).transform.Find("Progress")).gameObject.SetActive(false);
					}
				}
				((Renderer)((Component)component.hitData.builders.transform.GetChild(6)).gameObject.GetComponent<SpriteRenderer>()).enabled = true;
			}
			else if (buildingByType.Feature == "Mine")
			{
				((Component)component.hitData.builders.transform.GetChild(6)).gameObject.SetActive(false);
				component.hitData.builders.transform.GetChild(6).localScale = new Vector3(0f, 0.5f, 0.5f);
				((Component)((Component)component.hitData.builders.transform.GetChild(6)).transform.GetChild(0)).gameObject.SetActive(false);
			}
		}
		if (slotFlowLight.ContainsKey(buildingType))
		{
			((MonoBehaviour)this).StopCoroutine(slotFlowLight[buildingType]);
			slotFlowLight.Remove(buildingType);
		}
	}

	public void SetBuilderIdleStates(Building building, int num)
	{
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		if (building.Level != 0 && !(building.Feature == "Storehouse") && !(building.Feature == "MoltenCore"))
		{
			return;
		}
		HitArea component = building.GameObject.GetComponent<HitArea>();
		component.hitData.builders.SetActive(true);
		for (int i = 0; i < 5; i++)
		{
			if (i < num)
			{
				((Component)component.hitData.builders.transform.GetChild(i)).gameObject.SetActive(true);
				((Component)component.hitData.builders.transform.GetChild(i)).GetComponent<SkeletonAnimation>().AnimationName = "idle";
			}
			else
			{
				((Component)component.hitData.builders.transform.GetChild(i)).gameObject.SetActive(false);
			}
			if (building.Feature == "Mine")
			{
				float orientation = 0f;
				component.hitData.builders.transform.GetChild(i).position = component.SetCollectionBuilderPos(num, i, component.hitData.points[0].position, 1f, out orientation);
				component.hitData.builders.transform.GetChild(i).localEulerAngles = new Vector3(component.hitData.builders.transform.GetChild(i).localEulerAngles.x, 0f, component.hitData.builders.transform.GetChild(i).localEulerAngles.z);
				if (orientation > 0f)
				{
					((SkeletonRenderer)((Component)component.hitData.builders.transform.GetChild(i)).GetComponent<SkeletonAnimation>()).skeleton.FlipX = true;
				}
			}
			else if ((i + 1) % 2 != 0)
			{
				component.hitData.builders.transform.GetChild(i).localEulerAngles = new Vector3(component.hitData.builders.transform.GetChild(i).localEulerAngles.x, 180f, component.hitData.builders.transform.GetChild(i).localEulerAngles.z);
			}
			else
			{
				component.hitData.builders.transform.GetChild(i).localEulerAngles = new Vector3(component.hitData.builders.transform.GetChild(i).localEulerAngles.x, 0f, component.hitData.builders.transform.GetChild(i).localEulerAngles.z);
			}
		}
	}

	public void SetBuilderIdleUpgradeComplete(Building building, int num)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		if (building.Level < 1)
		{
			return;
		}
		Vector3 aimPos = Vector3.zero;
		float spacingY = 1f;
		HitArea component = building.GameObject.GetComponent<HitArea>();
		component.hitData.builders.SetActive(true);
		if (building.Feature == "WorkShop")
		{
			if (building.SomeLevelSlot(building.NextLevel) > 8)
			{
				Vector3 position = building.GameObject.GetComponent<WorkshopController>().WorkbenchNominal[7].transform.position;
				Vector3 position2 = building.GameObject.GetComponent<WorkshopController>().WorkbenchNominal[11].transform.position;
				aimPos = position - (position - position2) / 2f + new Vector3(0f, -0.5f, 0f);
				spacingY = 2f;
			}
			else
			{
				Vector3 position3 = building.GameObject.GetComponent<WorkshopController>().WorkbenchNominal[building.SomeLevelSlot(building.NextLevel) - 1].transform.position;
				Vector3 position4 = building.GameObject.GetComponent<WorkshopController>().WorkbenchNominal[building.SomeLevelSlot(building.NextLevel) - 2].transform.position;
				aimPos = position3 - (position3 - position4) / 2f;
				spacingY = 1f;
			}
		}
		else if (building.Feature == "Mine")
		{
			aimPos = component.hitData.points[0].position;
			spacingY = 1f;
		}
		else if (building.Feature == "Camp")
		{
			int slotIndex = building.SomeLevelSlot(building.NextLevel) - 1;
			aimPos = building.GameObject.GetComponent<CampController>().GetSlotPosForLevelUp(slotIndex) + new Vector3(0f, -0.2f, 0f);
			spacingY = 1f;
		}
		for (int i = 0; i < 5; i++)
		{
			GameObject gameObject = ((Component)component.hitData.builders.transform.GetChild(i)).gameObject;
			if (i < num)
			{
				gameObject.transform.position = component.SetCollectionBuilderPos(num, i, aimPos, spacingY, out var orientation);
				gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, 0f, gameObject.transform.eulerAngles.z);
				if (orientation > 0f)
				{
					((SkeletonRenderer)gameObject.GetComponent<SkeletonAnimation>()).skeleton.FlipX = true;
				}
				gameObject.GetComponent<SkeletonAnimation>().AnimationName = "idle";
				gameObject.SetActive(true);
			}
			else
			{
				gameObject.SetActive(false);
			}
		}
	}

	private void FeaMineTest()
	{
		Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType("1");
	}

	private void ReLoadBuildings(string buildingType, BuildingConstructingConfig info)
	{
		Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType(buildingType);
		if (buildingByType.NextLevel == 1 && buildingType != "11")
		{
			HitArea component = buildingByType.GameObject.GetComponent<HitArea>();
			if (buildingByType.Feature == "WorkShop")
			{
				((MonoBehaviour)this).StartCoroutine(RepairTiming(info.UpgradeRemainingTime, buildingByType));
			}
			else if (buildingByType.Feature == "Mine")
			{
				((MonoBehaviour)this).StartCoroutine(RepairTiming(info.UpgradeRemainingTime, buildingByType));
			}
			else if (buildingByType.Feature == "Camp")
			{
				((MonoBehaviour)this).StartCoroutine(RepairTiming(info.UpgradeRemainingTime, buildingByType));
			}
			else if (buildingByType.Feature == "MoltenCore")
			{
				((MonoBehaviour)this).StartCoroutine(RepairTiming(info.UpgradeRemainingTime, buildingByType));
			}
		}
	}

	public void ContinueRepairBuildings(BuildingConstructingConfig info, Building building)
	{
		if (building.Status == BuildingStatus.Constructing && info.UpgradeRemainingTime > 3)
		{
			ReLoadBuildings(building.BuildingType, info);
		}
		else if (building.Status == BuildingStatus.Constructing && info.UpgradeRemainingTime <= 3)
		{
			ScriptApi.CreateTimer(2f, delegate
			{
				LoadBuildings(building, isInit: true, 1);
				ReSetSlot(building);
				RefreshConveyorByEvents(building.BuildingType, building.NextLevel);
				SetBuilderIdleStates(building, info.Workers);
				OpenFlowIEnumerator(building);
				Instance.SetReadyBuildingUpgradeBar(building);
			});
		}
		else if (building.Status == BuildingStatus.Ready)
		{
			ScriptApi.CreateTimer(2f, delegate
			{
				LoadBuildings(building, isInit: true, 1);
				ReSetSlot(building);
				RefreshConveyorByEvents(building.BuildingType, building.NextLevel);
				SetBuilderIdleStates(building, info.Workers);
				OpenFlowIEnumerator(building);
				Instance.SetReadyBuildingUpgradeBar(building);
			});
		}
	}

	private IEnumerator UnLoadBuildingsSprites(string buildingType, string buildingFeature, HitArea hitArea, bool isInit)
	{
		if (isInit)
		{
			yield break;
		}
		int num;
		switch (buildingFeature)
		{
		default:
			num = ((buildingFeature == "Camp") ? 1 : 0);
			break;
		case "WorkShop":
		case "MilitaryIntelligence7":
		case "BlackMarketer":
		case "Mine":
			num = 1;
			break;
		}
		if (num != 0)
		{
			hitArea.hitData.background.GetComponent<SpriteRenderer>().sprite = null;
		}
		yield return (object)new WaitForSeconds(3f);
		int num2;
		switch (buildingFeature)
		{
		default:
			num2 = ((buildingFeature == "Camp") ? 1 : 0);
			break;
		case "WorkShop":
		case "MilitaryIntelligence7":
		case "BlackMarketer":
			num2 = 1;
			break;
		}
		if (num2 != 0)
		{
			hitArea.hitData.mask.GetComponent<SpriteRenderer>().sprite = null;
		}
		if (BuildingSpriteDic.ContainsKey(buildingType))
		{
			List<string> buildingSprites = (List<string>)BuildingSpriteDic[buildingType];
			for (int i = 0; i < buildingSprites.Count; i++)
			{
				AssetsManager.Instance.UnloadAsset<Sprite>(buildingSprites[i]);
			}
		}
	}

	private void BuildingSpritesDicAdd(string buildingType, string spriteName)
	{
		if (BuildingSpriteDic.ContainsKey(buildingType))
		{
			List<string> list = (List<string>)BuildingSpriteDic[buildingType];
			if (!list.Contains(spriteName))
			{
				list.Add(spriteName);
			}
		}
		else
		{
			BuildingSpriteDic.Add(buildingType, new List<string> { spriteName });
		}
	}

	public void LoadBuildings(Building building, bool isInit, int levelIncrease = 0)
	{
		//IL_08d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0920: Unknown result type (might be due to invalid IL or missing references)
		//IL_0941: Unknown result type (might be due to invalid IL or missing references)
		GameObject gameObject = building.GameObject;
		HitArea hitArea = gameObject.GetComponent<HitArea>();
		SpriteRenderer component = gameObject.GetComponent<SpriteRenderer>();
		int _level = building.Level + levelIncrease;
		if (_level == 0)
		{
			if (building.Feature == "Mine")
			{
				AssetsManager.Instance.LoadAsset<Sprite>("broken").Then((Action<Sprite>)delegate(Sprite asset)
				{
					hitArea.hitData.background.GetComponent<SpriteRenderer>().sprite = asset;
					spriteList.Add("broken");
					BuildingSpritesDicAdd(building.BuildingType, "broken");
				});
				hitArea.hitData.mask.SetActive(false);
				component.sprite = null;
				hitArea.hitData.builders.SetActive(false);
				GameObject[] workbenchNominal = ((WorkshopController)((WorkShop)building).Controller).WorkbenchNominal;
				for (int num = 0; num < workbenchNominal.Length; num++)
				{
					workbenchNominal[num].SetActive(false);
				}
			}
			else if (building.Feature == "WorkShop")
			{
				AssetsManager.Instance.LoadAsset<Sprite>("room_locked_" + building.BuildingType).Then((Action<Sprite>)delegate(Sprite asset)
				{
					hitArea.hitData.background.GetComponent<SpriteRenderer>().sprite = asset;
					spriteList.Add("room_locked_" + building.BuildingType);
					BuildingSpritesDicAdd(building.BuildingType, "room_locked_" + building.BuildingType);
				});
				hitArea.hitData.mask.SetActive(true);
				AssetsManager.Instance.LoadAsset<Sprite>("room_locked_mask_" + building.BuildingType).Then((Action<Sprite>)delegate(Sprite asset)
				{
					hitArea.hitData.mask.GetComponent<SpriteRenderer>().sprite = asset;
					spriteList.Add("room_locked_mask_" + building.BuildingType);
					BuildingSpritesDicAdd(building.BuildingType, "room_locked_mask_" + building.BuildingType);
				});
				GameObject[] workbenchNominal2 = ((WorkshopController)((WorkShop)building).Controller).WorkbenchNominal;
				for (int num2 = 0; num2 < workbenchNominal2.Length; num2++)
				{
					workbenchNominal2[num2].SetActive(false);
				}
				hitArea.hitData.builders.SetActive(false);
				if ((Object)(object)hitArea.hitData.decoration != (Object)null)
				{
					hitArea.hitData.decoration.SetActive(false);
				}
				if (building.BuildingType == "4" || building.BuildingType == "5" || building.BuildingType == "6")
				{
					if (GameManagers.Instance.BuildingManager.GetBuildingByType("1").Level > 0 || GameManagers.Instance.BuildingManager.GetBuildingByType("2").Level > 0 || GameManagers.Instance.BuildingManager.GetBuildingByType("4").Level > 0 || GameManagers.Instance.BuildingManager.GetBuildingByType("5").Level > 0 || GameManagers.Instance.BuildingManager.GetBuildingByType("6").Level > 0)
					{
						hitArea.hitData.conveyor.SetActive(true);
					}
					else
					{
						hitArea.hitData.conveyor.SetActive(false);
					}
				}
				else if (building.BuildingType == "13" || building.BuildingType == "8" || building.BuildingType == "9")
				{
					if (GameManagers.Instance.BuildingManager.GetBuildingByType("13").Level > 0 || GameManagers.Instance.BuildingManager.GetBuildingByType("8").Level > 0 || GameManagers.Instance.BuildingManager.GetBuildingByType("9").Level > 0)
					{
						hitArea.hitData.conveyor.SetActive(true);
					}
					else
					{
						hitArea.hitData.conveyor.SetActive(false);
					}
				}
			}
			else if (building.Feature == "Camp")
			{
				AssetsManager.Instance.LoadAsset<Sprite>("room_locked_barracks").Then((Action<Sprite>)delegate(Sprite asset)
				{
					hitArea.hitData.background.GetComponent<SpriteRenderer>().sprite = asset;
					spriteList.Add("room_locked_barracks");
					BuildingSpritesDicAdd(building.BuildingType, "room_locked_barracks");
				});
				AssetsManager.Instance.LoadAsset<Sprite>("room_locked_barracks_mask").Then((Action<Sprite>)delegate(Sprite asset)
				{
					hitArea.hitData.mask.GetComponent<SpriteRenderer>().sprite = asset;
					spriteList.Add("room_locked_barracks_mask");
					BuildingSpritesDicAdd(building.BuildingType, "room_locked_barracks_mask");
				});
				hitArea.hitData.mask.SetActive(true);
				hitArea.hitData.decoration.SetActive(false);
				hitArea.hitData.conveyor.SetActive(false);
				if (building.Slot <= 5)
				{
					CampController campController = (CampController)((Camp)building).Controller;
					for (int num3 = 0; num3 < building.Slot; num3++)
					{
						GameObject slotGameObject = campController.GetSlotGameObject(num3);
						if (slotGameObject != null)
						{
							slotGameObject.SetActive(false);
						}
					}
				}
				hitArea.hitData.builders.SetActive(false);
			}
			else if (building.Feature == "Storehouse")
			{
				hitArea.hitData.builders.SetActive(false);
			}
			else if (building.Feature == "MoltenCore")
			{
				hitArea.hitData.builders.SetActive(false);
			}
			else if (building.Feature == "MilitaryIntelligence7")
			{
				hitArea.hitData.builders.SetActive(false);
				AssetsManager.Instance.LoadAsset<Sprite>("room_locked_" + building.BuildingType).Then((Action<Sprite>)delegate(Sprite asset)
				{
					hitArea.hitData.background.GetComponent<SpriteRenderer>().sprite = asset;
					spriteList.Add("room_locked_" + building.BuildingType);
					BuildingSpritesDicAdd(building.BuildingType, "room_locked_" + building.BuildingType);
				});
				hitArea.hitData.mask.SetActive(true);
				AssetsManager.Instance.LoadAsset<Sprite>("room_locked_mask_" + building.BuildingType).Then((Action<Sprite>)delegate(Sprite asset)
				{
					hitArea.hitData.mask.GetComponent<SpriteRenderer>().sprite = asset;
					spriteList.Add("room_locked_mask_" + building.BuildingType);
					BuildingSpritesDicAdd(building.BuildingType, "room_locked_mask_" + building.BuildingType);
				});
				hitArea.hitData.decoration.SetActive(false);
			}
			else if (building.Feature == "BlackMarketer")
			{
				hitArea.hitData.builders.SetActive(false);
				if (building.BuildingType == "16")
				{
					AssetsManager.Instance.LoadAsset<Sprite>("room_locked_" + building.BuildingType).Then((Action<Sprite>)delegate(Sprite asset)
					{
						hitArea.hitData.background.GetComponent<SpriteRenderer>().sprite = asset;
						spriteList.Add("room_locked_" + building.BuildingType);
						BuildingSpritesDicAdd(building.BuildingType, "room_locked_" + building.BuildingType);
					});
					hitArea.hitData.mask.SetActive(true);
					AssetsManager.Instance.LoadAsset<Sprite>("room_locked_mask_" + building.BuildingType).Then((Action<Sprite>)delegate(Sprite asset)
					{
						hitArea.hitData.mask.GetComponent<SpriteRenderer>().sprite = asset;
						spriteList.Add("room_locked_mask_" + building.BuildingType);
						BuildingSpritesDicAdd(building.BuildingType, "room_locked_mask_" + building.BuildingType);
					});
					hitArea.hitData.decoration.SetActive(false);
				}
			}
			else if (!(building.Feature == "MoltenCore"))
			{
			}
		}
		else if (building.Feature == "Mine")
		{
			AssetsManager.Instance.LoadAsset<Sprite>($"portal_{building.BuildingType}_{_level}").Then((Action<Sprite>)delegate(Sprite asset)
			{
				OpenIEnumerator(UnLoadBuildingsSprites(building.BuildingType, building.Feature, hitArea, isInit));
				hitArea.hitData.background.GetComponent<SpriteRenderer>().sprite = asset;
				spriteList.Add($"portal_{building.BuildingType}_{_level}");
			});
			hitArea.hitData.mask.SetActive(true);
			if (hitArea.hitData.mask.GetComponentsInChildren<Transform>().Length > 1)
			{
				for (int num4 = hitArea.hitData.mask.transform.childCount - 1; num4 >= 0; num4--)
				{
					Object.DestroyImmediate((Object)(object)((Component)hitArea.hitData.mask.transform.GetChild(num4)).gameObject);
				}
			}
			GameObject val = SpawnManager.Instance.InstantiatePool($"Teleport_13.{building.BuildingType}_{_level}", Vector3.zero, 1);
			if ((Object)(object)val != (Object)null)
			{
				val.transform.parent = hitArea.hitData.mask.transform;
				val.transform.localPosition = Vector3.zero;
				val.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				val.GetComponent<Renderer>().sortingLayerName = "Default";
				for (int num5 = 0; num5 < ((Component)val.transform).GetComponentsInChildren<Renderer>().Length; num5++)
				{
					((Component)val.transform).GetComponentsInChildren<Renderer>()[num5].sortingLayerName = "Default";
				}
			}
			component.sprite = null;
			hitArea.hitData.builders.SetActive(false);
			GameObject[] workbenchNominal3 = ((WorkshopController)((WorkShop)building).Controller).WorkbenchNominal;
			for (int num6 = 0; num6 < workbenchNominal3.Length; num6++)
			{
				workbenchNominal3[num6].SetActive(true);
			}
			if (!isInit && (building.BuildingType == "1" || building.BuildingType == "2"))
			{
				GameManagers.Instance.BuildingManager.Buildings["4"].GameObject.GetComponent<HitArea>().hitData.conveyor.SetActive(true);
				GameManagers.Instance.BuildingManager.Buildings["5"].GameObject.GetComponent<HitArea>().hitData.conveyor.SetActive(true);
				GameManagers.Instance.BuildingManager.Buildings["6"].GameObject.GetComponent<HitArea>().hitData.conveyor.SetActive(true);
			}
		}
		else if (building.Feature == "WorkShop")
		{
			AssetsManager.Instance.LoadAsset<Sprite>("room_unlocked_" + building.BuildingType).Then((Action<Sprite>)delegate(Sprite asset)
			{
				OpenIEnumerator(UnLoadBuildingsSprites(building.BuildingType, building.Feature, hitArea, isInit));
				hitArea.hitData.background.GetComponent<SpriteRenderer>().sprite = asset;
				spriteList.Add("room_unlocked_" + building.BuildingType);
			});
			hitArea.hitData.mask.SetActive(false);
			GameObject[] workbenchNominal4 = ((WorkshopController)((WorkShop)building).Controller).WorkbenchNominal;
			for (int num7 = 0; num7 < workbenchNominal4.Length; num7++)
			{
				workbenchNominal4[num7].SetActive(true);
			}
			hitArea.hitData.builders.SetActive(false);
			if ((Object)(object)hitArea.hitData.decoration != (Object)null)
			{
				hitArea.hitData.decoration.SetActive(true);
				AssetsManager.Instance.LoadAsset<Shader>("MoveLightImage").Then((Action<Shader>)delegate(Shader shader)
				{
					//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
					//IL_040c: Unknown result type (might be due to invalid IL or missing references)
					//IL_042c: Unknown result type (might be due to invalid IL or missing references)
					//IL_044c: Unknown result type (might be due to invalid IL or missing references)
					((Renderer)hitArea.hitData.decoration.GetComponent<SpriteRenderer>()).material.shader = shader;
					string decoName = "workshop_" + building.BuildingType + "_deco_1";
					string text = "workshop_" + building.BuildingType + "_deco_1_flowBack";
					if (building.BuildingType == "13")
					{
						if (_level <= 3)
						{
							decoName = "workshop_" + building.BuildingType + "_deco_1_lv1-3";
							text = "workshop_" + building.BuildingType + "_deco_1__lv1-3_flowBack";
						}
						else
						{
							decoName = "workshop_" + building.BuildingType + "_deco_1_lv4-5";
							text = "workshop_" + building.BuildingType + "_deco_1__lv4-5_flowBack";
						}
					}
					else if (building.BuildingType == "8" || building.BuildingType == "9")
					{
						if (_level <= 2)
						{
							decoName = "workshop_" + building.BuildingType + "_deco_1_lv1-2";
							text = "workshop_" + building.BuildingType + "_deco_1__lv1-2_flowBack";
						}
						else
						{
							decoName = "workshop_" + building.BuildingType + "_deco_1_lv3-5";
							text = "workshop_" + building.BuildingType + "_deco_1__lv3-5_flowBack";
						}
					}
					AssetsManager.Instance.LoadAsset<Sprite>(decoName).Then((Action<Sprite>)delegate(Sprite asset)
					{
						hitArea.hitData.decoration.GetComponent<SpriteRenderer>().sprite = asset;
						spriteList.Add(decoName);
					});
					AssetsManager.Instance.LoadAsset<Texture2D>(text).Then((Action<Texture2D>)delegate(Texture2D asset)
					{
						((Renderer)hitArea.hitData.decoration.GetComponent<SpriteRenderer>()).material.SetTexture("_MaskTex", (Texture)(object)asset);
					});
					AssetsManager.Instance.LoadAsset<Texture2D>("flow").Then((Action<Texture2D>)delegate(Texture2D asset)
					{
						((Renderer)hitArea.hitData.decoration.GetComponent<SpriteRenderer>()).material.SetTexture("_LightTex", (Texture)(object)asset);
					});
					((Renderer)hitArea.hitData.decoration.GetComponent<SpriteRenderer>()).material.SetFloat("_uvaddspeed", 0.7f);
					AssetsManager.Instance.LoadAsset<Sprite>($"workshop_{building.BuildingType}_lv{_level}").Then((Action<Sprite>)delegate(Sprite asset)
					{
						((Component)hitArea.hitData.decoration.transform.Find("Deco")).GetComponent<SpriteRenderer>().sprite = asset;
						spriteList.Add($"workshop_{building.BuildingType}_lv{_level}");
					});
					if (((Component)hitArea.hitData.decoration.transform.Find("SfxBack")).GetComponentsInChildren<Transform>().Length > 1)
					{
						for (int num9 = ((Component)hitArea.hitData.decoration.transform.Find("SfxBack")).transform.childCount - 1; num9 >= 0; num9--)
						{
							Object.DestroyImmediate((Object)(object)((Component)((Component)hitArea.hitData.decoration.transform.Find("SfxBack")).transform.GetChild(num9)).gameObject);
						}
					}
					GameObject val2 = SpawnManager.Instance.InstantiatePool($"Workshop_{building.BuildingType}_{_level}", Vector3.zero, 1);
					if ((Object)(object)val2 != (Object)null)
					{
						val2.transform.parent = ((Component)hitArea.hitData.decoration.transform.Find("SfxBack")).transform;
						val2.transform.localPosition = Vector3.zero;
						val2.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
						val2.transform.localScale = new Vector3(1f, 1f, 1f);
						val2.GetComponent<Renderer>().sortingLayerName = "Default";
						for (int num10 = 0; num10 < ((Component)val2.transform).GetComponentsInChildren<Renderer>().Length; num10++)
						{
							((Component)val2.transform).GetComponentsInChildren<Renderer>()[num10].sortingLayerName = "Default";
						}
					}
				});
			}
			if (!isInit)
			{
				if (building.BuildingType == "4" || building.BuildingType == "5" || building.BuildingType == "6")
				{
					GameManagers.Instance.BuildingManager.Buildings["4"].GameObject.GetComponent<HitArea>().hitData.conveyor.SetActive(true);
					GameManagers.Instance.BuildingManager.Buildings["5"].GameObject.GetComponent<HitArea>().hitData.conveyor.SetActive(true);
					GameManagers.Instance.BuildingManager.Buildings["6"].GameObject.GetComponent<HitArea>().hitData.conveyor.SetActive(true);
				}
				else if (building.BuildingType == "13" || building.BuildingType == "8" || building.BuildingType == "9")
				{
					GameManagers.Instance.BuildingManager.Buildings["13"].GameObject.GetComponent<HitArea>().hitData.conveyor.SetActive(true);
					GameManagers.Instance.BuildingManager.Buildings["8"].GameObject.GetComponent<HitArea>().hitData.conveyor.SetActive(true);
					GameManagers.Instance.BuildingManager.Buildings["9"].GameObject.GetComponent<HitArea>().hitData.conveyor.SetActive(true);
				}
			}
			else
			{
				hitArea.hitData.conveyor.SetActive(true);
			}
		}
		else if (building.Feature == "Camp")
		{
			AssetsManager.Instance.LoadAsset<Sprite>("room_unlocked_barracks").Then((Action<Sprite>)delegate(Sprite asset)
			{
				OpenIEnumerator(UnLoadBuildingsSprites(building.BuildingType, building.Feature, hitArea, isInit));
				hitArea.hitData.background.GetComponent<SpriteRenderer>().sprite = asset;
				spriteList.Add("room_unlocked_barracks");
			});
			hitArea.hitData.mask.SetActive(false);
			hitArea.hitData.decoration.SetActive(true);
			hitArea.hitData.conveyor.SetActive(true);
			if (building.Slot <= 5)
			{
				CampController campController2 = (CampController)((Camp)building).Controller;
				for (int num8 = 0; num8 < building.Slot; num8++)
				{
					GameObject slotGameObject2 = campController2.GetSlotGameObject(num8);
					if (slotGameObject2 != null)
					{
						slotGameObject2.SetActive(true);
					}
				}
			}
			hitArea.hitData.builders.SetActive(false);
		}
		else if (building.Feature == "Storehouse")
		{
			hitArea.hitData.builders.SetActive(false);
		}
		else if (building.Feature == "MilitaryIntelligence7")
		{
			hitArea.hitData.builders.SetActive(false);
			AssetsManager.Instance.LoadAsset<Sprite>("room_unlocked_" + building.BuildingType).Then((Action<Sprite>)delegate(Sprite asset)
			{
				OpenIEnumerator(UnLoadBuildingsSprites(building.BuildingType, building.Feature, hitArea, isInit));
				hitArea.hitData.background.GetComponent<SpriteRenderer>().sprite = asset;
				spriteList.Add("room_unlocked_" + building.BuildingType);
			});
			hitArea.hitData.mask.SetActive(false);
			hitArea.hitData.decoration.SetActive(true);
			AssetsManager.Instance.LoadAsset<Sprite>("room_deco_" + building.BuildingType).Then((Action<Sprite>)delegate(Sprite asset)
			{
				hitArea.hitData.decoration.GetComponent<SpriteRenderer>().sprite = asset;
				spriteList.Add("room_deco_" + building.BuildingType);
			});
		}
		else if (building.Feature == "BlackMarketer")
		{
			hitArea.hitData.builders.SetActive(false);
			if (building.BuildingType == "16")
			{
				AssetsManager.Instance.LoadAsset<Sprite>("room_unlocked_" + building.BuildingType).Then((Action<Sprite>)delegate(Sprite asset)
				{
					OpenIEnumerator(UnLoadBuildingsSprites(building.BuildingType, building.Feature, hitArea, isInit));
					hitArea.hitData.background.GetComponent<SpriteRenderer>().sprite = asset;
					spriteList.Add("room_unlocked_" + building.BuildingType);
				});
				hitArea.hitData.mask.SetActive(false);
				hitArea.hitData.decoration.SetActive(true);
				AssetsManager.Instance.LoadAsset<Sprite>("room_deco_" + building.BuildingType).Then((Action<Sprite>)delegate(Sprite asset)
				{
					hitArea.hitData.decoration.GetComponent<SpriteRenderer>().sprite = asset;
					spriteList.Add("room_deco_" + building.BuildingType);
				});
			}
		}
		else if (!(building.Feature == "MoltenCore"))
		{
		}
	}

	public void RefreshConveyorByEvents(string buildingType, int nextLevel)
	{
		if (nextLevel == 1)
		{
			Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType(buildingType);
			if (buildingByType.BuildingType == "1" || buildingByType.BuildingType == "2")
			{
				GameManagers.Instance.BuildingManager.Buildings["4"].GameObject.GetComponent<HitArea>().hitData.conveyor.SetActive(true);
				GameManagers.Instance.BuildingManager.Buildings["5"].GameObject.GetComponent<HitArea>().hitData.conveyor.SetActive(true);
				GameManagers.Instance.BuildingManager.Buildings["6"].GameObject.GetComponent<HitArea>().hitData.conveyor.SetActive(true);
			}
			else if (buildingByType.BuildingType == "4" || buildingByType.BuildingType == "5" || buildingByType.BuildingType == "6")
			{
				GameManagers.Instance.BuildingManager.Buildings["4"].GameObject.GetComponent<HitArea>().hitData.conveyor.SetActive(true);
				GameManagers.Instance.BuildingManager.Buildings["5"].GameObject.GetComponent<HitArea>().hitData.conveyor.SetActive(true);
				GameManagers.Instance.BuildingManager.Buildings["6"].GameObject.GetComponent<HitArea>().hitData.conveyor.SetActive(true);
			}
			else if (buildingByType.BuildingType == "13" || buildingByType.BuildingType == "8" || buildingByType.BuildingType == "9")
			{
				GameManagers.Instance.BuildingManager.Buildings["13"].GameObject.GetComponent<HitArea>().hitData.conveyor.SetActive(true);
				GameManagers.Instance.BuildingManager.Buildings["8"].GameObject.GetComponent<HitArea>().hitData.conveyor.SetActive(true);
				GameManagers.Instance.BuildingManager.Buildings["9"].GameObject.GetComponent<HitArea>().hitData.conveyor.SetActive(true);
			}
		}
	}

	public void UpdateAnnouncement(List<Announcement> announcements)
	{
		foreach (Announcement announcement in announcements)
		{
			curAnnouncementId = announcement.Id;
			UpdateMessage(announcement.Content, announcement.Type, announcement.From);
		}
	}

	public void UpdateMessage(string content, int type, int from)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		object obj = UiTagManager.Instance.FindObjectByTag("MainCity.ChatContentList");
		string text = LanguagesManager.GetDesc("CsharpCodeZhTcText42") + "：";
		if (obj != null)
		{
			((GObject)((GComponent)((GComponent)((GObject)obj).asList).GetChildAt(0).asButton).GetChild("ChatContent").asTextField).text = content;
			((GObject)((GComponent)((GComponent)((GObject)obj).asList).GetChildAt(0).asButton).GetChild("sender").asTextField).text = text;
		}
		else
		{
			messageTemp = content;
			senderTemp = text;
		}
	}

	public string TruncateTextLength(string originalText, int permissibleLength, string suffix = "...")
	{
		string pattern = "[^\\x00-\\xff]";
		if (Regex.Replace(originalText, pattern, "aa").Length <= permissibleLength)
		{
			return originalText;
		}
		while (Regex.Replace(originalText, pattern, "aa").Length > permissibleLength)
		{
			originalText = originalText.Substring(0, originalText.Length - 1);
		}
		return originalText + suffix;
	}

	public void ClaimBonusFromApiModels(List<ModelsBonus> bonusList, Action<ModelsBonus> extraProcess = null)
	{
		foreach (ModelsBonus bonus in bonusList)
		{
			string[] array = bonus.ItemId.Split('.');
			int qty = bonus.Qty;
			if (array.Length == 1)
			{
				Bonus.Get(bonus.ItemId, qty, bonus.Type, bonus.IsShining).Claim(GameManagers.Instance, null, bonus.StockInReason);
			}
			else if (array.Length == 2)
			{
				string text = array[1];
				switch (array[0])
				{
				case "PotentialLevel":
					GameManagers.Instance.UserArchiveManager.SetSoldierPotentialLevel(text, qty, refundProgress: true);
					break;
				case "Unlock":
					switch (SchemaIndexHelper.GetSchemaById(text))
					{
					case "Item":
						GameManagers.Instance.UserArchiveManager.SetItemLevel(text, qty);
						break;
					case "Product":
						GameManagers.Instance.UserArchiveManager.UnlockProduct(text);
						break;
					case "Soldier":
						GameManagers.Instance.SoldierManager.Unlock(text, qty, 0);
						break;
					case "Technology":
						Bonus.Get(text, qty, 2).Claim(GameManagers.Instance);
						break;
					case "Formation":
						GameManagers.Instance.FormationManager.UnlockFormation(text, free: true);
						break;
					}
					Bonus.Get(text, qty, 2);
					break;
				case "AutoProduce":
					GameManagers.Instance.UserArchiveManager.InsertAutoProduceBonus(text, qty);
					break;
				default:
					Bonus.Get(bonus.ItemId, qty, bonus.Type, bonus.IsShining).Claim(GameManagers.Instance, null, bonus.StockInReason);
					break;
				}
			}
			extraProcess?.Invoke(bonus);
		}
	}

	public void SetUiMaskVisible(bool _visible)
	{
		UnityUiService.Instance.SetMaskVisible(_visible);
		float delay = 0.05f;
		if (!_visible)
		{
			delay = 2.2f;
		}
		((MonoBehaviour)this).StartCoroutine(UpdateStageCameraFrames(delay));
		if ((Object)(object)StageCamera != (Object)null && !_visible)
		{
			StageCamera.cullingMask = 0;
		}
	}

	private void ShowDungeonLevelUpTip(int _level)
	{
		if (curLegionSizeLimit != GameController.Contexts.game.dungeon.value.LegionSizeLimit)
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "LastLimit", curLegionSizeLimit },
				{
					"CurLimit",
					GameController.Contexts.game.dungeon.value.LegionSizeLimit
				}
			};
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UndergroundCityUpGrade.Name, parameters);
			curLegionSizeLimit = GameController.Contexts.game.dungeon.value.LegionSizeLimit;
		}
	}

	public int GetRaceIcon(string _race)
	{
		int num = 0;
		return _race switch
		{
			"哥布林" => 0, 
			"恶魔" => 1, 
			"亡灵" => 2, 
			"人类" => 3, 
			"兽族" => 4, 
			_ => 5, 
		};
	}

	public void ShowRaceInfo(string _race, int _type, int _order)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Order", _order);
		dictionary.Add("Type", _type);
		dictionary.Add("Race", _race);
		dictionary.Add("List", GetRaceList(_race));
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_RaceInfoPanel.Name, dictionary);
	}

	public List<string> GetRaceList(string _race)
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>(GameManagers.Instance.SoldierManager.PlayerSoldiers.Keys);
		foreach (string key in GameManagers.Instance.SoldierManager.PlayerSoldiers.Keys)
		{
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(key);
			if (soldier.Faction == _race)
			{
				list.Add(key);
			}
		}
		return list;
	}

	public void SetScreenOrientationPortrait()
	{
		GRoot.inst.SetContentScaleFactor(1080, 1920);
		Screen.orientation = (ScreenOrientation)1;
		Screen.autorotateToPortrait = true;
		Screen.autorotateToPortraitUpsideDown = true;
		Screen.autorotateToLandscapeLeft = false;
		Screen.autorotateToLandscapeRight = false;
		Instance.SetUiMaskVisible(_visible: false);
	}

	public void SetScreenOrientationAutoRotation(Action action)
	{
		GRoot.inst.SetContentScaleFactor(1920, 1080);
		ScriptApi.CreateTimer(0.5f, delegate
		{
			action();
			Screen.orientation = (ScreenOrientation)3;
			Screen.orientation = (ScreenOrientation)5;
			Screen.autorotateToPortrait = false;
			Screen.autorotateToPortraitUpsideDown = false;
			Screen.autorotateToLandscapeLeft = true;
			Screen.autorotateToLandscapeRight = true;
			Instance.SetUiMaskVisible(_visible: true);
		});
	}

	public void AdaptationsOnChangeScreenSize(float curPlayTime)
	{
		float num = curPlayTime - lastUpdateScreenTime;
		if (num <= 1f && num >= 0f)
		{
			return;
		}
		if (!UnityUiService.IsReady())
		{
			UnityUiService.Instance.ShowWaitingAnimation(show: false);
			UnityUiService.Instance.SetMaskVisible(value: false);
			return;
		}
		lastUpdateScreenTime = curPlayTime;
		if (Math.Abs(lastScreenWidth - -1f) < float.Epsilon || Math.Abs((float)Screen.width - lastScreenWidth) > float.Epsilon || Math.Abs((float)Screen.height - lastScreenHeight) > float.Epsilon)
		{
			lastScreenWidth = Screen.width;
			lastScreenHeight = Screen.height;
			OpenUiAndSceneAdaptationsOnChangeScreenSizeIEnumerator();
		}
	}

	private void OpenUiAndSceneAdaptationsOnChangeScreenSizeIEnumerator()
	{
		if (uiAndSceneAdaptationsOnChangeScreenSizeCoroutine != null)
		{
			CloseIEnumerator(uiAndSceneAdaptationsOnChangeScreenSizeCoroutine);
		}
		uiAndSceneAdaptationsOnChangeScreenSizeCoroutine = OpenIEnumerator(UiAndSceneAdaptationsOnChangeScreenSize());
	}

	private IEnumerator UiAndSceneAdaptationsOnChangeScreenSize()
	{
		float curWidth = Screen.width;
		float curHeight = Screen.height;
		Instance.StageCamera.clearFlags = (CameraClearFlags)2;
		yield return (object)new WaitForEndOfFrame();
		ApplyContentScaleFactor(curWidth, curHeight);
		UnityUiService.Instance.GetScreenWidthHeightRadio();
		yield return (object)new WaitForEndOfFrame();
		UnityUiService.Instance.edgeMaskPanel.Init(null);
		UnityUiService.Instance.waitingPanel.Init(null);
		UnityUiService.Instance.ChangeAllUiSizeAndPos();
		Camera _camera = ((Component)Camera.main).GetComponent<Camera>();
		Singleton<CameraService>.Instance.FicCameraOnChangeScreenSize(_camera, curWidth, curHeight);
		UnityUiService.Instance.maskCover.Init(null);
		UnityUiService.Instance.EdgeMaskInit();
		yield return (object)new WaitForEndOfFrame();
		Instance.StageCamera.clearFlags = (CameraClearFlags)3;
		SharedMessenger.Broadcast("SCREEN_RESIZE");
	}

	public void ApplyContentScaleFactor(float curWidth, float curHeight)
	{
		GRoot.inst.SetContentScaleFactor(1920, 1080, (ScreenMatchMode)0);
		if (((GObject)GRoot.inst).width / ((GObject)GRoot.inst).height > 2.3703704f)
		{
			float num = 2560f;
			((GObject)GRoot.inst).x = (((GObject)GRoot.inst).width - num) / 2f;
			((GObject)GRoot.inst).width = num;
		}
		else
		{
			((GObject)GRoot.inst).x = 0f;
		}
	}

	private void UpdateMails(List<ClientMail> mails)
	{
		GetMails();
	}

	public void GetMails()
	{
		if (GameManagers.Instance.MailManager.Mails == null)
		{
			return;
		}
		MailsList.Clear();
		MailsList.AddRange(GameManagers.Instance.MailManager.Mails.Values);
		for (int num = MailsList.Count - 1; num >= 0; num--)
		{
			if (MailsList[num].Status == MailStatus.Deleted)
			{
				MailsList.RemoveAt(num);
			}
		}
		UpdateMailBtnNote();
	}

	public void UpdateMailBtnNote()
	{
		if (MaincityUi == null)
		{
			return;
		}
		List<ClientMail> mailsList = MailsList;
		((GObject)MaincityUi.MailBox_T.note).visible = false;
		((GObject)MaincityUi.MailBox_T.newNote).visible = false;
		string text = "idle_close";
		UI_MainCity.MailIconType mailIconStatus = UI_MainCity.MailIconType.Empty;
		if (GameManagers.Instance.FriendsChatManager.HasAnyUnreadMessage)
		{
			text = "idle_open2";
			mailIconStatus = UI_MainCity.MailIconType.Chat;
		}
		for (int i = 0; i < mailsList.Count; i++)
		{
			if (mailsList[i].Status == MailStatus.Unread)
			{
				text = "idle_open";
				mailIconStatus = UI_MainCity.MailIconType.Mail;
				break;
			}
		}
		if ((Object)(object)MaincityUi.MailSpineAnimation != (Object)null && MaincityUi.MailSpineAnimation.AnimationName != text)
		{
			((SkeletonRenderer)MaincityUi.MailSpineAnimation).ClearState();
			MaincityUi.MailSpineAnimation.AnimationState.AddAnimation(0, text, true, 0f);
		}
		MaincityUi.MailIconStatus = mailIconStatus;
	}

	public int GetSoulStoneNum(string stoneItemId)
	{
		int num = GameManagers.Instance.StockController.GetStock(stoneItemId);
		int num2 = Shift.Legion.Common.Models.Item.Rarity(stoneItemId);
		string soldierId = "S" + stoneItemId.Substring(3);
		Soldier soldier = new Soldier(soldierId);
		if (num2 - 1 == soldier.PotentialLevel)
		{
			num += soldier.PotentialProgress.Count;
		}
		return num;
	}

	private void CloseNewSoldierUIOnContract(string uiId)
	{
		if ((uiId == UI_main_NewSoldierPanel.Name || uiId == UI_SoldierShowPanel.Name || uiId == UI_UpgradeSuccessPanel.Name) && ContractPanel != null && ContractPanel.WaitingForOpenUiList.Count > 0)
		{
			ContractPanel.WaitingForOpenUiList.RemoveAt(0);
		}
	}

	private void OnSoldierSummoning(string soldierId, int levelChange, Dictionary<string, int> bonus)
	{
		if (bonus != null)
		{
			foreach (KeyValuePair<string, int> bonu in bonus)
			{
			}
		}
		if (levelChange > 0)
		{
			int soldierPotentialLevel = GameManagers.Instance.UserArchiveManager.GetSoldierPotentialLevel(soldierId);
			int potentialLevel = soldierPotentialLevel - levelChange;
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
			FakeSoldier fakeSoldier = new FakeSoldier(soldierId, soldier.Level, soldier.EvoLevel, soldierPotentialLevel);
			FakeSoldier value = new FakeSoldier(soldierId, fakeSoldier.Level, fakeSoldier.EvoLevel, potentialLevel);
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "Soldier", fakeSoldier },
				{ "FakeSoldier", value }
			};
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_NewUpguadeSuccessPanel.Name, parameters);
		}
	}

	public void UpdateParent(string curSoldierId)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		if (SoldierCultivatePanel != null && SoldierCultivatePanel.soldierId == curSoldierId)
		{
			((GComponent)(object)Instance.SoldierCultivatePanel).SetTimeout(0.15f).OnComplete((GTweenCallback)delegate
			{
				SoldierCultivatePanel.LoaderSoldierData(curSoldierId, isUpGrade: false, isUpPotential: true);
				SoldierCultivatePanel = null;
			});
		}
	}

	private void OnItemUpgrade(string itemId, int level)
	{
		if (!string.IsNullOrEmpty(itemId) && level >= 1 && BlueprintUpGradeInfo != null && BlueprintUpGradeInfo.Item1 == itemId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("BlueprintInfo", BlueprintUpGradeInfo);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_BlueprintUpGradePanel.Name, dictionary);
		}
	}

	public void OpenNewSoldierUiIEnumerator()
	{
		ShowNewSoldierEnumerator = ContractBonusesClaim();
		((MonoBehaviour)this).StartCoroutine(ShowNewSoldierEnumerator);
	}

	public void StopNewSoldierUiIEnumerator()
	{
		if (ShowNewSoldierEnumerator != null)
		{
			((MonoBehaviour)this).StopCoroutine(ShowNewSoldierEnumerator);
		}
	}

	public IEnumerator ContractBonusesClaim()
	{
		while (true)
		{
			OpenNewSoldierInterval -= 0.2f;
			if (OpenNewSoldierInterval <= 0f && ContractPanel != null && !ContractPanel.JudgeAnimationPlaying() && ContractPanel.WaitingForOpenUiList.Count > 0)
			{
				ContractPanel.WaitingForOpenUiList[0].BroadcastInforms();
				_ = ContractPanel.WaitingForOpenUiList[0].ItemId;
			}
			if (ContractPanel != null && ContractPanel.cardNum <= 0 && ContractPanel.WaitingForOpenUiList.Count == 0)
			{
				StopNewSoldierUiIEnumerator();
			}
			yield return (object)new WaitForSeconds(0.2f);
		}
	}

	public void OpenCloseLoadingUiIEnumerator()
	{
		CanCloseLoadingUITiming = CanCloseLoadingUI();
		((MonoBehaviour)this).StartCoroutine(CanCloseLoadingUITiming);
	}

	public IEnumerator CanCloseLoadingUI()
	{
		while (true)
		{
			yield return (object)new WaitForEndOfFrame();
		}
	}

	public void OpenMonthCardOverdueTipPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				"[color=#FFFF66]" + LanguagesManager.GetDesc("CsharpCodeZhTcText43") + "[/color]"
			},
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{
						"Confirm",
						delegate
						{
							GameController.Contexts.Service<IUiService>().OpenPanel(UI_MonthCardPanel.Name, new Dictionary<string, object> { 
							{
								"Activity",
								Instance.GetBlackMarketerActivity("UI_MonthCardPanel")
							} });
						}
					},
					{
						"Cancel",
						delegate
						{
							SharedMessenger.Broadcast("OPEN_WORKER_OVERVIEW_PANEL");
						}
					}
				}
			},
			{ "PageIndex", 3 },
			{
				"Title",
				LanguagesManager.GetDesc("CsharpCodeZhTcText44") + "！"
			},
			{ "FontSize", 34 }
		});
	}

	public bool JudgeFreeWorkerNum(bool needTip = false)
	{
		int freeManPower = Dungeon.GetFreeManPower(GameManagers.Instance);
		if (freeManPower < 0)
		{
			if (needTip)
			{
				OpenMonthCardOverdueTipPanel();
			}
			return false;
		}
		return true;
	}

	public bool NotEnoughToPayTip(Shift.Legion.Common.Models.Store.StoreItem storeItem, int order, int quantity = 1)
	{
		Dictionary<string, float> dictionary = storeItem.Price.First();
		bool result = true;
		foreach (KeyValuePair<string, float> item in dictionary)
		{
			if (!(item.Key == "RMB"))
			{
				int stock = GameManagers.Instance.StockController.GetStock(item.Key);
				if ((float)stock < item.Value * (float)quantity)
				{
					List<string> arg = new List<string> { GDMgr.Get<GDEItemData>(item.Key).Name + LanguagesManager.GetDesc("CsharpCodeZhTcText45") + "！" };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, order, arg3: false);
					result = false;
					break;
				}
			}
		}
		return result;
	}

	private void OpenTakeItems(string packItemId, List<Bonus> bonusList, Dictionary<string, float> resultDict)
	{
		List<KeyValuePair<string, float>> list = resultDict.ToList();
		for (int num = list.Count - 1; num >= 0; num--)
		{
			string key = list[num].Key;
			if (key[0] == 'S' && SchemaIndexHelper.GetSchemaById(key) == "Soldier")
			{
				list.RemoveAt(num);
			}
		}
		List<Modifier> list2 = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, packItemId);
		if (list2 != null)
		{
			string nameById = SchemaIndexHelper.GetNameById(GameManagers.Instance, packItemId);
			int num2 = Shift.Legion.Common.Models.Item.ItemType(packItemId);
			if (num2 == 34)
			{
				OpenTakeItemsPanelForPack(nameById, bonusList, list, "", WarehousePanel);
				return;
			}
			Dictionary<string, object> uiParams = (list2.Exists((Modifier modifer) => modifer.ModifierId == "UIParams") ? list2.Find((Modifier modifer) => modifer.ModifierId == "UIParams").PayloadDictionary : null);
			foreach (Modifier item in list2)
			{
				if (item.ModifierId == "TIP")
				{
					foreach (Bonus bonus2 in bonusList)
					{
						ILRequestHelper.ShowMessage($"{Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, bonus2.ItemId)}+{bonus2.Qty}");
					}
					return;
				}
				if (item.ModifierId == "UI")
				{
					OpenTakeItemsPanelForPack(nameById, bonusList, list, "", WarehousePanel, uiParams);
					return;
				}
				if (item.ModifierId == "OpenUI")
				{
					Dictionary<string, object> parameters = null;
					if (item.PayloadDictionary.TryGetValue("Data", out var value))
					{
						parameters = JsonHelper.ToObject<Dictionary<string, object>>(value.ToString());
					}
					GameController.Contexts.Service<IUiService>().OpenPanel(item.PayloadDictionary["Payload"].ToString(), parameters);
					return;
				}
			}
		}
		foreach (Bonus bonus3 in bonusList)
		{
			bonus3.BroadcastInforms();
			if (bonus3.ItemId.IndexOf("Unlock.") >= 0)
			{
				string itemId = bonus3.ItemId.Replace("Unlock.", "");
				Bonus bonus = Bonus.Get(itemId, bonus3.Qty, bonus3.Type, bonus3.IsShining);
				bonus.Claim(GameManagers.Instance, null, null, forceClaim: true, broadcastInform: true, _isChangeStock: false);
			}
		}
	}

	public void OpenTakeItemsPanelForPack(string packName, List<Bonus> bonusList, List<KeyValuePair<string, float>> resultDict, string confirmBtnTitle = "", IUiController uiPanel = null, Dictionary<string, object> uiParams = null)
	{
		List<Bonus> list = new List<Bonus>();
		foreach (KeyValuePair<string, float> item in resultDict)
		{
			list.Add(Bonus.Get(item.Key, item.Value));
		}
		if (list.Count <= 4)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>
			{
				{ "Name", packName },
				{ "Items", list },
				{ "ShowBox", true },
				{ "ResultList", bonusList }
			};
			if (!string.IsNullOrWhiteSpace(confirmBtnTitle))
			{
				dictionary.Add("ConfirmBtnTitle", confirmBtnTitle);
			}
			if (uiPanel != null && uiPanel is UI_ActivityPanel)
			{
				dictionary.Add("Parent", uiPanel);
			}
			else if (uiPanel != null && uiPanel is UI_WarehousePanel)
			{
				dictionary.Add("Parent", uiPanel);
			}
			if (uiParams != null)
			{
				foreach (KeyValuePair<string, object> uiParam in uiParams)
				{
					dictionary.Add(uiParam.Key, uiParam.Value);
				}
			}
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_TakeItems.Name, dictionary);
		}
		else
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ShowOfflineEarnings.Name, new Dictionary<string, object>
			{
				{ "Bonus", list },
				{ "Time", 0 },
				{ "Status", 2 },
				{ "Title", packName }
			});
		}
	}

	public void OpenMilitaryIntelligencePanel(string uiName, Dictionary<string, object> dic)
	{
		Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType("14");
		if (buildingByType.Status == BuildingStatus.Banned)
		{
			List<string> arg = new List<string>
			{
				LanguagesManager.GetDesc("CsharpCodeZhTcText21"),
				LanguagesManager.GetDesc("CsharpCodeZhTcText22")
			};
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
		else if (buildingByType.Status == BuildingStatus.Ready)
		{
			dic.Add("Building", buildingByType);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dic);
		}
		else if (buildingByType.Level == 0)
		{
			dic.Add("Building", buildingByType);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dic);
		}
		else if (Instance.JudgeFreeWorkerNum(needTip: true))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_MilitaryIntelligencePanel.Name, dic);
		}
	}

	private void OpenSandClock(int time, List<Bonus> resultList)
	{
		SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText46") + UiHelper.ParseTimeChinses(time) }, 1000, arg3: false);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_ShowOfflineEarnings.Name, new Dictionary<string, object>
		{
			{ "Bonus", resultList },
			{ "Time", time },
			{ "Status", 1 }
		});
	}

	private void OpenTechUi(string techId, int level)
	{
		GameManagers.Instance.NewMsgIncomingManager.CheckNewTechPoint();
		if (!TechIdisNotMainKey(techId) && !SkipShowTechUpgradeTip)
		{
			ScriptApi.CreateTimer(2f, delegate
			{
				Dictionary<string, object> parameters = new Dictionary<string, object>
				{
					{ "MainTechId", techId },
					{ "Level", level }
				};
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_LordUpgradeTipPanel.Name, parameters);
			});
		}
		else if (GameManagers.Instance.UserArchiveManager.GetTechLevel(techId) <= 1 && TechnologyPanel == null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("TechId", techId);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_Technology.Name, dictionary);
		}
	}

	public void StartLongPress(int index, UI_ExperiencePage page, UI_SoldierCultivate soldierCultivate, LongPressGesture gestureA)
	{
		if (soldierCultivate.soldier.Level >= soldierCultivate.soldier.MaxLevel)
		{
			List<string> content = new List<string>
			{
				LanguagesManager.GetDesc("CsharpCodeZhTcText23"),
				LanguagesManager.GetDesc("CsharpCodeZhTcText24")
			};
			ShowTips(content, 1, showMask: false);
		}
		else
		{
			LongPressEvent = AutomatedEvent(index, page, soldierCultivate, gestureA);
			((MonoBehaviour)this).StartCoroutine(LongPressEvent);
		}
	}

	public void StopLongPress()
	{
		if (LongPressEvent != null)
		{
			((MonoBehaviour)this).StopCoroutine(LongPressEvent);
		}
	}

	public IEnumerator AutomatedEvent(int index, UI_ExperiencePage page, UI_SoldierCultivate soldierCultivate, LongPressGesture gestureA)
	{
		float time = 0.35f;
		while (true)
		{
			if (soldierCultivate.soldier.Level >= soldierCultivate.soldier.MaxLevel)
			{
				List<string> tipList = new List<string>
				{
					LanguagesManager.GetDesc("CsharpCodeZhTcText23"),
					LanguagesManager.GetDesc("CsharpCodeZhTcText24")
				};
				ShowTips(tipList, 1, showMask: false);
				StopLongPress();
			}
			if (!soldierCultivate.isToMax)
			{
				GGraph progressBarSfxBack = ((soldierCultivate.progressBarSfxBackList.Count > 0) ? soldierCultivate.progressBarSfxBackList[soldierCultivate.progressBarSfxBackList.Count - 1] : null);
				int nextLevelExpBefore = SoldierLevelManager.GetLevelTotalExp(soldierCultivate.soldier.NextLevel);
				double upLevelBeforeExp = SoldierLevelManager.GetLevelTotalExp(soldierCultivate.soldier.Level);
				int curLevelSoldierExp = GameManagers.Instance.UserArchiveManager.GetSoldierExp(soldierCultivate.soldier.Id);
				int curLevelSoldierRemainingExp = nextLevelExpBefore - (int)upLevelBeforeExp - curLevelSoldierExp;
				int stock = GameManagers.Instance.StockController.GetStock(soldierCultivate.expItems[index]);
				if (stock - 1 < 0 || soldierCultivate.soldier.Level >= GameManagers.Instance.UserArchiveManager.GetSoldierMaxLevel(soldierCultivate.soldier.Id))
				{
					break;
				}
				List<Modifier> effect = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, soldierCultivate.expItems[index]);
				for (int i = 0; i < effect.Count; i++)
				{
					if (effect[i].ModifierId == "Bonus")
					{
						int canGetExp = Convert.ToInt32(effect[i].PayloadDictionary["SoldierExp"]);
						canGetExp = (int)((float)canGetExp * (1f + GameManagers.Instance.ModifierManager.GetPercentFloatPayload("SoldierExpGain")));
						bool canLevelUp = ((canGetExp >= curLevelSoldierRemainingExp) ? true : false);
						((GObject)soldierCultivate.SoldierInfoPanel.ExperienceProcessBar).data = new Tuple<LongPressGesture, UI_ExperiencePage, GGraph, int, double, bool>(gestureA, page, progressBarSfxBack, nextLevelExpBefore, upLevelBeforeExp, canLevelUp);
						break;
					}
				}
				ILRequestHelper<UseItemResponse>.Request((EventContext)null, (Func<Task<UseItemResponse>>)(() => GameController.Contexts.Service<INetworkService>().UseItem(-1L, soldierCultivate.expItems[index], 1, soldierCultivate.soldier.Id)), (Action<UseItemResponse>)delegate(UseItemResponse response)
				{
					if (!response.Result)
					{
						ILRequestHelper.ShowErrorCode(response.ErrorCode);
					}
					else
					{
						Shift.Legion.Common.Models.Item.Use(GameManagers.Instance, soldierCultivate.expItems[index], soldierCultivate.soldier);
					}
				});
			}
			yield return (object)new WaitForSeconds(time);
		}
	}

	public IEnumerator RepairTiming(int time, Building building)
	{
		HitArea hitArea = building.GameObject.GetComponent<HitArea>();
		BuildingConstructingConfig info = building.ConstructingConfig;
		int totalTime = info.UpgradeRemainingTime;
		if (totalTime <= 0)
		{
			PlayBuildingRepaired(building);
			Instance.BuildingUpgradeBarRefresh(building, init: false, totalTime);
			yield return (object)new WaitForSeconds(1f);
		}
		while (totalTime > 0)
		{
			totalTime--;
			if (totalTime <= 1 && !hitArea.haveSmoke)
			{
				if (building.BuildingType == "10")
				{
					for (int i = 0; i < 3; i++)
					{
						int index = i;
						ScriptApi.CreateTimer(1.8f, delegate
						{
							//IL_000b: Unknown result type (might be due to invalid IL or missing references)
							//IL_0041: Unknown result type (might be due to invalid IL or missing references)
							//IL_0077: Unknown result type (might be due to invalid IL or missing references)
							//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
							//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
							//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
							GameObject val = SpawnManager.Instance.InstantiatePool("buildingSmoke", Vector3.zero);
							if ((Object)(object)val != (Object)null)
							{
								val.transform.eulerAngles = building.GameObject.transform.eulerAngles;
								val.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
								val.transform.position = new Vector3(building.GameObject.transform.position.x + (float)((index - 1) * 2), building.GameObject.transform.position.y, val.transform.position.z);
							}
						});
					}
					ScriptApi.CreateTimer(0.5f, delegate
					{
						hitArea.haveSmoke = true;
					});
				}
				else if (!(building.BuildingType == "1") && !(building.BuildingType == "2") && !(building.BuildingType == "3") && !(building.BuildingType == "12"))
				{
					ScriptApi.CreateTimer(1.8f, delegate
					{
						//IL_000b: Unknown result type (might be due to invalid IL or missing references)
						//IL_0068: Unknown result type (might be due to invalid IL or missing references)
						//IL_0088: Unknown result type (might be due to invalid IL or missing references)
						GameObject val = SpawnManager.Instance.InstantiatePool("buildingSmoke", Vector3.zero);
						if ((Object)(object)val != (Object)null && !hitArea.haveSmoke)
						{
							val.transform.parent = building.GameObject.transform;
							val.transform.localEulerAngles = building.GameObject.transform.eulerAngles;
							val.transform.localPosition = new Vector3(0f, 0f, -5f);
							val.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
						}
						hitArea.haveSmoke = true;
					});
				}
				else
				{
					ScriptApi.CreateTimer(1.9f, delegate
					{
						//IL_000b: Unknown result type (might be due to invalid IL or missing references)
						//IL_0068: Unknown result type (might be due to invalid IL or missing references)
						//IL_0088: Unknown result type (might be due to invalid IL or missing references)
						GameObject val = SpawnManager.Instance.InstantiatePool("workplaceSmoke", Vector3.zero);
						if ((Object)(object)val != (Object)null && !hitArea.haveSmoke)
						{
							val.transform.parent = building.GameObject.transform;
							val.transform.localEulerAngles = building.GameObject.transform.eulerAngles;
							val.transform.localPosition = new Vector3(0f, 0f, -5f);
							val.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
						}
						hitArea.haveSmoke = true;
					});
				}
			}
			Instance.BuildingUpgradeBarRefresh(building, init: false, totalTime);
			yield return (object)new WaitForSeconds(1f);
		}
		hitArea.isStartRepair = false;
		LoadBuildings(building, isInit: false, 1);
		ReSetSlot(building);
		if (building.Level >= 1)
		{
			hitArea.hitData.builders.SetActive(true);
		}
		for (int i2 = 0; i2 < 5; i2++)
		{
			if (((Component)hitArea.hitData.builders.transform.GetChild(i2)).gameObject.activeInHierarchy)
			{
				((Component)hitArea.hitData.builders.transform.GetChild(i2)).GetComponent<SkeletonAnimation>().AnimationName = "idle";
			}
		}
		ScriptApi.CreateTimer(1.05f, delegate
		{
			for (int num = hitArea.smokes.Count - 1; num >= 0; num--)
			{
				Object.Destroy((Object)(object)hitArea.smokes[num]);
			}
			hitArea.smokes.Clear();
		});
		OpenFlowIEnumerator(building);
	}

	private void PlayBuildingRepaired(Building building)
	{
		HitArea hitArea = building.GameObject.GetComponent<HitArea>();
		if (hitArea.haveSmoke)
		{
			return;
		}
		if (building.BuildingType == "10")
		{
			for (int i = 0; i < 3; i++)
			{
				int index = i;
				ScriptApi.CreateTimer(0.2f, delegate
				{
					//IL_000b: Unknown result type (might be due to invalid IL or missing references)
					//IL_0041: Unknown result type (might be due to invalid IL or missing references)
					//IL_0077: Unknown result type (might be due to invalid IL or missing references)
					//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
					//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
					//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
					GameObject val = SpawnManager.Instance.InstantiatePool("buildingSmoke", Vector3.zero);
					if ((Object)(object)val != (Object)null)
					{
						val.transform.eulerAngles = building.GameObject.transform.eulerAngles;
						val.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
						val.transform.position = new Vector3(building.GameObject.transform.position.x + (float)((index - 1) * 2), building.GameObject.transform.position.y, val.transform.position.z);
					}
				});
			}
			ScriptApi.CreateTimer(0.2f, delegate
			{
				hitArea.haveSmoke = true;
			});
			return;
		}
		if (!(building.BuildingType == "1") && !(building.BuildingType == "2") && !(building.BuildingType == "3") && !(building.BuildingType == "12"))
		{
			ScriptApi.CreateTimer(0.1f, delegate
			{
				//IL_000b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0068: Unknown result type (might be due to invalid IL or missing references)
				//IL_0088: Unknown result type (might be due to invalid IL or missing references)
				GameObject val = SpawnManager.Instance.InstantiatePool("buildingSmoke", Vector3.zero);
				if ((Object)(object)val != (Object)null && !hitArea.haveSmoke)
				{
					val.transform.parent = building.GameObject.transform;
					val.transform.localEulerAngles = building.GameObject.transform.eulerAngles;
					val.transform.localPosition = new Vector3(0f, 0f, -5f);
					val.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
				}
				hitArea.haveSmoke = true;
			});
			return;
		}
		ScriptApi.CreateTimer(0.2f, delegate
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			GameObject val = SpawnManager.Instance.InstantiatePool("workplaceSmoke", Vector3.zero);
			if ((Object)(object)val != (Object)null && !hitArea.haveSmoke)
			{
				val.transform.parent = building.GameObject.transform;
				val.transform.localEulerAngles = building.GameObject.transform.eulerAngles;
				val.transform.localPosition = new Vector3(0f, 0f, -5f);
				val.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
			}
			hitArea.haveSmoke = true;
		});
	}

	public void OpenFlowIEnumerator(Building building)
	{
		if (building.Feature == "WorkShop" && building.Level == 0)
		{
			IEnumerator enumerator = FlowLight(building);
			((MonoBehaviour)this).StartCoroutine(enumerator);
			buildingFlowLight.Add(building.BuildingType ?? "", enumerator);
			((WorkshopController)((WorkShop)building).Controller).OpenFlowIEnumerator(building);
		}
	}

	public IEnumerator FlowLight(Building building)
	{
		HitArea hitArea = building.GameObject.GetComponent<HitArea>();
		if (!((Object)(object)hitArea.hitData.decoration != (Object)null))
		{
			yield break;
		}
		while (true)
		{
			float time = Time.realtimeSinceStartup;
			int decade = (int)time / 10;
			float amend = time - (float)(10 * decade);
			if (1.4 <= (double)amend && amend <= 3f)
			{
				((Renderer)hitArea.hitData.decoration.GetComponent<SpriteRenderer>()).material.SetFloat("_uvaddspeed", amend / 2f);
			}
			else
			{
				((Renderer)hitArea.hitData.decoration.GetComponent<SpriteRenderer>()).material.SetFloat("_uvaddspeed", 0.7f);
			}
			yield return null;
		}
	}

	public void ReSetSlot(Building building)
	{
		if (building.BuildingType == "10")
		{
			Camp camp = (Camp)building;
			int level = ((camp.NextLevel != 1) ? camp.NextLevel : 0);
			((CampController)camp.Controller).SetSlot(camp.SomeLevelSlot(level));
		}
		else
		{
			if (building.BuildingType == "1" || building.BuildingType == "2" || building.BuildingType == "3" || building.BuildingType == "12" || building.BuildingType == "17")
			{
				return;
			}
			int expectedLevel = ((building.Level != 0) ? 1 : 0);
			((WorkshopController)((WorkShop)building).Controller).WorkshopStyleInit(expectedLevel);
			if (building.Level == 0)
			{
				ScriptApi.CreateTimer(0.25f, delegate
				{
					((WorkshopController)((WorkShop)building).Controller).WorkshopStyleInit(1);
				});
			}
		}
	}

	public void CheckIsClearUi(string str)
	{
		if (UnityUiService.Instance.CheckIsClearUi() && UnityUiService.Instance.edgeMaskPanel.ratio > 1f)
		{
			UnityUiService.Instance.SetEdgeMaskVisible(value: false);
		}
	}

	private void UpdateWorkshopSlot(string uiName)
	{
		if (uiName == UI_MonthCardPanel.Name && leaseholdChanged)
		{
			List<string> arg = new List<string>
			{
				LanguagesManager.GetDesc("CsharpCodeZhTcText25"),
				LanguagesManager.GetDesc("CsharpCodeZhTcText26")
			};
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			ReSetWorkshopSlot();
		}
	}

	private void SetLeaseholdChanged(string itemId, DateTimeOffset dateTime)
	{
		if (itemId == "PrimeContract" && GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime("PrimeContract") <= 2592000)
		{
			leaseholdChanged = true;
		}
		else if (itemId == "OverlordContract_Week")
		{
			UnityUiService.Instance.OpenPanel(UI_MonthCardPanel.Name, new Dictionary<string, object> { 
			{
				"Activity",
				Instance.GetBlackMarketerActivity("UI_MonthCardPanel")
			} });
		}
	}

	public void ReSetWorkshopSlot()
	{
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		leaseholdChanged = false;
		bool flag = false;
		foreach (Building building in GameManagers.Instance.BuildingManager.Buildings.Values)
		{
			if (!string.IsNullOrEmpty(building.Prefab) && building.Feature == "WorkShop" && building.Level > 0)
			{
				flag = true;
				ScriptApi.CreateTimer(1f, delegate
				{
					((WorkshopController)((WorkShop)building).Controller).WorkshopStyleInit(0, leaseholdChanged: true);
				});
			}
		}
		if (flag)
		{
			GameController.Contexts.Service<IUiService>().CloseAll();
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_MainCity.Name, null);
			Instance.SetMainCityCameraMoveInfo(GameController.Contexts.Service<ICameraService>().Position.x, -1f * Instance.difference, 1f);
		}
	}

	public static bool HasUiScaleAdaptation(GObject panel)
	{
		Instance.UIsScaleAdaptation.TryGetValue(panel, out var value);
		return value;
	}

	public static bool RemoveUIsScaleAdaptation(GObject panel)
	{
		return Instance.UIsScaleAdaptation.Remove(panel);
	}

	public static KeyValuePair<float, float> SetUiPanelSizeAndXy(GObject panel, bool scaleAdaption = false)
	{
		Instance.UIsScaleAdaptation[panel] = scaleAdaption;
		if (panel.parent is GRoot)
		{
			panel.sortingOrder = 2000;
		}
		panel.SetXY(0f, 0f);
		if (scaleAdaption)
		{
			return SetPanelYScaleAdaption(panel);
		}
		return SetPanelXOrY(panel);
	}

	private static KeyValuePair<float, float> SetPanelXOrY(GObject panel)
	{
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = 1.7777778f;
		float num3 = num / num2;
		if (num3 >= 1f)
		{
			panel.SetPivot(0.5f, 0.5f);
			float value = (panel.x = (((GObject)GRoot.inst).width - panel.width) / 2f);
			if (panel.parent != null && !(panel.parent is UI_WindowLoader))
			{
				UnityUiService.Instance.SetPanelMask(panel, privatePanel: true);
			}
			return new KeyValuePair<float, float>(num3, value);
		}
		panel.SetPivot(0.5f, 0.5f);
		float value2 = (panel.y = (((GObject)GRoot.inst).height - 1080f) / 2f);
		return new KeyValuePair<float, float>(num3, value2);
	}

	public static void SetToFullScreen(GObject target)
	{
		target.SetPivot(0.5f, 0.5f);
		target.SetSize(((GObject)GRoot.inst).width, target.height);
		target.AddRelation((GObject)(object)GRoot.inst, (RelationType)14);
		target.AddRelation((GObject)(object)GRoot.inst, (RelationType)3);
	}

	private static KeyValuePair<float, float> SetPanelYScaleAdaption(GObject panel)
	{
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = 1.7777778f;
		float num3 = num / num2;
		if (num3 >= 1f)
		{
			panel.SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
			panel.SetXY(0f, 0f);
			return new KeyValuePair<float, float>(num3, 0f);
		}
		panel.SetSize(((GObject)GRoot.inst).width, 1080f);
		panel.SetPivot(0.5f, 0.5f);
		float value = (panel.y = (((GObject)GRoot.inst).height - 1080f) / 2f);
		panel.x = 0f;
		return new KeyValuePair<float, float>(num3, value);
	}

	public Vector2 StageAmendXY(Vector2 xy)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		xy.x += (((GObject)GRoot.inst).width - 1920f) / 2f;
		xy.y += (((GObject)GRoot.inst).height - 1080f) / 2f;
		return xy;
	}

	public float ScreenAmendY()
	{
		return (((GObject)GRoot.inst).height - 1080f) / 2f;
	}

	public void SetMainCityPos(GameObject city)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		mainCity = city;
		if ((Object)(object)mainCity != (Object)null)
		{
			float num = mainCity.GetComponent<BoxCollider>().size.x * mainCity.transform.lossyScale.x;
			float num2 = mainCity.GetComponent<BoxCollider>().size.y * mainCity.transform.lossyScale.y;
			Transform transform = ((Component)((Component)Camera.main).transform.Find("BattleCameraFrame")).transform;
			SpriteRenderer component = ((Component)transform).GetComponent<SpriteRenderer>();
			component.sprite = Addressables.LoadAssetAsync<Sprite>((object)"BattleCameraFrame").WaitForCompletion();
			component.drawMode = (SpriteDrawMode)1;
			float num3 = (float)Screen.width / (float)Screen.height;
			float num4 = 1.7777778f;
			float num5 = num3 / num4;
			if (num5 < 1f)
			{
				Singleton<CameraService>.Instance.CameraSize = Singleton<CameraService>.Instance.CameraSize / num5;
				num *= Mathf.Sqrt(num5);
			}
			else if (num5 > 1f)
			{
				num *= Mathf.Sqrt(num5);
			}
			transform.localScale = new Vector3(transform.localScale.x * num5, transform.localScale.y, transform.localScale.z);
			if (cameraFrameX <= 0f)
			{
				cameraFrameX = component.size.x * transform.lossyScale.x;
			}
			difference = num / 2f - cameraFrameX / 2f;
		}
	}

	public Vector2 AmendXY(Vector2 xy)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = 1.7777778f;
		float num3 = num / num2;
		if (num3 > 1f)
		{
			((Vector2)(ref xy))._002Ector(xy.x * num3, xy.y);
		}
		else if (num3 < 1f)
		{
			((Vector2)(ref xy))._002Ector(xy.x, xy.y / num3);
		}
		return xy;
	}

	public bool JudgBattleFieldExist()
	{
		bool result = false;
		GameObject val = GameObject.Find("BattleField(Clone)");
		if ((Object)(object)val != (Object)null)
		{
			result = true;
		}
		return result;
	}

	public void SetSoulStoneIconAndFrame(GButton soulStoneBtn, string soulStoneItemId, List<string> textureList = null, int IconBtnStatus = 0)
	{
		int num = Shift.Legion.Common.Models.Item.Level(GameManagers.Instance, soulStoneItemId);
		GButton asButton = ((GComponent)soulStoneBtn).GetChild("IconBtn").asButton;
		((GComponent)asButton).GetController("Status").selectedIndex = IconBtnStatus;
		((GComponent)soulStoneBtn).GetController("Level").selectedIndex = num - 1;
		if (IconBtnStatus != 1)
		{
			GLoader asLoader = ((GComponent)asButton).GetChild("icon").asLoader;
			string icon = UiHelper.GetIcon(soulStoneItemId);
			asLoader.url = "ui://PublicResources/" + icon;
		}
	}

	public void GetBlackMarketData()
	{
		if (Instance.BlackMarket_StoreItem != null)
		{
			return;
		}
		Instance.BlackMarket_StoreItem = new Dictionary<string, Shift.Legion.ClientApi.Protocol.Store.StoreItem[]>();
		Activity storeActivity = Instance.GetBlackMarketerActivity("UI_GiftBagPanel");
		if (storeActivity == null)
		{
			return;
		}
		Dictionary<string, ActivityContentPayload> dictionary = storeActivity.ContentPayload(GameManagers.Instance);
		foreach (string _key in dictionary.Keys)
		{
			Task<GetStoreActivityItemsResponse> _task = GameController.Contexts.Service<INetworkService>().GetStoreActivityItems(storeActivity.ActivityId, _key);
			_task.GetAwaiter().OnCompleted(delegate
			{
				string key = storeActivity.ActivityId + ":" + _key;
				if (_task.Result.StoreItems != null)
				{
					Shift.Legion.ClientApi.Protocol.Store.StoreItem[] value = GiftBagSort(_task.Result.StoreItems);
					Instance.BlackMarket_StoreItem.Add(key, value);
				}
			});
		}
	}

	public void GetBlackMarketPurchaseLimitData()
	{
		if (Instance.BlackMarket_PurchaseLimit != null)
		{
			return;
		}
		Instance.BlackMarket_PurchaseLimit = new List<Shift.Legion.ClientApi.Protocol.Store.StoreItem>();
		Activity storeActivity = Instance.GetSpecialActivity("UI_NationalDayGiftBagPanel", ActivityType.HomePageActivity);
		if (storeActivity == null)
		{
			return;
		}
		Dictionary<string, ActivityContentPayload> dictionary = storeActivity.ContentPayload(GameManagers.Instance);
		foreach (string _key in dictionary.Keys)
		{
			Task<GetStoreActivityItemsResponse> _task = GameController.Contexts.Service<INetworkService>().GetStoreActivityItems(storeActivity.ActivityId, _key);
			_task.GetAwaiter().OnCompleted(delegate
			{
				string text = storeActivity.ActivityId + ":" + _key;
				if (_task.Result.StoreItems != null)
				{
					Shift.Legion.ClientApi.Protocol.Store.StoreItem[] source = GiftBagSort(_task.Result.StoreItems);
					Instance.BlackMarket_PurchaseLimit.AddRange(source.ToList());
				}
			});
		}
	}

	public Shift.Legion.ClientApi.Protocol.Store.StoreItem[] GiftBagSort(Shift.Legion.ClientApi.Protocol.Store.StoreItem[] itemList)
	{
		List<Shift.Legion.ClientApi.Protocol.Store.StoreItem> list = new List<Shift.Legion.ClientApi.Protocol.Store.StoreItem>();
		list.AddRange(itemList);
		List<Shift.Legion.ClientApi.Protocol.Store.StoreItem> list2 = new List<Shift.Legion.ClientApi.Protocol.Store.StoreItem>();
		for (int num = list.Count - 1; num >= 0; num--)
		{
			Shift.Legion.ClientApi.Protocol.Store.StoreItem storeItem = list[num];
			int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem.StoreItemId);
			if (storeItem.PurchaseLimitPeriod != 1 && storeItem.PurchaseLimit - purchaseCntAtLimitPeriod == 0)
			{
				list2.Add(storeItem);
				list.RemoveAt(num);
			}
		}
		List<Shift.Legion.ClientApi.Protocol.Store.StoreItem> list3 = new List<Shift.Legion.ClientApi.Protocol.Store.StoreItem>();
		list3.AddRange(list);
		list3.AddRange(list2);
		itemList = list3.ToArray();
		return itemList;
	}

	public List<Shift.Legion.Common.Models.Store.StoreItem> GiftBagSort(List<Shift.Legion.Common.Models.Store.StoreItem> itemList)
	{
		List<Shift.Legion.Common.Models.Store.StoreItem> list = new List<Shift.Legion.Common.Models.Store.StoreItem>();
		list.AddRange(itemList);
		List<Shift.Legion.Common.Models.Store.StoreItem> list2 = new List<Shift.Legion.Common.Models.Store.StoreItem>();
		for (int num = list.Count - 1; num >= 0; num--)
		{
			Shift.Legion.Common.Models.Store.StoreItem storeItem = list[num];
			int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem.StoreItemId);
			if (storeItem.PurchaseLimitPeriod != PurchaseLimitType.NoLimit && storeItem.PurchaseLimit - purchaseCntAtLimitPeriod == 0)
			{
				list2.Add(storeItem);
				list.RemoveAt(num);
			}
		}
		List<Shift.Legion.Common.Models.Store.StoreItem> list3 = new List<Shift.Legion.Common.Models.Store.StoreItem>();
		list3.AddRange(list);
		list3.AddRange(list2);
		return list3;
	}

	public Activity GetBlackMarketerActivity(string uiName)
	{
		List<Activity> activitiesByType = GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.BlackMarket);
		Activity result = null;
		for (int i = 0; i < activitiesByType.Count; i++)
		{
			if (uiName == activitiesByType[i].UiName)
			{
				result = activitiesByType[i];
				break;
			}
		}
		return result;
	}

	public Activity GetSpecialActivity(string uiName, ActivityType actType)
	{
		List<Activity> activitiesByType = GameManagers.Instance.ActivityManager.GetActivitiesByType(actType);
		Activity result = null;
		for (int i = 0; i < activitiesByType.Count; i++)
		{
			if (uiName == activitiesByType[i].UiName)
			{
				result = activitiesByType[i];
				break;
			}
		}
		return result;
	}

	public List<Activity> GetSpecialActivities(List<ActivityType> actTypes)
	{
		List<Activity> list = new List<Activity>();
		for (int i = 0; i < actTypes.Count; i++)
		{
			List<Activity> activitiesByType = GameManagers.Instance.ActivityManager.GetActivitiesByType(actTypes[i]);
			list.AddRange(activitiesByType);
		}
		return list;
	}

	public Activity GetSpringFestivalActivity()
	{
		List<Activity> activitiesByType = GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.HomePageActivity);
		Activity activity = null;
		foreach (Activity item in activitiesByType)
		{
			if (item.UiName == "UI_InstanceZonesPanel")
			{
				activity = item;
				break;
			}
		}
		if (activity == null)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText47") + "：SpringFestival" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 999, arg3: false);
		}
		return activity;
	}

	public Shift.Legion.Common.Models.Store.StoreItem GetStoreItem(Shift.Legion.ClientApi.Protocol.Store.StoreItem incomingStoreItemData)
	{
		Shift.Legion.Common.Models.Store.StoreItem storeItem = new Shift.Legion.Common.Models.Store.StoreItem(GameManagers.Instance, incomingStoreItemData.StoreItemId)
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
		if (!storeItem.IsPassedFilters)
		{
			return null;
		}
		if ((!storeItem.IsKickedOff || storeItem.IsExpired || storeItem.IsSoldOut) && !storeItem.IsResident)
		{
			return null;
		}
		return storeItem;
	}

	public async Task GetDynamicLimitedTimeTotalRecharge(Action action, bool mustUpdateData = false)
	{
		if (LimitedTimeTotalRechargeCurrentActivity != null && !mustUpdateData)
		{
			return;
		}
		GetDynamicLimitedTimeTotalRechargeItemsResponse resp = await GameController.Contexts.Service<INetworkService>().GetDynamicLimitedTimeTotalRechargeItems(-1L);
		if (resp.Result && resp.LTTR_Configs != null && resp.LTTR_Configs.Count > 0)
		{
			ArchiveExtension_DynamicActivity_LTTR.SetLTTRProgress(_model: JsonHelper.ToObject<ArchiveExtension_DynamicActivity_LTTR.Model>(resp.LTTR_Progress), manager: GameManagers.Instance.UserArchiveManager);
			if (LimitedTimeTotalRechargeCurrentActivity != null && LimitedTimeTotalRechargeCurrentActivity.BonusInfos != null)
			{
				action?.Invoke();
				return;
			}
			string config = resp.LTTR_Configs.Values.First();
			LTTR_Model _config = JsonHelper.ToObject<LTTR_Model>(config);
			LimitedTimeTotalRechargeCurrentActivity = new LimitedTimeTotalRechargeActivity(_config);
			if (HotUpdateProcess.Instance.IsRegionOutCN)
			{
				DynamicActivityLocaleInfo localeInfo = DynamicActivityLocaleInfo.DynamicActivityLocaleInfoFromDesc(LimitedTimeTotalRechargeCurrentActivity.Desc);
				if (localeInfo != null)
				{
					LimitedTimeTotalRechargeCurrentActivity.ActivityName = localeInfo.Name;
					LimitedTimeTotalRechargeCurrentActivity.Desc = localeInfo.Desc;
					LimitedTimeTotalRechargeCurrentActivity.ImgUrl = localeInfo.BackgroundImageUrl;
				}
			}
			action?.Invoke();
		}
		else
		{
			LimitedTimeTotalRechargeCurrentActivity = null;
			action?.Invoke();
		}
	}

	public async Task GetSimpleDynamicPromotionActivity(Action action, bool mustUpdateData = false)
	{
		if (SimpleDynamicPromotionActivities != null && !mustUpdateData)
		{
			return;
		}
		GetDynamicDiscountActivityItemsResponse rankSeasonInfoResponse = await GameController.Contexts.Service<INetworkService>().GetDynamicDiscountActivityItems(-1L);
		if (rankSeasonInfoResponse.Result && rankSeasonInfoResponse.DynamicPromotionActivities != null && rankSeasonInfoResponse.DynamicPromotionActivities.Count > 0)
		{
			SimpleDynamicPromotionActivities = rankSeasonInfoResponse.DynamicPromotionActivities;
			if (HotUpdateProcess.Instance.IsRegionOutCN)
			{
				foreach (SimpleDynamicPromotionActivity simpleDynamicPromotionActivity in SimpleDynamicPromotionActivities)
				{
					DynamicActivityLocaleInfo localeInfo = DynamicActivityLocaleInfo.DynamicActivityLocaleInfoFromDesc(simpleDynamicPromotionActivity.Desc);
					if (localeInfo != null)
					{
						simpleDynamicPromotionActivity.ActivityName = localeInfo.Name;
						simpleDynamicPromotionActivity.Desc = localeInfo.Desc;
						simpleDynamicPromotionActivity.PageName = localeInfo.Name;
					}
				}
			}
		}
		else
		{
			SimpleDynamicPromotionActivities = null;
		}
		action?.Invoke();
	}

	public async Task GetSimpleDynamicSigninActivity(Action action, bool mustUpdateData = false)
	{
		if (SimpleDynamicSigninActivities != null && !mustUpdateData)
		{
			return;
		}
		GetDynamicSigninActivityItemsResponse rankSeasonInfoResponse = await GameController.Contexts.Service<INetworkService>().GetDynamicSigninActivityData(-1L);
		if (rankSeasonInfoResponse.Result && rankSeasonInfoResponse.DynamicSigninActivities != null && rankSeasonInfoResponse.DynamicSigninActivities.Count > 0)
		{
			SimpleDynamicSigninActivities = rankSeasonInfoResponse.DynamicSigninActivities;
			if (HotUpdateProcess.Instance.IsRegionOutCN)
			{
				foreach (SimpleDynamicSigninActivity simpleDynamicSigninActivity in SimpleDynamicSigninActivities)
				{
					DynamicActivityLocaleInfo localeInfo = DynamicActivityLocaleInfo.DynamicActivityLocaleInfoFromDesc(simpleDynamicSigninActivity.Desc);
					if (localeInfo != null)
					{
						simpleDynamicSigninActivity.ActivityName = localeInfo.Name;
						simpleDynamicSigninActivity.PageName = localeInfo.Name;
						simpleDynamicSigninActivity.Desc = localeInfo.Desc;
						simpleDynamicSigninActivity.ImgUrl = localeInfo.BackgroundImageUrl;
					}
				}
			}
		}
		else
		{
			SimpleDynamicSigninActivities = null;
		}
		action?.Invoke();
	}

	public async Task GetSimpleDynamicCardPool(Action action, bool mustUpdateData = false)
	{
		if (SimpleDynamicCardPoolActivities != null && !mustUpdateData)
		{
			return;
		}
		GetDynamicCardPoolResponse res = await GameController.Contexts.Service<INetworkService>().GetDynamicCardPool(-1L);
		if (res.Result && res.DynamicCardPoolActivities != null && res.DynamicCardPoolActivities.Count > 0)
		{
			SimpleDynamicCardPoolActivities = res.DynamicCardPoolActivities;
			if (HotUpdateProcess.Instance.IsRegionOutCN)
			{
				foreach (SimpleDynamicCardPoolActivity simpleDynamicCardPoolActivity in SimpleDynamicCardPoolActivities)
				{
					DynamicActivityLocaleInfo localeInfo = DynamicActivityLocaleInfo.DynamicActivityLocaleInfoFromDesc(simpleDynamicCardPoolActivity.Desc);
					if (localeInfo != null)
					{
						simpleDynamicCardPoolActivity.Name = localeInfo.Name;
						simpleDynamicCardPoolActivity.Desc = localeInfo.Desc;
						simpleDynamicCardPoolActivity.ImgUrl = localeInfo.BackgroundImageUrl;
					}
				}
			}
		}
		else
		{
			SimpleDynamicCardPoolActivities = null;
		}
		action?.Invoke();
	}

	public void Stats_Dynamic_SignInParallel(float paid)
	{
		if (paid <= 0f || SimpleDynamicSigninActivities == null)
		{
			return;
		}
		bool flag = false;
		foreach (SimpleDynamicSigninActivity simpleDynamicSigninActivity in SimpleDynamicSigninActivities)
		{
			if (simpleDynamicSigninActivity.RetroactiveSignInAvailable)
			{
				simpleDynamicSigninActivity.AddUseableRetroactiveSignInCount(GameManagers.Instance);
				flag = true;
			}
		}
		if (flag)
		{
			SharedMessenger.Broadcast("ADD_USEABLE_RETROACTIVE_SIGN_IN_COUNT");
		}
	}

	public async Task<TreasureHouseRechargeInfo> GetBlackMarketTreasureData()
	{
		GetTreasureHouseRechargeInfoResponse response = await GameController.Contexts.Service<INetworkService>().GetTreasureHouseRechargeInfo(-1L, BlackMarketTreasureActivityId);
		if (!response.Result)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowMessage($"Get BlackMarketTreasureData Failed: {response.ErrorCode}");
			}
			return null;
		}
		BlackMarketTreasureData = response.TreasureHouseRechargeInfo;
		return BlackMarketTreasureData;
	}

	public async Task<NoviceRechargeData> GetNoviceRechargeData()
	{
		NoviceRechargeResponse response = await GameController.Contexts.Service<INetworkService>().GetNoviceRechargeProgress(-1L, "NoviceRecharge_Demo");
		if (!response.Result)
		{
			ILRequestHelper.ShowMessage($"GetNoviceRechargeProgress Failed: {response.ErrorCode}");
			return null;
		}
		NoviceRechargeData = response.NoviceRechargeData;
		return NoviceRechargeData;
	}

	public async void GetNeutralDungeonDataAsync(Action<NeutralDungeonData> onComplete)
	{
		if (NeutralDungeonData != null)
		{
			onComplete(NeutralDungeonData);
			return;
		}
		IUiService uiService = GameController.Contexts.Service<IUiService>();
		uiService.ShowWaitingAnimation(show: true);
		int changeId = uiService.SetUiNotTouchable(null);
		await GetNeutralDungeonActivity(forceUpdate: true, getAdInfo: true);
		uiService.ShowWaitingAnimation(show: false);
		uiService.SetUiTouchable(changeId);
		onComplete(NeutralDungeonData);
	}

	public async Task<NeutralDungeonData> GetNeutralDungeonActivity(bool forceUpdate = false, bool getAdInfo = false)
	{
		if (NeutralDungeonData != null && !forceUpdate)
		{
			return NeutralDungeonData;
		}
		try
		{
			GetNeutralInstanceResponse res = await GameController.Contexts.Service<INetworkService>().GetNeutralDungeonActivity(-1L, NeutralDungeonActivityId);
			if (res.Result && res.NeutralInstanceActivityData != null)
			{
				if (NeutralDungeonData == null)
				{
					NeutralDungeonData = new NeutralDungeonData();
					NeutralDungeonData.Activity = ActivityManager.Activities[NeutralDungeonActivityId];
				}
				if (res.NeutralInstanceActivityData.TryGetValue("BeginTime", out var curBeginTime))
				{
					DateTimeHelper.TryParse(curBeginTime.ToString(), out NeutralDungeonData.CurBeginTime);
				}
				if (res.NeutralInstanceActivityData.TryGetValue("EndTime", out var curEndTime))
				{
					DateTimeHelper.TryParse(curEndTime.ToString(), out NeutralDungeonData.CurEndTime);
				}
				if (res.NeutralInstanceActivityData.TryGetValue("TicketCount", out var ticketCnt))
				{
					GameManagers.Instance.StockController.SetStock(NeutralDungeonData.Activity.TicketItem, Convert.ToInt32(ticketCnt), StockInContext.AutoFill);
				}
				DateTimeOffset now = DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime());
				if (now.CompareTo(NeutralDungeonData.CurBeginTime) > -1 && now.CompareTo(NeutralDungeonData.CurEndTime) < 1)
				{
					GameManagers.Instance.UserArchiveManager.SetActivityStatus(NeutralDungeonActivityId, ActivityStatus.Enabled);
				}
				else
				{
					GameManagers.Instance.UserArchiveManager.SetActivityStatus(NeutralDungeonActivityId, ActivityStatus.Pending);
				}
			}
			else
			{
				ILRuntimeDebug.LogError("Find No NeutralDungeonActivity");
			}
			if (getAdInfo && NeutralDungeonData != null)
			{
				GetNeutralInstanceAdInfoResponse adInfoRes = await GameController.Contexts.Service<INetworkService>().GetNeutralDungeonActivityAdInfo(-1L);
				if (adInfoRes.Result && adInfoRes.AdInfo != null && adInfoRes.AdInfo.Count > 0)
				{
					Dictionary<string, string> adInfoDict = adInfoRes.AdInfo[0];
					adInfoDict.TryGetValue("ActivityId", out NeutralDungeonData.AdId);
					adInfoDict.TryGetValue("Name", out NeutralDungeonData.AdName);
					adInfoDict.TryGetValue("Desc", out NeutralDungeonData.AdDesc);
					adInfoDict.TryGetValue("ImgUrl", out NeutralDungeonData.AdBgUrl);
					if (HotUpdateProcess.Instance.IsRegionOutCN)
					{
						DynamicActivityLocaleInfo localeInfo = DynamicActivityLocaleInfo.DynamicActivityLocaleInfoFromDesc(NeutralDungeonData.AdDesc);
						if (localeInfo != null)
						{
							NeutralDungeonData.AdName = localeInfo.Name;
							NeutralDungeonData.AdDesc = localeInfo.Desc;
							NeutralDungeonData.AdBgUrl = localeInfo.BackgroundImageUrl;
						}
					}
					if (adInfoDict.TryGetValue("BeginTime", out var adBeginTime))
					{
						DateTimeHelper.TryParse(adBeginTime, out NeutralDungeonData.AdBeginTime);
					}
					if (adInfoDict.TryGetValue("EndTime", out var adEndTime))
					{
						DateTimeHelper.TryParse(adEndTime, out NeutralDungeonData.AdEndTime);
					}
				}
			}
		}
		catch (Exception exception)
		{
			ILRuntimeDebug.LogException(exception);
			throw;
		}
		return NeutralDungeonData;
	}

	public async Task GetWorldBossActivities(Action action, bool mustUpdateData = false)
	{
		if (WorldBossActivities != null && !mustUpdateData)
		{
			return;
		}
		GetDynamicWorldBossResponse res = await GameController.Contexts.Service<INetworkService>().GetDynamicWorldBoss(-1L);
		if (res.Result && res.WorldBossActivities != null && res.WorldBossActivities.Count > 0)
		{
			WorldBossActivities = res.WorldBossActivities;
			if (HotUpdateProcess.Instance.IsRegionOutCN)
			{
				foreach (SimpleDynamicCardPoolActivity worldBossActivity in WorldBossActivities)
				{
					DynamicActivityLocaleInfo localeInfo = DynamicActivityLocaleInfo.DynamicActivityLocaleInfoFromDesc(worldBossActivity.Desc);
					if (localeInfo != null)
					{
						worldBossActivity.Name = localeInfo.Name;
						worldBossActivity.Desc = localeInfo.Desc;
						worldBossActivity.ImgUrl = localeInfo.BackgroundImageUrl;
					}
				}
			}
		}
		else
		{
			WorldBossActivities = null;
		}
		action?.Invoke();
	}

	public async Task GetIslandComeAgainActivities(Action action, bool mustUpdateData = false)
	{
		if (IslandComeAgainActivities != null && !mustUpdateData)
		{
			action?.Invoke();
			return;
		}
		GetDynamicIslandComeAgainResponse res = await GameController.Contexts.Service<INetworkService>().GetDynamicIslandComeAgain(-1L);
		if (res.Result && res.IslandComeAgainActivities != null && res.IslandComeAgainActivities.Count > 0)
		{
			IslandComeAgainActivities = res.IslandComeAgainActivities;
			if (HotUpdateProcess.Instance.IsRegionOutCN)
			{
				foreach (DynamicIslandComeAgainActivity islandComeAgainActivity in IslandComeAgainActivities)
				{
					DynamicActivityLocaleInfo localeInfo = DynamicActivityLocaleInfo.DynamicActivityLocaleInfoFromDesc(islandComeAgainActivity.Desc);
					if (localeInfo != null)
					{
						islandComeAgainActivity.Name = localeInfo.Name;
						islandComeAgainActivity.Desc = localeInfo.Desc;
						islandComeAgainActivity.ImgUrl = localeInfo.BackgroundImageUrl;
					}
				}
			}
		}
		else
		{
			IslandComeAgainActivities = null;
		}
		action?.Invoke();
	}

	public async Task GetPlayerReturnActivity(Action action, bool mustUpdateData = false)
	{
		if (PlayerReturnActivity == null || mustUpdateData)
		{
			GetRecallPlayerDynamicActivityResponse res = await GameController.Contexts.Service<INetworkService>().GetRecallPlayerDynamicActivity();
			if (res.ErrorCode != 0)
			{
				PlayerReturnActivity = null;
				return;
			}
			PlayerReturnActivity = res.PlayerReturnActivity;
			action?.Invoke();
		}
	}

	public async Task GetDynamicSecretTreasuryActivity()
	{
		GetDynamicSecretTreasuryResponse response = await GameController.Contexts.Service<INetworkService>().GetDynamicSecretTreasury();
		if (response.ErrorCode == 0)
		{
			DynamicSecretTreasury = new DynamicSecretTreasuryActivity(response);
		}
	}

	public void GetDynamicSecretTreasuryActivity(Action action)
	{
		ILRequestHelper<GetDynamicSecretTreasuryResponse>.Request((EventContext)null, (Func<Task<GetDynamicSecretTreasuryResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetDynamicSecretTreasury()), (Action<GetDynamicSecretTreasuryResponse>)delegate(GetDynamicSecretTreasuryResponse response)
		{
			if (response.ErrorCode == 0)
			{
				DynamicSecretTreasury = new DynamicSecretTreasuryActivity(response);
				action();
			}
		});
	}

	public SimpleDynamicSigninActivity GetDynamicSigninActivity(string activityId)
	{
		if (SimpleDynamicSigninActivities == null || SimpleDynamicSigninActivities.Count <= 0)
		{
			return null;
		}
		for (int i = 0; i < SimpleDynamicSigninActivities.Count; i++)
		{
			if (SimpleDynamicSigninActivities[i].ActivityId == activityId)
			{
				return SimpleDynamicSigninActivities[i];
			}
		}
		return null;
	}

	public async Task GetDynamicStoreContentConfig()
	{
		GetStoreContentConfigResponse resp = await GameController.Contexts.Service<INetworkService>().GetStoreContentConfig();
		if (resp.ErrorCode == 0)
		{
			Dictionary<string, GDEStoreContentConfigData> configs = resp.StoreContentConfigs.Select(JsonHelper.ToObject<GDEStoreContentConfigData>).ToDictionary((GDEStoreContentConfigData c) => c.Key, (GDEStoreContentConfigData c) => c);
			GDMgr.TryAddDynamicConfig(configs);
		}
	}

	public Activity GetPushGiftBagActivity(string uiName)
	{
		ActivityManager.Activities.TryGetValue(uiName, out var value);
		return value;
	}

	public async Task<bool> GetPushGiftBagData()
	{
		string activityName = (HotUpdateProcess.Instance.IsRegionOutCN ? "Merchandise1_sea" : "Merchandise1");
		curPushGiftBagActivity = GetPushGiftBagActivity(activityName);
		if (curPushGiftBagActivity == null)
		{
			return false;
		}
		GetStoreActivityItemsResponse storeItemsResponse = await GameController.Contexts.Service<INetworkService>().GetStoreActivityItems(curPushGiftBagActivity.ActivityId, curPushGiftBagActivity.ContentPayload(GameManagers.Instance).Keys.First());
		Shift.Legion.ClientApi.Protocol.Store.StoreItem[] additionStoreItems = null;
		if ((GameManagers.Instance.UserArchiveManager.IsNewGuideMode6() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode6() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode7()) && ActivityManager.ShadowDemonGift != null)
		{
			GetShadowDemonActivityResponse shadowDemon = await GameController.Contexts.Service<INetworkService>().GetShadowDemonActivity(ActivityManager.ShadowDemonGift.ActivityId);
			if (shadowDemon.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(shadowDemon.ErrorCode);
			}
			else
			{
				additionStoreItems = shadowDemon.StoreItems;
			}
		}
		if (!storeItemsResponse.Result)
		{
			ILRequestHelper.ShowErrorCode(storeItemsResponse.ErrorCode);
		}
		Shift.Legion.ClientApi.Protocol.Store.StoreItem[] incomingStoreItems = storeItemsResponse.StoreItems;
		if (incomingStoreItems == null && additionStoreItems == null)
		{
			return false;
		}
		pushStoreItems.Clear();
		CopyToPushStoreItem(incomingStoreItems);
		CopyToPushStoreItem(additionStoreItems);
		return true;
	}

	private void CopyToPushStoreItem(Shift.Legion.ClientApi.Protocol.Store.StoreItem[] sourceStoreItems)
	{
		if (sourceStoreItems == null)
		{
			return;
		}
		foreach (Shift.Legion.ClientApi.Protocol.Store.StoreItem storeItem in sourceStoreItems)
		{
			Shift.Legion.Common.Models.Store.StoreItem storeItem2 = new Shift.Legion.Common.Models.Store.StoreItem(GameManagers.Instance, storeItem.StoreItemId)
			{
				Icon = storeItem.Icon,
				Rarity = storeItem.Rarity,
				Category = (StoreCategory)storeItem.Category,
				DoubleAtFirst = storeItem.DoubleAtFirst,
				BonusAtFirst = storeItem.BonusAtFirst,
				Tags = storeItem.Tags,
				ValidTime = storeItem.ValidTime,
				KickOffTimestamp = storeItem.KickOffTimestamp,
				ExpireTimestamp = storeItem.ExpireTimestamp,
				Content = storeItem.Content,
				DisplayContent = storeItem.DisplayContent,
				OriginPrice = storeItem.OriginPrice,
				Price = storeItem.Price,
				Discount = storeItem.Discount,
				PurchaseLimit = storeItem.PurchaseLimit,
				PurchaseLimitPeriod = (PurchaseLimitType)storeItem.PurchaseLimitPeriod,
				IsExpo = storeItem.IsExpo,
				Substitution = storeItem.Substitution,
				IsResident = storeItem.IsResident,
				UserLevelFilter = storeItem.UserLevelFilter,
				DungeonLevelFilter = storeItem.DungeonLevelFilter,
				GameLevelFilter = storeItem.GameLevelFilter,
				OwnedItemFilter = storeItem.OwnedItemFilter,
				PurchaseFilter = storeItem.PurchaseFilter
			};
			if (storeItem2.IsPassedFilters && ((storeItem2.IsKickedOff && !storeItem2.IsExpired && !storeItem2.IsSoldOut) || storeItem2.IsResident) && !storeItem2.IsSoldOut)
			{
				pushStoreItems.Add(storeItem2);
			}
		}
	}

	private void GiftBagSort()
	{
		List<Shift.Legion.Common.Models.Store.StoreItem> list = new List<Shift.Legion.Common.Models.Store.StoreItem>();
		list.AddRange(pushStoreItems);
		List<Shift.Legion.Common.Models.Store.StoreItem> list2 = new List<Shift.Legion.Common.Models.Store.StoreItem>();
		for (int num = list.Count - 1; num >= 0; num--)
		{
			Shift.Legion.Common.Models.Store.StoreItem storeItem = list[num];
			int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem.StoreItemId);
			if (storeItem.PurchaseLimit - purchaseCntAtLimitPeriod == 0)
			{
				list2.Add(storeItem);
				list.RemoveAt(num);
			}
		}
		IOrderedEnumerable<Shift.Legion.Common.Models.Store.StoreItem> source = from result in list
			select (result) into time
			orderby Mathf.Abs(time.ExpireTimestamp - (int)GameController.Instance.GetServerTime()) descending
			select time;
		source = source.OrderByDescending((Shift.Legion.Common.Models.Store.StoreItem discount) => discount.Discount);
		source = source.ThenByDescending((Shift.Legion.Common.Models.Store.StoreItem purchaseLimit) => (int)purchaseLimit.PurchaseLimitPeriod);
		pushStoreItems.Clear();
		pushStoreItems.AddRange(list);
		pushStoreItems.AddRange(list2);
	}

	public async Task<bool> GetPushGiftBagAndSort()
	{
		bool _result = await GetPushGiftBagData();
		for (int i = 0; i < pushStoreItems.Count; i++)
		{
		}
		NewPushStoreItem = null;
		if (curPushStoreItemsId.Count <= 0)
		{
			for (int j = 0; j < pushStoreItems.Count; j++)
			{
				curPushStoreItemsId.Add(pushStoreItems[j].StoreItemId);
				if (j == pushStoreItems.Count - 1)
				{
					NewPushStoreItem = pushStoreItems.Last();
				}
			}
		}
		else
		{
			List<string> _pushStoreItemsId = new List<string>();
			for (int k = 0; k < pushStoreItems.Count; k++)
			{
				_pushStoreItemsId.Add(pushStoreItems[k].StoreItemId);
			}
			for (int l = 0; l < _pushStoreItemsId.Count; l++)
			{
				if (!curPushStoreItemsId.Contains(_pushStoreItemsId[l]))
				{
					NewPushStoreItem = pushStoreItems[l];
					break;
				}
				if (l == _pushStoreItemsId.Count - 1)
				{
					NewPushStoreItem = pushStoreItems.Last();
				}
			}
			curPushStoreItemsId.Clear();
			curPushStoreItemsId.AddRange(_pushStoreItemsId);
		}
		return _result;
	}

	public string CutItemIdPrefix(string itemId, out string prefix)
	{
		prefix = "";
		if (itemId.Contains("."))
		{
			prefix = itemId;
			itemId = itemId.Split('.')[1];
			prefix = prefix.Split('.')[0];
			if (itemId.Contains("$"))
			{
				itemId = itemId.Substring(1);
			}
		}
		return itemId;
	}

	public string GetItemIdPrefix(string itemId, char split)
	{
		return (!itemId.Contains(split)) ? string.Empty : itemId.Split(split)[0];
	}

	private string GetItemIconSuffix(string icon, char split)
	{
		return (!icon.Contains(split)) ? string.Empty : icon.Split(split)[1];
	}

	private string GetTechnologyIcon(string itemId)
	{
		string result = itemId;
		if (TechnologyManager.DoomTechnologies.Contains(itemId))
		{
			result = TechnologyManager.DoomArtifactKey;
		}
		else if (TechnologyManager.SlaveryTechnologies.Contains(itemId))
		{
			result = TechnologyManager.SlaveryArtifactKey;
		}
		else if (TechnologyManager.DominionTechnologies.Contains(itemId))
		{
			result = TechnologyManager.DominionArtifactKey;
		}
		return result;
	}

	public void SetItemIconAndFrame(GLoader loader, string itemId, List<string> textureList = null, string frame = "", bool frameVisible = true, float PieceScale = 1f, Bonus _bonus = null, bool userExpFrameVisible = false)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ba: Unknown result type (might be due to invalid IL or missing references)
		string prefix = "";
		((GObject)loader).scale = Vector2.one;
		itemId = CutItemIdPrefix(itemId, out prefix);
		ItemIdReplace(ref itemId);
		if (!string.IsNullOrWhiteSpace(prefix))
		{
			if (TechnologyManager.TechnologyKeys.Contains(itemId))
			{
				loader.url = "ui://PublicResources/" + GetTechnologyIcon(itemId);
			}
			else
			{
				if ((!(prefix == "Unlock") && !(prefix == "PotentialLevel")) || itemId[0] != 'S')
				{
					return;
				}
				loader.url = "ui://kt6rg65of4sztic";
				if (loader.component != null)
				{
					Soldier soldier = GameManagers.Instance.SoldierManager.Get(itemId);
					GButton asButton = ((GObject)loader.component).asButton;
					((GComponent)((GComponent)asButton).GetChild("racePicture").asButton).GetController("Type").selectedIndex = GetRaceIcon(soldier.Faction);
					GObject child = ((GComponent)asButton).GetChild("icon");
					string iconPath = UiHelper.GetIconPath(itemId);
					child.asLoader.url = "ui://PublicResources/" + iconPath;
					string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
					if (_bonus != null)
					{
						iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(_bonus.Qty);
					}
					((GComponent)asButton).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
					UiHelper.LoadSoldierIconFrameMaterial(((GComponent)asButton).GetChild("iconFrame").asLoader, soldier.PotentialLevel);
					SetAlightSoulStoneForSoldierIcon(((GComponent)asButton).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, new List<int>());
					if (prefix == "Unlock")
					{
						((GComponent)asButton).GetController("RedPointController").selectedIndex = 0;
					}
					else if (prefix == "PotentialLevel")
					{
						((GComponent)asButton).GetController("RedPointController").selectedIndex = 1;
					}
				}
			}
			return;
		}
		if (TechnologyManager.TechnologyKeys.Contains(itemId))
		{
			loader.url = "ui://PublicResources/" + GetTechnologyIcon(itemId);
			return;
		}
		if (itemId[0] == 'S' && SchemaIndexHelper.GetSchemaById(itemId) == "Soldier")
		{
			Soldier soldier2 = GameManagers.Instance.SoldierManager.Get(itemId);
			itemId = soldier2.ItemId;
		}
		if (itemId == "UserExp" && !userExpFrameVisible)
		{
			loader.url = "ui://PublicResources/icon_exp";
			return;
		}
		int num = Shift.Legion.Common.Models.Item.ItemType(itemId);
		int num2 = ((num == 2) ? GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(itemId) : Shift.Legion.Common.Models.Item.Level(GameManagers.Instance, itemId));
		loader.fill = (FillType)5;
		loader.verticalAlign = (VertAlignType)0;
		switch (num)
		{
		case 8:
			loader.url = "ui://kt6rg65os0m4tbx";
			if (loader.component != null)
			{
				GButton asButton3 = ((GObject)loader.component).asButton;
				GObject child2 = ((GComponent)asButton3).GetChild("icon");
				string iconPath2 = UiHelper.GetIconPath(itemId);
				child2.asCom.GetChild("icon").asLoader.url = "ui://PublicResources/" + iconPath2;
				string text = "kuang_square_lv1";
				((GComponent)asButton3).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + text;
				((GComponent)asButton3).GetChild("numNote").visible = false;
				((GComponent)asButton3).GetChild("num").text = "";
				((GComponent)asButton3).GetChild("title").text = "";
				((GComponent)asButton3).GetChild("title_Max").text = "";
			}
			return;
		case 10:
			loader.url = "ui://kt6rg65ovv0ue7";
			if (loader.component != null)
			{
				GButton asButton4 = ((GObject)loader.component).asButton;
				((GComponent)asButton4).GetChild("removeBack").visible = false;
				((GComponent)asButton4).GetChild("lvFrame").visible = false;
				((GComponent)asButton4).GetChild("assemblyNote").visible = false;
				((GComponent)asButton4).GetChild("numNote").visible = false;
				((GComponent)asButton4).GetChild("NumBack").visible = false;
				((GComponent)asButton4).GetChild("removeNote").visible = false;
				((GComponent)asButton4).GetChild("lv").visible = false;
				((GComponent)asButton4).GetChild("num").visible = false;
				((GComponent)asButton4).GetChild("classListCopy").visible = false;
				((GComponent)asButton4).GetChild("classList").visible = false;
				((GComponent)asButton4).GetChild("title").visible = false;
				((GComponent)asButton4).GetChild("removeText").visible = false;
				((GComponent)asButton4).GetChild("occupation").visible = false;
				((GComponent)asButton4).GetChild("PotentialIcon").visible = false;
				Soldier soldier3 = GameManagers.Instance.SoldierManager.Get("S" + GDMgr.Get<GDEItemData>(itemId).Icon.Substring(3));
				((GComponent)((GComponent)asButton4).GetChild("racePicture").asButton).GetController("Type").selectedIndex = GetRaceIcon(soldier3.Faction);
				GObject child3 = ((GComponent)asButton4).GetChild("icon");
				string iconPath3 = UiHelper.GetIconPath(itemId);
				child3.asLoader.url = "ui://PublicResources/" + iconPath3;
				int level = 0;
				List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, itemId);
				if (list[0].PayloadDictionary.TryGetValue("PotentialLevel", out var value))
				{
					level = int.Parse(value.ToString());
				}
				string iconFrameBorderSoldier2 = UiHelper.GetIconFrameBorderSoldier(level);
				((GComponent)asButton4).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier2;
				UiHelper.LoadSoldierIconFrameMaterial(((GComponent)asButton4).GetChild("iconFrame").asLoader, level);
				SetAlightSoulStoneForSoldierIcon(((GComponent)asButton4).GetChild("SoulStoneLevel").asCom, level, new List<int>());
			}
			return;
		case 3:
			loader.url = "ui://kt6rg65obunlt85";
			if (loader.component != null)
			{
				GButton asButton2 = ((GObject)loader.component).asButton;
				((GObject)loader).scale = new Vector2(PieceScale, PieceScale);
				SetSoulStoneIconAndFrame(asButton2, itemId, textureList);
			}
			return;
		}
		loader.url = "ui://kt6rg65ot1tzf9";
		if (loader.component == null)
		{
			return;
		}
		GButton asButton5 = ((GObject)loader.component).asButton;
		string text2 = UiHelper.GetIconPath(itemId);
		string text3 = "PublicResources";
		if (num == 17 || num == 20)
		{
			((GComponent)asButton5).GetChild("icon").asLoader.LoadArmsIcon(text2);
		}
		else if (num == 27 || (GetItemIdPrefix(itemId, '_') == "BlueprintBox" && GetItemIconSuffix(text2, '_') == "Blue"))
		{
			((GComponent)asButton5).GetChild("icon").asLoader.LoadBlueprintIcon(text2);
		}
		else
		{
			if (num == 16)
			{
				text3 = "PublicResourcesRGB";
			}
			if (itemId == "UserExp")
			{
				text2 = "icon_exp";
			}
			if (GetItemIdPrefix(itemId, '_') == "BlueprintBox" && GetItemIconSuffix(text2, '_') == "Blue")
			{
				text3 = "PublicResourcesRGB";
			}
			((GComponent)asButton5).GetChild("icon").asLoader.url = "ui://" + text3 + "/" + text2;
		}
		if (!frameVisible)
		{
			return;
		}
		string text4 = "";
		if (string.IsNullOrWhiteSpace(frame))
		{
			num2 = ((num2 > 0) ? num2 : Shift.Legion.Common.Models.Item.Rarity(itemId));
			string schemaById = SchemaIndexHelper.GetSchemaById(itemId);
			if (schemaById == "Technology")
			{
				num2 = 5;
			}
			if (num == 105)
			{
				num2 += 2;
			}
			text4 = UiHelper.GetIconFrameBorder(2, num2);
		}
		else
		{
			text4 = frame;
		}
		((GComponent)asButton5).GetChild("frame").asLoader.url = "ui://PublicResources/" + text4;
	}

	public void ItemIdReplace(ref string oldItemId)
	{
		string text = oldItemId;
		string text2 = text;
		if (text2 == "ContributionPoint")
		{
			oldItemId = "I65001";
		}
	}

	public void BuildingFocus(GameObject building, float duration, bool needCloseUi = true, bool canBreak = false)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		if (canBreak)
		{
			return;
		}
		if (needCloseUi)
		{
			GameController.Contexts.Service<IUiService>().CloseAll();
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_MainCity.Name, null);
		}
		if (!needCloseUi)
		{
			return;
		}
		if (!LimitCameraInMainCity())
		{
			Vector3 buildingPos = building.transform.position;
			float currentX = GameController.Contexts.Service<ICameraService>().Position.x;
			ScriptApi.CreateTimer(0.5f, delegate
			{
				SetMainCityCameraMoveInfo(currentX, buildingPos.x, duration);
			});
		}
	}

	public void BuildingFocusClick(GameObject building, float duration)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		if (!LimitCameraInMainCity())
		{
			Vector3 position = building.transform.position;
			float x = GameController.Contexts.Service<ICameraService>().Position.x;
			SetMainCityCameraMoveInfo(x, position.x, duration);
		}
	}

	public void SetMainCityCameraMoveInfo(float currentX, float endX, float duration)
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		float _cameraRangeX = Instance.difference;
		((GObject)GRoot.inst).touchable = false;
		TweenerCore<float, float, FloatOptions> tweener = DOTween.To((DOGetter<float>)(() => currentX), (DOSetter<float>)delegate(float x)
		{
			currentX = x;
		}, endX, duration);
		TweenerCore<float, float, FloatOptions> obj = tweener;
		object obj2 = _003C_003Ec._003C_003E9__241_2;
		if (obj2 == null)
		{
			TweenCallback val = delegate
			{
				((GObject)GRoot.inst).touchable = true;
			};
			_003C_003Ec._003C_003E9__241_2 = val;
			obj2 = (object)val;
		}
		TweenSettingsExtensions.OnComplete<TweenerCore<float, float, FloatOptions>>(obj, (TweenCallback)obj2);
		TweenSettingsExtensions.OnUpdate<TweenerCore<float, float, FloatOptions>>(tweener, (TweenCallback)delegate
		{
			CameraMove(currentX, 0f, _cameraRangeX);
			ChangeMaincityTurnBtnStatus();
			if (Math.Abs(endX - currentX) < float.Epsilon)
			{
				TweenExtensions.Complete((Tween)(object)tweener, false);
			}
		});
	}

	public void CameraMove(float posX, float posZ, float _cameraRangeX)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		Vector3 position = GameController.Contexts.Service<ICameraService>().Position;
		if (posX < _cameraRangeX && posX > 0f - _cameraRangeX)
		{
			Vector3 val = default(Vector3);
			((Vector3)(ref val))._002Ector(posX, position.y, position.z);
			GameController.Contexts.Service<ICameraService>().SetPosition(Vector3.op_Implicit(Vector3.Slerp(Vector3.op_Implicit(position), val, 1f)));
		}
		else if (posX > _cameraRangeX)
		{
			GameController.Contexts.Service<ICameraService>().SwitchToScene("MainCity.Right");
		}
		else if (posX < 0f - _cameraRangeX)
		{
			GameController.Contexts.Service<ICameraService>().SwitchToScene("MainCity.Left");
		}
		BuildingIndicatorStatusUpdate();
	}

	public void ChangeMaincityTurnBtnStatus()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		if (MaincityUi == null)
		{
			return;
		}
		Vector3 position = GameController.Contexts.Service<ICameraService>().Position;
		if (position.x - difference >= -0.25f)
		{
			MaincityUi.SetTurnPageBtnPos(MaincityUi.TurnPageLeftBtn, -12f, delegate
			{
				((GObject)MaincityUi.TurnPageRightBtn).visible = false;
				((GObject)MaincityUi.TurnPageLeftBtn).visible = true;
			});
			if (((GObject)MaincityUi.TurnPageLeftBtn).x < 65f)
			{
				((GObject)MaincityUi.TurnPageLeftBtn).x = 65f;
			}
		}
		else if (position.x - (0f - difference) < 0.25f)
		{
			MaincityUi.SetTurnPageBtnPos(MaincityUi.TurnPageRightBtn, 12f, delegate
			{
				((GObject)MaincityUi.TurnPageLeftBtn).visible = false;
				((GObject)MaincityUi.TurnPageRightBtn).visible = true;
			});
			if (((GObject)MaincityUi.TurnPageRightBtn).x > ((GObject)GRoot.inst).width - 65f)
			{
				((GObject)MaincityUi.TurnPageRightBtn).x = ((GObject)GRoot.inst).width - 65f;
			}
		}
		else
		{
			((GObject)MaincityUi.TurnPageLeftBtn).visible = false;
			((GObject)MaincityUi.TurnPageRightBtn).visible = false;
		}
	}

	public void ShowNewOfflineBonuses()
	{
		GameStateContext gameState = GameController.Contexts.gameState;
		if (gameState.hasOfflineSeconds && gameState.hasOfflineBonuses)
		{
			int value = gameState.offlineSeconds.value;
			List<Bonus> value2 = gameState.offlineBonuses.value;
			gameState.RemoveOfflineSeconds();
			gameState.RemoveOfflineBonuses();
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ShowOfflineEarnings.Name, new Dictionary<string, object>
			{
				{ "Bonus", value2 },
				{ "Time", value }
			});
		}
	}

	public IEnumerator UpdateStageCameraFrames(float delay)
	{
		StageCamera.clearFlags = (CameraClearFlags)3;
		yield return (object)new WaitForSeconds(delay);
		StageCamera.clearFlags = (CameraClearFlags)3;
	}

	public void OpenExclamationMarkPanel(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, object> parameters = (Dictionary<string, object>)((GObject)context.sender).data;
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_ExclamationMarkPanel.Name, parameters);
		context.StopPropagation();
	}

	public string GetGoodsPurchaseLimitTitle(PurchaseLimitType purchaseLimitType)
	{
		string desc = LanguagesManager.GetDesc("CsharpCodeZhTcText27");
		switch (purchaseLimitType)
		{
		case PurchaseLimitType.Daily:
			desc = LanguagesManager.GetDesc("CsharpCodeZhTcText28");
			break;
		case PurchaseLimitType.Weekly:
			desc = LanguagesManager.GetDesc("CsharpCodeZhTcText29");
			break;
		case PurchaseLimitType.Monthly:
			desc = LanguagesManager.GetDesc("CsharpCodeZhTcText30");
			break;
		}
		return desc;
	}

	public bool LimitCameraInMainCity()
	{
		return !GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1001").Contains("P110");
	}

	public void AddNumFloatingForCouponBtn(UI_ProductionNumFloating NumFloating, GComponent addCouponBtn, int value, int order = 1, bool dispose = false)
	{
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		if (value < 0)
		{
			((GObject)NumFloating).Dispose();
			return;
		}
		string text = value.ToString();
		if (value >= 0)
		{
			text = "+" + text;
		}
		((GObject)NumFloating.Title).text = text;
		((GObject)NumFloating.Title).data = value;
		TextFormat textFormat = NumFloating.Title.textFormat;
		textFormat.size = 40;
		textFormat.font = "SourceHanSansCN-Heavy";
		NumFloating.Title.textFormat = textFormat;
		addCouponBtn.AddChild((GObject)(object)NumFloating);
		((GObject)NumFloating).sortingOrder = 1;
		((GObject)NumFloating).alpha = 0f;
		((GObject)NumFloating).SetPivot(1f, 1f, true);
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(addCouponBtn.GetChild("num").x + addCouponBtn.GetChild("num").width + ((GObject)NumFloating).width / 2f + 25f, addCouponBtn.GetChild("num").y + addCouponBtn.GetChild("num").height);
		((GObject)NumFloating).SetXY(val.x, val.y);
		NumFloating.DisAppear.timeScale = 0.4f;
		PlayCompleteCallback val2 = default(PlayCompleteCallback);
		((GComponent)(object)NumFloating).SetTimeout((float)(addCouponBtn.numChildren - 5) * 0.25f).OnComplete((GTweenCallback)delegate
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_004c: Expected O, but got Unknown
			if (!((GObject)NumFloating).isDisposed)
			{
				((GObject)NumFloating).alpha = 1f;
				Transition disAppear = NumFloating.DisAppear;
				PlayCompleteCallback obj = val2;
				if (obj == null)
				{
					PlayCompleteCallback val3 = delegate
					{
						if (!((GObject)addCouponBtn).isDisposed)
						{
							addCouponBtn.RemoveChild((GObject)(object)NumFloating, dispose);
						}
					};
					PlayCompleteCallback val4 = val3;
					val2 = val3;
					obj = val4;
				}
				disAppear.Play(obj);
			}
		});
	}

	public List<string> GetItemBuildingSource(string itemId)
	{
		GDEProductData productByItemId = GameManagers.Instance.BuildingManager.GetProductByItemId(itemId);
		if (productByItemId != null)
		{
			GDEProductData gDEProductData = BuildingManager.Products[productByItemId.Key];
			return gDEProductData.BuildType;
		}
		return null;
	}

	public void ItemTip(string itemId, int order, bool noCheckBtn = false, bool reserveRes = false, IUiController parent = null, bool isPack = false, Dictionary<string, object> legendItemDialogParams = null, int gvgStock = 0, Action onJumpAction = null)
	{
		ItemIdReplace(ref itemId);
		Dictionary<string, object> dictionary = new Dictionary<string, object> { { "ItemId", itemId } };
		ItemType itemType = (ItemType)Shift.Legion.Common.Models.Item.ItemType(itemId);
		switch (itemType)
		{
		case ItemType.BlackMarketLegendItem:
		{
			ItemEffectIdentifiedLegendItem itemEffectIdentifiedLegendItem = JsonHelper.ToObject<ItemEffectIdentifiedLegendItem>(GDMgr.Get<GDEItemData>(itemId).Effect);
			LegendItemsHelper.BlackMarketLegendItem itemData = new LegendItemsHelper.BlackMarketLegendItem(itemEffectIdentifiedLegendItem.ItemData, itemEffectIdentifiedLegendItem.LegendItemId, itemEffectIdentifiedLegendItem.Score);
			UI_LegendItemInfoDialog.DialogInfo = new LegendItemInfoDialogInfo(null, "", -1, 3, itemData);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog.Name, legendItemDialogParams);
			return;
		}
		case ItemType.Souvenir:
			UI_main_Souvenir.OpenPanel(itemId);
			return;
		}
		string key = "P" + itemId.Substring(1);
		string name = UI_MaterialIntroductionPanel.Name;
		dictionary.Add("Order", order);
		if (parent != null)
		{
			dictionary.Add("Parent", parent);
		}
		if (!BuildingManager.Products.ContainsKey(key) || noCheckBtn)
		{
			dictionary.Add("HideCheckBtn", true);
		}
		if (reserveRes)
		{
			dictionary.Add("ReserveResource", true);
		}
		if (itemType == ItemType.CommonTimeMachine || itemType == ItemType.MoneyTimeMachine || itemType == ItemType.RecycleTimeMachine)
		{
			dictionary.Add("TimeMachine", true);
		}
		if (onJumpAction != null)
		{
			dictionary.Add("OnJumpAction", onJumpAction);
		}
		if (isPack)
		{
			dictionary.Add("Pack", true);
			if (itemType == ItemType.LegendItemChest)
			{
				name = UI_IdentificationPanel.Name;
			}
		}
		if (gvgStock > 0)
		{
			dictionary.Add("GvGItemStock", gvgStock);
		}
		if (itemType == ItemType.SoulKey)
		{
			GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
			SoulKeyItemEffect soulKeyItemEffect = JsonHelper.ToObject<SoulKeyItemEffect>(gDEItemData.Effect);
			int soldierPotentialLevel = GameManagers.Instance.UserArchiveManager.GetSoldierPotentialLevel(soulKeyItemEffect.SoldierId);
			name = UI_MaterialIntroductionPanel.Name;
			if (soldierPotentialLevel >= soulKeyItemEffect.PotentialLevel)
			{
				if (!dictionary.ContainsKey("Pack"))
				{
					dictionary.Add("Pack", true);
				}
			}
			else if (dictionary.ContainsKey("Pack"))
			{
				dictionary.Remove("Pack");
			}
		}
		if ((itemType == ItemType.GvGStoreChest || itemType == ItemType.GvGStoreSelectChest) && isPack && dictionary.ContainsKey("HideCheckBtn"))
		{
			dictionary.Remove("HideCheckBtn");
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(name, dictionary);
	}

	public static bool TryShowOptionalBlueprint(string itemId, bool isPreview = true)
	{
		if (Shift.Legion.Common.Models.Item.OptionalBlueprintSet == null)
		{
			Shift.Legion.Common.Models.Item.OptionalBlueprintSet = "OptionalBlueprintSet".ToConfiguration<List<string>>();
		}
		if (Shift.Legion.Common.Models.Item.OptionalBlueprintSet.Contains(itemId))
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["IsPreview"] = isPreview;
			dictionary["ClickItemId"] = itemId;
			string name = UI_main_OptionalBlueprintPopup.Name;
			GameController.Contexts.Service<IUiService>().OpenPanel(name, dictionary);
			return true;
		}
		return false;
	}

	public static bool TryShowSpecialBlueprint(string itemId)
	{
		if (itemId == "I31108")
		{
			string name = UI_main_SelectBlueprintPopup.Name;
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			GameController.Contexts.Service<IUiService>().OpenPanel(name, parameters);
			return true;
		}
		return false;
	}

	public string GetStockString(string itemId, int currentGvGStock = 0)
	{
		int num = Shift.Legion.Common.Models.Item.ItemType(itemId);
		if (itemId == "UserExp")
		{
			return string.Empty;
		}
		if (num == 9 || num == 10 || num == 12)
		{
			return string.Empty;
		}
		string desc = LanguagesManager.GetDesc("CsharpCodeZhTcText48");
		if (num == 31)
		{
			return desc + ":" + currentGvGStock.ShortNumberFormat();
		}
		string result = desc + ":" + GameManagers.Instance.StockController.GetStock(itemId).ShortNumberFormat();
		switch (num)
		{
		case 8:
		{
			Soldier soldier = GameManagers.Instance.SoldierManager.Get("S" + itemId.Substring(3));
			result = desc + ":" + GameManagers.Instance.StockController.GetStock(soldier.Id).ShortNumberFormat();
			break;
		}
		case 3:
			result = desc + ":" + Instance.GetSoulStoneNum(itemId).ShortNumberFormat();
			break;
		}
		return result;
	}

	public KeyValuePair<string, float> GetPriceItemId(Shift.Legion.Common.Models.Store.StoreItem _storeItem)
	{
		if (!_storeItem.CanRedeem(null, out var costDict))
		{
			Dictionary<string, float> dict = _storeItem.Price.Last();
			return dict.First();
		}
		Dictionary<string, float> dict2 = costDict;
		return dict2.First();
	}

	public void GetCurrencySymbol(string currency, GLoader loader, List<string> textureList)
	{
		loader.url = "ui://PublicResources/" + currency;
	}

	public void MaincityUiAddBuildingIndicator(string buildingType)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		if (MaincityUi != null && !buildingIndicators.ContainsKey(buildingType))
		{
			UI_buildingDirectionIndicator indicator = UI_buildingDirectionIndicator.CreateInstance();
			((GComponent)indicator).GetChild("icon").asLoader.url = "ui://PublicResources/Building" + buildingType;
			((GObject)indicator).TweenFade(((GObject)indicator).alpha, 1f).OnComplete((GTweenCallback)delegate
			{
				((GComponent)indicator).GetTransition("shakeSelf").Play();
			});
			if (!Timers.inst.Exists(new TimerCallback(BuildingIndicatorsShake)))
			{
				Timers.inst.Add(15f, 0, new TimerCallback(BuildingIndicatorsShake));
			}
			((GObject)indicator).data = buildingType;
			((GObject)indicator).onClick.Add(new EventCallback1(FixBuildingPositionByIndicator));
			((GObject)indicator).visible = false;
			((GComponent)indicator).opaque = true;
			((GComponent)MaincityUi).AddChild((GObject)(object)indicator);
			buildingIndicators.Add(buildingType, new tKeyValue<UI_buildingDirectionIndicator, int>(indicator, 0));
			BuildingIndicatorStatusUpdate(init: true, buildingType);
		}
	}

	private void BuildingIndicatorsShake(object paramter)
	{
		int num = 0;
		foreach (KeyValuePair<string, tKeyValue<UI_buildingDirectionIndicator, int>> buildingIndicator in buildingIndicators)
		{
			int num2 = Random.Range(0, buildingIndicators.Count);
			if (num == num2)
			{
				UI_buildingDirectionIndicator key = buildingIndicator.Value.Key;
				int num3 = Random.Range(0, 11);
				if (num3 % 5 == 0)
				{
					continue;
				}
				if (num3 % 2 == 0)
				{
					((GComponent)key).GetTransition("shakeSelf").Play();
				}
				else
				{
					((GComponent)key).GetTransition("zoomSelf").Play();
				}
			}
			num++;
		}
	}

	public void MaincityUiRemoveBuildingIndicator(string buildingType, int level)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		UI_buildingDirectionIndicator key = buildingIndicators[buildingType].Key;
		buildingIndicators.Remove(buildingType);
		if (buildingIndicators.Count == 0 && Timers.inst.Exists(new TimerCallback(BuildingIndicatorsShake)))
		{
			Timers.inst.Remove(new TimerCallback(BuildingIndicatorsShake));
		}
		if (key != null && MaincityUi != null)
		{
			((GComponent)MaincityUi).RemoveChild((GObject)(object)key);
			((GObject)key).onClick.Remove(new EventCallback1(FixBuildingPositionByIndicator));
			((GObject)key).Dispose();
		}
	}

	public void FixBuildingPositionByIndicator(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string type = ((GObject)context.sender).data.ToString();
		Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType(type);
		BuildingFocusClick(buildingByType.GameObject, 1f);
	}

	public void BuildingIndicatorStatusUpdate(bool init = false, string buildingType = null)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0410: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_044e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0453: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		ArrayList arrayList = new ArrayList();
		List<string> list = new List<string>();
		List<float> list2 = new List<float>();
		Vector2 val5 = default(Vector2);
		foreach (KeyValuePair<string, tKeyValue<UI_buildingDirectionIndicator, int>> buildingIndicator in buildingIndicators)
		{
			Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType(buildingIndicator.Key);
			if (!string.IsNullOrWhiteSpace(buildingType) && buildingByType.BuildingType != buildingType)
			{
				continue;
			}
			Vector3 position = buildingByType.GameObject.transform.position;
			float x = GameController.Contexts.Service<ICameraService>().Position.x;
			BoxCollider component = buildingByType.GameObject.GetComponent<BoxCollider>();
			Vector3 val = buildingByType.GameObject.transform.TransformPoint(component.center);
			Vector2 val2 = Vector2.op_Implicit(GameController.Contexts.Service<ICameraService>().WorldToScreenPoint(Vector3.op_Implicit(val)));
			val2.y = (float)Screen.height - val2.y;
			Vector2 val3 = ((MaincityUi != null) ? ((GObject)MaincityUi).GlobalToLocal(Vector2.op_Implicit(val2)) : ((GObject)GRoot.inst).GlobalToLocal(Vector2.op_Implicit(val2)));
			UI_buildingDirectionIndicator key = buildingIndicator.Value.Key;
			Vector2 val4 = val3 - ((GObject)key).xy;
			((Vector2)(ref val5))._002Ector(-1f, 0f);
			float rotation = Vector2.SignedAngle(val5, val4);
			((GObject)((GComponent)key).GetChild("back").asImage).rotation = rotation;
			int num = 0;
			float num2 = 1f;
			if (buildingByType.BuildingType == "10")
			{
				num2 = 0.5333f;
			}
			else if (buildingByType.BuildingType == "11")
			{
				num2 = 0.62f;
			}
			if (position.x < x)
			{
				num = 0;
				if (val.x + component.size.x / 2f * num2 > x - cameraFrameX / 2f)
				{
					((GObject)key).visible = false;
				}
				else
				{
					((GObject)key).visible = true;
				}
			}
			else
			{
				num = 1;
				if (val.x - component.size.x / 2f * num2 < x + cameraFrameX / 2f)
				{
					((GObject)key).visible = false;
				}
				else
				{
					((GObject)key).visible = true;
				}
			}
			if (num != buildingIndicator.Value.Value)
			{
				arrayList.Add(buildingIndicators[buildingIndicator.Key].Key);
				list.Add(buildingByType.BuildingType);
				list2.Add(val3.y);
			}
		}
		for (int i = 0; i < arrayList.Count; i++)
		{
			switch (buildingIndicators[list[i]].Value)
			{
			case 0:
				buildingIndicators[list[i]] = new tKeyValue<UI_buildingDirectionIndicator, int>((UI_buildingDirectionIndicator)arrayList[i], 1);
				break;
			case 1:
				buildingIndicators[list[i]] = new tKeyValue<UI_buildingDirectionIndicator, int>((UI_buildingDirectionIndicator)arrayList[i], 0);
				break;
			}
			SetindicatorTransform(list[i], list2[i]);
		}
		if (!init)
		{
			return;
		}
		foreach (KeyValuePair<string, tKeyValue<UI_buildingDirectionIndicator, int>> buildingIndicator2 in buildingIndicators)
		{
			Building buildingByType2 = GameManagers.Instance.BuildingManager.GetBuildingByType(buildingIndicator2.Key);
			if (string.IsNullOrWhiteSpace(buildingType) || !(buildingByType2.BuildingType != buildingType))
			{
				BoxCollider component2 = buildingByType2.GameObject.GetComponent<BoxCollider>();
				Vector3 val6 = buildingByType2.GameObject.transform.TransformPoint(component2.center);
				Vector3 val7 = Camera.main.WorldToScreenPoint(val6);
				val7.y = (float)Screen.height - val7.y;
				Vector2 val8 = ((MaincityUi != null) ? ((GObject)MaincityUi).GlobalToLocal(Vector2.op_Implicit(val7)) : ((GObject)GRoot.inst).GlobalToLocal(Vector2.op_Implicit(val7)));
				SetindicatorTransform(buildingIndicator2.Key, val8.y);
			}
		}
	}

	private void SetindicatorTransform(string buildingType, float localPosY)
	{
		int value = buildingIndicators[buildingType].Value;
		UI_buildingDirectionIndicator key = buildingIndicators[buildingType].Key;
		if (value == 0)
		{
			((GObject)key).SetXY(80f, localPosY);
			float num = SetindicatorY(buildingType, localPosY, 0);
			if (num > 0f)
			{
				((GObject)key).SetXY(((GObject)key).x, num);
			}
			else
			{
				((GObject)key).SetXY(((GObject)key).x, localPosY);
			}
		}
		else
		{
			((GObject)key).SetXY(((GObject)MaincityUi).width - 5f - 45f, localPosY);
			float num2 = SetindicatorY(buildingType, localPosY, 0);
			if (num2 > 0f)
			{
				((GObject)key).SetXY(((GObject)key).x, num2);
			}
			else
			{
				((GObject)key).SetXY(((GObject)key).x, localPosY);
			}
		}
	}

	public void BuildingIndicatorInit()
	{
		Instance.buildingIndicators.Clear();
		foreach (Building value in GameManagers.Instance.BuildingManager.Buildings.Values)
		{
			if (!((Object)(object)value.GameObject == (Object)null) && !buildingIndicators.ContainsKey(value.BuildingType) && value.Status == BuildingStatus.Ready)
			{
				MaincityUiAddBuildingIndicator(value.BuildingType);
			}
		}
	}

	public float SetindicatorY(string buildingType, float initY, int times)
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		float num = 10000f;
		int value = buildingIndicators[buildingType].Value;
		UI_buildingDirectionIndicator key = buildingIndicators[buildingType].Key;
		float num2 = initY;
		Vector2 val;
		if (MaincityUi != null)
		{
			if (value == 0)
			{
				val = new Vector2(((GObject)key).x, initY) - ((GObject)MaincityUi.TurnPageLeftBtn).xy;
				num = ((Vector2)(ref val)).magnitude;
				num2 = ((GObject)MaincityUi.TurnPageLeftBtn).y;
			}
			else
			{
				val = new Vector2(((GObject)key).x, initY) - ((GObject)MaincityUi.TurnPageRightBtn).xy;
				num = ((Vector2)(ref val)).magnitude;
				num2 = ((GObject)MaincityUi.TurnPageRightBtn).y;
			}
		}
		foreach (KeyValuePair<string, tKeyValue<UI_buildingDirectionIndicator, int>> buildingIndicator in buildingIndicators)
		{
			if (buildingIndicator.Value.Value == value)
			{
				val = new Vector2(((GObject)key).x, initY) - ((GObject)buildingIndicator.Value.Key).xy;
				float magnitude = ((Vector2)(ref val)).magnitude;
				if (magnitude < num)
				{
					num = magnitude;
					num2 = ((GObject)buildingIndicator.Value.Key).y;
				}
			}
		}
		times++;
		if (num >= 52f && 0f <= initY && 1080f >= initY)
		{
			return initY;
		}
		if (times >= 5)
		{
			return -1f;
		}
		initY = ((!(num2 < initY)) ? (num2 - 52f) : (num2 + 52f));
		return SetindicatorY(buildingType, initY, times);
	}

	public Coroutine OpenIEnumerator(IEnumerator Enumerator)
	{
		return ((MonoBehaviour)this).StartCoroutine(Enumerator);
	}

	public void CloseIEnumerator(Coroutine coroutine)
	{
		if (coroutine != null)
		{
			((MonoBehaviour)this).StopCoroutine(coroutine);
		}
	}

	public void ClearCache_SoliderSoulStone()
	{
		_cache_SoliderSoulStone?.Clear();
	}

	public GComponent SetAlightSoulStoneForSoldierIcon(GComponent _component, int level, List<int> progress, bool isActivating = false, bool needMask = true)
	{
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		if (_cache_SoliderSoulStone == null)
		{
			_cache_SoliderSoulStone = new Dictionary<GComponent, GComponent>();
		}
		if (_cache_SoliderSoulStone.TryGetValue(_component, out var value))
		{
			return value;
		}
		_component.GetController("SoulStoneLevel").selectedIndex = level;
		int num = level + 2;
		GComponent val = null;
		switch (num / 2)
		{
		case 1:
			val = _component.GetChild("LevelC").asCom;
			LoadSoliderSoulStoneSfx(val, "green", needMask);
			break;
		case 2:
			val = _component.GetChild("LevelB").asCom;
			LoadSoliderSoulStoneSfx(val, "blue", needMask);
			break;
		case 3:
			val = _component.GetChild("LevelA").asCom;
			LoadSoliderSoulStoneSfx(val, "purple", needMask);
			break;
		case 4:
			val = _component.GetChild("LevelS").asCom;
			LoadSoliderSoulStoneSfx(val, "orange", needMask);
			break;
		case 5:
			val = _component.GetChild("LevelM").asCom;
			break;
		default:
			val = _component.GetChild("LevelC").asCom;
			ClearSoliderSoulStoneSfx(val);
			break;
		}
		if (num % 2 != 0)
		{
			val.GetController("SoulStoneIllume").selectedIndex = 7;
		}
		else
		{
			int selectedIndex = 0;
			val.GetController("SoulStoneIllume").selectedIndex = selectedIndex;
			ClearSoliderSoulStoneSfx(val);
		}
		if (isActivating)
		{
			val.GetController("SoulStoneIllume").selectedIndex = 8;
		}
		_cache_SoliderSoulStone.Add(_component, val);
		((GObject)_component).onRemovedFromStage.Set((EventCallback0)delegate
		{
			if (_cache_SoliderSoulStone.ContainsKey(_component))
			{
				_cache_SoliderSoulStone.Remove(_component);
			}
		});
		return val;
	}

	private void LoadSoliderSoulStoneSfx(GComponent SoliderSoulStone, string sfxType, bool needMask = true)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < 3; i++)
		{
			Instance.AddTextSpecialEffects(SoliderSoulStone.GetChild($"sfxBack{i}").asGraph, $"frame_fx_{sfxType}_{i + 1}", new Vector3(72f, 72f, 72f), "Default", 0.5f, delegate(GameObject frameFx)
			{
				frameFx.GetComponent<ParticleSystemRenderer>().maskInteraction = (SpriteMaskInteraction)(needMask ? 1 : 0);
			});
		}
	}

	private void ClearSoliderSoulStoneSfx(GComponent SoliderSoulStone)
	{
		if (SoliderSoulStone.numChildren < 2)
		{
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			DisplayObject displayObject = ((GObject)SoliderSoulStone.GetChild($"sfxBack{i}").asGraph).displayObject;
			if (displayObject != null)
			{
				displayObject.Dispose();
			}
		}
	}

	public void SetSoldierPotentialIcon(GComponent _component, int level, List<string> textureList = null, string iconType = "")
	{
		GLoader mainLoader = _component.GetChild("levelIcon").asLoader;
		GLoader minorLoader = _component.GetChild("levelLogo").asLoader;
		string mainLoaderIcon = "";
		string minorLoaderIcon = "";
		Controller controller = _component.GetController("PageController");
		switch (level)
		{
		case 0:
			mainLoaderIcon = "icon_aptitude" + iconType + "_0";
			controller.selectedIndex = 0;
			break;
		case 1:
			mainLoaderIcon = "icon_aptitude" + iconType + "_0";
			minorLoaderIcon = "icon_aptitude" + iconType + "_1";
			controller.selectedIndex = 1;
			break;
		case 2:
			mainLoaderIcon = "icon_aptitude" + iconType + "_2";
			controller.selectedIndex = 0;
			break;
		case 3:
			mainLoaderIcon = "icon_aptitude" + iconType + "_2";
			minorLoaderIcon = "icon_aptitude" + iconType + "_3";
			controller.selectedIndex = 1;
			break;
		case 4:
			mainLoaderIcon = "icon_aptitude" + iconType + "_4";
			controller.selectedIndex = 0;
			break;
		default:
			mainLoaderIcon = "icon_aptitude" + iconType + "_0";
			controller.selectedIndex = 0;
			break;
		}
		AssetsManager.Instance.LoadAsset<Texture2D>(mainLoaderIcon).Then((Action<Texture2D>)delegate(Texture2D asset)
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Expected O, but got Unknown
			mainLoader.texture = new NTexture((Texture)(object)asset);
			textureList?.Add(mainLoaderIcon);
		});
		if (!string.IsNullOrWhiteSpace(minorLoaderIcon))
		{
			AssetsManager.Instance.LoadAsset<Texture2D>(minorLoaderIcon).Then((Action<Texture2D>)delegate(Texture2D asset)
			{
				//IL_0008: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Expected O, but got Unknown
				minorLoader.texture = new NTexture((Texture)(object)asset);
				textureList?.Add(minorLoaderIcon);
			});
		}
		else
		{
			minorLoader.url = "";
		}
	}

	public void PlayTimeLine(string timeLineId)
	{
		if (timeLineId == "LordAppear")
		{
			object _controller = ((Throne)GameManagers.Instance.BuildingManager.GetBuildingByType("15")).Controller;
			ThroneController throneController = (ThroneController)_controller;
			((Behaviour)throneController.Director).enabled = true;
			ScriptApi.CreateTimer(2.5f, delegate
			{
				object controller = ((Throne)GameManagers.Instance.BuildingManager.GetBuildingByType("15")).Controller;
				ThroneController throneController2 = (ThroneController)_controller;
				throneController2.FlashingArtifact.SetActive(true);
			});
		}
	}

	private void UpdateBuildingsTitleOnUserLevelUp()
	{
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		int userLevel = GameManagers.Instance.UserArchiveManager.GetUserLevel();
		for (int i = 0; i < buildingTitleList.Count; i++)
		{
			if (!(buildingTitleList[i].Key.componentName != "BuildingTitleNotEnabled") && buildingTitleList[i].Value.Status != BuildingStatus.Banned && (buildingTitleList[i].Value.Status == BuildingStatus.Ready || buildingTitleList[i].Value.Level == 0))
			{
				GComponent ui = buildingTitleList[i].Key.ui;
				GObject child = ui.GetChild("name");
				Controller controller = ui.GetController("PageController");
				GObject child2 = ui.GetChild("tip");
				GObject child3 = ui.GetChild("note");
				if (child3.visible || buildingTitleList[i].Value.CanUpgrade())
				{
					Controller controller2 = ui.GetController("Status");
					controller2.selectedIndex = 0;
					child2.visible = true;
					child2.alpha = 1f;
				}
				child.grayed = true;
				child.asTextField.color = Color32.op_Implicit(new Color32((byte)204, (byte)204, (byte)204, byte.MaxValue));
				controller.selectedIndex = 1;
				child.y = 27f;
				Building value = buildingTitleList[i].Value;
				int buildingLevel = GameManagers.Instance.UserArchiveManager.GetBuildingLevel(value.BuildingType);
				int userLevelRequiredForBuildingUpgrade = GameManagers.Instance.ConfigDataManager.GetUserLevelRequiredForBuildingUpgrade(buildingTitleList[i].Value.BuildingType, buildingLevel);
				if (userLevel < userLevelRequiredForBuildingUpgrade)
				{
					child.text = LanguagesManager.GetDesc("CsharpCodeZhTcText21");
					child2.text = GetBuildingTitleTip(value, userLevelRequiredForBuildingUpgrade);
				}
				else
				{
					child.text = buildingTitleList[i].Value.Name ?? "";
					child2.text = LanguagesManager.GetDesc("CsharpCodeZhTcText31");
				}
			}
		}
	}

	public void ShowDialogTip(string _tips, int sortingOrder)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				_tips ?? ""
			},
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{
						"Confirm",
						delegate
						{
						}
					},
					{ "Cancel", null }
				}
			},
			{ "PageIndex", 4 },
			{ "ClickSound", "Confirm" },
			{ "Order", sortingOrder }
		});
	}

	public async void SetGoblinTitle(GoblinController goblinCtl)
	{
		Dictionary<int, Tuple<int, string, int>> invitingSlotsConfig = GameManagers.Instance.FriendsManager.InvitingSlotsConfig.GetValue();
		InvitedWorker targetWorker = null;
		int targetSlotIndex = -1;
		int[] array = invitingSlotsConfig.Keys.ToArray();
		foreach (int slotKey in array)
		{
			Tuple<int, string, int> configInfo = invitingSlotsConfig[slotKey];
			if (configInfo.Item1 >= 1 && GameManagers.Instance.FriendsManager.InvitedWorkers.TryGetValue(configInfo.Item1, out var invitedWorker) && invitedWorker.Status == InvitedWorkerActivateStatus.Activated)
			{
				if (configInfo.Item2 == goblinCtl.BuildingType && configInfo.Item3 == goblinCtl.selfIndex)
				{
					targetWorker = invitedWorker;
					targetSlotIndex = slotKey;
					break;
				}
				invitedWorker = null;
			}
		}
		if (targetWorker == null)
		{
			int[] array2 = invitingSlotsConfig.Keys.ToArray();
			foreach (int slotKey2 in array2)
			{
				Tuple<int, string, int> configInfo2 = invitingSlotsConfig[slotKey2];
				if (configInfo2.Item1 >= 1 && GameManagers.Instance.FriendsManager.InvitedWorkers.TryGetValue(configInfo2.Item1, out var invitedWorker2) && invitedWorker2.Status == InvitedWorkerActivateStatus.Activated)
				{
					if (configInfo2.Item2 == null || configInfo2.Item3 < 0)
					{
						targetSlotIndex = slotKey2;
						targetWorker = invitedWorker2;
						invitingSlotsConfig[slotKey2] = new Tuple<int, string, int>(configInfo2.Item1, goblinCtl.BuildingType, goblinCtl.selfIndex);
						break;
					}
					invitedWorker2 = null;
				}
			}
		}
		if (targetWorker != null)
		{
			string inviterName = targetWorker.Nickname;
			int workerUserId = targetWorker.UserId;
			GameController.Contexts.Service<INetworkService>().AssignInvitedWorker(targetSlotIndex, workerUserId, goblinCtl.BuildingType, goblinCtl.selfIndex);
			GameManagers.Instance.FriendsManager.AssignInvitedWorker(targetSlotIndex, workerUserId, goblinCtl.BuildingType, goblinCtl.selfIndex);
			if (inviterAndWorkers.ContainsKey(inviterName))
			{
				inviterName += $"({++inviterNameRepeatCnt})";
			}
			inviterAndWorkers.Add(inviterName, goblinCtl);
			if (goblinCtl.NameUi != null)
			{
				goblinCtl.NameUi.GetChild("name").text = inviterName;
			}
			else
			{
				GameObject nameGameObject = new GameObject();
				nameGameObject.transform.parent = ((Component)goblinCtl).gameObject.transform;
				nameGameObject.transform.localPosition = new Vector3(0f, 5f, 0f);
				nameGameObject.transform.localEulerAngles = Vector3.zero;
				UIPanel workerTitleUiPanel = nameGameObject.AddComponent<UIPanel>();
				workerTitleUiPanel.packageName = "PublicResources";
				workerTitleUiPanel.componentName = "WorkerTitle1";
				workerTitleUiPanel.container.renderMode = (RenderMode)2;
				workerTitleUiPanel.SetSortingOrder(3, true);
				workerTitleUiPanel.sortingOrder = 2;
				workerTitleUiPanel.CreateUI();
				((Component)workerTitleUiPanel).transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
				GComponent workerTitle = workerTitleUiPanel.ui;
				workerTitle.GetChild("name").text = inviterName;
				goblinCtl.NameUi = workerTitle;
			}
			((GObject)goblinCtl.NameUi).data = new KeyValuePair<Tuple<int, InvitedWorker>, int>(new Tuple<int, InvitedWorker>(targetSlotIndex, targetWorker), workerUserId);
			OpenNameTextMobile(goblinCtl.NameUi, inviterName);
		}
	}

	public async void ClearGoblinTitle(GoblinController goblinCtl)
	{
		if (goblinCtl.NameUi == null)
		{
			return;
		}
		goblinCtl.NameUi.GetChild("name").text = "";
		if (!inviterAndWorkers.ContainsValue(goblinCtl))
		{
			return;
		}
		string workerCtlKey = "";
		foreach (KeyValuePair<string, GoblinController> item in inviterAndWorkers)
		{
			if ((Object)(object)item.Value == (Object)(object)goblinCtl)
			{
				workerCtlKey = item.Key;
				break;
			}
		}
		if (NameTextMobileCoroutines.ContainsKey(workerCtlKey))
		{
			Instance.CloseIEnumerator(NameTextMobileCoroutines[workerCtlKey]);
			NameTextMobileCoroutines.Remove(workerCtlKey);
		}
		inviterAndWorkers.Remove(workerCtlKey);
		if (((GObject)goblinCtl.NameUi).data != null)
		{
			KeyValuePair<Tuple<int, InvitedWorker>, int> _data = (KeyValuePair<Tuple<int, InvitedWorker>, int>)((GObject)goblinCtl.NameUi).data;
			GameController.Contexts.Service<INetworkService>().AssignInvitedWorker(_data.Key.Item1, _data.Value, null, -1);
			_data.Key.Item2.AllocateInfo = new KeyValuePair<string, int>(null, -1);
			GameManagers.Instance.FriendsManager.AssignInvitedWorker(_data.Key.Item1, _data.Value);
			((GObject)goblinCtl.NameUi).data = null;
		}
	}

	public void WorkerTitleFade(GoblinController workerCtl, float alphaValue)
	{
		if (workerCtl.NameUi != null)
		{
			((GObject)workerCtl.NameUi).alpha = alphaValue;
		}
	}

	private void OpenNameTextMobile(GComponent nameUi, string nameKey)
	{
		GObject child = nameUi.GetChild("name");
		if (child.width <= ((GObject)nameUi).width)
		{
			child.x = (((GObject)nameUi).width - child.width) / 2f;
			return;
		}
		child.x = 0f;
		NameTextMobileCoroutines.Add(nameKey, Instance.OpenIEnumerator(GoblinNameMobile(nameUi)));
	}

	public IEnumerator GoblinNameMobile(GComponent nameUi, float speed = 300f)
	{
		while (true)
		{
			yield return (object)new WaitForSeconds(15f);
			GObject nameText = nameUi.GetChild("name");
			float offX = nameText.width - ((GObject)nameUi).width;
			nameText.TweenMoveX(0f - offX, offX / speed * 2.5f).OnComplete((GTweenCallback)delegate
			{
				nameText.TweenMoveX(0f, offX / speed * 2.5f);
			});
		}
	}

	public void UpdateBuildingsTitle(string buildingType, int level)
	{
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		int num = Convert.ToInt32(buildingType);
		if (buildingTitleList.Count - 1 < num - 1)
		{
			return;
		}
		Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType(buildingType);
		UIPanel key = buildingTitleList[num - 1].Key;
		string text = "";
		if (!(buildingByType.BuildingType == "14") && !(buildingByType.BuildingType == "15") && !(buildingByType.BuildingType == "16") && !(buildingByType.BuildingType == "18") && !(buildingByType.BuildingType == "12") && !(buildingByType.BuildingType == "7"))
		{
			text = $"Lv{level}";
		}
		if (level == 1)
		{
			key.packageName = "PublicResources";
			key.componentName = "BuildingTitle" + buildingType;
			key.container.renderMode = (RenderMode)2;
			key.SetSortingOrder(4, true);
			key.sortingOrder = 4;
			key.CreateUI();
			if (buildingByType.BuildingType == "10" || buildingByType.BuildingType == "15")
			{
				((Component)key).transform.localScale = new Vector3(0.019f, 0.019f, 0.019f);
			}
			else if (buildingByType.BuildingType == "11")
			{
				((Component)key).transform.localScale = new Vector3(0.016f, 0.019f, 0.019f);
			}
			else
			{
				((Component)key).transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
			}
			TextFormat textFormat = key.ui.GetChild("name").asTextField.textFormat;
			textFormat.font = "ui://kt6rg65orytnv47b";
			textFormat.size = UiHelper.BuildingTitleFontSize;
			key.ui.GetChild("name").asTextField.textFormat = textFormat;
			key.ui.GetChild("name").text = buildingByType.Name + text;
			key.ui.GetChild("name").grayed = false;
			key.ui.GetChild("name").asTextField.color = Color32.op_Implicit(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));
			key.ui.GetChild("icon").asLoader.url = "ui://PublicResources/Building" + buildingByType.BuildingType;
		}
		else
		{
			key.ui.GetChild("name").text = GetBuildingTitleName(buildingByType, text);
		}
		((GObject)key.ui).visible = false;
	}

	public void BuildingsTitleInit(Building building)
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		UIPanel val = ((Component)building.GameObject.transform.Find("BuildingTitle")).gameObject.AddComponent<UIPanel>();
		val.packageName = "PublicResources";
		string text = building.BuildingType ?? "";
		if (building.BuildingType == "15")
		{
			text = building.BuildingType ?? "";
		}
		else if (building.Status == BuildingStatus.Banned || building.Level == 0)
		{
			text = "NotEnabled";
		}
		val.componentName = "BuildingTitle" + text;
		val.container.renderMode = (RenderMode)2;
		val.SetSortingOrder(4, true);
		val.sortingOrder = 4;
		val.CreateUI();
		if (building.BuildingType == "10" || building.BuildingType == "15")
		{
			((Component)val).transform.localScale = new Vector3(0.019f, 0.019f, 0.019f);
		}
		else if (building.BuildingType == "11")
		{
			((Component)val).transform.localScale = new Vector3(0.016f, 0.019f, 0.019f);
		}
		else
		{
			((Component)val).transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
		}
		TextFormat textFormat = val.ui.GetChild("name").asTextField.textFormat;
		textFormat.font = "ui://kt6rg65orytnv47b";
		textFormat.size = UiHelper.BuildingTitleFontSize;
		val.ui.GetChild("name").asTextField.textFormat = textFormat;
		string level = "";
		if (!(building.BuildingType == "14") && !(building.BuildingType == "15") && !(building.BuildingType == "16") && !(building.BuildingType == "18") && !(building.BuildingType == "12") && !(building.BuildingType == "7"))
		{
			level = $"Lv{building.Level}";
		}
		if (building.BuildingType == "15")
		{
			val.ui.GetChild("name").text = GetBuildingTitleName(building, level);
			val.ui.GetChild("name").grayed = false;
			val.ui.GetChild("name").asTextField.color = Color32.op_Implicit(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));
		}
		else if (building.Status == BuildingStatus.Banned)
		{
			val.ui.GetChild("name").text = LanguagesManager.GetDesc("CsharpCodeZhTcText21");
			val.ui.GetChild("name").grayed = true;
			val.ui.GetChild("tip").text = LanguagesManager.GetDesc("CsharpCodeZhTcText22");
			val.ui.GetChild("name").asTextField.color = Color32.op_Implicit(new Color32((byte)204, (byte)204, (byte)204, byte.MaxValue));
			val.ui.GetController("PageController").selectedIndex = 0;
		}
		else if (building.Level == 0)
		{
			val.ui.GetChild("name").text = LanguagesManager.GetDesc("CsharpCodeZhTcText21");
			val.ui.GetChild("name").grayed = true;
			val.ui.GetChild("name").asTextField.color = Color32.op_Implicit(new Color32((byte)204, (byte)204, (byte)204, byte.MaxValue));
			val.ui.GetController("PageController").selectedIndex = 1;
			int buildingLevel = GameManagers.Instance.UserArchiveManager.GetBuildingLevel(building.BuildingType);
			int userLevelRequiredForBuildingUpgrade = GameManagers.Instance.ConfigDataManager.GetUserLevelRequiredForBuildingUpgrade(building.BuildingType, buildingLevel);
			if (GameManagers.Instance.UserArchiveManager.GetUserLevel() < userLevelRequiredForBuildingUpgrade)
			{
				val.ui.GetChild("tip").text = GetBuildingTitleTip(building, userLevelRequiredForBuildingUpgrade);
			}
			else
			{
				val.ui.GetChild("name").text = building.Name ?? "";
				val.ui.GetChild("tip").text = LanguagesManager.GetDesc("CsharpCodeZhTcText31");
			}
		}
		else
		{
			val.ui.GetChild("name").text = GetBuildingTitleName(building, level);
		}
		GObject child = val.ui.GetChild("icon");
		if (child != null)
		{
			child.asLoader.url = "ui://PublicResources/Building" + building.BuildingType;
		}
		buildingTitleList.Add(new KeyValuePair<UIPanel, Building>(val, building));
		buildingRedDot.Add(building.BuildingType, val.ui.GetChild("note"));
	}

	private static string GetBuildingTitleName(Building building, string level)
	{
		return (HotUpdateProcess.LanguageKey == "eng") ? (building.Name + " " + level) : (building.Name + level);
	}

	public void UpdateBuildingNote()
	{
		foreach (KeyValuePair<UIPanel, Building> buildingTitle in buildingTitleList)
		{
			if (buildingTitle.Value.Status != BuildingStatus.Banned)
			{
				buildingTitle.Key.ui.GetChild("note").visible = buildingTitle.Value.HasAnyInform();
			}
		}
	}

	public void BuildingsTextFloatingStageInit(WorkShop building)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		if (building.Status != BuildingStatus.Banned)
		{
			WorkshopController workshopController = (WorkshopController)building.Controller;
			Transform deliveryPoint = workshopController.DeliveryPoint;
			if ((Object)(object)deliveryPoint != (Object)null)
			{
				UIPanel val = ((Component)((Component)deliveryPoint).transform.Find("ProductionNumShow")).gameObject.AddComponent<UIPanel>();
				val.packageName = "PublicResources";
				val.componentName = "ProductionNumStage";
				val.container.renderMode = (RenderMode)2;
				val.SetSortingOrder(4, true);
				val.sortingOrder = 4;
				val.CreateUI();
				((Component)val).transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
			}
			Transform refundPoint = workshopController.RefundPoint;
			if ((Object)(object)refundPoint != (Object)null)
			{
				UIPanel val2 = ((Component)((Component)refundPoint).transform.Find("ProductionNumShow")).gameObject.AddComponent<UIPanel>();
				val2.packageName = "PublicResources";
				val2.componentName = "ProductionNumStage";
				val2.container.renderMode = (RenderMode)2;
				val2.SetSortingOrder(4, true);
				val2.sortingOrder = 4;
				val2.CreateUI();
				((Component)val2).transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
			}
		}
	}

	public void BuildingsUpgradeBarInit(Building building)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		if (building.Status != BuildingStatus.Banned && !(building.BuildingType == "15"))
		{
			UIPanel val = ((Component)building.GameObject.transform.Find("BuildingUpgradeStage")).gameObject.AddComponent<UIPanel>();
			val.packageName = "PublicResources";
			val.componentName = "BuildingUpgradeProgressStage";
			val.container.renderMode = (RenderMode)2;
			val.SetSortingOrder(0, true);
			val.sortingOrder = 0;
			val.CreateUI();
			if (building.BuildingType == "10")
			{
				((Component)val).transform.localScale = new Vector3(0.019f, 0.019f, 0.019f);
			}
			else if (building.BuildingType == "11")
			{
				((Component)val).transform.localScale = new Vector3(0.016f, 0.019f, 0.019f);
			}
			else
			{
				((Component)val).transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
			}
			((GObject)val.ui).visible = false;
			buildingUpgradeStageDic.Add(building.BuildingType, val);
		}
	}

	public void SetReadyBuildingUpgradeBar(Building building)
	{
		UIPanel component = ((Component)building.GameObject.transform.Find("BuildingUpgradeStage")).gameObject.GetComponent<UIPanel>();
		((GObject)component.ui).visible = true;
		BuildingUpgradeBarInitSet(building.BuildingType);
		BuildingUpgradeBarEndSet(building.BuildingType);
	}

	public void BuildingUpgradeBarFade(string buildingType, int level)
	{
		if (buildingUpgradeStageDic != null && buildingUpgradeStageDic.ContainsKey(buildingType))
		{
			((GObject)buildingUpgradeStageDic[buildingType].ui).visible = false;
			buildingUpgradeStageDic[buildingType].ui.GetChild("UpgradedProgressBar").visible = true;
			buildingUpgradeStageDic[buildingType].ui.GetChild("UpdatingProgressBar").visible = true;
		}
	}

	public void BuildingUpgradeBarInitSet(string buildingType)
	{
		if (buildingUpgradeStageDic != null && buildingUpgradeStageDic.ContainsKey(buildingType))
		{
			Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType(buildingType);
			buildingUpgradeStageDic[buildingType].ui.GetChild("UpgradedProgressBar").visible = false;
			buildingUpgradeStageDic[buildingType].ui.GetChild("UpdatingProgressBar").visible = true;
			if (buildingByType.Level == 0)
			{
				((GComponent)buildingUpgradeStageDic[buildingType].ui.GetChild("UpdatingProgressBar").asProgress).GetChild("status").text = LanguagesManager.GetDesc("CsharpCodeZhTcText32");
			}
			else
			{
				((GComponent)buildingUpgradeStageDic[buildingType].ui.GetChild("UpdatingProgressBar").asProgress).GetChild("status").text = LanguagesManager.GetDesc("CsharpCodeZhTcText33");
			}
			BuildingUpgradeBarRefresh(buildingByType, init: true);
			((GObject)buildingUpgradeStageDic[buildingType].ui).visible = true;
		}
	}

	public void BuildingUpgradeBarRefresh(Building building, bool init = false, int remainingTime = -1)
	{
		if (buildingUpgradeStageDic != null && buildingUpgradeStageDic.ContainsKey(building.BuildingType))
		{
			GProgressBar asProgress = buildingUpgradeStageDic[building.BuildingType].ui.GetChild("UpdatingProgressBar").asProgress;
			BuildingConstructingConfig constructingConfig = building.ConstructingConfig;
			double num = ((remainingTime >= 0) ? remainingTime : constructingConfig.UpgradeRemainingTime);
			double num2 = building.GetUpgradeTime(constructingConfig.Workers);
			if (init)
			{
				asProgress.value = (num2 - num) / num2 * 100.0;
			}
			else
			{
				asProgress.TweenValue((num2 - num) / num2 * 100.0, 1f);
			}
			((GObject)((GComponent)asProgress).GetChild("time").asTextField).text = UiHelper.ParseTime(constructingConfig.UpgradeRemainingTime) ?? "";
		}
	}

	public void BuildingUpgradeBarEndSet(string buildingType)
	{
		if (buildingUpgradeStageDic != null && buildingUpgradeStageDic.ContainsKey(buildingType))
		{
			buildingUpgradeStageDic[buildingType].ui.GetChild("UpdatingProgressBar").visible = false;
			GProgressBar asProgress = buildingUpgradeStageDic[buildingType].ui.GetChild("UpgradedProgressBar").asProgress;
			((GObject)asProgress).visible = true;
			((GObject)((GComponent)asProgress).GetChild("time").asTextField).text = "00:00:00";
			Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType(buildingType);
			if (buildingByType.Level == 0)
			{
				((GComponent)asProgress).GetChild("repairedTitle").visible = true;
				((GComponent)asProgress).GetChild("upgradeTitle").visible = false;
			}
			else
			{
				((GComponent)asProgress).GetChild("repairedTitle").visible = false;
				((GComponent)asProgress).GetChild("upgradeTitle").visible = true;
			}
			((GObject)buildingUpgradeStageDic[buildingType].ui).visible = true;
		}
	}

	public void BuildingsTitleFadeOut()
	{
		for (int i = 0; i < buildingTitleList.Count; i++)
		{
			if (buildingTitleList[i].Key.ui.GetChild("note").visible)
			{
				((GObject)buildingTitleList[i].Key.ui).visible = true;
				if (buildingTitleList[i].Key.ui.GetTransition("t0").playing)
				{
					buildingTitleList[i].Key.ui.GetTransition("t0").Stop();
				}
				buildingTitleList[i].Key.ui.GetController("Status").selectedIndex = 0;
				buildingTitleList[i].Key.ui.GetChild("back").alpha = 1f;
				buildingTitleList[i].Key.ui.GetChild("back").visible = true;
				buildingTitleList[i].Key.ui.GetChild("name").visible = true;
				if (!(buildingTitleList[i].Key.componentName == "BuildingTitleNotEnabled"))
				{
					buildingTitleList[i].Key.ui.GetChild("icon").visible = true;
				}
			}
		}
		ScriptApi.CreateTimer(2f, delegate
		{
			for (int j = 0; j < buildingTitleList.Count; j++)
			{
				if (!buildingTitleList[j].Key.ui.GetChild("note").visible)
				{
					Building value = buildingTitleList[j].Value;
					int buildingLevel = GameManagers.Instance.UserArchiveManager.GetBuildingLevel(value.BuildingType);
					if (buildingLevel > 0)
					{
						buildingTitleList[j].Key.ui.GetController("Status").selectedIndex = 1;
					}
				}
			}
		});
	}

	public static string GetBuildingTitleTip(Building building, int requireLevel)
	{
		return LanguagesManager.GetDesc("MainCityBuildingLockedTip_" + building.BuildingType);
	}

	public void BuildingsTitleAppear()
	{
		for (int i = 0; i < buildingTitleList.Count; i++)
		{
			((GObject)buildingTitleList[i].Key.ui).visible = true;
			if (buildingTitleList[i].Key.ui.GetTransition("t0").playing)
			{
				buildingTitleList[i].Key.ui.GetTransition("t0").Stop();
			}
			buildingTitleList[i].Key.ui.GetController("Status").selectedIndex = 0;
			buildingTitleList[i].Key.ui.GetChild("back").visible = true;
			buildingTitleList[i].Key.ui.GetChild("back").alpha = 1f;
			buildingTitleList[i].Key.ui.GetChild("name").visible = true;
			if (!(buildingTitleList[i].Key.componentName == "BuildingTitleNotEnabled"))
			{
				buildingTitleList[i].Key.ui.GetChild("icon").visible = true;
			}
		}
	}

	public void CampSlotsUiPanelInint(Camp camp)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		if (camp.Slot > 5)
		{
			return;
		}
		for (int i = 0; i < 5; i++)
		{
			GameObject slotGameObject = camp.GameObject.GetComponent<CampController>().GetSlotGameObject(i);
			if (slotGameObject != null)
			{
				UIPanel val = ((Component)slotGameObject.transform.Find("CmapSlotUi")).gameObject.AddComponent<UIPanel>();
				val.packageName = "PublicResources";
				val.componentName = "CampSlotPanel";
				val.container.renderMode = (RenderMode)2;
				val.SetSortingOrder(4, true);
				val.CreateUI();
				val.ui.GetChild("EquipmentList").alpha = 0f;
				val.ui.GetChild("ProgressBar").alpha = 0f;
				val.ui.GetChild("max").alpha = 0f;
				val.ui.GetChild("max").visible = true;
				((GComponent)val.ui.GetChild("ProgressBar").asProgress).GetChild("time").SetXY(((GComponent)val.ui.GetChild("ProgressBar").asProgress).GetChild("time").x, -8f);
				if (camp.Slot < i + 1)
				{
					((GObject)val.ui).visible = false;
				}
			}
		}
	}

	public void PlayCampSlotCastAnimation(GameObject slot, GComponent ui, float setupTime)
	{
		((Component)slot.transform.Find("Soldier")).GetComponent<PortalSoldier>().PlayEquipmentDisappear = ((MonoBehaviour)this).StartCoroutine(PlayEquipmentListDisappear(slot, ui, 1.17f));
		((Component)slot.transform.Find("Soldier")).GetComponent<PortalSoldier>().ProgressBarAppear = ((MonoBehaviour)this).StartCoroutine(ProgressBarAppear(slot, ui, 1.67f));
		((Component)slot.transform.Find("Soldier")).GetComponent<PortalSoldier>().ProductComplete = ((MonoBehaviour)this).StartCoroutine(ProductCompleted(slot, ui, setupTime - 1f));
	}

	public IEnumerator PlayEquipmentListDisappear(GameObject slot, GComponent ui, float duration)
	{
		yield return (object)new WaitForSeconds(duration);
		((Component)slot.transform.Find("Soldier")).GetComponent<PortalSoldier>().EquipmentDisappear = ui.GetTransition("EquipmentListDisappear");
		((Component)slot.transform.Find("Soldier")).GetComponent<PortalSoldier>().EquipmentDisappear.Play();
	}

	public IEnumerator ProgressBarAppear(GameObject slot, GComponent ui, float duration)
	{
		yield return (object)new WaitForSeconds(duration);
		GProgressBar progressBar = ui.GetChild("ProgressBar").asProgress;
		((Component)slot.transform.Find("Soldier")).GetComponent<PortalSoldier>().ShowProgressBar = ((GObject)progressBar).TweenFade(1f, 0.33f);
	}

	public IEnumerator ProductCompleted(GameObject slot, GComponent ui, float duration)
	{
		yield return (object)new WaitForSeconds(duration);
		GProgressBar progressBar = ui.GetChild("ProgressBar").asProgress;
		((GObject)progressBar).alpha = 0f;
		ui.GetChild("EquipmentList").alpha = 0f;
		((Component)slot.transform.Find("MagicCircleBlue/TreasureChestGlowRays")).gameObject.SetActive(false);
		GameObject campSlotFinish = null;
		yield return SpawnManager.Instance.InstantiatePoolCoroutine("camp_slot_finish", Vector3.one * 20000f, delegate(GameObject go)
		{
			campSlotFinish = go;
		});
		((Component)slot.transform.Find("Soldier")).GetComponent<PortalSoldier>().campSlotFinish = campSlotFinish;
		campSlotFinish.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
		UiAudioManager.Instance.LoadSoundsForSfx(campSlotFinish, "BlastForPack", playLoop: false, 1f, limitForScene: true);
		campSlotFinish.GetComponent<Renderer>().sortingLayerName = "Default";
		campSlotFinish.transform.parent = slot.transform;
		campSlotFinish.transform.localPosition = new Vector3(0f, 0.05f, 0.5f);
		campSlotFinish.transform.localEulerAngles = new Vector3(-55f, 0f, 0f);
	}

	public async void PlayCampSlotCastAnimationBefore(GameObject slot, GComponent ui, bool isEnough)
	{
		Building camp = GameManagers.Instance.BuildingManager.GetBuildingByType("10");
		GameObject runeMissile = await AddressableHelper.Instance.InstantiateAsync("FX/Prefabs/rune_missile");
		runeMissile.SetActive(false);
		((Component)slot.transform.Find("Soldier")).GetComponent<PortalSoldier>().runeMissile = runeMissile;
		runeMissile.AddComponent<HotFix_DestroySelf>().destroyTime = 0.9f;
		runeMissile.transform.parent = camp.GameObject.transform;
		runeMissile.transform.localPosition = camp.GameObject.transform.Find("summon_stone").localPosition;
		runeMissile.SetActive(true);
		UiAudioManager.Instance.LoadSoundsForSfx(runeMissile, "Missile", playLoop: false, 0.5f, limitForScene: true);
		PortalSoldier component = ((Component)slot.transform.Find("Soldier")).GetComponent<PortalSoldier>();
		Tweener obj = ShortcutExtensions.DOLocalMove(runeMissile.transform, slot.transform.localPosition, 0.6f, false);
		object obj2 = _003C_003Ec._003C_003E9__303_0;
		if (obj2 == null)
		{
			TweenCallback val = delegate
			{
			};
			_003C_003Ec._003C_003E9__303_0 = val;
			obj2 = (object)val;
		}
		component.runeMissileMove = TweenSettingsExtensions.OnComplete<Tweener>(obj, (TweenCallback)obj2);
	}

	public IEnumerator ShowEquipmentList(GameObject slot, GComponent ui, bool isEnough, float duration)
	{
		yield return (object)new WaitForSeconds(duration);
		((Component)slot.transform.Find("MagicCircleBlue/TreasureChestGlowRays")).gameObject.SetActive(true);
		ui.GetChild("EquipmentList").SetScale(0.7f, 0.7f);
		ui.GetChild("EquipmentList").SetXY(-173f, 116f);
		if (!isEnough)
		{
			ui.GetChild("EquipmentList").alpha = 1f;
			yield break;
		}
		ui.GetChild("EquipmentList").TweenFade(1f, 0.7f);
		ui.GetChild("max").alpha = 1f;
	}

	public void SetCampSlotEquipList(PortalSoldier slot, GComponent ui, string soldierId, Dictionary<string, float> requirements, List<string> textureList, List<bool> result, out string waitItemId)
	{
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		GList asList = ui.GetChild("EquipmentList").asList;
		asList.RemoveChildrenToPool();
		int num = 0;
		if (!result.Contains(item: false))
		{
			foreach (KeyValuePair<string, float> requirement in requirements)
			{
				asList.AddItemFromPool();
				int num2 = num;
				string frame = "";
				SetItemIconAndFrame(((GComponent)asList).GetChildAt(num2).asCom.GetChild("icon").asLoader, requirement.Key, textureList, frame);
				((GComponent)asList).GetChildAt(num2).asCom.GetChild("MateriaNuml").visible = false;
				GComponent component = ((GComponent)asList).GetChildAt(num2).asCom.GetChild("icon").asLoader.component;
				component.GetChild("MateriaNuml").visible = false;
				num++;
			}
			waitItemId = "";
			if ((Object)(object)slot.NoticeGameObject != (Object)null)
			{
				slot.NoticeGameObject.SetActive(false);
			}
			return;
		}
		int num3 = 0;
		for (int i = 0; i < result.Count; i++)
		{
			if (!result[i])
			{
				num3 = i;
			}
		}
		KeyValuePair<string, float> keyValuePair = default(KeyValuePair<string, float>);
		foreach (KeyValuePair<string, float> requirement2 in requirements)
		{
			if (num == num3)
			{
				keyValuePair = requirement2;
				break;
			}
			num++;
		}
		if (!string.IsNullOrEmpty(keyValuePair.Key))
		{
			asList.AddItemFromPool();
			string frame2 = "";
			SetItemIconAndFrame(((GComponent)asList).GetChildAt(0).asCom.GetChild("icon").asLoader, keyValuePair.Key, textureList, frame2);
			((GComponent)asList).GetChildAt(0).asCom.GetChild("MateriaNuml").visible = false;
			GComponent component2 = ((GComponent)asList).GetChildAt(0).asCom.GetChild("icon").asLoader.component;
			component2.GetChild("MateriaNuml").SetPivot(0f, 0f, true);
			component2.GetChild("MateriaNuml").visible = true;
			component2.GetChild("MateriaNuml").asCom.GetChild("n3").visible = true;
			component2.GetChild("MateriaNuml").asCom.GetChild("curNum").text = $"{GameManagers.Instance.StockController.GetStock(keyValuePair.Key)}";
			component2.GetChild("MateriaNuml").asCom.GetChild("sprit").text = "/";
			component2.GetChild("MateriaNuml").asCom.GetChild("requireNum").text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(keyValuePair.Value.ToString()) ?? "";
			component2.GetChild("MateriaNuml").SetPivot(0.5f, 0.5f, true);
			component2.GetChild("MateriaNuml").SetXY(component2.GetChild("icon").x, component2.GetChild("icon").y + 26f);
		}
		waitItemId = keyValuePair.Key;
		if ((Object)(object)slot.NoticeGameObject != (Object)null)
		{
			Object.Destroy((Object)(object)slot.NoticeGameObject);
		}
		GameObject val = (slot.NoticeGameObject = SpawnManager.Instance.InstantiatePool("notise", Vector3.zero));
		val.transform.parent = ((Component)slot).gameObject.transform.parent.Find("NotiseSfx");
		val.transform.localPosition = new Vector3(0f, 0f, 0f);
	}

	public IEnumerator WaitToHttpGet(string _url)
	{
		CoroutineWithData cd = new CoroutineWithData((MonoBehaviour)(object)this, HttpGet(_url));
		yield return cd.Coroutine;
		if (cd.Result != null)
		{
		}
	}

	public IEnumerator WaitToHttpPost(string _url, string postData)
	{
		CoroutineWithData cd = new CoroutineWithData((MonoBehaviour)(object)this, HttpPost(_url, postData));
		yield return cd.Coroutine;
		if (cd.Result != null)
		{
		}
	}

	private IEnumerator HttpGet(string url)
	{
		UnityWebRequest uwr = UnityWebRequest.Get(url);
		yield return uwr.SendWebRequest();
		if (uwr.isNetworkError || uwr.isHttpError)
		{
			Debug.LogError((object)uwr.error);
			yield return null;
			yield break;
		}
		if (!string.IsNullOrEmpty(uwr.downloadHandler.text))
		{
		}
		if (uwr.downloadHandler.data != null && uwr.downloadHandler.data.Length != 0)
		{
			string _data = "";
			for (int i = 0; i < uwr.downloadHandler.data.Length; i++)
			{
				_data += uwr.downloadHandler.data[i];
			}
		}
		yield return uwr.downloadHandler;
	}

	private IEnumerator HttpPost(string url, string postData)
	{
		byte[] postDataBytes = Encoding.UTF8.GetBytes(postData);
		UnityWebRequest www = new UnityWebRequest(url, "POST");
		www.chunkedTransfer = false;
		www.uploadHandler = (UploadHandler)new UploadHandlerRaw(postDataBytes);
		www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
		www.SetRequestHeader("Content-Type", "application/json");
		www.SetRequestHeader("Accept", "application/json");
		yield return www.SendWebRequest();
		if (www.isNetworkError || www.isHttpError)
		{
			yield break;
		}
		if (!string.IsNullOrEmpty(www.downloadHandler.text))
		{
		}
		if (www.downloadHandler.data != null && www.downloadHandler.data.Length != 0)
		{
			string _data = "";
			for (int i = 0; i < www.downloadHandler.data.Length; i++)
			{
				_data += www.downloadHandler.data[i];
			}
		}
		yield return www.downloadHandler;
	}

	private void OnPrinceRedDotChange(Cache_PrinceRedDot cache)
	{
		if (buildingRedDot != null && buildingRedDot.TryGetValue("15", out var value))
		{
			value.visible = cache.IsShowRedDot;
		}
	}

	private void AddNeedReleaseTexture2Ds(string panelName, Texture2D texture2D)
	{
		if (!(panelName == ""))
		{
			if (_needReleaseTexture2Ds == null)
			{
				_needReleaseTexture2Ds = new Dictionary<string, List<Texture2D>>();
			}
			if (!_needReleaseTexture2Ds.ContainsKey(panelName))
			{
				_needReleaseTexture2Ds.Add(panelName, new List<Texture2D>());
			}
			_needReleaseTexture2Ds[panelName].Add(texture2D);
		}
	}

	public void ReleaseGloaderTexture2D(string panelName)
	{
		if (!(panelName == "") && _needReleaseTexture2Ds != null && _needReleaseTexture2Ds.ContainsKey(panelName))
		{
			List<Texture2D> list = _needReleaseTexture2Ds[panelName];
			for (int i = 0; i < list.Count; i++)
			{
				Object.Destroy((Object)(object)list[i]);
			}
			_needReleaseTexture2Ds[panelName].Clear();
		}
	}

	public IEnumerator SetSelfImageByWebRequestAndStorage(string panelName, GLoader imageComp, Action action = null)
	{
		if (imageComp == null || ((GObject)imageComp).isDisposed)
		{
			yield break;
		}
		imageComp.url = "ui://PublicResources/Boss3";
		GameLocalDataManager.SelfLocalData userLocalData = GameLocalDataManager.GetSelfUserLocalData();
		if (userLocalData == null)
		{
			yield return ((MonoBehaviour)this).StartCoroutine(Instance.GetSelfUserAvatar(panelName, imageComp, need_ensure: true, action));
			yield break;
		}
		int curTime = (int)GameController.Instance.GetServerTime();
		if (curTime < (int)userLocalData.ExpiredTime)
		{
			if (userLocalData.isPending)
			{
				action?.Invoke();
			}
			yield return ((MonoBehaviour)this).StartCoroutine(Instance.GetSelfUserAvatar(panelName, imageComp));
		}
		else
		{
			yield return ((MonoBehaviour)this).StartCoroutine(Instance.GetSelfUserAvatar(panelName, imageComp, need_ensure: true, action));
		}
	}

	public IEnumerator SetSelfImageByWebRequestAndStorageWithoutFadeIn(string panelName, GLoader imageComp, Action action = null)
	{
		if (imageComp == null || ((GObject)imageComp).isDisposed)
		{
			yield break;
		}
		imageComp.url = "ui://PublicResources/Boss3";
		GameLocalDataManager.SelfLocalData userLocalData = GameLocalDataManager.GetSelfUserLocalData();
		if (userLocalData == null)
		{
			yield return ((MonoBehaviour)this).StartCoroutine(Instance.GetSelfUserAvatarWithoutFadeIn(panelName, imageComp, need_ensure: true, action));
			yield break;
		}
		int curTime = (int)GameController.Instance.GetServerTime();
		if (curTime < (int)userLocalData.ExpiredTime)
		{
			if (userLocalData.isPending)
			{
				action?.Invoke();
			}
			yield return ((MonoBehaviour)this).StartCoroutine(Instance.GetSelfUserAvatarWithoutFadeIn(panelName, imageComp));
		}
		else
		{
			yield return ((MonoBehaviour)this).StartCoroutine(Instance.GetSelfUserAvatarWithoutFadeIn(panelName, imageComp, need_ensure: true, action));
		}
	}

	public IEnumerator GetUserNickName(int userId, GTextField textField, int textLength = 14)
	{
		if (textField == null || ((GObject)textField).isDisposed)
		{
			yield break;
		}
		if (userId == GameController.Contexts.gameState.user.value.UserId)
		{
			((GObject)textField).text = Instance.TruncateTextLength(GameController.Contexts.gameState.user.value.Nickname, textLength);
			yield break;
		}
		((GObject)textField).text = "";
		GameLocalDataManager.UserLocalData userLocalData = GameLocalDataManager.GetSomeUserLocalData(userId);
		if (userLocalData == null)
		{
			yield return ((MonoBehaviour)this).StartCoroutine(EnsurePVPAvatarExist(userId, textField, textLength));
			yield break;
		}
		int curTime = (int)GameController.Instance.GetServerTime();
		if (curTime < (int)userLocalData.ModifiedDate)
		{
			if (!string.IsNullOrWhiteSpace(userLocalData.NickName))
			{
				((GObject)textField).text = Instance.TruncateTextLength(userLocalData.NickName, textLength);
			}
			else
			{
				yield return ((MonoBehaviour)this).StartCoroutine(EnsurePVPAvatarExist(userId, textField, textLength));
			}
		}
		else
		{
			yield return ((MonoBehaviour)this).StartCoroutine(EnsurePVPAvatarExist(userId, textField, textLength));
		}
	}

	public void GetUserMedal(int userId, GList medalList, Controller isShowMedals = null, Action<bool> onLoaded = null)
	{
		if (Define.IsGvgAvatarMedalOpen && !HotUpdateProcess.Instance.IsRegionOutCN)
		{
			((MonoBehaviour)this).StartCoroutine(GetUserMedalCoroutine(userId, medalList, isShowMedals, onLoaded));
		}
	}

	private static IEnumerator GetUserMedalCoroutine(int userId, GList medalList, Controller isShowMedals, Action<bool> onLoaded = null)
	{
		if (medalList == null || ((GObject)medalList).isDisposed)
		{
			yield break;
		}
		((GObject)medalList).data = userId;
		Controller obj = isShowMedals;
		if (obj != null)
		{
			obj.SetSelectedIndex(0);
		}
		if (!TryRenderMedals())
		{
			yield return LoadUserMedal(userId);
			if (medalList != null && !((GObject)medalList).isDisposed && (int)((GObject)medalList).data == userId)
			{
				TryRenderMedals();
			}
		}
		bool TryRenderMedals()
		{
			GameLocalDataManager.UserMedalData userMedalData = GameLocalDataManager.GetUserMedalData(userId);
			if (userMedalData == null)
			{
				onLoaded?.Invoke(obj: false);
				return false;
			}
			bool flag = userMedalData.MedalRecords.Count > 0;
			Controller obj2 = isShowMedals;
			if (obj2 != null)
			{
				obj2.SetSelectedIndex(flag ? 1 : 0);
			}
			GComponentExtension.RenderMedals(medalList, userMedalData.MedalRecords);
			onLoaded?.Invoke(flag);
			return true;
		}
	}

	private static IEnumerator LoadUserMedal(int userId)
	{
		string profile_url = UiHelper.GetUserProfileHttpsUrl(userId);
		UnityWebRequest uwr_profile = UnityWebRequest.Get(profile_url);
		try
		{
			uwr_profile.timeout = 3;
			yield return uwr_profile.SendWebRequest();
			string medals = string.Empty;
			if ((int)uwr_profile.result != 2 && (int)uwr_profile.result != 3)
			{
				UserProfile userProfile = uwr_profile.downloadHandler.data.Deserialize<UserProfile>();
				if (userProfile != null)
				{
					medals = userProfile.Medals;
				}
			}
			GameLocalDataManager.SetUserMedalData(userId, medals);
		}
		finally
		{
			((IDisposable)uwr_profile)?.Dispose();
		}
	}

	public IEnumerator GetImageByWebRequestAndStorage(int userId, GLoader imageComp, GTextField textField, int textLength = 14, bool is_big = false)
	{
		return GetImageByWebRequestAndStorage("", userId, imageComp, textField, textLength, is_big);
	}

	public IEnumerator GetImageByWebRequestAndStorage(string panelName, int userId, GLoader imageComp, GTextField textField, int textLength = 14, bool is_big = false)
	{
		if (imageComp == null || textField == null || ((GObject)imageComp).isDisposed || ((GObject)textField).isDisposed)
		{
			yield break;
		}
		imageComp.url = "";
		imageComp.texture = null;
		((GObject)textField).text = "";
		if (userId == GameController.Contexts.gameState.user.value.UserId)
		{
			yield return ((MonoBehaviour)this).StartCoroutine(Instance.SetSelfImageByWebRequestAndStorage(panelName, imageComp));
			yield return ((MonoBehaviour)this).StartCoroutine(Instance.GetUserNickName(userId, textField, textLength));
			yield break;
		}
		GameLocalDataManager.UserLocalData userLocalData = GameLocalDataManager.GetSomeUserLocalData(userId);
		if (userLocalData == null)
		{
			string npcName = "";
			if (userId <= 0)
			{
				npcName = LanguagesManager.GetDesc("CsharpCodeZhTcText51");
			}
			yield return ((MonoBehaviour)this).StartCoroutine(Instance.GetPvpUserAvatar(panelName, userId, imageComp, textField, npcName, 14, is_big));
			yield break;
		}
		int curTime = (int)GameController.Instance.GetServerTime();
		if (curTime < (int)userLocalData.ModifiedDate)
		{
			if (!string.IsNullOrWhiteSpace(userLocalData.NickName))
			{
				((GObject)textField).text = Instance.TruncateTextLength(userLocalData.NickName, textLength);
			}
			yield return ((MonoBehaviour)this).StartCoroutine(Instance.GetPvpUserAvatar(panelName, userId, imageComp, textField, userLocalData.NickName, 14, is_big, existed: true));
		}
		else
		{
			yield return ((MonoBehaviour)this).StartCoroutine(Instance.GetPvpUserAvatar(panelName, userId, imageComp, textField, "", 14, is_big));
		}
	}

	public IEnumerator GetImageByWebRequestAndStorageWithoutFadeIn(string panelName, int userId, GLoader imageComp, GTextField textField, int textLength = 14, bool is_big = false)
	{
		if (imageComp == null || textField == null || ((GObject)imageComp).isDisposed || ((GObject)textField).isDisposed)
		{
			yield break;
		}
		imageComp.url = "";
		imageComp.texture = null;
		((GObject)textField).text = "";
		if (userId == GameController.Contexts.gameState.user.value.UserId)
		{
			yield return ((MonoBehaviour)this).StartCoroutine(Instance.SetSelfImageByWebRequestAndStorageWithoutFadeIn(panelName, imageComp));
			yield return ((MonoBehaviour)this).StartCoroutine(Instance.GetUserNickName(userId, textField, textLength));
			yield break;
		}
		GameLocalDataManager.UserLocalData userLocalData = GameLocalDataManager.GetSomeUserLocalData(userId);
		if (userLocalData == null)
		{
			string npcName = "";
			if (userId <= 0)
			{
				npcName = LanguagesManager.GetDesc("CsharpCodeZhTcText51");
			}
			yield return ((MonoBehaviour)this).StartCoroutine(Instance.GetPvpUserAvatarWithoutFadeIn(panelName, userId, imageComp, textField, npcName, 14, is_big));
			yield break;
		}
		int curTime = (int)GameController.Instance.GetServerTime();
		if (curTime < (int)userLocalData.ModifiedDate)
		{
			if (!string.IsNullOrWhiteSpace(userLocalData.NickName))
			{
				((GObject)textField).text = Instance.TruncateTextLength(userLocalData.NickName, textLength);
			}
			yield return ((MonoBehaviour)this).StartCoroutine(Instance.GetPvpUserAvatarWithoutFadeIn(panelName, userId, imageComp, textField, userLocalData.NickName, 14, is_big, existed: true));
		}
		else
		{
			yield return ((MonoBehaviour)this).StartCoroutine(Instance.GetPvpUserAvatarWithoutFadeIn(panelName, userId, imageComp, textField, "", 14, is_big));
		}
	}

	private IEnumerator GetSelfUserAvatar(string panelName, GLoader loader, bool need_ensure = false, Action action = null)
	{
		if (loader != null && !((GObject)loader).isDisposed)
		{
			string png_path = UiHelper.GetSelfAvatarLocalPath();
			if (need_ensure || !File.Exists(png_path))
			{
				CoroutineWithData cd_Ensure = new CoroutineWithData((MonoBehaviour)(object)this, EnsureSelfAvatarExist(action));
				yield return cd_Ensure.Coroutine;
			}
			CoroutineWithData cd = new CoroutineWithData((MonoBehaviour)(object)this, HotFix_Utils.getTextureByPath(png_path));
			yield return cd.Coroutine;
			if (cd.Result != null && !((GObject)loader).isDisposed)
			{
				((GObject)loader).alpha = 0f;
				Texture2D _texture = (Texture2D)cd.Result;
				loader.texture = new NTexture((Texture)(object)_texture);
				((GObject)loader).TweenFade(1f, 0.45f);
				AddNeedReleaseTexture2Ds(panelName, _texture);
			}
			else if (!((GObject)loader).isDisposed)
			{
				loader.url = "ui://PublicResources/Boss3";
			}
		}
	}

	private IEnumerator GetSelfUserAvatarWithoutFadeIn(string panelName, GLoader loader, bool need_ensure = false, Action action = null)
	{
		if (loader != null && !((GObject)loader).isDisposed)
		{
			string png_path = UiHelper.GetSelfAvatarLocalPath();
			if (need_ensure || !File.Exists(png_path))
			{
				CoroutineWithData cd_Ensure = new CoroutineWithData((MonoBehaviour)(object)this, EnsureSelfAvatarExist(action));
				yield return cd_Ensure.Coroutine;
			}
			CoroutineWithData cd = new CoroutineWithData((MonoBehaviour)(object)this, HotFix_Utils.getTextureByPath(png_path));
			yield return cd.Coroutine;
			if (cd.Result != null && !((GObject)loader).isDisposed)
			{
				Texture2D _texture = (Texture2D)cd.Result;
				loader.texture = new NTexture((Texture)(object)_texture);
				AddNeedReleaseTexture2Ds(panelName, _texture);
			}
			else if (!((GObject)loader).isDisposed)
			{
				loader.url = "ui://PublicResources/Boss3";
			}
		}
	}

	private IEnumerator GetPvpUserAvatar(string panelName, int userId, GLoader loader, GTextField textField = null, string nickName = "", int textLength = 14, bool is_big = false, bool existed = false)
	{
		if (userId <= 0 || loader == null || ((GObject)loader).isDisposed)
		{
			yield break;
		}
		loader.url = "ui://PublicResources/avatar_player_default";
		string png_path = UiHelper.GetUserAvatarLocalPath(userId.ToString());
		if (is_big)
		{
			png_path = UiHelper.GetUserBigAvatarLocalPath(userId.ToString());
			if (!File.Exists(png_path))
			{
				png_path = UiHelper.GetUserAvatarLocalPath(userId.ToString());
			}
		}
		if (!existed || !File.Exists(png_path))
		{
			yield return ((MonoBehaviour)this).StartCoroutine(EnsurePVPAvatarExist(userId, textField, textLength));
		}
		CoroutineWithData cd = new CoroutineWithData((MonoBehaviour)(object)this, HotFix_Utils.getTextureByPath(png_path));
		yield return cd.Coroutine;
		if (cd.Result != null && !((GObject)loader).isDisposed)
		{
			((GObject)loader).alpha = 0f;
			Texture2D _texture = (Texture2D)cd.Result;
			loader.texture = new NTexture((Texture)(object)_texture);
			((GObject)loader).TweenFade(1f, 0.45f);
			AddNeedReleaseTexture2Ds(panelName, _texture);
		}
		else if (!((GObject)loader).isDisposed)
		{
			loader.url = "ui://PublicResources/avatar_player_default";
			if (textField != null && !((GObject)textField).isDisposed)
			{
				((GObject)textField).text = Instance.TruncateTextLength(RankDataHelper.UserId_Obfuscating(userId), textLength);
			}
		}
		if (textField != null && !((GObject)textField).isDisposed && !string.IsNullOrWhiteSpace(nickName))
		{
			((GObject)textField).text = Instance.TruncateTextLength(nickName, textLength);
		}
	}

	private IEnumerator GetPvpUserAvatarWithoutFadeIn(string panelName, int userId, GLoader loader, GTextField textField = null, string nickName = "", int textLength = 14, bool is_big = false, bool existed = false)
	{
		if (userId <= 0 || loader == null || ((GObject)loader).isDisposed)
		{
			yield break;
		}
		loader.url = "ui://PublicResources/avatar_player_default";
		string png_path = UiHelper.GetUserAvatarLocalPath(userId.ToString());
		if (is_big)
		{
			png_path = UiHelper.GetUserBigAvatarLocalPath(userId.ToString());
			if (!File.Exists(png_path))
			{
				png_path = UiHelper.GetUserAvatarLocalPath(userId.ToString());
			}
		}
		if (!existed || !File.Exists(png_path))
		{
			yield return ((MonoBehaviour)this).StartCoroutine(EnsurePVPAvatarExist(userId, textField, textLength));
		}
		CoroutineWithData cd = new CoroutineWithData((MonoBehaviour)(object)this, HotFix_Utils.getTextureByPath(png_path));
		yield return cd.Coroutine;
		if (cd.Result != null && !((GObject)loader).isDisposed)
		{
			Texture2D _texture = (Texture2D)cd.Result;
			loader.texture = new NTexture((Texture)(object)_texture);
			AddNeedReleaseTexture2Ds(panelName, _texture);
		}
		else if (!((GObject)loader).isDisposed)
		{
			loader.url = "ui://PublicResources/avatar_player_default";
			if (textField != null && !((GObject)textField).isDisposed)
			{
				((GObject)textField).text = Instance.TruncateTextLength(RankDataHelper.UserId_Obfuscating(userId), textLength);
			}
		}
		if (textField != null && !((GObject)textField).isDisposed && !string.IsNullOrWhiteSpace(nickName))
		{
			((GObject)textField).text = Instance.TruncateTextLength(nickName, textLength);
		}
	}

	public IEnumerator EnsureSelfAvatarExist(Action action = null)
	{
		int userId = GameController.Contexts.gameState.user.value.UserId;
		string png_path = UiHelper.GetSelfAvatarLocalPath();
		string avatar_url = UiHelper.GetUserSelfAvatarHttpsUrl(userId);
		string avatar_pending_url = UiHelper.GetUserPendingAvatarHttpsUrl(userId);
		bool isPending = true;
		UnityWebRequest uwr_avatar = UnityWebRequest.Get(avatar_pending_url);
		uwr_avatar.timeout = 3;
		yield return uwr_avatar.SendWebRequest();
		if ((int)uwr_avatar.result != 1)
		{
			isPending = false;
			uwr_avatar.Dispose();
			uwr_avatar = UnityWebRequest.Get(avatar_url);
			uwr_avatar.timeout = 3;
			yield return uwr_avatar.SendWebRequest();
		}
		if ((int)uwr_avatar.result != 1)
		{
			ILRuntimeDebug.LogError($"u{userId} 网络异常 故无法拿到 avatar_url={avatar_url}");
			File.WriteAllBytes(png_path, new byte[0]);
			uwr_avatar.Dispose();
			yield break;
		}
		byte[] self_avatar_data = uwr_avatar.downloadHandler.data;
		UserProfileAvatar userProfile_avatar = null;
		if (uwr_avatar.isDone && self_avatar_data != null && self_avatar_data.Length != 0)
		{
			userProfile_avatar = self_avatar_data.Deserialize<UserProfileAvatar>();
		}
		if (userId > 0 && userProfile_avatar != null && userProfile_avatar.AvatarData != null && userProfile_avatar.AvatarData.Length != 0)
		{
			File.WriteAllBytes(png_path, userProfile_avatar.AvatarData);
		}
		else
		{
			File.WriteAllBytes(png_path, new byte[0]);
		}
		GameLocalDataManager.SelfLocalData _userLocalData = new GameLocalDataManager.SelfLocalData
		{
			ExpiredTime = GameController.Instance.GetServerTime() + 31536000
		};
		if (isPending)
		{
			_userLocalData.ExpiredTime = GameController.Instance.GetServerTime() + 3600;
			action?.Invoke();
		}
		_userLocalData.isPending = isPending;
		GameLocalDataManager.SetSelfUserLocalData(_userLocalData);
		uwr_avatar.Dispose();
	}

	private IEnumerator EnsurePVPAvatarExist(int userId, GTextField textField, int textLength)
	{
		string png_path = UiHelper.GetUserAvatarLocalPath(userId.ToString());
		string png_big_path = UiHelper.GetUserBigAvatarLocalPath(userId.ToString());
		string _NickName = RankDataHelper.UserId_Obfuscating(userId);
		if (textField != null && !((GObject)textField).isDisposed && !string.IsNullOrEmpty(((GObject)textField).text))
		{
			_NickName = ((GObject)textField).text;
		}
		string avatar_url = UiHelper.GetUserAvatarHttpsUrl(userId);
		string profile_url = UiHelper.GetUserProfileHttpsUrl(userId);
		string big_avatar_url = UiHelper.GetUserBigAvatarHttpsUrl(userId);
		if (textField != null && !((GObject)textField).isDisposed && string.IsNullOrEmpty(((GObject)textField).text))
		{
			UnityWebRequest uwr_profile = UnityWebRequest.Get(profile_url);
			try
			{
				uwr_profile.timeout = 3;
				yield return uwr_profile.SendWebRequest();
				if ((int)uwr_profile.result == 2 || (int)uwr_profile.result == 3)
				{
					File.WriteAllBytes(png_path, new byte[0]);
					File.WriteAllBytes(png_big_path, new byte[0]);
					GameLocalDataManager.SetSomeUserLocalData(_userLocalData: new GameLocalDataManager.UserLocalData
					{
						UserId = userId,
						NickName = _NickName,
						ModifiedDate = GameController.Instance.GetServerTime() + 1
					}, userId: userId);
					yield return null;
					yield break;
				}
				UserProfile userProfile = uwr_profile.downloadHandler.data.Deserialize<UserProfile>();
				if (userProfile != null)
				{
					_NickName = userProfile.Name;
					GameLocalDataManager.SetUserMedalData(userId, userProfile.Medals);
				}
			}
			finally
			{
				((IDisposable)uwr_profile)?.Dispose();
			}
		}
		UnityWebRequest uwr_big_avatar = UnityWebRequest.Get(big_avatar_url);
		try
		{
			uwr_big_avatar.timeout = 3;
			yield return uwr_big_avatar.SendWebRequest();
			UnityWebRequest uwr_avatar = UnityWebRequest.Get(avatar_url);
			try
			{
				uwr_avatar.timeout = 3;
				yield return uwr_avatar.SendWebRequest();
				if ((int)uwr_avatar.result == 2 || (int)uwr_avatar.result == 3 || (int)uwr_big_avatar.result == 2 || (int)uwr_big_avatar.result == 3)
				{
					File.WriteAllBytes(png_path, new byte[0]);
					File.WriteAllBytes(png_big_path, new byte[0]);
					GameLocalDataManager.SetSomeUserLocalData(_userLocalData: new GameLocalDataManager.UserLocalData
					{
						UserId = userId,
						NickName = _NickName,
						ModifiedDate = GameController.Instance.GetServerTime() + 1
					}, userId: userId);
					yield return null;
					yield break;
				}
				using (MemoryStreamManager.GetStream())
				{
					using (MemoryStreamManager.GetStream())
					{
						UserProfileAvatar userProfile_avatar = null;
						UserProfileAvatar userProfile_big_avatar = null;
						if (uwr_avatar.isDone && uwr_avatar.downloadHandler.data != null)
						{
							userProfile_avatar = uwr_avatar.downloadHandler.data.Deserialize<UserProfileAvatar>();
						}
						if (uwr_big_avatar.isDone && uwr_big_avatar.downloadHandler.data != null)
						{
							userProfile_big_avatar = uwr_big_avatar.downloadHandler.data.Deserialize<UserProfileAvatar>();
						}
						if (userId > 0 && userProfile_avatar != null && userProfile_avatar.AvatarData != null && userProfile_avatar.AvatarData.Length != 0)
						{
							File.WriteAllBytes(png_path, userProfile_avatar.AvatarData);
						}
						else
						{
							File.WriteAllBytes(png_path, new byte[0]);
						}
						if (userId > 0 && userProfile_big_avatar != null && userProfile_big_avatar.AvatarData != null && userProfile_big_avatar.AvatarData.Length != 0)
						{
							File.WriteAllBytes(png_big_path, userProfile_big_avatar.AvatarData);
						}
						else
						{
							File.WriteAllBytes(png_big_path, new byte[0]);
						}
						if (textField != null && !((GObject)textField).isDisposed)
						{
							((GObject)textField).text = Instance.TruncateTextLength(_NickName, textLength);
						}
						GameLocalDataManager.SetSomeUserLocalData(_userLocalData: new GameLocalDataManager.UserLocalData
						{
							UserId = userId,
							NickName = _NickName,
							ModifiedDate = UiHelper.GetUserAvatarExpireSeconds(userId)
						}, userId: userId);
					}
				}
				yield return null;
			}
			finally
			{
				((IDisposable)uwr_avatar)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)uwr_big_avatar)?.Dispose();
		}
	}

	public IEnumerator GetUserNickName(GObject panel, int userId, Action<string> callback, int textLength = 14)
	{
		if (panel == null || panel.isDisposed)
		{
			yield break;
		}
		if (userId == GameController.Contexts.gameState.user.value.UserId)
		{
			callback(TruncateTextLength(GameController.Contexts.gameState.user.value.Nickname, textLength));
			yield break;
		}
		GameLocalDataManager.UserLocalData userLocalData = GameLocalDataManager.GetSomeUserLocalData(userId);
		int curTime = (int)GameController.Instance.GetServerTime();
		if (userLocalData != null && curTime < (int)userLocalData.ModifiedDate && !string.IsNullOrWhiteSpace(userLocalData.NickName))
		{
			callback(TruncateTextLength(userLocalData.NickName, textLength));
			yield break;
		}
		yield return EnsureUserNickNameExist(userId);
		userLocalData = GameLocalDataManager.GetSomeUserLocalData(userId);
		callback(TruncateTextLength(userLocalData.NickName, textLength));
	}

	private IEnumerator EnsureUserNickNameExist(int userId)
	{
		string profile_url = UiHelper.GetUserProfileHttpsUrl(userId);
		UnityWebRequest uwr_profile = UnityWebRequest.Get(profile_url);
		try
		{
			uwr_profile.timeout = 3;
			yield return uwr_profile.SendWebRequest();
			if ((int)uwr_profile.result == 2 || (int)uwr_profile.result == 3)
			{
				GameLocalDataManager.UserLocalData _userLocalData = new GameLocalDataManager.UserLocalData
				{
					UserId = userId,
					NickName = RankDataHelper.UserId_Obfuscating(userId),
					ModifiedDate = GameController.Instance.GetServerTime() + 1
				};
				GameLocalDataManager.SetSomeUserLocalData(userId, _userLocalData);
				yield break;
			}
			UserProfile userProfile = uwr_profile.downloadHandler.data.Deserialize<UserProfile>();
			if (userProfile != null)
			{
				GameLocalDataManager.UserLocalData _userLocalData2 = new GameLocalDataManager.UserLocalData
				{
					UserId = userId,
					NickName = userProfile.Name,
					ModifiedDate = UiHelper.GetUserAvatarExpireSeconds(userId)
				};
				GameLocalDataManager.SetUserMedalData(userId, userProfile.Medals);
				GameLocalDataManager.SetSomeUserLocalData(userId, _userLocalData2);
			}
		}
		finally
		{
			((IDisposable)uwr_profile)?.Dispose();
		}
	}

	public IEnumerator EnsurePVPAvatarExist(int userId)
	{
		string png_path = UiHelper.GetUserAvatarLocalPath(userId.ToString());
		string png_big_path = UiHelper.GetUserBigAvatarLocalPath(userId.ToString());
		string _NickName = RankDataHelper.UserId_Obfuscating(userId);
		string avatar_url = UiHelper.GetUserAvatarHttpsUrl(userId);
		string profile_url = UiHelper.GetUserProfileHttpsUrl(userId);
		string big_avatar_url = UiHelper.GetUserBigAvatarHttpsUrl(userId);
		UnityWebRequest uwr_profile = UnityWebRequest.Get(profile_url);
		try
		{
			uwr_profile.timeout = 3;
			yield return uwr_profile.SendWebRequest();
			if ((int)uwr_profile.result == 2 || (int)uwr_profile.result == 3)
			{
				File.WriteAllBytes(png_path, new byte[0]);
				File.WriteAllBytes(png_big_path, new byte[0]);
				GameLocalDataManager.SetSomeUserLocalData(_userLocalData: new GameLocalDataManager.UserLocalData
				{
					UserId = userId,
					NickName = _NickName,
					ModifiedDate = GameController.Instance.GetServerTime() + 1
				}, userId: userId);
				yield return null;
				yield break;
			}
			UserProfile userProfile = uwr_profile.downloadHandler.data.Deserialize<UserProfile>();
			if (userProfile != null)
			{
				_NickName = userProfile.Name;
				GameLocalDataManager.SetUserMedalData(userId, userProfile.Medals);
			}
		}
		finally
		{
			((IDisposable)uwr_profile)?.Dispose();
		}
		UnityWebRequest uwr_big_avatar = UnityWebRequest.Get(big_avatar_url);
		try
		{
			uwr_big_avatar.timeout = 3;
			yield return uwr_big_avatar.SendWebRequest();
			UnityWebRequest uwr_avatar = UnityWebRequest.Get(avatar_url);
			try
			{
				uwr_avatar.timeout = 3;
				yield return uwr_avatar.SendWebRequest();
				if ((int)uwr_avatar.result == 2 || (int)uwr_avatar.result == 3 || (int)uwr_big_avatar.result == 2 || (int)uwr_big_avatar.result == 3)
				{
					File.WriteAllBytes(png_path, new byte[0]);
					File.WriteAllBytes(png_big_path, new byte[0]);
					GameLocalDataManager.SetSomeUserLocalData(_userLocalData: new GameLocalDataManager.UserLocalData
					{
						UserId = userId,
						NickName = _NickName,
						ModifiedDate = GameController.Instance.GetServerTime() + 1
					}, userId: userId);
					yield return null;
					yield break;
				}
				using (MemoryStreamManager.GetStream())
				{
					using (MemoryStreamManager.GetStream())
					{
						UserProfileAvatar userProfile_avatar = null;
						UserProfileAvatar userProfile_big_avatar = null;
						if (uwr_avatar.isDone && uwr_avatar.downloadHandler.data != null)
						{
							userProfile_avatar = uwr_avatar.downloadHandler.data.Deserialize<UserProfileAvatar>();
						}
						if (uwr_big_avatar.isDone && uwr_big_avatar.downloadHandler.data != null)
						{
							userProfile_big_avatar = uwr_big_avatar.downloadHandler.data.Deserialize<UserProfileAvatar>();
						}
						if (userId > 0 && userProfile_avatar != null && userProfile_avatar.AvatarData != null && userProfile_avatar.AvatarData.Length != 0)
						{
							File.WriteAllBytes(png_path, userProfile_avatar.AvatarData);
						}
						else
						{
							File.WriteAllBytes(png_path, new byte[0]);
						}
						if (userId > 0 && userProfile_big_avatar != null && userProfile_big_avatar.AvatarData != null && userProfile_big_avatar.AvatarData.Length != 0)
						{
							File.WriteAllBytes(png_big_path, userProfile_big_avatar.AvatarData);
						}
						else
						{
							File.WriteAllBytes(png_big_path, new byte[0]);
						}
						GameLocalDataManager.SetSomeUserLocalData(_userLocalData: new GameLocalDataManager.UserLocalData
						{
							UserId = userId,
							NickName = _NickName,
							ModifiedDate = UiHelper.GetUserAvatarExpireSeconds(userId)
						}, userId: userId);
					}
				}
			}
			finally
			{
				((IDisposable)uwr_avatar)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)uwr_big_avatar)?.Dispose();
		}
		yield return null;
	}

	public void GetImageFromLink(string url, Action<NTexture> onSuccess)
	{
		((MonoBehaviour)this).StartCoroutine(GetImageFromLinkCoroutine(url, onSuccess));
	}

	private IEnumerator GetImageFromLinkCoroutine(string url, Action<NTexture> onSuccess)
	{
		UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
		yield return request.SendWebRequest();
		if ((int)request.result == 2 || (int)request.result == 3)
		{
			yield return null;
			yield break;
		}
		Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
		onSuccess?.Invoke(new NTexture((Texture)(object)texture));
	}

	public static void SetIsTapTap(string channel)
	{
		int isTapTap;
		switch (channel)
		{
		default:
			isTapTap = ((channel == "gubulin-android") ? 1 : 0);
			break;
		case "taptap":
		case "tapplay":
		case "toutiao-android":
			isTapTap = 1;
			break;
		}
		IsTapTap = (byte)isTapTap != 0;
	}

	public void BattleAudioManagerInit()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		temp_BattleAudioManager = new GameObject();
		BattleAudioManager = temp_BattleAudioManager.AddComponent<BattleAudioManager>();
		((Object)temp_BattleAudioManager).name = "BattleAudioPlayManager";
		temp_BattleAudioManager.transform.position = new Vector3(0f, 0f, 0f);
		Object.DontDestroyOnLoad((Object)(object)temp_BattleAudioManager);
	}

	public IEnumerator DownloadGvG2ZipReplay(string battleId, Action<BattleRecordDetail, BattleRecordDetail, GetGvGBattleResultResponse> action = null)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		total_download_cnt = 0;
		retry_times = 0;
		List<string> file_names = new List<string> { "ret.bin", "GvGShipBattleRecordDetail_Blue.bytes", "GvGShipBattleRecordDetail_Red.bytes" };
		yield return ReplayDownloadManager.DownloadReplayZip(battleId, delegate(bool isSuccess)
		{
			if (!isSuccess)
			{
			}
		}, delegate(float progress)
		{
			float barValue = progress * 65f;
			UnityUiService.Instance.SetWaitingPanelDownloadProgress(barValue, LanguagesManager.GetDesc("CsharpCodeZhTcText52"));
		});
		yield return DownloadGvG2Replay(battleId, file_names, "", 0f, action);
	}

	public IEnumerator DownloadGvG2Replay(string battleId, List<string> queue, string downloading = "", float wait_tm = 0f, Action<BattleRecordDetail, BattleRecordDetail, GetGvGBattleResultResponse> action = null)
	{
		if (wait_tm > 0f)
		{
			yield return (object)new WaitForSeconds(0.2f);
		}
		else
		{
			yield return null;
		}
		if (queue.Count == 0)
		{
			yield break;
		}
		if (string.IsNullOrEmpty(downloading))
		{
			downloading = queue[0];
			queue.RemoveAt(0);
		}
		ReplayDownloadManager.DownloadReplay(battleId, downloading, delegate(bool isSucess)
		{
			if (!isSucess)
			{
				if (retry_times > 10)
				{
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
					List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText53") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText54") };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
				}
				else
				{
					retry_times++;
					Instance.OpenIEnumerator(DownloadGvG2Replay(battleId, queue, downloading, 0f, action));
				}
			}
			else
			{
				retry_times = 0;
				float num = 1f * (float)(total_download_cnt - queue.Count) / (float)total_download_cnt;
				float barValue = num * 35f + 65f;
				UnityUiService.Instance.SetWaitingPanelDownloadProgress(barValue);
				if (queue.Count == 0)
				{
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
					string battleReplayBasePath = ReplayDownloadManager.GetBattleReplayBasePath(battleId, "ret.bin");
					GetGvGBattleResultResponse gvG2BattleRecordData = GetGvG2BattleRecordData<GetGvGBattleResultResponse>(battleReplayBasePath);
					string battleReplayBasePath2 = ReplayDownloadManager.GetBattleReplayBasePath(battleId, "GvGShipBattleRecordDetail_Red.bytes");
					BattleRecordDetail gvG2BattleRecordData2 = GetGvG2BattleRecordData<BattleRecordDetail>(battleReplayBasePath2);
					string battleReplayBasePath3 = ReplayDownloadManager.GetBattleReplayBasePath(battleId, "GvGShipBattleRecordDetail_Blue.bytes");
					BattleRecordDetail gvG2BattleRecordData3 = GetGvG2BattleRecordData<BattleRecordDetail>(battleReplayBasePath3);
					action?.Invoke(gvG2BattleRecordData2, gvG2BattleRecordData3, gvG2BattleRecordData);
				}
				else
				{
					Instance.OpenIEnumerator(DownloadGvG2Replay(battleId, queue, "", 0f, action));
				}
			}
		});
	}

	private T GetGvG2BattleRecordData<T>(string jsonPath)
	{
		try
		{
			using FileStream fileStream = new FileStream(jsonPath, FileMode.Open, FileAccess.Read);
			fileStream.Seek(0L, SeekOrigin.Begin);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, (int)fileStream.Length);
			fileStream.Flush();
			fileStream.Dispose();
			fileStream.Close();
			if (array.Length == 0)
			{
				return default(T);
			}
			T val = default(T);
			return array.Deserialize<T>();
		}
		catch (Exception ex)
		{
			Debug.LogError((object)ex.Message);
			Debug.LogError((object)("GvG2BattleResultResponse文件读取异常：" + jsonPath));
			return default(T);
		}
	}

	public IEnumerator GetUserGvGBattleRecordDetailData(string battleId, string recordDetailRedDataHttpUrl, string recordDetailRedDataKey, string recordDetailBlueDataHttpUrl, string recordDetailBlueDataKey, Action<BattleRecordDetail, BattleRecordDetail, GetGvGBattleResultResponse> action)
	{
		CoroutineWithData cdRed = new CoroutineWithData((MonoBehaviour)(object)this, GetUserGvGBattleRecordDetailData(recordDetailRedDataHttpUrl, recordDetailRedDataKey));
		yield return cdRed.Coroutine;
		CoroutineWithData cdBlue = new CoroutineWithData((MonoBehaviour)(object)this, GetUserGvGBattleRecordDetailData(recordDetailBlueDataHttpUrl, recordDetailBlueDataKey));
		yield return cdBlue.Coroutine;
		if (cdRed.Result != null && cdBlue.Result != null)
		{
			BattleRecordDetail recordRedDetailData = (BattleRecordDetail)cdRed.Result;
			BattleRecordDetail recordBlueDetailData = (BattleRecordDetail)cdBlue.Result;
			CoroutineWithData getResultCd = new CoroutineWithData((MonoBehaviour)(object)this, DownloadZipReplay(battleId, "ret.bin", recordRedDetailData, recordBlueDetailData, 0f, action));
			yield return getResultCd.Coroutine;
		}
	}

	private IEnumerator GetUserGvGBattleRecordDetailData(string recordDetailDataHttpUrl, string recordDetailDataKey)
	{
		BattleRecordDetail recordDetailData = GameLocalDataManager.GetUserGvGRecordDetailLocalData(recordDetailDataKey);
		if (recordDetailData != null)
		{
			yield return recordDetailData;
			yield break;
		}
		UnityWebRequest uwr_profile = UnityWebRequest.Get(recordDetailDataHttpUrl);
		try
		{
			yield return uwr_profile.SendWebRequest();
			if ((int)uwr_profile.result == 2 || (int)uwr_profile.result == 3)
			{
				yield return null;
				yield break;
			}
			BattleRecordDetail result = uwr_profile.downloadHandler.data.Deserialize<BattleRecordDetail>();
			if (result != null)
			{
				GameLocalDataManager.SetUserGvGRecordDetailLocalData(recordDetailDataKey, result);
			}
			yield return result;
		}
		finally
		{
			((IDisposable)uwr_profile)?.Dispose();
		}
	}

	public IEnumerator DownloadZipReplay(string battleId, string gvgResultDataName, BattleRecordDetail recordRedDetailData, BattleRecordDetail recordBlueDetailData, float wait_tm = 0f, Action<BattleRecordDetail, BattleRecordDetail, GetGvGBattleResultResponse> action = null)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		yield return ReplayDownloadManager.DownloadReplayZip(battleId, delegate(bool isSuccess)
		{
			if (!isSuccess)
			{
			}
		}, delegate(float progress)
		{
			float barValue = progress * 65f;
			UnityUiService.Instance.SetWaitingPanelDownloadProgress(barValue, LanguagesManager.GetDesc("CsharpCodeZhTcText52"));
		});
		yield return DownloadNormalReplay(battleId, 0, recordRedDetailData, recordBlueDetailData, gvgResultDataName, 0f, action);
	}

	public IEnumerator DownloadNormalReplay(string battleId, int retry_times, BattleRecordDetail recordRedDetailData, BattleRecordDetail recordBlueDetailData, string downloading = "", float wait_tm = 0f, Action<BattleRecordDetail, BattleRecordDetail, GetGvGBattleResultResponse> action = null)
	{
		if (wait_tm > 0f)
		{
			yield return (object)new WaitForSeconds(0.2f);
		}
		else
		{
			yield return null;
		}
		ReplayDownloadManager.DownloadReplay(battleId, downloading, delegate(bool isSucess)
		{
			if (!isSucess)
			{
				if (retry_times > 10)
				{
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
					List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText53") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText54") };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
				}
				else
				{
					retry_times++;
					Instance.OpenIEnumerator(DownloadNormalReplay(battleId, retry_times, recordRedDetailData, recordBlueDetailData, downloading, 0.2f));
				}
			}
			else
			{
				string battleReplayBasePath = ReplayDownloadManager.GetBattleReplayBasePath(battleId, downloading);
				GetGvGBattleResultResponse gvGBattleRecordResultData = GetGvGBattleRecordResultData(battleReplayBasePath);
				if (gvGBattleRecordResultData != null)
				{
					action?.Invoke(recordRedDetailData, recordBlueDetailData, gvGBattleRecordResultData);
				}
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			}
		});
	}

	private GetGvGBattleResultResponse GetGvGBattleRecordResultData(string jsonPath)
	{
		try
		{
			using FileStream fileStream = new FileStream(jsonPath, FileMode.Open, FileAccess.Read);
			fileStream.Seek(0L, SeekOrigin.Begin);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, (int)fileStream.Length);
			fileStream.Flush();
			fileStream.Dispose();
			fileStream.Close();
			if (array.Length == 0)
			{
				return null;
			}
			return array.Deserialize<GetGvGBattleResultResponse>();
		}
		catch (Exception ex)
		{
			Debug.LogError((object)ex.Message);
			Debug.LogError((object)("GvGBattleResultResponse文件读取异常：" + jsonPath));
			return null;
		}
	}

	public void UpdateConfigsGVGDisable()
	{
		int num = (int)GameController.Instance.GetServerTime();
		if (num - lastUpdateGVGDisableTimestamp > 60)
		{
			Instance.OpenIEnumerator(HotUpdateProcess.Instance.UpdateGvGConfigs());
			lastUpdateGVGDisableTimestamp = num;
		}
	}
}
