using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SplitBluePrint;

public class UI_com_Effect01 : GComponent
{
	public GLoader icon;

	public GMovieClip n1;

	public Transition t0;

	public const string URL = "ui://7uylntmmkp1o20";

	public static string Name = "UI_com_Effect01";

	public static string GetURL()
	{
		return "ui://7uylntmmkp1o20";
	}

	public static UI_com_Effect01 CreateInstance()
	{
		return (UI_com_Effect01)(object)UIPackage.CreateObject("GvG3SplitBluePrint", "com_Effect01");
	}

	public static UI_com_Effect01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Effect01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7uylntmmkp1o20", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n1 = (GMovieClip)((GComponent)this).GetChild("n1");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
