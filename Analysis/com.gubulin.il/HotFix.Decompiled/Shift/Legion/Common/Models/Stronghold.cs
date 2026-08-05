using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class Stronghold
{
	public readonly GDEStrongholdData Data;

	public readonly string StrongholdId;

	public Region Region;

	public readonly string Name;

	public readonly string Desc;

	public readonly List<string> Tags;

	public readonly Dictionary<string, int> ProductionsConfig;

	public Dictionary<string, float> Productions(GameManagers managers)
	{
		return Status(managers).Productions;
	}

	public StrongholdConfig Status(GameManagers managers)
	{
		return managers.UserArchiveManager.GetStrongholdStatus(StrongholdId);
	}

	public string Occupant(GameManagers managers)
	{
		return Status(managers).Occupant;
	}

	public bool IsOccupied(GameManagers managers)
	{
		return Status(managers).Occupant != null;
	}

	public float Efficiency(GameManagers managers)
	{
		return IsOccupied(managers) ? (1f + managers.ModifierManager.GetPercentFloatPayload("OccupiedProduceEfficiency") + OccupantEfficiencyModifier(managers)) : 0f;
	}

	public float OccupantEfficiencyModifier(GameManagers managers)
	{
		return IsOccupied(managers) ? CalcOccupantEfficiencyModifier(managers, Occupant(managers)) : 0f;
	}

	public Stronghold(GDEStrongholdData data)
	{
		Data = data;
		StrongholdId = data.Key;
		Name = data.Name;
		Desc = data.Desc;
		Tags = new List<string>();
		if (!string.IsNullOrEmpty(data.Tags))
		{
			Tags.AddRange(data.Tags.Split(' '));
		}
		if (!string.IsNullOrEmpty(data.Bonus))
		{
			ProductionsConfig = JsonHelper.ToObject<Dictionary<string, int>>(data.Bonus);
		}
	}

	public bool AssignOccupantToStronghold(GameManagers managers, string soldierId)
	{
		return managers.UserArchiveManager.AssignOccupantToStronghold(soldierId, StrongholdId);
	}

	public void WithdrawOccupantFromStronghold(GameManagers managers)
	{
		managers.UserArchiveManager.WithdrawOccupantFromStronghold(StrongholdId);
	}

	public void RefreshStatus(GameManagers managers)
	{
		StrongholdConfig strongholdConfig = Status(managers);
		StrongholdConfig strongholdConfig2 = new StrongholdConfig
		{
			StrongholdId = StrongholdId,
			Occupant = strongholdConfig.Occupant
		};
		foreach (KeyValuePair<string, int> item in ProductionsConfig)
		{
			strongholdConfig2.Productions.Add(item.Key, (float)item.Value * Efficiency(managers));
		}
		managers.UserArchiveManager.SetStrongholdStatus(strongholdConfig2);
	}

	public float CalcOccupantEfficiencyModifier(GameManagers managers, string soldierId)
	{
		Soldier soldier = managers.SoldierManager.Get(soldierId);
		return (soldier == null) ? 0f : (0.4f * (float)Tags.Intersect(soldier.Tags).Count() + soldier.ManagePower);
	}
}
