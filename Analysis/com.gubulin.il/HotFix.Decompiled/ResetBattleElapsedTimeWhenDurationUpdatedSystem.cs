using System.Collections.Generic;
using Entitas;

public class ResetBattleElapsedTimeWhenDurationUpdatedSystem : ReactiveSystem<GameStateEntity>
{
	private GameStateContext _context;

	public ResetBattleElapsedTimeWhenDurationUpdatedSystem(Contexts contexts)
		: base((IContext<GameStateEntity>)(object)contexts.gameState)
	{
		base.init((IContext<GameStateEntity>)(object)contexts.gameState);
		_context = contexts.gameState;
	}

	protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameStateEntity>(context, new TriggerOnEvent<GameStateEntity>[1] { TriggerOnEventMatcherExtension.Added<GameStateEntity>(GameStateMatcher.BattleDurationUpdated) });
	}

	protected override bool Filter(GameStateEntity entity)
	{
		return true;
	}

	protected override void Execute(List<GameStateEntity> entities)
	{
		_context.ReplaceBattleElapsedTime(0f);
		_context.ReplaceBattleTimeLeft(_context.battleDuration.value);
		_context.isBattleDurationUpdated = false;
	}
}
