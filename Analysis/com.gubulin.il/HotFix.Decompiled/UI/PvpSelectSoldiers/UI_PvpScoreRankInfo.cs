using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_PvpScoreRankInfo : GComponent
{
	public Controller RankType;

	public Controller SelfType;

	public UI_RankingListAvatar Avatar;

	public GImage n1;

	public GImage n2;

	public GImage n3;

	public GImage n6;

	public GImage n7;

	public GImage n8;

	public GGraph n9;

	public GImage n10;

	public GTextField UserName;

	public GTextField ScoreBonus;

	public GImage n22;

	public GImage n13;

	public GImage n17;

	public GImage n14;

	public GImage n15;

	public GImage n16;

	public GTextField CombatPower;

	public GTextField TotalScore;

	public UI_RankListLevelDiy Rank;

	public const string URL = "ui://82mo10n5lt7m9g";

	public static string Name = "UI_PvpScoreRankInfo";

	public static string GetURL()
	{
		return "ui://82mo10n5lt7m9g";
	}

	public static UI_PvpScoreRankInfo CreateInstance()
	{
		return (UI_PvpScoreRankInfo)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvpScoreRankInfo");
	}

	public static UI_PvpScoreRankInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpScoreRankInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5lt7m9g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
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
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RankType = ((GComponent)this).GetController("RankType");
		SelfType = ((GComponent)this).GetController("SelfType");
		Avatar = (UI_RankingListAvatar)(object)((GComponent)this).GetChild("Avatar");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GGraph)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		UserName = (GTextField)((GComponent)this).GetChild("UserName");
		ScoreBonus = (GTextField)((GComponent)this).GetChild("ScoreBonus");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		CombatPower = (GTextField)((GComponent)this).GetChild("CombatPower");
		TotalScore = (GTextField)((GComponent)this).GetChild("TotalScore");
		Rank = (UI_RankListLevelDiy)(object)((GComponent)this).GetChild("Rank");
	}
}
