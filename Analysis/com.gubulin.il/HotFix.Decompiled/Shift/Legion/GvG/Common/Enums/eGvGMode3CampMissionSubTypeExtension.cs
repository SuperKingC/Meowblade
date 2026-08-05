namespace Shift.Legion.GvG.Common.Enums;

public static class eGvGMode3CampMissionSubTypeExtension
{
	public static bool HasRandomEventReward(this eGvGMode3CampMissionSubType subType)
	{
		return subType == eGvGMode3CampMissionSubType.RE_Battle || subType == eGvGMode3CampMissionSubType.RE_NPCEvent || subType == eGvGMode3CampMissionSubType.RE_BossEvent;
	}
}
