using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyBattleTimeLeftListenerComponent : IComponent
{
	public List<IAnyBattleTimeLeftListener> value;
}
