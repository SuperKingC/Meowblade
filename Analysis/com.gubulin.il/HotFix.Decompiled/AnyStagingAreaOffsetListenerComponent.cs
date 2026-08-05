using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyStagingAreaOffsetListenerComponent : IComponent
{
	public List<IAnyStagingAreaOffsetListener> value;
}
