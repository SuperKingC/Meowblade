using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_Others
{
	public const string UserHasReviewedKey = "UserHasReviewed";

	private const string LastUpdatedTimeKey = "LAST_UPDATED_TIME";

	private const string CurrentLevelIdKey = "CURRENT_LEVEL_ID";

	private const string NewGachaActivityIdKey = "NewGachaActivityId";

	private const string UserLevelUpReviewPoint = "USER_LEVEL_UP_REVIEW_POINT";

	public static string GetCurrentLevelId(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<string>("CURRENT_LEVEL_ID");
	}

	public static void SetCurrentLevelId(this UserArchiveManager manager, string levelId)
	{
		manager.SetConfigValue("CURRENT_LEVEL_ID", levelId);
	}

	public static string GetCurrentChapterId(this UserArchiveManager manager)
	{
		string currentLevelId = manager.GetCurrentLevelId();
		return string.IsNullOrEmpty(currentLevelId) ? null : manager.Managers.ChapterManager.GetLevelInstance(currentLevelId)?.ChapterId;
	}

	public static long GetLastUpdatedTime(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<long>("LAST_UPDATED_TIME");
	}

	public static void SetLastUpdatedTime(this UserArchiveManager manager, long time)
	{
		manager.SetConfigValue("LAST_UPDATED_TIME", time);
	}

	public static bool CheckUserLevelUpReviewPointEnabled(this UserArchiveManager manager)
	{
		GDEConfigurationData gDEConfigurationData = GDMgr.Get<GDEConfigurationData>("USER_LEVEL_UP_REVIEW_POINT");
		if (gDEConfigurationData != null)
		{
			List<int> list = JsonHelper.ToObject<List<int>>(gDEConfigurationData.Config);
			return list.Contains(manager.GetUserLevel());
		}
		return false;
	}

	public static void SetNewbieGachaPool(this UserArchiveManager manager, string id)
	{
		manager.SetConfigValue("NewGachaActivityId", id);
	}

	public static string GetNewbieGachaActivityId(this UserArchiveManager manager)
	{
		return manager.GetConfig<string>("NewGachaActivityId").GetValue();
	}
}
