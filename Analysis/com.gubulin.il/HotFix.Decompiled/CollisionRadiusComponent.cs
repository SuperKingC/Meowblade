using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Event(EventTarget.Self, EventType.Added, 0)]
public sealed class CollisionRadiusComponent : IComponent
{
	public float value;
}
