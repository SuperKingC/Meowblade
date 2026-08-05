using System.Collections.Generic;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_LevelProgress
{
	private const string Key = "LEVEL_PROGRESS";

	private const string LevelBonusClaimedKey = "LEVEL_BONUS_CLAIMED";

	public static Dictionary<string, List<string>> GetLevelProgress(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<Dictionary<string, List<string>>>("LEVEL_PROGRESS");
	}

	public static List<string> GetChapterLevelProgress(this UserArchiveManager manager, string chapterId, bool insert = false)
	{
		Dictionary<string, List<string>> levelProgress = manager.GetLevelProgress();
		if (!levelProgress.TryGetValue(chapterId, out var value))
		{
			value = new List<string>();
			if (insert)
			{
				levelProgress.Add(chapterId, value);
				manager.SetConfigValue("LEVEL_PROGRESS", levelProgress);
			}
		}
		return value;
	}

	public static void UpdateLevelProgress(this UserArchiveManager manager, string chapterId, string levelId)
	{
		List<string> chapterLevelProgress = manager.GetChapterLevelProgress(chapterId, insert: true);
		if (!chapterLevelProgress.Contains(levelId))
		{
			chapterLevelProgress.Add(levelId);
		}
		manager.SetValueOfDictConfig("LEVEL_PROGRESS", chapterId, chapterLevelProgress);
		manager.Managers.Messenger.Broadcast("GAME_PROGRESS_UPDATED", chapterId, levelId);
	}

	public static void AddClaimedLevel(this UserArchiveManager manager, string levelId)
	{
		Config<HashSet<string>> config = manager.GetConfig<HashSet<string>>("LEVEL_BONUS_CLAIMED");
		HashSet<string> hashSet = config.GetValue();
		if (hashSet == null)
		{
			hashSet = new HashSet<string>();
			config.SetValue(hashSet);
		}
		if (hashSet.Add(levelId))
		{
			config.Save();
		}
	}

	public static bool IsLevelClaimed(this UserArchiveManager manager, string levelId)
	{
		Config<HashSet<string>> config = manager.GetConfig<HashSet<string>>("LEVEL_BONUS_CLAIMED");
		return config.GetValue()?.Contains(levelId) ?? false;
	}

	public static bool IsLevelCompleted(this UserArchiveManager manager, string levelId)
	{
		Dictionary<string, List<string>> levelProgress = manager.GetLevelProgress();
		foreach (List<string> value in levelProgress.Values)
		{
			if (value.Contains(levelId))
			{
				return true;
			}
		}
		return false;
	}
}
