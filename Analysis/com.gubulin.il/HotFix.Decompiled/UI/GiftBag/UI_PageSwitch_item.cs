using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GiftBag;

public class UI_PageSwitch_item : GButton
{
	public Controller button;

	public GGraph n0;

	public GGraph n1;

	public GTextField title;

	public const string URL = "ui://4fqsd8h6t1jrv";

	public static string Name = "UI_PageSwitch_item";

	public static string GetURL()
	{
		return "ui://4fqsd8h6t1jrv";
	}

	public static UI_PageSwitch_item CreateInstance()
	{
		return (UI_PageSwitch_item)(object)UIPackage.CreateObject("GiftBag", "PageSwitch_item");
	}

	public static UI_PageSwitch_item CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PageSwitch_item).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6t1jrv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		n1 = (GGraph)((GComponent)this).GetChild("n1");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://4fqsd8h6t1jrv".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
