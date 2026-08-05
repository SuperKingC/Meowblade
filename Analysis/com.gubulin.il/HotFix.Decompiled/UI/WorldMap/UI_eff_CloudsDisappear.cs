using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_eff_CloudsDisappear : GComponent
{
	public GImage n00;

	public GImage n01;

	public GImage n02;

	public GImage n03;

	public GImage n04;

	public GImage n05;

	public GImage n06;

	public GImage n07;

	public GImage n08;

	public GImage n09;

	public GImage n10;

	public GImage n11;

	public GImage n12;

	public GImage n13;

	public GImage n14;

	public GImage n15;

	public Transition t0;

	public const string URL = "ui://c9n2h0kspplflg";

	public static string Name = "UI_eff_CloudsDisappear";

	public static string GetURL()
	{
		return "ui://c9n2h0kspplflg";
	}

	public static UI_eff_CloudsDisappear CreateInstance()
	{
		return (UI_eff_CloudsDisappear)(object)UIPackage.CreateObject("WorldMap", "eff_CloudsDisappear");
	}

	public static UI_eff_CloudsDisappear CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_eff_CloudsDisappear).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0kspplflg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n00 = (GImage)((GComponent)this).GetChild("n00");
		n01 = (GImage)((GComponent)this).GetChild("n01");
		n02 = (GImage)((GComponent)this).GetChild("n02");
		n03 = (GImage)((GComponent)this).GetChild("n03");
		n04 = (GImage)((GComponent)this).GetChild("n04");
		n05 = (GImage)((GComponent)this).GetChild("n05");
		n06 = (GImage)((GComponent)this).GetChild("n06");
		n07 = (GImage)((GComponent)this).GetChild("n07");
		n08 = (GImage)((GComponent)this).GetChild("n08");
		n09 = (GImage)((GComponent)this).GetChild("n09");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
