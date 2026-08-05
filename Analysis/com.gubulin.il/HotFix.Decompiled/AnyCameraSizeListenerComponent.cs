using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyCameraSizeListenerComponent : IComponent
{
	public List<IAnyCameraSizeListener> value;
}
