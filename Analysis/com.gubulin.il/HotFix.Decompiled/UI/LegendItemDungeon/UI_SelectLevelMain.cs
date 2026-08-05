using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_SelectLevelMain : GButton
{
	public Controller button;

	public const string URL = "ui://2eraz3j9f5lg1j";

	public static string Name = "UI_SelectLevelMain";

	public static string GetURL()
	{
		return "ui://2eraz3j9f5lg1j";
	}

	public static UI_SelectLevelMain CreateInstance()
	{
		return (UI_SelectLevelMain)(object)UIPackage.CreateObject("LegendItemDungeon", "SelectLevelMain");
	}

	public static UI_SelectLevelMain CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SelectLevelMain).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9f5lg1j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
	}
}
