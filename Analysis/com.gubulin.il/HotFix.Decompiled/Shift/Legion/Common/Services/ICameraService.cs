using GameMaths;

namespace Shift.Legion.Common.Services;

public interface ICameraService : IService, IAnyBattleStartedListener, IAnyBattleStartedRemovedListener, IAnyFreeBattleModeListener
{
	Vector3 Position { get; set; }

	Quaternion Rotation { get; set; }

	float Size { get; set; }

	float Aspect { get; set; }

	float ScreenWidth { get; }

	float ScreenHeight { get; }

	float ScreenRatio { get; }

	void SwitchToScene(string scene);

	void SetPosition(Vector3 position, bool animated = false, float duration = 0f);

	void SetRotation(Quaternion rotation, bool animated = false, float duration = 0f);

	void SetSize(float size, bool animated = false, float duration = 0f);

	Vector3 GetCameraPositionForScene(string scene);

	Vector3 WorldToScreenPoint(Vector3 position);
}
