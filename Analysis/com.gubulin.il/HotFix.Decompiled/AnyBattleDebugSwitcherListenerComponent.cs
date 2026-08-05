using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyBattleDebugSwitcherListenerComponent : IComponent
{
	public List<IAnyBattleDebugSwitcherListener> value;
}
