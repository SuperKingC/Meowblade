using Entitas;

public class ClearAllUnitsCommandExecutor
{
	private readonly Contexts _contexts;

	public ClearAllUnitsCommandExecutor(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Prepare()
	{
	}

	public void Execute()
	{
		GameEntity[] entities = ((Context<GameEntity>)_contexts.game).GetEntities();
		GameEntity[] array = entities;
		foreach (GameEntity gameEntity in array)
		{
			gameEntity.isDestroyable = true;
		}
	}
}
