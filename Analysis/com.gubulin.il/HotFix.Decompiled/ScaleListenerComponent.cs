using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class ScaleListenerComponent : IComponent
{
	public List<IScaleListener> value;
}
