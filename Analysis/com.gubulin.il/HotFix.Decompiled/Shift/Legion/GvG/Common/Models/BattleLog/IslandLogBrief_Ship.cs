namespace Shift.Legion.GvG.Common.Models.BattleLog;

public class IslandLogBrief_Ship
{
	public string ShipId { get; set; }

	public int ShipRace { get; set; }

	public IslandBattleShipStatData ShipStatData { get; set; }

	public int Kill => (int)ShipStatData.Kill;

	public int Loss => (int)ShipStatData.Loss;

	public int HoldingProgress => ShipStatData.HoldingProgress;

	public float HoldingProgressUi => (float)HoldingProgress / 100f;
}
