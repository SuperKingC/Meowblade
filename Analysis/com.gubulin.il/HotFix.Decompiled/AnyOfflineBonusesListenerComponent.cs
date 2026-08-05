using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyOfflineBonusesListenerComponent : IComponent
{
	public List<IAnyOfflineBonusesListener> value;
}
