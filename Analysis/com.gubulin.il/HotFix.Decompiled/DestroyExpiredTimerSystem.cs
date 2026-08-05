using System.Collections.Generic;
using Entitas;

public sealed class DestroyExpiredTimerSystem : IExecuteSystem, ISystem
{
	private readonly IGroup<TimerEntity> _group;

	private readonly List<TimerEntity> _buffer;

	public DestroyExpiredTimerSystem(Contexts contexts)
	{
		_group = ((Context<TimerEntity>)contexts.timer).GetGroup((IMatcher<TimerEntity>)(object)TimerMatcher.AllOf(TimerMatcher.Duration, TimerMatcher.ElapsedTime));
		_buffer = new List<TimerEntity>();
	}

	public void Execute()
	{
		_group.GetEntities(_buffer);
		foreach (TimerEntity item in _buffer)
		{
			if (item.repeat.value == 0)
			{
				if (item.hasCallbackAction)
				{
					item.RemoveCallbackAction();
				}
				item.isDestroyed = true;
			}
		}
	}
}
