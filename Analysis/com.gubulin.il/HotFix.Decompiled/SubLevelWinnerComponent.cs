using Entitas;
using Entitas.CodeGeneration.Attributes;
using Shift.Legion.Common.Enums;

[GameState]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class SubLevelWinnerComponent : IComponent
{
	public Team value;
}
