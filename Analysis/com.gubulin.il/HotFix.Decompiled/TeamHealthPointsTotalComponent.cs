using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
[Event(EventTarget.Any, EventType.Added, 0)]
public sealed class TeamHealthPointsTotalComponent : IComponent
{
	public float redCurrent;

	public float redTotal;

	public float blueCurrent;

	public float blueTotal;
}
