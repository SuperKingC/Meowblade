using System;
using System.Collections;
using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Cache;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Enum;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Filters;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Ship;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Manager;

public class GvGIslandFilterManager : Singleton<GvGIslandFilterManager>
{
	public Action OnIslandFilterChange = delegate
	{
	};

	private List<IslandAreaFilters> _areaFilters;

	private readonly Dictionary<string, IslandFilter> _allFilters = new Dictionary<string, IslandFilter>();

	private FilterIslandRecordController _recordController;

	private CampIslandsOfInterestCache _islandsOfInterestCache;

	private bool _isEventRegistered;

	private string _lastIzConfigId = string.Empty;

	public Action<int> OnCheckIslandBtnTitleChange = delegate
	{
	};

	private const int _EMPTY_ISLAND_ID = 0;

	private const float _CATCHUP_TIME = 0.5f;

	private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(0.5f);

	public string CurSelectedFilterId => _recordController.CurFilterId;

	public List<IslandAreaFilters> AreaFilters => _areaFilters;

	public void RegisterSocketEvents()
	{
		if (!_isEventRegistered)
		{
			_isEventRegistered = true;
			WorldStateManager instance = Singleton<WorldStateManager>.Instance;
			instance.OnCampFlagshipStayIslandChange = (Action)Delegate.Combine(instance.OnCampFlagshipStayIslandChange, new Action(OnFlagshipPosChange));
			S2C_GvGMode3NewIOI.OnPushEvent = (Action<S2C_GvGMode3NewIOI.Request>)Delegate.Combine(S2C_GvGMode3NewIOI.OnPushEvent, new Action<S2C_GvGMode3NewIOI.Request>(OnCampIOIChange));
		}
	}

	public void UnregisterSocketEvents()
	{
		if (_isEventRegistered)
		{
			_isEventRegistered = false;
			WorldStateManager instance = Singleton<WorldStateManager>.Instance;
			instance.OnCampFlagshipStayIslandChange = (Action)Delegate.Remove(instance.OnCampFlagshipStayIslandChange, new Action(OnFlagshipPosChange));
			S2C_GvGMode3NewIOI.OnPushEvent = (Action<S2C_GvGMode3NewIOI.Request>)Delegate.Remove(S2C_GvGMode3NewIOI.OnPushEvent, new Action<S2C_GvGMode3NewIOI.Request>(OnCampIOIChange));
		}
	}

	public void ClearCheckRecord()
	{
		_recordController?.ClearCheckRecord();
	}

	private void OnCampIOIChange(S2C_GvGMode3NewIOI.Request req)
	{
		_islandsOfInterestCache?.OnCampFlagshipIoiChange();
	}

	public void Init(GvGMode3ObserverRecord observerRecord, List<int> campIslandsOfInterest)
	{
		if (_lastIzConfigId == observerRecord.IZConfigId)
		{
			_islandsOfInterestCache.UpdateIslandsOfInterest(campIslandsOfInterest);
			return;
		}
		_lastIzConfigId = observerRecord.IZConfigId;
		InitAllFilters();
		InitRecordController();
		InitIoiCache(campIslandsOfInterest);
	}

	public void InitIslandFilterIcons()
	{
		UpdateIslandFilterIcons(_recordController.CurFilterId);
	}

	private void InitAllFilters()
	{
		_areaFilters = IslandFilterConfigHelper.CreateIslandAreaFilters(_lastIzConfigId);
		List<IslandAreaFilters> areaFilters = _areaFilters;
		foreach (IslandAreaFilters item in areaFilters)
		{
			foreach (IslandFilter filter in item.Filters)
			{
				_allFilters.Add(filter.FilterId, filter);
			}
		}
	}

	private void InitRecordController()
	{
		_recordController = new FilterIslandRecordController();
	}

	private void InitIoiCache(List<int> campIslandsOfInterest)
	{
		_islandsOfInterestCache = new CampIslandsOfInterestCache(campIslandsOfInterest);
	}

	public bool CanDisplayFilterIcons(string filterId, IslandStateModel model)
	{
		IslandFilter filter;
		return TryGetIslandFilter(filterId, out filter) && filter.CanDisplayFilterIcons(model);
	}

	public List<string> GetIslandFilterIconUrls(string filterId)
	{
		IslandFilter value;
		return (!_allFilters.TryGetValue(filterId, out value)) ? new List<string>() : value.ItemUrls;
	}

	public void ChangeFilter(string filterId)
	{
		ClearCurIslandFilterIcons();
		if (_recordController.UpdateOnFilterChange(filterId))
		{
			UpdateIslandFilterIcons(filterId);
		}
		OnIslandFilterChange?.Invoke();
	}

	private void ClearCurIslandFilterIcons()
	{
		string curFilterId = _recordController.CurFilterId;
		if (!string.IsNullOrEmpty(curFilterId) && _allFilters.TryGetValue(curFilterId, out var value))
		{
			List<int> allIslandId = value.GetAllIslandId();
			UpdateIslandFilter(string.Empty, allIslandId);
		}
	}

	private void UpdateIslandFilterIcons(string filterId)
	{
		if (!string.IsNullOrEmpty(filterId) && _allFilters.TryGetValue(filterId, out var value))
		{
			List<int> allIslandId = value.GetAllIslandId();
			UpdateIslandFilter(filterId, allIslandId);
		}
	}

	private static void UpdateIslandFilter(string filterId, List<int> islands)
	{
		foreach (int island in islands)
		{
			IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(island);
			islandStateModel.CurFilterId = filterId;
		}
	}

	private void OnFlagshipPosChange()
	{
		foreach (IslandAreaFilters areaFilter in _areaFilters)
		{
			areaFilter.MarkFiltersIslandSortCacheDirty();
		}
	}

	public CheckIslandButtonMode GetCheckIslandBtnTitleMode()
	{
		int lastCheckIslandId = _recordController.LastCheckIslandId;
		return (lastCheckIslandId > 0) ? CheckIslandButtonMode.Next : CheckIslandButtonMode.First;
	}

	public void CheckFilteredIsland()
	{
		string curFilterId = _recordController.CurFilterId;
		if (!string.IsNullOrEmpty(curFilterId))
		{
			TryUpdateCampIslandOfInterest(FindNextFilterIsland);
		}
	}

	public void FocusIslandAndTryOpenIslandCard(int islandId)
	{
		FGUIManager.Instance.OpenIEnumerator(FocusIslandById(islandId));
	}

	private IEnumerator FocusIslandById(int islandId)
	{
		yield return null;
		BroadcastPreventInputChange(preventInput: true);
		BroadcastCloseIslandCard();
		GvGWorldMapController.Instance.FocusIslandById(islandId);
		yield return _waitForSeconds;
		if (_islandsOfInterestCache.IslandIsCampInterest(islandId))
		{
			BroadcastOpenIslandCard(islandId);
		}
		BroadcastPreventInputChange(preventInput: false);
	}

	private void ChangeCheckIslandBtnTitle()
	{
		int lastCheckIslandId = _recordController.LastCheckIslandId;
		int obj = ((lastCheckIslandId > 0) ? 1 : 0);
		OnCheckIslandBtnTitleChange?.Invoke(obj);
	}

	private void TryUpdateCampIslandOfInterest(Action action)
	{
		if (_islandsOfInterestCache.DirtyFlag)
		{
			GetNewCampIoiIslands(action);
		}
		else
		{
			action?.Invoke();
		}
	}

	private void GetNewCampIoiIslands(Action action)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetUserIslandOfInterest
		{
			Req = new C2S_GetUserIslandOfInterest.Request()
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetUserIslandOfInterest.Response response = (C2S_GetUserIslandOfInterest.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Callback(response);
			}
		});
		void Callback(C2S_GetUserIslandOfInterest.Response res)
		{
			_islandsOfInterestCache.UpdateIslandsOfInterest(res.IslandOfInterest);
			UpdateLastCheckIslandId();
			action?.Invoke();
		}
	}

	private void UpdateLastCheckIslandId()
	{
		if (_recordController.LastCheckIslandId > 0 && !_islandsOfInterestCache.IslandIsCampInterest(_recordController.LastCheckIslandId))
		{
			_recordController.UpdateCheckIslandId(0);
			ChangeCheckIslandBtnTitle();
		}
	}

	private void FindNextFilterIsland()
	{
		string curFilterId = _recordController.CurFilterId;
		if (TryFindNextFilterIsland(curFilterId, out var nextIslandId))
		{
			FGUIManager.Instance.OpenIEnumerator(FocusIsland(nextIslandId));
		}
	}

	private IEnumerator FocusIsland(int nextIslandId)
	{
		yield return null;
		BroadcastPreventInputChange(preventInput: true);
		BroadcastCloseIslandCard();
		GvGWorldMapController.Instance.FocusIslandById(nextIslandId);
		yield return _waitForSeconds;
		BroadcastOpenIslandCard(nextIslandId);
		BroadcastPreventInputChange(preventInput: false);
	}

	private bool TryFindNextFilterIsland(string curFilterId, out int nextIslandId)
	{
		nextIslandId = FindNextFilterIsland(curFilterId, out var curFilter);
		if (nextIslandId > 0)
		{
			_recordController.UpdateCheckIslandId(nextIslandId);
			ChangeCheckIslandBtnTitle();
			return true;
		}
		curFilter.CheckNotAvailableTip.ToTip();
		return false;
	}

	private int FindNextFilterIsland(string curFilterId, out IslandFilter curFilter)
	{
		TryGetIslandFilter(curFilterId, out curFilter);
		int lastCheckIslandId = _recordController.LastCheckIslandId;
		List<int> sortedIslandId = curFilter.GetSortedIslandId();
		int count = sortedIslandId.Count;
		int num = sortedIslandId.IndexOf(lastCheckIslandId);
		int num2 = ((num >= 0) ? GetNextIslandIndex(num, count) : 0);
		int num3 = num2;
		do
		{
			int num4 = sortedIslandId[num3];
			if (CanBeFiltered(curFilter, num4))
			{
				return num4;
			}
			num3 = GetNextIslandIndex(num3, count);
		}
		while (num3 != num2);
		return 0;
	}

	private static int GetNextIslandIndex(int currentIndex, int totalCount)
	{
		return (currentIndex + 1) % totalCount;
	}

	private bool CanBeFiltered(IslandFilter filter, int islandId)
	{
		IslandStateModel model = Singleton<WorldStateManager>.Instance.TryGetIsland(islandId);
		bool flag = filter.IslandConformFilterConditions(model);
		bool flag2 = _islandsOfInterestCache.IslandIsCampInterest(islandId);
		return flag2 && flag;
	}

	private bool TryGetIslandFilter(string filterId, out IslandFilter filter)
	{
		if (!_allFilters.TryGetValue(filterId, out filter))
		{
			throw new InvalidOperationException("[岛屿筛选] : filterId=" + filterId);
		}
		return true;
	}

	private static void BroadcastPreventInputChange(bool preventInput)
	{
		SharedMessenger.Broadcast("GVG3_PREVENT_INPUT_CHANGE", preventInput);
	}

	private static void BroadcastCloseIslandCard()
	{
		SharedMessenger.Broadcast("GVG3_AUTO_CLOSE_ISLAND_CARD");
	}

	private static void BroadcastOpenIslandCard(int islandId)
	{
		SharedMessenger.Broadcast("GVG3_AUTO_OPEN_ISLAND_CARD", islandId);
	}
}
