using GameMaths;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Services;

public interface ICreateUnitService : IService
{
	GameEntity CreateSoldier(int parentViewId, GameEntityData data, Team team, int portalId, int portalUnitIndex, int portalUnitTotal, float visionRadius);

	GameEntity CreateSoldier(int parentViewId, GameEntityData data, Team team, Vector3 position, float visionRadius);

	int CreateParticleAtTargetBone(int parentViewId, string particle, int sourceId, int targetId, int duration = -1, float scale = 1f, string bone = "", bool follow = true, bool autoSize = false, string audioFx = null, int audioVolume = 100, bool audioLoop = false);
}
