using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGMode3Collecting;

public class UI_eff_FloatingIsland : GComponent
{
	public GGraph n13;

	public GImage island7;

	public GImage island6;

	public GImage island5;

	public GImage island4;

	public GImage island3;

	public GImage island2;

	public GImage island1;

	public Transition t0;

	public const string URL = "ui://n2y4xuvas4pld";

	public static string Name = "UI_eff_FloatingIsland";

	public static string GetURL()
	{
		return "ui://n2y4xuvas4pld";
	}

	public static UI_eff_FloatingIsland CreateInstance()
	{
		return (UI_eff_FloatingIsland)(object)UIPackage.CreateObject("GvGMode3Collecting", "eff_FloatingIsland");
	}

	public static UI_eff_FloatingIsland CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_eff_FloatingIsland).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://n2y4xuvas4pld", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n13 = (GGraph)((GComponent)this).GetChild("n13");
		island7 = (GImage)((GComponent)this).GetChild("island7");
		island6 = (GImage)((GComponent)this).GetChild("island6");
		island5 = (GImage)((GComponent)this).GetChild("island5");
		island4 = (GImage)((GComponent)this).GetChild("island4");
		island3 = (GImage)((GComponent)this).GetChild("island3");
		island2 = (GImage)((GComponent)this).GetChild("island2");
		island1 = (GImage)((GComponent)this).GetChild("island1");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
