using Entitas;

public static class ParticleLogic
{
	public static void Destroy(Contexts contexts, GameEntity entity)
	{
		if (entity != null && ((Entity)entity).isEnabled)
		{
			entity.isDestroyed = true;
		}
	}
}
