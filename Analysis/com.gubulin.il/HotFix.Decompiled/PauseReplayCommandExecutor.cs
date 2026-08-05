using Shift.Legion.Common.Services;

public class PauseReplayCommandExecutor
{
	private readonly Contexts _contexts;

	public PauseReplayCommandExecutor(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Prepare()
	{
	}

	public void Execute()
	{
		_contexts.Service<ReplayPlayerService>().Pause();
	}
}
