using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_com_LevelSlot_Big : GComponent
{
	public Controller button;

	public Controller AdvanceNum;

	public UI_btn_SlotBuy SlotBuyBtn;

	public GImage n40;

	public GImage n51;

	public GImage n52;

	public GImage n48;

	public GImage n50;

	public UI_btn_RewardSlot1 Basic;

	public UI_btn_RewardSlot2 Advanced;

	public UI_btn_RewardSlot2 Premium;

	public GImage n44;

	public GImage n45;

	public GTextField TargetLevel;

	public GGroup n47;

	public Transition Switch;

	public const string URL = "ui://bfjg32huq1eq3k";

	public static string Name = "UI_com_LevelSlot_Big";

	public static string GetURL()
	{
		return "ui://bfjg32huq1eq3k";
	}

	public static UI_com_LevelSlot_Big CreateInstance()
	{
		return (UI_com_LevelSlot_Big)(object)UIPackage.CreateObject("GvGBattlePass3", "com_LevelSlot_Big");
	}

	public static UI_com_LevelSlot_Big CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LevelSlot_Big).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32huq1eq3k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
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
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		AdvanceNum = ((GComponent)this).GetController("AdvanceNum");
		SlotBuyBtn = (UI_btn_SlotBuy)(object)((GComponent)this).GetChild("SlotBuyBtn");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n51 = (GImage)((GComponent)this).GetChild("n51");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		n48 = (GImage)((GComponent)this).GetChild("n48");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		Basic = (UI_btn_RewardSlot1)(object)((GComponent)this).GetChild("Basic");
		Advanced = (UI_btn_RewardSlot2)(object)((GComponent)this).GetChild("Advanced");
		Premium = (UI_btn_RewardSlot2)(object)((GComponent)this).GetChild("Premium");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		TargetLevel = (GTextField)((GComponent)this).GetChild("TargetLevel");
		n47 = (GGroup)((GComponent)this).GetChild("n47");
		Switch = ((GComponent)this).GetTransition("Switch");
	}
}
