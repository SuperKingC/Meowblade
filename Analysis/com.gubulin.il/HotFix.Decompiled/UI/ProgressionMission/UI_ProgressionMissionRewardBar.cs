using FairyGUI;
using FairyGUI.Utils;

namespace UI.ProgressionMission;

public class UI_ProgressionMissionRewardBar : GComponent
{
	public Controller isAdvance;

	public Controller Status;

	public Controller isSelect;

	public GImage progressBarBg;

	public GImage n27;

	public const string URL = "ui://mapat4i5th6mv4ry";

	public static string Name = "UI_ProgressionMissionRewardBar";

	public static string GetURL()
	{
		return "ui://mapat4i5th6mv4ry";
	}

	public static UI_ProgressionMissionRewardBar CreateInstance()
	{
		return (UI_ProgressionMissionRewardBar)(object)UIPackage.CreateObject("ProgressionMission", "ProgressionMissionRewardBar");
	}

	public static UI_ProgressionMissionRewardBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProgressionMissionRewardBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://mapat4i5th6mv4ry", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		isAdvance = ((GComponent)this).GetController("isAdvance");
		Status = ((GComponent)this).GetController("Status");
		isSelect = ((GComponent)this).GetController("isSelect");
		progressBarBg = (GImage)((GComponent)this).GetChild("progressBarBg");
		n27 = (GImage)((GComponent)this).GetChild("n27");
	}
}
