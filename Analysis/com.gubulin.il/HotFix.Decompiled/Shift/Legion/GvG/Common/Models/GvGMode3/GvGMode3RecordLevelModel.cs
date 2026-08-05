using System.Collections.Generic;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

public class GvGMode3RecordLevelModel
{
	public string BattleId { get; set; }

	public string LevelId { get; set; }

	public int Result { get; set; }

	public Dictionary<Team, BattleResultStats> BattleResultStats { get; set; }

	public bool HasBoss { get; set; }

	public List<ItemAbility> Abilities { get; set; }

	public int BossLevel { get; set; }

	public Dictionary<string, SoldierDetail> RedDetails { get; set; }

	public Dictionary<string, SoldierDetail> BlueDetails { get; set; }
}
