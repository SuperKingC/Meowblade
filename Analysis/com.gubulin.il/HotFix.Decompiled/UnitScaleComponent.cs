using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Event(EventTarget.Self, EventType.Added, 0)]
public sealed class UnitScaleComponent : IComponent
{
	public float value;
}
