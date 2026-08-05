using GameMaths;

public interface ICamera : IAnyCameraPositionListener, IAnyCameraActiveListener, IAnyCameraRotationListener, IAnyCameraSizeListener
{
	void Initialize(Contexts contexts, GameEntity entity);

	Vector3 WorldToScreenPoint(Vector3 position);
}
