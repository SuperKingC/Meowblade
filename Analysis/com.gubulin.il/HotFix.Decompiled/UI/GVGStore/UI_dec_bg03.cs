using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_dec_bg03 : GComponent
{
	public GImage n31;

	public const string URL = "ui://fvc33k3g9fpi4d";

	public static string Name = "UI_dec_bg03";

	public static string GetURL()
	{
		return "ui://fvc33k3g9fpi4d";
	}

	public static UI_dec_bg03 CreateInstance()
	{
		return (UI_dec_bg03)(object)UIPackage.CreateObject("GVGStore", "dec_bg03");
	}

	public static UI_dec_bg03 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_bg03).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3g9fpi4d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n31 = (GImage)((GComponent)this).GetChild("n31");
	}
}
