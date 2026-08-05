using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class BattleFieldSubLevelIndexComponent : IComponent
{
	public int value;
}
