using System.Collections.Generic;
using Entitas;

public sealed class DestroyUnitSystem : ReactiveSystem<GameEntity>
{
	private readonly Contexts _contexts;

	public DestroyUnitSystem(Contexts contexts)
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
		return entity.isDestroyable && (entity.isUnit || entity.isBuildingUnit);
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			if (entity.hasSkeleton)
			{
				entity.RemoveSkeleton();
			}
			if (entity.hasAsset)
			{
				entity.RemoveAsset();
			}
			entity.isDestroyed = true;
		}
	}
}
