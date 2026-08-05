using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3LandOfEternalNight;

public class UI_eff_star_yellow : GComponent
{
	public GImage n56;

	public Transition t0;

	public const string URL = "ui://amuqyzl8g180m";

	public static string Name = "UI_eff_star_yellow";

	public static string GetURL()
	{
		return "ui://amuqyzl8g180m";
	}

	public static UI_eff_star_yellow CreateInstance()
	{
		return (UI_eff_star_yellow)(object)UIPackage.CreateObject("GvG3LandOfEternalNight", "eff_star_yellow");
	}

	public static UI_eff_star_yellow CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_eff_star_yellow).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://amuqyzl8g180m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n56 = (GImage)((GComponent)this).GetChild("n56");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
