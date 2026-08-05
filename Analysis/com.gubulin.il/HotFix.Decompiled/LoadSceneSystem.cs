using System.Collections.Generic;
using Entitas;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Services;

public class LoadSceneSystem : ReactiveSystem<GameStateEntity>
{
	private readonly Contexts _contexts;

	public LoadSceneSystem(Contexts contexts)
		: base((IContext<GameStateEntity>)(object)contexts.gameState)
	{
		base.init((IContext<GameStateEntity>)(object)contexts.gameState);
		_contexts = contexts;
	}

	protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameStateEntity>(context, new TriggerOnEvent<GameStateEntity>[1] { TriggerOnEventMatcherExtension.Added<GameStateEntity>(GameStateMatcher.LoadingPanelStatus) });
	}

	protected override bool Filter(GameStateEntity entity)
	{
		return entity.loadingPanelStatus.value == LoadingPanelStatus.Showing;
	}

	protected override void Execute(List<GameStateEntity> entities)
	{
		_contexts.Service<BaseSceneService>().Load();
	}
}
