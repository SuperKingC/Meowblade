using System.Collections.Generic;
using System.Linq;
using Shift.Legion.ClientApi.Protocol.UserAction;

namespace Shift.Legion.ClientApi.Models;

public class RankBattleConfigDetail
{
	public List<Dictionary<string, List<RankSoldierEquipmentsInfo>>> SoldierEquipments { get; set; } = new List<Dictionary<string, List<RankSoldierEquipmentsInfo>>>();

	public List<string> FormationIds { get; set; } = new List<string>();

	public List<List<SoldierDetail>> SoldiersDetail { get; set; } = new List<List<SoldierDetail>>();

	public List<int> TeamCombatPower { get; set; } = new List<int>();

	public int MaxCombatPower { get; set; }

	public void TryCopyLegendItemBrief()
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
				foreach (Dictionary<string, List<RankSoldierEquipmentsInfo>> soldierEquipment in SoldierEquipments)
				{
					if (soldierEquipment != null && soldierEquipment.TryGetValue(item.SoldierId, out var value))
					{
						item.LegendItems = value.Select((RankSoldierEquipmentsInfo l) => l.ItemBrief).ToList();
					}
				}
			}
		}
	}
}
