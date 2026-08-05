using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPlayerCommand3;

public class UI_btn_CommandMessage : GButton
{
	public Controller button;

	public GImage n1;

	public GImage n2;

	public const string URL = "ui://vheg8vabeai3g";

	public static string Name = "UI_btn_CommandMessage";

	public static string GetURL()
	{
		return "ui://vheg8vabeai3g";
	}

	public static UI_btn_CommandMessage CreateInstance()
	{
		return (UI_btn_CommandMessage)(object)UIPackage.CreateObject("GvGPlayerCommand3", "btn_CommandMessage");
	}

	public static UI_btn_CommandMessage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CommandMessage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai3g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
	}
}
