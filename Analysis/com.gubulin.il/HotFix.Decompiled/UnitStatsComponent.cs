using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Event(EventTarget.Self, EventType.Added, 0)]
public sealed class UnitStatsComponent : IComponent
{
	public UnitStats value;
}
