using System;
using System.Collections.Generic;
using Entitas;

public sealed class CallTimerCallbackActionSystem : IExecuteSystem, ISystem
{
	private readonly IGroup<TimerEntity> _group;

	private readonly List<TimerEntity> _buffer;

	public CallTimerCallbackActionSystem(Contexts contexts)
	{
		_group = ((Context<TimerEntity>)contexts.timer).GetGroup((IMatcher<TimerEntity>)(object)TimerMatcher.AllOf(TimerMatcher.ReadyToTrigger));
		_buffer = new List<TimerEntity>();
	}

	public void Execute()
	{
		_group.GetEntities(_buffer);
		foreach (TimerEntity item in _buffer)
		{
			if (item.hasCallbackAction)
			{
				try
				{
					item.callbackAction.value();
				}
				catch (Exception e)
				{
					ILRuntimeDebug.Exeption(e);
				}
			}
		}
	}
}
