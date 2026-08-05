using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivityPass;

public class UI_btn_RewardSlot1 : GButton
{
	public Controller button;

	public Controller State;

	public GImage n16;

	public GLoader Back;

	public GLoader Icon;

	public GTextField Num;

	public GImage Claimed;

	public GGraph SfxBack;

	public GMovieClip n15;

	public Transition t0;

	public const string URL = "ui://11dkggb8nk8f6";

	public static string Name = "UI_btn_RewardSlot1";

	public static string GetURL()
	{
		return "ui://11dkggb8nk8f6";
	}

	public static UI_btn_RewardSlot1 CreateInstance()
	{
		return (UI_btn_RewardSlot1)(object)UIPackage.CreateObject("WeekActivityPass", "btn_RewardSlot1");
	}

	public static UI_btn_RewardSlot1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_RewardSlot1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://11dkggb8nk8f6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		Back = (GLoader)((GComponent)this).GetChild("Back");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
		Claimed = (GImage)((GComponent)this).GetChild("Claimed");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		n15 = (GMovieClip)((GComponent)this).GetChild("n15");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
