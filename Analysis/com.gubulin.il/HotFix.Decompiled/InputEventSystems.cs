using Entitas;

public sealed class InputEventSystems : Feature
{
	public InputEventSystems(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new InputDestroyedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyMouseScrollDeltaEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyZoomDeltaEventSystem(contexts));
	}
}
