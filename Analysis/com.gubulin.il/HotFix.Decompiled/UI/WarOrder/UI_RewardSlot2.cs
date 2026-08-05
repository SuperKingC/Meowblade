using FairyGUI;
using FairyGUI.Utils;

namespace UI.WarOrder;

public class UI_RewardSlot2 : GButton
{
	public Controller button;

	public Controller State;

	public Controller IsAdvancedMode;

	public GLoader Back;

	public GGraph SfxBack2;

	public GGraph SfxBack;

	public GLoader Icon;

	public GTextField Num;

	public GImage n14;

	public GImage Claimed;

	public const string URL = "ui://ax280w58okbc1k";

	public static string Name = "UI_RewardSlot2";

	public static string GetURL()
	{
		return "ui://ax280w58okbc1k";
	}

	public static UI_RewardSlot2 CreateInstance()
	{
		return (UI_RewardSlot2)(object)UIPackage.CreateObject("WarOrder", "RewardSlot2");
	}

	public static UI_RewardSlot2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RewardSlot2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ax280w58okbc1k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
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
		State = ((GComponent)this).GetController("State");
		IsAdvancedMode = ((GComponent)this).GetController("IsAdvancedMode");
		Back = (GLoader)((GComponent)this).GetChild("Back");
		SfxBack2 = (GGraph)((GComponent)this).GetChild("SfxBack2");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		Claimed = (GImage)((GComponent)this).GetChild("Claimed");
	}
}
