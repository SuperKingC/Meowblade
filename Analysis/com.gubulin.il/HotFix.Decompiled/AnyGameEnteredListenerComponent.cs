using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyGameEnteredListenerComponent : IComponent
{
	public List<IAnyGameEnteredListener> value;
}
