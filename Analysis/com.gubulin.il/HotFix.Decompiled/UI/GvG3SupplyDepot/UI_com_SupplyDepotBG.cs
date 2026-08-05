using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SupplyDepot;

public class UI_com_SupplyDepotBG : GComponent
{
	public GImage n10;

	public GImage n15;

	public GImage n14;

	public GImage n16;

	public GImage n17;

	public UI_com_CloudFluttering n19;

	public GImage n18;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://pobej4q7v7ipy1p";

	public static string Name = "UI_com_SupplyDepotBG";

	public static string GetURL()
	{
		return "ui://pobej4q7v7ipy1p";
	}

	public static UI_com_SupplyDepotBG CreateInstance()
	{
		return (UI_com_SupplyDepotBG)(object)UIPackage.CreateObject("GvG3SupplyDepot", "com_SupplyDepotBG");
	}

	public static UI_com_SupplyDepotBG CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SupplyDepotBG).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7v7ipy1p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n19 = (UI_com_CloudFluttering)(object)((GComponent)this).GetChild("n19");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
