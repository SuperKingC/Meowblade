using Entitas;

public sealed class UpdateTickSystem : IExecuteSystem, ISystem
{
	private readonly InputContext _context;

	public UpdateTickSystem(Contexts contexts)
	{
		_context = contexts.input;
		_context.SetTick(0);
	}

	public void Execute()
	{
		_context.ReplaceTick(_context.tick.value + 1);
	}
}
