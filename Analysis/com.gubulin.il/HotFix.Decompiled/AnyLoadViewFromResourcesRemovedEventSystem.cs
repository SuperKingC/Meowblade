using System.Collections.Generic;
using Entitas;

public sealed class AnyLoadViewFromResourcesRemovedEventSystem : ReactiveSystem<ConfigEntity>
{
	private readonly IGroup<ConfigEntity> _listeners;

	private readonly List<ConfigEntity> _entityBuffer;

	private readonly List<IAnyLoadViewFromResourcesRemovedListener> _listenerBuffer;

	public AnyLoadViewFromResourcesRemovedEventSystem(Contexts contexts)
		: base((IContext<ConfigEntity>)(object)contexts.config)
	{
		base.init((IContext<ConfigEntity>)(object)contexts.config);
		_listeners = ((Context<ConfigEntity>)contexts.config).GetGroup(ConfigMatcher.AnyLoadViewFromResourcesRemovedListener);
		_entityBuffer = new List<ConfigEntity>();
		_listenerBuffer = new List<IAnyLoadViewFromResourcesRemovedListener>();
	}

	protected override ICollector<ConfigEntity> GetTrigger(IContext<ConfigEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<ConfigEntity>(context, new TriggerOnEvent<ConfigEntity>[1] { TriggerOnEventMatcherExtension.Removed<ConfigEntity>(ConfigMatcher.LoadViewFromResources) });
	}

	protected override bool Filter(ConfigEntity entity)
	{
		return !entity.isLoadViewFromResources;
	}

	protected override void Execute(List<ConfigEntity> entities)
	{
		foreach (ConfigEntity entity in entities)
		{
			foreach (ConfigEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyLoadViewFromResourcesRemovedListener.value);
				foreach (IAnyLoadViewFromResourcesRemovedListener item in _listenerBuffer)
				{
					item.OnAnyLoadViewFromResourcesRemoved(entity);
				}
			}
		}
	}
}
