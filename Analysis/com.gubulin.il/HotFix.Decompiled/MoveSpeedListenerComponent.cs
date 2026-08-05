using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class MoveSpeedListenerComponent : IComponent
{
	public List<IMoveSpeedListener> value;
}
