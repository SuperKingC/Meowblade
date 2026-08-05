using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_TopTournamentScoreRankInfo : GComponent
{
	public Controller RankType;

	public Controller SelfType;

	public GImage n24;

	public GImage n25;

	public GImage n26;

	public GImage n28;

	public UI_RankingListAvatar Avatar;

	public GImage n1;

	public GImage n2;

	public GImage n3;

	public GTextField UserName;

	public GImage n17;

	public GImage n14;

	public GImage n15;

	public GImage n16;

	public GTextField CombatPower;

	public GTextField TotalScore;

	public UI_RankListLevelDiy Rank;

	public GImage n27;

	public GTextField n29;

	public GList medalList;

	public const string URL = "ui://82mo10n5t7wpdg9";

	public static string Name = "UI_TopTournamentScoreRankInfo";

	public static string GetURL()
	{
		return "ui://82mo10n5t7wpdg9";
	}

	public static UI_TopTournamentScoreRankInfo CreateInstance()
	{
		return (UI_TopTournamentScoreRankInfo)(object)UIPackage.CreateObject("PvpSelectSoldiers", "TopTournamentScoreRankInfo");
	}

	public static UI_TopTournamentScoreRankInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TopTournamentScoreRankInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5t7wpdg9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RankType = ((GComponent)this).GetController("RankType");
		SelfType = ((GComponent)this).GetController("SelfType");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		Avatar = (UI_RankingListAvatar)(object)((GComponent)this).GetChild("Avatar");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		UserName = (GTextField)((GComponent)this).GetChild("UserName");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		CombatPower = (GTextField)((GComponent)this).GetChild("CombatPower");
		TotalScore = (GTextField)((GComponent)this).GetChild("TotalScore");
		Rank = (UI_RankListLevelDiy)(object)((GComponent)this).GetChild("Rank");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n29 = (GTextField)((GComponent)this).GetChild("n29");
		string id = "ui://82mo10n5t7wpdg9".Replace("ui://", "") + "-" + ((GObject)n29).id;
		((GObject)n29).text = LanguagesManager.GetDesc(id);
		medalList = (GList)((GComponent)this).GetChild("medalList");
	}
}
