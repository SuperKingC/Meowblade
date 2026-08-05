using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_islandInfoDisplay : GComponent
{
	public Controller hasMyShip;

	public Controller fightStatus;

	public Controller hasReward;

	public Controller islandType;

	public GImage n16;

	public GImage n17;

	public GImage n18;

	public UI_com_IslandReward rewardGroup;

	public UI_com_IslandName islandName;

	public UI_com_IslandStatus enrollCount;

	public UI_com_IslandShip myShipIcon;

	public UI_com_IslandWinCampIcon winCampIcon;

	public GMovieClip n19;

	public GMovieClip fightIcon;

	public UI_com_CampMvpAvatar Mvp;

	public const string URL = "ui://hozu168rllu55s";

	public static string Name = "UI_com_islandInfoDisplay";

	public static string GetURL()
	{
		return "ui://hozu168rllu55s";
	}

	public static UI_com_islandInfoDisplay CreateInstance()
	{
		return (UI_com_islandInfoDisplay)(object)UIPackage.CreateObject("GvGBrawlFight", "com_islandInfoDisplay");
	}

	public static UI_com_islandInfoDisplay CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_islandInfoDisplay).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rllu55s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		hasMyShip = ((GComponent)this).GetController("hasMyShip");
		fightStatus = ((GComponent)this).GetController("fightStatus");
		hasReward = ((GComponent)this).GetController("hasReward");
		islandType = ((GComponent)this).GetController("islandType");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		rewardGroup = (UI_com_IslandReward)(object)((GComponent)this).GetChild("rewardGroup");
		islandName = (UI_com_IslandName)(object)((GComponent)this).GetChild("islandName");
		enrollCount = (UI_com_IslandStatus)(object)((GComponent)this).GetChild("enrollCount");
		myShipIcon = (UI_com_IslandShip)(object)((GComponent)this).GetChild("myShipIcon");
		winCampIcon = (UI_com_IslandWinCampIcon)(object)((GComponent)this).GetChild("winCampIcon");
		n19 = (GMovieClip)((GComponent)this).GetChild("n19");
		fightIcon = (GMovieClip)((GComponent)this).GetChild("fightIcon");
		Mvp = (UI_com_CampMvpAvatar)(object)((GComponent)this).GetChild("Mvp");
	}
}
