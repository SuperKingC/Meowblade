using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class UnitBaseImageRemovedListenerComponent : IComponent
{
	public List<IUnitBaseImageRemovedListener> value;
}
