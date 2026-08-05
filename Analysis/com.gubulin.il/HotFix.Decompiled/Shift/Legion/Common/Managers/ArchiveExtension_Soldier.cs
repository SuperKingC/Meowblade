using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_Soldier
{
	private const string EvoLevelKey = "SOLDIER_EVO_LEVEL";

	private const string MaxEvoLevelKey = "SOLDIER_MAX_EVO_LEVEL";

	private const string PotentialLevelKey = "SOLDIER_POTENTIAL";

	private const string PotentialProgressKey = "SOLDIER_POTENTIAL_PROGRESS";

	private const string MaxStarsKey = "SOLDIER_MAX_STARS";

	private const string SoldierLevelKey = "SOLDIER_LEVEL";

	private const string SoldierExperienceKey = "SOLDIER_EXPERIENCE";

	private const string SoldierSkinKey = "SOLDIER_SKIN";

	private const string UnlockSoldierKey = "UNLOCK_SOLDIER";

	public static int GetSoldierEvolutionLevel(this UserArchiveManager manager, string soldierId)
	{
		return manager.GetValueOfDictConfig<int>("SOLDIER_EVO_LEVEL", soldierId);
	}

	public static void SetSoldierEvolutionLevel(this UserArchiveManager manager, string soldierId, int level)
	{
		manager.SetValueOfDictConfig("SOLDIER_EVO_LEVEL", soldierId, level, acceptInsert: true);
	}

	public static int GetSoldierPotentialLevel(this UserArchiveManager manager, string soldierId)
	{
		return manager.GetValueOfDictConfig<int>("SOLDIER_POTENTIAL", soldierId);
	}

	public static List<int> GetSoldierPotentialProgress(this UserArchiveManager manager, string soldierId)
	{
		List<int> list = manager.GetValueOfDictConfig<List<int>>("SOLDIER_POTENTIAL_PROGRESS", soldierId);
		if (list == null)
		{
			list = new List<int>();
			manager.SetValueOfDictConfig("SOLDIER_POTENTIAL_PROGRESS", soldierId, list, acceptInsert: true);
		}
		return list;
	}

	public static void SetSoldierPotentialProgress(this UserArchiveManager manager, string soldierId, IEnumerable<int> positionList)
	{
		List<int> soldierPotentialProgress = manager.GetSoldierPotentialProgress(soldierId);
		foreach (int position in positionList)
		{
			if (!soldierPotentialProgress.Contains(position))
			{
				soldierPotentialProgress.Add(position);
			}
		}
		manager.SetValueOfDictConfig("SOLDIER_POTENTIAL_PROGRESS", soldierId, soldierPotentialProgress, acceptInsert: true);
	}

	public static void ClearSoldierPotentialProgress(this UserArchiveManager manager, string soldierId)
	{
		Dictionary<string, List<int>> configValue = manager.GetConfigValue<Dictionary<string, List<int>>>("SOLDIER_POTENTIAL_PROGRESS");
		if (configValue.ContainsKey(soldierId))
		{
			configValue[soldierId].Clear();
		}
		else
		{
			configValue.Add(soldierId, new List<int>());
		}
		manager.SetConfigValue("SOLDIER_POTENTIAL_PROGRESS", configValue);
	}

	public static void SetSoldierPotentialLevel(this UserArchiveManager manager, string soldierId, int potentialLevel, bool refundProgress = false)
	{
		if (refundProgress)
		{
			int soldierPotentialLevel = manager.GetSoldierPotentialLevel(soldierId);
			SoldierPotentialData soldierPotential = ConfigDataManager.GetSoldierPotential(soldierId, soldierPotentialLevel + 1);
			if (soldierPotential != null)
			{
				List<int> soldierPotentialProgress = manager.GetSoldierPotentialProgress(soldierId);
				manager.Managers.StockController.ReadStockChangeRecords(new StockChangeRecord[1]
				{
					new StockChangeRecord
					{
						ItemId = soldierPotential.Requirements(manager.Managers).Keys.First(),
						Offset = soldierPotentialProgress.Count,
						Context = 11,
						ContextValue = soldierId,
						Type = 1
					}
				});
			}
		}
		manager.ClearSoldierPotentialProgress(soldierId);
		manager.SetValueOfDictConfig("SOLDIER_POTENTIAL", soldierId, potentialLevel, acceptInsert: true);
		manager.Managers.Messenger.Broadcast("SOLDIER_POTENTIAL_UPGRADED", soldierId, potentialLevel);
	}

	public static int GetSoldierMaxLevel(this UserArchiveManager manager, string soldierId, int evoLevel = -1)
	{
		if (evoLevel < 0)
		{
			evoLevel = manager.GetSoldierEvolutionLevel(soldierId);
		}
		if (evoLevel < 5)
		{
			return evoLevel * 10;
		}
		return evoLevel switch
		{
			5 => 60, 
			6 => 90, 
			_ => (evoLevel - 4) * 20 + 40, 
		};
	}

	public static int GetSoldierMaxEvoLevel(this UserArchiveManager manager)
	{
		return 6;
	}

	public static int GetSoldierMaxStars(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<int>("SOLDIER_MAX_STARS");
	}

	public static void SetSoldierMaxStars(this UserArchiveManager manager, int maxBreakthrough)
	{
		manager.SetConfigValue("SOLDIER_MAX_STARS", maxBreakthrough);
	}

	public static int GetSoldierLevel(this UserArchiveManager manager, string soldierId)
	{
		return manager.GetValueOfDictConfig<int>("SOLDIER_LEVEL", soldierId);
	}

	public static void SetSoldierLevel(this UserArchiveManager manager, string soldierId, int level)
	{
		manager.SetValueOfDictConfig("SOLDIER_LEVEL", soldierId, level, acceptInsert: true);
	}

	public static int GetSoldierExp(this UserArchiveManager manager, string soldierId)
	{
		return manager.GetValueOfDictConfig<int>("SOLDIER_EXPERIENCE", soldierId);
	}

	public static void SetSoldierExp(this UserArchiveManager manager, string soldierId, int exp)
	{
		manager.SetValueOfDictConfig("SOLDIER_EXPERIENCE", soldierId, exp, acceptInsert: true);
		manager.Managers.Messenger.Broadcast("ON_SOLDIER_GET_EXP", soldierId, exp);
	}

	public static string GetSoldierSkin(this UserArchiveManager manager, string soldierId)
	{
		if (!Regex.IsMatch(soldierId, "^S\\d{3}$"))
		{
			return GDMgr.Get<GDESoldierData>(soldierId)?.Skin ?? "skin1";
		}
		Dictionary<string, string> configValue = manager.GetConfigValue<Dictionary<string, string>>("SOLDIER_SKIN");
		int num = (manager.GetSoldierPotentialLevel(soldierId) + 2) / 2;
		if (configValue != null)
		{
			if (configValue.TryGetValue(soldierId, out var value))
			{
				return value;
			}
			value = GDMgr.Get<GDESoldierData>(soldierId)?.Skin;
			if (string.IsNullOrEmpty(value))
			{
				value = $"skin{num}";
			}
			manager.AddToDictConfig("SOLDIER_SKIN", soldierId, value);
			return value;
		}
		return $"skin{num}";
	}

	public static string GetSoldierSkin(this UserArchiveManager manager, Soldier soldier)
	{
		return manager.GetSoldierSkin(soldier.Id);
	}

	public static void SetSoldierSkin(this UserArchiveManager manager, string soldierId, string skin)
	{
		manager.SetValueOfDictConfig("SOLDIER_SKIN", soldierId, skin);
	}

	public static void SetSoldierSkin(this UserArchiveManager manager, Soldier soldier, string skin)
	{
		manager.SetSoldierSkin(soldier.Id, skin);
	}

	public static List<string> GetUnlockedSoldiers(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<List<string>>("UNLOCK_SOLDIER");
	}

	internal static void SetUnlockedSoldiers(this UserArchiveManager manager, List<string> value)
	{
		manager.SetConfigValue("UNLOCK_SOLDIER", value);
	}

	public static bool UnlockSoldier(this UserArchiveManager manager, string soldierId, int potentialLevel = 0, int getVolunteers = -1, string reason = null)
	{
		List<string> unlockedSoldiers = manager.GetUnlockedSoldiers();
		if (unlockedSoldiers.IndexOf(soldierId) == -1)
		{
			manager.AddToList("UNLOCK_SOLDIER", soldierId);
			manager.SetSoldierLevel(soldierId, 1);
			manager.SetSoldierEvolutionLevel(soldierId, 1);
			manager.SetSoldierExp(soldierId, 0);
			manager.SetSoldierPotentialLevel(soldierId, potentialLevel);
			if (getVolunteers < 0)
			{
				getVolunteers = ((!(soldierId == "S001") && !(soldierId == "S002") && !(soldierId == "S005")) ? ConfigDataManager.VolunteersOnSoldierUnlock : 10);
			}
			manager.Managers.StockController.ReadStockChangeRecords(new StockChangeRecord[1]
			{
				new StockChangeRecord
				{
					ItemId = soldierId,
					Offset = getVolunteers,
					Context = 4,
					ContextValue = reason,
					Type = 1
				}
			});
			return true;
		}
		return false;
	}
}
