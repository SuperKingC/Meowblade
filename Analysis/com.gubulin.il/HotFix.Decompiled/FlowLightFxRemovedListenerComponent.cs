using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class FlowLightFxRemovedListenerComponent : IComponent
{
	public List<IFlowLightFxRemovedListener> value;
}
