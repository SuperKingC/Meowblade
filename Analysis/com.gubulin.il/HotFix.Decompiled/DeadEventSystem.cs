using System.Collections.Generic;
using Entitas;

public sealed class DeadEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IDeadListener> _listenerBuffer;

	public DeadEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IDeadListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.Dead) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isDead && entity.hasDeadListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.deadListener.value);
			foreach (IDeadListener item in _listenerBuffer)
			{
				item.OnDead(entity);
			}
		}
	}
}
