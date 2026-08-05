using System.Collections.Generic;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.Common.Models;

public class PvPRankProgress
{
	public int AttackBuffCnt = 0;

	public int DefenseBuffExpiredAt = 1000000000;

	public Dictionary<string, int> CdFinishAt = new Dictionary<string, int>();

	public int TopRank = -1;

	public Dictionary<string, string> RivalFormationUnitsMarks = new Dictionary<string, string>();

	public int Id = -1;

	public int TurnId = -1;

	public string SeasonName;

	public string RankServerName;

	public int GameId;

	public int LadderScore;

	public int Score;

	public int ClaimedScore;

	public RankBattleTopTournamentConfig TopTournamentFormation = null;

	public void Reset()
	{
		TopRank = -1;
		LadderScore = 0;
		Score = 0;
		ClaimedScore = 0;
	}
}
