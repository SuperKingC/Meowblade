using System.Collections.Generic;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_CurrentLevelEnemiesHp
{
	private const string LevelEnemiesHpKey = "LEVEL_ENEMIES_HP";

	public static List<List<float>> GetLevelEnemiesHp(this UserArchiveManager manager, Level level)
	{
		string key = "LEVEL_ENEMIES_HP_" + level.LevelId;
		if (!manager.Contains(key))
		{
			return null;
		}
		return manager.GetConfigValue<List<List<float>>>(key);
	}

	public static void SetLevelEnemiesHp(this UserArchiveManager manager, Level level, List<List<float>> value)
	{
		string key = "LEVEL_ENEMIES_HP_" + level.LevelId;
		manager.SetConfigValue(key, value);
	}

	public static void RemoveLevelEnemiesHp(this UserArchiveManager manager, Level level)
	{
		string key = "LEVEL_ENEMIES_HP_" + level.LevelId;
		manager.RemoveConfig(key);
	}
}
