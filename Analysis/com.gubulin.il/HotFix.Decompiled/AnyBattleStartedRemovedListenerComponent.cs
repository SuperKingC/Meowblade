using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyBattleStartedRemovedListenerComponent : IComponent
{
	public List<IAnyBattleStartedRemovedListener> value;
}
