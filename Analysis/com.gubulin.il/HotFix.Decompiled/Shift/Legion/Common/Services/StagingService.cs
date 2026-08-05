using GameMaths;
using Shift.Legion.Common.Enums;

namespace Shift.Legion.Common.Services;

public class StagingService : Service, IStagingService, IService
{
	private const float OffsetY = 0f;

	private readonly Vector2[] _sizeBuffer;

	private readonly Vector3[] _positionBuffer;

	public StagingService(Contexts contexts)
		: base(contexts)
	{
		_sizeBuffer = (Vector2[])(object)new Vector2[12];
		_positionBuffer = (Vector3[])(object)new Vector3[12];
	}

	private string GetTeamFormation(Team team)
	{
		int num = 0;
		if (base.Contexts.gameState.hasBattleFieldSubLevelIndex)
		{
			num = base.Contexts.gameState.battleFieldSubLevelIndex.value;
		}
		if (team == Team.Red)
		{
			return base.Contexts.config.battleConfig.Red.FormationId[num];
		}
		return base.Contexts.config.battleConfig.Blue.FormationId[num];
	}

	public void SetStagingArea(Team team, Vector3[] positions, Vector2[] sizes)
	{
	}

	private Vector2 GetStagingAreaSize(Team team, int portalIndex)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		Vector2[] stagingAreaSizesForTeam = ClientBattleFieldLogic.GetStagingAreaSizesForTeam(team, GetTeamFormation(team), _sizeBuffer);
		return stagingAreaSizesForTeam[portalIndex];
	}

	private Vector2 GetStagingAreaSize_PortalIndex(Team team, int portalIndex)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		return ClientBattleFieldLogic.GetStagingAreaSizesForTeam_ByIndex(team, GetTeamFormation(team), portalIndex, _sizeBuffer);
	}

	public Vector3 GetStagingAreaPosition(Team team, int portalIndex)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		Vector3[] stagingAreaPositionsForTeam = ClientBattleFieldLogic.GetStagingAreaPositionsForTeam(team, base.Contexts.config.battleConfig.BattleFieldLength, GetTeamFormation(team), base.Contexts.config.stagingAreaOffset.value, _positionBuffer);
		return stagingAreaPositionsForTeam[portalIndex];
	}

	public Vector3 GetStagingAreaPosition_PortalIndex(Team team, int portalIndex)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		return ClientBattleFieldLogic.GetStagingAreaPositionsForTeam_ByIndex(team, portalIndex, base.Contexts.config.battleConfig.BattleFieldLength, GetTeamFormation(team), base.Contexts.config.stagingAreaOffset.value);
	}

	public Vector2 GetStagingPoint(Team team, int portalIndex, float radius, int index, int total)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		if (portalIndex == -1)
		{
			Vector3 campPosition = ClientBattleFieldLogic.GetCampPosition(team, base.Contexts.config.battleConfig.BattleFieldLength);
			return new Vector2(campPosition.x, campPosition.z + 0f);
		}
		Vector2 stagingAreaSize_PortalIndex = GetStagingAreaSize_PortalIndex(team, portalIndex);
		Vector3 stagingAreaPosition_PortalIndex = GetStagingAreaPosition_PortalIndex(team, portalIndex);
		if (stagingAreaSize_PortalIndex == Vector2.zero)
		{
			return Vector2.zero;
		}
		int num = Mathf.FloorToInt(stagingAreaSize_PortalIndex.x / (2f * radius));
		int num2 = Mathf.FloorToInt(stagingAreaSize_PortalIndex.y / (2f * radius));
		int num3 = index % num2;
		int num4 = index / num2;
		int num5 = total / num2 + ((total % num2 != 0) ? 1 : 0);
		int num6 = ((num4 != num5 - 1) ? num2 : ((total % num2 == 0) ? num2 : (total % num2)));
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(radius + (float)num4 * 2f * radius, radius + (float)num3 * 2f * radius);
		float num7 = stagingAreaSize_PortalIndex.x / 2f - (float)num5 * radius;
		float num8 = stagingAreaSize_PortalIndex.y / 2f - (float)num6 * radius + 0f;
		return new Vector2(stagingAreaPosition_PortalIndex.x + (float)((team == Team.Red) ? 1 : (-1)) * (stagingAreaSize_PortalIndex.x / 2f - val.x - num7), stagingAreaPosition_PortalIndex.z + val.y + num8 - stagingAreaSize_PortalIndex.y / 2f - (float)index / 1000f);
	}
}
