using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class ShowHealthBarListenerComponent : IComponent
{
	public List<IShowHealthBarListener> value;
}
