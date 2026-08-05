using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_HoldingPercent : GComponent
{
	public Controller CampId;

	public Controller State;

	public GImage n8;

	public GLoader n0;

	public GTextField HoldingPercent;

	public GImage n11;

	public GImage n10;

	public GLoader n1;

	public GImage n6;

	public GMovieClip n5;

	public GImage n9;

	public GTextField ShipCount;

	public Transition t0;

	public const string URL = "ui://ebc4ciwrl44le";

	public static string Name = "UI_com_HoldingPercent";

	public static string GetURL()
	{
		return "ui://ebc4ciwrl44le";
	}

	public static UI_com_HoldingPercent CreateInstance()
	{
		return (UI_com_HoldingPercent)(object)UIPackage.CreateObject("GvGOnIsland3", "com_HoldingPercent");
	}

	public static UI_com_HoldingPercent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_HoldingPercent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrl44le", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		CampId = ((GComponent)this).GetController("CampId");
		State = ((GComponent)this).GetController("State");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n0 = (GLoader)((GComponent)this).GetChild("n0");
		HoldingPercent = (GTextField)((GComponent)this).GetChild("HoldingPercent");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n5 = (GMovieClip)((GComponent)this).GetChild("n5");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		ShipCount = (GTextField)((GComponent)this).GetChild("ShipCount");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
