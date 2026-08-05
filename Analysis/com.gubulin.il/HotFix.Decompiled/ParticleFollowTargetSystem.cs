using System.Collections.Generic;
using Entitas;
using GameMaths;

public class ParticleFollowTargetSystem : BaseExecuteSystem
{
	private readonly IGroup<GameEntity> _group;

	private readonly List<GameEntity> _buffer;

	public ParticleFollowTargetSystem(Contexts contexts)
		: base(contexts)
	{
		_group = ((Context<GameEntity>)contexts.game).GetGroup((IMatcher<GameEntity>)(object)((IAnyOfMatcher<GameEntity>)(object)GameMatcher.AllOf(GameMatcher.Particle, GameMatcher.TargetId)).NoneOf(new IMatcher<GameEntity>[1] { GameMatcher.BoneName }));
		_buffer = new List<GameEntity>();
	}

	public override void Execute()
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		List<GameEntity> entities = _group.GetEntities(_buffer);
		foreach (GameEntity item in entities)
		{
			if (!item.isParticleFollowTarget && item.hasPosition)
			{
				continue;
			}
			GameEntity entity = _contexts.GetEntity(item.targetId.value);
			if (entity == null || !entity.hasPosition)
			{
				continue;
			}
			Vector3 value = entity.position.value;
			if (entity.hasCharacter)
			{
				item.ReplacePosition(new Vector3(value.x, value.y + 0.7f, value.z));
			}
			else
			{
				item.ReplacePosition(value);
			}
			if (entity.hasRotation)
			{
				Quaternion value2 = entity.rotation.value;
				if (value2 == RotationHelper.Left)
				{
					item.ReplaceRotation(RotationHelper.Right);
				}
				else
				{
					item.ReplaceRotation(RotationHelper.FlipLeft);
				}
			}
		}
	}
}
