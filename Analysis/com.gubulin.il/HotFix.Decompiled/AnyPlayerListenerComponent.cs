using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyPlayerListenerComponent : IComponent
{
	public List<IAnyPlayerListener> value;
}
