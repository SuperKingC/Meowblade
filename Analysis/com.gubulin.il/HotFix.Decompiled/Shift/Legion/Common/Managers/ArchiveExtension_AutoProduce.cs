using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_AutoProduce
{
	private const string AutoProduceBonusKey = "AUTO_PRODUCE_BONUS";

	private const string AutoProduceBonusRecordKey = "AUTO_PRODUCE_BONUS_RECORD";

	public static Action InsertAutoProduceBonus(this UserArchiveManager manager, string itemId, float qty, string context = null, bool broadcastInform = true)
	{
		if (context != null)
		{
			Dictionary<string, Dictionary<string, float>> configValue = manager.GetConfigValue<Dictionary<string, Dictionary<string, float>>>("AUTO_PRODUCE_BONUS_RECORD");
			if (configValue.ContainsKey(context))
			{
				return null;
			}
			configValue.Add(context, new Dictionary<string, float> { { itemId, qty } });
			manager.SetConfigValue("AUTO_PRODUCE_BONUS_RECORD", configValue);
		}
		Dictionary<string, float> configValue2 = manager.GetConfigValue<Dictionary<string, float>>("AUTO_PRODUCE_BONUS");
		if (configValue2.ContainsKey(itemId))
		{
			configValue2[itemId] += qty;
		}
		else
		{
			configValue2.Add(itemId, qty);
		}
		manager.SetConfigValue("AUTO_PRODUCE_BONUS", configValue2);
		string informTip = string.Format("{0}{1} {2}{3}/{4}", SchemaIndexHelper.GetNameById(manager.Managers, itemId), LanguagesManager.GetDesc("CsharpCodeZhTcText810"), (qty >= 0f) ? "+" : "-", qty, LanguagesManager.GetDesc("CsharpCodeZhTcText248"));
		Action action = delegate
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { informTip }, 121, arg3: false);
		};
		if (broadcastInform)
		{
			action();
		}
		return action;
	}

	public static Dictionary<string, Dictionary<string, float>> GetAutoProduceRecords(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<Dictionary<string, Dictionary<string, float>>>("AUTO_PRODUCE_BONUS_RECORD");
	}

	private static float GetCurrentTotalAutoProductions()
	{
		string text = GameManagers.Instance.UserArchiveManager.GetCurrentLevelId();
		if (string.IsNullOrEmpty(text))
		{
			foreach (KeyValuePair<string, Region> region in WorldMapManager.Regions)
			{
				if (region.Value.Status(GameManagers.Instance) == RegionStatus.Unlocked)
				{
					text = region.Value.CurrentLevelId(GameManagers.Instance);
					break;
				}
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			foreach (KeyValuePair<string, Region> region2 in WorldMapManager.Regions)
			{
				if (region2.Value.Status(GameManagers.Instance) == RegionStatus.Battling)
				{
					text = region2.Value.CurrentLevelId(GameManagers.Instance);
					break;
				}
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			return 0f;
		}
		Level levelInstance = GameManagers.Instance.ChapterManager.GetLevelInstance(text);
		if (levelInstance == null)
		{
			return 0f;
		}
		List<string> level_IDs = levelInstance.Chapter.Level_IDs;
		int num = level_IDs.IndexOf(text);
		if (num == -1)
		{
			return 0f;
		}
		if (num > 0)
		{
			return levelInstance.Chapter.GetLevels(num - 1).AutoProduceBonus["Money"];
		}
		if (levelInstance.Chapter.PrevChapter == null || levelInstance.Chapter.PrevChapter.ChapterId == "C1000" || levelInstance.Chapter.PrevChapter.ChapterId == "C10000" || levelInstance.Chapter.PrevChapter.ChapterId == "C10001" || levelInstance.Chapter.PrevChapter.ChapterId == "C1000" || levelInstance.Chapter.PrevChapter.ChapterId == "C10002")
		{
			return 0f;
		}
		int key = levelInstance.Chapter.PrevChapter.Level_IDs.Count - 1;
		if (levelInstance.Chapter.PrevChapter.Levels.ContainsKey(key))
		{
			return levelInstance.Chapter.PrevChapter.Levels[key].AutoProduceBonus["Money"];
		}
		return 0f;
	}

	private static Level GetLatestMainStoryLevel()
	{
		Dictionary<string, List<string>> levelProgress = GameManagers.Instance.UserArchiveManager.GetLevelProgress();
		Chapter chapter = null;
		foreach (string key in levelProgress.Keys)
		{
			if (ChapterManager.MainStoryChapters.TryGetValue(key, out var value) && value.Data.NextChapter == "C1001")
			{
				chapter = value;
			}
		}
		string levelId = null;
		List<string> value2;
		while (chapter != null && levelProgress.TryGetValue(chapter.ChapterId, out value2) && value2.Count >= 1)
		{
			levelId = value2[value2.Count - 1];
			chapter = chapter.NextChapter;
		}
		return GameManagers.Instance.ChapterManager.GetLevelInstance(levelId);
	}

	public static Dictionary<string, float> GetFormattedAutoProductions(this UserArchiveManager manager, bool containBonus = true)
	{
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		float num = (containBonus ? (1f + manager.Managers.ModifierManager.GetPercentFloatPayload("AutoProduceEfficiency")) : 1f);
		Level latestMainStoryLevel = GetLatestMainStoryLevel();
		if (latestMainStoryLevel == null)
		{
			return dictionary;
		}
		foreach (KeyValuePair<string, float> autoProduceBonu in latestMainStoryLevel.AutoProduceBonus)
		{
			dictionary.Add(autoProduceBonu.Key, autoProduceBonu.Value * num);
		}
		return dictionary;
	}

	public static Dictionary<string, float> GetFormattedOccupiedProductions(this UserArchiveManager manager)
	{
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		foreach (StrongholdConfig value2 in manager.GetAllStrongholdsStatus().Values)
		{
			if (!WorldMapManager.Strongholds.TryGetValue(value2.StrongholdId, out var value))
			{
				continue;
			}
			foreach (KeyValuePair<string, float> item in value.Productions(manager.Managers))
			{
				if (dictionary.ContainsKey(item.Key))
				{
					dictionary[item.Key] += item.Value;
				}
				else
				{
					dictionary.Add(item.Key, item.Value);
				}
			}
		}
		return dictionary;
	}

	public static Dictionary<string, float> GetAllBonusProductions(this UserArchiveManager manager)
	{
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		foreach (KeyValuePair<string, float> formattedAutoProduction in manager.GetFormattedAutoProductions())
		{
			if (dictionary.ContainsKey(formattedAutoProduction.Key))
			{
				dictionary[formattedAutoProduction.Key] += formattedAutoProduction.Value;
			}
			else
			{
				dictionary.Add(formattedAutoProduction.Key, formattedAutoProduction.Value);
			}
		}
		foreach (KeyValuePair<string, float> formattedOccupiedProduction in manager.GetFormattedOccupiedProductions())
		{
			if (dictionary.ContainsKey(formattedOccupiedProduction.Key))
			{
				dictionary[formattedOccupiedProduction.Key] += formattedOccupiedProduction.Value;
			}
			else
			{
				dictionary.Add(formattedOccupiedProduction.Key, formattedOccupiedProduction.Value);
			}
		}
		return dictionary;
	}
}
