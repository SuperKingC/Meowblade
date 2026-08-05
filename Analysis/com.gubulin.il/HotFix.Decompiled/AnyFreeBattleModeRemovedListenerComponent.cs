using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyFreeBattleModeRemovedListenerComponent : IComponent
{
	public List<IAnyFreeBattleModeRemovedListener> value;
}
