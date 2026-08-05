using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyLoadViewFromResourcesRemovedListenerComponent : IComponent
{
	public List<IAnyLoadViewFromResourcesRemovedListener> value;
}
