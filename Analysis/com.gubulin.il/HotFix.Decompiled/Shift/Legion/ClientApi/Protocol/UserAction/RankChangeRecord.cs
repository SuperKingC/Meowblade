using System.Collections.Generic;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

public class RankChangeRecord
{
	public int HostRank;

	public int HostId;

	public int ChallengerRank;

	public int ChallengerId;

	public int Timestamp;

	public string BattleId;

	public int GameId;

	public int Winner;

	public int Index;

	public List<int> KingPoints;
}
