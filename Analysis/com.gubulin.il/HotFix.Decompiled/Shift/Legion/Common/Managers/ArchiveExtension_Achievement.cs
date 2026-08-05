using System.Collections.Generic;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_Achievement
{
	private const string AchievementProgressKey = "ACHIEVEMENT_PROGRESS";

	public const string MissionOf7UnLockBonus = "MissionOf7UnLockBonus";

	public static List<string> GetAchievementProgress(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<List<string>>("ACHIEVEMENT_PROGRESS");
	}

	public static void UpdateAchievementProgress(this UserArchiveManager manager, string achievementId)
	{
		List<string> achievementProgress = manager.GetAchievementProgress();
		if (!achievementProgress.Contains(achievementId))
		{
			achievementProgress.Add(achievementId);
		}
		manager.SetConfigValue("ACHIEVEMENT_PROGRESS", achievementProgress);
		manager.Managers.Messenger.Broadcast("ACHIEVEMENT_BONUS_CLAIMED", achievementId);
	}

	public static bool GetMissionOf7UnLockBonus(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<bool>("MissionOf7UnLockBonus");
	}

	public static void SetMissionOf7UnLockBonus(this UserArchiveManager manager, bool value)
	{
		manager.SetConfigValue("MissionOf7UnLockBonus", value);
	}
}
