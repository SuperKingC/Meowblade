using System.Collections.Generic;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.Common.Models;

public class BattleResult
{
	public string BattleId { get; set; }

	public int SubLevelIndex { get; set; }

	public int Winner { get; set; }

	public int ReplaySegments { get; set; }

	public int ReplayFrames { get; set; }

	public bool IsRetreat { get; set; }

	public List<List<float>> RedTeamHp { get; set; }

	public float RedTeamHpTotal { get; set; }

	public List<List<float>> BlueTeamHp { get; set; }

	public float BlueTeamHpTotal { get; set; }

	public List<UnitBornRecord[]> RedTeamBornRecords { get; set; }

	public List<UnitBornRecord[]> BlueTeamBornRecords { get; set; }

	public List<List<UnitBornRecord[]>> LevelsRedTeamBornRecords { get; set; }

	public List<List<UnitBornRecord[]>> LevelsBlueTeamBornRecords { get; set; }

	public Dictionary<string, float> RedTeamDamageStat { get; set; }

	public Dictionary<string, float> BlueTeamDamageStat { get; set; }

	public Dictionary<string, int> RedTeamDeadStat { get; set; }

	public Dictionary<string, int> BlueTeamDeadStat { get; set; }
}
