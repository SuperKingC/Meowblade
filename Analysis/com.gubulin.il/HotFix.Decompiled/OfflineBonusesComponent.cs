using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Shift.Legion.Common.Models;

[GameState]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class OfflineBonusesComponent : IComponent
{
	public List<Bonus> value;
}
