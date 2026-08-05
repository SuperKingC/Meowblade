using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_btn_RefreshConfirm : GButton
{
	public Controller button;

	public GImage back;

	public GLoader icon;

	public const string URL = "ui://fvc33k3gv6i7y";

	public static string Name = "UI_btn_RefreshConfirm";

	public static string GetURL()
	{
		return "ui://fvc33k3gv6i7y";
	}

	public static UI_btn_RefreshConfirm CreateInstance()
	{
		return (UI_btn_RefreshConfirm)(object)UIPackage.CreateObject("GVGStore", "btn_RefreshConfirm");
	}

	public static UI_btn_RefreshConfirm CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_RefreshConfirm).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gv6i7y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
