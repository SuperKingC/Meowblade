using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_RechargeAchievementList : GComponent
{
	public const string URL = "ui://29q48tv6gawy1i";

	public static string Name = "UI_RechargeAchievementList";

	public static string GetURL()
	{
		return "ui://29q48tv6gawy1i";
	}

	public static UI_RechargeAchievementList CreateInstance()
	{
		return (UI_RechargeAchievementList)(object)UIPackage.CreateObject("GameActivity", "RechargeAchievementList");
	}

	public static UI_RechargeAchievementList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RechargeAchievementList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6gawy1i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
	}
}
