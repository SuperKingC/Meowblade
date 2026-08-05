using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyBattleConfigListenerComponent : IComponent
{
	public List<IAnyBattleConfigListener> value;
}
