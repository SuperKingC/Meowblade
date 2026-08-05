using System.Collections.Generic;
using Entitas;

public sealed class VisibleEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IVisibleListener> _listenerBuffer;

	public VisibleEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IVisibleListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.Visible) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isVisible && entity.hasVisibleListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.visibleListener.value);
			foreach (IVisibleListener item in _listenerBuffer)
			{
				item.OnVisible(entity);
			}
		}
	}
}
