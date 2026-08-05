using FairyGUI;
using FairyGUI.Utils;

namespace UI.PrinceOfTheDevils;

public class UI_AchievementList : GComponent
{
	public const string URL = "ui://zko5n3veohi4n";

	public static string Name = "UI_AchievementList";

	public static string GetURL()
	{
		return "ui://zko5n3veohi4n";
	}

	public static UI_AchievementList CreateInstance()
	{
		return (UI_AchievementList)(object)UIPackage.CreateObject("PrinceOfTheDevils", "AchievementList");
	}

	public static UI_AchievementList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AchievementList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3veohi4n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
	}
}
