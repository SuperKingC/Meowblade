using Entitas;
using Entitas.CodeGeneration.Attributes;
using GameMaths;

[GameState]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class CameraRotationComponent : IComponent
{
	public Quaternion value;
}
