using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Config;

public class GvGIslandFilterAreaConfig
{
	public string AreaKey { get; set; }

	public List<string> Filters { get; set; }

	public string EffectiveCondition { get; set; }
}
