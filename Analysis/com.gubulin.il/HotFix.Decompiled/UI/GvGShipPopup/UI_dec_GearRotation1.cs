using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_dec_GearRotation1 : GComponent
{
	public GGraph n2;

	public GImage n0;

	public Transition t0;

	public const string URL = "ui://pwrbvhpvhvfx5i";

	public static string Name = "UI_dec_GearRotation1";

	public static string GetURL()
	{
		return "ui://pwrbvhpvhvfx5i";
	}

	public static UI_dec_GearRotation1 CreateInstance()
	{
		return (UI_dec_GearRotation1)(object)UIPackage.CreateObject("GvGShipPopup", "dec_GearRotation1");
	}

	public static UI_dec_GearRotation1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_GearRotation1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvhvfx5i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n2 = (GGraph)((GComponent)this).GetChild("n2");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
