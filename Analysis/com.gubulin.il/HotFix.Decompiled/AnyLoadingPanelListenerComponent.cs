using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyLoadingPanelListenerComponent : IComponent
{
	public List<IAnyLoadingPanelListener> value;
}
