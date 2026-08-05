using System.Collections.Generic;
using Entitas;

public sealed class TimerDestroyedEventSystem : ReactiveSystem<TimerEntity>
{
	private readonly List<ITimerDestroyedListener> _listenerBuffer;

	public TimerDestroyedEventSystem(Contexts contexts)
		: base((IContext<TimerEntity>)(object)contexts.timer)
	{
		_listenerBuffer = new List<ITimerDestroyedListener>();
	}

	protected override ICollector<TimerEntity> GetTrigger(IContext<TimerEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<TimerEntity>(context, new TriggerOnEvent<TimerEntity>[1] { TriggerOnEventMatcherExtension.Added<TimerEntity>(TimerMatcher.Destroyed) });
	}

	protected override bool Filter(TimerEntity entity)
	{
		return entity.isDestroyed && entity.hasTimerDestroyedListener;
	}

	protected override void Execute(List<TimerEntity> entities)
	{
		foreach (TimerEntity entity in entities)
		{
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.timerDestroyedListener.value);
			foreach (ITimerDestroyedListener item in _listenerBuffer)
			{
				item.OnDestroyed(entity);
			}
		}
	}
}
