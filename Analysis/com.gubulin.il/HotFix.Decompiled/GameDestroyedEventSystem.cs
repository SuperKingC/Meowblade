using System.Collections.Generic;
using Entitas;

public sealed class GameDestroyedEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IGameDestroyedListener> _listenerBuffer;

	public GameDestroyedEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IGameDestroyedListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.Destroyed) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isDestroyed && entity.hasGameDestroyedListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.gameDestroyedListener.value);
			foreach (IGameDestroyedListener item in _listenerBuffer)
			{
				item.OnDestroyed(entity);
			}
		}
	}
}
