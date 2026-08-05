using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_TopTournamentHistoryRankListDialog : GComponent
{
	public Controller Type;

	public GImage Background;

	public GImage n14;

	public GList ScoreRankingList;

	public GTextField tip;

	public UI_EveryDayLogTitleList DayIndexList;

	public GTextField n16;

	public const string URL = "ui://82mo10n5zgaedhk";

	public static string Name = "UI_TopTournamentHistoryRankListDialog";

	public static string GetURL()
	{
		return "ui://82mo10n5zgaedhk";
	}

	public static UI_TopTournamentHistoryRankListDialog CreateInstance()
	{
		return (UI_TopTournamentHistoryRankListDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "TopTournamentHistoryRankListDialog");
	}

	public static UI_TopTournamentHistoryRankListDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TopTournamentHistoryRankListDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5zgaedhk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Background = (GImage)((GComponent)this).GetChild("Background");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		ScoreRankingList = (GList)((GComponent)this).GetChild("ScoreRankingList");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://82mo10n5zgaedhk".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		DayIndexList = (UI_EveryDayLogTitleList)(object)((GComponent)this).GetChild("DayIndexList");
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id2 = "ui://82mo10n5zgaedhk".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id2);
	}
}
