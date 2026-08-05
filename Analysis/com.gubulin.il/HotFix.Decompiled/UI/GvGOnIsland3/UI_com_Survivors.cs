using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_Survivors : GComponent
{
	public Controller Type;

	public Controller isFinal;

	public GImage n88;

	public GImage n80;

	public GImage n82;

	public GImage n83;

	public GImage n92;

	public GLoader n84;

	public GLoader n85;

	public GTextField SoldierCount1;

	public GTextField Magnification;

	public GImage n89;

	public GMovieClip n90;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://ebc4ciwrebviq73";

	public static string Name = "UI_com_Survivors";

	public static string GetURL()
	{
		return "ui://ebc4ciwrebviq73";
	}

	public static UI_com_Survivors CreateInstance()
	{
		return (UI_com_Survivors)(object)UIPackage.CreateObject("GvGOnIsland3", "com_Survivors");
	}

	public static UI_com_Survivors CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Survivors).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrebviq73", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Type = ((GComponent)this).GetController("Type");
		isFinal = ((GComponent)this).GetController("isFinal");
		n88 = (GImage)((GComponent)this).GetChild("n88");
		n80 = (GImage)((GComponent)this).GetChild("n80");
		n82 = (GImage)((GComponent)this).GetChild("n82");
		n83 = (GImage)((GComponent)this).GetChild("n83");
		n92 = (GImage)((GComponent)this).GetChild("n92");
		n84 = (GLoader)((GComponent)this).GetChild("n84");
		n85 = (GLoader)((GComponent)this).GetChild("n85");
		SoldierCount1 = (GTextField)((GComponent)this).GetChild("SoldierCount1");
		Magnification = (GTextField)((GComponent)this).GetChild("Magnification");
		n89 = (GImage)((GComponent)this).GetChild("n89");
		n90 = (GMovieClip)((GComponent)this).GetChild("n90");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
