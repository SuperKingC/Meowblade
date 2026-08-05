using Entitas;

public sealed class InitConfigSystem : IInitializeSystem, ISystem
{
	private readonly Contexts _contexts;

	public InitConfigSystem(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Initialize()
	{
		InitConfigHelper.Init(_contexts.config);
	}
}
