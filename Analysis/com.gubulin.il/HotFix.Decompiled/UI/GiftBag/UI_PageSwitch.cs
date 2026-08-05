using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GiftBag;

public class UI_PageSwitch : GComboBox
{
	public Controller button;

	public GGraph n0;

	public GGraph n1;

	public GGraph n2;

	public GTextField title;

	public const string URL = "ui://4fqsd8h6t1jrx";

	public static string Name = "UI_PageSwitch";

	public static string GetURL()
	{
		return "ui://4fqsd8h6t1jrx";
	}

	public static UI_PageSwitch CreateInstance()
	{
		return (UI_PageSwitch)(object)UIPackage.CreateObject("GiftBag", "PageSwitch");
	}

	public static UI_PageSwitch CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PageSwitch).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6t1jrx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		n1 = (GGraph)((GComponent)this).GetChild("n1");
		n2 = (GGraph)((GComponent)this).GetChild("n2");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://4fqsd8h6t1jrx".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
