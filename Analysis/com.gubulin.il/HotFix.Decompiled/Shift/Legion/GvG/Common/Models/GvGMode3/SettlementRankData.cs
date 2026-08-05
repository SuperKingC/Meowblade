using System.Collections.Generic;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

public class SettlementRankData
{
	public int Rank { get; set; }

	public long Data { get; set; }

	public Dictionary<string, int> Reward { get; set; } = new Dictionary<string, int>();

	public bool HasClaimed { get; set; }
}
