using System.Collections.Generic;
using Entitas;

public sealed class AnyReplayStateEventSystem : ReactiveSystem<GameStateEntity>
{
	private readonly IGroup<GameStateEntity> _listeners;

	private readonly List<GameStateEntity> _entityBuffer;

	private readonly List<IAnyReplayStateListener> _listenerBuffer;

	public AnyReplayStateEventSystem(Contexts contexts)
		: base((IContext<GameStateEntity>)(object)contexts.gameState)
	{
		base.init((IContext<GameStateEntity>)(object)contexts.gameState);
		_listeners = ((Context<GameStateEntity>)contexts.gameState).GetGroup(GameStateMatcher.AnyReplayStateListener);
		_entityBuffer = new List<GameStateEntity>();
		_listenerBuffer = new List<IAnyReplayStateListener>();
	}

	protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameStateEntity>(context, new TriggerOnEvent<GameStateEntity>[1] { TriggerOnEventMatcherExtension.Added<GameStateEntity>(GameStateMatcher.ReplayState) });
	}

	protected override bool Filter(GameStateEntity entity)
	{
		return entity.hasReplayState;
	}

	protected override void Execute(List<GameStateEntity> entities)
	{
		foreach (GameStateEntity entity in entities)
		{
			ReplayStateComponent replayState = entity.replayState;
			foreach (GameStateEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyReplayStateListener.value);
				foreach (IAnyReplayStateListener item in _listenerBuffer)
				{
					item.OnAnyReplayState(entity, replayState.value);
				}
			}
		}
	}
}
