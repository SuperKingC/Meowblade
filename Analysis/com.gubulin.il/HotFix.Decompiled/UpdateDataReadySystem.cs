using System.Collections.Generic;
using Entitas;

public sealed class UpdateDataReadySystem : ReactiveSystem<GameStateEntity>
{
	private readonly GameStateContext _context;

	public UpdateDataReadySystem(Contexts contexts)
		: base((IContext<GameStateEntity>)(object)contexts.gameState)
	{
		base.init((IContext<GameStateEntity>)(object)contexts.gameState);
		_context = contexts.gameState;
	}

	protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameStateEntity>(context, new TriggerOnEvent<GameStateEntity>[2]
		{
			TriggerOnEventMatcherExtension.Removed<GameStateEntity>(GameStateMatcher.GameDataLoaded),
			TriggerOnEventMatcherExtension.Removed<GameStateEntity>(GameStateMatcher.UserDataLoaded)
		});
	}

	protected override bool Filter(GameStateEntity entity)
	{
		return !_context.isGameDataLoaded || !_context.isUserDataLoaded;
	}

	protected override void Execute(List<GameStateEntity> entities)
	{
		_context.isDataReady = false;
	}
}
