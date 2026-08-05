using System.Collections.Generic;
using Entitas;

public sealed class AnyStartFightingDistanceEventSystem : ReactiveSystem<ConfigEntity>
{
	private readonly IGroup<ConfigEntity> _listeners;

	private readonly List<ConfigEntity> _entityBuffer;

	private readonly List<IAnyStartFightingDistanceListener> _listenerBuffer;

	public AnyStartFightingDistanceEventSystem(Contexts contexts)
		: base((IContext<ConfigEntity>)(object)contexts.config)
	{
		base.init((IContext<ConfigEntity>)(object)contexts.config);
		_listeners = ((Context<ConfigEntity>)contexts.config).GetGroup(ConfigMatcher.AnyStartFightingDistanceListener);
		_entityBuffer = new List<ConfigEntity>();
		_listenerBuffer = new List<IAnyStartFightingDistanceListener>();
	}

	protected override ICollector<ConfigEntity> GetTrigger(IContext<ConfigEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<ConfigEntity>(context, new TriggerOnEvent<ConfigEntity>[1] { TriggerOnEventMatcherExtension.Added<ConfigEntity>(ConfigMatcher.StartFightingDistance) });
	}

	protected override bool Filter(ConfigEntity entity)
	{
		return entity.hasStartFightingDistance;
	}

	protected override void Execute(List<ConfigEntity> entities)
	{
		foreach (ConfigEntity entity in entities)
		{
			StartFightingDistanceComponent startFightingDistance = entity.startFightingDistance;
			foreach (ConfigEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyStartFightingDistanceListener.value);
				foreach (IAnyStartFightingDistanceListener item in _listenerBuffer)
				{
					item.OnAnyStartFightingDistance(entity, startFightingDistance.value);
				}
			}
		}
	}
}
