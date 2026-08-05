using FairyGUI;
using FairyGUI.Utils;

namespace UI.MilitaryAFKAssistant;

public class UI_dec_02 : GComponent
{
	public GImage n5;

	public GImage n6;

	public GImage n7;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://8x5gc8j2jz2uv4vc";

	public static string Name = "UI_dec_02";

	public static string GetURL()
	{
		return "ui://8x5gc8j2jz2uv4vc";
	}

	public static UI_dec_02 CreateInstance()
	{
		return (UI_dec_02)(object)UIPackage.CreateObject("MilitaryAFKAssistant", "dec_02");
	}

	public static UI_dec_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://8x5gc8j2jz2uv4vc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
