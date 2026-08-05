using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivityPass;

public class UI_com_DailyrMissionDialog : GComponent
{
	public GImage Background;

	public GImage n18;

	public GImage n20;

	public GTextField Progress;

	public GList MissionList;

	public GTextField n16;

	public GTextField n19;

	public const string URL = "ui://11dkggb8dhmu33";

	public static string Name = "UI_com_DailyrMissionDialog";

	public static string GetURL()
	{
		return "ui://11dkggb8dhmu33";
	}

	public static UI_com_DailyrMissionDialog CreateInstance()
	{
		return (UI_com_DailyrMissionDialog)(object)UIPackage.CreateObject("WeekActivityPass", "com_DailyrMissionDialog");
	}

	public static UI_com_DailyrMissionDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_DailyrMissionDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://11dkggb8dhmu33", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Background = (GImage)((GComponent)this).GetChild("Background");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		Progress = (GTextField)((GComponent)this).GetChild("Progress");
		MissionList = (GList)((GComponent)this).GetChild("MissionList");
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id = "ui://11dkggb8dhmu33".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id);
		n19 = (GTextField)((GComponent)this).GetChild("n19");
		string id2 = "ui://11dkggb8dhmu33".Replace("ui://", "") + "-" + ((GObject)n19).id;
		((GObject)n19).text = LanguagesManager.GetDesc(id2);
	}
}
