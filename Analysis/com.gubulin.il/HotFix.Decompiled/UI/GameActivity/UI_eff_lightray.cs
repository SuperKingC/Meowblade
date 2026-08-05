using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_eff_lightray : GComponent
{
	public GImage n86;

	public GImage n87;

	public GImage n88;

	public Transition t0;

	public const string URL = "ui://29q48tv6pri95f87";

	public static string Name = "UI_eff_lightray";

	public static string GetURL()
	{
		return "ui://29q48tv6pri95f87";
	}

	public static UI_eff_lightray CreateInstance()
	{
		return (UI_eff_lightray)(object)UIPackage.CreateObject("GameActivity", "eff_lightray");
	}

	public static UI_eff_lightray CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_eff_lightray).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6pri95f87", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n86 = (GImage)((GComponent)this).GetChild("n86");
		n87 = (GImage)((GComponent)this).GetChild("n87");
		n88 = (GImage)((GComponent)this).GetChild("n88");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
