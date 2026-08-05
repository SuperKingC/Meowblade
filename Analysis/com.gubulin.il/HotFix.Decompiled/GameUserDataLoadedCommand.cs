using System.Collections.Generic;
using Entitas;
using Shift.Legion.CodeGeneration.Attributes;
using Shift.Legion.Common.Models;

[Command]
[CommandFlag]
public class GameUserDataLoadedCommand : IComponent
{
	public int userId;

	public Dictionary<string, UserData> data;
}
