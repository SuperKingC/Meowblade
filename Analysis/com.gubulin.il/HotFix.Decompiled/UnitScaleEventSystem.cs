using System.Collections.Generic;
using Entitas;

public sealed class UnitScaleEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IUnitScaleListener> _listenerBuffer;

	public UnitScaleEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IUnitScaleListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.UnitScale) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasUnitScale && entity.hasUnitScaleListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			UnitScaleComponent unitScale = entity.unitScale;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.unitScaleListener.value);
			foreach (IUnitScaleListener item in _listenerBuffer)
			{
				item.OnUnitScale(entity, unitScale.value);
			}
		}
	}
}
