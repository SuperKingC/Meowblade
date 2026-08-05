using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyRedTeamCombatPowerListenerComponent : IComponent
{
	public List<IAnyRedTeamCombatPowerListener> value;
}
