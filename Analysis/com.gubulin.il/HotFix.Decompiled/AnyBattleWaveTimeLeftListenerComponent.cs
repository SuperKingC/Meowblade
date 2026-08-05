using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyBattleWaveTimeLeftListenerComponent : IComponent
{
	public List<IAnyBattleWaveTimeLeftListener> value;
}
