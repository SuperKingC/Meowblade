using System;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.IslandOperations.Static;

public static class JumpUseOuterTechTip
{
	private const string _CHECK_KEY = "CheckJumpUseOuterTech";

	public static bool NeedCheckJumpUseOuterTech()
	{
		int serverNowTimestamp = DateTimeHelper.ServerNowTimestamp;
		int num = GameLocalDataManager.GetInt("CheckJumpUseOuterTech");
		return num < serverNowTimestamp;
	}

	public static void RecordCheckJumpUseOuterTech()
	{
		int value = CalculateNextRefreshTimestamp();
		GameLocalDataManager.SetInt("CheckJumpUseOuterTech", value);
	}

	private static int CalculateNextRefreshTimestamp()
	{
		int serverNowTimestamp = DateTimeHelper.ServerNowTimestamp;
		DateTime localDateTime = DateTimeHelper.ParseTimeStamp(serverNowTimestamp).LocalDateTime;
		if (localDateTime.Hour >= 6 && localDateTime.Hour <= 23)
		{
			DateTime time = new DateTime(localDateTime.Year, localDateTime.Month, localDateTime.Day, 6, 0, 0).AddDays(1.0);
			return DateTimeHelper.GetTimeStamp(time);
		}
		DateTime time2 = new DateTime(localDateTime.Year, localDateTime.Month, localDateTime.Day, 6, 0, 0);
		return DateTimeHelper.GetTimeStamp(time2);
	}
}
