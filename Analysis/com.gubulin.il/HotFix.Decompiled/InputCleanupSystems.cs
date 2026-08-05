using Entitas;

public sealed class InputCleanupSystems : Feature
{
	public InputCleanupSystems(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new DestroyDestroyedInputSystem(contexts));
	}
}
