using System.Collections.Generic;

namespace Shift.Legion.Common.Models;

public class BattleResultStats
{
	public string[,] Units;

	public int[,] UnitsTotal;

	public Dictionary<string, int> UnitsDead;

	public Dictionary<string, float> UnitsDamage;

	public float CurrentHp;

	public float TotalHp;
}
