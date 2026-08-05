using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyBaseVisionRadiusListenerComponent : IComponent
{
	public List<IAnyBaseVisionRadiusListener> value;
}
