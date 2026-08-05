using System.Collections.Generic;
using Entitas;

public sealed class DestroyDestroyedTimerSystem : ICleanupSystem, ISystem
{
	private readonly IGroup<TimerEntity> _group;

	private readonly List<TimerEntity> _buffer = new List<TimerEntity>();

	public DestroyDestroyedTimerSystem(Contexts contexts)
	{
		_group = ((Context<TimerEntity>)contexts.timer).GetGroup(TimerMatcher.Destroyed);
	}

	public void Cleanup()
	{
		foreach (TimerEntity entity in _group.GetEntities(_buffer))
		{
			((Entity)entity).Destroy();
		}
	}
}
