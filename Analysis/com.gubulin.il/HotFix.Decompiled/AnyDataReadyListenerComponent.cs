using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyDataReadyListenerComponent : IComponent
{
	public List<IAnyDataReadyListener> value;
}
