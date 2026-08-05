using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AlphaListenerComponent : IComponent
{
	public List<IAlphaListener> value;
}
