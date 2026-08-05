using GameMaths;
using Shift.Legion.Common.Enums;

namespace Shift.Legion.Common.Services;

public interface IStagingService : IService
{
	Vector3 GetStagingAreaPosition(Team team, int portalId);

	Vector3 GetStagingAreaPosition_PortalIndex(Team team, int portalId);

	Vector2 GetStagingPoint(Team team, int portalIndex, float radius, int index, int total);
}
