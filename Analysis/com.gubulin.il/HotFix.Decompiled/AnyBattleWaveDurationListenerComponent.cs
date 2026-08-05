using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyBattleWaveDurationListenerComponent : IComponent
{
	public List<IAnyBattleWaveDurationListener> value;
}
