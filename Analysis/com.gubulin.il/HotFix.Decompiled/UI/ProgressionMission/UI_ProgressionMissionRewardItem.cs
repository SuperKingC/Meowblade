using FairyGUI;
using FairyGUI.Utils;

namespace UI.ProgressionMission;

public class UI_ProgressionMissionRewardItem : GComponent
{
	public Controller isAdvance;

	public Controller Status;

	public Controller isSelect;

	public GImage bg;

	public GImage n31;

	public GImage n24;

	public GImage n23;

	public GLoader rewardIcon;

	public GTextField Num;

	public GLoader n32;

	public GLoader n34;

	public GGroup grayGroup;

	public GMovieClip n35;

	public GMovieClip n28;

	public GImage progressBarBg;

	public GImage n27;

	public GImage scoreBg2;

	public GImage n30;

	public GImage scoreBg;

	public GImage n26;

	public GTextField score;

	public Transition t2;

	public const string URL = "ui://mapat4i5elte8d";

	public static string Name = "UI_ProgressionMissionRewardItem";

	public static string GetURL()
	{
		return "ui://mapat4i5elte8d";
	}

	public static UI_ProgressionMissionRewardItem CreateInstance()
	{
		return (UI_ProgressionMissionRewardItem)(object)UIPackage.CreateObject("ProgressionMission", "ProgressionMissionRewardItem");
	}

	public static UI_ProgressionMissionRewardItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProgressionMissionRewardItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://mapat4i5elte8d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		isAdvance = ((GComponent)this).GetController("isAdvance");
		Status = ((GComponent)this).GetController("Status");
		isSelect = ((GComponent)this).GetController("isSelect");
		bg = (GImage)((GComponent)this).GetChild("bg");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		rewardIcon = (GLoader)((GComponent)this).GetChild("rewardIcon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
		n32 = (GLoader)((GComponent)this).GetChild("n32");
		n34 = (GLoader)((GComponent)this).GetChild("n34");
		grayGroup = (GGroup)((GComponent)this).GetChild("grayGroup");
		n35 = (GMovieClip)((GComponent)this).GetChild("n35");
		n28 = (GMovieClip)((GComponent)this).GetChild("n28");
		progressBarBg = (GImage)((GComponent)this).GetChild("progressBarBg");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		scoreBg2 = (GImage)((GComponent)this).GetChild("scoreBg2");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		scoreBg = (GImage)((GComponent)this).GetChild("scoreBg");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		score = (GTextField)((GComponent)this).GetChild("score");
		t2 = ((GComponent)this).GetTransition("t2");
	}
}
