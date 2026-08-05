using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
[Event(EventTarget.Any, EventType.Removed, 0)]
public sealed class ReplayStateComponent : IComponent
{
	public const int Playing = 1;

	public const int Paused = 2;

	public const int Finished = 3;

	public int value;
}
