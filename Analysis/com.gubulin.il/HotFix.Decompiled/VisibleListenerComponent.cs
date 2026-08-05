using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class VisibleListenerComponent : IComponent
{
	public List<IVisibleListener> value;
}
