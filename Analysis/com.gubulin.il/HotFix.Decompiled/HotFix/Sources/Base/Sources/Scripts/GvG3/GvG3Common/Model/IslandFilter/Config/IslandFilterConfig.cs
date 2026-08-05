using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Config;

public class IslandFilterConfig
{
	public string FilterLanguageKey { get; set; }

	public List<string> IconUrls { get; set; }

	public string CheckNotAvailableTip { get; set; }

	public List<int> Islands { get; set; }

	public List<string> Conditions { get; set; }
}
