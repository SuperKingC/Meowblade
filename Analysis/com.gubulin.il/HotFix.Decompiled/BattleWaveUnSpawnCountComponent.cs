using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
public sealed class BattleWaveUnSpawnCountComponent : IComponent
{
	public int value;
}
