using FairyGUI;
using FairyGUI.Utils;

namespace UI.PrinceOfTheDevils;

public class UI_RightContent : GComponent
{
	public UI_AchievementList AchievementList;

	public Transition test;

	public const string URL = "ui://zko5n3veohi4m";

	public static string Name = "UI_RightContent";

	public static string GetURL()
	{
		return "ui://zko5n3veohi4m";
	}

	public static UI_RightContent CreateInstance()
	{
		return (UI_RightContent)(object)UIPackage.CreateObject("PrinceOfTheDevils", "RightContent");
	}

	public static UI_RightContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RightContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3veohi4m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		AchievementList = (UI_AchievementList)(object)((GComponent)this).GetChild("AchievementList");
		test = ((GComponent)this).GetTransition("test");
	}
}
