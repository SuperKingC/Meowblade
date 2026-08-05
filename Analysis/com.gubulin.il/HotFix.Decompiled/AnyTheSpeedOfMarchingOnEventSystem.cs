using System.Collections.Generic;
using Entitas;

public sealed class AnyTheSpeedOfMarchingOnEventSystem : ReactiveSystem<ConfigEntity>
{
	private readonly IGroup<ConfigEntity> _listeners;

	private readonly List<ConfigEntity> _entityBuffer;

	private readonly List<IAnyTheSpeedOfMarchingOnListener> _listenerBuffer;

	public AnyTheSpeedOfMarchingOnEventSystem(Contexts contexts)
		: base((IContext<ConfigEntity>)(object)contexts.config)
	{
		base.init((IContext<ConfigEntity>)(object)contexts.config);
		_listeners = ((Context<ConfigEntity>)contexts.config).GetGroup(ConfigMatcher.AnyTheSpeedOfMarchingOnListener);
		_entityBuffer = new List<ConfigEntity>();
		_listenerBuffer = new List<IAnyTheSpeedOfMarchingOnListener>();
	}

	protected override ICollector<ConfigEntity> GetTrigger(IContext<ConfigEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<ConfigEntity>(context, new TriggerOnEvent<ConfigEntity>[1] { TriggerOnEventMatcherExtension.Added<ConfigEntity>(ConfigMatcher.TheSpeedOfMarchingOn) });
	}

	protected override bool Filter(ConfigEntity entity)
	{
		return entity.hasTheSpeedOfMarchingOn;
	}

	protected override void Execute(List<ConfigEntity> entities)
	{
		foreach (ConfigEntity entity in entities)
		{
			TheSpeedOfMarchingOnComponent theSpeedOfMarchingOn = entity.theSpeedOfMarchingOn;
			foreach (ConfigEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyTheSpeedOfMarchingOnListener.value);
				foreach (IAnyTheSpeedOfMarchingOnListener item in _listenerBuffer)
				{
					item.OnAnyTheSpeedOfMarchingOn(entity, theSpeedOfMarchingOn.value);
				}
			}
		}
	}
}
