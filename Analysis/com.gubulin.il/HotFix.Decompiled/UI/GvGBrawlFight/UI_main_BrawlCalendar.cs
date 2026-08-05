using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Interface.Brawl;
using Shift.Legion.Common.Services;

namespace UI.GvGBrawlFight;

public class UI_main_BrawlCalendar : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_BrawlCalendar Calendar;

	public Transition t0;

	public const string URL = "ui://hozu168rswyq3e";

	public static string Name = "UI_main_BrawlCalendar";

	private const string CLAIMED_INFO = "CLAIMED_INFO";

	private const string ON_SELECTED_ACTION = "ON_SELECTED_ACTION";

	private const string CURRENT_DAY = "CURRENT_DAY";

	private List<IBrawlClaimedUiInfo> _infos;

	private Action<int> _onSelected;

	private int _curDay;

	public static string GetURL()
	{
		return "ui://hozu168rswyq3e";
	}

	public static UI_main_BrawlCalendar CreateInstance()
	{
		return (UI_main_BrawlCalendar)(object)UIPackage.CreateObject("GvGBrawlFight", "main_BrawlCalendar");
	}

	public static UI_main_BrawlCalendar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_BrawlCalendar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rswyq3e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Calendar = (UI_com_BrawlCalendar)(object)((GComponent)this).GetChild("Calendar");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public static void OpenBrawlCalendarPanel(List<IBrawlClaimedUiInfo> infos, Action<int> onSelected, int curDay)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(Name, new Dictionary<string, object>
		{
			{ "CLAIMED_INFO", infos },
			{ "ON_SELECTED_ACTION", onSelected },
			{ "CURRENT_DAY", curDay }
		});
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_infos = (List<IBrawlClaimedUiInfo>)parameters["CLAIMED_INFO"];
		_onSelected = (Action<int>)parameters["ON_SELECTED_ACTION"];
		_curDay = (int)parameters["CURRENT_DAY"];
	}

	public void OnShow()
	{
		RenderDays();
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void RenderDays()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Calendar.ClaimedInfos.itemRenderer = new ListItemRenderer(DayRenderer);
		Calendar.ClaimedInfos.numItems = _infos.Count;
		int selectedIndex = _infos.FindIndex((IBrawlClaimedUiInfo info) => info.DayIndex == _curDay);
		Calendar.ClaimedInfos.selectedIndex = selectedIndex;
	}

	private void DayRenderer(int index, GObject obj)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		if (!(obj is UI_btn_Day uI_btn_Day))
		{
			throw new Exception("[UI_main_BrawlCalendar]:DayRenderer obj is not UI_btn_Day");
		}
		IBrawlClaimedUiInfo brawlClaimedUiInfo = _infos[index];
		((GObject)uI_btn_Day.Date).text = brawlClaimedUiInfo.Date;
		((GObject)uI_btn_Day.Day).text = brawlClaimedUiInfo.DayIndex.ToString();
		uI_btn_Day.IsClaimed.SetSelectedIndex(brawlClaimedUiInfo.ClaimedStatus);
		uI_btn_Day.IsGenerated.SetSelectedIndex(brawlClaimedUiInfo.IsGenerated);
		((GObject)uI_btn_Day).data = index;
		((GObject)uI_btn_Day).onClick.Set(new EventCallback1(OnDaySelected));
		((GObject)uI_btn_Day).touchable = brawlClaimedUiInfo.IsGenerated == 1 && brawlClaimedUiInfo.ClaimedStatus != 2;
	}

	private void OnDaySelected(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		int index = (int)((GObject)context.sender).data;
		_onSelected(_infos[index].DayIndex);
		End();
	}
}
