using FairyGUI;
using FairyGUI.Utils;

namespace UI.NewbieMission;

public class UI_MissionInfoDialog : GComponent
{
	public Controller State;

	public GTextField MissionDesc;

	public GTextField MissionValue;

	public GGraph n9;

	public GLoader missionRewardIcon;

	public GTextField MissionReward;

	public UI_GotoBtn GotoBtn;

	public GImage redNote;

	public GGroup showHide;

	public const string URL = "ui://kmmwvr7ck11jq";

	public static string Name = "UI_MissionInfoDialog";

	public static string GetURL()
	{
		return "ui://kmmwvr7ck11jq";
	}

	public static UI_MissionInfoDialog CreateInstance()
	{
		return (UI_MissionInfoDialog)(object)UIPackage.CreateObject("NewbieMission", "MissionInfoDialog");
	}

	public static UI_MissionInfoDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MissionInfoDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kmmwvr7ck11jq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		MissionDesc = (GTextField)((GComponent)this).GetChild("MissionDesc");
		MissionValue = (GTextField)((GComponent)this).GetChild("MissionValue");
		n9 = (GGraph)((GComponent)this).GetChild("n9");
		missionRewardIcon = (GLoader)((GComponent)this).GetChild("missionRewardIcon");
		MissionReward = (GTextField)((GComponent)this).GetChild("MissionReward");
		GotoBtn = (UI_GotoBtn)(object)((GComponent)this).GetChild("GotoBtn");
		redNote = (GImage)((GComponent)this).GetChild("redNote");
		showHide = (GGroup)((GComponent)this).GetChild("showHide");
	}
}
