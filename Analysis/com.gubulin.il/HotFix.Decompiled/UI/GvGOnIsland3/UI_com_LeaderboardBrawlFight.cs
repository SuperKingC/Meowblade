using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_LeaderboardBrawlFight : GComponent
{
	public Controller Type;

	public Controller isEmpty;

	public Controller c2;

	public Controller isShowSwitchBtn;

	public GImage n83;

	public GImage n84;

	public GImage n85;

	public GImage n102;

	public GImage n103;

	public GImage n104;

	public GGroup n105;

	public GGroup n99;

	public GImage n90;

	public GImage n89;

	public GImage n88;

	public GImage n87;

	public GTextField n91;

	public GTextField n82;

	public GTextField n98;

	public GList CampRank;

	public GList PlayerRank;

	public GGroup RankGorup;

	public UI_btn_arrow n86;

	public UI_btn_RankingListSwitch Switch;

	public UI_btn_Help Help;

	public const string URL = "ui://ebc4ciwrj962q6j";

	public static string Name = "UI_com_LeaderboardBrawlFight";

	public static string GetURL()
	{
		return "ui://ebc4ciwrj962q6j";
	}

	public static UI_com_LeaderboardBrawlFight CreateInstance()
	{
		return (UI_com_LeaderboardBrawlFight)(object)UIPackage.CreateObject("GvGOnIsland3", "com_LeaderboardBrawlFight");
	}

	public static UI_com_LeaderboardBrawlFight CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LeaderboardBrawlFight).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrj962q6j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		isEmpty = ((GComponent)this).GetController("isEmpty");
		c2 = ((GComponent)this).GetController("c2");
		isShowSwitchBtn = ((GComponent)this).GetController("isShowSwitchBtn");
		n83 = (GImage)((GComponent)this).GetChild("n83");
		n84 = (GImage)((GComponent)this).GetChild("n84");
		n85 = (GImage)((GComponent)this).GetChild("n85");
		n102 = (GImage)((GComponent)this).GetChild("n102");
		n103 = (GImage)((GComponent)this).GetChild("n103");
		n104 = (GImage)((GComponent)this).GetChild("n104");
		n105 = (GGroup)((GComponent)this).GetChild("n105");
		n99 = (GGroup)((GComponent)this).GetChild("n99");
		n90 = (GImage)((GComponent)this).GetChild("n90");
		n89 = (GImage)((GComponent)this).GetChild("n89");
		n88 = (GImage)((GComponent)this).GetChild("n88");
		n87 = (GImage)((GComponent)this).GetChild("n87");
		n91 = (GTextField)((GComponent)this).GetChild("n91");
		string id = "ui://ebc4ciwrj962q6j".Replace("ui://", "") + "-" + ((GObject)n91).id;
		((GObject)n91).text = LanguagesManager.GetDesc(id);
		n82 = (GTextField)((GComponent)this).GetChild("n82");
		string id2 = "ui://ebc4ciwrj962q6j".Replace("ui://", "") + "-" + ((GObject)n82).id;
		((GObject)n82).text = LanguagesManager.GetDesc(id2);
		n98 = (GTextField)((GComponent)this).GetChild("n98");
		string id3 = "ui://ebc4ciwrj962q6j".Replace("ui://", "") + "-" + ((GObject)n98).id;
		((GObject)n98).text = LanguagesManager.GetDesc(id3);
		CampRank = (GList)((GComponent)this).GetChild("CampRank");
		PlayerRank = (GList)((GComponent)this).GetChild("PlayerRank");
		RankGorup = (GGroup)((GComponent)this).GetChild("RankGorup");
		n86 = (UI_btn_arrow)(object)((GComponent)this).GetChild("n86");
		Switch = (UI_btn_RankingListSwitch)(object)((GComponent)this).GetChild("Switch");
		Help = (UI_btn_Help)(object)((GComponent)this).GetChild("Help");
	}
}
