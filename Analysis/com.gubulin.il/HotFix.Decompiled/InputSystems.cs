using Entitas;

public class InputSystems : Feature
{
	public InputSystems(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new UpdateTimeSystem(contexts));
	}
}
