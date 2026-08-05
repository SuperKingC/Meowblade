using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_TopTournamentEveryDayLogDialog : GComponent
{
	public GImage Background;

	public GImage n1;

	public GList BattleLogList;

	public UI_EveryDayLogTitleList DayIndexList;

	public GTextField tip;

	public GTextField n7;

	public const string URL = "ui://82mo10n5aveldgr";

	public static string Name = "UI_TopTournamentEveryDayLogDialog";

	public static string GetURL()
	{
		return "ui://82mo10n5aveldgr";
	}

	public static UI_TopTournamentEveryDayLogDialog CreateInstance()
	{
		return (UI_TopTournamentEveryDayLogDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "TopTournamentEveryDayLogDialog");
	}

	public static UI_TopTournamentEveryDayLogDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TopTournamentEveryDayLogDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5aveldgr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Background = (GImage)((GComponent)this).GetChild("Background");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		BattleLogList = (GList)((GComponent)this).GetChild("BattleLogList");
		DayIndexList = (UI_EveryDayLogTitleList)(object)((GComponent)this).GetChild("DayIndexList");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://82mo10n5aveldgr".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id2 = "ui://82mo10n5aveldgr".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id2);
	}
}
