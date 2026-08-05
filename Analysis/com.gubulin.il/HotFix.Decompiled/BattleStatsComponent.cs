using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;

[GameState]
[Unique]
public sealed class BattleStatsComponent : IComponent
{
	public Dictionary<Team, TeamUnitStats> value;
}
