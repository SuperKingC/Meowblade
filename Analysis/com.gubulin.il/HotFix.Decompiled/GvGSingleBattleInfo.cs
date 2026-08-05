using System.Collections.Generic;

public class GvGSingleBattleInfo
{
	public GvGShip AttackerShipInstance;

	public GvGShip DefenderShipInstance;

	public string CurBattleId;

	public tKeyValue<float, float> CurFightPoint;

	public float AttackerMoveSpeed;

	public float DefenderMoveSpeed;

	public int CurBattleStartTime;

	public int CurBattleEndTime;

	public GvGSingleBattleState CurBattleState;

	public GvGSingleBattleResult CurBattleResult;

	public Dictionary<string, GvGSingleBattleSoldierSummary> AttackerSoilderSummary;

	public Dictionary<string, GvGSingleBattleSoldierSummary> DefenderSoilderSummary;
}
