using Entitas;
using Entitas.CodeGeneration.Attributes;
using GameMaths;

[Game]
[Event(EventTarget.Self, EventType.Added, 0)]
public sealed class RotationComponent : IComponent
{
	public Quaternion value;
}
