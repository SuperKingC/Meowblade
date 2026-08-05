using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_btn_BattleScore : GButton
{
	public Controller button;

	public Controller ScoreType;

	public Controller RankType;

	public Controller HasScore;

	public GImage n3;

	public UI_com_CampIcon CampIcon;

	public GComponent ShipRace;

	public GLoader icon;

	public GTextField Score;

	public UI_com_ScoreRanking Ranking;

	public UI_tbn_ExclamationMarkBtn Buff;

	public GGroup n9;

	public GTextField n10;

	public const string URL = "ui://hozu168rqkbp4g";

	public static string Name = "UI_btn_BattleScore";

	public static string GetURL()
	{
		return "ui://hozu168rqkbp4g";
	}

	public static UI_btn_BattleScore CreateInstance()
	{
		return (UI_btn_BattleScore)(object)UIPackage.CreateObject("GvGBrawlFight", "btn_BattleScore");
	}

	public static UI_btn_BattleScore CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BattleScore).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rqkbp4g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		ScoreType = ((GComponent)this).GetController("ScoreType");
		RankType = ((GComponent)this).GetController("RankType");
		HasScore = ((GComponent)this).GetController("HasScore");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		CampIcon = (UI_com_CampIcon)(object)((GComponent)this).GetChild("CampIcon");
		ShipRace = (GComponent)((GComponent)this).GetChild("ShipRace");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		Score = (GTextField)((GComponent)this).GetChild("Score");
		string id = "ui://hozu168rqkbp4g".Replace("ui://", "") + "-" + ((GObject)Score).id;
		((GObject)Score).text = LanguagesManager.GetDesc(id);
		Ranking = (UI_com_ScoreRanking)(object)((GComponent)this).GetChild("Ranking");
		Buff = (UI_tbn_ExclamationMarkBtn)(object)((GComponent)this).GetChild("Buff");
		n9 = (GGroup)((GComponent)this).GetChild("n9");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id2 = "ui://hozu168rqkbp4g".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id2);
	}
}
