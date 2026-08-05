using System.Collections.Generic;
using Entitas;
using GameMaths;
using Shift.Legion.Common.Services;

public class ParticleFullscreenMoveSystem : BaseExecuteSystem
{
	private readonly IGroup<GameEntity> _group;

	private readonly List<GameEntity> _buffer;

	public ParticleFullscreenMoveSystem(Contexts contexts)
		: base(contexts)
	{
		_group = ((Context<GameEntity>)contexts.game).GetGroup((IMatcher<GameEntity>)(object)GameMatcher.AllOf(GameMatcher.Particle, GameMatcher.ParticleFullscreenStartPosition));
		_buffer = new List<GameEntity>();
	}

	public override void Execute()
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		_group.GetEntities(_buffer);
		foreach (GameEntity item in _buffer)
		{
			if (item.isParticleFollowTarget)
			{
				float num = item.particleFullscreenMoveElapsedTime.value / item.particleFullscreenMoveDuration.value;
				item.particleFullscreenMoveElapsedTime.value += _contexts.input.fixedDeltaTime.value;
				Vector3 val = Vector3.Lerp(item.particleFullscreenStartPosition.value, item.particleFullscreenEndPosition.value, num);
				Vector3 val2 = _contexts.Service<ICameraService>().Position + val;
				item.ReplacePosition(new Vector3(val2.x, 1.1f, 0f));
			}
		}
	}
}
