using GameMaths;

public interface IAnyCameraMoveLimitListener
{
	void OnAnyCameraMoveLimit(GameStateEntity entity, Vector3 position, Vector3 size);
}
