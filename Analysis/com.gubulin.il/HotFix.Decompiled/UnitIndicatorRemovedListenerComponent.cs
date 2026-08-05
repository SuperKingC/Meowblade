using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class UnitIndicatorRemovedListenerComponent : IComponent
{
	public List<IUnitIndicatorRemovedListener> value;
}
