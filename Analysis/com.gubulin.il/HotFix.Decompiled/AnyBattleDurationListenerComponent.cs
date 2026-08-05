using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyBattleDurationListenerComponent : IComponent
{
	public List<IAnyBattleDurationListener> value;
}
