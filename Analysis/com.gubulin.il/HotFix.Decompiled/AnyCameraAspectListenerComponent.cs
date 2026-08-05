using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyCameraAspectListenerComponent : IComponent
{
	public List<IAnyCameraAspectListener> value;
}
