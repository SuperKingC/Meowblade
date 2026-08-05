using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivityPass;

public class UI_btn_RewardSlot2 : GButton
{
	public Controller button;

	public Controller State;

	public Controller Lock;

	public Controller Type;

	public GImage n20;

	public GLoader Back;

	public GMovieClip n19;

	public GGraph SfxBack2;

	public GGraph SfxBack;

	public GLoader Icon;

	public GMovieClip n17;

	public GGroup n18;

	public GTextField Num;

	public GImage n14;

	public GImage Claimed;

	public Transition t0;

	public const string URL = "ui://11dkggb8nk8f9";

	public static string Name = "UI_btn_RewardSlot2";

	public static string GetURL()
	{
		return "ui://11dkggb8nk8f9";
	}

	public static UI_btn_RewardSlot2 CreateInstance()
	{
		return (UI_btn_RewardSlot2)(object)UIPackage.CreateObject("WeekActivityPass", "btn_RewardSlot2");
	}

	public static UI_btn_RewardSlot2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_RewardSlot2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://11dkggb8nk8f9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		Lock = ((GComponent)this).GetController("Lock");
		Type = ((GComponent)this).GetController("Type");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		Back = (GLoader)((GComponent)this).GetChild("Back");
		n19 = (GMovieClip)((GComponent)this).GetChild("n19");
		SfxBack2 = (GGraph)((GComponent)this).GetChild("SfxBack2");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n17 = (GMovieClip)((GComponent)this).GetChild("n17");
		n18 = (GGroup)((GComponent)this).GetChild("n18");
		Num = (GTextField)((GComponent)this).GetChild("Num");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		Claimed = (GImage)((GComponent)this).GetChild("Claimed");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
