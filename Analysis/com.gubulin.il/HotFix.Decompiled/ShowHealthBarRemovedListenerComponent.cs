using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class ShowHealthBarRemovedListenerComponent : IComponent
{
	public List<IShowHealthBarRemovedListener> value;
}
