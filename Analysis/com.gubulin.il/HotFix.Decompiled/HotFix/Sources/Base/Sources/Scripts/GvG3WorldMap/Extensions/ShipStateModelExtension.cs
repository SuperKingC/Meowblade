using System.Linq;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;

public static class ShipStateModelExtension
{
	public static bool SoldierNumNotEnough_Square(this ShipStateModel stateModel)
	{
		int num = stateModel.GroupInfo.Sum((GvGMode3UnitInfo group) => group.CurCnt);
		int num2 = stateModel.GroupInfo.Sum((GvGMode3UnitInfo group) => group.PerTeamMemberCnt);
		return num < num2;
	}

	public static bool SoldierIsFull(this ShipStateModel stateModel)
	{
		int num = stateModel.GroupInfo.Sum((GvGMode3UnitInfo group) => group.CurCnt);
		int num2 = stateModel.GroupInfo.Sum((GvGMode3UnitInfo group) => group.Total);
		foreach (GvGMode3UnitInfo item in stateModel.GroupInfo)
		{
			if (item.CurCnt != item.Total)
			{
				return false;
			}
		}
		foreach (GvGMode3UnitInfo item2 in stateModel.BackupGroupInfo)
		{
			if (item2.CurCnt != item2.Total)
			{
				return false;
			}
		}
		return true;
	}

	public static bool ShipIsExceptional(this ShipStateModel stateModel)
	{
		if (stateModel.State == eShipState.Rebuilding || stateModel.State == eShipState.NotLaunched)
		{
			return false;
		}
		return stateModel.CurrentUnitInfos == null || stateModel.CurrentUnitInfos.Count <= 0 || stateModel.WorkersOnboardCount < 1;
	}

	public static bool ShipGroupHasNotice(this ShipStateModel stateModel)
	{
		if (!stateModel.CanFillUpUnits())
		{
			return false;
		}
		if (stateModel.CurrentUnitInfos == null)
		{
			return true;
		}
		int num = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.BackupGroupSlotLimit + 5;
		int num2 = stateModel.CurrentUnitInfos.Count((GvGMode3UnitInfo t) => UnitInfoHelper.CheckIsValidSoldier(t.SoldierId));
		return num2 < num || stateModel.CurrentUnitInfos.Any((GvGMode3UnitInfo unit) => unit.CurCnt < unit.Total);
	}

	public static bool CanFillUpUnits(this ShipStateModel stateModel)
	{
		if (stateModel.State == eShipState.NotLaunched || stateModel.State == eShipState.Rebuilding)
		{
			return false;
		}
		IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(stateModel.StayIslandId);
		int ourFlagShipStayIslandId = Singleton<WorldStateManager>.Instance.Data.OurFlagShipStayIslandId;
		if (islandStateModel.IslandId == ourFlagShipStayIslandId && stateModel.State == eShipState.Stay)
		{
			return true;
		}
		eIslandType type = WorldMapConfigHelper.Configs.TryGetIsland(islandStateModel.IslandId).Props.Type;
		return stateModel.State == eShipState.Stay && islandStateModel.CampId == Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId && (type == eIslandType.MainMoon || type == eIslandType.Moon);
	}
}
