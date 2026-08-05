using Entitas;
using Entitas.CodeGeneration.Attributes;
using GameMaths;

[Config]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class StagingAreaSizeComponent : IComponent
{
	public Vector2 value;
}
