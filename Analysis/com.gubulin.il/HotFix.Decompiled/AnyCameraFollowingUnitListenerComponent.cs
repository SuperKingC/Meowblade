using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyCameraFollowingUnitListenerComponent : IComponent
{
	public List<IAnyCameraFollowingUnitListener> value;
}
