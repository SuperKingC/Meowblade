using FairyGUI;
using FairyGUI.Utils;

namespace UI.WarOrder;

public class UI_LevelSlot_Big : GComponent
{
	public Controller button;

	public Controller LevelState;

	public Controller AdvanceNum;

	public GImage n40;

	public UI_RewardSlot1 Normal;

	public UI_RewardSlot2 Advanced1;

	public UI_RewardSlot2 Advanced2;

	public GImage frame;

	public GTextField TargetLevel;

	public UI_SlotBuyBtn SlotBuyBtn;

	public GImage n42;

	public Transition Switch;

	public const string URL = "ui://ax280w58okbc3d";

	public static string Name = "UI_LevelSlot_Big";

	public static string GetURL()
	{
		return "ui://ax280w58okbc3d";
	}

	public static UI_LevelSlot_Big CreateInstance()
	{
		return (UI_LevelSlot_Big)(object)UIPackage.CreateObject("WarOrder", "LevelSlot_Big");
	}

	public static UI_LevelSlot_Big CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LevelSlot_Big).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ax280w58okbc3d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		LevelState = ((GComponent)this).GetController("LevelState");
		AdvanceNum = ((GComponent)this).GetController("AdvanceNum");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		Normal = (UI_RewardSlot1)(object)((GComponent)this).GetChild("Normal");
		Advanced1 = (UI_RewardSlot2)(object)((GComponent)this).GetChild("Advanced1");
		Advanced2 = (UI_RewardSlot2)(object)((GComponent)this).GetChild("Advanced2");
		frame = (GImage)((GComponent)this).GetChild("frame");
		TargetLevel = (GTextField)((GComponent)this).GetChild("TargetLevel");
		SlotBuyBtn = (UI_SlotBuyBtn)(object)((GComponent)this).GetChild("SlotBuyBtn");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		Switch = ((GComponent)this).GetTransition("Switch");
	}
}
