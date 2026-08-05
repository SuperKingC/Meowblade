using System.Collections.Generic;
using Entitas;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Services;

public class HideNextLevelComingSystem : BaseExecuteSystem
{
	private List<GameEntity> _buffer;

	public HideNextLevelComingSystem(Contexts contexts)
		: base(contexts)
	{
		_buffer = new List<GameEntity>();
	}

	public override void Execute()
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		if (!_contexts.gameState.isNextLevelComing || _contexts.Service<ICameraService>() == null)
		{
			return;
		}
		float size = _contexts.Service<ICameraService>().Size;
		float aspect = _contexts.Service<ICameraService>().Aspect;
		float num = _contexts.Service<ICameraService>().ScreenRatio / 1.7777778f;
		float num2 = ((num > 1f) ? (size * aspect * num) : (size * aspect)) / 2f;
		float num3 = _contexts.Service<ICameraService>().Position.x - num2;
		float num4 = _contexts.Service<ICameraService>().Position.x + num2;
		IGroup<GameEntity> groupOfReplayContexts = _contexts.Service<ReplayPlayerService>().GetGroupOfReplayContexts(GameMatcher.GameObject);
		groupOfReplayContexts.GetEntities(_buffer);
		foreach (GameEntity item in _buffer)
		{
			if (!item.hasTeam || !item.hasPosition || item.isDead || item.team.value != Team.Blue || !(item.position.value.x > num3) || !(item.position.value.x < num4))
			{
				continue;
			}
			_contexts.gameState.isNextLevelComing = false;
			break;
		}
	}
}
