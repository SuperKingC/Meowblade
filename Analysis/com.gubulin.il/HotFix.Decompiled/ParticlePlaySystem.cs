using System.Collections.Generic;
using Entitas;
using Shift.Legion.Common.Enums;

public sealed class ParticlePlaySystem : ReactiveSystem<GameEntity>
{
	public ParticlePlaySystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.Particle) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasParticleState && entity.particleState.value == ParticleState.Init && entity.hasParticle;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			if (entity.hasPosition)
			{
				entity.particle.value.Play();
				entity.ReplaceParticleState(ParticleState.Play);
			}
		}
	}
}
