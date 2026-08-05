using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyReplayModeListenerComponent : IComponent
{
	public List<IAnyReplayModeListener> value;
}
