using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyBattleFieldLevelListenerComponent : IComponent
{
	public List<IAnyBattleFieldLevelListener> value;
}
