using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyFreeBattleModeListenerComponent : IComponent
{
	public List<IAnyFreeBattleModeListener> value;
}
