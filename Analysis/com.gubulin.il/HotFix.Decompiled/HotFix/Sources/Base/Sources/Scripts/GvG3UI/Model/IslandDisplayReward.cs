using System.Collections.Generic;
using ILRuntime_LitJson;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class IslandDisplayReward
{
	[JsonIgnore]
	private int? _displayRankType;

	[JsonIgnore]
	private List<KeyValuePair<string, string>> _items;

	public int[] RankRange { get; set; }

	public string BoxItem { get; set; }

	public Dictionary<string, string> BonusItems { get; set; }

	[JsonIgnore]
	public int MinRank => RankRange[0];

	[JsonIgnore]
	public int MaxRank => RankRange[1];

	[JsonIgnore]
	public int DisplayRankType
	{
		get
		{
			int? displayRankType = _displayRankType;
			if (displayRankType.HasValue)
			{
				return _displayRankType.Value;
			}
			if (MaxRank != MinRank)
			{
				_displayRankType = 3;
			}
			else if (MaxRank > 3)
			{
				_displayRankType = 3;
			}
			else
			{
				_displayRankType = MaxRank - 1;
			}
			return _displayRankType.Value;
		}
	}

	[JsonIgnore]
	public List<KeyValuePair<string, string>> Items => _items ?? (_items = new List<KeyValuePair<string, string>>(BonusItems));
}
