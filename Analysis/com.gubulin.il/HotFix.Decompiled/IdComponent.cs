using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Timer]
public sealed class IdComponent : IComponent
{
	[PrimaryEntityIndex]
	public int value;
}
