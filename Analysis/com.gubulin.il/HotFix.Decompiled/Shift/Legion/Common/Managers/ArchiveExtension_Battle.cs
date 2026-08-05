namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_Battle
{
	private const string CurrentBattleIdKey = "CURRENT_BATTLE_ID";

	public static string GetCurrentBattleId(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<string>("CURRENT_BATTLE_ID");
	}

	public static void SetCurrentBattleId(this UserArchiveManager manager, string battleId)
	{
		manager.SetConfigValue("CURRENT_BATTLE_ID", battleId);
	}

	public static void RemoveCurrentBattleId(this UserArchiveManager manager)
	{
		manager.SetCurrentBattleId(string.Empty);
	}
}
