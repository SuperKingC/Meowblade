using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPlayerCommand3;

public class UI_btn_DefaultMessageFilter : GButton
{
	public Controller button;

	public GImage n5;

	public GImage back;

	public GImage n2;

	public GList Menu;

	public UI_btn_DefaultMessage CurrentSelected;

	public const string URL = "ui://vheg8vabeai37";

	public static string Name = "UI_btn_DefaultMessageFilter";

	public static string GetURL()
	{
		return "ui://vheg8vabeai37";
	}

	public static UI_btn_DefaultMessageFilter CreateInstance()
	{
		return (UI_btn_DefaultMessageFilter)(object)UIPackage.CreateObject("GvGPlayerCommand3", "btn_DefaultMessageFilter");
	}

	public static UI_btn_DefaultMessageFilter CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_DefaultMessageFilter).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai37", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
		back = (GImage)((GComponent)this).GetChild("back");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		Menu = (GList)((GComponent)this).GetChild("Menu");
		CurrentSelected = (UI_btn_DefaultMessage)(object)((GComponent)this).GetChild("CurrentSelected");
	}
}
