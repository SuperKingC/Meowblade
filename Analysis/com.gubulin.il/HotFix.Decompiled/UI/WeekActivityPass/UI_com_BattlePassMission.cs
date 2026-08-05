using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivityPass;

public class UI_com_BattlePassMission : GComponent
{
	public GImage Background;

	public GList MissionList;

	public GTextField n15;

	public const string URL = "ui://11dkggb8nk8f1w";

	public static string Name = "UI_com_BattlePassMission";

	public static string GetURL()
	{
		return "ui://11dkggb8nk8f1w";
	}

	public static UI_com_BattlePassMission CreateInstance()
	{
		return (UI_com_BattlePassMission)(object)UIPackage.CreateObject("WeekActivityPass", "com_BattlePassMission");
	}

	public static UI_com_BattlePassMission CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BattlePassMission).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://11dkggb8nk8f1w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Background = (GImage)((GComponent)this).GetChild("Background");
		MissionList = (GList)((GComponent)this).GetChild("MissionList");
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id = "ui://11dkggb8nk8f1w".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id);
	}
}
