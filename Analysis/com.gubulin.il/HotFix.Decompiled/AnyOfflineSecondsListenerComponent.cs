using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyOfflineSecondsListenerComponent : IComponent
{
	public List<IAnyOfflineSecondsListener> value;
}
