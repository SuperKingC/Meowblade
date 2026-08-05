using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_mc_Curtain02 : GComponent
{
	public GImage n6;

	public GImage n5;

	public Transition t0;

	public const string URL = "ui://k2sprg26laau6a";

	public static string Name = "UI_mc_Curtain02";

	public static string GetURL()
	{
		return "ui://k2sprg26laau6a";
	}

	public static UI_mc_Curtain02 CreateInstance()
	{
		return (UI_mc_Curtain02)(object)UIPackage.CreateObject("IslandComeAgain", "mc_Curtain02");
	}

	public static UI_mc_Curtain02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mc_Curtain02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau6a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
