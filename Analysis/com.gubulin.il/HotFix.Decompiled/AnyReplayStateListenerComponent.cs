using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyReplayStateListenerComponent : IComponent
{
	public List<IAnyReplayStateListener> value;
}
