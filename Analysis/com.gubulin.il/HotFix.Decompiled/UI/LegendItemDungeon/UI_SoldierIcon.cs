using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_SoldierIcon : GButton
{
	public Controller button;

	public GImage back1;

	public UI_LegendSoldierIcon icon;

	public GImage back2;

	public const string URL = "ui://2eraz3j9glfm1p";

	public static string Name = "UI_SoldierIcon";

	public static string GetURL()
	{
		return "ui://2eraz3j9glfm1p";
	}

	public static UI_SoldierIcon CreateInstance()
	{
		return (UI_SoldierIcon)(object)UIPackage.CreateObject("LegendItemDungeon", "SoldierIcon");
	}

	public static UI_SoldierIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9glfm1p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back1 = (GImage)((GComponent)this).GetChild("back1");
		icon = (UI_LegendSoldierIcon)(object)((GComponent)this).GetChild("icon");
		back2 = (GImage)((GComponent)this).GetChild("back2");
	}
}
