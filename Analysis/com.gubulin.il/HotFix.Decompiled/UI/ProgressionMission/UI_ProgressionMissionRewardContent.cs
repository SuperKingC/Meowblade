using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.ProgressionMission;

public class UI_ProgressionMissionRewardContent : GComponent
{
	public GList AdvanceRewardList;

	public GList rewardProgressList;

	public GList rewardList;

	public GTextField n2;

	public const string URL = "ui://mapat4i5t2e69h";

	public static string Name = "UI_ProgressionMissionRewardContent";

	public static string GetURL()
	{
		return "ui://mapat4i5t2e69h";
	}

	public static UI_ProgressionMissionRewardContent CreateInstance()
	{
		return (UI_ProgressionMissionRewardContent)(object)UIPackage.CreateObject("ProgressionMission", "ProgressionMissionRewardContent");
	}

	public static UI_ProgressionMissionRewardContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProgressionMissionRewardContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://mapat4i5t2e69h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		AdvanceRewardList = (GList)((GComponent)this).GetChild("AdvanceRewardList");
		rewardProgressList = (GList)((GComponent)this).GetChild("rewardProgressList");
		rewardList = (GList)((GComponent)this).GetChild("rewardList");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://mapat4i5t2e69h".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
	}
}
