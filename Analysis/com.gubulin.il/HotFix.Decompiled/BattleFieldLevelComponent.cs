using Entitas;
using Entitas.CodeGeneration.Attributes;
using Shift.Legion.Common.Models;

[GameState]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class BattleFieldLevelComponent : IComponent
{
	public Level value;
}
