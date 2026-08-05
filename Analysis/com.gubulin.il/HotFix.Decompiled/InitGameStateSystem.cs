using Entitas;

public sealed class InitGameStateSystem : IInitializeSystem, ISystem
{
	private readonly Contexts _contexts;

	public InitGameStateSystem(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Initialize()
	{
		InitGameStateHelper.Init(_contexts.gameState);
	}
}
