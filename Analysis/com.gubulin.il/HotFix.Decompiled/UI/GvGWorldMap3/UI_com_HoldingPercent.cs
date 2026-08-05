using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_HoldingPercent : GComponent
{
	public Controller CampId;

	public Controller isAdvance;

	public GImage n8;

	public GImage n0;

	public GImage n13;

	public GTextField islandOccupiedCount;

	public GTextField islandOccupiedCount2;

	public GImage n11;

	public GLoader n1;

	public GImage n12;

	public GMovieClip n14;

	public GMovieClip n15;

	public GMovieClip n16;

	public Transition t0;

	public const string URL = "ui://4eq8fgd210ihqb6se0";

	public static string Name = "UI_com_HoldingPercent";

	public static string GetURL()
	{
		return "ui://4eq8fgd210ihqb6se0";
	}

	public static UI_com_HoldingPercent CreateInstance()
	{
		return (UI_com_HoldingPercent)(object)UIPackage.CreateObject("GvGWorldMap3", "com_HoldingPercent");
	}

	public static UI_com_HoldingPercent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_HoldingPercent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd210ihqb6se0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CampId = ((GComponent)this).GetController("CampId");
		isAdvance = ((GComponent)this).GetController("isAdvance");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		islandOccupiedCount = (GTextField)((GComponent)this).GetChild("islandOccupiedCount");
		islandOccupiedCount2 = (GTextField)((GComponent)this).GetChild("islandOccupiedCount2");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n14 = (GMovieClip)((GComponent)this).GetChild("n14");
		n15 = (GMovieClip)((GComponent)this).GetChild("n15");
		n16 = (GMovieClip)((GComponent)this).GetChild("n16");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
