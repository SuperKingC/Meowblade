using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyLoadingShowAllSoldierListenerComponent : IComponent
{
	public List<IAnyLoadingShowAllSoldierListener> value;
}
