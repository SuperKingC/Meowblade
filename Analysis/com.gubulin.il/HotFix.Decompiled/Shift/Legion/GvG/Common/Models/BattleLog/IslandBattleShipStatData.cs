using System.Collections.Generic;

namespace Shift.Legion.GvG.Common.Models.BattleLog;

public class IslandBattleShipStatData
{
	public ShipInfo ShipInfo { get; set; }

	public int DeadCnt { get; set; } = 0;

	public int FinishFightingCount { get; set; } = 0;

	public long Kill { get; set; } = 0L;

	public long Loss { get; set; } = 0L;

	public Dictionary<string, int> LossInfo { get; set; } = new Dictionary<string, int>();

	public long BossDamage { get; set; } = 0L;

	public int CurShipMultiKillCount { get; set; } = 0;

	public long REKill { get; set; } = 0L;

	public long REBossDamage { get; set; } = 0L;

	public long HoldingScore { get; set; } = 0L;

	public int HoldingProgress { get; set; } = 0;

	public float ContributionPoints_BossDamage { get; set; } = 0f;

	public float ContributionPoints_KillNPCUnit { get; set; } = 0f;

	public float ContributionPoints_KillPlayerUnit { get; set; } = 0f;

	public float ContributionPoints_BattleLossUnit { get; set; } = 0f;

	public float ContributionPoints_HoldingScore { get; set; } = 0f;

	public float ContributionPoints_REBossDamage { get; set; } = 0f;

	public float ContributionPoints_REKillNPCUnit { get; set; } = 0f;

	public float TotalContributionPoints => ContributionPoints_BossDamage + ContributionPoints_KillNPCUnit + ContributionPoints_KillPlayerUnit + ContributionPoints_BattleLossUnit + ContributionPoints_HoldingScore;

	public float RETotalContributionPoints => ContributionPoints_REBossDamage + ContributionPoints_REKillNPCUnit;

	public IslandBattleShipStatData Clone()
	{
		IslandBattleShipStatData islandBattleShipStatData = (IslandBattleShipStatData)MemberwiseClone();
		islandBattleShipStatData.ShipInfo = ShipInfo.Clone();
		islandBattleShipStatData.LossInfo = new Dictionary<string, int>(LossInfo);
		return islandBattleShipStatData;
	}
}
