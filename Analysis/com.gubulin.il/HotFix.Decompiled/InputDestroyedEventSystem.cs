using System.Collections.Generic;
using Entitas;

public sealed class InputDestroyedEventSystem : ReactiveSystem<InputEntity>
{
	private readonly List<IInputDestroyedListener> _listenerBuffer;

	public InputDestroyedEventSystem(Contexts contexts)
		: base((IContext<InputEntity>)(object)contexts.input)
	{
		base.init((IContext<InputEntity>)(object)contexts.input);
		_listenerBuffer = new List<IInputDestroyedListener>();
	}

	protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<InputEntity>(context, new TriggerOnEvent<InputEntity>[1] { TriggerOnEventMatcherExtension.Added<InputEntity>(InputMatcher.Destroyed) });
	}

	protected override bool Filter(InputEntity entity)
	{
		return entity.isDestroyed && entity.hasInputDestroyedListener;
	}

	protected override void Execute(List<InputEntity> entities)
	{
		foreach (InputEntity entity in entities)
		{
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.inputDestroyedListener.value);
			foreach (IInputDestroyedListener item in _listenerBuffer)
			{
				item.OnDestroyed(entity);
			}
		}
	}
}
