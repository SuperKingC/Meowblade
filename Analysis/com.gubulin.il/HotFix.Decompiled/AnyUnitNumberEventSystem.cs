using System.Collections.Generic;
using Entitas;

public sealed class AnyUnitNumberEventSystem : ReactiveSystem<ConfigEntity>
{
	private readonly IGroup<ConfigEntity> _listeners;

	private readonly List<ConfigEntity> _entityBuffer;

	private readonly List<IAnyUnitNumberListener> _listenerBuffer;

	public AnyUnitNumberEventSystem(Contexts contexts)
		: base((IContext<ConfigEntity>)(object)contexts.config)
	{
		base.init((IContext<ConfigEntity>)(object)contexts.config);
		_listeners = ((Context<ConfigEntity>)contexts.config).GetGroup(ConfigMatcher.AnyUnitNumberListener);
		_entityBuffer = new List<ConfigEntity>();
		_listenerBuffer = new List<IAnyUnitNumberListener>();
	}

	protected override ICollector<ConfigEntity> GetTrigger(IContext<ConfigEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<ConfigEntity>(context, new TriggerOnEvent<ConfigEntity>[1] { TriggerOnEventMatcherExtension.Added<ConfigEntity>(ConfigMatcher.UnitNumber) });
	}

	protected override bool Filter(ConfigEntity entity)
	{
		return entity.hasUnitNumber;
	}

	protected override void Execute(List<ConfigEntity> entities)
	{
		foreach (ConfigEntity entity in entities)
		{
			UnitNumberComponent unitNumber = entity.unitNumber;
			foreach (ConfigEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyUnitNumberListener.value);
				foreach (IAnyUnitNumberListener item in _listenerBuffer)
				{
					item.OnAnyUnitNumber(entity, unitNumber.value);
				}
			}
		}
	}
}
