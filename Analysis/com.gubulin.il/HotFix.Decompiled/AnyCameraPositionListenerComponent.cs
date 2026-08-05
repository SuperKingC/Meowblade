using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyCameraPositionListenerComponent : IComponent
{
	public List<IAnyCameraPositionListener> value;
}
