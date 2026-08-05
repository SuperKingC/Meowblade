using System;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_DailyAttributes
{
	public const string DailyAttributesExpireAtKey = "DailyAttributesExpireAt";

	public const string RecycleExportToKey = "RecycleExportTo";

	public const string EnableMultiplayerKey = "RecycleEnableMultiplayer";

	public const string DailyCompleteLevelsKey = "DailyCompleteLevels";

	public const string DailyActivityResetKey = "DailyActivityReset";

	public static void EnsureDailyAttributesExpireAt(this UserArchiveManager manager)
	{
		if (!manager.Contains("DailyAttributesExpireAt"))
		{
			manager.SetConfigValue("DailyAttributesExpireAt", default(DateTimeOffset).ToString());
		}
		if (!DateTimeHelper.TryParse(manager.GetConfigValue<string>("DailyAttributesExpireAt"), out var dateTime) || dateTime <= DateTimeHelper.Now)
		{
			manager.SetConfigValue("DailyAttributesExpireAt", DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours).AddDays(1.0).ToString("yyyy-MM-dd HH:mm:ss%K"));
			manager.SetConfigValue("RecycleExportTo", manager.Managers.Archive.UserId);
			manager.SetConfigValue("RecycleEnableMultiplayer", value: false);
		}
	}
}
