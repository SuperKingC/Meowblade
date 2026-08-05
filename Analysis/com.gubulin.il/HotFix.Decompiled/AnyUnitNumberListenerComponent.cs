using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyUnitNumberListenerComponent : IComponent
{
	public List<IAnyUnitNumberListener> value;
}
