using HotFix.Sources.Base.Scripts.Helper;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.ObserverStat;

public static class eObserverStatKey_Extension
{
	public static string GetName(this eObserverStatKey type)
	{
		return $"GvG3_eObserverStatKey_{(int)type}".ToLanguage();
	}
}
