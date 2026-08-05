using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyCurrentFormationListenerComponent : IComponent
{
	public List<IAnyCurrentFormationListener> value;
}
