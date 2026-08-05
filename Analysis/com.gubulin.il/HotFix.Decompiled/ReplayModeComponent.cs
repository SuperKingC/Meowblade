using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
[Event(EventTarget.Any, EventType.Removed, 0)]
public sealed class ReplayModeComponent : IComponent
{
	public const int Normal = 1;

	public const int Story = 2;

	public const int Replay = 3;

	public int value;
}
