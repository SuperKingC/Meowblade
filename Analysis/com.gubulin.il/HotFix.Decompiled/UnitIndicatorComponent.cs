using Entitas;
using Entitas.CodeGeneration.Attributes;
using GameMaths;

[Game]
[Event(EventTarget.Self, EventType.Added, 0)]
[Event(EventTarget.Self, EventType.Removed, 0)]
public sealed class UnitIndicatorComponent : IComponent
{
	public Color32 value;
}
