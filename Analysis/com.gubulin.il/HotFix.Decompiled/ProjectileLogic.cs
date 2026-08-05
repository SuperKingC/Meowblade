using System.Collections.Generic;

public static class ProjectileLogic
{
	public static void Destroy(Contexts contexts, GameEntity entity, List<GameEntity> allParticles)
	{
		if (entity == null)
		{
			return;
		}
		int value = entity.id.value;
		foreach (GameEntity allParticle in allParticles)
		{
			if (allParticle.hasOwnerId && allParticle.isParticleLiveWithOwner && allParticle.ownerId.value == value)
			{
				allParticle.isDestroyable = true;
			}
		}
		entity.isDestroyed = true;
	}
}
