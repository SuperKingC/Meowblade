using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyLoadingPanelStatusListenerComponent : IComponent
{
	public List<IAnyLoadingPanelStatusListener> value;
}
