using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_btn_CloseDivineStore : GButton
{
	public GImage n112;

	public const string URL = "ui://fvc33k3gc7ho3e";

	public static string Name = "UI_btn_CloseDivineStore";

	public static string GetURL()
	{
		return "ui://fvc33k3gc7ho3e";
	}

	public static UI_btn_CloseDivineStore CreateInstance()
	{
		return (UI_btn_CloseDivineStore)(object)UIPackage.CreateObject("GVGStore", "btn_CloseDivineStore");
	}

	public static UI_btn_CloseDivineStore CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CloseDivineStore).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gc7ho3e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n112 = (GImage)((GComponent)this).GetChild("n112");
	}
}
