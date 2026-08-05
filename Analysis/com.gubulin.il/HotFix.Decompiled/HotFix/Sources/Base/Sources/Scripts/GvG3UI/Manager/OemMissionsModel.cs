using System;
using System.Collections.Generic;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;

public class OemMissionsModel
{
	private const int RefreshOemMissionsTimeInterval = 300;

	private int CurrentTimestamp => (int)GameController.Instance.GetServerTime();

	public int IzVersionNumber { get; set; }

	public int NextRefreshTimestamp { get; set; }

	public int NextDayRefreshTimestamp { get; set; }

	public List<OemMissionToProtocol> Missions { get; set; } = new List<OemMissionToProtocol>(50);

	public void SaveNextRefreshTimestamp()
	{
		NextRefreshTimestamp = CurrentTimestamp + 300;
		IzVersionNumber = Singleton<GvGMode3RoomManager>.Instance.IZVersionNumber;
		NextDayRefreshTimestamp = CalculateNextRefreshTimestamp(CurrentTimestamp);
	}

	public bool NeedRefresh()
	{
		return IzVersionNumber != Singleton<GvGMode3RoomManager>.Instance.IZVersionNumber || CurrentTimestamp > NextDayRefreshTimestamp;
	}

	public bool CanRefresh(out int countdown)
	{
		countdown = 0;
		if (CurrentTimestamp > NextRefreshTimestamp)
		{
			return true;
		}
		countdown = NextRefreshTimestamp - CurrentTimestamp;
		return false;
	}

	private int CalculateNextRefreshTimestamp(int saveTimestamp)
	{
		DateTime localDateTime = DateTimeHelper.ParseTimeStamp(saveTimestamp).LocalDateTime;
		if (localDateTime.Hour >= 6 && localDateTime.Hour <= 23)
		{
			DateTime time = new DateTime(localDateTime.Year, localDateTime.Month, localDateTime.Day, 6, 0, 0).AddDays(1.0);
			return DateTimeHelper.GetTimeStamp(time);
		}
		DateTime time2 = new DateTime(localDateTime.Year, localDateTime.Month, localDateTime.Day, 6, 0, 0);
		return DateTimeHelper.GetTimeStamp(time2);
	}
}
