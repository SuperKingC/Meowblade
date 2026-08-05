using System.Collections.Generic;
using Entitas;

public sealed class AnyOfflineSecondsEventSystem : ReactiveSystem<GameStateEntity>
{
	private readonly IGroup<GameStateEntity> _listeners;

	private readonly List<GameStateEntity> _entityBuffer;

	private readonly List<IAnyOfflineSecondsListener> _listenerBuffer;

	public AnyOfflineSecondsEventSystem(Contexts contexts)
		: base((IContext<GameStateEntity>)(object)contexts.gameState)
	{
		base.init((IContext<GameStateEntity>)(object)contexts.gameState);
		_listeners = ((Context<GameStateEntity>)contexts.gameState).GetGroup(GameStateMatcher.AnyOfflineSecondsListener);
		_entityBuffer = new List<GameStateEntity>();
		_listenerBuffer = new List<IAnyOfflineSecondsListener>();
	}

	protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameStateEntity>(context, new TriggerOnEvent<GameStateEntity>[1] { TriggerOnEventMatcherExtension.Added<GameStateEntity>(GameStateMatcher.OfflineSeconds) });
	}

	protected override bool Filter(GameStateEntity entity)
	{
		return entity.hasOfflineSeconds;
	}

	protected override void Execute(List<GameStateEntity> entities)
	{
		foreach (GameStateEntity entity in entities)
		{
			OfflineSecondsComponent offlineSeconds = entity.offlineSeconds;
			foreach (GameStateEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyOfflineSecondsListener.value);
				foreach (IAnyOfflineSecondsListener item in _listenerBuffer)
				{
					item.OnAnyOfflineSeconds(entity, offlineSeconds.value);
				}
			}
		}
	}
}
