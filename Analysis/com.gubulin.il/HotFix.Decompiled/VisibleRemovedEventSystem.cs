using System.Collections.Generic;
using Entitas;

public sealed class VisibleRemovedEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IVisibleRemovedListener> _listenerBuffer;

	public VisibleRemovedEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IVisibleRemovedListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Removed<GameEntity>(GameMatcher.Visible) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return !entity.isVisible && entity.hasVisibleRemovedListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.visibleRemovedListener.value);
			foreach (IVisibleRemovedListener item in _listenerBuffer)
			{
				item.OnVisibleRemoved(entity);
			}
		}
	}
}
