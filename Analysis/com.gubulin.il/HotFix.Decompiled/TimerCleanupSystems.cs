using Entitas;

public sealed class TimerCleanupSystems : Feature
{
	public TimerCleanupSystems(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new DestroyDestroyedTimerSystem(contexts));
	}
}
