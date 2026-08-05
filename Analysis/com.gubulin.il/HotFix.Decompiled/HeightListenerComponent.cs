using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class HeightListenerComponent : IComponent
{
	public List<IHeightListener> value;
}
