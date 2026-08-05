using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_MissionAchievementList : GComponent
{
	public const string URL = "ui://29q48tv6gawy1a";

	public static string Name = "UI_MissionAchievementList";

	public static string GetURL()
	{
		return "ui://29q48tv6gawy1a";
	}

	public static UI_MissionAchievementList CreateInstance()
	{
		return (UI_MissionAchievementList)(object)UIPackage.CreateObject("GameActivity", "MissionAchievementList");
	}

	public static UI_MissionAchievementList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MissionAchievementList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6gawy1a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
	}
}
