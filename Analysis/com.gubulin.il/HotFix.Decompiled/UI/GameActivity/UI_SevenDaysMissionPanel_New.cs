using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_SevenDaysMissionPanel_New : GComponent
{
	public GImage n63;

	public GImage n64;

	public GImage n65;

	public UI_MissionProgress MissionProgress;

	public GList missionTabList;

	public UI_MissionAchievementList MissionAchievementList;

	public UI_MissionGiftPack_New MissionGiftPack_Free;

	public UI_MissionGiftPack_New MissionGiftPack_Pay;

	public GGraph AimAchievementListTop;

	public GGraph AimAchievementListBottom;

	public GTextField tip1;

	public GTextField tip2;

	public const string URL = "ui://29q48tv6j6fy7y";

	public static string Name = "UI_SevenDaysMissionPanel_New";

	public static string GetURL()
	{
		return "ui://29q48tv6j6fy7y";
	}

	public static UI_SevenDaysMissionPanel_New CreateInstance()
	{
		return (UI_SevenDaysMissionPanel_New)(object)UIPackage.CreateObject("GameActivity", "SevenDaysMissionPanel_New");
	}

	public static UI_SevenDaysMissionPanel_New CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SevenDaysMissionPanel_New).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6j6fy7y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n63 = (GImage)((GComponent)this).GetChild("n63");
		n64 = (GImage)((GComponent)this).GetChild("n64");
		n65 = (GImage)((GComponent)this).GetChild("n65");
		MissionProgress = (UI_MissionProgress)(object)((GComponent)this).GetChild("MissionProgress");
		missionTabList = (GList)((GComponent)this).GetChild("missionTabList");
		MissionAchievementList = (UI_MissionAchievementList)(object)((GComponent)this).GetChild("MissionAchievementList");
		MissionGiftPack_Free = (UI_MissionGiftPack_New)(object)((GComponent)this).GetChild("MissionGiftPack_Free");
		MissionGiftPack_Pay = (UI_MissionGiftPack_New)(object)((GComponent)this).GetChild("MissionGiftPack_Pay");
		AimAchievementListTop = (GGraph)((GComponent)this).GetChild("AimAchievementListTop");
		AimAchievementListBottom = (GGraph)((GComponent)this).GetChild("AimAchievementListBottom");
		tip1 = (GTextField)((GComponent)this).GetChild("tip1");
		string id = "ui://29q48tv6j6fy7y".Replace("ui://", "") + "-" + ((GObject)tip1).id;
		((GObject)tip1).text = LanguagesManager.GetDesc(id);
		tip2 = (GTextField)((GComponent)this).GetChild("tip2");
		string id2 = "ui://29q48tv6j6fy7y".Replace("ui://", "") + "-" + ((GObject)tip2).id;
		((GObject)tip2).text = LanguagesManager.GetDesc(id2);
	}
}
