using Entitas;
using Entitas.CodeGeneration.Attributes;
using Shift.Legion.Common.Models;

[Game]
[Unique]
public sealed class DungeonComponent : IComponent
{
	public Dungeon value;
}
