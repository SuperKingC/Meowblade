using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.Model;

public class BuySweepCountConfig
{
	public int[] Range { get; set; }

	public int SweepCountAdd { get; set; }

	public Dictionary<string, int> Cost { get; set; } = new Dictionary<string, int>();

	public Dictionary<string, int> ExtraReward { get; set; } = new Dictionary<string, int>();
}
