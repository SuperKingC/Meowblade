using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class FlowLightFxListenerComponent : IComponent
{
	public List<IFlowLightFxListener> value;
}
