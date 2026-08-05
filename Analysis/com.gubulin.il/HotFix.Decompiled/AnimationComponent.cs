using Entitas;
using Entitas.CodeGeneration.Attributes;
using Shift.Legion.Common.Enums;

[Game]
[Event(EventTarget.Self, EventType.Added, 0)]
public sealed class AnimationComponent : IComponent
{
	public AnimationName value;
}
