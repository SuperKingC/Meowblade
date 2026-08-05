using System.Collections.Generic;
using System.Linq;
using ILRuntime_LitJson;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class OemMissionCost
{
	[JsonIgnore]
	private int? _baseCostValue;

	[JsonIgnore]
	private int? _extraCostValue;

	public Dictionary<string, int> Base { get; set; }

	public Dictionary<string, int> Extra { get; set; }

	[JsonIgnore]
	public int BaseCostValue
	{
		get
		{
			int? baseCostValue = _baseCostValue;
			if (!baseCostValue.HasValue)
			{
				_baseCostValue = ((Base != null) ? Base.Values.ToList()[0] : 0);
			}
			return _baseCostValue.Value;
		}
	}

	[JsonIgnore]
	public int ExtraCostValue
	{
		get
		{
			int? extraCostValue = _extraCostValue;
			if (!extraCostValue.HasValue)
			{
				_extraCostValue = ((Extra != null) ? Extra.Values.ToList()[0] : 0);
			}
			return _extraCostValue.Value;
		}
	}
}
