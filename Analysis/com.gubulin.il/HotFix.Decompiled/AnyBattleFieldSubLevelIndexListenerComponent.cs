using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyBattleFieldSubLevelIndexListenerComponent : IComponent
{
	public List<IAnyBattleFieldSubLevelIndexListener> value;
}
