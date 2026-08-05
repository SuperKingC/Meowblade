using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class TimerDestroyedListenerComponent : IComponent
{
	public List<ITimerDestroyedListener> value;
}
