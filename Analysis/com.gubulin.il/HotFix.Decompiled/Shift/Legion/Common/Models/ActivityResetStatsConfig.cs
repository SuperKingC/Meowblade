using System;
using System.Collections.Generic;

namespace Shift.Legion.Common.Models;

public class ActivityResetStatsConfig
{
	public Dictionary<string, int> ActivityResetCntStats;

	public Dictionary<string, Dictionary<string, int>> ActivityResetCostStats;

	public Dictionary<string, int> DailyActivityResetCntStats;

	public Dictionary<string, Dictionary<string, int>> DailyActivityResetCostStats;

	public DateTimeOffset DailyEndAt;

	public ActivityResetStatsConfig()
	{
		ActivityResetCntStats = new Dictionary<string, int>();
		ActivityResetCostStats = new Dictionary<string, Dictionary<string, int>>();
		DailyActivityResetCntStats = new Dictionary<string, int>();
		DailyActivityResetCostStats = new Dictionary<string, Dictionary<string, int>>();
	}

	public void CheckDate()
	{
		DateTimeOffset dailyRefreshTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
		if (dailyRefreshTime.CompareTo(DailyEndAt) > 0)
		{
			DailyActivityResetCntStats.Clear();
			DailyActivityResetCostStats.Clear();
			DailyEndAt = dailyRefreshTime;
		}
	}
}
