using Entitas;

public static class GameContextExtension
{
	public static GameEntity GetEntity(this Contexts contexts, int id)
	{
		if (id < 0)
		{
			return null;
		}
		GameEntity entityWithId = contexts.game.GetEntityWithId(id);
		if (entityWithId == null || !((Entity)entityWithId).isEnabled || !entityWithId.isGameObject)
		{
			return null;
		}
		return entityWithId;
	}
}
