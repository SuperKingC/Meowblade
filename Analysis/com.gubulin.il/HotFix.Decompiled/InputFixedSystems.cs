using Entitas;

public class InputFixedSystems : Feature
{
	public InputFixedSystems(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new UpdateTickSystem(contexts));
	}
}
