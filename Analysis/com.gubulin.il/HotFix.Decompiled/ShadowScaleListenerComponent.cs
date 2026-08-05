using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class ShadowScaleListenerComponent : IComponent
{
	public List<IShadowScaleListener> value;
}
