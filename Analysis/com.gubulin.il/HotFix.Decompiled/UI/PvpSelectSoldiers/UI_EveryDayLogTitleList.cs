using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;

namespace UI.PvpSelectSoldiers;

public class UI_EveryDayLogTitleList : GButton
{
	public Controller button;

	public Controller Type;

	public GGraph back;

	public GTextField CurrentDay;

	public GImage n5;

	public GImage n6;

	public GList DayIndexList;

	public const string URL = "ui://82mo10n5aveldgz";

	public static string Name = "UI_EveryDayLogTitleList";

	private Dictionary<int, string> allBattleLogDayIndex = new Dictionary<int, string>();

	public static string GetURL()
	{
		return "ui://82mo10n5aveldgz";
	}

	public static UI_EveryDayLogTitleList CreateInstance()
	{
		return (UI_EveryDayLogTitleList)(object)UIPackage.CreateObject("PvpSelectSoldiers", "EveryDayLogTitleList");
	}

	public static UI_EveryDayLogTitleList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EveryDayLogTitleList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5aveldgz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		back = (GGraph)((GComponent)this).GetChild("back");
		CurrentDay = (GTextField)((GComponent)this).GetChild("CurrentDay");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		DayIndexList = (GList)((GComponent)this).GetChild("DayIndexList");
	}

	public int Init()
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		allBattleLogDayIndex = RankDataHelper.GetTopTournamentLogDayIndex();
		if (allBattleLogDayIndex == null || allBattleLogDayIndex.Count <= 0)
		{
			((GObject)DayIndexList).visible = false;
			((GObject)CurrentDay).text = "（" + RankDataHelper.GetLastTurnLastDayTitle() + "）";
			return 0;
		}
		((GObject)DayIndexList).visible = true;
		KeyValuePair<int, string> keyValuePair = allBattleLogDayIndex.ToList()[allBattleLogDayIndex.Count - 1];
		((GObject)CurrentDay).text = "（" + keyValuePair.Value + "）";
		Type.selectedIndex = 0;
		((GObject)this).onClick.Set(new EventCallback0(ShowAllDayTitle));
		RenderAllDayTitle();
		return keyValuePair.Key;
	}

	private void RenderAllDayTitle()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		DayIndexList.itemRenderer = new ListItemRenderer(RenderDayTitle);
		DayIndexList.numItems = allBattleLogDayIndex.Count;
		DayIndexList.ResizeToFit(allBattleLogDayIndex.Count);
	}

	private void RenderDayTitle(int index, GObject obj)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		if (obj is UI_TopTournamentDayTitleItem uI_TopTournamentDayTitleItem)
		{
			KeyValuePair<int, string> keyValuePair = allBattleLogDayIndex.ToList()[index];
			((GObject)uI_TopTournamentDayTitleItem.CurrentDay).text = "（" + keyValuePair.Value + "）";
			((GObject)uI_TopTournamentDayTitleItem).data = index;
			((GObject)uI_TopTournamentDayTitleItem).onClick.Set(new EventCallback1(SelectCheckOneDayLog));
		}
	}

	private void ShowAllDayTitle()
	{
		Type.selectedIndex = ((Type.selectedIndex == 0) ? 1 : 0);
	}

	private void SelectCheckOneDayLog(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		object data = ((GObject)context.sender).data;
		if (data != null)
		{
			KeyValuePair<int, string> keyValuePair = allBattleLogDayIndex.ToList()[(int)data];
			((GObject)CurrentDay).text = "（" + keyValuePair.Value + "）";
			UI_TopTournamentEveryDayLogPanel.TopTournamentEveryDayLogPanel?.BattleLogInit(keyValuePair.Key);
		}
	}
}
