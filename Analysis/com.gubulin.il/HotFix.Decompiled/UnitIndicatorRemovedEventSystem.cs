using System.Collections.Generic;
using Entitas;

public sealed class UnitIndicatorRemovedEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IUnitIndicatorRemovedListener> _listenerBuffer;

	public UnitIndicatorRemovedEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IUnitIndicatorRemovedListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Removed<GameEntity>(GameMatcher.UnitIndicator) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return !entity.hasUnitIndicator && entity.hasUnitIndicatorRemovedListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.unitIndicatorRemovedListener.value);
			foreach (IUnitIndicatorRemovedListener item in _listenerBuffer)
			{
				item.OnUnitIndicatorRemoved(entity);
			}
		}
	}
}
