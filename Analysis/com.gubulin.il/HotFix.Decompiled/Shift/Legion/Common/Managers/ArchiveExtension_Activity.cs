using System.Collections.Generic;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_Activity
{
	private class SoldierStockLimitIncrease
	{
		public int LimitIncrease { get; set; }

		public int ExpiredTimestamp { get; set; }

		public bool StockIncreased { get; set; }
	}

	private const string Key = "ACTIVITY_PROGRESS";

	public const string NewGuideModeExcludeLevelCaseActivitiesKey = "NewGuideModeExcludeLevelCaseActivities";

	private const string IslandComeAgainSoldierStockLimitIncreaseKey = "IslandComeAgainSoldierStockLimitIncrease";

	public static Dictionary<string, ActivityConfig> GetAllActivityProgress(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<Dictionary<string, ActivityConfig>>("ACTIVITY_PROGRESS");
	}

	internal static void SetAllActivityProgress(this UserArchiveManager manager, Dictionary<string, ActivityConfig> value)
	{
		manager.SetConfigValue("ACTIVITY_PROGRESS", value);
	}

	public static ActivityConfig GetActivityProgressOrNew(this UserArchiveManager manager, string activityId)
	{
		Dictionary<string, ActivityConfig> allActivityProgress = manager.GetAllActivityProgress();
		if (allActivityProgress.TryGetValue(activityId, out var value))
		{
			return value;
		}
		value = new ActivityConfig
		{
			ActivityId = activityId,
			LastAutoFillAt = DateTimeHelper.Now
		};
		manager.SetActivityProgress(value);
		return value;
	}

	public static ActivityConfig GetActivityProgress(this UserArchiveManager manager, string activityId)
	{
		Dictionary<string, ActivityConfig> allActivityProgress = manager.GetAllActivityProgress();
		if (allActivityProgress.TryGetValue(activityId, out var value))
		{
			return value;
		}
		return null;
	}

	public static void SetActivityProgress(this UserArchiveManager manager, ActivityConfig config, bool updateModifiedAt = true)
	{
		Dictionary<string, ActivityConfig> allActivityProgress = manager.GetAllActivityProgress();
		if (allActivityProgress.ContainsKey(config.ActivityId))
		{
			allActivityProgress[config.ActivityId] = config;
		}
		else
		{
			allActivityProgress.Add(config.ActivityId, config);
		}
		if (updateModifiedAt)
		{
			config.ModifiedAt = DateTimeHelper.Now;
		}
		manager.SetAllActivityProgress(allActivityProgress);
	}

	public static void RemoveActivityProgress(this UserArchiveManager manager, string activityId)
	{
		Dictionary<string, ActivityConfig> allActivityProgress = manager.GetAllActivityProgress();
		allActivityProgress.Remove(activityId);
		manager.SetAllActivityProgress(allActivityProgress);
	}

	public static void ResetActivityProgress(this UserArchiveManager manager, string activityId)
	{
		manager.SetActivityProgress(new ActivityConfig
		{
			ActivityId = activityId,
			ModifiedAt = DateTimeHelper.Now
		});
	}

	public static void SetActivityStatus(this UserArchiveManager manager, string activityId, ActivityStatus status)
	{
		manager.SetConfigValue("ACTIVITY_STATUS:" + activityId, (int)status);
	}

	public static bool TryGetActivityStatus(this UserArchiveManager manager, string activityId, out ActivityStatus status)
	{
		string key = "ACTIVITY_STATUS:" + activityId;
		if (manager.Contains(key))
		{
			status = (ActivityStatus)manager.GetConfigValue<int>(key);
			return true;
		}
		status = ActivityStatus.Disabled;
		return false;
	}

	public static List<string> GetExcludeLevelCaseActivities(this UserArchiveManager manager)
	{
		if (!manager.IsNewGuideMode())
		{
			return new List<string>();
		}
		List<string> list = manager.GetConfigValue<List<string>>("NewGuideModeExcludeLevelCaseActivities");
		if (list == null)
		{
			list = new List<string>();
			manager.SetConfigValue("NewGuideModeExcludeLevelCaseActivities", list);
		}
		return list;
	}

	public static void SetExcludeLevelCaseActivities(this UserArchiveManager manager, string activityId)
	{
		if (manager.IsNewGuideMode())
		{
			List<string> excludeLevelCaseActivities = manager.GetExcludeLevelCaseActivities();
			if (!excludeLevelCaseActivities.Contains(activityId))
			{
				excludeLevelCaseActivities.Add(activityId);
			}
			manager.SetConfigValue("NewGuideModeExcludeLevelCaseActivities", excludeLevelCaseActivities);
		}
	}

	public static int GetIslandComeAgainSoldierStockLimitIncrement(this UserArchiveManager manager)
	{
		SoldierStockLimitIncrease configValue = manager.GetConfigValue<SoldierStockLimitIncrease>("IslandComeAgainSoldierStockLimitIncrease");
		if (configValue != null && configValue.ExpiredTimestamp > (int)GameController.Instance.GetServerTime())
		{
			return configValue.LimitIncrease;
		}
		return 0;
	}

	public static void SetIslandComeAgainSoldierStockLimitIncrease(this UserArchiveManager manager, int limitIncrease, int expiredTimestamp)
	{
		SoldierStockLimitIncrease value = new SoldierStockLimitIncrease
		{
			LimitIncrease = limitIncrease,
			ExpiredTimestamp = expiredTimestamp
		};
		manager.SetConfigValue("IslandComeAgainSoldierStockLimitIncrease", value);
	}

	public static bool GetIslandComeAgainSoldierStockIncreased(this UserArchiveManager manager)
	{
		SoldierStockLimitIncrease configValue = manager.GetConfigValue<SoldierStockLimitIncrease>("IslandComeAgainSoldierStockLimitIncrease");
		if (configValue != null && configValue.ExpiredTimestamp > DateTimeHelper.TimeStamp)
		{
			return configValue.StockIncreased;
		}
		return false;
	}

	public static void SetIslandComeAgainSoldierStockIncreased(this UserArchiveManager manager)
	{
		SoldierStockLimitIncrease configValue = manager.GetConfigValue<SoldierStockLimitIncrease>("IslandComeAgainSoldierStockLimitIncrease");
		if (configValue != null && configValue.ExpiredTimestamp > DateTimeHelper.TimeStamp)
		{
			configValue.StockIncreased = true;
			manager.SetConfigValue("IslandComeAgainSoldierStockLimitIncrease", configValue);
		}
	}
}
