using FairyGUI;
using FairyGUI.Utils;

namespace UI.FullScreenAnimation;

public class UI_SummaryMissionReward : GComponent
{
	public GLoader MissionTitle;

	public GLoader MissionIcon;

	public GTextField RewardNum;

	public const string URL = "ui://huhayyi1d0ym5";

	public static string Name = "UI_SummaryMissionReward";

	public static string GetURL()
	{
		return "ui://huhayyi1d0ym5";
	}

	public static UI_SummaryMissionReward CreateInstance()
	{
		return (UI_SummaryMissionReward)(object)UIPackage.CreateObject("FullScreenAnimation", "SummaryMissionReward");
	}

	public static UI_SummaryMissionReward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SummaryMissionReward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://huhayyi1d0ym5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		MissionTitle = (GLoader)((GComponent)this).GetChild("MissionTitle");
		MissionIcon = (GLoader)((GComponent)this).GetChild("MissionIcon");
		RewardNum = (GTextField)((GComponent)this).GetChild("RewardNum");
	}
}
