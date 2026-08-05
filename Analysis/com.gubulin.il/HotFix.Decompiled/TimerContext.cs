using System;
using Entitas;

public sealed class TimerContext : Context<TimerEntity>
{
	public TimerContext()
		: base(12, 0, new ContextInfo("Timer", TimerComponentsLookup.componentNames, TimerComponentsLookup.componentTypes), (Func<IEntity, IAERC>)((IEntity entity) => (IAERC)new UnsafeAERC()), (Func<TimerEntity>)(() => new TimerEntity()))
	{
	}//IL_0013: Unknown result type (might be due to invalid IL or missing references)
	//IL_005b: Expected O, but got Unknown

}
