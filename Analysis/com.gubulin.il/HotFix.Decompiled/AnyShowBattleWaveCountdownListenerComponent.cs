using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyShowBattleWaveCountdownListenerComponent : IComponent
{
	public List<IAnyShowBattleWaveCountdownListener> value;
}
