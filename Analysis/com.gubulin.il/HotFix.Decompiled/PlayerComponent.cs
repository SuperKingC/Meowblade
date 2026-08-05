using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class PlayerComponent : IComponent
{
}
