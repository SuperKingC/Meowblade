using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class SkeletonListenerComponent : IComponent
{
	public List<ISkeletonListener> value;
}
