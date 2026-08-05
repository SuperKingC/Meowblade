using System.Collections.Generic;
using Entitas;

public sealed class AnyPlayerEventSystem : ReactiveSystem<GameEntity>
{
	private readonly IGroup<GameEntity> _listeners;

	private readonly List<GameEntity> _entityBuffer;

	private readonly List<IAnyPlayerListener> _listenerBuffer;

	public AnyPlayerEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listeners = ((Context<GameEntity>)contexts.game).GetGroup(GameMatcher.AnyPlayerListener);
		_entityBuffer = new List<GameEntity>();
		_listenerBuffer = new List<IAnyPlayerListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.Player) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isPlayer;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			foreach (GameEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyPlayerListener.value);
				foreach (IAnyPlayerListener item in _listenerBuffer)
				{
					item.OnAnyPlayer(entity);
				}
			}
		}
	}
}
