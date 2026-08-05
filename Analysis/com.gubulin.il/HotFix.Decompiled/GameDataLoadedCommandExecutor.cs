using Shift.Legion.Common.Services;

public class GameDataLoadedCommandExecutor
{
	private readonly Contexts _contexts;

	public GameDataLoadedCommandExecutor(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Prepare()
	{
	}

	public void Execute(GameDataLoadedCommand cmd)
	{
		_contexts.Service<IGameDataService>().LoadGameData(cmd.data);
		_contexts.gameState.isGameDataLoaded = true;
	}
}
