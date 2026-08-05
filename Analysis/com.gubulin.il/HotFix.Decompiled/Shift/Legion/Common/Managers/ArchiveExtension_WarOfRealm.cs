using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_WarOfRealm
{
	public const string WarOfRealmFormationKey = "WarOfRealmFormation";

	public const string WarOfRealmFormationSavedKey = "WarOfRealmFormationSaved";

	public static void SetWarOfRealmFormation(this UserArchiveManager manager, WarOfRealmConfig config)
	{
		manager.SetConfigValue("WarOfRealmFormation", config);
	}

	public static WarOfRealmConfig GetWarOfRealmFormation(this UserArchiveManager manager)
	{
		if (!manager.TryGetConfigValue<WarOfRealmConfig>("WarOfRealmFormation", out var val))
		{
			val = new WarOfRealmConfig();
			manager.SetWarOfRealmFormation(val);
		}
		return val;
	}

	public static void SetWarOfRealmFormationSaved(this UserArchiveManager manager, bool saved)
	{
		manager.SetConfigValue("WarOfRealmFormationSaved", saved);
	}

	public static bool HasSavedWarOfRealmFormation(this UserArchiveManager manager)
	{
		bool val;
		return manager.TryGetConfigValue<bool>("WarOfRealmFormationSaved", out val) && val;
	}
}
