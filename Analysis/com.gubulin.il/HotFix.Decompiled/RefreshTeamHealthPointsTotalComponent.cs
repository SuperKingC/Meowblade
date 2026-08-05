using Entitas;
using Entitas.CodeGeneration.Attributes;
using Shift.Legion.Common.Enums;

[GameState]
[Unique]
public sealed class RefreshTeamHealthPointsTotalComponent : IComponent
{
	public Team value;
}
