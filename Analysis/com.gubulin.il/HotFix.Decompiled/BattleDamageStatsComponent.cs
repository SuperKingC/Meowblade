using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
public sealed class BattleDamageStatsComponent : IComponent
{
	public Dictionary<string, float> red;

	public Dictionary<string, float> blue;
}
