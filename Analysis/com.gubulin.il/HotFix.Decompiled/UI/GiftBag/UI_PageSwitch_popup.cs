using FairyGUI;
using FairyGUI.Utils;

namespace UI.GiftBag;

public class UI_PageSwitch_popup : GComponent
{
	public GGraph n0;

	public GList list;

	public const string URL = "ui://4fqsd8h6t1jrw";

	public static string Name = "UI_PageSwitch_popup";

	public static string GetURL()
	{
		return "ui://4fqsd8h6t1jrw";
	}

	public static UI_PageSwitch_popup CreateInstance()
	{
		return (UI_PageSwitch_popup)(object)UIPackage.CreateObject("GiftBag", "PageSwitch_popup");
	}

	public static UI_PageSwitch_popup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PageSwitch_popup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6t1jrw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		list = (GList)((GComponent)this).GetChild("list");
	}
}
