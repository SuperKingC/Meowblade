using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_LegendSoldierIcon : GComponent
{
	public GImage n10;

	public GLoader icon;

	public const string URL = "ui://2eraz3j9kl9h44";

	public static string Name = "UI_LegendSoldierIcon";

	public static string GetURL()
	{
		return "ui://2eraz3j9kl9h44";
	}

	public static UI_LegendSoldierIcon CreateInstance()
	{
		return (UI_LegendSoldierIcon)(object)UIPackage.CreateObject("LegendItemDungeon", "LegendSoldierIcon");
	}

	public static UI_LegendSoldierIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendSoldierIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9kl9h44", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n10 = (GImage)((GComponent)this).GetChild("n10");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
