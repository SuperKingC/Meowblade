using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
[Event(EventTarget.Any, EventType.Removed, 0)]
public sealed class FreeBattleModeComponent : IComponent
{
}
