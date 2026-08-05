using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGChat;

public class UI_btn_Cancel : GButton
{
	public Controller button;

	public GImage n7;

	public GLoader icon;

	public const string URL = "ui://e3rxkbaprb0jz";

	public static string Name = "UI_btn_Cancel";

	public static string GetURL()
	{
		return "ui://e3rxkbaprb0jz";
	}

	public static UI_btn_Cancel CreateInstance()
	{
		return (UI_btn_Cancel)(object)UIPackage.CreateObject("GvGChat", "btn_Cancel");
	}

	public static UI_btn_Cancel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Cancel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0jz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n7 = (GImage)((GComponent)this).GetChild("n7");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
