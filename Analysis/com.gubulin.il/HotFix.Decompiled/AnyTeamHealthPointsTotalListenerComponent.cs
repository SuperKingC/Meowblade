using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AnyTeamHealthPointsTotalListenerComponent : IComponent
{
	public List<IAnyTeamHealthPointsTotalListener> value;
}
