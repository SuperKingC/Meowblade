using GameMaths;

public interface ISkeleton
{
	void Initialize(Contexts contexts, GameEntity entity);

	Vector3 GetBonePosition(string boneName);

	Quaternion GetBoneRotation(string boneName);
}
