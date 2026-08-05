using Entitas;
using Entitas.CodeGeneration.Attributes;
using Shift.Legion.Common.Models;

[GameState]
[Unique]
public sealed class CharacterArchiveComponent : IComponent
{
	public CharacterArchive value;
}
