using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class ShowGizmosListenerComponent : IComponent
{
	public List<IShowGizmosListener> value;
}
