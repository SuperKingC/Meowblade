using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyUnitListenerComponent : IComponent
{
	public List<IAnyUnitListener> value;
}
