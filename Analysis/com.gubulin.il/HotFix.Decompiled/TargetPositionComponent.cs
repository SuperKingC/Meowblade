using Entitas;
using Entitas.CodeGeneration.Attributes;
using GameMaths;

[Game]
[Event(EventTarget.Self, EventType.Added, 0)]
public sealed class TargetPositionComponent : IComponent
{
	public Vector3 value;
}
