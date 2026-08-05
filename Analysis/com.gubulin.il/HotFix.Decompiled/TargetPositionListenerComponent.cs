using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class TargetPositionListenerComponent : IComponent
{
	public List<ITargetPositionListener> value;
}
