using FairyGUI;
using FairyGUI.Utils;

namespace UI.NewbieMission;

public class UI_MissionColumn : GComponent
{
	public Controller State;

	public Controller SummaryMissionStatus;

	public Controller Type;

	public GImage n4;

	public GImage n22;

	public GGroup n27;

	public GImage n24;

	public GImage n23;

	public GImage n25;

	public GImage n26;

	public GImage n5;

	public GImage n12;

	public GLoader summaryMissionRewardIcon;

	public GImage n11;

	public GTextField summaryMissionProgress;

	public UI_ArrowBtn arrowBtn;

	public GLoader secondRewardIcon;

	public GGraph SfxBack;

	public UI_MissionInfoDialog MissionDesc;

	public Transition UpdateMissionInfo;

	public const string URL = "ui://kmmwvr7ckk933";

	public static string Name = "UI_MissionColumn";

	public static string GetURL()
	{
		return "ui://kmmwvr7ckk933";
	}

	public static UI_MissionColumn CreateInstance()
	{
		return (UI_MissionColumn)(object)UIPackage.CreateObject("NewbieMission", "MissionColumn");
	}

	public static UI_MissionColumn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MissionColumn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kmmwvr7ckk933", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		SummaryMissionStatus = ((GComponent)this).GetController("SummaryMissionStatus");
		Type = ((GComponent)this).GetController("Type");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n27 = (GGroup)((GComponent)this).GetChild("n27");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		summaryMissionRewardIcon = (GLoader)((GComponent)this).GetChild("summaryMissionRewardIcon");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		summaryMissionProgress = (GTextField)((GComponent)this).GetChild("summaryMissionProgress");
		arrowBtn = (UI_ArrowBtn)(object)((GComponent)this).GetChild("arrowBtn");
		secondRewardIcon = (GLoader)((GComponent)this).GetChild("secondRewardIcon");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		MissionDesc = (UI_MissionInfoDialog)(object)((GComponent)this).GetChild("MissionDesc");
		UpdateMissionInfo = ((GComponent)this).GetTransition("UpdateMissionInfo");
	}
}
