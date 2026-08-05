using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class DeadListenerComponent : IComponent
{
	public List<IDeadListener> value;
}
