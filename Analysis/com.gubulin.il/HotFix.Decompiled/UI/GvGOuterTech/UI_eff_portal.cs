using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_eff_portal : GComponent
{
	public GImage n148;

	public GImage n147;

	public GImage n150;

	public Transition t0;

	public const string URL = "ui://th385mttshl4o69";

	public static string Name = "UI_eff_portal";

	public static string GetURL()
	{
		return "ui://th385mttshl4o69";
	}

	public static UI_eff_portal CreateInstance()
	{
		return (UI_eff_portal)(object)UIPackage.CreateObject("GvGOuterTech", "eff_portal");
	}

	public static UI_eff_portal CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_eff_portal).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttshl4o69", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n148 = (GImage)((GComponent)this).GetChild("n148");
		n147 = (GImage)((GComponent)this).GetChild("n147");
		n150 = (GImage)((GComponent)this).GetChild("n150");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
