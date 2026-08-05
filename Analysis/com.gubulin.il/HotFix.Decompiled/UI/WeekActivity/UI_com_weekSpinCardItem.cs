using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivity;

public class UI_com_weekSpinCardItem : GComponent
{
	public Controller LevelState;

	public Controller Stage;

	public Controller TargetLevel;

	public UI_RewardSlot1 Normal;

	public UI_RewardSlot2 Advanced1;

	public GImage frame;

	public GImage n46;

	public GLoader n44;

	public const string URL = "ui://jl0c82y5ibyro";

	public static string Name = "UI_com_weekSpinCardItem";

	public static string GetURL()
	{
		return "ui://jl0c82y5ibyro";
	}

	public static UI_com_weekSpinCardItem CreateInstance()
	{
		return (UI_com_weekSpinCardItem)(object)UIPackage.CreateObject("WeekActivity", "com_weekSpinCardItem");
	}

	public static UI_com_weekSpinCardItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_weekSpinCardItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5ibyro", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		LevelState = ((GComponent)this).GetController("LevelState");
		Stage = ((GComponent)this).GetController("Stage");
		TargetLevel = ((GComponent)this).GetController("TargetLevel");
		Normal = (UI_RewardSlot1)(object)((GComponent)this).GetChild("Normal");
		Advanced1 = (UI_RewardSlot2)(object)((GComponent)this).GetChild("Advanced1");
		frame = (GImage)((GComponent)this).GetChild("frame");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n44 = (GLoader)((GComponent)this).GetChild("n44");
	}
}
