using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class UIIslandBuffDetail
{
	public int IslandId;

	public bool IsMyIsland;

	public int OccupyStatus;

	public List<UIIslandBuff> UIIslandBuffs = new List<UIIslandBuff>();

	public int IslandUIType;

	public bool IsActiveToMyCamp;

	public IslandConfigData IslandConfigData => WorldMapConfigHelper.Configs.Islands_Dict[IslandId];

	public IslandStateModel IslandStateModel => Singleton<WorldStateManager>.Instance.TryGetIsland(IslandId);

	public void CheckOccupyStatus(int myCampId)
	{
		if (IslandStateModel.CampId == myCampId)
		{
			OccupyStatus = 1;
			return;
		}
		eGvGMode3IslandBelongStatus belongStatus = IslandStateModel.GetBelongStatus();
		GvGMode3DefenderZone gvGMode3DefenderZoneConfigs = WorldMapConfigHelper.GetGvGMode3DefenderZoneConfigs(IslandId);
		bool flag = IslandStateModel.IsIslandFullOfShips();
		bool flag2 = IslandStateModel.CanArrive();
		bool flag3 = true;
		switch (belongStatus)
		{
		case eGvGMode3IslandBelongStatus.Neutral:
			flag3 = IslandStateModel.ProtectedPeriodTimestamp <= GameController.Instance.GetServerTime();
			break;
		case eGvGMode3IslandBelongStatus.Enemy:
			flag3 = gvGMode3DefenderZoneConfigs.ProtectedPeriod >= 0 && IslandStateModel.ProtectedPeriodTimestamp <= GameController.Instance.GetServerTime();
			break;
		}
		if (flag2 && !flag && flag3)
		{
			OccupyStatus = 0;
		}
		else
		{
			OccupyStatus = 2;
		}
	}
}
