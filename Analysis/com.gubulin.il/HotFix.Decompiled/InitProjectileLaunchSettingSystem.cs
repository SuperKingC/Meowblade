using System.Collections.Generic;
using Entitas;
using GameMaths;

public class InitProjectileLaunchSettingSystem : BaseExecuteSystem
{
	private IGroup<GameEntity> _group;

	private List<GameEntity> _buffer;

	public InitProjectileLaunchSettingSystem(Contexts contexts)
		: base(contexts)
	{
		_group = ((Context<GameEntity>)contexts.game).GetGroup((IMatcher<GameEntity>)(object)((IAnyOfMatcher<GameEntity>)(object)GameMatcher.AllOf(GameMatcher.Projectile, GameMatcher.LaunchBone, GameMatcher.SourceId)).NoneOf(new IMatcher<GameEntity>[1] { GameMatcher.Visible }));
		_buffer = new List<GameEntity>();
	}

	public override void Execute()
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		_group.GetEntities(_buffer);
		foreach (GameEntity item in _buffer)
		{
			GameEntity entity = _contexts.GetEntity(item.sourceId.value);
			if (entity != null && entity.hasSkeleton)
			{
				Vector3 bonePosition = entity.skeleton.value.GetBonePosition(item.launchBone.value);
				Quaternion boneRotation = entity.skeleton.value.GetBoneRotation(item.launchBone.value);
				item.ReplacePosition(bonePosition);
				item.ReplaceRotation(boneRotation);
				item.isVisible = true;
			}
		}
	}
}
