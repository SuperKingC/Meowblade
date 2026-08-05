using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoulKeyStore;

public class UI_com_Scroll : GComponent
{
	public GImage n4;

	public Transition t0;

	public const string URL = "ui://3nd2hqkir89117";

	public static string Name = "UI_com_Scroll";

	public static string GetURL()
	{
		return "ui://3nd2hqkir89117";
	}

	public static UI_com_Scroll CreateInstance()
	{
		return (UI_com_Scroll)(object)UIPackage.CreateObject("SoulKeyStore", "com_Scroll");
	}

	public static UI_com_Scroll CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Scroll).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3nd2hqkir89117", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
