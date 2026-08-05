using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class SpecialFxListenerComponent : IComponent
{
	public List<ISpecialFxListener> value;
}
