using System.Collections.Generic;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;

public class BrawlEventRankRewardsConfig
{
	public int[] Rank;

	public Dictionary<string, int> Normal;

	public Dictionary<string, int> Extra;
}
