using System.Collections.Generic;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

public class SettlementCampRankData
{
	public int Rank { get; set; }

	public long Data { get; set; }

	public Dictionary<string, int> Reward { get; set; }

	public int CampId { get; set; }
}
