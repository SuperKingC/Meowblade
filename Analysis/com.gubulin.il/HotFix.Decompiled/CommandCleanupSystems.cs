using Entitas;

public sealed class CommandCleanupSystems : Feature
{
	public CommandCleanupSystems(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new DestroyDestroyedCommandSystem(contexts));
	}
}
