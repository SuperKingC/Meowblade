using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyCurrentLevelBattleStartedRemovedListenerComponent : IComponent
{
	public List<IAnyCurrentLevelBattleStartedRemovedListener> value;
}
