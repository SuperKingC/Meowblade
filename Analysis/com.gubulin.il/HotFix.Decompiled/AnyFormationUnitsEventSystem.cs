using System.Collections.Generic;
using Entitas;

public sealed class AnyFormationUnitsEventSystem : ReactiveSystem<ConfigEntity>
{
	private readonly IGroup<ConfigEntity> _listeners;

	private readonly List<ConfigEntity> _entityBuffer;

	private readonly List<IAnyFormationUnitsListener> _listenerBuffer;

	public AnyFormationUnitsEventSystem(Contexts contexts)
		: base((IContext<ConfigEntity>)(object)contexts.config)
	{
		base.init((IContext<ConfigEntity>)(object)contexts.config);
		_listeners = ((Context<ConfigEntity>)contexts.config).GetGroup(ConfigMatcher.AnyFormationUnitsListener);
		_entityBuffer = new List<ConfigEntity>();
		_listenerBuffer = new List<IAnyFormationUnitsListener>();
	}

	protected override ICollector<ConfigEntity> GetTrigger(IContext<ConfigEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<ConfigEntity>(context, new TriggerOnEvent<ConfigEntity>[1] { TriggerOnEventMatcherExtension.Added<ConfigEntity>(ConfigMatcher.FormationUnits) });
	}

	protected override bool Filter(ConfigEntity entity)
	{
		return entity.hasFormationUnits;
	}

	protected override void Execute(List<ConfigEntity> entities)
	{
		foreach (ConfigEntity entity in entities)
		{
			FormationUnitsComponent formationUnits = entity.formationUnits;
			foreach (ConfigEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyFormationUnitsListener.value);
				foreach (IAnyFormationUnitsListener item in _listenerBuffer)
				{
					item.OnAnyFormationUnits(entity, formationUnits.value);
				}
			}
		}
	}
}
