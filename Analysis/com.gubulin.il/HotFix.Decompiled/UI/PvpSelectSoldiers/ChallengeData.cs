using System.Collections.Generic;
using Shift.Legion.ClientApi.Protocol.UserAction;

namespace UI.PvpSelectSoldiers;

public class ChallengeData
{
	public int MyRank;

	public List<RankSummary> AimRankSummaries;

	public ChallengeData(int myRank, List<RankSummary> aimRankSummaries)
	{
		MyRank = myRank;
		AimRankSummaries = aimRankSummaries;
	}
}
