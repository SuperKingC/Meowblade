using Shift.Legion.Common.Models;

public class GameUserDataLoadedCommandExecutor
{
	private readonly Contexts _contexts;

	public GameUserDataLoadedCommandExecutor(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Prepare()
	{
	}

	public void Execute(GameUserDataLoadedCommand cmd)
	{
		CharacterArchive characterArchive = new CharacterArchive(cmd.userId);
		characterArchive.Load(cmd.data);
		_contexts.gameState.ReplaceCharacterArchive(characterArchive);
		_contexts.gameState.isUserDataLoaded = true;
	}
}
