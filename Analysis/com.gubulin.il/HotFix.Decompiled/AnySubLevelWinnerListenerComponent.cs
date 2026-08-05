using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnySubLevelWinnerListenerComponent : IComponent
{
	public List<IAnySubLevelWinnerListener> value;
}
