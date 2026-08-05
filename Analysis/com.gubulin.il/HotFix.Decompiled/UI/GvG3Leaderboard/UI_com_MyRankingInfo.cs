using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Leaderboard;

public class UI_com_MyRankingInfo : GComponent
{
	public Controller RankingTopThree;

	public Controller BonusState;

	public Controller RankingType;

	public Controller IsEmpty;

	public GImage n181;

	public GImage n183;

	public GTextField n182;

	public GImage n184;

	public GTextField EmptyTip;

	public GTextField PlayerName;

	public GLoader RankingTypeIcon;

	public GTextField RankingData;

	public UI_com_Item BonusItem;

	public GMovieClip n192;

	public GImage n194;

	public GImage n193;

	public GImage n195;

	public GLoader n185;

	public GTextField Ranking;

	public GGroup n197;

	public GTextField n198;

	public UI_btn_MyContribution myContributionBtn;

	public UI_btn_01 showDetailBtn;

	public const string URL = "ui://ylvfgf90530y5s";

	public static string Name = "UI_com_MyRankingInfo";

	public static string GetURL()
	{
		return "ui://ylvfgf90530y5s";
	}

	public static UI_com_MyRankingInfo CreateInstance()
	{
		return (UI_com_MyRankingInfo)(object)UIPackage.CreateObject("GvG3Leaderboard", "com_MyRankingInfo");
	}

	public static UI_com_MyRankingInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MyRankingInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ylvfgf90530y5s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RankingTopThree = ((GComponent)this).GetController("RankingTopThree");
		BonusState = ((GComponent)this).GetController("BonusState");
		RankingType = ((GComponent)this).GetController("RankingType");
		IsEmpty = ((GComponent)this).GetController("IsEmpty");
		n181 = (GImage)((GComponent)this).GetChild("n181");
		n183 = (GImage)((GComponent)this).GetChild("n183");
		n182 = (GTextField)((GComponent)this).GetChild("n182");
		string id = "ui://ylvfgf90530y5s".Replace("ui://", "") + "-" + ((GObject)n182).id;
		((GObject)n182).text = LanguagesManager.GetDesc(id);
		n184 = (GImage)((GComponent)this).GetChild("n184");
		EmptyTip = (GTextField)((GComponent)this).GetChild("EmptyTip");
		string id2 = "ui://ylvfgf90530y5s".Replace("ui://", "") + "-" + ((GObject)EmptyTip).id;
		((GObject)EmptyTip).text = LanguagesManager.GetDesc(id2);
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		RankingTypeIcon = (GLoader)((GComponent)this).GetChild("RankingTypeIcon");
		RankingData = (GTextField)((GComponent)this).GetChild("RankingData");
		BonusItem = (UI_com_Item)(object)((GComponent)this).GetChild("BonusItem");
		n192 = (GMovieClip)((GComponent)this).GetChild("n192");
		n194 = (GImage)((GComponent)this).GetChild("n194");
		n193 = (GImage)((GComponent)this).GetChild("n193");
		n195 = (GImage)((GComponent)this).GetChild("n195");
		n185 = (GLoader)((GComponent)this).GetChild("n185");
		Ranking = (GTextField)((GComponent)this).GetChild("Ranking");
		n197 = (GGroup)((GComponent)this).GetChild("n197");
		n198 = (GTextField)((GComponent)this).GetChild("n198");
		string id3 = "ui://ylvfgf90530y5s".Replace("ui://", "") + "-" + ((GObject)n198).id;
		((GObject)n198).text = LanguagesManager.GetDesc(id3);
		myContributionBtn = (UI_btn_MyContribution)(object)((GComponent)this).GetChild("myContributionBtn");
		showDetailBtn = (UI_btn_01)(object)((GComponent)this).GetChild("showDetailBtn");
	}
}
