using System.Collections.Generic;
using System.Linq;
using Shift.Legion.ClientApi.Models;
using UnityEngine;

public class GvGShip : MonoBehaviour
{
	public tShipAttr ShipAttr;

	public GvGSingleBattleInfo BattleInfo;

	private TextMesh SoldierSummary;

	private void Awake()
	{
		SoldierSummary = ((Component)((Component)this).transform.Find("SoldierSummary")).GetComponent<TextMesh>();
	}

	public void LeaveIsland()
	{
	}

	public void UpdateShipAttr(tShipAttr _attr)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		ShipAttr = _attr;
		_attr.ShipInstance = this;
		((Object)((Component)this).gameObject).name = $"GvGShip_{ShipAttr.UserId}";
		((Component)this).transform.position = ShipAttr.GetShipBornPoint();
		SoldierSummary.text = ShipAttr.SoldierSummary.Sum((KeyValuePair<string, GvGSingleBattleSoldierSummary> kv) => kv.Value.Total).ToString();
	}

	public void UpdateBattleInfo(GvGSingleBattleInfo info)
	{
		BattleInfo = info;
	}

	public void GenerateOneGroup()
	{
		RankBattleTopTournamentConfig dungeonPresetFormationConfigs = GameLocalDataManager.GetDungeonPresetFormationConfigs();
		_GenerateOneGroup(dungeonPresetFormationConfigs.FormationsId[0], dungeonPresetFormationConfigs.Units[0]);
	}

	private void _GenerateOneGroup(string formationId, List<SoldierWithLegendItemId> Units)
	{
	}
}
