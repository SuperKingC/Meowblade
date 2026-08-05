using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
public sealed class BattleElapsedTimeComponent : IComponent
{
	public float value;
}
