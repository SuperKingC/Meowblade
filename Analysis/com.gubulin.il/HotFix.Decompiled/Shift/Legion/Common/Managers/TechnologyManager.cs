using System;
using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public class TechnologyManager : Manager
{
	private static List<string> _technologyKeys;

	private static Dictionary<string, Dictionary<int, List<GDETechnologyEffectData>>> _technologyEffectDataDictionary;

	private static List<string> _doomTechnologies;

	private static List<string> _dominionTechnologies;

	private static List<string> _slaveryTechnologies;

	public static string DoomArtifactKey = "H000";

	public static string SlaveryArtifactKey = "N000";

	public static string DominionArtifactKey = "T000";

	public static int MaxTechnologyLevel = 10;

	public static List<string> TechnologyKeys
	{
		get
		{
			if (_technologyKeys == null)
			{
				_technologyKeys = new List<string>();
				IEnumerable<GDETechnologyData> allItems = GDMgr.GetAllItems<GDETechnologyData>();
				foreach (GDETechnologyData item in allItems)
				{
					_technologyKeys.Add(item.Key);
				}
			}
			return _technologyKeys;
		}
	}

	public static Dictionary<string, Dictionary<int, List<GDETechnologyEffectData>>> TechnologyEffectDataDictionary
	{
		get
		{
			if (_technologyEffectDataDictionary == null)
			{
				_technologyEffectDataDictionary = new Dictionary<string, Dictionary<int, List<GDETechnologyEffectData>>>();
				foreach (GDETechnologyEffectData allItem in GDMgr.GetAllItems<GDETechnologyEffectData>())
				{
					string techId = allItem.TechId;
					int level = allItem.Level;
					if (!_technologyEffectDataDictionary.ContainsKey(techId))
					{
						_technologyEffectDataDictionary.Add(techId, new Dictionary<int, List<GDETechnologyEffectData>>());
					}
					if (!_technologyEffectDataDictionary[techId].ContainsKey(level))
					{
						_technologyEffectDataDictionary[techId].Add(level, new List<GDETechnologyEffectData>());
					}
					_technologyEffectDataDictionary[techId][level].Add(allItem);
				}
			}
			return _technologyEffectDataDictionary;
		}
	}

	public static List<string> DoomTechnologies
	{
		get
		{
			if (_doomTechnologies == null)
			{
				_doomTechnologies = new List<string>();
				foreach (string technologyKey in TechnologyKeys)
				{
					if (IsDoomTechnology(technologyKey))
					{
						_doomTechnologies.Add(technologyKey);
					}
				}
			}
			return _doomTechnologies;
		}
	}

	public static List<string> DominionTechnologies
	{
		get
		{
			if (_dominionTechnologies == null)
			{
				_dominionTechnologies = new List<string>();
				foreach (string technologyKey in TechnologyKeys)
				{
					if (IsDominionTechnology(technologyKey))
					{
						_dominionTechnologies.Add(technologyKey);
					}
				}
			}
			return _dominionTechnologies;
		}
	}

	public static List<string> SlaveryTechnologies
	{
		get
		{
			if (_slaveryTechnologies == null)
			{
				_slaveryTechnologies = new List<string>();
				foreach (string technologyKey in TechnologyKeys)
				{
					if (IsSlaveryTechnology(technologyKey))
					{
						_slaveryTechnologies.Add(technologyKey);
					}
				}
			}
			return _slaveryTechnologies;
		}
	}

	public TechnologyManager(GameManagers managers)
		: base(managers)
	{
	}

	public override void AddEventListener()
	{
	}

	public override void RemoveEventListener()
	{
	}

	public Action Upgrade(string techId, bool free = false, bool broadcastInform = true)
	{
		if (!TechnologyKeys.Contains(techId))
		{
			return null;
		}
		return TechnologyData.Upgrade(Managers, techId, free, broadcastInform);
	}

	public Action CheckArtifactLevel(string techId, bool broadcastInform = true)
	{
		List<string> list = null;
		int num = 0;
		string artifactKey = "";
		if (IsDoomTechnology(techId))
		{
			list = DoomTechnologies;
			num = Managers.UserArchiveManager.GetDoomArtifactLevel();
			artifactKey = DoomArtifactKey;
		}
		else if (IsDominionTechnology(techId))
		{
			list = DominionTechnologies;
			num = Managers.UserArchiveManager.GetDominionArtifactLevel();
			artifactKey = DominionArtifactKey;
		}
		else if (IsSlaveryTechnology(techId))
		{
			list = SlaveryTechnologies;
			num = Managers.UserArchiveManager.GetSlaveryArtifactLevel();
			artifactKey = SlaveryArtifactKey;
		}
		if (list != null)
		{
			int artifactLevelAfterCheck = int.MaxValue;
			foreach (string item in list)
			{
				if (!(item == artifactKey))
				{
					int techLevel = Managers.UserArchiveManager.GetTechLevel(item);
					if (techLevel < artifactLevelAfterCheck)
					{
						artifactLevelAfterCheck = techLevel;
					}
				}
			}
			if (artifactLevelAfterCheck > num)
			{
				List<Modifier> effects = TechnologyData.GetEffects(Managers, artifactKey, num);
				List<Modifier> effects2 = TechnologyData.GetEffects(Managers, artifactKey, artifactLevelAfterCheck);
				if (effects != null)
				{
					foreach (Modifier item2 in effects)
					{
						if (!(item2.ModifierId == "Bonus"))
						{
							Managers.ModifierManager.ReadFromModifier(item2, -1);
						}
					}
				}
				foreach (Modifier item3 in effects2)
				{
					Managers.ModifierManager.ReadFromModifier(item3);
				}
				Managers.UserArchiveManager.SetTechLevel(artifactKey, artifactLevelAfterCheck);
				Action action = delegate
				{
					Managers.Messenger.Broadcast("TECH_UPGRADED", artifactKey, artifactLevelAfterCheck);
				};
				if (broadcastInform)
				{
					action();
				}
				return action;
			}
		}
		return null;
	}

	public static bool IsDoomTechnology(string techId)
	{
		return techId.IndexOf('H') == 0;
	}

	public static bool IsSlaveryTechnology(string techId)
	{
		return techId.IndexOf('N') == 0;
	}

	public static bool IsDominionTechnology(string techId)
	{
		return techId.IndexOf('T') == 0;
	}

	public List<Modifier> GetTechEffects(string techId, int level)
	{
		return TechnologyData.GetEffects(Managers, techId, level);
	}

	public bool TechCanUpgrade(string techId)
	{
		return TechnologyData.CanUpgrade(Managers, techId);
	}

	public bool IsUnlockDuplicated(string techId)
	{
		return Managers.UserArchiveManager.GetTechLevel(techId) > 0;
	}

	public bool CanReset()
	{
		Dictionary<string, int> resetCost = GetResetCost();
		foreach (KeyValuePair<string, int> item in resetCost)
		{
			if (Managers.StockController.GetStock(item.Key) < item.Value)
			{
				return false;
			}
		}
		return true;
	}

	public Dictionary<string, int> GetResetCost()
	{
		return Managers.UserArchiveManager.GetConfig<Dictionary<string, int>>("TECH_RESET_COST").GetValue();
	}

	public void ConsumeReset()
	{
		Dictionary<string, int> resetCost = GetResetCost();
		StockChangeRecord[] array = new StockChangeRecord[resetCost.Count];
		int num = 0;
		foreach (KeyValuePair<string, int> item in resetCost)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = item.Key,
				Offset = -item.Value,
				Context = 21,
				Type = 1
			};
		}
		Managers.StockController.ReadStockChangeRecords(array);
	}

	public void ResetAllTechnologies()
	{
		ConsumeReset();
		List<string> list = new List<string>();
		list.AddRange(_doomTechnologies);
		list.AddRange(_dominionTechnologies);
		list.AddRange(_slaveryTechnologies);
		ResetTechnologies(list);
	}

	private void ResetTechnologies(List<string> techList)
	{
		List<StockChangeRecord> list = new List<StockChangeRecord>();
		foreach (string tech in techList)
		{
			int techLevel = Managers.UserArchiveManager.GetTechLevel(tech);
			if (techLevel < 1)
			{
				continue;
			}
			for (int i = 1; i <= techLevel; i++)
			{
				List<Modifier> effects = TechnologyData.GetEffects(Managers, tech, i);
				if (effects == null || effects.Count < 1)
				{
					continue;
				}
				foreach (Modifier item in effects)
				{
					if (item.ModifierId == "Bonus" || i == techLevel)
					{
						Managers.ModifierManager.ReadFromModifier(item, -1);
					}
				}
				Dictionary<string, int> upgradeRequirements = TechnologyData.GetUpgradeRequirements(tech, i);
				if (upgradeRequirements == null)
				{
					continue;
				}
				int num = 0;
				foreach (KeyValuePair<string, int> item2 in upgradeRequirements)
				{
					list.Add(new StockChangeRecord
					{
						ItemId = item2.Key,
						Offset = item2.Value,
						Context = 21,
						ContextValue = tech,
						Type = 1
					});
				}
			}
			Managers.UserArchiveManager.SetTechLevel(tech, 0);
		}
		Managers.StockController.ReadStockChangeRecords(list);
		foreach (string key in GameManagers.Instance.StockController.GetOwnedSoldiers(onlyUnlocked: true).Keys)
		{
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(key);
			soldier.EnsureAttr();
		}
		GameManagers.Instance.SoldierManager.CurrentMaxLegionPower.SetValue(LegionHelper.GetPlayerMaxPossibleCombatPower(Managers));
	}

	public void CheckTechnologyEffect()
	{
		foreach (string technologyKey in TechnologyKeys)
		{
			int techLevel = Managers.UserArchiveManager.GetTechLevel(technologyKey);
			if (techLevel < 1)
			{
				continue;
			}
			Dictionary<string, Modifier> dictionary = new Dictionary<string, Modifier>();
			for (int i = 0; i < techLevel; i++)
			{
				List<Modifier> techEffects = GetTechEffects(technologyKey, i);
				if (techEffects == null)
				{
					continue;
				}
				foreach (Modifier item in techEffects)
				{
					string modifierId = item.ModifierId;
					if (modifierId == "Bonus")
					{
						if (item.PayloadDictionary.TryGetValue("Unlock", out var value))
						{
							Modifier modifier = new Modifier(Managers, "Unlock", new Dictionary<string, object> { { "Unlock", value } });
							Managers.ModifierManager.ReadFromModifier(modifier);
						}
					}
					else if (!(modifierId == "OfflineYieldTimeLimit") && !(modifierId == "TimeMachine"))
					{
						if (dictionary.TryGetValue(modifierId, out var value2))
						{
							dictionary.Remove(modifierId);
							Managers.ModifierManager.ReadFromModifier(value2, -1);
						}
						dictionary.Add(modifierId, item);
						Managers.ModifierManager.ReadFromModifier(value2);
					}
				}
			}
		}
	}
}
