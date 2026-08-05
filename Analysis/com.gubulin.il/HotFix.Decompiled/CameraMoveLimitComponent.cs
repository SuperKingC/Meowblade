using Entitas;
using Entitas.CodeGeneration.Attributes;
using GameMaths;

[GameState]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class CameraMoveLimitComponent : IComponent
{
	public Vector3 position;

	public Vector3 size;
}
