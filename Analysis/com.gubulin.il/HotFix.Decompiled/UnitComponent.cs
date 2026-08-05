using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class UnitComponent : IComponent
{
}
