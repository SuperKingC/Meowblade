using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
public sealed class BattleIdComponent : IComponent
{
	public string value;
}
