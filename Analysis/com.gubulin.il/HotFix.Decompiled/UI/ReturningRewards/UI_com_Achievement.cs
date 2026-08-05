using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_com_Achievement : GComponent
{
	public Controller State;

	public Controller HasJumpUi;

	public GImage back;

	public GImage n22;

	public GImage n21;

	public GImage n16;

	public GTextField Desc;

	public GTextField Value;

	public GLoader RewardIcon;

	public GTextField RewardNum;

	public UI_btn_Jump Jump;

	public GImage mask;

	public GImage n18;

	public GImage mask2;

	public GTextField LevelCase;

	public GImage n26;

	public Transition t0;

	public const string URL = "ui://rx5ntv98win23";

	public static string Name = "UI_com_Achievement";

	public static string GetURL()
	{
		return "ui://rx5ntv98win23";
	}

	public static UI_com_Achievement CreateInstance()
	{
		return (UI_com_Achievement)(object)UIPackage.CreateObject("ReturningRewards", "com_Achievement");
	}

	public static UI_com_Achievement CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Achievement).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98win23", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		HasJumpUi = ((GComponent)this).GetController("HasJumpUi");
		back = (GImage)((GComponent)this).GetChild("back");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		Value = (GTextField)((GComponent)this).GetChild("Value");
		RewardIcon = (GLoader)((GComponent)this).GetChild("RewardIcon");
		RewardNum = (GTextField)((GComponent)this).GetChild("RewardNum");
		Jump = (UI_btn_Jump)(object)((GComponent)this).GetChild("Jump");
		mask = (GImage)((GComponent)this).GetChild("mask");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		mask2 = (GImage)((GComponent)this).GetChild("mask2");
		LevelCase = (GTextField)((GComponent)this).GetChild("LevelCase");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
