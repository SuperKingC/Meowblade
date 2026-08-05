using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_com_BattlePassMission : GComponent
{
	public Controller contribute;

	public GImage Background;

	public GList MissionList;

	public GTextField n15;

	public GImage n17;

	public const string URL = "ui://bfjg32huq1eq4a";

	public static string Name = "UI_com_BattlePassMission";

	public static string GetURL()
	{
		return "ui://bfjg32huq1eq4a";
	}

	public static UI_com_BattlePassMission CreateInstance()
	{
		return (UI_com_BattlePassMission)(object)UIPackage.CreateObject("GvGBattlePass3", "com_BattlePassMission");
	}

	public static UI_com_BattlePassMission CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BattlePassMission).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32huq1eq4a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		contribute = ((GComponent)this).GetController("contribute");
		Background = (GImage)((GComponent)this).GetChild("Background");
		MissionList = (GList)((GComponent)this).GetChild("MissionList");
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id = "ui://bfjg32huq1eq4a".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id);
		n17 = (GImage)((GComponent)this).GetChild("n17");
	}
}
