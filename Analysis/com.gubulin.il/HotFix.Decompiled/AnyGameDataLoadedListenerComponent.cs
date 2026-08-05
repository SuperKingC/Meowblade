using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyGameDataLoadedListenerComponent : IComponent
{
	public List<IAnyGameDataLoadedListener> value;
}
