using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyHealBarSwitcherListenerComponent : IComponent
{
	public List<IAnyHealBarSwitcherListener> value;
}
