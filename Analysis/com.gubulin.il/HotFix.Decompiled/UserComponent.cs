using Entitas;
using Entitas.CodeGeneration.Attributes;
using Shift.Legion.ClientApi.Protocol;

[GameState]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class UserComponent : IComponent
{
	public User value;
}
