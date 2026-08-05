using System.Collections.Generic;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_Level
{
	private const string LevelRandomSeedKey = "LEVEL_BONUS_RANDOM_SEED";

	private const string LevelLotteryBonusKey = "LEVEL_LOTTERY_BONUS";

	public static int GetLevelRandomSeed(this UserArchiveManager manager, Level level)
	{
		string levelId = level.LevelId;
		Dictionary<string, int> configValue = manager.GetConfigValue<Dictionary<string, int>>("LEVEL_BONUS_RANDOM_SEED");
		if (!configValue.TryGetValue(levelId, out var value))
		{
			value = manager.Managers.RandomManager.Int(0, int.MaxValue);
			configValue[levelId] = value;
			manager.SetConfigValue("LEVEL_BONUS_RANDOM_SEED", configValue);
		}
		return configValue[levelId];
	}

	public static void RemoveLevelRandomSeed(this UserArchiveManager manager, Level level)
	{
		string levelId = level.LevelId;
		manager.RemoveFromDictConfig<int>("LEVEL_BONUS_RANDOM_SEED", levelId);
	}

	public static void SetLevelLotteryBonus(this UserArchiveManager manager, Level level, List<BonusConfig> bonusConfigs)
	{
		string levelId = level.LevelId;
		Dictionary<string, List<BonusConfig>> dictionary = manager.GetConfigValue<Dictionary<string, List<BonusConfig>>>("LEVEL_LOTTERY_BONUS");
		if (dictionary == null)
		{
			dictionary = new Dictionary<string, List<BonusConfig>>();
		}
		dictionary[levelId] = bonusConfigs;
		manager.SetConfigValue("LEVEL_LOTTERY_BONUS", dictionary);
	}

	public static List<BonusConfig> GetLevelLotteryBonus(this UserArchiveManager manager, Level level)
	{
		string levelId = level.LevelId;
		Dictionary<string, List<BonusConfig>> configValue = manager.GetConfigValue<Dictionary<string, List<BonusConfig>>>("LEVEL_LOTTERY_BONUS");
		if (configValue == null)
		{
			ILRuntimeDebug.LogError("LevelLotteryBonusKey Data is null");
			return null;
		}
		configValue.TryGetValue(levelId, out var value);
		return value;
	}

	public static void RemoveLevelLotteryBonus(this UserArchiveManager manager, Level level)
	{
		string levelId = level.LevelId;
		manager.RemoveFromDictConfig<List<BonusConfig>>("LEVEL_LOTTERY_BONUS", levelId);
	}

	public static void SaveLevelEnemiesHp(this UserArchiveManager manager, Level level, Team winner, List<List<float>> enemiesHp)
	{
		if (string.IsNullOrEmpty(level.ChapterId))
		{
			return;
		}
		Chapter chapter = manager.Managers.ChapterManager.GetChapter(level.ChapterId);
		if (chapter != null && chapter.PreserveEnemy)
		{
			int num = ((winner == Team.Red) ? 1 : (-1));
			if (num == -1)
			{
				manager.SetLevelEnemiesHp(level, enemiesHp);
			}
			else
			{
				manager.RemoveLevelEnemiesHp(level);
			}
		}
	}
}
