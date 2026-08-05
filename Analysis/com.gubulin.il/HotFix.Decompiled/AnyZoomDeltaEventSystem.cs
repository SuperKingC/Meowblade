using System.Collections.Generic;
using Entitas;

public sealed class AnyZoomDeltaEventSystem : ReactiveSystem<InputEntity>
{
	private readonly IGroup<InputEntity> _listeners;

	private readonly List<InputEntity> _entityBuffer;

	private readonly List<IAnyZoomDeltaListener> _listenerBuffer;

	public AnyZoomDeltaEventSystem(Contexts contexts)
		: base((IContext<InputEntity>)(object)contexts.input)
	{
		base.init((IContext<InputEntity>)(object)contexts.input);
		_listeners = ((Context<InputEntity>)contexts.input).GetGroup(InputMatcher.AnyZoomDeltaListener);
		_entityBuffer = new List<InputEntity>();
		_listenerBuffer = new List<IAnyZoomDeltaListener>();
	}

	protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<InputEntity>(context, new TriggerOnEvent<InputEntity>[1] { TriggerOnEventMatcherExtension.Added<InputEntity>(InputMatcher.ZoomDelta) });
	}

	protected override bool Filter(InputEntity entity)
	{
		return entity.hasZoomDelta;
	}

	protected override void Execute(List<InputEntity> entities)
	{
		foreach (InputEntity entity in entities)
		{
			ZoomDeltaComponent zoomDelta = entity.zoomDelta;
			foreach (InputEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyZoomDeltaListener.value);
				foreach (IAnyZoomDeltaListener item in _listenerBuffer)
				{
					item.OnAnyZoomDelta(entity, zoomDelta.value);
				}
			}
		}
	}
}
