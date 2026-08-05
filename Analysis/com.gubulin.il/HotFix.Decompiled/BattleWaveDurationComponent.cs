using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class BattleWaveDurationComponent : IComponent
{
	public int value;
}
