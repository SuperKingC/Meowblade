using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyBattleFieldLengthListenerComponent : IComponent
{
	public List<IAnyBattleFieldLengthListener> value;
}
