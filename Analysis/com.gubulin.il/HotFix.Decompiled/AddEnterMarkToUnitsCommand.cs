using Entitas;
using Shift.Legion.CodeGeneration.Attributes;
using Shift.Legion.Common.Enums;

[Command]
[CommandFlag]
public sealed class AddEnterMarkToUnitsCommand : IComponent
{
	public Team team;

	public int portalId;
}
