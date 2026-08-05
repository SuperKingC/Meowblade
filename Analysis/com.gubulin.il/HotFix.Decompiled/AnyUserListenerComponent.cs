using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyUserListenerComponent : IComponent
{
	public List<IAnyUserListener> value;
}
