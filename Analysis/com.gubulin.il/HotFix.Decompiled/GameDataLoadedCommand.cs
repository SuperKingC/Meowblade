using Entitas;
using Shift.Legion.CodeGeneration.Attributes;

[Command]
[CommandFlag]
public class GameDataLoadedCommand : IComponent
{
	public byte[] data;
}
