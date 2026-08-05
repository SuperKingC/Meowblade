using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class OfflineSecondsComponent : IComponent
{
	public int value;
}
