using Entitas;

public sealed class TimerEventSystems : Feature
{
	public TimerEventSystems(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new TimerDestroyedEventSystem(contexts));
	}
}
