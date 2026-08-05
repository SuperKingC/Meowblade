using System.Collections.Generic;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierLegendItem.Models;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_GvGSoldiersEquippedItems
{
	public const string GvGSoldiersEquippedItemsKey = "GvGSoldiersEquippedItems";

	private static bool need_refresh = true;

	private static Dictionary<long, string> _cache_EquippedLegendItemDict = new Dictionary<long, string>();

	public static long[] GetGvGSoldiersEquippedItemIds(this GameManagers managers, string soldierId)
	{
		Config<SoldiersEquippedItems> config = managers.UserArchiveManager.GetConfig<SoldiersEquippedItems>("GvGSoldiersEquippedItems");
		SoldiersEquippedItems value = config.GetValue();
		if (!value.Value.ContainsKey(soldierId))
		{
			value.Value.Add(soldierId, new long[2]);
			managers.UserArchiveManager.SetConfigValue("GvGSoldiersEquippedItems", value);
		}
		if (!managers.SoldierItemSlotsManager.IsSlotUnlocked(soldierId, 0))
		{
			return new long[0];
		}
		if (!managers.SoldierItemSlotsManager.IsSlotUnlocked(soldierId, 1))
		{
			return new long[1] { value.Value[soldierId][0] };
		}
		return value.Value[soldierId];
	}

	public static void SetGvGSoldiersEquippedItemIds(this GameManagers managers, string soldierId, long[] ids)
	{
		need_refresh = true;
		Config<SoldiersEquippedItems> config = managers.UserArchiveManager.GetConfig<SoldiersEquippedItems>("GvGSoldiersEquippedItems");
		SoldiersEquippedItems value = config.GetValue();
		if (!managers.SoldierItemSlotsManager.IsSlotUnlocked(soldierId, 0))
		{
			ids = new long[0];
		}
		else if (!managers.SoldierItemSlotsManager.IsSlotUnlocked(soldierId, 1))
		{
			ids = new long[1] { ids[0] };
		}
		value.Value[soldierId] = ids;
		managers.UserArchiveManager.SetConfigValue("GvGSoldiersEquippedItems", value);
	}

	public static void ClearGvGSoldiersEquippedItemIds(this GameManagers managers)
	{
		Config<SoldiersEquippedItems> config = managers.UserArchiveManager.GetConfig<SoldiersEquippedItems>("GvGSoldiersEquippedItems");
		SoldiersEquippedItems value = config.GetValue();
		value.Value.Clear();
		managers.UserArchiveManager.SetConfigValue("GvGSoldiersEquippedItems", value);
	}

	public static string GetGvGSoldierIdByEquippedLegendItem(this GameManagers managers, long instanceId)
	{
		SoldiersEquippedItems value = managers.UserArchiveManager.GetConfig<SoldiersEquippedItems>("GvGSoldiersEquippedItems").GetValue();
		if (need_refresh)
		{
			_cache_EquippedLegendItemDict.Clear();
			foreach (KeyValuePair<string, long[]> item in value.Value)
			{
				long[] value2 = item.Value;
				foreach (long num in value2)
				{
					if (num > 0)
					{
						_cache_EquippedLegendItemDict.Add(num, item.Key);
					}
				}
			}
			need_refresh = false;
		}
		if (_cache_EquippedLegendItemDict.TryGetValue(instanceId, out var value3))
		{
			return value3;
		}
		return string.Empty;
	}
}
