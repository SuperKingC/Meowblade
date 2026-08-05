using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Event(EventTarget.Any, EventType.Added, 0)]
[Event(EventTarget.Self, EventType.Removed, 0)]
public sealed class AssetComponent : IComponent
{
	public string value;
}
