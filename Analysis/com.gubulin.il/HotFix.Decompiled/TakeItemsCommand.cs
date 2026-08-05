using System.Collections.Generic;
using Entitas;
using Shift.Legion.CodeGeneration.Attributes;
using Shift.Legion.Common.Models;

[Command]
[CommandFlag]
public sealed class TakeItemsCommand : IComponent
{
	public List<Bonus> items;
}
