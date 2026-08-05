using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyReplayStateRemovedListenerComponent : IComponent
{
	public List<IAnyReplayStateRemovedListener> value;
}
