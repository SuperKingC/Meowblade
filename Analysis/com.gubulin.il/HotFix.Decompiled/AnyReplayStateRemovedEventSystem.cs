using System.Collections.Generic;
using Entitas;

public sealed class AnyReplayStateRemovedEventSystem : ReactiveSystem<GameStateEntity>
{
	private readonly IGroup<GameStateEntity> _listeners;

	private readonly List<GameStateEntity> _entityBuffer;

	private readonly List<IAnyReplayStateRemovedListener> _listenerBuffer;

	public AnyReplayStateRemovedEventSystem(Contexts contexts)
		: base((IContext<GameStateEntity>)(object)contexts.gameState)
	{
		base.init((IContext<GameStateEntity>)(object)contexts.gameState);
		_listeners = ((Context<GameStateEntity>)contexts.gameState).GetGroup(GameStateMatcher.AnyReplayStateRemovedListener);
		_entityBuffer = new List<GameStateEntity>();
		_listenerBuffer = new List<IAnyReplayStateRemovedListener>();
	}

	protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameStateEntity>(context, new TriggerOnEvent<GameStateEntity>[1] { TriggerOnEventMatcherExtension.Removed<GameStateEntity>(GameStateMatcher.ReplayState) });
	}

	protected override bool Filter(GameStateEntity entity)
	{
		return !entity.hasReplayState;
	}

	protected override void Execute(List<GameStateEntity> entities)
	{
		foreach (GameStateEntity entity in entities)
		{
			foreach (GameStateEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyReplayStateRemovedListener.value);
				foreach (IAnyReplayStateRemovedListener item in _listenerBuffer)
				{
					item.OnAnyReplayStateRemoved(entity);
				}
			}
		}
	}
}
