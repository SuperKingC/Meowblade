using System.Collections.Generic;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_Region
{
	private const string RegionUnlockBonusRecordKey = "REGION_UNLOCK_BONUS_RECORD";

	private const string StrongholdsStatusKey = "STRONGHOLDS_STATUS";

	public static bool CheckRegionUnlockBonusesClaimed(this UserArchiveManager manager, string regionId)
	{
		return manager.GetConfigValue<List<string>>("REGION_UNLOCK_BONUS_RECORD").Contains(regionId);
	}

	public static void RecordRegionUnlockBonuses(this UserArchiveManager manager, string regionId)
	{
		WorldMapManager.Cache_RegionStatus.Remove(regionId);
		manager.AddToList("REGION_UNLOCK_BONUS_RECORD", regionId);
	}

	public static List<string> GetAssignedSoldiers(this UserArchiveManager manager)
	{
		List<string> list = new List<string>();
		foreach (StrongholdConfig value in manager.GetAllStrongholdsStatus().Values)
		{
			if (!string.IsNullOrEmpty(value.Occupant))
			{
				list.Add(value.Occupant);
			}
		}
		return list;
	}

	public static Dictionary<string, StrongholdConfig> GetAllStrongholdsStatus(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<Dictionary<string, StrongholdConfig>>("STRONGHOLDS_STATUS");
	}

	public static StrongholdConfig GetStrongholdStatus(this UserArchiveManager manager, string strongholdId)
	{
		Dictionary<string, StrongholdConfig> allStrongholdsStatus = manager.GetAllStrongholdsStatus();
		if (!allStrongholdsStatus.TryGetValue(strongholdId, out var value))
		{
			value = new StrongholdConfig
			{
				StrongholdId = strongholdId
			};
			manager.SetStrongholdStatus(value);
		}
		return value;
	}

	public static void SetStrongholdStatus(this UserArchiveManager manager, StrongholdConfig strongholdConfig)
	{
		manager.SetValueOfDictConfig("STRONGHOLDS_STATUS", strongholdConfig.StrongholdId, strongholdConfig, acceptInsert: true);
	}

	public static bool AssignOccupantToStronghold(this UserArchiveManager manager, string soldierId, string strongholdId)
	{
		List<string> unlockedSoldiers = manager.GetUnlockedSoldiers();
		if (!unlockedSoldiers.Contains(soldierId))
		{
			return false;
		}
		if (!WorldMapManager.Strongholds.TryGetValue(strongholdId, out var value))
		{
			return false;
		}
		Dictionary<string, StrongholdConfig> allStrongholdsStatus = manager.GetAllStrongholdsStatus();
		foreach (StrongholdConfig value3 in allStrongholdsStatus.Values)
		{
			if (value3.Occupant == soldierId)
			{
				return false;
			}
		}
		if (!allStrongholdsStatus.TryGetValue(strongholdId, out var value2))
		{
			value2 = new StrongholdConfig
			{
				StrongholdId = strongholdId
			};
		}
		value2.Occupant = soldierId;
		value2.Productions = new Dictionary<string, float>();
		float num = value.Efficiency(manager.Managers);
		foreach (KeyValuePair<string, int> item in value.ProductionsConfig)
		{
			value2.Productions.Add(item.Key, (float)item.Value * num);
		}
		manager.SetStrongholdStatus(value2);
		manager.Managers.Messenger.Broadcast("STRONGHOLD_ASSIGNED_OCCUPANT", strongholdId, soldierId);
		return true;
	}

	public static void WithdrawOccupantFromStronghold(this UserArchiveManager manager, string strongholdId)
	{
		Dictionary<string, StrongholdConfig> allStrongholdsStatus = manager.GetAllStrongholdsStatus();
		if (!allStrongholdsStatus.TryGetValue(strongholdId, out var value))
		{
			value = new StrongholdConfig
			{
				StrongholdId = strongholdId
			};
		}
		value.Occupant = null;
		value.Productions?.Clear();
		manager.SetStrongholdStatus(value);
		manager.Managers.Messenger.Broadcast<string, string>("STRONGHOLD_ASSIGNED_OCCUPANT", strongholdId, null);
	}
}
