using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivityPass;

public class UI_com_LevelSlot_Big : GComponent
{
	public Controller button;

	public GImage n40;

	public UI_btn_RewardSlot1 Basic;

	public UI_btn_RewardSlot2 Advanced;

	public UI_btn_RewardSlot2 Premium;

	public GImage n44;

	public GTextField TargetLevel;

	public GGroup n47;

	public Transition Switch;

	public const string URL = "ui://11dkggb8nk8f1q";

	public static string Name = "UI_com_LevelSlot_Big";

	public static string GetURL()
	{
		return "ui://11dkggb8nk8f1q";
	}

	public static UI_com_LevelSlot_Big CreateInstance()
	{
		return (UI_com_LevelSlot_Big)(object)UIPackage.CreateObject("WeekActivityPass", "com_LevelSlot_Big");
	}

	public static UI_com_LevelSlot_Big CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LevelSlot_Big).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://11dkggb8nk8f1q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		Basic = (UI_btn_RewardSlot1)(object)((GComponent)this).GetChild("Basic");
		Advanced = (UI_btn_RewardSlot2)(object)((GComponent)this).GetChild("Advanced");
		Premium = (UI_btn_RewardSlot2)(object)((GComponent)this).GetChild("Premium");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		TargetLevel = (GTextField)((GComponent)this).GetChild("TargetLevel");
		n47 = (GGroup)((GComponent)this).GetChild("n47");
		Switch = ((GComponent)this).GetTransition("Switch");
	}
}
