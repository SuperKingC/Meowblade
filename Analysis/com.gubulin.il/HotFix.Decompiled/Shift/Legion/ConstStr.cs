using Assets.Scripts.Managers;
using HotFix;

namespace Shift.Legion;

public static class ConstStr
{
	public static string UNLOCK_BLACK_MARKET => LanguagesManager.GetDesc("CsharpCodeZhTcText152");

	public static string DEFENSIVE_LEVEL_UP_TIP => LanguagesManager.GetDesc("CsharpCodeZhTcText709");

	public static string DEFENSIVE_LEVEL_MAX => LanguagesManager.GetDesc("CsharpCodeZhTcText710");

	public static string LAST_TURN_BATTLE_LOG_TITLE => LanguagesManager.GetDesc("CsharpCodeZhTcText263");

	public static string USER_VERIFIED => LanguagesManager.GetDesc("CsharpCodeZhTcText711");

	public static string GetItemNameXCountString(string name, int count)
	{
		return (HotUpdateProcess.LanguageKey == "eng") ? $"{name} x {count}" : $"{name}x{count}";
	}
}
