using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyWinnerListenerComponent : IComponent
{
	public List<IAnyWinnerListener> value;
}
