using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyReplayModeRemovedListenerComponent : IComponent
{
	public List<IAnyReplayModeRemovedListener> value;
}
