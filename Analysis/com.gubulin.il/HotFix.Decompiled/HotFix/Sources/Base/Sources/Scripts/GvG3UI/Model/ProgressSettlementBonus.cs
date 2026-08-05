using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using ILRuntime_LitJson;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class ProgressSettlementBonus
{
	[JsonIgnore]
	private string _desc;

	public string Icon { get; set; }

	public string Desc { get; set; }

	public List<int> Change { get; set; }

	public List<int> Change2 { get; set; }

	public bool Visible(int progress)
	{
		List<int> change = GetChange();
		if (change == null)
		{
			return true;
		}
		if (change.Count < progress)
		{
			return false;
		}
		return change[progress - 1] > 0;
	}

	private List<int> GetChange()
	{
		if (WorldMapConfigHelper.Configs.IsBrawlEvent())
		{
			return Change2;
		}
		return Change;
	}

	public string DescText(int progress)
	{
		List<int> change = GetChange();
		return _desc ?? (_desc = ((change == null) ? Desc.ToLanguage() : string.Format(Desc.ToLanguage(), new object[1] { change[progress - 1] })));
	}
}
