using Entitas;

public class GameStateSystems : Feature
{
	public GameStateSystems(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new InitGameStateSystem(contexts));
		((Systems)this).Add((ISystem)(object)new UpdateGameStateAfterUserLoginSystem(contexts));
	}
}
