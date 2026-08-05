using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class FormationUnitsComponent : IComponent
{
	public Dictionary<string, Dictionary<string, List<string>>> value;
}
