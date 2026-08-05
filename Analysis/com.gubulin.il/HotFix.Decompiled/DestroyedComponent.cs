using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Timer]
[Command]
[Input]
[Event(EventTarget.Self, EventType.Added, 0)]
[Cleanup(CleanupMode.DestroyEntity)]
public sealed class DestroyedComponent : IComponent
{
}
