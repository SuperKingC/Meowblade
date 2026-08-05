using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class ModelListenerComponent : IComponent
{
	public List<IModelListener> value;
}
