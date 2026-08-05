using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_eff_BGLight01 : GComponent
{
	public GImage n19;

	public GImage n21;

	public GImage n20;

	public GImage n18;

	public GImage n17;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://k2sprg26laau4d";

	public static string Name = "UI_eff_BGLight01";

	public static string GetURL()
	{
		return "ui://k2sprg26laau4d";
	}

	public static UI_eff_BGLight01 CreateInstance()
	{
		return (UI_eff_BGLight01)(object)UIPackage.CreateObject("IslandComeAgain", "eff_BGLight01");
	}

	public static UI_eff_BGLight01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_eff_BGLight01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau4d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
