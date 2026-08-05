using System.Collections.Generic;
using Entitas;
using Shift.Legion.CodeGeneration.Attributes;

[Command]
[CommandFlag]
public class UnlockSoldierCommand : IComponent
{
	public string soldierId;

	public List<string> unlockedProduct;
}
