using System.Collections.Generic;
using Entitas;
using GameMaths;

public class UpdateProjectileTargetPositionFromTargetBoneSystem : BaseExecuteSystem
{
	private IGroup<GameEntity> _group;

	private List<GameEntity> _buffer;

	public UpdateProjectileTargetPositionFromTargetBoneSystem(Contexts contexts)
		: base(contexts)
	{
		_group = ((Context<GameEntity>)contexts.game).GetGroup((IMatcher<GameEntity>)(object)GameMatcher.AllOf(GameMatcher.Projectile, GameMatcher.TargetId, GameMatcher.LandingBone));
		_buffer = new List<GameEntity>();
	}

	public override void Execute()
	{
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		_group.GetEntities(_buffer);
		foreach (GameEntity item in _buffer)
		{
			GameEntity entity = _contexts.GetEntity(item.targetId.value);
			if (entity != null && entity.hasPosition)
			{
				if (!entity.hasSkeleton)
				{
					item.ReplaceTargetPosition(entity.position.value);
					continue;
				}
				Vector3 bonePosition = entity.skeleton.value.GetBonePosition(item.landingBone.value);
				item.ReplaceTargetPosition(bonePosition);
			}
		}
	}
}
