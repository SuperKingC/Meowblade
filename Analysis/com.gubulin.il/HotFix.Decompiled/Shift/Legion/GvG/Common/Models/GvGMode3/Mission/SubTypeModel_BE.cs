using System.Collections.Generic;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.Mission;

public class SubTypeModel_BE
{
	public long AmpScoreLimit = -1L;

	public List<BrawlEventRankRewardsConfig> BrawlEventPlayer = new List<BrawlEventRankRewardsConfig>();

	public List<BrawlEventRankRewardsConfig> BrawlEventCamp = new List<BrawlEventRankRewardsConfig>();
}
