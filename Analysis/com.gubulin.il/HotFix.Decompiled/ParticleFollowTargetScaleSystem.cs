using System.Collections.Generic;
using Entitas;

public class ParticleFollowTargetScaleSystem : BaseExecuteSystem
{
	private readonly IGroup<GameEntity> _group;

	private readonly List<GameEntity> _buffer;

	private Dictionary<GameEntity, float> _entity_LastScale;

	private new Contexts _contexts;

	public ParticleFollowTargetScaleSystem(Contexts contexts)
		: base(contexts)
	{
		_group = ((Context<GameEntity>)contexts.game).GetGroup((IMatcher<GameEntity>)(object)GameMatcher.AllOf(GameMatcher.Particle, GameMatcher.TargetId, GameMatcher.ParticleFollowTargetScale));
		_buffer = new List<GameEntity>();
		_entity_LastScale = new Dictionary<GameEntity, float>();
		_contexts = contexts;
	}

	public override void Execute()
	{
		_group.GetEntities(_buffer);
		foreach (GameEntity item in _buffer)
		{
			if (!item.isParticleFollowTargetScale)
			{
				continue;
			}
			GameEntity entityWithId = _contexts.game.GetEntityWithId(item.targetId.value);
			if (entityWithId == null)
			{
				continue;
			}
			float num;
			if (item.isShadow)
			{
				if (!entityWithId.hasShadowScale)
				{
					continue;
				}
				num = item.particleBaseScale.value * entityWithId.shadowScale.value;
			}
			else
			{
				if (!entityWithId.hasUnitScale)
				{
					continue;
				}
				num = item.particleBaseScale.value * entityWithId.unitScale.value;
			}
			if (!_entity_LastScale.TryGetValue(item, out var value))
			{
				_entity_LastScale.Add(item, value);
			}
			else if (value == num)
			{
				continue;
			}
			if (item.scale.value != num)
			{
				item.ReplaceScale(num);
			}
			if (item.isShadow)
			{
				item.isParticleFollowTargetScale = false;
			}
		}
	}
}
