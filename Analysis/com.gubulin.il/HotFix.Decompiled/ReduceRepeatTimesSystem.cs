using System.Collections.Generic;
using Entitas;

public sealed class ReduceRepeatTimesSystem : IExecuteSystem, ISystem
{
	private readonly IGroup<TimerEntity> _group;

	private readonly List<TimerEntity> _buffer;

	public ReduceRepeatTimesSystem(Contexts contexts)
	{
		_group = ((Context<TimerEntity>)contexts.timer).GetGroup((IMatcher<TimerEntity>)(object)TimerMatcher.AllOf(TimerMatcher.Duration, TimerMatcher.ElapsedTime));
		_buffer = new List<TimerEntity>();
	}

	public void Execute()
	{
		_group.GetEntities(_buffer);
		foreach (TimerEntity item in _buffer)
		{
			if (item.elapsedTime.value >= item.duration.value)
			{
				item.elapsedTime.value = 0f;
				item.isReadyToTrigger = true;
				if (item.repeat.value > 0)
				{
					item.repeat.value--;
				}
			}
		}
	}
}
