using System.Collections.Generic;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.Common.Models;

public class WarOfRealmProgressRecord
{
	public string ActivityId { get; set; }

	public int WeekEndTs { get; set; }

	public int SeasonBeginTs { get; set; }

	public int SeasonEndTs { get; set; }

	public bool Settlement { get; set; }

	public int Score { get; set; }

	public List<int> Claimed { get; set; }

	public Dictionary<eMissionType, int> MissionProgress { get; set; } = new Dictionary<eMissionType, int>();

	public List<string> CompletedWeeklyMission { get; set; }

	public List<string> CompletedSeasonMission { get; set; }

	public void ResetWeeklyMission()
	{
		WeekEndTs = DateTimeHelper.GetTimeStamp(DateTimeHelper.GetWeeklyRefreshTime(DateTimeHelper.Now.AddDays(7.0), DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours));
		CompletedWeeklyMission.Clear();
		foreach (eMissionType key in MissionProgress.Keys)
		{
			if (key == eMissionType.入围巅峰赛战斗周任务 || key == eMissionType.累计参加天梯战斗次数周任务 || key == eMissionType.累计天梯获胜次数周任务)
			{
				MissionProgress[key] = 0;
			}
		}
	}
}
