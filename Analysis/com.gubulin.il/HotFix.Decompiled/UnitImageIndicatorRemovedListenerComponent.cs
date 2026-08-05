using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class UnitImageIndicatorRemovedListenerComponent : IComponent
{
	public List<IUnitImageIndicatorRemovedListener> value;
}
