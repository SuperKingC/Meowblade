using System.Collections.Generic;

namespace UI.ReturningRewards;

public class RecallWelfareUiParams
{
	public int EndTimestamp { get; set; }

	public int TotalScore { get; set; }

	public Dictionary<int, IRecallWelfarePrize> DrawedPrizes { get; set; } = new Dictionary<int, IRecallWelfarePrize>();

	public bool AllRewardsClaimed { get; set; }

	public int Money { get; set; }

	public int PrizesCount { get; set; }
}
