using System.Collections.Generic;
using Entitas;
using GameMaths;

public class ParticleFollowTargetBoneSystem : BaseExecuteSystem
{
	private readonly IGroup<GameEntity> _group;

	private readonly List<GameEntity> _buffer;

	private Dictionary<GameEntity, Vector3> _entity_LastVec3;

	public ParticleFollowTargetBoneSystem(Contexts contexts)
		: base(contexts)
	{
		_group = ((Context<GameEntity>)contexts.game).GetGroup((IMatcher<GameEntity>)(object)GameMatcher.AllOf(GameMatcher.Particle, GameMatcher.TargetId, GameMatcher.BoneName));
		_buffer = new List<GameEntity>();
		_entity_LastVec3 = new Dictionary<GameEntity, Vector3>();
	}

	public override void Execute()
	{
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		_group.GetEntities(_buffer);
		Vector3 val = default(Vector3);
		foreach (GameEntity item in _buffer)
		{
			if (!item.isParticleFollowTarget && item.hasPosition)
			{
				continue;
			}
			GameEntity entity = _contexts.GetEntity(item.targetId.value);
			if (entity == null || entity.isDead || !entity.hasSkeleton)
			{
				_entity_LastVec3.Remove(item);
				continue;
			}
			Vector3 bonePosition = entity.skeleton.value.GetBonePosition(item.boneName.value);
			((Vector3)(ref val))._002Ector(bonePosition.x, bonePosition.y + (item.isShadow ? 0f : entity.position.value.y), bonePosition.z);
			if (!_entity_LastVec3.TryGetValue(item, out var value))
			{
				_entity_LastVec3.Add(item, val);
			}
			else if (((Vector3)(ref value)).Equals(val))
			{
				continue;
			}
			item.ReplacePosition(val);
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
			if (item.isShadow)
			{
				item.isParticleFollowTarget = false;
				item.RemoveTargetId();
			}
		}
	}
}
