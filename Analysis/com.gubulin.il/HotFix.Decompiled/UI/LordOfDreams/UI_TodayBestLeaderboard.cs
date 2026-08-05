using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_TodayBestLeaderboard : GComponent
{
	public Controller HasMission;

	public GImage n3;

	public GImage n13;

	public GList List;

	public GTextField n16;

	public GTextField n18;

	public GTextField TodayTotalScore;

	public GImage n20;

	public GImage n21;

	public GGraph n24;

	public GList ScoreBonusList;

	public UI_BonusDetailBtn BonusDetailBtn;

	public UI_ScoreHistoryPanel ScoreHistoryPanel;

	public GGraph Help;

	public GButton HelpBtn;

	public GTextField n30;

	public const string URL = "ui://0i520nzmb529o8b";

	public static string Name = "UI_TodayBestLeaderboard";

	public static string GetURL()
	{
		return "ui://0i520nzmb529o8b";
	}

	public static UI_TodayBestLeaderboard CreateInstance()
	{
		return (UI_TodayBestLeaderboard)(object)UIPackage.CreateObject("LordOfDreams", "TodayBestLeaderboard");
	}

	public static UI_TodayBestLeaderboard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TodayBestLeaderboard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmb529o8b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		HasMission = ((GComponent)this).GetController("HasMission");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		List = (GList)((GComponent)this).GetChild("List");
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id = "ui://0i520nzmb529o8b".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id);
		n18 = (GTextField)((GComponent)this).GetChild("n18");
		string id2 = "ui://0i520nzmb529o8b".Replace("ui://", "") + "-" + ((GObject)n18).id;
		((GObject)n18).text = LanguagesManager.GetDesc(id2);
		TodayTotalScore = (GTextField)((GComponent)this).GetChild("TodayTotalScore");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n24 = (GGraph)((GComponent)this).GetChild("n24");
		ScoreBonusList = (GList)((GComponent)this).GetChild("ScoreBonusList");
		BonusDetailBtn = (UI_BonusDetailBtn)(object)((GComponent)this).GetChild("BonusDetailBtn");
		ScoreHistoryPanel = (UI_ScoreHistoryPanel)(object)((GComponent)this).GetChild("ScoreHistoryPanel");
		Help = (GGraph)((GComponent)this).GetChild("Help");
		HelpBtn = (GButton)((GComponent)this).GetChild("HelpBtn");
		n30 = (GTextField)((GComponent)this).GetChild("n30");
		string id3 = "ui://0i520nzmb529o8b".Replace("ui://", "") + "-" + ((GObject)n30).id;
		((GObject)n30).text = LanguagesManager.GetDesc(id3);
	}
}
