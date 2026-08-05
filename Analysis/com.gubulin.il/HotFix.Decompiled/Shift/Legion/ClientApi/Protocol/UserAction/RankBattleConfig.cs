using System.Collections.Generic;
using System.Linq;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

public class RankBattleConfig
{
	public float BossDamageMultiplier;

	public Dictionary<string, int> UnitsPool;

	public Dictionary<string, int> UnitsBorn;

	public List<List<string>> _unitsId;

	public List<List<SoldierDetail>> SoldiersDetail;

	public List<List<GameEntityData>> _units;

	public string[] _bossId;

	public GameEntityData[] _boss;

	public List<List<int>> UnitsTotal;

	public List<List<float>> UnitsHp;

	public BattleMode BattleMode;

	public List<List<float>> CombatPowerModifier;

	public string[] FormationId;

	public Obstacle[] Obstacles;

	public void TryCopyLegendItemBrief(List<Dictionary<string, List<RankSoldierEquipmentsInfo>>> SoldierEquipments)
	{
		if (SoldiersDetail == null || SoldierEquipments == null || SoldierEquipments.Count == 0)
		{
			return;
		}
		for (int i = 0; i < SoldiersDetail.Count; i++)
		{
			List<SoldierDetail> list = SoldiersDetail[i];
			if (list == null)
			{
				continue;
			}
			foreach (SoldierDetail item in list)
			{
				if (item == null || (item.LegendItems != null && item.LegendItems.Count > 0))
				{
					continue;
				}
				foreach (Dictionary<string, List<RankSoldierEquipmentsInfo>> SoldierEquipment in SoldierEquipments)
				{
					if (SoldierEquipment != null && SoldierEquipment.TryGetValue(item.SoldierId, out var value))
					{
						item.LegendItems = value.Select((RankSoldierEquipmentsInfo l) => l.ItemBrief).ToList();
					}
				}
			}
		}
	}
}
