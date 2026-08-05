using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BattlePass;

public class GvG3InsuranceConfig
{
	public Dictionary<string, InsuranceIslandConfig> Islands { get; set; } = new Dictionary<string, InsuranceIslandConfig>();
}
