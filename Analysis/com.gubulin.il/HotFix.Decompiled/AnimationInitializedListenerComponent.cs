using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnimationInitializedListenerComponent : IComponent
{
	public List<IAnimationInitializedListener> value;
}
