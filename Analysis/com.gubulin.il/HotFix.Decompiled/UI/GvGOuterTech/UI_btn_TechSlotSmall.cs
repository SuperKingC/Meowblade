using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_btn_TechSlotSmall : GButton
{
	public Controller Rarity;

	public Controller State;

	public GGraph SfxBack;

	public GGroup n45;

	public GImage n42;

	public GLoader Frame;

	public GLoader n28;

	public GImage n29;

	public GLoader TechIcon;

	public GImage n30;

	public GTextField TechName;

	public GLoader n44;

	public GImage n33;

	public GImage n32;

	public GImage n39;

	public GImage n40;

	public GImage n38;

	public GImage n21;

	public GImage n41;

	public GLoader PieceIcon;

	public GTextField ToPieceCount;

	public GGroup n25;

	public GImage n34;

	public GImage n35;

	public GGroup n37;

	public Transition t0;

	public const string URL = "ui://th385mttlgfv20";

	public static string Name = "UI_btn_TechSlotSmall";

	public static string GetURL()
	{
		return "ui://th385mttlgfv20";
	}

	public static UI_btn_TechSlotSmall CreateInstance()
	{
		return (UI_btn_TechSlotSmall)(object)UIPackage.CreateObject("GvGOuterTech", "btn_TechSlotSmall");
	}

	public static UI_btn_TechSlotSmall CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_TechSlotSmall).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttlgfv20", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Rarity = ((GComponent)this).GetController("Rarity");
		State = ((GComponent)this).GetController("State");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		n45 = (GGroup)((GComponent)this).GetChild("n45");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		Frame = (GLoader)((GComponent)this).GetChild("Frame");
		n28 = (GLoader)((GComponent)this).GetChild("n28");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		TechIcon = (GLoader)((GComponent)this).GetChild("TechIcon");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		TechName = (GTextField)((GComponent)this).GetChild("TechName");
		n44 = (GLoader)((GComponent)this).GetChild("n44");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n38 = (GImage)((GComponent)this).GetChild("n38");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		PieceIcon = (GLoader)((GComponent)this).GetChild("PieceIcon");
		ToPieceCount = (GTextField)((GComponent)this).GetChild("ToPieceCount");
		n25 = (GGroup)((GComponent)this).GetChild("n25");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		n35 = (GImage)((GComponent)this).GetChild("n35");
		n37 = (GGroup)((GComponent)this).GetChild("n37");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
