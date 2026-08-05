using System.Collections.Generic;
using Entitas;
using Shift.Legion.Common.Services;

public sealed class AddShadowOnUnitCreatedSystem : ReactiveSystem<GameEntity>
{
	private readonly Contexts _contexts;

	public AddShadowOnUnitCreatedSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.Unit) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isUnit && entity.hasTags;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			if (!entity.tags.value.Contains("障碍物"))
			{
				int value = _contexts.Service<ICreateUnitService>().CreateParticleAtTargetBone(-1, entity.tags.value.Contains("IS_BOSS") ? "FX/Prefabs/shadow_boss" : "FX/Prefabs/shadow_normal", entity.id.value, entity.id.value, -1, 1f, "floor", follow: true, autoSize: true);
				GameEntity entityWithId = _contexts.game.GetEntityWithId(value);
				if (entityWithId != null)
				{
					entityWithId.isShadow = true;
				}
			}
		}
	}
}
