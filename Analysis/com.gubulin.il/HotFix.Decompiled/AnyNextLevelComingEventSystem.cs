using System.Collections.Generic;
using Entitas;

public sealed class AnyNextLevelComingEventSystem : ReactiveSystem<GameStateEntity>
{
	private readonly IGroup<GameStateEntity> _listeners;

	private readonly List<GameStateEntity> _entityBuffer;

	private readonly List<IAnyNextLevelComingListener> _listenerBuffer;

	public AnyNextLevelComingEventSystem(Contexts contexts)
		: base((IContext<GameStateEntity>)(object)contexts.gameState)
	{
		base.init((IContext<GameStateEntity>)(object)contexts.gameState);
		_listeners = ((Context<GameStateEntity>)contexts.gameState).GetGroup(GameStateMatcher.AnyNextLevelComingListener);
		_entityBuffer = new List<GameStateEntity>();
		_listenerBuffer = new List<IAnyNextLevelComingListener>();
	}

	protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameStateEntity>(context, new TriggerOnEvent<GameStateEntity>[1] { TriggerOnEventMatcherExtension.Added<GameStateEntity>(GameStateMatcher.NextLevelComing) });
	}

	protected override bool Filter(GameStateEntity entity)
	{
		return entity.isNextLevelComing;
	}

	protected override void Execute(List<GameStateEntity> entities)
	{
		foreach (GameStateEntity entity in entities)
		{
			foreach (GameStateEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyNextLevelComingListener.value);
				foreach (IAnyNextLevelComingListener item in _listenerBuffer)
				{
					item.OnAnyNextLevelComing(entity);
				}
			}
		}
	}
}
