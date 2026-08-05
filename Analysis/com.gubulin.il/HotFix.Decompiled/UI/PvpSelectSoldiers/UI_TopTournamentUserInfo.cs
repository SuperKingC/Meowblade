using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_TopTournamentUserInfo : GComponent
{
	public Controller RankType;

	public Controller SelfType;

	public Controller HighlyStyle;

	public GImage n6;

	public GImage n7;

	public GImage n8;

	public GImage n9;

	public UI_RankingListAvatar Avatar;

	public GImage n1;

	public GGroup n28;

	public GImage n2;

	public GImage n3;

	public GImage n17;

	public GImage n14;

	public GImage n15;

	public GImage n16;

	public GTextField TotalScore;

	public UI_RankListLevelDiy Rank;

	public GImage n24;

	public GButton Help;

	public GList medalList;

	public GTextField UserName;

	public GTextField CombatPower;

	public GTextField n26;

	public GGroup n29;

	public const string URL = "ui://82mo10n5aveldh9";

	public static string Name = "UI_TopTournamentUserInfo";

	public static string GetURL()
	{
		return "ui://82mo10n5aveldh9";
	}

	public static UI_TopTournamentUserInfo CreateInstance()
	{
		return (UI_TopTournamentUserInfo)(object)UIPackage.CreateObject("PvpSelectSoldiers", "TopTournamentUserInfo");
	}

	public static UI_TopTournamentUserInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TopTournamentUserInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5aveldh9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
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
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RankType = ((GComponent)this).GetController("RankType");
		SelfType = ((GComponent)this).GetController("SelfType");
		HighlyStyle = ((GComponent)this).GetController("HighlyStyle");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		Avatar = (UI_RankingListAvatar)(object)((GComponent)this).GetChild("Avatar");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n28 = (GGroup)((GComponent)this).GetChild("n28");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		TotalScore = (GTextField)((GComponent)this).GetChild("TotalScore");
		Rank = (UI_RankListLevelDiy)(object)((GComponent)this).GetChild("Rank");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		Help = (GButton)((GComponent)this).GetChild("Help");
		medalList = (GList)((GComponent)this).GetChild("medalList");
		UserName = (GTextField)((GComponent)this).GetChild("UserName");
		CombatPower = (GTextField)((GComponent)this).GetChild("CombatPower");
		n26 = (GTextField)((GComponent)this).GetChild("n26");
		string id = "ui://82mo10n5aveldh9".Replace("ui://", "") + "-" + ((GObject)n26).id;
		((GObject)n26).text = LanguagesManager.GetDesc(id);
		n29 = (GGroup)((GComponent)this).GetChild("n29");
	}
}
