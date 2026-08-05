using System;
using System.Collections.Generic;

namespace Shift.Legion.Common.Models;

public class PurchaseConfig
{
	public Dictionary<string, int> PurchaseStat;

	public Dictionary<string, int> DailyPurchaseStat;

	public DateTimeOffset DailyEndAt;

	public Dictionary<string, int> WeeklyPurchaseStat;

	public DateTimeOffset WeeklyEndAt;

	public Dictionary<string, int> MonthlyPurchaseStat;

	public DateTimeOffset MonthlyEndAt;

	public Dictionary<string, int> PvPPurchaseStat;

	public Dictionary<string, int> RecallPurchaseStat;

	public DateTimeOffset RecallEndAt = DateTimeHelper.BaseTime;

	public Dictionary<string, int> WeeklyActivityPurchaseStat;

	public Dictionary<string, int> WarOfRealmPurchaseStat;

	public PurchaseConfig()
	{
		PurchaseStat = new Dictionary<string, int>();
		DailyPurchaseStat = new Dictionary<string, int>();
		WeeklyPurchaseStat = new Dictionary<string, int>();
		MonthlyPurchaseStat = new Dictionary<string, int>();
		PvPPurchaseStat = new Dictionary<string, int>();
		RecallPurchaseStat = new Dictionary<string, int>();
		WeeklyActivityPurchaseStat = new Dictionary<string, int>();
		WarOfRealmPurchaseStat = new Dictionary<string, int>();
	}

	public void DestroySelf()
	{
		PurchaseStat = null;
		DailyPurchaseStat = null;
		WeeklyPurchaseStat = null;
		MonthlyPurchaseStat = null;
		PvPPurchaseStat = null;
		RecallPurchaseStat = null;
		WeeklyActivityPurchaseStat = null;
		WarOfRealmPurchaseStat = null;
	}

	public void ClearPvPPurchaseStat()
	{
		PvPPurchaseStat.Clear();
	}

	public void ClearRecallPurchaseStat()
	{
		RecallPurchaseStat.Clear();
	}

	public void ClearSpinWeekPurchaseStat()
	{
		WeeklyActivityPurchaseStat.Clear();
	}

	public void ClearWarOfRealmPurchastStat()
	{
		WarOfRealmPurchaseStat.Clear();
	}

	public void CheckDate()
	{
		DateTimeOffset now = DateTimeHelper.Now;
		if (now.CompareTo(DailyEndAt) > 0)
		{
			DailyPurchaseStat.Clear();
			DailyEndAt = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours).AddDays(1.0);
		}
		if (now.CompareTo(WeeklyEndAt) > 0)
		{
			WeeklyPurchaseStat.Clear();
			WeeklyEndAt = DateTimeHelper.GetWeeklyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours).AddDays(7.0);
		}
		if (now.CompareTo(MonthlyEndAt) > 0)
		{
			MonthlyPurchaseStat.Clear();
			MonthlyEndAt = DateTimeHelper.GetMonthlyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours).AddMonths(1);
		}
		if (RecallPurchaseStat == null)
		{
			RecallPurchaseStat = new Dictionary<string, int>();
		}
		if (now.CompareTo(RecallEndAt) > 0)
		{
			RecallPurchaseStat.Clear();
			RecallEndAt = DateTimeHelper.BaseTime;
		}
	}
}
