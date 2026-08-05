using System.Collections.Generic;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_NewGuideMode
{
	public const string MissionOf7ForeignActivityId = "MissionsOf7Days2";

	public const string eNewGuideModeDefault = "Default";

	public const string eNewGuideModeNew = "New";

	public const string eNewGuideModeForeign = "NewForeign";

	public const string eNewGuideModeNew2 = "New2";

	public const string eNewGuideModeForeign2 = "NewForeign2";

	public const string eNewGuideModeNew3 = "New3";

	public const string eNewGuideModeForeign3 = "NewForeign3";

	public const string eNewGuideModeNew4 = "New4";

	public const string eNewGuideModeForeign4 = "NewForeign4";

	public const string eNewGuideModeNew5 = "New5";

	public const string eNewGuideModeForeign5 = "NewForeign5";

	public const string eNewGuideModeNew6 = "New6";

	public const string eNewGuideModeForeign6 = "NewForeign6";

	public const string eNewGuideModeNew7 = "New7";

	public const string eNewGuideModeNewForeign7 = "NewForeign7";

	public const string NewGuideModeKey = "NewGuideMode";

	public static readonly HashSet<string> NewGuideModes = new HashSet<string>
	{
		"New", "New2", "New3", "New4", "New5", "New6", "New7", "NewForeign", "NewForeign2", "NewForeign3",
		"NewForeign4", "NewForeign5", "NewForeign6"
	};

	public static bool IsForeignNewGuideMode(this UserArchiveManager manager)
	{
		string newGuideMode = manager.GetNewGuideMode();
		int result;
		switch (newGuideMode)
		{
		default:
			result = ((newGuideMode == "NewForeign6") ? 1 : 0);
			break;
		case "NewForeign":
		case "NewForeign2":
		case "NewForeign3":
		case "NewForeign4":
		case "NewForeign5":
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	private static void EnsureNewGuideMode(this UserArchiveManager manager)
	{
		if (!manager.Contains("NewGuideMode"))
		{
			manager.SetNewGuideMode("Default");
		}
	}

	public static void SetNewGuideMode(this UserArchiveManager manager, string value)
	{
		manager.SetConfigValue("NewGuideMode", value);
	}

	public static string GetNewGuideMode(this UserArchiveManager manager)
	{
		manager.EnsureNewGuideMode();
		return manager.GetConfigValue<string>("NewGuideMode");
	}

	public static bool IsNewGuideMode(this UserArchiveManager manager)
	{
		string newGuideMode = manager.GetNewGuideMode();
		return NewGuideModes.Contains(newGuideMode);
	}

	public static bool IsNewGuideMode1(this UserArchiveManager manager)
	{
		return manager.GetNewGuideMode() == "New";
	}

	public static bool IsNewGuideMode2(this UserArchiveManager manager)
	{
		return manager.GetNewGuideMode() == "New2";
	}

	public static bool IsNewGuideMode3(this UserArchiveManager manager)
	{
		return manager.GetNewGuideMode() == "New3";
	}

	public static bool IsNewGuideMode4(this UserArchiveManager manager)
	{
		return manager.GetNewGuideMode() == "New4";
	}

	public static bool IsNewGuideMode5(this UserArchiveManager manager)
	{
		return manager.GetNewGuideMode() == "New5";
	}

	public static bool IsNewGuideMode6(this UserArchiveManager manager)
	{
		return manager.GetNewGuideMode() == "New6";
	}

	public static bool IsNewGuideMode7(this UserArchiveManager manager)
	{
		return manager.GetNewGuideMode() == "New7";
	}

	public static bool IsNewGuideForeignMode(this UserArchiveManager manager)
	{
		return manager.GetNewGuideMode() == "NewForeign";
	}

	public static bool IsNewGuideForeignMode2(this UserArchiveManager manager)
	{
		return manager.GetNewGuideMode() == "NewForeign2";
	}

	public static bool IsNewGuideForeignMode3(this UserArchiveManager manager)
	{
		return manager.GetNewGuideMode() == "NewForeign3";
	}

	public static bool IsNewGuideForeignMode4(this UserArchiveManager manager)
	{
		return manager.GetNewGuideMode() == "NewForeign4";
	}

	public static bool IsNewGuideForeignMode5(this UserArchiveManager manager)
	{
		return manager.GetNewGuideMode() == "NewForeign5";
	}

	public static bool IsNewGuideForeignMode6(this UserArchiveManager manager)
	{
		return manager.GetNewGuideMode() == "NewForeign6";
	}
}
