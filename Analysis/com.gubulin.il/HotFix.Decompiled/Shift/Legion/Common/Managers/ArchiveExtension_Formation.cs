using System;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;
using UI.Battle;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_Formation
{
	private const string FormationLevelKey = "FORMATION_LEVEL";

	private const string UnlockFormationKey = "UNLOCK_FORMATION";

	private const string CurrentFormationKey = "CURRENT_FORMATION";

	private const string RankFormationUnitsKey = "RANK_FORMATION_UNITS";

	private const string PvPRankProgressKey = "PvPRankProgressKey";

	public static Dictionary<string, Dictionary<string, string>> GetCurrentFormation(this UserArchiveManager manager)
	{
		Dictionary<string, Dictionary<string, string>> configValue = manager.GetConfigValue<Dictionary<string, Dictionary<string, string>>>("CURRENT_FORMATION");
		foreach (object value in Enum.GetValues(typeof(ChapterType)))
		{
			string text = value.ToString();
			if (text == ChapterType.StorySub.ToString() || text == ChapterType.StoryTransition.ToString())
			{
				text = ChapterType.StoryMain.ToString();
			}
			if (!configValue.ContainsKey(text))
			{
				configValue.Add(text, new Dictionary<string, string>());
			}
			foreach (object value2 in Enum.GetValues(typeof(BattleMode)))
			{
				string key = value2.ToString();
				if (!configValue[text].ContainsKey(key))
				{
					if (value2 is BattleMode battleMode && battleMode == BattleMode.DefenceMode)
					{
						configValue[text].Add(key, "FFB_01");
					}
					else
					{
						configValue[text].Add(key, "FA01");
					}
				}
			}
		}
		return configValue;
	}

	public static string GetCurrentFormation(this UserArchiveManager manager, string context, string subContext)
	{
		GDELevelAssistanceData gDELevelAssistanceData = null;
		if (GDMgr.Has<GDELevelAssistanceData>(context))
		{
			gDELevelAssistanceData = GDMgr.Get<GDELevelAssistanceData>(context);
		}
		if (gDELevelAssistanceData != null && (gDELevelAssistanceData.ChapterId == "C10000" || gDELevelAssistanceData.ChapterId == "C10001"))
		{
			GameLocalDataManager.LevelAssistanceFormation levelAssistanceBattleFormation = GameLocalDataManager.GetLevelAssistanceBattleFormation();
			if (levelAssistanceBattleFormation != null && levelAssistanceBattleFormation.LevelId == context.Replace("LevelAssistance_", ""))
			{
				return levelAssistanceBattleFormation.FormationId;
			}
			return gDELevelAssistanceData.AssistanceFormation;
		}
		if (gDELevelAssistanceData != null && GameManagers.Instance.UserArchiveManager.IsNewGuideMode())
		{
			return gDELevelAssistanceData.AssistanceFormation;
		}
		Dictionary<string, Dictionary<string, string>> currentFormation = manager.GetCurrentFormation();
		if (currentFormation.TryGetValue(context, out var value) && value.TryGetValue(subContext, out var value2))
		{
			return value2;
		}
		return "FA01";
	}

	public static void SetCurrentFormation(this UserArchiveManager manager, string context, string subContext, string formationId, bool fromServer = false)
	{
		if (GDMgr.Has<GDELevelAssistanceData>(context))
		{
			GDELevelAssistanceData gDELevelAssistanceData = GDMgr.Get<GDELevelAssistanceData>(context);
			if (gDELevelAssistanceData.ChapterId == "C10000" || gDELevelAssistanceData.ChapterId == "C10001")
			{
				GameLocalDataManager.LevelAssistanceFormation levelAssistanceFormation = GameLocalDataManager.GetLevelAssistanceBattleFormation();
				if (levelAssistanceFormation == null || levelAssistanceFormation.LevelId != context.Replace("LevelAssistance_", ""))
				{
					levelAssistanceFormation = new GameLocalDataManager.LevelAssistanceFormation
					{
						LevelId = context.Replace("LevelAssistance_", ""),
						FormationId = gDELevelAssistanceData.AssistanceFormation,
						UnitsId = gDELevelAssistanceData.AssistanceSoldier.ToList()
					};
				}
				else if (!fromServer)
				{
					levelAssistanceFormation.FormationId = formationId;
				}
				GameLocalDataManager.SetLevelAssistanceBattleFormation(levelAssistanceFormation);
				return;
			}
		}
		Dictionary<string, Dictionary<string, string>> currentFormation = manager.GetCurrentFormation();
		if (!currentFormation.ContainsKey(context))
		{
			currentFormation.Add(context, new Dictionary<string, string>());
		}
		if (currentFormation[context].ContainsKey(subContext))
		{
			currentFormation[context][subContext] = formationId;
		}
		else
		{
			currentFormation[context].Add(subContext, formationId);
		}
		manager.SetConfigValue("CURRENT_FORMATION", currentFormation);
	}

	private static Dictionary<string, string> GetBattleFormationConfigs(this UserArchiveManager manager, string context, string subContext)
	{
		if (context == ChapterType.StorySub.ToString() || context == ChapterType.StoryTransition.ToString())
		{
			context = ChapterType.StoryMain.ToString();
		}
		else if (context == ChapterType.RepeatableInstanceDefensive.ToString() || context == ChapterType.RepeatableInstanceOffensive.ToString())
		{
			context = ChapterType.RepeatableInstance.ToString();
		}
		GDELevelAssistanceData levelAssistanceConfig = null;
		if (GDMgr.Has<GDELevelAssistanceData>(context) && GameManagers.Instance.UserArchiveManager.IsNewGuideMode())
		{
			levelAssistanceConfig = GDMgr.Get<GDELevelAssistanceData>(context);
		}
		string text = string.Empty;
		if (levelAssistanceConfig != null)
		{
			text = context.Substring(16);
		}
		Dictionary<string, Dictionary<string, string>> dictionary = manager.GetConfigValue<Dictionary<string, Dictionary<string, string>>>(context + "FORMATION");
		bool flag = false;
		if (dictionary == null)
		{
			dictionary = new Dictionary<string, Dictionary<string, string>>();
			flag = true;
		}
		if (!dictionary.TryGetValue(subContext, out var value))
		{
			value = new Dictionary<string, string>();
			for (int i = 0; i < 12; i++)
			{
				value.Add($"Pos{i}", "Unlock");
			}
			dictionary.Add(subContext, value);
			flag = true;
		}
		if (flag && levelAssistanceConfig == null)
		{
			manager.SetConfigValue(context + "FORMATION", dictionary);
		}
		if (levelAssistanceConfig != null)
		{
			GameLocalDataManager.LevelAssistanceFormation levelAssistanceFormation = GameLocalDataManager.GetLevelAssistanceBattleFormation();
			if (levelAssistanceFormation == null)
			{
				levelAssistanceFormation = new GameLocalDataManager.LevelAssistanceFormation
				{
					LevelId = text,
					FormationId = levelAssistanceConfig.AssistanceFormation,
					UnitsId = levelAssistanceConfig.AssistanceSoldier.ToList()
				};
			}
			if (levelAssistanceFormation != null)
			{
				for (int j = 0; j < levelAssistanceFormation.UnitsId.Count; j++)
				{
					string text2 = levelAssistanceFormation.UnitsId[j];
					GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(text2);
					if (gDESoldierData != null && gDESoldierData.IsPlayer)
					{
						value[$"Pos{j}"] = text2;
					}
					else
					{
						value[$"Pos{j}"] = "Unlock";
					}
				}
			}
			for (int k = 0; k < value.Count; k++)
			{
				if (levelAssistanceConfig.LockPosition.Contains(k + 1))
				{
					value[$"Pos{k}"] = "Lock";
				}
				else if (GDMgr.Get<GDESoldierData>(value[$"Pos{k}"]) == null)
				{
					value[$"Pos{k}"] = "Unlock";
				}
			}
			List<string> unlockedSoldiers = GameManagers.Instance.UserArchiveManager.GetUnlockedSoldiers();
			List<string> list = new List<string>(value.Values);
			IEnumerable<string> source = levelAssistanceConfig.AssistanceSoldier.Select((string _soldierId) => SoldierManager.GetRootIdForSoldier(_soldierId));
			bool flag2 = true;
			List<string> list2 = null;
			if (levelAssistanceFormation != null)
			{
				list2 = levelAssistanceFormation.UnitsId.Where((string _id) => !_id.Equals("Lock") && !_id.Equals("Unlock")).ToList();
				if ((GameManagers.Instance.UserArchiveManager.IsNewGuideMode2() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode2() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode3() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode3()) && (levelAssistanceConfig.ChapterId == "C10000" || levelAssistanceConfig.ChapterId == "C10001"))
				{
					bool flag3 = list2.All((string item) => levelAssistanceConfig.AssistanceSoldier.Contains(item));
					flag2 = !flag3;
				}
			}
			if (flag2)
			{
				for (int num = 0; num < levelAssistanceConfig.AssistanceSoldier.Count; num++)
				{
					string text3 = levelAssistanceConfig.AssistanceSoldier[num];
					string rootIdForSoldier = SoldierManager.GetRootIdForSoldier(text3);
					int num2 = levelAssistanceConfig.AssistancePosition[num];
					string value2;
					if (unlockedSoldiers.Contains(rootIdForSoldier))
					{
						GDESoldierData data = GDMgr.Get<GDESoldierData>(rootIdForSoldier);
						GameEntityData gameEntityData = GameEntityData.ResetForSoldier(data, manager.GetSoldierPotentialLevel(rootIdForSoldier));
						GDESoldierData gDESoldierData2 = GDMgr.Get<GDESoldierData>(text3);
						GameEntityData gameEntityData2 = GameEntityData.ResetForSoldier(gDESoldierData2, gDESoldierData2.PotentialLevel);
						value2 = ((gameEntityData.CombatPower > gameEntityData2.CombatPower) ? rootIdForSoldier : text3);
					}
					else
					{
						value2 = text3;
					}
					int num3 = list.IndexOf(rootIdForSoldier);
					if (num3 != -1)
					{
						value[$"Pos{num3}"] = "Unlock";
					}
					value[$"Pos{num2 - 1}"] = value2;
				}
			}
			else
			{
				for (int num4 = 0; num4 < 5; num4++)
				{
					if (list2.Count <= 0)
					{
						break;
					}
					string key = $"Pos{num4}";
					value[key] = list2[num4];
				}
			}
			list.Clear();
			list.AddRange(value.Values);
			Queue<string> queue = new Queue<string>();
			if (levelAssistanceFormation != null && levelAssistanceFormation.LevelId != text)
			{
				foreach (string item in levelAssistanceFormation.UnitsId)
				{
					if (!list.Contains(item) && !source.Contains(item))
					{
						GDESoldierData gDESoldierData3 = GDMgr.Get<GDESoldierData>(item);
						if (gDESoldierData3 != null && gDESoldierData3.IsPlayer && !queue.Contains(item))
						{
							queue.Enqueue(item);
						}
					}
				}
			}
			Dictionary<string, Dictionary<string, string>> configValue = manager.GetConfigValue<Dictionary<string, Dictionary<string, string>>>("StoryMainFORMATION");
			if (configValue != null && configValue.TryGetValue("RushMode", out var value3))
			{
				foreach (string value4 in value3.Values)
				{
					if (!list.Contains(value4) && !source.Contains(value4))
					{
						GDESoldierData gDESoldierData4 = GDMgr.Get<GDESoldierData>(value4);
						if (gDESoldierData4 != null && gDESoldierData4.IsPlayer && !queue.Contains(value4))
						{
							queue.Enqueue(value4);
						}
					}
				}
			}
			for (int num5 = 0; num5 < 5; num5++)
			{
				if (queue.Count <= 0)
				{
					break;
				}
				string key2 = $"Pos{num5}";
				if (value[key2] == "Unlock")
				{
					value[key2] = queue.Dequeue();
				}
			}
		}
		return value;
	}

	public static Dictionary<string, string> GetBattleFormation(this UserArchiveManager manager, string context, string subContext)
	{
		return manager.GetBattleFormationConfigs(context, subContext);
	}

	public static string GetBattleFormation(this UserArchiveManager manager, int pos, string context, string subContext)
	{
		Dictionary<string, string> battleFormationConfigs = manager.GetBattleFormationConfigs(context, subContext);
		if (!battleFormationConfigs.TryGetValue($"Pos{pos}", out var value))
		{
			return null;
		}
		return value;
	}

	public static void SetBattleFormation(this UserArchiveManager manager, int pos, string soldierId, string context, string subContext)
	{
		if (context == ChapterType.StorySub.ToString() || context == ChapterType.StoryTransition.ToString())
		{
			context = ChapterType.StoryMain.ToString();
		}
		else if (context == ChapterType.RepeatableInstanceDefensive.ToString() || context == ChapterType.RepeatableInstanceOffensive.ToString())
		{
			context = ChapterType.RepeatableInstance.ToString();
		}
		if (context.StartsWith("LevelAssistance_"))
		{
			if (!GDMgr.Has<GDELevelAssistanceData>(context))
			{
				ILRuntimeDebug.LogError("SetBattleFormation Error , context=" + context + " but has No levelAssistanceConfig");
				return;
			}
			GameLocalDataManager.LevelAssistanceFormation levelAssistanceFormation = null;
			GDELevelAssistanceData gDELevelAssistanceData = GDMgr.Get<GDELevelAssistanceData>(context);
			string levelId = gDELevelAssistanceData.Key.Replace("LevelAssistance_", "");
			if (gDELevelAssistanceData.ChapterId == "C10000" || gDELevelAssistanceData.ChapterId == "C10001")
			{
				levelAssistanceFormation = GameLocalDataManager.GetLevelAssistanceBattleFormation();
				if (levelAssistanceFormation == null)
				{
					levelAssistanceFormation = new GameLocalDataManager.LevelAssistanceFormation
					{
						LevelId = levelId,
						FormationId = gDELevelAssistanceData.AssistanceFormation,
						UnitsId = gDELevelAssistanceData.AssistanceSoldier.ToList()
					};
				}
			}
			else
			{
				levelAssistanceFormation = new GameLocalDataManager.LevelAssistanceFormation
				{
					LevelId = levelId,
					FormationId = gDELevelAssistanceData.AssistanceFormation,
					UnitsId = UI_Battle.GetFormationUnits(context, subContext)
				};
			}
			for (int i = 0; i <= pos; i++)
			{
				if (i >= levelAssistanceFormation.UnitsId.Count)
				{
					levelAssistanceFormation.UnitsId.Add("Unlock");
				}
			}
			levelAssistanceFormation.UnitsId[pos] = soldierId;
			GameLocalDataManager.SetLevelAssistanceBattleFormation(levelAssistanceFormation);
		}
		else
		{
			Dictionary<string, Dictionary<string, string>> configValue = manager.GetConfigValue<Dictionary<string, Dictionary<string, string>>>(context + "FORMATION");
			if (configValue.TryGetValue(subContext, out var value) && value.TryGetValue($"Pos{pos}", out var _))
			{
				value[$"Pos{pos}"] = soldierId;
				manager.SetConfigValue(context + "FORMATION", configValue);
			}
		}
	}

	public static void SetBattleFormation(this UserArchiveManager manager, string formationContext, string subContext, Dictionary<string, string> formationUnits)
	{
		string key = formationContext + "FORMATION";
		Dictionary<string, Dictionary<string, string>> dictionary = manager.GetConfigValue<Dictionary<string, Dictionary<string, string>>>(key) ?? new Dictionary<string, Dictionary<string, string>>();
		if (dictionary.ContainsKey(subContext))
		{
			dictionary[subContext] = formationUnits;
		}
		else
		{
			dictionary.Add(subContext, formationUnits);
		}
		manager.SetConfigValue(key, dictionary);
	}

	public static List<string> GetUnlockedFormations(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<List<string>>("UNLOCK_FORMATION");
	}

	public static void UnlockFormation(this UserArchiveManager manager, string formationId)
	{
		List<string> unlockedFormations = manager.GetUnlockedFormations();
		if (!unlockedFormations.Contains(formationId))
		{
			unlockedFormations.Add(formationId);
			manager.SetConfigValue("UNLOCK_FORMATION", unlockedFormations);
			manager.SetValueOfDictConfig("FORMATION_LEVEL", formationId, 1, acceptInsert: true);
			manager.Managers.Messenger.Broadcast("FORMATION_UNLOCKED", formationId);
		}
	}

	public static void LockFormation(this UserArchiveManager manager, string formationId)
	{
		List<string> unlockedFormations = manager.GetUnlockedFormations();
		if (unlockedFormations.Contains(formationId))
		{
			unlockedFormations.Remove(formationId);
			manager.SetConfigValue("UNLOCK_FORMATION", unlockedFormations);
			Dictionary<string, int> configValue = manager.GetConfigValue<Dictionary<string, int>>("FORMATION_LEVEL");
			configValue.Remove(formationId);
			manager.SetConfigValue("FORMATION_LEVEL", configValue);
			manager.Managers.Messenger.Broadcast("FORMATION_LOCKED", formationId);
		}
	}

	public static RankBattleFormationUnitsConfig GetRankBattleFormationConfig(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<RankBattleFormationUnitsConfig>("RANK_FORMATION_UNITS");
	}

	public static void SetRankBattleFormationConfig(this UserArchiveManager manager, List<string> formationsId, List<List<string>> unitsId)
	{
		RankBattleFormationUnitsConfig rankBattleFormationUnitsConfig = new RankBattleFormationUnitsConfig();
		for (int i = 0; i < 3; i++)
		{
			rankBattleFormationUnitsConfig.UnitsId.Add(new List<string>());
			bool flag = unitsId != null && unitsId.Count > i;
			for (int j = 0; j < 12; j++)
			{
				if (flag && j < unitsId[i].Count)
				{
					rankBattleFormationUnitsConfig.UnitsId[i].Add(unitsId[i][j]);
				}
				else
				{
					rankBattleFormationUnitsConfig.UnitsId[i].Add(null);
				}
			}
			if (formationsId != null && i < formationsId.Count)
			{
				rankBattleFormationUnitsConfig.FormationsId.Add(formationsId[i]);
			}
			else
			{
				rankBattleFormationUnitsConfig.FormationsId.Add(null);
			}
		}
		manager.SetConfigValue("RANK_FORMATION_UNITS", rankBattleFormationUnitsConfig);
	}

	public static int GetFormationLevel(this UserArchiveManager manager, string formationId)
	{
		Dictionary<string, int> configValue = manager.GetConfigValue<Dictionary<string, int>>("FORMATION_LEVEL");
		if (configValue.TryGetValue(formationId, out var value))
		{
			return value;
		}
		return 0;
	}

	public static void FormationLevelUp(this UserArchiveManager manager, string formationId)
	{
		Dictionary<string, int> configValue = manager.GetConfigValue<Dictionary<string, int>>("FORMATION_LEVEL");
		if (!configValue.TryGetValue(formationId, out var _))
		{
			configValue[formationId] = 1;
		}
		else
		{
			configValue[formationId]++;
		}
		manager.SetConfigValue("FORMATION_LEVEL", configValue);
	}
}
