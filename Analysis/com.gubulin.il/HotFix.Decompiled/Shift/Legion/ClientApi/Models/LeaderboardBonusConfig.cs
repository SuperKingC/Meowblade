using System.Collections.Generic;

namespace Shift.Legion.ClientApi.Models;

public class LeaderboardBonusConfig
{
	public List<int> RankRange { get; set; }

	public Dictionary<string, int> BonusItems { get; set; }
}
