using System.Collections.Generic;
using ILRuntime_LitJson;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class RankBonusData
{
	public int[] RankRange;

	public Dictionary<string, int> BonusItems;

	[JsonIgnore]
	public int MinRank => RankRange[0];

	[JsonIgnore]
	public int MaxRank => RankRange[1];

	public int GetRankingStyle()
	{
		if (MinRank != MaxRank)
		{
			return 3;
		}
		return MinRank - 1;
	}
}
