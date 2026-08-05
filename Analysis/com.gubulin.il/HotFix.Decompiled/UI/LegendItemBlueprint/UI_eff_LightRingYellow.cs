using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_eff_LightRingYellow : GComponent
{
	public GImage n23;

	public GImage n24;

	public Transition t0;

	public const string URL = "ui://h09dvkcgq0lt4e";

	public static string Name = "UI_eff_LightRingYellow";

	public static string GetURL()
	{
		return "ui://h09dvkcgq0lt4e";
	}

	public static UI_eff_LightRingYellow CreateInstance()
	{
		return (UI_eff_LightRingYellow)(object)UIPackage.CreateObject("LegendItemBlueprint", "eff_LightRingYellow");
	}

	public static UI_eff_LightRingYellow CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_eff_LightRingYellow).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgq0lt4e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
