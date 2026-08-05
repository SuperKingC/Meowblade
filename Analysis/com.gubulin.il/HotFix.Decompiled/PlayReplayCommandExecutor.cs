using Shift.Legion.Common.Services;

public class PlayReplayCommandExecutor
{
	private readonly Contexts _contexts;

	public PlayReplayCommandExecutor(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Prepare()
	{
	}

	public void Execute()
	{
		_contexts.Service<ReplayPlayerService>().Play();
	}
}
