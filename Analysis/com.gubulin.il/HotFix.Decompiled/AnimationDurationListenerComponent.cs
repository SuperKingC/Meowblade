using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnimationDurationListenerComponent : IComponent
{
	public List<IAnimationDurationListener> value;
}
