using System.Collections.Generic;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent;

public class BE_RunningDataModel
{
	public int Day { get; set; }

	public int StepIdx { get; set; }

	public int IslandId { get; set; }

	public bool Finish { get; set; }

	public int SendRewardTimestamp { get; set; } = -1;

	public string ReplayName { get; set; }

	public int ReplayDuration { get; set; }

	public eGvGMode3CampMissionSubType Type { get; set; }

	public List<GvGMode3PlayerRankInfo> UserRankInfo { get; set; }

	public List<GvGMode3CampRankInfo> CampRankInfo { get; set; }
}
