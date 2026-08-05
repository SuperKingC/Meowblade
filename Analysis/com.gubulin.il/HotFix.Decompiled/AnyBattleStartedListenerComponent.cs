using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyBattleStartedListenerComponent : IComponent
{
	public List<IAnyBattleStartedListener> value;
}
