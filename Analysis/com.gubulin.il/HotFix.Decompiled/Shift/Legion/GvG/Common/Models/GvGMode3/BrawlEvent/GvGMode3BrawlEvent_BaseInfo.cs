using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;

public class GvGMode3BrawlEvent_BaseInfo
{
	public List<string> AllowRegisterTime;

	public List<string> FightingTime;

	public int LimitForEachUser;

	public List<GvGMode3BrawlEvent_BaseInfo_IslandRandom> AffectIslands;

	public string SpaceBg;

	public List<BrawlEventRankRewardsConfig> CampEnergyRewards;

	public List<BrawlEventRankRewardsConfig> Rewards;

	private List<TimeSpan> _AllowRegisterTimeSpans = null;

	private List<TimeSpan> _FightingTimeSpans = null;

	private List<int> _effectIslandIds;

	public int Day { get; set; }

	public int EndDay { get; set; }

	public int StepIdx { get; set; }

	public List<TimeSpan> AllowRegisterTimeSpans
	{
		get
		{
			if (_AllowRegisterTimeSpans == null)
			{
				_AllowRegisterTimeSpans = DateTimeHelper.TimeSpansPaser(AllowRegisterTime);
			}
			return _AllowRegisterTimeSpans;
		}
	}

	public List<TimeSpan> FightingTimeSpans
	{
		get
		{
			if (_FightingTimeSpans == null)
			{
				_FightingTimeSpans = DateTimeHelper.TimeSpansPaser(FightingTime);
			}
			return _FightingTimeSpans;
		}
	}

	public List<int> EffectIslandIds
	{
		get
		{
			if (_effectIslandIds == null)
			{
				_effectIslandIds = new List<int>();
				foreach (GvGMode3BrawlEvent_BaseInfo_IslandRandom affectIsland in AffectIslands)
				{
					_effectIslandIds.AddRange(affectIsland.IslandIds);
				}
			}
			return _effectIslandIds;
		}
	}

	public DateTimeOffset GetFightingTimeDisplay(int serverFightTime)
	{
		TimeSpan timeSpan = FightingTimeSpans[0];
		timeSpan = new TimeSpan(timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
		DateTime localDateTime = DateTimeHelper.Parse(serverFightTime).LocalDateTime;
		TimeSpan timeSpan2 = new TimeSpan(localDateTime.Hour, localDateTime.Minute, localDateTime.Second);
		DateTimeOffset dateTimeOffset = new DateTimeOffset(localDateTime.Year, localDateTime.Month, localDateTime.Day, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, DateTimeHelper.TimezoneOffset);
		if (timeSpan2 < timeSpan)
		{
			dateTimeOffset = dateTimeOffset.AddDays(-1.0);
		}
		return dateTimeOffset.AddSeconds((FightingTimeSpans[1] - FightingTimeSpans[0]).TotalSeconds);
	}

	public static string GetBrawlFightSettleTimeStr(int day)
	{
		int iZBeginTimestamp = Singleton<WorldStateManager>.Instance.Data.IZBeginTimestamp;
		DateTime dateTime = DateTimeHelper.ParseTimeStamp(iZBeginTimestamp).LocalDateTime.AddDays(day);
		GvGMode3BrawlEvent_BaseInfo gvGMode3BrawlEvent_BaseInfo = WorldMapConfigHelper.Configs.TryGetBrawlEventByDay(day + 1);
		int hours = gvGMode3BrawlEvent_BaseInfo.AllowRegisterTimeSpans[0].Hours;
		return new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, hours, 0, 0, TimeSpan.Zero).ToString("MM/dd HH:mm");
	}

	public static long GetAllowRegisterTimeStart(int day)
	{
		GvGMode3BrawlEvent_BaseInfo gvGMode3BrawlEvent_BaseInfo = WorldMapConfigHelper.Configs.TryGetBrawlEventByDay(day);
		return GetTimeStamp(day, gvGMode3BrawlEvent_BaseInfo.AllowRegisterTimeSpans[0]);
	}

	public static long GetAllowRegisterTimeEnd(int day)
	{
		GvGMode3BrawlEvent_BaseInfo gvGMode3BrawlEvent_BaseInfo = WorldMapConfigHelper.Configs.TryGetBrawlEventByDay(day);
		return GetTimeStamp(day, gvGMode3BrawlEvent_BaseInfo.AllowRegisterTimeSpans[1]);
	}

	public static long GetFightingEndTime(int day)
	{
		GvGMode3BrawlEvent_BaseInfo gvGMode3BrawlEvent_BaseInfo = WorldMapConfigHelper.Configs.TryGetBrawlEventByDay(day);
		return GetTimeStamp(day, gvGMode3BrawlEvent_BaseInfo.FightingTimeSpans[1]);
	}

	private static long GetTimeStamp(int day, TimeSpan offset)
	{
		int iZBeginTimestamp = Singleton<WorldStateManager>.Instance.Data.IZBeginTimestamp;
		DateTime dateTime = DateTimeHelper.ParseTimeStamp(iZBeginTimestamp).LocalDateTime.AddDays(day - 1);
		return new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, DateTimeHelper.TimezoneOffset).AddSeconds(offset.TotalSeconds).ToUnixTimeSeconds();
	}
}
