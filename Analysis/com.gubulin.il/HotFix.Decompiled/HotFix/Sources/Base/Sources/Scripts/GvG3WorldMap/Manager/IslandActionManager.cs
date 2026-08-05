using System;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;

public class IslandActionManager
{
	public void GoTo(int targetIslandId, int shipEntityId, Action onFinished = null)
	{
		ShipStateModel shipStateModel = Singleton<WorldStateManager>.Instance.TryGetShip(shipEntityId);
		C2S_IslandAction.Request req = new C2S_IslandAction.Request
		{
			ShipId = shipStateModel.ShipId,
			StartId = shipStateModel.StayIslandId,
			EndId = targetIslandId,
			ActionEnum = eIslandAction.GoTo,
			ActionData = string.Empty,
			NextActionEnum = eIslandAction.FakeAction,
			NextActionData = string.Empty
		};
		Singleton<WorldStateManager>.Instance.SendIslandAction(req, onFinished);
	}

	public void IslandAction(eIslandAction actionType, int targetIslandId, int shipEntityId, List<string> collectingStockModelIds = null, Action onFinished = null, bool autoCollection = false)
	{
		if (actionType == eIslandAction.Collect)
		{
			autoCollection = false;
		}
		ShipStateModel shipStateModel = Singleton<WorldStateManager>.Instance.TryGetShip(shipEntityId);
		string actionData = ((collectingStockModelIds == null) ? string.Empty : JsonHelper.ToJson(collectingStockModelIds));
		eIslandAction nextActionEnum = (autoCollection ? eIslandAction.Collect : eIslandAction.FakeAction);
		string nextActionData = (autoCollection ? JsonHelper.ToJson((from model in Singleton<WorldStateManager>.Instance.TryGetIsland(targetIslandId).DetailInfo.GetAllCollectingStock()
			select model.GetMiningConfigStr(0)).ToList()) : string.Empty);
		C2S_IslandAction.Request req = new C2S_IslandAction.Request
		{
			ShipId = shipStateModel.ShipId,
			StartId = shipStateModel.StayIslandId,
			EndId = targetIslandId,
			ActionEnum = actionType,
			ActionData = actionData,
			NextActionEnum = nextActionEnum,
			NextActionData = nextActionData
		};
		Singleton<WorldStateManager>.Instance.SendIslandAction(req, onFinished);
	}

	public void FillUpShipSoldiers(int targetIslandId, int shipEntityId, Action onFinished = null)
	{
		ShipStateModel shipStateModel = Singleton<WorldStateManager>.Instance.TryGetShip(shipEntityId);
		if (targetIslandId == shipStateModel.StayIslandId)
		{
			Singleton<WorldStateManager>.Instance.FillUpShipSoldiers(shipEntityId, onFinished);
			return;
		}
		IslandAction(eIslandAction.GoTo, targetIslandId, shipEntityId, null, delegate
		{
			SharedMessenger.Broadcast("ON_GVG3_ISLAND_ACTION_SUCCESS", 5);
		});
	}

	public int CalcIslandActionCost(eIslandAction action, int islandId, RealTimeFoodCostReduceModel model)
	{
		int num = 0;
		GDEGvGIslandMapConfigData gDEData = WorldMapConfigHelper.Configs.TryGetIsland(islandId).Props.GDEData;
		switch (action)
		{
		case eIslandAction.Collect:
			num = gDEData.FoodCost_Collect;
			break;
		case eIslandAction.Attack:
			num = gDEData.FoodCost_Attack;
			break;
		case eIslandAction.SuppressRebellion:
			num = gDEData.FoodCost_SuppressRebellion;
			break;
		}
		float num2 = model?.Total ?? 0f;
		return (int)((float)num * (1f - num2));
	}
}
