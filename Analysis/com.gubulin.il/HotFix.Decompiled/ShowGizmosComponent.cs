using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Event(EventTarget.Self, EventType.Added, 0)]
public sealed class ShowGizmosComponent : IComponent
{
	public bool value;
}
