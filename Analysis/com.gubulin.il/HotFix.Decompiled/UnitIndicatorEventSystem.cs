using System.Collections.Generic;
using Entitas;

public sealed class UnitIndicatorEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IUnitIndicatorListener> _listenerBuffer;

	public UnitIndicatorEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IUnitIndicatorListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.UnitIndicator) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasUnitIndicator && entity.hasUnitIndicatorListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		foreach (GameEntity entity in entities)
		{
			UnitIndicatorComponent unitIndicator = entity.unitIndicator;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.unitIndicatorListener.value);
			foreach (IUnitIndicatorListener item in _listenerBuffer)
			{
				item.OnUnitIndicator(entity, unitIndicator.value);
			}
		}
	}
}
