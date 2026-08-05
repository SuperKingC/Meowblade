using System.Collections.Generic;
using System.Linq;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class BattleRecordDetailModel
{
	public string FormationId;

	public List<SoldierDetail> Soldiers;

	public SoldierDetail GetDetailModel(string soldierId)
	{
		return Soldiers.FirstOrDefault((SoldierDetail soldier) => soldier.SoldierId == soldierId);
	}

	public long GetTotalCombatPower(long diffCombatPower, Dictionary<string, int> team)
	{
		if (team == null)
		{
			return 0L;
		}
		long num = 0L;
		foreach (KeyValuePair<string, int> item in team)
		{
			SoldierDetail detailModel = GetDetailModel(item.Key);
			if (detailModel != null)
			{
				num += long.Parse(detailModel.CombatPower) * item.Value;
			}
		}
		return num + diffCombatPower;
	}

	public int GetBossLevel()
	{
		foreach (SoldierDetail soldier2 in Soldiers)
		{
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldier2.SoldierId);
			if (soldier.Tags.Contains("WORLD_BOSS"))
			{
				return soldier2.Level;
			}
		}
		return 0;
	}
}
