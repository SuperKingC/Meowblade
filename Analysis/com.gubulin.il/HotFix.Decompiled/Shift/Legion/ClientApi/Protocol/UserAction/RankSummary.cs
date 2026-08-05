using System.Collections.Generic;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

public class RankSummary
{
	public int UserId;

	public int Rank;

	public List<SoldierInfo> SoldierInfoList = new List<SoldierInfo>();

	public int FormationsCnt;

	public int CombatPower;

	public long LastBattleFinishAt;

	public long LastRequestAt;

	public bool IsRecentBattle;

	public long DefenseBuffFinishAt;

	public string Md5;

	public void CheckValid()
	{
		if (SoldierInfoList == null)
		{
			SoldierInfoList = new List<SoldierInfo>();
		}
	}
}
