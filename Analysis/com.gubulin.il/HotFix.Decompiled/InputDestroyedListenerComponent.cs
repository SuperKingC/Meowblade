using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class InputDestroyedListenerComponent : IComponent
{
	public List<IInputDestroyedListener> value;
}
