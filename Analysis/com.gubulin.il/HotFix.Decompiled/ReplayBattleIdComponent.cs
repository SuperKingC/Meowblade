using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
public sealed class ReplayBattleIdComponent : IComponent
{
	public string value;
}
