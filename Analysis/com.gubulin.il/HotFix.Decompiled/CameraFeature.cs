using Entitas;

public class CameraFeature : Feature
{
	public CameraFeature(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new CameraFollowUnitSystem(contexts));
		((Systems)this).Add((ISystem)(object)new CameraMoveToPositionSystem(contexts));
	}
}
