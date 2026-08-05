using Entitas;

public abstract class BaseExecuteSystem : IExecuteSystem, ISystem
{
	public readonly Contexts _contexts;

	public BaseExecuteSystem(Contexts contexts)
	{
		_contexts = contexts;
	}

	public abstract void Execute();
}
