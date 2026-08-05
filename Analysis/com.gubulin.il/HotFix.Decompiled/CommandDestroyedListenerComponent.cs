using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class CommandDestroyedListenerComponent : IComponent
{
	public List<ICommandDestroyedListener> value;
}
