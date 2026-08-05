using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3.Collecting;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;

public class GvGShipUiInfoManager : Singleton<GvGShipUiInfoManager>
{
	private bool _isEventRegistered;

	private const int LaunchableIslandsUpdateInterval = 180;

	private int _lastGetLaunchableIslandsTimestamp;

	private List<int> _launchableIslands = new List<int>();

	public List<int> LaunchableIslands => _launchableIslands;

	private bool LaunchableIslandsNeedGet => LaunchableIslandsExpired();

	public void RegisterSocketEvents()
	{
		if (!_isEventRegistered)
		{
			_isEventRegistered = true;
			S2C_GvGMode3FoodOnboardCount.OnPushEvent = (Action<S2C_GvGMode3FoodOnboardCount.Request>)Delegate.Combine(S2C_GvGMode3FoodOnboardCount.OnPushEvent, new Action<S2C_GvGMode3FoodOnboardCount.Request>(OnPushFoodOnboardCount));
			S2C_FillupFood.OnPushEvent = (Action<S2C_FillupFood.Request>)Delegate.Combine(S2C_FillupFood.OnPushEvent, new Action<S2C_FillupFood.Request>(OnPushFoodFillUp));
			S2C_ShipCountLimit.OnPushEvent = (Action<S2C_ShipCountLimit.Request>)Delegate.Combine(S2C_ShipCountLimit.OnPushEvent, new Action<S2C_ShipCountLimit.Request>(OnPushShipCountChange));
		}
	}

	public void UnregisterSocketEvents()
	{
		if (_isEventRegistered)
		{
			_isEventRegistered = false;
			S2C_GvGMode3FoodOnboardCount.OnPushEvent = (Action<S2C_GvGMode3FoodOnboardCount.Request>)Delegate.Remove(S2C_GvGMode3FoodOnboardCount.OnPushEvent, new Action<S2C_GvGMode3FoodOnboardCount.Request>(OnPushFoodOnboardCount));
			S2C_FillupFood.OnPushEvent = (Action<S2C_FillupFood.Request>)Delegate.Remove(S2C_FillupFood.OnPushEvent, new Action<S2C_FillupFood.Request>(OnPushFoodFillUp));
			S2C_ShipCountLimit.OnPushEvent = (Action<S2C_ShipCountLimit.Request>)Delegate.Remove(S2C_ShipCountLimit.OnPushEvent, new Action<S2C_ShipCountLimit.Request>(OnPushShipCountChange));
		}
	}

	public void ShipFillupFood(int shipEntityId, string itemId, int quantity)
	{
		int num = Singleton<WorldStateManager>.Instance.Data.RealTimeFoodOnBoardModel.Base;
		int foodOnboardCount = Singleton<WorldStateManager>.Instance.TryGetShip(shipEntityId).FoodOnboardCount;
		if (foodOnboardCount >= num)
		{
			"GvG3FoodIsFullTips".ToShowLanguageTip();
			return;
		}
		if (GameManagers.Instance.StockController.GetStock(itemId) == 0)
		{
			"GvG3NotEnoughFoodItemTips".ToShowLanguageTip();
			return;
		}
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_FillupFood
		{
			Req = new C2S_FillupFood.Request
			{
				ShipEntityId = shipEntityId,
				ItemId = itemId,
				Quantity = quantity
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_FillupFood.Response response = (C2S_FillupFood.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
		});
	}

	private void OnPushFoodOnboardCount(S2C_GvGMode3FoodOnboardCount.Request request)
	{
		Singleton<WorldStateManager>.Instance.TryGetShip(request.ShipEntityId)?.SyncFood(request.FoodOnboardCount);
	}

	private void OnPushFoodFillUp(S2C_FillupFood.Request request)
	{
		if (request.ErrorCode != 0)
		{
			ILRequestHelper.ShowErrorCode(request.ErrorCode);
		}
	}

	public void SyncPreFlightSchedule(string shipId, int startId, int endId, int action, Action<C2S_GetPreFlightSchedule.Response> onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetPreFlightSchedule
		{
			Req = new C2S_GetPreFlightSchedule.Request
			{
				ShipId = shipId,
				StartId = startId,
				EndId = endId,
				Action = action
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetPreFlightSchedule.Response response = (C2S_GetPreFlightSchedule.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFinished?.Invoke(response);
			}
			else
			{
				onFinished?.Invoke(response);
			}
		});
	}

	public void SyncShipCollectingDetailInfo(int shipEntityId, Action<RealTimeShipSummarySpeedModel> onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetShipCollectingDetailInfo
		{
			Req = new C2S_GetShipCollectingDetailInfo.Request
			{
				ShipEntityId = shipEntityId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetShipCollectingDetailInfo.Response response = (C2S_GetShipCollectingDetailInfo.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Singleton<WorldStateManager>.Instance.TryGetShip(shipEntityId).SyncInfoFromShipCollectingDetail(response);
				onFinished?.Invoke(response.ShipSummarySpeedModel);
			}
		});
	}

	public void SyncRealTimeCollectingEfficiency(string shipId, Action onFinished = null)
	{
		if (Singleton<GvGMode3RoomManager>.Instance.IsRoomClosed)
		{
			return;
		}
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetRealTimeCollectingEfficiencyModel
		{
			Req = new C2S_GetRealTimeCollectingEfficiencyModel.Request
			{
				ShipId = shipId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetRealTimeCollectingEfficiencyModel.Response response = (C2S_GetRealTimeCollectingEfficiencyModel.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else if (!Singleton<GvGMode3RoomManager>.Instance.IsRoomClosed)
			{
				Singleton<WorldStateManager>.Instance.TryGetMyShip(shipId).SyncCollectingEfficiencyModel(response.Model);
				onFinished?.Invoke();
			}
		});
	}

	public void GetRealTimeFoodCostReduce(string shipId, int targetIslandId, Action<RealTimeFoodCostReduceModel> onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetRealTimeFoodCostReduceModel
		{
			Req = new C2S_GetRealTimeFoodCostReduceModel.Request
			{
				ShipId = shipId,
				TargetIslandId = targetIslandId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetRealTimeFoodCostReduceModel.Response response = (C2S_GetRealTimeFoodCostReduceModel.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				onFinished?.Invoke(response.Model);
			}
		});
	}

	public void GetRealTimeShipSummarySpeed(string shipId, int targetIsland, Action<RealTimeShipSummarySpeedModel> onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetRealTimeShipSummarySpeedModel
		{
			Req = new C2S_GetRealTimeShipSummarySpeedModel.Request
			{
				ShipId = shipId,
				TargetIslandId = targetIsland
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetRealTimeShipSummarySpeedModel.Response response = (C2S_GetRealTimeShipSummarySpeedModel.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Singleton<WorldStateManager>.Instance.TryGetMyShip(shipId).SyncShipSpeedBuff(response.Model);
				onFinished?.Invoke(response.Model);
			}
		});
	}

	private bool LaunchableIslandsExpired()
	{
		if (_launchableIslands.Count <= 0)
		{
			return true;
		}
		return GameController.Instance.GetServerTime() - _lastGetLaunchableIslandsTimestamp > 180;
	}

	public void GetLaunchableIsland(GvGShipDetailModel detailModel, Action<GvGShipDetailModel> onFinished = null)
	{
		if (!LaunchableIslandsNeedGet)
		{
			onFinished?.Invoke(detailModel);
			return;
		}
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetLaunchableIsland
		{
			Req = new C2S_GetLaunchableIsland.Request
			{
				NonStr = string.Empty
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetLaunchableIsland.Response response = (C2S_GetLaunchableIsland.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				_lastGetLaunchableIslandsTimestamp = (int)GameController.Instance.GetServerTime();
				_launchableIslands = new List<int>(response.IslandIds);
				onFinished?.Invoke(detailModel);
			}
		});
	}

	private void OnPushShipCountChange(S2C_ShipCountLimit.Request request)
	{
		Singleton<GvGMode3RoomManager>.Instance.SyncShipCountLimit(request.ShipCountLimit);
		SharedMessenger.Broadcast("ON_SHIP_COUNT_LIMIT_CHANGE");
	}
}
