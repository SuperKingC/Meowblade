using System.Collections.Generic;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;

namespace Shift.Legion.GvG.Common;

public class GvGBattleInfo
{
	public string BattleId;

	public string LevelId;

	public int Result;

	public Dictionary<Team, BattleResultStats> BattleResultStats = new Dictionary<Team, BattleResultStats>();

	public List<ItemAbility> WorldBossDebuffItemAbilities = new List<ItemAbility>();

	public int WorldBossLevel;
}
