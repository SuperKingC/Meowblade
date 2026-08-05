using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyRedTeamStagingAreaPositionListenerComponent : IComponent
{
	public List<IAnyRedTeamStagingAreaPositionListener> value;
}
