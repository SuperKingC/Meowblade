using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Event(EventTarget.Self, EventType.Added, 0)]
[Event(EventTarget.Self, EventType.Removed, 0)]
public sealed class FlowLightFxComponent : IComponent
{
	public int id;

	public float power;

	public float speed;
}
