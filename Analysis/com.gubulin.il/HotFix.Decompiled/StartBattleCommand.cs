using Entitas;
using Shift.Legion.CodeGeneration.Attributes;

[Command]
[CommandFlag]
public class StartBattleCommand : IComponent
{
	public string value;
}
