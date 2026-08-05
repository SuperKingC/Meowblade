using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_btn_RewardSlot1 : GButton
{
	public Controller button;

	public Controller State;

	public GLoader Back;

	public GGraph SfxBack;

	public GMovieClip n15;

	public GLoader Icon;

	public GTextField Num;

	public GImage Claimed;

	public const string URL = "ui://bfjg32huq1eq2p";

	public static string Name = "UI_btn_RewardSlot1";

	public static string GetURL()
	{
		return "ui://bfjg32huq1eq2p";
	}

	public static UI_btn_RewardSlot1 CreateInstance()
	{
		return (UI_btn_RewardSlot1)(object)UIPackage.CreateObject("GvGBattlePass3", "btn_RewardSlot1");
	}

	public static UI_btn_RewardSlot1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_RewardSlot1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32huq1eq2p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		Back = (GLoader)((GComponent)this).GetChild("Back");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		n15 = (GMovieClip)((GComponent)this).GetChild("n15");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
		Claimed = (GImage)((GComponent)this).GetChild("Claimed");
	}
}
