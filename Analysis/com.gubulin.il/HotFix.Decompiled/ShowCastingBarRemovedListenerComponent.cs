using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class ShowCastingBarRemovedListenerComponent : IComponent
{
	public List<IShowCastingBarRemovedListener> value;
}
