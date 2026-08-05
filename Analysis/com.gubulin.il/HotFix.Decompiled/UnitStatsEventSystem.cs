using System.Collections.Generic;
using Entitas;

public sealed class UnitStatsEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IUnitStatsListener> _listenerBuffer;

	public UnitStatsEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IUnitStatsListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.UnitStats) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasUnitStats && entity.hasUnitStatsListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			UnitStatsComponent unitStats = entity.unitStats;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.unitStatsListener.value);
			foreach (IUnitStatsListener item in _listenerBuffer)
			{
				item.OnUnitStats(entity, unitStats.value);
			}
		}
	}
}
