using System.Collections.Generic;
using Entitas;
using Shift.Legion.Common.Helpers;

public class BattleFieldPositionLimitSystem : BaseExecuteSystem
{
	private IGroup<GameEntity> _group;

	private List<GameEntity> _buffer;

	public BattleFieldPositionLimitSystem(Contexts contexts)
		: base(contexts)
	{
		_group = ((Context<GameEntity>)contexts.game).GetGroup((IMatcher<GameEntity>)(object)GameMatcher.AllOf(GameMatcher.AiObject, GameMatcher.Position, GameMatcher.CollisionRadius));
		_buffer = new List<GameEntity>();
	}

	public override void Execute()
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		if (!_contexts.config.hasBattleConfig)
		{
			return;
		}
		_group.GetEntities(_buffer);
		float battleFieldLength = _contexts.config.battleConfig.BattleFieldLength;
		foreach (GameEntity item in _buffer)
		{
			if (BattleFieldLogic.LimitPosition(battleFieldLength, ref item.position.value, item.collisionRadius.value, item.battleFieldXMargin.value))
			{
				item.ReplacePosition(item.position.value);
			}
		}
	}
}
