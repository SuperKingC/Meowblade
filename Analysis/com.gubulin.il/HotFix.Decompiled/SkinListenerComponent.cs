using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class SkinListenerComponent : IComponent
{
	public List<ISkinListener> value;
}
