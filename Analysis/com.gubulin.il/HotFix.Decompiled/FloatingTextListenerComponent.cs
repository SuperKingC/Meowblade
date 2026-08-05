using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class FloatingTextListenerComponent : IComponent
{
	public List<IFloatingTextListener> value;
}
