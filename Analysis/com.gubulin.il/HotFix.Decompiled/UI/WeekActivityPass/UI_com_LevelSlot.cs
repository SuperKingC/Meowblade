using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivityPass;

public class UI_com_LevelSlot : GComponent
{
	public Controller button;

	public Controller Progress;

	public Controller IsSpecialNode;

	public GImage n52;

	public UI_btn_RewardSlot1 Basic;

	public UI_btn_RewardSlot2 Advanced;

	public UI_btn_RewardSlot2 Premium;

	public GImage n44;

	public GImage n45;

	public GImage n47;

	public GImage n43;

	public GMovieClip n51;

	public GLoader LevelIcon;

	public GTextField TargetLevel;

	public GGroup n53;

	public Transition t0;

	public const string URL = "ui://11dkggb8nk8f1c";

	public static string Name = "UI_com_LevelSlot";

	public static string GetURL()
	{
		return "ui://11dkggb8nk8f1c";
	}

	public static UI_com_LevelSlot CreateInstance()
	{
		return (UI_com_LevelSlot)(object)UIPackage.CreateObject("WeekActivityPass", "com_LevelSlot");
	}

	public static UI_com_LevelSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LevelSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://11dkggb8nk8f1c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Progress = ((GComponent)this).GetController("Progress");
		IsSpecialNode = ((GComponent)this).GetController("IsSpecialNode");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		Basic = (UI_btn_RewardSlot1)(object)((GComponent)this).GetChild("Basic");
		Advanced = (UI_btn_RewardSlot2)(object)((GComponent)this).GetChild("Advanced");
		Premium = (UI_btn_RewardSlot2)(object)((GComponent)this).GetChild("Premium");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		n51 = (GMovieClip)((GComponent)this).GetChild("n51");
		LevelIcon = (GLoader)((GComponent)this).GetChild("LevelIcon");
		TargetLevel = (GTextField)((GComponent)this).GetChild("TargetLevel");
		n53 = (GGroup)((GComponent)this).GetChild("n53");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
