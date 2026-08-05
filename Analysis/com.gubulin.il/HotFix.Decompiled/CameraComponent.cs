using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class CameraComponent : IComponent
{
	public ICamera value;
}
