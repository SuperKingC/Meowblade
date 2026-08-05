using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyLoserListenerComponent : IComponent
{
	public List<IAnyLoserListener> value;
}
