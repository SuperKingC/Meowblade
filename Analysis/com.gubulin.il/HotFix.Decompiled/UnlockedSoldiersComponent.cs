using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class UnlockedSoldiersComponent : IComponent
{
	public List<string> value;
}
