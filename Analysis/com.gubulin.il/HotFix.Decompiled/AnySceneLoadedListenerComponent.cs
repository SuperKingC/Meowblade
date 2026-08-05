using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnySceneLoadedListenerComponent : IComponent
{
	public List<IAnySceneLoadedListener> value;
}
