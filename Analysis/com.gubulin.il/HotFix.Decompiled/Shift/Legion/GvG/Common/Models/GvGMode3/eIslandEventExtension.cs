namespace Shift.Legion.GvG.Common.Models.GvGMode3;

public static class eIslandEventExtension
{
	public static bool IsBattleRandomEvent(this eIslandEvent islandEvent)
	{
		return islandEvent == eIslandEvent.RandomEvent_Battle || islandEvent == eIslandEvent.RandomEvent_NPCEvent || islandEvent == eIslandEvent.RandomEvent_BossEvent;
	}
}
