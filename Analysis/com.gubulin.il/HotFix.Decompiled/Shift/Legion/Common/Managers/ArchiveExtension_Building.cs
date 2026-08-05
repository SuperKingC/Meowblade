using System.Collections.Generic;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_Building
{
	private const string LevelKey = "BUILDING_LEVEL";

	private const string MaxLevelKey = "BUILDING_MAX_LEVEL";

	private const string StatusKey = "BUILDING_STATUS";

	private const string ConstructingConfigKey = "BUILDING_CONSTRUCTING_CONFIG";

	private const string ExtraBuildingSlotsKey = "EXTRA_BUILDING_SLOTS";

	private const string RecruitingCampQueueKey = "RECRUITINGCAMP_QUEUE";

	public static int GetBuildingLevel(this UserArchiveManager manager, string buildingType)
	{
		return manager.GetValueOfDictConfig<int>("BUILDING_LEVEL", buildingType);
	}

	public static void SetBuildingLevel(this UserArchiveManager manager, string buildingType, int level)
	{
		manager.SetValueOfDictConfig("BUILDING_LEVEL", buildingType, level, acceptInsert: true);
	}

	public static Dictionary<string, int> GetAllBuildingLevel(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<Dictionary<string, int>>("BUILDING_LEVEL");
	}

	public static int GetBuildingMaxLevel(this UserArchiveManager manager, string buildingType)
	{
		return manager.GetValueOfDictConfig<int>("BUILDING_MAX_LEVEL", buildingType);
	}

	public static void SetBuildingMaxLevel(this UserArchiveManager manager, string buildingType, int maxLevel)
	{
		manager.Managers.Messenger.Broadcast("BUILDING_MAX_LEVEL_CHANGED", buildingType, maxLevel);
		manager.SetValueOfDictConfig("BUILDING_MAX_LEVEL", buildingType, maxLevel, acceptInsert: true);
	}

	public static BuildingConstructingConfig GetBuildingConstructingConfig(this UserArchiveManager manager, string buildingType)
	{
		Dictionary<string, BuildingConstructingConfig> configValue = manager.GetConfigValue<Dictionary<string, BuildingConstructingConfig>>("BUILDING_CONSTRUCTING_CONFIG");
		BuildingConstructingConfig value;
		return configValue.TryGetValue(buildingType, out value) ? value : null;
	}

	public static BuildingStatus GetBuildingStatus(this UserArchiveManager manager, string buildingType)
	{
		Dictionary<string, int> configValue = manager.GetConfigValue<Dictionary<string, int>>("BUILDING_STATUS");
		if (configValue.TryGetValue(buildingType, out var value))
		{
			return (BuildingStatus)value;
		}
		manager.ChangeBuildingStatus(buildingType, BuildingStatus.Disabled);
		return BuildingStatus.Disabled;
	}

	public static void ChangeBuildingStatus(this UserArchiveManager manager, string buildingType, BuildingStatus status)
	{
		manager.SetValueOfDictConfig("BUILDING_STATUS", buildingType, status, acceptInsert: true);
	}

	public static void SetBuildingConstructingConfig(this UserArchiveManager manager, string buildingType, BuildingConstructingConfig config)
	{
		manager.SetValueOfDictConfig("BUILDING_CONSTRUCTING_CONFIG", buildingType, config, acceptInsert: true);
	}

	public static Dictionary<string, int> GetAllExtraBuildingSlots(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<Dictionary<string, int>>("EXTRA_BUILDING_SLOTS");
	}

	public static int GetExtraBuildingSlots(this UserArchiveManager manager, string buildingType)
	{
		manager.GetAllExtraBuildingSlots().TryGetValue(buildingType, out var value);
		return value;
	}

	public static void SetExtraBuildingSlots(this UserArchiveManager manager, string buildingType, int slots)
	{
		Dictionary<string, int> allExtraBuildingSlots = manager.GetAllExtraBuildingSlots();
		if (allExtraBuildingSlots.ContainsKey(buildingType))
		{
			allExtraBuildingSlots[buildingType] = slots;
		}
		else
		{
			allExtraBuildingSlots.Add(buildingType, slots);
		}
		manager.SetConfigValue("EXTRA_BUILDING_SLOTS", allExtraBuildingSlots);
	}

	public static void SetWorkShopSlot(this UserArchiveManager manager, string buildingType, int slot)
	{
		manager.SetValueOfDictConfig("BUILDING" + buildingType, "MaxWorkers", slot);
	}

	public static void UnlockCampSlot(this UserArchiveManager manager, int slot)
	{
		Dictionary<string, string> configValue = manager.GetConfigValue<Dictionary<string, string>>("RECRUITINGCAMP_QUEUE");
		for (int i = 0; i < slot; i++)
		{
			string key = $"Pos{i}";
			if (!configValue.ContainsKey(key))
			{
				configValue.Add(key, "Lock");
			}
			if (configValue[$"Pos{i}"] == "Lock")
			{
				configValue[$"Pos{i}"] = "Unlock";
			}
		}
		manager.SetConfigValue("RECRUITINGCAMP_QUEUE", configValue);
	}

	public static Dictionary<int, string> GetCampProducingQueue(this UserArchiveManager manager)
	{
		Dictionary<string, string> configValue = manager.GetConfigValue<Dictionary<string, string>>("RECRUITINGCAMP_QUEUE");
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		int num = 0;
		foreach (KeyValuePair<string, string> item in configValue)
		{
			dictionary.Add(num, item.Value);
			num++;
		}
		return dictionary;
	}

	public static string GetCampSoldier(this UserArchiveManager manager, int position)
	{
		return manager.GetValueOfDictConfig<string>("RECRUITINGCAMP_QUEUE", $"Pos{position}");
	}

	public static void SetCampSoldier(this UserArchiveManager manager, int position, string soldierId)
	{
		manager.SetValueOfDictConfig("RECRUITINGCAMP_QUEUE", $"Pos{position}", soldierId);
	}

	public static void SetOldProductionConfigs(this UserArchiveManager manager, string buildingType, Dictionary<int, ProductionConfig> productionConfigs)
	{
		manager.SetConfigValue("OLD_PRODUCTION_CONFIGS" + buildingType, productionConfigs);
	}

	public static Dictionary<int, ProductionConfig> GetOldProductionConfigs(this UserArchiveManager manager, string buildingType)
	{
		return manager.GetConfigValue<Dictionary<int, ProductionConfig>>("OLD_PRODUCTION_CONFIGS" + buildingType);
	}

	public static void RemoveOldProductionConfigs(this UserArchiveManager manager, string buildingType)
	{
		manager.RemoveConfig("OLD_PRODUCTION_CONFIGS" + buildingType);
	}
}
