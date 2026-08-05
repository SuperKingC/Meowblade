using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyMouseScrollDeltaListenerComponent : IComponent
{
	public List<IAnyMouseScrollDeltaListener> value;
}
