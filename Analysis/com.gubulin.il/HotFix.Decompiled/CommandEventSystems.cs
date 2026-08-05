using Entitas;

public sealed class CommandEventSystems : Feature
{
	public CommandEventSystems(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new CommandDestroyedEventSystem(contexts));
	}
}
