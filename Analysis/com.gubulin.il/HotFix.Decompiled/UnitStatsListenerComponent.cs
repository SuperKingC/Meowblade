using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class UnitStatsListenerComponent : IComponent
{
	public List<IUnitStatsListener> value;
}
