using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipOverview;

public class UI_GearRotation : GComponent
{
	public GImage n0;

	public Transition t0;

	public const string URL = "ui://7ymaonxtc69m4y";

	public static string Name = "UI_GearRotation";

	public static string GetURL()
	{
		return "ui://7ymaonxtc69m4y";
	}

	public static UI_GearRotation CreateInstance()
	{
		return (UI_GearRotation)(object)UIPackage.CreateObject("GvGShipOverview", "GearRotation");
	}

	public static UI_GearRotation CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GearRotation).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ymaonxtc69m4y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
