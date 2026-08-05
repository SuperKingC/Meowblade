using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class SpecialFxRemovedListenerComponent : IComponent
{
	public List<ISpecialFxRemovedListener> value;
}
