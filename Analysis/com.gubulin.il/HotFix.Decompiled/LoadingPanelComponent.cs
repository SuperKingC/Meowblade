using Entitas;
using Entitas.CodeGeneration.Attributes;
using Shift.Legion.Common.Interfaces;

[GameState]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class LoadingPanelComponent : IComponent
{
	public IUiPanel value;
}
