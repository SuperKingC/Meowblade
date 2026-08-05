using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_ItemDisplay : GButton
{
	public Controller button;

	public GLoader Icon;

	public const string URL = "ui://2eraz3j9j2ox16";

	public static string Name = "UI_ItemDisplay";

	public static string GetURL()
	{
		return "ui://2eraz3j9j2ox16";
	}

	public static UI_ItemDisplay CreateInstance()
	{
		return (UI_ItemDisplay)(object)UIPackage.CreateObject("LegendItemDungeon", "ItemDisplay");
	}

	public static UI_ItemDisplay CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ItemDisplay).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9j2ox16", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
	}
}
