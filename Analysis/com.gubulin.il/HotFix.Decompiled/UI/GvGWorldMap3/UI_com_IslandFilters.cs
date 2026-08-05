using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Enum;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Filters;
using Shift.Legion.Common.Helpers;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_com_IslandFilters : GComponent
{
	public Controller State;

	public Controller AreaEnable;

	public Controller isShowPositioning;

	public GImage n0;

	public GList Filters;

	public GTextField n2;

	public UI_btn_CheckNextFilterIsland CheckIsland;

	public UI_com_FilterArea Area;

	public UI_btn_CloseFilter Close;

	public GTextField n8;

	public GImage n10;

	public GImage n11;

	public GImage n13;

	public GImage n14;

	public GTextField AreaTip;

	public GTextField n15;

	public GGroup n12;

	public GGroup n6;

	public Transition Display;

	public Transition Hide;

	public const string URL = "ui://4eq8fgd2kivrsbn";

	public static string Name = "UI_com_IslandFilters";

	private int _curAreaIndex;

	private FairyGuiPageTurner _turner;

	private bool _isInitialized;

	private EventCallback0 _onCloseClick;

	private IslandAreaFilters CurArea => Areas[_curAreaIndex];

	private static List<IslandAreaFilters> Areas => FilterManager.AreaFilters;

	private static string CurFilterId => FilterManager.CurSelectedFilterId;

	private static GvGIslandFilterManager FilterManager => Singleton<GvGIslandFilterManager>.Instance;

	public static string GetURL()
	{
		return "ui://4eq8fgd2kivrsbn";
	}

	public static UI_com_IslandFilters CreateInstance()
	{
		return (UI_com_IslandFilters)(object)UIPackage.CreateObject("GvGWorldMap3", "com_IslandFilters");
	}

	public static UI_com_IslandFilters CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandFilters).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2kivrsbn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		AreaEnable = ((GComponent)this).GetController("AreaEnable");
		isShowPositioning = ((GComponent)this).GetController("isShowPositioning");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		Filters = (GList)((GComponent)this).GetChild("Filters");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://4eq8fgd2kivrsbn".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		CheckIsland = (UI_btn_CheckNextFilterIsland)(object)((GComponent)this).GetChild("CheckIsland");
		Area = (UI_com_FilterArea)(object)((GComponent)this).GetChild("Area");
		Close = (UI_btn_CloseFilter)(object)((GComponent)this).GetChild("Close");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id2 = "ui://4eq8fgd2kivrsbn".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id2);
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		AreaTip = (GTextField)((GComponent)this).GetChild("AreaTip");
		string id3 = "ui://4eq8fgd2kivrsbn".Replace("ui://", "") + "-" + ((GObject)AreaTip).id;
		((GObject)AreaTip).text = LanguagesManager.GetDesc(id3);
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id4 = "ui://4eq8fgd2kivrsbn".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id4);
		n12 = (GGroup)((GComponent)this).GetChild("n12");
		n6 = (GGroup)((GComponent)this).GetChild("n6");
		Display = ((GComponent)this).GetTransition("Display");
		Hide = ((GComponent)this).GetTransition("Hide");
	}

	public void RegisterEvents(EventCallback0 closeCallback)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		_onCloseClick = closeCallback;
		_turner = new FairyGuiPageTurner(new FairyGuiPageTurnerCreateParams
		{
			PageTurner = Area,
			SelectingPageIndex = 0,
			PageCount = Areas.Count,
			OnPageIndexChange = ChangeArea
		});
		Filters.itemRenderer = new ListItemRenderer(FilterRenderer);
		((GObject)Close).onClick.Set(new EventCallback0(OnCloseBtnClicked));
		((GObject)CheckIsland).onClick.Set(new EventCallback0(OnCheckBtnClicked));
		GvGIslandFilterManager instance = Singleton<GvGIslandFilterManager>.Instance;
		instance.OnCheckIslandBtnTitleChange = (Action<int>)Delegate.Combine(instance.OnCheckIslandBtnTitleChange, new Action<int>(UpdateCheckBtnTitle));
	}

	public void UnregisterEvents()
	{
		_onCloseClick = null;
		((GObject)Close).onClick.Clear();
		((GObject)CheckIsland).onClick.Clear();
		GvGIslandFilterManager instance = Singleton<GvGIslandFilterManager>.Instance;
		instance.OnCheckIslandBtnTitleChange = (Action<int>)Delegate.Remove(instance.OnCheckIslandBtnTitleChange, new Action<int>(UpdateCheckBtnTitle));
	}

	public void DisplayFilters()
	{
		TryInit();
		State.SetSelectedIndex(1);
	}

	private void TryInit()
	{
		if (!_isInitialized)
		{
			_curAreaIndex = FindCurAreaIndex();
			_turner.SetSelectingPageIndex(_curAreaIndex);
			UpdateAreaFilters();
			_isInitialized = true;
		}
	}

	private static int FindCurAreaIndex()
	{
		if (!HasSelectedFilterId())
		{
			return 0;
		}
		int num = Areas.FindIndex((IslandAreaFilters area) => area.ContainsFilter(CurFilterId));
		return Mathf.Max(num, 0);
	}

	private string ChangeArea(int areaIndex)
	{
		_curAreaIndex = areaIndex;
		UpdateAreaFilters();
		return CurArea.AreaName;
	}

	private void UpdateAreaFilters()
	{
		RenderArea();
		RenderFilters();
		UpdateCheckBtn();
	}

	private void RenderArea()
	{
		bool checkAreaEffective = CurArea.CheckAreaEffective;
		AreaEnable.SetSelectedIndex(checkAreaEffective ? 1 : 0);
	}

	private void UpdateCheckBtn()
	{
		bool flag = HasSelectedFilterId();
		bool flag2 = FindCurAreaIndex() == _curAreaIndex;
		isShowPositioning.SetSelectedIndex((flag && flag2) ? 1 : 0);
		CheckIslandButtonMode checkIslandBtnTitleMode = FilterManager.GetCheckIslandBtnTitleMode();
		UpdateCheckBtnTitle((int)checkIslandBtnTitleMode);
	}

	private void UpdateCheckBtnTitle(int mode)
	{
		CheckIsland.Mode.SetSelectedIndex(mode);
	}

	private static bool HasSelectedFilterId()
	{
		return !string.IsNullOrEmpty(CurFilterId);
	}

	private void RenderFilters()
	{
		Filters.numItems = CurArea.Filters.Count;
	}

	private void FilterRenderer(int index, GObject obj)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		if (!(obj is UI_btn_IslandFilter uI_btn_IslandFilter))
		{
			throw new Exception("[UI_com_IslandFilters]:FilterRenderer filterUi is not UI_btn_IslandFilter");
		}
		IslandFilter islandFilter = CurArea.Filters[index];
		((GObject)uI_btn_IslandFilter.FilterName).text = islandFilter.FilterName;
		uI_btn_IslandFilter.State.SetSelectedIndex((islandFilter.FilterId == CurFilterId) ? 1 : 0);
		uI_btn_IslandFilter.Icons.itemRenderer = new ListItemRenderer(FilterIconRenderer);
		uI_btn_IslandFilter.Icons.numItems = islandFilter.ItemUrls.Count;
		((GObject)uI_btn_IslandFilter).data = index;
		((GObject)uI_btn_IslandFilter).onClick.Set(new EventCallback1(OnFilterSelected));
		void FilterIconRenderer(int iconIndex, GObject iconUi)
		{
			if (!(iconUi is UI_com_FilterIcon uI_com_FilterIcon))
			{
				throw new Exception("[UI_com_IslandFilters]:FilterIconRenderer filterIcon is not UI_com_FilterIcon");
			}
			uI_com_FilterIcon.Icon.url = islandFilter.ItemUrls[iconIndex];
		}
	}

	private void OnFilterSelected(EventContext context)
	{
		UI_btn_IslandFilter uI_btn_IslandFilter = (UI_btn_IslandFilter)(object)context.sender;
		int index = (int)((GObject)uI_btn_IslandFilter).data;
		string filterId = CurArea.Filters[index].FilterId;
		int selectedIndex = uI_btn_IslandFilter.State.selectedIndex;
		string filterId2 = ((selectedIndex == 1) ? string.Empty : filterId);
		uI_btn_IslandFilter.State.SetSelectedIndex(1 - selectedIndex);
		FilterManager.ChangeFilter(filterId2);
		RenderFilters();
		UpdateCheckBtn();
	}

	private static void OnCheckBtnClicked()
	{
		FilterManager.CheckFilteredIsland();
	}

	private void OnCloseBtnClicked()
	{
		State.SetSelectedIndex(0);
		EventCallback0 onCloseClick = _onCloseClick;
		if (onCloseClick != null)
		{
			onCloseClick.Invoke();
		}
	}
}
