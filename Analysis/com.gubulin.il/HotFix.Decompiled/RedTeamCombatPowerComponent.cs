using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class RedTeamCombatPowerComponent : IComponent
{
	public int value;
}
