using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyRedTeamCampPositionListenerComponent : IComponent
{
	public List<IAnyRedTeamCampPositionListener> value;
}
