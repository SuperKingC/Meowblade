using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyCurrentLevelBattleStartedListenerComponent : IComponent
{
	public List<IAnyCurrentLevelBattleStartedListener> value;
}
