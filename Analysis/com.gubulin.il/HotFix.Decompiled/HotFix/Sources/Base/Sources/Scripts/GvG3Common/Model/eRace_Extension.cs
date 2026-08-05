using FairyGUI;
using HotFix.Sources.Base.Scripts.Helper;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

public static class eRace_Extension
{
	private const string IconPrefix = "ShipRace";

	public static string ToRaceIconUrl(this eRace race)
	{
		return string.Format("img_{0}_{1}", "ShipRace", (int)race).ToPublicResourcesRgbIcon();
	}

	public static eRace IconUrlToRace(this string url)
	{
		if (string.IsNullOrEmpty(url))
		{
			return eRace.Invalid;
		}
		PackageItem itemByURL = UIPackage.GetItemByURL(url);
		if (itemByURL == null)
		{
			return eRace.Invalid;
		}
		string name = itemByURL.name;
		if (string.IsNullOrEmpty(name))
		{
			return eRace.Invalid;
		}
		string[] array = name.Split('_');
		if (array.Length < 2)
		{
			return eRace.Invalid;
		}
		string text = array[^2];
		string s = array[^1];
		if (text != "ShipRace" || !int.TryParse(s, out var result))
		{
			return eRace.Invalid;
		}
		return (eRace)result;
	}
}
