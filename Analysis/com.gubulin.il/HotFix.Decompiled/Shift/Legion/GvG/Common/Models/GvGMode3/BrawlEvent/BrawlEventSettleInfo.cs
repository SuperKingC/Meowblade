using System.Collections.Generic;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;

public class BrawlEventSettleInfo
{
	public int IslandId { get; set; }

	public int IslandSubType { get; set; }

	public int ShipRace { get; set; }

	public int UserRank { get; set; }

	public long UserScore { get; set; }

	public bool HasExtraScorePar { get; set; } = false;

	public int CampRank { get; set; }

	public long CampScore { get; set; }

	public Dictionary<string, BrawlEventSettleInfoBonus> Reward { get; set; }

	public int MUId { get; set; }

	public string MConfigId { get; set; }
}
