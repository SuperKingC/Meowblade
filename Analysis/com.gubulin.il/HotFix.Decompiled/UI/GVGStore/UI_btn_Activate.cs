using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_btn_Activate : GButton
{
	public Controller button;

	public Controller isGray;

	public GImage back;

	public GLoader icon;

	public const string URL = "ui://fvc33k3gr57r3b";

	public static string Name = "UI_btn_Activate";

	public static string GetURL()
	{
		return "ui://fvc33k3gr57r3b";
	}

	public static UI_btn_Activate CreateInstance()
	{
		return (UI_btn_Activate)(object)UIPackage.CreateObject("GVGStore", "btn_Activate");
	}

	public static UI_btn_Activate CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Activate).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gr57r3b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		isGray = ((GComponent)this).GetController("isGray");
		back = (GImage)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
