using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivity;

public class UI_RewardSlot1 : GButton
{
	public Controller button;

	public Controller State;

	public GImage n16;

	public GImage n15;

	public GImage n18;

	public GLoader Back;

	public GLoader Icon;

	public GTextField Num;

	public GMovieClip n14;

	public GImage n17;

	public Transition t0;

	public const string URL = "ui://jl0c82y5ibyrp";

	public static string Name = "UI_RewardSlot1";

	public static string GetURL()
	{
		return "ui://jl0c82y5ibyrp";
	}

	public static UI_RewardSlot1 CreateInstance()
	{
		return (UI_RewardSlot1)(object)UIPackage.CreateObject("WeekActivity", "RewardSlot1");
	}

	public static UI_RewardSlot1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RewardSlot1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5ibyrp", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		Back = (GLoader)((GComponent)this).GetChild("Back");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
		n14 = (GMovieClip)((GComponent)this).GetChild("n14");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
