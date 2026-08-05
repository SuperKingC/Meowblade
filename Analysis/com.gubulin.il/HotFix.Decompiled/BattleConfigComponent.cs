using Entitas;
using Entitas.CodeGeneration.Attributes;
using Shift.Legion.Common.Models;

[Config]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class BattleConfigComponent : IComponent
{
	public BattleConfig Red { get; set; }

	public BattleConfig Blue { get; set; }

	public float BattleFieldLength { get; set; }
}
