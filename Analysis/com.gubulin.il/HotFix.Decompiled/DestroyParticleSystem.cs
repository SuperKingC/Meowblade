using System.Collections.Generic;
using Entitas;

public sealed class DestroyParticleSystem : ReactiveSystem<GameEntity>
{
	private readonly Contexts _contexts;

	public DestroyParticleSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return CollectorContextExtension.CreateCollector<GameEntity>(context, GameMatcher.Destroyable);
	}

	protected override bool Filter(GameEntity entity)
	{
		return !entity.isDestroyed && entity.hasParticle && entity.isDestroyable;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			ParticleLogic.Destroy(_contexts, entity);
		}
	}
}
