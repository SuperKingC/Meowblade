using Entitas;

public class TimerFeature : Feature
{
	public TimerFeature(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new ReduceRepeatTimesSystem(contexts));
		((Systems)this).Add((ISystem)(object)new CallTimerCallbackActionSystem(contexts));
		((Systems)this).Add((ISystem)(object)new DestroyExpiredTimerSystem(contexts));
	}
}
