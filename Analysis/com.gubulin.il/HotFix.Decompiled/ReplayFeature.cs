using Entitas;

public class ReplayFeature : Systems
{
	public ReplayFeature(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new PlayReplaySystem(contexts));
	}
}
