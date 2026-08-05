using Entitas;
using Shift.Legion.Common.Services;

public sealed class UpdateTimeSystem : IExecuteSystem, ISystem
{
	private readonly Contexts _contexts;

	private readonly ITimeService _timeService;

	public UpdateTimeSystem(Contexts contexts)
	{
		_contexts = contexts;
		_timeService = _contexts.Service<ITimeService>();
		Execute();
	}

	public void Execute()
	{
		_contexts.input.ReplaceFixedDeltaTime(_timeService.FixedDeltaTime());
		_contexts.input.ReplaceDeltaTime(_timeService.DeltaTime());
	}
}
