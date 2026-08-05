using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Shift.Legion.Common.Models;

[GameState]
[Unique]
public sealed class BattleProgressStatsComponent : IComponent
{
	public List<Bonus> bonusRecord;

	public int clearStages;
}
