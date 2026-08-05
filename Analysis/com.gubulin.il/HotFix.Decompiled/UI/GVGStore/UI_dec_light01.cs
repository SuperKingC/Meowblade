using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_dec_light01 : GComponent
{
	public GImage n16;

	public Transition t0;

	public const string URL = "ui://fvc33k3gf5k049";

	public static string Name = "UI_dec_light01";

	public static string GetURL()
	{
		return "ui://fvc33k3gf5k049";
	}

	public static UI_dec_light01 CreateInstance()
	{
		return (UI_dec_light01)(object)UIPackage.CreateObject("GVGStore", "dec_light01");
	}

	public static UI_dec_light01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_light01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gf5k049", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n16 = (GImage)((GComponent)this).GetChild("n16");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
