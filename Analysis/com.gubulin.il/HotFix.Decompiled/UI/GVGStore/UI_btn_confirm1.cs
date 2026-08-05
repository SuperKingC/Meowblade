using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_btn_confirm1 : GButton
{
	public Controller button;

	public GImage n8;

	public GLoader icon;

	public const string URL = "ui://fvc33k3gjsii3";

	public static string Name = "UI_btn_confirm1";

	public static string GetURL()
	{
		return "ui://fvc33k3gjsii3";
	}

	public static UI_btn_confirm1 CreateInstance()
	{
		return (UI_btn_confirm1)(object)UIPackage.CreateObject("GVGStore", "btn_confirm1");
	}

	public static UI_btn_confirm1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_confirm1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gjsii3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n8 = (GImage)((GComponent)this).GetChild("n8");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
