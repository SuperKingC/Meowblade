using System.Collections.Generic;
using Entitas;

public sealed class AnyStagingAreaSizeEventSystem : ReactiveSystem<ConfigEntity>
{
	private readonly IGroup<ConfigEntity> _listeners;

	private readonly List<ConfigEntity> _entityBuffer;

	private readonly List<IAnyStagingAreaSizeListener> _listenerBuffer;

	public AnyStagingAreaSizeEventSystem(Contexts contexts)
		: base((IContext<ConfigEntity>)(object)contexts.config)
	{
		base.init((IContext<ConfigEntity>)(object)contexts.config);
		_listeners = ((Context<ConfigEntity>)contexts.config).GetGroup(ConfigMatcher.AnyStagingAreaSizeListener);
		_entityBuffer = new List<ConfigEntity>();
		_listenerBuffer = new List<IAnyStagingAreaSizeListener>();
	}

	protected override ICollector<ConfigEntity> GetTrigger(IContext<ConfigEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<ConfigEntity>(context, new TriggerOnEvent<ConfigEntity>[1] { TriggerOnEventMatcherExtension.Added<ConfigEntity>(ConfigMatcher.StagingAreaSize) });
	}

	protected override bool Filter(ConfigEntity entity)
	{
		return entity.hasStagingAreaSize;
	}

	protected override void Execute(List<ConfigEntity> entities)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		foreach (ConfigEntity entity in entities)
		{
			StagingAreaSizeComponent stagingAreaSize = entity.stagingAreaSize;
			foreach (ConfigEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyStagingAreaSizeListener.value);
				foreach (IAnyStagingAreaSizeListener item in _listenerBuffer)
				{
					item.OnAnyStagingAreaSize(entity, stagingAreaSize.value);
				}
			}
		}
	}
}
