using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class RotationListenerComponent : IComponent
{
	public List<IRotationListener> value;
}
