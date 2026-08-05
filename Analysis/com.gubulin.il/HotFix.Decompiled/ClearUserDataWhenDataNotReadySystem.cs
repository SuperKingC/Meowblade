using System.Collections.Generic;
using Entitas;

public class ClearUserDataWhenDataNotReadySystem : ReactiveSystem<GameStateEntity>
{
	private readonly GameStateContext _gameStateContext;

	private readonly ConfigContext _configContext;

	public ClearUserDataWhenDataNotReadySystem(Contexts contexts)
		: base((IContext<GameStateEntity>)(object)contexts.gameState)
	{
		base.init((IContext<GameStateEntity>)(object)contexts.gameState);
		_gameStateContext = contexts.gameState;
		_configContext = contexts.config;
	}

	protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameStateEntity>(context, new TriggerOnEvent<GameStateEntity>[1] { TriggerOnEventMatcherExtension.Removed<GameStateEntity>(GameStateMatcher.DataReady) });
	}

	protected override bool Filter(GameStateEntity entity)
	{
		return !_gameStateContext.isDataReady;
	}

	protected override void Execute(List<GameStateEntity> entities)
	{
		InitGameStateHelper.Init(_gameStateContext);
		InitConfigHelper.Init(_configContext);
	}
}
