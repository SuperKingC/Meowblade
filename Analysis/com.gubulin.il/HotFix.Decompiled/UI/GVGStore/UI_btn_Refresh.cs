using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_btn_Refresh : GButton
{
	public Controller button;

	public GImage n6;

	public const string URL = "ui://fvc33k3gv6i7u";

	public static string Name = "UI_btn_Refresh";

	public static string GetURL()
	{
		return "ui://fvc33k3gv6i7u";
	}

	public static UI_btn_Refresh CreateInstance()
	{
		return (UI_btn_Refresh)(object)UIPackage.CreateObject("GVGStore", "btn_Refresh");
	}

	public static UI_btn_Refresh CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Refresh).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gv6i7u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
