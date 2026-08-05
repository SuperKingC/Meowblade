using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public sealed class RvoTimeStepComponent : IComponent
{
	public float value;
}
