using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyLoadingTotalListenerComponent : IComponent
{
	public List<IAnyLoadingTotalListener> value;
}
