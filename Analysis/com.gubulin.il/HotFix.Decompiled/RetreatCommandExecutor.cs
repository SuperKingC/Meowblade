using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Services;

public class RetreatCommandExecutor
{
	private readonly Contexts _contexts;

	public RetreatCommandExecutor(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Prepare()
	{
	}

	public void Execute()
	{
		_contexts.gameState.isRetreat = true;
		_contexts.gameState.ReplaceWinner(Team.Blue);
		_contexts.Service<ReplayPlayerService>().Stop();
	}
}
