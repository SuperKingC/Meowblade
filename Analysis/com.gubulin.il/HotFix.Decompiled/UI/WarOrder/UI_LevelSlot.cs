using FairyGUI;
using FairyGUI.Utils;

namespace UI.WarOrder;

public class UI_LevelSlot : GComponent
{
	public Controller button;

	public Controller LevelState;

	public Controller AdvanceNum;

	public UI_RewardSlot1 Normal;

	public UI_RewardSlot2 Advanced1;

	public UI_RewardSlot2 Advanced2;

	public GImage frame;

	public GImage n41;

	public GTextField TargetLevel;

	public GImage n42;

	public const string URL = "ui://ax280w58p8iiu";

	public static string Name = "UI_LevelSlot";

	public static string GetURL()
	{
		return "ui://ax280w58p8iiu";
	}

	public static UI_LevelSlot CreateInstance()
	{
		return (UI_LevelSlot)(object)UIPackage.CreateObject("WarOrder", "LevelSlot");
	}

	public static UI_LevelSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LevelSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ax280w58p8iiu", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		LevelState = ((GComponent)this).GetController("LevelState");
		AdvanceNum = ((GComponent)this).GetController("AdvanceNum");
		Normal = (UI_RewardSlot1)(object)((GComponent)this).GetChild("Normal");
		Advanced1 = (UI_RewardSlot2)(object)((GComponent)this).GetChild("Advanced1");
		Advanced2 = (UI_RewardSlot2)(object)((GComponent)this).GetChild("Advanced2");
		frame = (GImage)((GComponent)this).GetChild("frame");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		TargetLevel = (GTextField)((GComponent)this).GetChild("TargetLevel");
		n42 = (GImage)((GComponent)this).GetChild("n42");
	}
}
