using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SplitBluePrint;

public class UI_dec_light02 : GComponent
{
	public GImage n3;

	public GImage n4;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://7uylntmmhzei1x";

	public static string Name = "UI_dec_light02";

	public static string GetURL()
	{
		return "ui://7uylntmmhzei1x";
	}

	public static UI_dec_light02 CreateInstance()
	{
		return (UI_dec_light02)(object)UIPackage.CreateObject("GvG3SplitBluePrint", "dec_light02");
	}

	public static UI_dec_light02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_light02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7uylntmmhzei1x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
