using System.Collections.Generic;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_UI
{
	private const string MainCityUnlockedComKey = "MAIN_CITY_UNLOCKED_COM";

	public static List<string> GetUnlockedMainCityCom(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<List<string>>("MAIN_CITY_UNLOCKED_COM");
	}

	public static void UnlockMainCityCom(this UserArchiveManager manager, string componentName)
	{
		List<string> unlockedMainCityCom = manager.GetUnlockedMainCityCom();
		if (!unlockedMainCityCom.Contains(componentName))
		{
			unlockedMainCityCom.Add(componentName);
			manager.SetConfigValue("MAIN_CITY_UNLOCKED_COM", unlockedMainCityCom);
			manager.Managers.Messenger.Broadcast("MAIN_CITY_COM_UNLOCKED", componentName);
		}
	}
}
