using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDataEditor;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.UI;
using HotFix.Sources.Base.Scripts.UI.GameActivity.NestingGiftBag;
using HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi;
using HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol.UserAction;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;
using UI.ReturningRewards;

namespace Shift.Legion.Common.Managers;

public class ActivityManager : Manager
{
	private const string DefaultActivityKey = "DEFAULT_ACTIVITY";

	private const string DefaultActivityContentKey = "DEFAULT_ACTIVITY_CONTENT";

	private const string CurrentInstanceActivityRecordKey = "CurrentInstanceActivityRecord";

	private const string ActivityResetStatsKey = "ActivityResetStats";

	private const string ActivityMaxDifficultyLevelsKey = "ActivityMaxDifficultyLevels";

	private const string ActivityDifficultyLevelsKey = "ActivityDifficultyLevels";

	private const string OffensiveActivityResetWithout5StarLevelStatsKey = "OffensiveActivityResetWithout5StarLevelStats";

	private const string ActivityProgressKeyPrefix = "Activity_";

	private static Dictionary<string, Activity> _activities;

	public static List<string> LocaleActivities = new List<string> { "GiftPackMerchant" };

	private Dictionary<string, LotteryActivityProgress> _legendItemLotteryActivityProgresses;

	private readonly HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi.ActivityEntranceController _activityEntranceController = new HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi.ActivityEntranceController();

	private readonly ActivityEntranceRedDotController _activityEntranceRedDotController = new ActivityEntranceRedDotController();

	private static Dictionary<ActivityType, List<Activity>> _categorizedActivities;

	private static Dictionary<ActivityType, List<Activity>> _singletonActivitiesIndexByType;

	private Config<List<string>> _defaultActivities;

	private Config<Dictionary<string, Dictionary<string, List<string>>>> _defaultActivityContent;

	private Config<Dictionary<string, string>> _currentSingletonActivityRecord;

	private Config<Dictionary<string, int>> _offensiveActivityResetWithout5StarLevelStats;

	private Config<ActivityResetStatsConfig> _activityResetStats;

	private Config<Dictionary<string, int>> _activityMaxDifficultyLevels;

	private Config<Dictionary<string, int>> _activityDifficultyLevels;

	public static Activity ProgressionMission;

	public static Activity ChallengeMission;

	public static GetWeeklyActivityResponse SpinWeekActivity;

	public static List<Activity> WeekActPasses = new List<Activity>();

	public static Activity ShadowDemonGift;

	public static Action<string> RemoveActivityNewMsgIncoming;

	public static Action<string> AddActivityNewMsgIncoming;

	private readonly List<Activity> _buffer = new List<Activity>();

	private bool _isCheckingActivities = false;

	private int _preventLockCnt = 0;

	public static Func<List<string>, List<ActivityType>, Task<CheckActivitiesOverPeriodResponse>> SendCheckActivitiesOverPeriodRequest;

	private Dictionary<string, Activity> _cache_LevelActivity = null;

	private bool LevelActivityDataOnUpdating;

	public static Func<List<string>, Task<ActivityReviewResponse>> SendActivitiesReviewRequest;

	private const string DEPARTURE_GIFTS = "DepartureGifts";

	private const string DEPARTURE_GIFTS_GUIDE5 = "DepartureGiftsGuide5";

	private const string DEPARTURE_GIFTS_GUIDE6 = "DepartureGiftsGuide6";

	private const string DEPARTURE_GIFTS_GUIDE7 = "DepartureGiftsGuide7";

	public List<NestingGiftBags> DepartureGift;

	private readonly RecallWelfareWrapper _recallWelfareWrapper = new RecallWelfareWrapper();

	public static Dictionary<string, Activity> Activities
	{
		get
		{
			if (_activities == null)
			{
				DateTimeOffset serverNow = DateTimeHelper.ServerNow;
				_activities = new Dictionary<string, Activity>();
				foreach (GDEActivityData activityData in GDMgr.GetAllItems<GDEActivityData>())
				{
					if (activityData.EndTime != null && activityData.EndTime.Count > 0 && DateTimeHelper.TryParse(activityData.EndTime[0], out var dateTime) && serverNow > dateTime)
					{
						continue;
					}
					if (activityData.Status == 0)
					{
						int type = activityData.Type;
						int num = type;
						if ((uint)(num - 21) <= 1u)
						{
							continue;
						}
					}
					string text = LocaleActivities.FirstOrDefault((string localActivityId) => activityData.Key.StartsWith(localActivityId));
					if (!string.IsNullOrEmpty(text))
					{
						if (HotUpdateProcess.Instance.IsRegionOutCN)
						{
							if (activityData.Key != text + "_" + HotUpdateProcess.RegionKey)
							{
								continue;
							}
						}
						else if (activityData.Key != text)
						{
							continue;
						}
					}
					Activity activity = new Activity(activityData);
					_activities.Add(activityData.Key, activity);
					OnActivityInit(activity);
				}
				_categorizedActivities = null;
				_singletonActivitiesIndexByType = null;
			}
			return _activities;
		}
	}

	public Dictionary<string, LotteryActivityProgress> LegendItemLotteryActivityProgresses
	{
		get
		{
			if (_legendItemLotteryActivityProgresses == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				string key = "Activity_" + ActivityType.LegendItemLottery;
				if (userArchiveManager.Contains(key))
				{
					_legendItemLotteryActivityProgresses = userArchiveManager.GetConfig<List<LotteryActivityProgress>>(key).GetValue().ToDictionary((LotteryActivityProgress progress) => progress.ActivityId, (LotteryActivityProgress progress) => progress);
				}
				else
				{
					_legendItemLotteryActivityProgresses = new Dictionary<string, LotteryActivityProgress>();
				}
			}
			return _legendItemLotteryActivityProgresses;
		}
	}

	public HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi.ActivityEntranceController EntranceController => _activityEntranceController;

	public ActivityEntranceRedDotController RedDotController => _activityEntranceRedDotController;

	public static Dictionary<ActivityType, List<Activity>> CategorizedActivities
	{
		get
		{
			if (_categorizedActivities == null)
			{
				CategorizeActivities();
			}
			return _categorizedActivities;
		}
	}

	public static Dictionary<ActivityType, List<Activity>> SingletonActivitiesIndexByType
	{
		get
		{
			if (_singletonActivitiesIndexByType == null)
			{
				CategorizeActivities();
			}
			return _singletonActivitiesIndexByType;
		}
	}

	public Config<List<string>> DefaultActivities
	{
		get
		{
			if (_defaultActivities == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("DEFAULT_ACTIVITY"))
				{
					userArchiveManager.SetConfigValue("DEFAULT_ACTIVITY", new List<string>());
				}
				_defaultActivities = userArchiveManager.GetConfig<List<string>>("DEFAULT_ACTIVITY");
			}
			return _defaultActivities;
		}
	}

	public Config<Dictionary<string, Dictionary<string, List<string>>>> DefaultActivityContent
	{
		get
		{
			if (_defaultActivityContent == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("DEFAULT_ACTIVITY_CONTENT"))
				{
					userArchiveManager.SetConfigValue("DEFAULT_ACTIVITY_CONTENT", new Dictionary<string, Dictionary<string, List<string>>>());
				}
				_defaultActivityContent = userArchiveManager.GetConfig<Dictionary<string, Dictionary<string, List<string>>>>("DEFAULT_ACTIVITY_CONTENT");
			}
			return _defaultActivityContent;
		}
	}

	public Config<Dictionary<string, string>> CurrentSingletonActivityRecord
	{
		get
		{
			if (_currentSingletonActivityRecord == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("CurrentInstanceActivityRecord"))
				{
					userArchiveManager.SetConfigValue("CurrentInstanceActivityRecord", new Dictionary<string, string>());
				}
				_currentSingletonActivityRecord = userArchiveManager.GetConfig<Dictionary<string, string>>("CurrentInstanceActivityRecord");
			}
			return _currentSingletonActivityRecord;
		}
	}

	public Config<Dictionary<string, int>> OffensiveActivityResetWithout5StarLevelStats
	{
		get
		{
			if (_offensiveActivityResetWithout5StarLevelStats == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("OffensiveActivityResetWithout5StarLevelStats"))
				{
					userArchiveManager.SetConfigValue("OffensiveActivityResetWithout5StarLevelStats", new Dictionary<string, int>());
				}
				_offensiveActivityResetWithout5StarLevelStats = userArchiveManager.GetConfig<Dictionary<string, int>>("OffensiveActivityResetWithout5StarLevelStats");
			}
			return _offensiveActivityResetWithout5StarLevelStats;
		}
	}

	public Config<ActivityResetStatsConfig> ActivityResetStats
	{
		get
		{
			if (_activityResetStats == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("ActivityResetStats"))
				{
					userArchiveManager.SetConfigValue("ActivityResetStats", new ActivityResetStatsConfig());
				}
				_activityResetStats = userArchiveManager.GetConfig<ActivityResetStatsConfig>("ActivityResetStats");
			}
			_activityResetStats.GetValue().CheckDate();
			_activityResetStats.Save();
			return _activityResetStats;
		}
	}

	public Config<Dictionary<string, int>> ActivityMaxDifficultyLevels
	{
		get
		{
			if (_activityMaxDifficultyLevels == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("ActivityMaxDifficultyLevels"))
				{
					userArchiveManager.SetConfigValue("ActivityMaxDifficultyLevels", new Dictionary<string, int>());
				}
				_activityMaxDifficultyLevels = userArchiveManager.GetConfig<Dictionary<string, int>>("ActivityMaxDifficultyLevels");
			}
			return _activityMaxDifficultyLevels;
		}
	}

	public Config<Dictionary<string, int>> ActivityDifficultyLevels
	{
		get
		{
			if (_activityDifficultyLevels == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("ActivityDifficultyLevels"))
				{
					userArchiveManager.SetConfigValue("ActivityDifficultyLevels", new Dictionary<string, int>());
				}
				_activityDifficultyLevels = userArchiveManager.GetConfig<Dictionary<string, int>>("ActivityDifficultyLevels");
			}
			return _activityDifficultyLevels;
		}
	}

	public static bool DebugOverPeriodValue { get; set; }

	private static void CategorizeActivities()
	{
		if (_categorizedActivities == null)
		{
			_categorizedActivities = new Dictionary<ActivityType, List<Activity>>();
		}
		else
		{
			_categorizedActivities.Clear();
		}
		if (_singletonActivitiesIndexByType == null)
		{
			_singletonActivitiesIndexByType = new Dictionary<ActivityType, List<Activity>>();
		}
		else
		{
			_singletonActivitiesIndexByType.Clear();
		}
		foreach (Activity value in Activities.Values)
		{
			if (!_categorizedActivities.ContainsKey(value.Type))
			{
				_categorizedActivities.Add(value.Type, new List<Activity>());
			}
			_categorizedActivities[value.Type].Add(value);
			if (value.Data.Singleton)
			{
				if (!_singletonActivitiesIndexByType.ContainsKey(value.Type))
				{
					_singletonActivitiesIndexByType.Add(value.Type, new List<Activity>());
				}
				_singletonActivitiesIndexByType[value.Type].Add(value);
			}
		}
	}

	public ActivityManager(GameManagers managers)
		: base(managers)
	{
	}

	public override async Task Init()
	{
		InitDepartureGift();
		await FGUIManager.Instance.GetDynamicSecretTreasuryActivity();
		await ActivityEntranceStatic.GetSpinWeekActivity();
	}

	public override void AddEventListener()
	{
		Managers.Messenger.AddListener<Level>("BATTLE_START", OnBattleStart);
		Managers.Messenger.AddListener<string, bool>("CHAPTER_COMPLETE", OnChapterComplete);
		Managers.Messenger.AddListener<string, Level, Team, bool>("LEVEL_COMPLETED", OnLevelComplete);
		Managers.Messenger.AddListener<string>("SOLDIER_UNLOCKED", OnSoldierUnlock);
		Managers.Messenger.AddListener<string, ActivityStatus>("ACTIVITY_STATUS_CHANGED", OnActivityStatusChanged);
		Managers.Messenger.AddListener<int>("USER_LEVEL_UP", OnUserLevelUp);
		Managers.Messenger.AddListener<int>("DUNGEON_LEVEL_UP", OnDungeonLevelUp);
		Managers.Messenger.AddListener<Level, Team>("BEFORE_LEVEL_COMPLETED", OnBeforeLevelCompleted);
		Managers.Messenger.AddListener("ON_PURCHASE_STATS", OnPurchaseStats);
		SharedMessenger.AddListener<PushItem>("ON_PING_PUSH_ITEM", _recallWelfareWrapper.OnPingPushItem);
		SharedMessenger.AddListener<PushItem>("ON_PING_PUSH_ITEM", OnPingPushItem);
		SharedMessenger.AddListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", _recallWelfareWrapper.OrderShipSuccessEvent);
		Managers.Messenger.AddListener<float>("ON_RECHARGE", CheckTotalRecharge);
	}

	public override void RemoveEventListener()
	{
		Managers.Messenger.RemoveListener<Level>("BATTLE_START", OnBattleStart);
		Managers.Messenger.RemoveListener<string, bool>("CHAPTER_COMPLETE", OnChapterComplete);
		Managers.Messenger.RemoveListener<string, Level, Team, bool>("LEVEL_COMPLETED", OnLevelComplete);
		Managers.Messenger.RemoveListener<string>("SOLDIER_UNLOCKED", OnSoldierUnlock);
		Managers.Messenger.RemoveListener<string, ActivityStatus>("ACTIVITY_STATUS_CHANGED", OnActivityStatusChanged);
		Managers.Messenger.RemoveListener<int>("USER_LEVEL_UP", OnUserLevelUp);
		Managers.Messenger.RemoveListener<int>("DUNGEON_LEVEL_UP", OnDungeonLevelUp);
		Managers.Messenger.RemoveListener<Level, Team>("BEFORE_LEVEL_COMPLETED", OnBeforeLevelCompleted);
		Managers.Messenger.RemoveListener("ON_PURCHASE_STATS", OnPurchaseStats);
		SharedMessenger.RemoveListener<PushItem>("ON_PING_PUSH_ITEM", _recallWelfareWrapper.OnPingPushItem);
		SharedMessenger.RemoveListener<PushItem>("ON_PING_PUSH_ITEM", OnPingPushItem);
		SharedMessenger.RemoveListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", _recallWelfareWrapper.OrderShipSuccessEvent);
		Managers.Messenger.RemoveListener<float>("ON_RECHARGE", CheckTotalRecharge);
	}

	private void OnBattleStart(Level level)
	{
		if (level.ParentLevel != null)
		{
			return;
		}
		Activity levelActivity = GetLevelActivity(level);
		if (levelActivity != null)
		{
			List<string> value = DefaultActivities.GetValue();
			if (value.Remove(levelActivity.ActivityId))
			{
				DefaultActivities.Save();
			}
			Dictionary<string, Dictionary<string, List<string>>> value2 = DefaultActivityContent.GetValue();
			if (value2.Remove(levelActivity.ActivityId))
			{
				DefaultActivityContent.Save();
			}
		}
	}

	private void OnMissionCompleted(Mission mission)
	{
		Dictionary<string, float> finalClaimed;
		if (mission.MissionType == MissionType.Weekly)
		{
			List<Activity> activitiesByType = GetActivitiesByType(ActivityType.BattlePass);
			bool flag = false;
			foreach (Activity item in activitiesByType)
			{
				if (item.GetStatus(Managers) == ActivityStatus.Enabled)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				mission.Claim(Managers, out finalClaimed);
			}
		}
		if (mission.MissionType != MissionType.DailyMission)
		{
			return;
		}
		List<Activity> activitiesByType2 = GetActivitiesByType(ActivityType.WeekActPass);
		bool flag2 = false;
		foreach (Activity item2 in activitiesByType2)
		{
			if (item2.GetStatus(Managers) == ActivityStatus.Enabled)
			{
				flag2 = true;
				break;
			}
		}
		if (flag2)
		{
			mission.Claim(Managers, out finalClaimed);
		}
	}

	private void OnChapterComplete(string chapterId, bool newCompleteFlag)
	{
		foreach (List<Activity> value2 in CategorizedActivities.Values)
		{
			foreach (Activity item in value2)
			{
				if (item.ContentType == ActivityContentType.Chapter && item.GetStatus(Managers) == ActivityStatus.Enabled && item.ContentPayload(Managers).TryGetValue(chapterId, out var value))
				{
					((ChapterActivityPayload)value).OnChapterComplete(Managers, newCompleteFlag);
				}
			}
		}
	}

	private void OnLevelComplete(string battleId, Level level, Team winner, bool newCompleteFlag)
	{
		if (winner == Team.Red)
		{
			CheckAllStatus();
			foreach (List<Activity> value in CategorizedActivities.Values)
			{
				foreach (Activity item in value)
				{
					if (item.ContentType == ActivityContentType.MissionSerial && item.GetStatus(Managers) == ActivityStatus.Enabled)
					{
						TryPickUpActivityMissions(item);
					}
				}
			}
		}
		if (level.ParentLevel == null)
		{
			Activity levelActivity = GetLevelActivity(level);
			if (levelActivity != null)
			{
			}
		}
	}

	private void OnSoldierUnlock(string soldierId)
	{
		CheckAllStatus();
	}

	private void ProcessActivityWithStatusDisabled(Activity activity)
	{
		foreach (KeyValuePair<string, ActivityContentPayload> item in activity.ContentPayload(Managers))
		{
			if (!(item.Value is ChapterActivityPayload chapterActivityPayload))
			{
				continue;
			}
			List<Level> list = chapterActivityPayload.Levels(Managers);
			foreach (Level item2 in list)
			{
				Managers.UserArchiveManager.RemoveLevelEnemiesHp(item2);
			}
		}
		List<string> value = DefaultActivities.GetValue();
		if (value.Remove(activity.ActivityId))
		{
			DefaultActivities.Save();
		}
		if (activity.Data.Singleton)
		{
			Activity currentSingletonActivityByType = GetCurrentSingletonActivityByType(activity.Type);
			if (currentSingletonActivityByType == null || currentSingletonActivityByType.ActivityId == activity.ActivityId)
			{
				RePickSingletonActivityByType(activity.Type);
			}
		}
		Managers.UserArchiveManager.RemoveActivityProgress(activity.ActivityId);
		RemoveActivityNewMsgIncoming(activity.ActivityId);
	}

	private void OnActivityStatusChanged(string activityId, ActivityStatus status)
	{
		UpdateLevelActivityCache(activityId);
		if (!Activities.TryGetValue(activityId, out var value))
		{
			return;
		}
		if (status == ActivityStatus.Disabled)
		{
			ProcessActivityWithStatusDisabled(value);
		}
		else if (status == ActivityStatus.Underline || status == ActivityStatus.Enabled || status == ActivityStatus.Settlement)
		{
			AddActivityNewMsgIncoming(value.ActivityId);
		}
		if (status == ActivityStatus.Enabled)
		{
			Shift.Legion.Common.Models.ActivityConfig activityConfig = value.ActivityProgress(Managers);
			if (value.Data.DynamicBeginTime && activityConfig.BeginAt == default(DateTimeOffset))
			{
				activityConfig.BeginAt = DateTimeHelper.Now;
			}
		}
	}

	public void OnUserLevelUp(int newLevel)
	{
		foreach (List<Activity> value in CategorizedActivities.Values)
		{
			foreach (Activity item in value)
			{
				if (item.ContentType == ActivityContentType.MissionSerial && item.GetStatus(Managers) == ActivityStatus.Enabled)
				{
					TryPickUpActivityMissions(item);
				}
			}
		}
	}

	public void OnDungeonLevelUp(int newLevel)
	{
		foreach (List<Activity> value in CategorizedActivities.Values)
		{
			foreach (Activity item in value)
			{
				if (item.ContentType == ActivityContentType.MissionSerial && item.GetStatus(Managers) == ActivityStatus.Enabled)
				{
					TryPickUpActivityMissions(item);
				}
			}
		}
	}

	public void OnStockChange(string itemId, int incrBy, (StockInContext, string) contextTuple)
	{
		foreach (List<Activity> value in CategorizedActivities.Values)
		{
			foreach (Activity item in value)
			{
				if (item.ContentType == ActivityContentType.MissionSerial && item.GetStatus(Managers) == ActivityStatus.Enabled)
				{
					TryPickUpActivityMissions(item);
				}
			}
		}
	}

	private void CheckAllStatus()
	{
		ActivityType[] array = CategorizedActivities.Keys.ToArray();
		List<Activity> list = new List<Activity>();
		for (int i = 0; i < CategorizedActivities.Count; i++)
		{
			for (int j = 0; j < CategorizedActivities[array[i]].Count; j++)
			{
				Activity activity = CategorizedActivities[array[i]][j];
				if (activity.CheckStatus(Managers, out var _, sendEvent: false))
				{
					list.Add(activity);
				}
			}
		}
		foreach (Activity item in list)
		{
			Managers.Messenger.Broadcast("ACTIVITY_STATUS_CHANGED", item.ActivityId, (int)item.GetStatus(Managers));
			Managers.UserArchiveManager.SetActivityProgress(item.ActivityProgress(Managers));
		}
	}

	private static void RemoveDisabledActivitiesFromList(GameManagers managers, List<Activity> activities)
	{
		for (int num = activities.Count - 1; num >= 0; num--)
		{
			if (activities[num].GetStatus(managers) == ActivityStatus.Disabled)
			{
				activities.RemoveAt(num);
			}
		}
	}

	public List<Activity> GetActivitiesByType(ActivityType type, List<Activity> buffer = null, bool isSort = true)
	{
		if (buffer == null)
		{
			buffer = new List<Activity>();
		}
		buffer.Clear();
		if (!CategorizedActivities.TryGetValue(type, out var value))
		{
			return buffer;
		}
		if (type == ActivityType.Lottery)
		{
			for (int num = value.Count - 1; num >= 0; num--)
			{
				if (value[num].GetStatus(Managers) == ActivityStatus.Disabled)
				{
					value.RemoveAt(num);
				}
			}
		}
		buffer.AddRange(value);
		if (isSort)
		{
			buffer.Sort(ActivitySort);
		}
		return buffer;
	}

	public async Task GetLotteryActivitiesIncludingDynamicActivities(Action<List<Activity>, Dictionary<string, string>> cb = null, bool isSort = true)
	{
		List<Activity> lotteryActivities = GetActivitiesByType(ActivityType.Lottery, null, isSort);
		Dictionary<string, string> activityIdToDynamicPoolId = new Dictionary<string, string>();
		GetDynamicCardPoolActivityResponse response = await GameController.Contexts.Service<INetworkService>().GetDynamicCardPoolActivities(-1L);
		if (response == null)
		{
			return;
		}
		if (!response.Result)
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
			return;
		}
		DynamicPoolInfo upCardPoolInfo = response.DynamicCardPoolActivityData.UpCardPool;
		string upCardPoolId = upCardPoolInfo.ActivityId;
		string upCardPoolActivityId = upCardPoolInfo.TemplateId;
		if (!string.IsNullOrEmpty(upCardPoolActivityId) && Activities.TryGetValue(upCardPoolActivityId, out var upCardPoolActivity))
		{
			lotteryActivities.Add(upCardPoolActivity);
			activityIdToDynamicPoolId[upCardPoolActivityId] = upCardPoolId;
		}
		DynamicPoolInfo neutralCardPoolInfo = response.DynamicCardPoolActivityData.NeutralCardPool;
		string legionCardPooId = neutralCardPoolInfo.ActivityId;
		string neutralCardPoolActivityId = neutralCardPoolInfo.TemplateId;
		if (!string.IsNullOrEmpty(neutralCardPoolActivityId) && Activities.TryGetValue(neutralCardPoolActivityId, out var neutralCardPoolActivity))
		{
			lotteryActivities.Add(neutralCardPoolActivity);
			activityIdToDynamicPoolId[neutralCardPoolActivityId] = legionCardPooId;
		}
		cb?.Invoke(lotteryActivities, activityIdToDynamicPoolId);
	}

	public List<Activity> GetSingletonActivitiesByType(ActivityType type, List<Activity> buffer = null)
	{
		if (buffer == null)
		{
			buffer = new List<Activity>();
		}
		buffer.Clear();
		if (!SingletonActivitiesIndexByType.TryGetValue(type, out var value))
		{
			return buffer;
		}
		buffer.AddRange(value);
		buffer.Sort(ActivitySort);
		return buffer;
	}

	public Activity GetCurrentSingletonActivityByType(ActivityType type)
	{
		if (!CurrentSingletonActivityRecord.GetValue().TryGetValue(type.ToString(), out var value) || string.IsNullOrEmpty(value))
		{
			return null;
		}
		Activities.TryGetValue(value, out var value2);
		return value2;
	}

	private int ActivitySort(Activity activity, Activity anotherActivity)
	{
		ActivityStatus status = activity.GetStatus(Managers);
		ActivityStatus status2 = anotherActivity.GetStatus(Managers);
		if (status == status2)
		{
			return activity.CurBeginTime(Managers, DateTimeHelper.Now).CompareTo(anotherActivity.CurBeginTime(Managers, DateTimeHelper.Now));
		}
		if (status == ActivityStatus.Enabled)
		{
			return -1;
		}
		if (status2 == ActivityStatus.Enabled)
		{
			return 1;
		}
		if (status == ActivityStatus.Pending)
		{
			return -1;
		}
		if (status2 == ActivityStatus.Pending)
		{
			return 1;
		}
		if (status == ActivityStatus.Settlement)
		{
			return -1;
		}
		if (status2 == ActivityStatus.Settlement)
		{
			return 1;
		}
		if (status == ActivityStatus.Underline)
		{
			return -1;
		}
		if (status2 == ActivityStatus.Underline)
		{
			return 1;
		}
		return 0;
	}

	public void TryPickUpActivityMissions(Activity activity)
	{
		foreach (ActivityContentPayload value in activity.ContentPayload(Managers).Values)
		{
			MissionSerialActivityPayload missionSerialActivityPayload = (MissionSerialActivityPayload)value;
			foreach (Mission item in missionSerialActivityPayload.Missions(Managers))
			{
				item.Pickup(Managers);
			}
		}
	}

	public void RePickSingletonActivityByType(ActivityType activityType)
	{
		Dictionary<string, string> value = CurrentSingletonActivityRecord.GetValue();
		List<string> defaultActivities = DefaultActivities.GetValue();
		if (!value.TryGetValue(activityType.ToString(), out var currentRecordActivityId))
		{
			value.Add(activityType.ToString(), null);
		}
		if (!string.IsNullOrEmpty(currentRecordActivityId) && defaultActivities.Contains(currentRecordActivityId) && Activities.TryGetValue(currentRecordActivityId, out var value2) && value2.GetStatus(Managers) != ActivityStatus.Disabled)
		{
			return;
		}
		List<Activity> singletonActivitiesByType = GetSingletonActivitiesByType(activityType, _buffer);
		singletonActivitiesByType.RemoveAll((Activity activity2) => activity2.GetStatus(Managers) == ActivityStatus.Disabled || !string.IsNullOrEmpty(activity2.Parent));
		List<Activity> list = singletonActivitiesByType.Where((Activity activity2) => activity2.GetStatus(Managers) == ActivityStatus.Enabled).ToList();
		if (currentRecordActivityId != null)
		{
			list.RemoveAll((Activity activity2) => activity2.ActivityId == currentRecordActivityId);
		}
		Activity activity = null;
		if (list.Any())
		{
			activity = list.Find((Activity activity2) => defaultActivities.Contains(activity2.ActivityId)) ?? list[Managers.RandomManager.Int(list.Count)];
		}
		else if (singletonActivitiesByType.Any())
		{
			activity = singletonActivitiesByType.Find((Activity activity2) => defaultActivities.Contains(activity2.ActivityId)) ?? singletonActivitiesByType.First();
		}
		if (activity == null)
		{
			value.Remove(activityType.ToString());
		}
		else
		{
			value[activityType.ToString()] = activity.ActivityId;
			InitActivityWhenStartNewPeriod(activity);
		}
		CurrentSingletonActivityRecord.Save();
		Dictionary<string, int> value3 = ActivityDifficultyLevels.GetValue();
		if (value3.ContainsKey(activityType.ToString()))
		{
			value3[activityType.ToString()] = 0;
		}
		else
		{
			value3.Add(activityType.ToString(), 0);
		}
		ActivityDifficultyLevels.Save();
		Managers.Messenger.Broadcast("NEW_SINGLETON_ACTIVITY_RECORD", activity?.ActivityId);
	}

	private void InitActivityWhenStartNewPeriod(Activity newActivity)
	{
		newActivity.Reset(Managers, null, autoReset: true);
		Shift.Legion.Common.Models.ActivityConfig activityConfig = newActivity.ActivityProgress(Managers);
		activityConfig.LastPeriodStarAt = activityConfig.PeriodStartAt;
		activityConfig.PeriodStartAt = newActivity.CurBeginTime(Managers, DateTimeHelper.Now);
		Managers.UserArchiveManager.SetActivityProgress(activityConfig);
		if (newActivity.ChildIds.Count <= 0)
		{
			return;
		}
		foreach (string childId in newActivity.ChildIds)
		{
			if (Activities.TryGetValue(childId, out var value))
			{
				InitActivityWhenStartNewPeriod(value);
			}
		}
	}

	public void CheckActivities(List<string> activityIds = null, List<ActivityType> activityTypes = null, Action<CheckActivitiesOverPeriodResponse, bool, bool> callback = null)
	{
		if (!GameController.Contexts.gameState.hasCharacterArchive)
		{
			return;
		}
		CheckAllStatus();
		ILRequestHelper<CheckActivitiesOverPeriodResponse>.Request(null, () => SendCheckActivitiesOverPeriodRequest(activityIds, activityTypes), delegate(CheckActivitiesOverPeriodResponse response)
		{
			if (response != null)
			{
				if (!response.Result)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
				else
				{
					bool arg = false;
					if (response.ActivityConfigs != null && response.ActivityConfigs.Count > 0)
					{
						foreach (KeyValuePair<string, Shift.Legion.ClientApi.Models.ActivityConfig> activityConfig in response.ActivityConfigs)
						{
							if (Activities.TryGetValue(activityConfig.Key, out var value))
							{
								value.Reset(Managers, null, autoReset: true, activityConfig.Value);
								arg = true;
							}
						}
					}
					bool flag = false;
					if (response.CurrentRecordSingletonActivities != null && response.CurrentRecordSingletonActivities.Count > 0)
					{
						Dictionary<string, string> value2 = CurrentSingletonActivityRecord.GetValue();
						string[] array = value2.Keys.ToArray();
						List<ActivityType> list = new List<ActivityType>();
						string[] array2 = array;
						foreach (string value3 in array2)
						{
							ActivityType item = (ActivityType)Enum.Parse(typeof(ActivityType), value3);
							list.Add(item);
						}
						foreach (ActivityType item3 in list)
						{
							string text = value2[item3.ToString()];
							if (response.CurrentRecordSingletonActivities.TryGetValue((int)item3, out var value4))
							{
								if (text != value4)
								{
									value2[item3.ToString()] = value4;
									flag = true;
								}
							}
							else
							{
								value2.Remove(item3.ToString());
								flag = true;
							}
						}
						foreach (int key2 in response.CurrentRecordSingletonActivities.Keys)
						{
							ActivityType item2 = (ActivityType)key2;
							if (!list.Contains(item2))
							{
								value2.Add(item2.ToString(), response.CurrentRecordSingletonActivities[key2]);
								flag = true;
							}
						}
					}
					if (response.DefaultActivities != null)
					{
						DefaultActivities.SetValue(response.DefaultActivities);
					}
					if (response.DefaultActivityContents != null)
					{
						DefaultActivityContent.SetValue(response.DefaultActivityContents);
					}
					if (response.NewTickets != null && response.NewTickets.Count > 0)
					{
						StockChangeRecord[] array3 = new StockChangeRecord[response.NewTickets.Count];
						int num = 0;
						foreach (KeyValuePair<string, int> newTicket in response.NewTickets)
						{
							string key = newTicket.Key;
							int offset = newTicket.Value - Managers.StockController.GetStock(key);
							array3[num++] = new StockChangeRecord
							{
								ItemId = key,
								Offset = offset,
								Context = 7,
								Type = 1
							};
						}
						Managers.StockController.ReadStockChangeRecords(array3);
					}
					if (flag)
					{
						CurrentSingletonActivityRecord.Save();
						Managers.Messenger.Broadcast("NEW_SINGLETON_ACTIVITY_RECORD");
					}
					callback?.Invoke(response, arg, flag);
				}
			}
		}, 1f);
	}

	public IEnumerator GetAllLevelActivityData()
	{
		if (_cache_LevelActivity != null && LevelActivityDataOnUpdating)
		{
			yield break;
		}
		LevelActivityDataOnUpdating = true;
		_cache_LevelActivity = new Dictionary<string, Activity>();
		foreach (KeyValuePair<string, Activity> activity2 in Activities)
		{
			Activity activity = activity2.Value;
			if (activity.GetStatus(Managers) != ActivityStatus.Enabled)
			{
				continue;
			}
			Dictionary<string, ActivityContentPayload> _ActivityContentPayload = ((activity.Type != ActivityType.TreasureHunt) ? activity.ContentPayload(Managers) : activity.AllContentPayload());
			foreach (ActivityContentPayload _payload in _ActivityContentPayload.Values)
			{
				ActivityContentPayload activityContentPayload = _payload;
				if (!(activityContentPayload is ChapterActivityPayload chapterActivityPayload))
				{
					if (!(activityContentPayload is TreasureHuntChapterActivityPayload treasureHuntChapterActivityPayload))
					{
						continue;
					}
					foreach (string _id in treasureHuntChapterActivityPayload.Level_IDs)
					{
						if (!_cache_LevelActivity.ContainsKey(_id))
						{
							_cache_LevelActivity.Add(_id, activity);
						}
					}
					continue;
				}
				foreach (Level levelOfActivity in chapterActivityPayload.Levels(Managers))
				{
					if (!_cache_LevelActivity.ContainsKey(levelOfActivity.LevelId))
					{
						_cache_LevelActivity.Add(levelOfActivity.LevelId, activity);
					}
				}
			}
			if (LevelActivityDataOnUpdating)
			{
				yield return null;
				continue;
			}
			yield break;
		}
		LevelActivityDataOnUpdating = false;
	}

	private void AddLevelActivityDataCache()
	{
		if (_cache_LevelActivity != null)
		{
			return;
		}
		_cache_LevelActivity = new Dictionary<string, Activity>();
		foreach (KeyValuePair<string, Activity> activity in Activities)
		{
			Activity value = activity.Value;
			if (value.GetStatus(Managers) != ActivityStatus.Enabled)
			{
				continue;
			}
			Dictionary<string, ActivityContentPayload> dictionary = ((value.Type != ActivityType.TreasureHunt) ? value.ContentPayload(Managers) : value.AllContentPayload());
			foreach (ActivityContentPayload value2 in dictionary.Values)
			{
				ActivityContentPayload activityContentPayload = value2;
				ActivityContentPayload activityContentPayload2 = activityContentPayload;
				if (!(activityContentPayload2 is ChapterActivityPayload chapterActivityPayload))
				{
					if (!(activityContentPayload2 is TreasureHuntChapterActivityPayload treasureHuntChapterActivityPayload))
					{
						continue;
					}
					foreach (string level_ID in treasureHuntChapterActivityPayload.Level_IDs)
					{
						if (!_cache_LevelActivity.ContainsKey(level_ID))
						{
							_cache_LevelActivity.Add(level_ID, value);
						}
					}
					continue;
				}
				foreach (Level item in chapterActivityPayload.Levels(Managers))
				{
					if (!_cache_LevelActivity.ContainsKey(item.LevelId))
					{
						_cache_LevelActivity.Add(item.LevelId, value);
					}
				}
			}
		}
	}

	public void UpdateLevelActivityCache(string activityId)
	{
		if (!Activities.TryGetValue(activityId, out var value))
		{
			ILRuntimeDebug.LogError("UpdateLevelActivityCache Not Found " + activityId);
		}
		else
		{
			if (value.GetStatus(Managers) != ActivityStatus.Enabled)
			{
				return;
			}
			if (_cache_LevelActivity == null)
			{
				_cache_LevelActivity = new Dictionary<string, Activity>();
			}
			Dictionary<string, ActivityContentPayload> dictionary = ((value.Type != ActivityType.TreasureHunt) ? value.ContentPayload(Managers) : value.AllContentPayload());
			foreach (ActivityContentPayload value2 in dictionary.Values)
			{
				ActivityContentPayload activityContentPayload = value2;
				ActivityContentPayload activityContentPayload2 = activityContentPayload;
				if (!(activityContentPayload2 is ChapterActivityPayload chapterActivityPayload))
				{
					if (!(activityContentPayload2 is TreasureHuntChapterActivityPayload treasureHuntChapterActivityPayload))
					{
						continue;
					}
					foreach (string level_ID in treasureHuntChapterActivityPayload.Level_IDs)
					{
						if (_cache_LevelActivity == null)
						{
							ILRuntimeDebug.LogError("_cache_LevelActivity=null While UpdateLevelActivityCache");
						}
						_cache_LevelActivity[level_ID] = value;
					}
					continue;
				}
				foreach (Level item in chapterActivityPayload.Levels(Managers))
				{
					_cache_LevelActivity[item.LevelId] = value;
				}
			}
		}
	}

	public void FlushLevelActivityCache(bool needUpdateLevelActivityCache = false)
	{
		_cache_LevelActivity = null;
		if (needUpdateLevelActivityCache)
		{
			FGUIManager.Instance.OpenIEnumerator(GetAllLevelActivityData());
		}
	}

	public Activity GetLevelActivity(Level level)
	{
		if (level.ParentLevel != null)
		{
			return GetLevelActivity(level.ParentLevel);
		}
		if (level.Chapter.Type == ChapterType.StoryMain || level.Chapter.Type == ChapterType.StorySub || level.Chapter.Type == ChapterType.StoryTransition)
		{
			return null;
		}
		string levelId = level.LevelId;
		if (LevelActivityDataOnUpdating)
		{
			LevelActivityDataOnUpdating = true;
			FlushLevelActivityCache();
		}
		AddLevelActivityDataCache();
		if (_cache_LevelActivity.ContainsKey(levelId))
		{
			return _cache_LevelActivity[levelId];
		}
		return null;
	}

	public async Task<Activity> GetLevelActivityAsync(Level level)
	{
		if (level.ParentLevel != null)
		{
			return await GetLevelActivityAsync(level.ParentLevel);
		}
		if (level.Chapter.Type == ChapterType.StoryMain || level.Chapter.Type == ChapterType.StorySub || level.Chapter.Type == ChapterType.StoryTransition)
		{
			return null;
		}
		string _levelid = level.LevelId;
		if (LevelActivityDataOnUpdating)
		{
			while (!LevelActivityDataOnUpdating)
			{
				await Task.Delay(50);
			}
		}
		AddLevelActivityDataCache();
		if (_cache_LevelActivity.ContainsKey(_levelid))
		{
			return _cache_LevelActivity[_levelid];
		}
		return null;
	}

	public Activity GetLevelActivity(string levelId)
	{
		Level levelInstance = Managers.ChapterManager.GetLevelInstance(levelId);
		return GetLevelActivity(levelInstance);
	}

	private void OnPurchaseStats()
	{
		foreach (List<Activity> value in CategorizedActivities.Values)
		{
			foreach (Activity item in value)
			{
				if (item.ContentType == ActivityContentType.MissionSerial && item.GetStatus(Managers) == ActivityStatus.Enabled)
				{
					TryPickUpActivityMissions(item);
				}
			}
		}
	}

	private static void OnActivityInit(Activity act)
	{
		if (act.ContentType == ActivityContentType.ProgressMission)
		{
			ProgressionMission = act;
		}
		else if (act.ContentType == ActivityContentType.ChallengeMission)
		{
			ChallengeMission = act;
		}
		else if (act.ContentType == ActivityContentType.WeekActPassContent)
		{
			WeekActPasses.Add(act);
		}
	}

	public void OnBeforeLevelCompleted(Level level, Team team)
	{
		if (level.ParentLevel == null)
		{
			Activity levelActivity = GetLevelActivity(level);
			if (levelActivity != null)
			{
				CheckActivities(new List<string> { levelActivity.ActivityId });
			}
		}
	}

	public Dictionary<string, int> GetBattleCostOfLevel(Level level)
	{
		if (level.ParentLevel != null)
		{
			return null;
		}
		Activity levelActivity = GetLevelActivity(level);
		if (levelActivity == null)
		{
			return null;
		}
		if (!levelActivity.ContentPayload(Managers).TryGetValue(level.ChapterId, out var value))
		{
			return null;
		}
		if (!(value is ChapterActivityPayload chapterActivityPayload))
		{
			return null;
		}
		return new Dictionary<string, int> { { levelActivity.TicketItem, chapterActivityPayload.Tickets } };
	}

	public void StatsReset(string activityId, Dictionary<string, int> costDict)
	{
		ActivityResetStatsConfig value = ActivityResetStats.GetValue();
		if (value.ActivityResetCntStats.ContainsKey(activityId))
		{
			value.ActivityResetCntStats[activityId]++;
		}
		else
		{
			value.ActivityResetCntStats.Add(activityId, 1);
		}
		if (value.DailyActivityResetCntStats.ContainsKey(activityId))
		{
			value.DailyActivityResetCntStats[activityId]++;
		}
		else
		{
			value.DailyActivityResetCntStats.Add(activityId, 1);
		}
		if (costDict != null && costDict.Count > 0)
		{
			if (!value.ActivityResetCostStats.TryGetValue(activityId, out var value2))
			{
				value2 = new Dictionary<string, int>();
				value.ActivityResetCostStats.Add(activityId, value2);
			}
			if (!value.DailyActivityResetCostStats.TryGetValue(activityId, out var value3))
			{
				value3 = new Dictionary<string, int>();
				value.DailyActivityResetCostStats.Add(activityId, value3);
			}
			foreach (KeyValuePair<string, int> item in costDict)
			{
				if (value2.ContainsKey(item.Key))
				{
					value2[item.Key] += item.Value;
				}
				else
				{
					value2.Add(item.Key, item.Value);
				}
				if (value3.ContainsKey(item.Key))
				{
					value3[item.Key] += item.Value;
				}
				else
				{
					value3.Add(item.Key, item.Value);
				}
			}
		}
		ActivityResetStats.Save();
	}

	public async Task ReviewActivities(List<string> activityIds)
	{
		await SendActivitiesReviewRequest(activityIds);
		foreach (string activityId in activityIds)
		{
			if (Activities.TryGetValue(activityId, out var activity))
			{
				Shift.Legion.Common.Models.ActivityConfig activityProgress = activity.ActivityProgress(GameManagers.Instance);
				if (activityProgress.IsNew)
				{
					activityProgress.IsNew = false;
					GameManagers.Instance.UserArchiveManager.SetActivityProgress(activityProgress);
					activity = null;
				}
			}
		}
	}

	public void InitDepartureGift()
	{
		string configKey = "DepartureGifts";
		if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode5() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode5())
		{
			configKey = "DepartureGiftsGuide5";
		}
		else if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode6() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode6())
		{
			configKey = "DepartureGiftsGuide6";
		}
		else if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode7())
		{
			configKey = "DepartureGiftsGuide7";
		}
		List<NestingGiftBagsConfig> list = configKey.ToConfiguration<List<NestingGiftBagsConfig>>();
		DepartureGift = ((list == null) ? new List<NestingGiftBags>() : list.Select((NestingGiftBagsConfig config) => new NestingGiftBags(config)).ToList());
	}

	private void OnPingPushItem(PushItem item)
	{
		if (item.PacketId == PacketIds.PUSH_ACTIVE_NEWGACHA_ACTIVITYID)
		{
			GameManagers.Instance.UserArchiveManager.SetNewbieGachaPool(item.Body);
		}
		else if (item.PacketId == PacketIds.PUSH_WAROFREALM_COMPLETEDMISSION)
		{
			List<WarOfRealmPacket> list = JsonHelper.ToObject<List<WarOfRealmPacket>>(item.Body);
			if (list != null)
			{
				RankDataHelper.AllServersChampionshipInfo?.UpdateMissionProgress(list);
			}
		}
	}

	public async Task<GetRecallWelfareResponse> GetRecallWelfare()
	{
		return await _recallWelfareWrapper.GetRecallWelfare();
	}

	public RecallWelfareUiParams CreateRecallWelfareUiParams()
	{
		return _recallWelfareWrapper.CreateRecallWelfareUiParams();
	}

	public RecallWelfarePreviewParams CreatePreviewParams()
	{
		return _recallWelfareWrapper.CreatePreviewParams();
	}

	public List<IRecallWelfareMission> CreateMissions()
	{
		return _recallWelfareWrapper.CreateMissions();
	}

	public void ClaimRecallWelfareMissionReward(string missionId, Action onClaimed = null)
	{
		_recallWelfareWrapper.ClaimRecallWelfareMissionReward(missionId, onClaimed);
	}

	public void DrawRecallWelfare(List<int> ids, Action<Dictionary<int, IRecallWelfarePrize>> onDrawed = null, Action<List<StockChangeRecord>> onStockChanged = null)
	{
		_recallWelfareWrapper.DrawRecallWelfare(ids, onDrawed, onStockChanged);
	}

	public void ExchangeRecallWelfare(Action<ExchangeRecallWelfareResponse> onExchanged = null)
	{
		_recallWelfareWrapper.ExchangeRecallWelfare(onExchanged);
	}

	public void AddOnTotalScoreChanged(Action<int> onChanged)
	{
		RecallWelfareWrapper recallWelfareWrapper = _recallWelfareWrapper;
		recallWelfareWrapper.OnTotalScoreChanged = (Action<int>)Delegate.Combine(recallWelfareWrapper.OnTotalScoreChanged, onChanged);
	}

	public void RemoveOnTotalScoreChanged(Action<int> onChanged)
	{
		RecallWelfareWrapper recallWelfareWrapper = _recallWelfareWrapper;
		recallWelfareWrapper.OnTotalScoreChanged = (Action<int>)Delegate.Remove(recallWelfareWrapper.OnTotalScoreChanged, onChanged);
	}

	private static async void CheckTotalRecharge(float rechargeCnt)
	{
		await FGUIManager.Instance.GetDynamicSecretTreasuryActivity();
	}
}
