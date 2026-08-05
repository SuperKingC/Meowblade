using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WarOrder;

public class UI_WarOrderMissionDialog : GComponent
{
	public GImage Background;

	public GTextField Progress;

	public GList MissionList;

	public GTextField n15;

	public GTextField n16;

	public const string URL = "ui://ax280w58okbc25";

	public static string Name = "UI_WarOrderMissionDialog";

	public static string GetURL()
	{
		return "ui://ax280w58okbc25";
	}

	public static UI_WarOrderMissionDialog CreateInstance()
	{
		return (UI_WarOrderMissionDialog)(object)UIPackage.CreateObject("WarOrder", "WarOrderMissionDialog");
	}

	public static UI_WarOrderMissionDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WarOrderMissionDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ax280w58okbc25", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Background = (GImage)((GComponent)this).GetChild("Background");
		Progress = (GTextField)((GComponent)this).GetChild("Progress");
		MissionList = (GList)((GComponent)this).GetChild("MissionList");
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id = "ui://ax280w58okbc25".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id);
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id2 = "ui://ax280w58okbc25".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id2);
	}
}
