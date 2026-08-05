using System.Collections.Generic;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.Mission;

public class GvGMode3CampProgressConfigModel
{
	public int Progress;

	public int StepCnt;

	public int GroupId;

	public List<string> Tags;

	public int EternalNightStartTimestamp;

	public int CampControlMoonIsland;

	public eCampMainMissionTag MissionTag()
	{
		return Tags.Contains("EternalNight") ? eCampMainMissionTag.EternalNight : (Tags.Contains("WaitEternalNight") ? eCampMainMissionTag.WaitEternalNight : eCampMainMissionTag.Camp);
	}
}
