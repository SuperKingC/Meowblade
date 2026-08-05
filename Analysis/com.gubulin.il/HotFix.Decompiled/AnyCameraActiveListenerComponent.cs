using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyCameraActiveListenerComponent : IComponent
{
	public List<IAnyCameraActiveListener> value;
}
