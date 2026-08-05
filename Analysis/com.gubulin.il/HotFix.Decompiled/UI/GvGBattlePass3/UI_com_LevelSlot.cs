using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_com_LevelSlot : GComponent
{
	public Controller button;

	public Controller Type;

	public Controller Progress;

	public Controller IsSpecialNode;

	public GImage n55;

	public GImage n56;

	public GImage n57;

	public GImage n42;

	public GImage n54;

	public GImage n52;

	public UI_btn_RewardSlot1 Basic;

	public UI_btn_RewardSlot2 Advanced;

	public UI_btn_RewardSlot2 Premium;

	public GImage n44;

	public GImage n45;

	public GImage n47;

	public GImage n46;

	public GImage n43;

	public GMovieClip n51;

	public GLoader LevelIcon;

	public GImage n49;

	public GImage n50;

	public GTextField TargetLevel;

	public GGroup n53;

	public Transition t0;

	public const string URL = "ui://bfjg32huq1eq3g";

	public static string Name = "UI_com_LevelSlot";

	public static string GetURL()
	{
		return "ui://bfjg32huq1eq3g";
	}

	public static UI_com_LevelSlot CreateInstance()
	{
		return (UI_com_LevelSlot)(object)UIPackage.CreateObject("GvGBattlePass3", "com_LevelSlot");
	}

	public static UI_com_LevelSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LevelSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32huq1eq3g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		Progress = ((GComponent)this).GetController("Progress");
		IsSpecialNode = ((GComponent)this).GetController("IsSpecialNode");
		n55 = (GImage)((GComponent)this).GetChild("n55");
		n56 = (GImage)((GComponent)this).GetChild("n56");
		n57 = (GImage)((GComponent)this).GetChild("n57");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		Basic = (UI_btn_RewardSlot1)(object)((GComponent)this).GetChild("Basic");
		Advanced = (UI_btn_RewardSlot2)(object)((GComponent)this).GetChild("Advanced");
		Premium = (UI_btn_RewardSlot2)(object)((GComponent)this).GetChild("Premium");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		n51 = (GMovieClip)((GComponent)this).GetChild("n51");
		LevelIcon = (GLoader)((GComponent)this).GetChild("LevelIcon");
		n49 = (GImage)((GComponent)this).GetChild("n49");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		TargetLevel = (GTextField)((GComponent)this).GetChild("TargetLevel");
		n53 = (GGroup)((GComponent)this).GetChild("n53");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
