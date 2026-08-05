using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGChat;

public class UI_btn_TabWorld : GButton
{
	public Controller button;

	public GImage n4;

	public GImage n5;

	public GImage n6;

	public GImage n7;

	public const string URL = "ui://e3rxkbaprb0jf";

	public static string Name = "UI_btn_TabWorld";

	public static string GetURL()
	{
		return "ui://e3rxkbaprb0jf";
	}

	public static UI_btn_TabWorld CreateInstance()
	{
		return (UI_btn_TabWorld)(object)UIPackage.CreateObject("GvGChat", "btn_TabWorld");
	}

	public static UI_btn_TabWorld CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_TabWorld).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0jf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
