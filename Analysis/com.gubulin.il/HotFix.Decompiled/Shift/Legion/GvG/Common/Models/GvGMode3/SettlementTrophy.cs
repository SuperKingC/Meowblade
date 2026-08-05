namespace Shift.Legion.GvG.Common.Models.GvGMode3;

public class SettlementTrophy
{
	public string Type { get; set; }

	public string TrophyName { get; set; }

	public eLeaderboardType LBType => (eLeaderboardType)int.Parse(Type);
}
