using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_OffensiveCardPool : GComponent
{
	public GGraph point0;

	public GGraph point1;

	public GGraph point2;

	public GGraph point3;

	public GGraph point4;

	public GGraph point5;

	public GGraph point00;

	public GGraph point01;

	public GGraph point02;

	public GGraph point03;

	public GGraph point04;

	public GGroup PosTemplate0;

	public GGraph point10;

	public GGraph point11;

	public GGraph point12;

	public GGraph point13;

	public GGraph point14;

	public GGroup PosTemplate1;

	public GGraph point20;

	public GGraph point21;

	public GGraph point22;

	public GGraph point23;

	public GGraph point24;

	public GGroup PosTemplate2;

	public const string URL = "ui://f4wr270ric7j2x";

	public static string Name = "UI_OffensiveCardPool";

	public static string GetURL()
	{
		return "ui://f4wr270ric7j2x";
	}

	public static UI_OffensiveCardPool CreateInstance()
	{
		return (UI_OffensiveCardPool)(object)UIPackage.CreateObject("InstanceZones", "OffensiveCardPool");
	}

	public static UI_OffensiveCardPool CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OffensiveCardPool).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270ric7j2x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		point0 = (GGraph)((GComponent)this).GetChild("point0");
		point1 = (GGraph)((GComponent)this).GetChild("point1");
		point2 = (GGraph)((GComponent)this).GetChild("point2");
		point3 = (GGraph)((GComponent)this).GetChild("point3");
		point4 = (GGraph)((GComponent)this).GetChild("point4");
		point5 = (GGraph)((GComponent)this).GetChild("point5");
		point00 = (GGraph)((GComponent)this).GetChild("point00");
		point01 = (GGraph)((GComponent)this).GetChild("point01");
		point02 = (GGraph)((GComponent)this).GetChild("point02");
		point03 = (GGraph)((GComponent)this).GetChild("point03");
		point04 = (GGraph)((GComponent)this).GetChild("point04");
		PosTemplate0 = (GGroup)((GComponent)this).GetChild("PosTemplate0");
		point10 = (GGraph)((GComponent)this).GetChild("point10");
		point11 = (GGraph)((GComponent)this).GetChild("point11");
		point12 = (GGraph)((GComponent)this).GetChild("point12");
		point13 = (GGraph)((GComponent)this).GetChild("point13");
		point14 = (GGraph)((GComponent)this).GetChild("point14");
		PosTemplate1 = (GGroup)((GComponent)this).GetChild("PosTemplate1");
		point20 = (GGraph)((GComponent)this).GetChild("point20");
		point21 = (GGraph)((GComponent)this).GetChild("point21");
		point22 = (GGraph)((GComponent)this).GetChild("point22");
		point23 = (GGraph)((GComponent)this).GetChild("point23");
		point24 = (GGraph)((GComponent)this).GetChild("point24");
		PosTemplate2 = (GGroup)((GComponent)this).GetChild("PosTemplate2");
	}
}
