using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class CollisionRadiusListenerComponent : IComponent
{
	public List<ICollisionRadiusListener> value;
}
