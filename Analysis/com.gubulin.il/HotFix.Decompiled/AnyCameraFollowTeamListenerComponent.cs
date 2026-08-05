using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyCameraFollowTeamListenerComponent : IComponent
{
	public List<IAnyCameraFollowTeamListener> value;
}
