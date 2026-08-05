using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyCameraMoveLimitListenerComponent : IComponent
{
	public List<IAnyCameraMoveLimitListener> value;
}
