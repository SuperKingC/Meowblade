using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyStagingAreaSizeListenerComponent : IComponent
{
	public List<IAnyStagingAreaSizeListener> value;
}
