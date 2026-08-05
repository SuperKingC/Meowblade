using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class MouseScrollDeltaComponent : IComponent
{
	public float value;
}
