using System.Collections.Generic;
using Entitas;

public static class ContextsExtensions
{
	public static GameEntity GetEntityWithId(this GameContext context, int value)
	{
		return ((PrimaryEntityIndex<GameEntity, int>)(object)((Context<GameEntity>)context).GetEntityIndex("Id")).GetEntity(value);
	}

	public static TimerEntity GetEntityWithId(this TimerContext context, int value)
	{
		return ((PrimaryEntityIndex<TimerEntity, int>)(object)((Context<TimerEntity>)context).GetEntityIndex("Id")).GetEntity(value);
	}

	public static HashSet<GameEntity> GetEntitiesWithOwnerId(this GameContext context, int value)
	{
		return ((EntityIndex<GameEntity, int>)(object)((Context<GameEntity>)context).GetEntityIndex("OwnerId")).GetEntities(value);
	}
}
