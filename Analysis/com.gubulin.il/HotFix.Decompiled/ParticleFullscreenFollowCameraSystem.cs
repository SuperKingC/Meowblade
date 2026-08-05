using System.Collections.Generic;
using Entitas;
using GameMaths;
using Shift.Legion.Common.Services;

public class ParticleFullscreenFollowCameraSystem : BaseExecuteSystem
{
	private readonly IGroup<GameEntity> _group;

	private readonly List<GameEntity> _buffer;

	public ParticleFullscreenFollowCameraSystem(Contexts contexts)
		: base(contexts)
	{
		_group = ((Context<GameEntity>)contexts.game).GetGroup((IMatcher<GameEntity>)(object)GameMatcher.AllOf(GameMatcher.Particle, GameMatcher.ParticleFullscreen));
		_buffer = new List<GameEntity>();
	}

	public override void Execute()
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		_group.GetEntities(_buffer);
		foreach (GameEntity item in _buffer)
		{
			if ((item.isParticleFollowTarget || !item.hasPosition) && !item.hasParticleFullscreenStartPosition)
			{
				Vector3 position = _contexts.Service<ICameraService>().Position;
				item.ReplacePosition(new Vector3(position.x, 1.1f, 0f));
			}
		}
	}
}
