using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_btn_Buy : GButton
{
	public Controller button;

	public GImage back;

	public GLoader icon;

	public const string URL = "ui://fvc33k3gv6i7t";

	public static string Name = "UI_btn_Buy";

	public static string GetURL()
	{
		return "ui://fvc33k3gv6i7t";
	}

	public static UI_btn_Buy CreateInstance()
	{
		return (UI_btn_Buy)(object)UIPackage.CreateObject("GVGStore", "btn_Buy");
	}

	public static UI_btn_Buy CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Buy).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gv6i7t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		back = (GImage)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
