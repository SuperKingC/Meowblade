using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyNextLevelComingRemovedListenerComponent : IComponent
{
	public List<IAnyNextLevelComingRemovedListener> value;
}
