using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyCameraRotationListenerComponent : IComponent
{
	public List<IAnyCameraRotationListener> value;
}
