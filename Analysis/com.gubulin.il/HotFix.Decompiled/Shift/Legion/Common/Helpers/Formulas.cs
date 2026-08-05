using System;

namespace Shift.Legion.Common.Helpers;

public static class Formulas
{
	public static int CombatPower(float attackPower, float criticalDamageModifier, float criticalChance, float attackSpeed, float hitRate, float health, float defensePower, float evasionRate, float attackRangeCorrection, float legendItemCorrection)
	{
		float num = ((attackPower + attackPower * (criticalDamageModifier - 1f) * criticalChance) * attackSpeed * hitRate + 0.15f * (health * (1f + defensePower / (defensePower + 3000f) + evasionRate))) * (1f + attackRangeCorrection) * (1f + legendItemCorrection);
		return (int)Math.Floor(num);
	}
}
