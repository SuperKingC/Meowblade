using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyUnlockedSoldiersListenerComponent : IComponent
{
	public List<IAnyUnlockedSoldiersListener> value;
}
