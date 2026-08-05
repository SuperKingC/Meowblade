using Entitas;
using Shift.Legion.CodeGeneration.Attributes;

[Command]
[CommandFlag]
public sealed class ChangeCurrentFormationUnitCommand : IComponent
{
	public int portalId;

	public string unitId;

	public string context;

	public string subContext;
}
