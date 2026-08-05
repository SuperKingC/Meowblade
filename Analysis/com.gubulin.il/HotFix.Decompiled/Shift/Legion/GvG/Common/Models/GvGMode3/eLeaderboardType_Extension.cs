using HotFix.Sources.Base.Scripts.Helper;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

public static class eLeaderboardType_Extension
{
	public static string GetName(this eLeaderboardType type)
	{
		return $"GvG3_eLeaderboardType_{(int)type}".ToLanguage();
	}
}
