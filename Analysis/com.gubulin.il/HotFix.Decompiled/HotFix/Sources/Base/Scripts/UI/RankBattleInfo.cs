using System.Collections.Generic;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;

namespace HotFix.Sources.Base.Scripts.UI;

public class RankBattleInfo
{
	public readonly string BattleId;

	public int RealLegionSize;

	public int NeedLegionSize;

	public readonly string LevelId;

	public int Result;

	public Dictionary<Team, BattleResultStats> BattleResultStats = new Dictionary<Team, BattleResultStats>();

	public RankBattleInfo(string battleId)
	{
		BattleId = battleId;
		LevelId = "RankBattleFieldLevel";
	}
}
