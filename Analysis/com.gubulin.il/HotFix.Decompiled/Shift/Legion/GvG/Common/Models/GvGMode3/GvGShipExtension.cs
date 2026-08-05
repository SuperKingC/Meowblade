using HotFix.Sources.Base.Scripts.Helper;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

public static class GvGShipExtension
{
	public static string ToRealShipName(this string rawShipName)
	{
		string text = rawShipName;
		if (!string.IsNullOrEmpty(text) && text[0] == '#')
		{
			text = text.Replace("#", "").ToLanguage();
		}
		return text;
	}
}
