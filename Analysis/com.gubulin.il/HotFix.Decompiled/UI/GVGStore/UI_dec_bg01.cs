using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_dec_bg01 : GComponent
{
	public GImage n24;

	public GImage n25;

	public const string URL = "ui://fvc33k3gf5k04a";

	public static string Name = "UI_dec_bg01";

	public static string GetURL()
	{
		return "ui://fvc33k3gf5k04a";
	}

	public static UI_dec_bg01 CreateInstance()
	{
		return (UI_dec_bg01)(object)UIPackage.CreateObject("GVGStore", "dec_bg01");
	}

	public static UI_dec_bg01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_bg01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gf5k04a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GImage)((GComponent)this).GetChild("n25");
	}
}
