using System.Collections.Generic;
using Entitas;

public sealed class AnySceneLoadedEventSystem : ReactiveSystem<GameEntity>
{
	private readonly IGroup<GameEntity> _listeners;

	private readonly List<GameEntity> _entityBuffer;

	private readonly List<IAnySceneLoadedListener> _listenerBuffer;

	public AnySceneLoadedEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listeners = ((Context<GameEntity>)contexts.game).GetGroup(GameMatcher.AnySceneLoadedListener);
		_entityBuffer = new List<GameEntity>();
		_listenerBuffer = new List<IAnySceneLoadedListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.SceneLoaded) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isSceneLoaded;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			foreach (GameEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anySceneLoadedListener.value);
				foreach (IAnySceneLoadedListener item in _listenerBuffer)
				{
					item.OnAnySceneLoaded(entity);
				}
			}
		}
	}
}
