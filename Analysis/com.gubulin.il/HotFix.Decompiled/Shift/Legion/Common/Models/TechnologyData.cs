using System;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public static class TechnologyData
{
	private static Dictionary<string, Dictionary<int, Dictionary<string, int>>> _upgradeRequirements;

	private static Dictionary<string, Dictionary<int, Dictionary<string, int>>> UpgradeRequirements
	{
		get
		{
			if (_upgradeRequirements == null)
			{
				_upgradeRequirements = new Dictionary<string, Dictionary<int, Dictionary<string, int>>>();
				foreach (string technologyKey in TechnologyManager.TechnologyKeys)
				{
					Dictionary<int, Dictionary<string, int>> dictionary = new Dictionary<int, Dictionary<string, int>>();
					GDETechnologyData gDETechnologyData = GDMgr.Get<GDETechnologyData>(technologyKey);
					if (gDETechnologyData != null)
					{
						int num = 1;
						string name = $"Level{num}Cost";
						for (object obj = gDETechnologyData.GetType().GetProperty(name)?.GetValue(gDETechnologyData); obj != null; obj = gDETechnologyData.GetType().GetProperty(name)?.GetValue(gDETechnologyData))
						{
							string text = obj.ToString();
							if (string.IsNullOrEmpty(text))
							{
								break;
							}
							dictionary.Add(num, JsonHelper.ToObject<Dictionary<string, int>>(text));
							name = $"Level{++num}Cost";
						}
					}
					_upgradeRequirements.Add(technologyKey, dictionary);
				}
			}
			return _upgradeRequirements;
		}
	}

	public static Dictionary<string, int> GetUpgradeRequirements(string techId, int level = 0)
	{
		if (UpgradeRequirements[techId].TryGetValue(level, out var value))
		{
			return value;
		}
		return null;
	}

	public static Dictionary<int, List<Modifier>> Effects(GameManagers managers, string techId)
	{
		Dictionary<int, List<Modifier>> dictionary = new Dictionary<int, List<Modifier>>();
		if (TechnologyManager.TechnologyEffectDataDictionary.TryGetValue(techId, out var value))
		{
			foreach (KeyValuePair<int, List<GDETechnologyEffectData>> item2 in value)
			{
				int key = item2.Key;
				if (!dictionary.ContainsKey(key))
				{
					dictionary.Add(key, new List<Modifier>());
				}
				foreach (GDETechnologyEffectData item3 in item2.Value)
				{
					Modifier item = new Modifier(managers, item3.ModifierId, item3.Payload);
					if (!item.PayloadDictionary.TryGetValue("Payload", out var value2))
					{
						value2 = item.PayloadDictionary.Values.First();
					}
					item.Desc = (string.IsNullOrEmpty(item3.Desc) ? Modifier.ParseModifiedValue(value2) : item3.Desc.Replace("{Payload}", value2.ToString()));
					dictionary[key].Add(item);
				}
			}
		}
		return dictionary;
	}

	public static List<Modifier> GetEffects(GameManagers managers, string techId, int level = 0)
	{
		Dictionary<int, List<Modifier>> dictionary = Effects(managers, techId);
		if (dictionary.TryGetValue(level, out var value))
		{
			return value;
		}
		return null;
	}

	public static GDETechnologyEffectData GetEffect(string techId, int level)
	{
		if (TechnologyManager.TechnologyEffectDataDictionary.TryGetValue(techId, out var value) && value.TryGetValue(level, out var value2))
		{
			return value2[0];
		}
		return null;
	}

	public static Action Upgrade(GameManagers managers, string techId, bool free = false, bool broadcastInform = true)
	{
		if (free || CanUpgrade(managers, techId))
		{
			if (!free)
			{
				ConsumeUpgrade(managers, techId);
			}
			int techLevel = managers.UserArchiveManager.GetTechLevel(techId);
			int nextLevel = techLevel + 1;
			List<Modifier> effects = GetEffects(managers, techId, techLevel);
			List<Modifier> effects2 = GetEffects(managers, techId, nextLevel);
			if (effects != null)
			{
				foreach (Modifier item in effects)
				{
					if (!(item.ModifierId == "Bonus"))
					{
						managers.ModifierManager.ReadFromModifier(item, -1);
					}
				}
			}
			foreach (Modifier item2 in effects2)
			{
				managers.ModifierManager.ReadFromModifier(item2);
			}
			managers.UserArchiveManager.SetTechLevel(techId, nextLevel);
			Action action = delegate
			{
				managers.Messenger.Broadcast("TECH_UPGRADED", techId, nextLevel);
			};
			Action b = managers.TechnologyManager.CheckArtifactLevel(techId, broadcastInform);
			if (broadcastInform)
			{
				action();
			}
			else
			{
				action = (Action)Delegate.Combine(action, b);
			}
			return action;
		}
		return null;
	}

	public static bool CanUpgrade(GameManagers managers, string techId)
	{
		int level = managers.UserArchiveManager.GetTechLevel(techId) + 1;
		GDETechnologyData gDETechnologyData = GDMgr.Get<GDETechnologyData>(techId);
		if (gDETechnologyData == null)
		{
			return false;
		}
		if (!FrontTechsSatisfied(techId))
		{
			return false;
		}
		if (IsMaxLevel(techId))
		{
			return false;
		}
		Dictionary<string, int> upgradeRequirements = GetUpgradeRequirements(techId, level);
		if (upgradeRequirements == null)
		{
			return true;
		}
		foreach (KeyValuePair<string, int> item in upgradeRequirements)
		{
			if (managers.StockController.GetStock(item.Key) < item.Value)
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsMaxLevel(string techId)
	{
		GameManagers instance = GameManagers.Instance;
		int techLevel = instance.UserArchiveManager.GetTechLevel(techId);
		int maxLevel = GetMaxLevel();
		return techLevel >= maxLevel;
	}

	public static int GetMaxLevel()
	{
		return 5;
	}

	public static bool FrontTechsSatisfied(string techId)
	{
		GameManagers instance = GameManagers.Instance;
		int techLevel = instance.UserArchiveManager.GetTechLevel(techId);
		GDETechnologyData gDETechnologyData = GDMgr.Get<GDETechnologyData>(techId);
		if (gDETechnologyData == null)
		{
			return true;
		}
		if (IsFirstTechNode(techId))
		{
			int weaponLevel = GetWeaponLevel((TechnologyType)gDETechnologyData.Type);
			return weaponLevel >= techLevel;
		}
		foreach (string frontTech in gDETechnologyData.FrontTechs)
		{
			if (instance.UserArchiveManager.GetTechLevel(frontTech) <= techLevel)
			{
				continue;
			}
			GDETechnologyData gDETechnologyData2 = GDMgr.Get<GDETechnologyData>(frontTech);
			if (gDETechnologyData2 != null)
			{
				int techLevel2 = instance.UserArchiveManager.GetTechLevel(frontTech);
				if (techLevel2 > techLevel)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool IsFirstTechNode(string techId)
	{
		GDETechnologyData gDETechnologyData = GDMgr.Get<GDETechnologyData>(techId);
		return gDETechnologyData.FrontTechs == null || gDETechnologyData.FrontTechs.Count < 1;
	}

	private static void ConsumeUpgrade(GameManagers managers, string techId)
	{
		Dictionary<string, int> upgradeRequirements = GetUpgradeRequirements(techId, managers.UserArchiveManager.GetTechLevel(techId) + 1);
		if (upgradeRequirements == null)
		{
			return;
		}
		StockChangeRecord[] array = new StockChangeRecord[upgradeRequirements.Count];
		int num = 0;
		foreach (KeyValuePair<string, int> item in upgradeRequirements)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = item.Key,
				Offset = -item.Value,
				Context = 21,
				ContextValue = techId,
				Type = 1
			};
		}
		managers.StockController.ReadStockChangeRecords(array);
	}

	public static int GetWeaponLevel(TechnologyType type)
	{
		string text = null;
		return ArchiveExtension_Tech.GetTechLevel(techId: type switch
		{
			TechnologyType.Dominion => "T000", 
			TechnologyType.Doom => "H000", 
			TechnologyType.Slavery => "N000", 
			_ => throw new ArgumentOutOfRangeException("type", type, null), 
		}, manager: GameManagers.Instance.UserArchiveManager);
	}
}
