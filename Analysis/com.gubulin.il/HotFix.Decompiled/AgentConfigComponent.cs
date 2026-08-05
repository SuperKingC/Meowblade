using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public sealed class AgentConfigComponent : IComponent
{
	public int maxNeighbors;

	public float neighborDist;

	public float timeHorizon;

	public float timeHorizonObst;
}
