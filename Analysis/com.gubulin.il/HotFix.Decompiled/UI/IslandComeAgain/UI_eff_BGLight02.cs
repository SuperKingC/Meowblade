using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_eff_BGLight02 : GComponent
{
	public GImage n27;

	public GImage n22;

	public GImage n23;

	public GImage n24;

	public GImage n26;

	public GImage n28;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://k2sprg26laau4h";

	public static string Name = "UI_eff_BGLight02";

	public static string GetURL()
	{
		return "ui://k2sprg26laau4h";
	}

	public static UI_eff_BGLight02 CreateInstance()
	{
		return (UI_eff_BGLight02)(object)UIPackage.CreateObject("IslandComeAgain", "eff_BGLight02");
	}

	public static UI_eff_BGLight02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_eff_BGLight02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau4h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
