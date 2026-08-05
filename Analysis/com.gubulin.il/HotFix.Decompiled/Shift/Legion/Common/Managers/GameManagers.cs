using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Managers;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Managers;

public class GameManagers
{
	public static Dictionary<string, string> Configs = new Dictionary<string, string>();

	public Dictionary<string, object> CacheData = new Dictionary<string, object>();

	public Dictionary<long, object> LongCacheData = new Dictionary<long, object>();

	public static GameManagers Instance;

	private bool _initialized;

	public const int ManagersCount = 35;

	private readonly List<Manager> _managers;

	public RandomManager RandomManager;

	public UserArchiveManager UserArchiveManager;

	public StockController StockController;

	public BuildingManager BuildingManager;

	public ChapterManager ChapterManager;

	public ConfigDataManager ConfigDataManager;

	public CustomScriptManager CustomScriptManager;

	public FormationManager FormationManager;

	public LotteryManager LotteryManager;

	public NewGuideModeManager NewGuideMissionManager;

	public MissionManager MissionManager;

	public ModifierManager ModifierManager;

	public ProduceManager ProduceManager;

	public RecycleManager RecycleManager;

	public RecruitingCampDataManager RecruitingCampDataManager;

	public SoldierLevelManager SoldierLevelManager;

	public SoldierStuffIsReadyManager SoldierStuffIsReadyManager;

	public TechnologyManager TechnologyManager;

	public TriggerManager TriggerManager;

	public WorldMapManager WorldMapManager;

	public ActivityManager ActivityManager;

	public LeaseholdManager LeaseholdManager;

	public StoreManager StoreManager;

	public PiecesManager PiecesManager;

	public FormationUnitsManager FormationUnitsManager;

	public SoldierManager SoldierManager;

	public FriendsManager FriendsManager;

	public AchievementManager AchievementManager;

	public StoryManager StoryManager;

	public LegendItemManager LegendItemManager;

	public SoldierEquipmentManager SoldierEquipmentManager;

	public BlueprintLockManager BpLockManager;

	public InventoryManager InventoryManager;

	public SoldierItemSlotsManager SoldierItemSlotsManager;

	public MailManager MailManager;

	public FriendsChatManager FriendsChatManager;

	public NewMsgIncomingManager NewMsgIncomingManager;

	public Messenger Messenger;

	public CharacterArchive Archive;

	public List<UserData> CommonSettings;

	public CharacterArchive LocalArchive;

	private static readonly object Locker = new object();

	public int UserId => Archive.UserId;

	public bool Initialized => _initialized;

	public GameManagers(Messenger messenger)
	{
		Messenger = messenger;
		_managers = new List<Manager>();
	}

	public void Init(Action callback)
	{
		if (!_initialized)
		{
			FGUIManager.Instance.OpenIEnumerator(StartCoroutine_Init(callback));
		}
	}

	private IEnumerator StartCoroutine_Init(Action callback)
	{
		_ = StockController.StorehouseDataDictionary;
		yield return null;
		_ = StockController.CategorizedStorehouseData;
		yield return null;
		_ = BuildingManager.BuildingTypes;
		yield return null;
		_ = BuildingManager.ProductIDs;
		yield return null;
		_ = BuildingManager.BuildingEvoDataDictionary;
		yield return null;
		_ = ChapterManager.Chapters;
		yield return null;
		_ = ChapterManager.RegionChaptersDict;
		yield return null;
		_ = ConfigDataManager.PiecesDataByType;
		yield return null;
		_ = ConfigDataManager.SoldierPiecesData;
		yield return null;
		_ = ConfigDataManager.SoldierEvoData;
		yield return null;
		_ = ConfigDataManager.SoldierPotentialDataDict;
		yield return null;
		_ = ConfigDataManager.ItemsByType;
		yield return null;
		_ = ConfigDataManager.VolunteersOnSoldierUnlock;
		yield return null;
		_ = TechnologyManager.TechnologyKeys;
		yield return null;
		_ = TechnologyManager.TechnologyEffectDataDictionary;
		yield return null;
		_ = TechnologyManager.DoomTechnologies;
		yield return null;
		_ = TechnologyManager.DominionTechnologies;
		yield return null;
		_ = TechnologyManager.SlaveryTechnologies;
		yield return null;
		_ = StoryManager.StoryLines;
		yield return null;
		_ = PiecesManager.PiecesDict;
		yield return null;
		_ = PiecesManager.TypedPiecesDict;
		yield return null;
		_ = PiecesManager.SoldierSoulStoneDict;
		yield return null;
		_ = Shift.Legion.Common.Models.Item.CollectableItemList;
		yield return null;
		_ = Shift.Legion.Common.Models.Item.ItemKeys;
		yield return null;
		_ = StoryScript.StoryCache;
		yield return null;
		_ = WorldMapManager.Strongholds;
		yield return null;
		_ = WorldMapManager.Regions;
		yield return null;
		_ = AchievementManager.Achievements;
		yield return null;
		_ = SoldierLevelManager.ExpValueList;
		yield return null;
		_ = MissionManager.Missions;
		yield return null;
		_ = ActivityManager.Activities;
		yield return null;
		_ = ActivityManager.CategorizedActivities;
		yield return null;
		_ = RecycleManager.RecycleProducts;
		yield return null;
		_ = RecycleManager.RecycleProductsByItemId;
		yield return null;
		_ = FormationManager.Formations;
		yield return null;
		_ = SoldierItemSlotsManager.UnlockConditions;
		yield return null;
		_ = SoldierItemSlotsManager.UnlockRequirements;
		yield return null;
		Singleton<AnimationManager>.Instance.InitInstance();
		yield return null;
		_initialized = true;
		FieldInfo[] fields = typeof(GameManagers).GetFields();
		FieldInfo[] array = fields;
		foreach (FieldInfo fieldInfo in array)
		{
			if (fieldInfo.FieldType.IsSubclassOf(typeof(Manager)))
			{
				Manager instance = (Manager)Activator.CreateInstance(fieldInfo.FieldType, this);
				fieldInfo.SetValue(this, instance);
				_managers.Add(instance);
				yield return null;
			}
		}
		callback?.Invoke();
	}

	public void AddEventListeners()
	{
		foreach (Manager manager in _managers)
		{
			manager.AddEventListener();
		}
	}

	public void RemoveEventListeners()
	{
		foreach (Manager manager in _managers)
		{
			manager.RemoveEventListener();
		}
	}

	public async Task InitManagers()
	{
		foreach (Manager manager in _managers)
		{
			try
			{
				Task task = manager.Init();
				if (task != null)
				{
					await task;
				}
			}
			catch (Exception ex)
			{
				ILRuntimeDebug.LogError(ex.ToString());
			}
			SharedMessenger.Broadcast("GET_PROGRESSBAR_NUM");
		}
	}

	public static void PreLoadStaticData()
	{
		lock (Locker)
		{
			Dictionary<string, GDEStorehouseData> storehouseDataDictionary = StockController.StorehouseDataDictionary;
			Dictionary<int, List<GDEStorehouseData>> categorizedStorehouseData = StockController.CategorizedStorehouseData;
			List<string> buildingTypes = BuildingManager.BuildingTypes;
			List<string> productIDs = BuildingManager.ProductIDs;
			Dictionary<string, Dictionary<int, BuildingEvoData>> buildingEvoDataDictionary = BuildingManager.BuildingEvoDataDictionary;
			Dictionary<string, Chapter> chapters = ChapterManager.Chapters;
			Dictionary<string, List<Chapter>> regionChaptersDict = ChapterManager.RegionChaptersDict;
			Dictionary<PiecesType, List<Pieces>> piecesDataByType = ConfigDataManager.PiecesDataByType;
			Dictionary<string, Pieces> soldierPiecesData = ConfigDataManager.SoldierPiecesData;
			Dictionary<string, Dictionary<int, SoldierEvoData>> soldierEvoData = ConfigDataManager.SoldierEvoData;
			Dictionary<string, Dictionary<int, SoldierPotentialData>> soldierPotentialDataDict = ConfigDataManager.SoldierPotentialDataDict;
			Dictionary<string, ProductEvoData> productEvoData = ConfigDataManager.ProductEvoData;
			Dictionary<ItemType, List<string>> itemsByType = ConfigDataManager.ItemsByType;
			List<string> technologyKeys = TechnologyManager.TechnologyKeys;
			Dictionary<string, Dictionary<int, List<GDETechnologyEffectData>>> technologyEffectDataDictionary = TechnologyManager.TechnologyEffectDataDictionary;
			List<string> doomTechnologies = TechnologyManager.DoomTechnologies;
			List<string> dominionTechnologies = TechnologyManager.DominionTechnologies;
			List<string> slaveryTechnologies = TechnologyManager.SlaveryTechnologies;
			Dictionary<string, List<string>> storyLines = StoryManager.StoryLines;
			Dictionary<string, Pieces> piecesDict = PiecesManager.PiecesDict;
			Dictionary<PiecesType, List<Pieces>> typedPiecesDict = PiecesManager.TypedPiecesDict;
			Dictionary<string, List<Pieces>> soldierSoulStoneDict = PiecesManager.SoldierSoulStoneDict;
			List<string> collectableItemList = Shift.Legion.Common.Models.Item.CollectableItemList;
			List<string> itemKeys = Shift.Legion.Common.Models.Item.ItemKeys;
			Dictionary<string, Stronghold> strongholds = WorldMapManager.Strongholds;
			Dictionary<string, Region> regions = WorldMapManager.Regions;
			Dictionary<string, Achievement> achievements = AchievementManager.Achievements;
			List<int> expValueList = SoldierLevelManager.ExpValueList;
			Dictionary<string, Mission> missions = MissionManager.Missions;
			Dictionary<string, Activity> activities = ActivityManager.Activities;
			Dictionary<ActivityType, List<Activity>> categorizedActivities = ActivityManager.CategorizedActivities;
			Dictionary<string, RecycleProduct> recycleProducts = RecycleManager.RecycleProducts;
			Dictionary<string, List<RecycleProduct>> recycleProductsByItemId = RecycleManager.RecycleProductsByItemId;
			Dictionary<string, Formation> formations = FormationManager.Formations;
			Dictionary<string, AttrCheckConf[]> unlockConditions = SoldierItemSlotsManager.UnlockConditions;
			Dictionary<string, Dictionary<int, List<ResourceRequirement>>> unlockRequirements = SoldierItemSlotsManager.UnlockRequirements;
		}
	}

	public T GetDataInMemory<T>(string key, Func<T> defaultValue = null)
	{
		if (!CacheData.TryGetValue(key, out var value))
		{
			return (defaultValue != null) ? defaultValue() : default(T);
		}
		return (T)value;
	}

	public async Task<T> GetDataInMemoryAsync<T>(string key, Func<Task<T>> defaultValue = null)
	{
		if (CacheData.TryGetValue(key, out var value))
		{
			return (T)value;
		}
		if (defaultValue == null)
		{
			return default(T);
		}
		value = await defaultValue();
		CacheData[key] = value;
		return (T)value;
	}

	public T GetDataInMemory<T>(long key, Func<T> defaultValue = null)
	{
		if (!LongCacheData.TryGetValue(key, out var value))
		{
			return (defaultValue != null) ? defaultValue() : default(T);
		}
		return (T)value;
	}

	public async Task<T> GetDataInMemoryAsync<T>(long key, Func<Task<T>> defaultValue = null)
	{
		if (LongCacheData.TryGetValue(key, out var value))
		{
			return (T)value;
		}
		if (defaultValue == null)
		{
			return default(T);
		}
		value = await defaultValue();
		LongCacheData[key] = value;
		return (T)value;
	}
}
