using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyBlueTeamCombatPowerListenerComponent : IComponent
{
	public List<IAnyBlueTeamCombatPowerListener> value;
}
