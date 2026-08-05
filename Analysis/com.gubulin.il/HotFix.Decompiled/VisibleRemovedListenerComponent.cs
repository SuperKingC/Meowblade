using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class VisibleRemovedListenerComponent : IComponent
{
	public List<IVisibleRemovedListener> value;
}
