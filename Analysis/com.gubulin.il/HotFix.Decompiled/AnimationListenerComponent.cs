using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnimationListenerComponent : IComponent
{
	public List<IAnimationListener> value;
}
