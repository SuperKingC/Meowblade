using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class FloatingTextAlphaListenerComponent : IComponent
{
	public List<IFloatingTextAlphaListener> value;
}
