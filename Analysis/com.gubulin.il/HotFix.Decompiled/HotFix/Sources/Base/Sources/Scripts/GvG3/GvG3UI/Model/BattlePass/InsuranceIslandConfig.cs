using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BattlePass;

public class InsuranceIslandConfig
{
	public List<InsuranceCondition> Conditions { get; set; } = new List<InsuranceCondition>();

	public int CloneCount { get; set; }
}
