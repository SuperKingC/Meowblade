using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
public sealed class BattleWaveElapsedTimeComponent : IComponent
{
	public float value;
}
