using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class BattleDebugSwitcherComponent : IComponent
{
	public bool value;
}
