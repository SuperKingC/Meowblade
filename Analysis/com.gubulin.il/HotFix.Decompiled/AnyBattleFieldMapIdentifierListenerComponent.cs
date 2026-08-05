using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyBattleFieldMapIdentifierListenerComponent : IComponent
{
	public List<IAnyBattleFieldMapIdentifierListener> value;
}
