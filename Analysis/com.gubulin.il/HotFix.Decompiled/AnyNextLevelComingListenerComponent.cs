using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyNextLevelComingListenerComponent : IComponent
{
	public List<IAnyNextLevelComingListener> value;
}
