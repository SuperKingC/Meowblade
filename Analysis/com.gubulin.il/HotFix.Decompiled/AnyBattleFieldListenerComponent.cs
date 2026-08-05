using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyBattleFieldListenerComponent : IComponent
{
	public List<IAnyBattleFieldListener> value;
}
