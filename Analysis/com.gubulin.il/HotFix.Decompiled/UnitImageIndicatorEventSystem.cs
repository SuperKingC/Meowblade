using System.Collections.Generic;
using Entitas;

public sealed class UnitImageIndicatorEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IUnitImageIndicatorListener> _listenerBuffer;

	public UnitImageIndicatorEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IUnitImageIndicatorListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.UnitImageIndicator) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasUnitImageIndicator && entity.hasUnitImageIndicatorListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			UnitImageIndicatorComponent unitImageIndicator = entity.unitImageIndicator;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.unitImageIndicatorListener.value);
			foreach (IUnitImageIndicatorListener item in _listenerBuffer)
			{
				item.OnUnitImageIndicator(entity, unitImageIndicator.value);
			}
		}
	}
}
