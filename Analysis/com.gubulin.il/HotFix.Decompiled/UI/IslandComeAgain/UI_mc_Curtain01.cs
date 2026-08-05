using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_mc_Curtain01 : GComponent
{
	public GImage n4;

	public GImage n3;

	public Transition t0;

	public const string URL = "ui://k2sprg26laau67";

	public static string Name = "UI_mc_Curtain01";

	public static string GetURL()
	{
		return "ui://k2sprg26laau67";
	}

	public static UI_mc_Curtain01 CreateInstance()
	{
		return (UI_mc_Curtain01)(object)UIPackage.CreateObject("IslandComeAgain", "mc_Curtain01");
	}

	public static UI_mc_Curtain01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mc_Curtain01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau67", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
