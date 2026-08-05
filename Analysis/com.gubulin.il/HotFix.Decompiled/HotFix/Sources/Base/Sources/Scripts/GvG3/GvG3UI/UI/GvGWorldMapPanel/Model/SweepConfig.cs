using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.Model;

public class SweepConfig
{
	public int FreeCount { get; set; }

	public int FoodCost { get; set; }

	public int SweepContributionAdd { get; set; }

	public int DailyMaxSweepCountAdd { get; set; }

	public int SweepCountMaximumHolding { get; set; }

	public List<BuySweepCountConfig> BuySweepCountConfig { get; set; } = new List<BuySweepCountConfig>();
}
