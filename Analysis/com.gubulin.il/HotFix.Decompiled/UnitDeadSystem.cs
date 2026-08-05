using System.Collections.Generic;
using Entitas;

public sealed class UnitDeadSystem : ReactiveSystem<GameEntity>
{
	public UnitDeadSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.Dead) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isDead && !entity.isDestroyed;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			entity.ReplaceDeadElapsedTick(0);
		}
	}
}
