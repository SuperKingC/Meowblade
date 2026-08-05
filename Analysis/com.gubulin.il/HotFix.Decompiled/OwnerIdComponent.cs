using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public sealed class OwnerIdComponent : IComponent
{
	[EntityIndex]
	public int value;
}
