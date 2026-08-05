using System.Collections.Generic;
using Shift.Legion.GvG.Common.Enums;
using UI.GvGBrawlFight;

namespace Shift.Legion.GvG.Common.Models.BattleLog;

public class IslandLog
{
	public int WinnerCampId;

	public int OriginalCampId;

	public int ProcessStartByWhichCamp;

	public long IslandStartTimestamp_ms;

	public long IslandEndTimestamp_ms;

	public string NameId;

	public string ProcessId;

	public List<BattleLog_Big> BigLogs;

	public string RandomEventName = string.Empty;

	public bool IsBossBattle;

	public string BrawlEventReplayName;

	public int BrawlEventDuration;

	public int BrawlEventType;

	public int BrawlEventDay;

	public int Id { get; set; }

	public bool Checked { get; set; }

	public bool IsRunning { get; set; } = false;

	public bool IsBrawlFight()
	{
		return BrawlEventDuration > 0;
	}

	public bool CanBeDisplay()
	{
		if (!IsBrawlFight())
		{
			return true;
		}
		int num = UI_main_BrawlFightEnroll.WhatDayIsToday();
		if (BrawlEventDay >= num)
		{
			return false;
		}
		return true;
	}

	public eGvGMode3CampMissionSubType GetBrawlEventType()
	{
		return (eGvGMode3CampMissionSubType)BrawlEventType;
	}
}
