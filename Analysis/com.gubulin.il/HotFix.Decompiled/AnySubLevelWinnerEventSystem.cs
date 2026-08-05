using System.Collections.Generic;
using Entitas;

public sealed class AnySubLevelWinnerEventSystem : ReactiveSystem<GameStateEntity>
{
	private readonly IGroup<GameStateEntity> _listeners;

	private readonly List<GameStateEntity> _entityBuffer;

	private readonly List<IAnySubLevelWinnerListener> _listenerBuffer;

	public AnySubLevelWinnerEventSystem(Contexts contexts)
		: base((IContext<GameStateEntity>)(object)contexts.gameState)
	{
		base.init((IContext<GameStateEntity>)(object)contexts.gameState);
		_listeners = ((Context<GameStateEntity>)contexts.gameState).GetGroup(GameStateMatcher.AnySubLevelWinnerListener);
		_entityBuffer = new List<GameStateEntity>();
		_listenerBuffer = new List<IAnySubLevelWinnerListener>();
	}

	protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameStateEntity>(context, new TriggerOnEvent<GameStateEntity>[1] { TriggerOnEventMatcherExtension.Added<GameStateEntity>(GameStateMatcher.SubLevelWinner) });
	}

	protected override bool Filter(GameStateEntity entity)
	{
		return entity.hasSubLevelWinner;
	}

	protected override void Execute(List<GameStateEntity> entities)
	{
		foreach (GameStateEntity entity in entities)
		{
			SubLevelWinnerComponent subLevelWinner = entity.subLevelWinner;
			foreach (GameStateEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anySubLevelWinnerListener.value);
				foreach (IAnySubLevelWinnerListener item in _listenerBuffer)
				{
					item.OnAnySubLevelWinner(entity, subLevelWinner.value);
				}
			}
		}
	}
}
