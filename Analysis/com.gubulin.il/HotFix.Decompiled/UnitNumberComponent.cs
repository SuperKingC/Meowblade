using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class UnitNumberComponent : IComponent
{
	public int value;
}
