using System.Collections.Generic;
using Entitas;

public sealed class DestroyProjectileSystem : ReactiveSystem<GameEntity>
{
	private readonly Contexts _contexts;

	private readonly IGroup<GameEntity> _particleGroup;

	private readonly List<GameEntity> _particleBuffer;

	public DestroyProjectileSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_contexts = contexts;
		_particleGroup = ((Context<GameEntity>)contexts.game).GetGroup(GameMatcher.Particle);
		_particleBuffer = new List<GameEntity>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return CollectorContextExtension.CreateCollector<GameEntity>(context, GameMatcher.Destroyable);
	}

	protected override bool Filter(GameEntity entity)
	{
		return !entity.isDestroyed && entity.isProjectile && entity.isDestroyable;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		_particleGroup.GetEntities(_particleBuffer);
		foreach (GameEntity entity in entities)
		{
			ProjectileLogic.Destroy(_contexts, entity, _particleBuffer);
		}
	}
}
