using System.Collections.Generic;
using Entitas;

public sealed class AnyWinnerEventSystem : ReactiveSystem<GameStateEntity>
{
	private readonly IGroup<GameStateEntity> _listeners;

	private readonly List<GameStateEntity> _entityBuffer;

	private readonly List<IAnyWinnerListener> _listenerBuffer;

	public AnyWinnerEventSystem(Contexts contexts)
		: base((IContext<GameStateEntity>)(object)contexts.gameState)
	{
		base.init((IContext<GameStateEntity>)(object)contexts.gameState);
		_listeners = ((Context<GameStateEntity>)contexts.gameState).GetGroup(GameStateMatcher.AnyWinnerListener);
		_entityBuffer = new List<GameStateEntity>();
		_listenerBuffer = new List<IAnyWinnerListener>();
	}

	protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameStateEntity>(context, new TriggerOnEvent<GameStateEntity>[1] { TriggerOnEventMatcherExtension.Added<GameStateEntity>(GameStateMatcher.Winner) });
	}

	protected override bool Filter(GameStateEntity entity)
	{
		return entity.hasWinner;
	}

	protected override void Execute(List<GameStateEntity> entities)
	{
		foreach (GameStateEntity entity in entities)
		{
			WinnerComponent winner = entity.winner;
			foreach (GameStateEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyWinnerListener.value);
				foreach (IAnyWinnerListener item in _listenerBuffer)
				{
					item.OnAnyWinner(entity, winner.value);
				}
			}
		}
	}
}
