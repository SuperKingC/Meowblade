using System.Collections.Generic;
using Entitas;

public sealed class AnyMouseScrollDeltaEventSystem : ReactiveSystem<InputEntity>
{
	private readonly IGroup<InputEntity> _listeners;

	private readonly List<InputEntity> _entityBuffer;

	private readonly List<IAnyMouseScrollDeltaListener> _listenerBuffer;

	public AnyMouseScrollDeltaEventSystem(Contexts contexts)
		: base((IContext<InputEntity>)(object)contexts.input)
	{
		base.init((IContext<InputEntity>)(object)contexts.input);
		_listeners = ((Context<InputEntity>)contexts.input).GetGroup(InputMatcher.AnyMouseScrollDeltaListener);
		_entityBuffer = new List<InputEntity>();
		_listenerBuffer = new List<IAnyMouseScrollDeltaListener>();
	}

	protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<InputEntity>(context, new TriggerOnEvent<InputEntity>[1] { TriggerOnEventMatcherExtension.Added<InputEntity>(InputMatcher.MouseScrollDelta) });
	}

	protected override bool Filter(InputEntity entity)
	{
		return entity.hasMouseScrollDelta;
	}

	protected override void Execute(List<InputEntity> entities)
	{
		foreach (InputEntity entity in entities)
		{
			MouseScrollDeltaComponent mouseScrollDelta = entity.mouseScrollDelta;
			foreach (InputEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyMouseScrollDeltaListener.value);
				foreach (IAnyMouseScrollDeltaListener item in _listenerBuffer)
				{
					item.OnAnyMouseScrollDelta(entity, mouseScrollDelta.value);
				}
			}
		}
	}
}
