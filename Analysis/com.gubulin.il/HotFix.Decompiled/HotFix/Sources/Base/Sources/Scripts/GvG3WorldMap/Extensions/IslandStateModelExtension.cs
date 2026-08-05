using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;

public static class IslandStateModelExtension
{
	private static readonly HashSet<eIslandAction> _checkedActions = new HashSet<eIslandAction> { eIslandAction.Attack };

	public static bool GetVisibility(this IslandStateModel islandState, int watcherCampId)
	{
		return islandState.CampId == watcherCampId;
	}

	public static int Obedience(this IslandStateModel islandState)
	{
		return (islandState.ObedienceValue < 0f) ? 100 : Mathf.CeilToInt(islandState.ObedienceValue / (float)WorldMapConfigHelper.GetGvGMode3DefenderZoneConfigs(islandState.IslandId).NPCRebellionMax * 100f);
	}

	public static List<IslandUiAction> IslandValidUiActions(this IslandStateModel islandState, string shipId)
	{
		HashSet<IslandUiAction> hashSet = new HashSet<IslandUiAction>();
		bool flag = !string.IsNullOrEmpty(shipId);
		bool flag2 = islandState.State == eGvGMode3IslandState.Fighting;
		bool flag3 = Singleton<GvGMode3RoomManager>.Instance.IsIZInSettlement || Singleton<WorldStateManager>.Instance.Data.ProgressData.HasSettlement;
		C2S_GetFinalProgressInfo.FinalProgressBossInfo bossInfo = Singleton<GvG3FlagShipMissionsManager>.Instance.FinalProgressInfo.BossInfo;
		bool flag4 = bossInfo?.Resurrecting ?? false;
		bool flag5 = bossInfo?.EnterBossNearDeath ?? false;
		if (islandState.IsBossIsland())
		{
			hashSet.Add(new IslandUiAction
			{
				UiAction = (flag ? eIslandUiAction.Reinforce : eIslandUiAction.Attack),
				ActionEnabled = !(flag3 || flag4 || flag5),
				ActionType = "Attack"
			});
			hashSet.Add(new IslandUiAction
			{
				UiAction = eIslandUiAction.Watching,
				ActionEnabled = flag,
				ActionType = "Watching"
			});
			return new List<IslandUiAction>(hashSet);
		}
		eGvGMode3IslandBelongStatus belongStatus = islandState.GetBelongStatus();
		if (flag && flag2)
		{
			hashSet.Add(new IslandUiAction
			{
				UiAction = eIslandUiAction.Reinforce,
				ActionEnabled = true,
				ActionType = ((belongStatus == eGvGMode3IslandBelongStatus.OwnSide) ? "GoTo" : "Attack")
			});
			hashSet.Add(new IslandUiAction
			{
				UiAction = eIslandUiAction.Watching,
				ActionEnabled = true,
				ActionType = "Watching"
			});
			return new List<IslandUiAction>(hashSet);
		}
		GvGMode3DefenderZone gvGMode3DefenderZoneConfigs = WorldMapConfigHelper.GetGvGMode3DefenderZoneConfigs(islandState.IslandId);
		bool flag6 = islandState.IsIslandFullOfShips();
		bool flag7 = islandState.CanArrive();
		if (belongStatus != eGvGMode3IslandBelongStatus.OwnSide)
		{
			bool flag8 = true;
			switch (belongStatus)
			{
			case eGvGMode3IslandBelongStatus.Neutral:
				flag8 = islandState.ProtectedPeriodTimestamp <= GameController.Instance.GetServerTime();
				break;
			case eGvGMode3IslandBelongStatus.Enemy:
				flag8 = gvGMode3DefenderZoneConfigs.ProtectedPeriod >= 0 && islandState.ProtectedPeriodTimestamp <= GameController.Instance.GetServerTime();
				break;
			}
			hashSet.Add(new IslandUiAction
			{
				UiAction = eIslandUiAction.Attack,
				ActionEnabled = (flag7 && !flag6 && flag8),
				ActionType = "Attack"
			});
			return new List<IslandUiAction>(hashSet);
		}
		eGvGMode3IslandNPCStatus npcStatus = islandState.GetNpcStatus();
		if (islandState.State == eGvGMode3IslandState.Suppress)
		{
			hashSet.Add(new IslandUiAction
			{
				UiAction = (flag ? eIslandUiAction.Reinforce : eIslandUiAction.SuppressRebellion),
				ActionEnabled = true,
				ActionType = "SuppressRebellion"
			});
			if (flag)
			{
				hashSet.Add(new IslandUiAction
				{
					UiAction = eIslandUiAction.Watching,
					ActionEnabled = true,
					ActionType = "Watching"
				});
			}
			else
			{
				hashSet.Add(new IslandUiAction
				{
					UiAction = eIslandUiAction.GoTo,
					ActionEnabled = true,
					ActionType = "GoTo"
				});
			}
			return new List<IslandUiAction>(hashSet);
		}
		if (!flag && flag2)
		{
			hashSet.Add(new IslandUiAction
			{
				UiAction = eIslandUiAction.Reinforce,
				ActionEnabled = true,
				ActionType = "GoTo"
			});
			return new List<IslandUiAction>(hashSet);
		}
		IslandConfigData islandConfigData = WorldMapConfigHelper.Configs.TryGetIsland(islandState.IslandId);
		eIslandType type = islandConfigData.Props.Type;
		if (npcStatus == eGvGMode3IslandNPCStatus.Rebellion && type == eIslandType.Star)
		{
			WorldMapConfigHelper.SpecialSuppressIslandConfig config = WorldMapConfigHelper.SpecialSuppressIslandConfig.GetConfig();
			bool actionEnabled = WorldMapConfigHelper.GetGvGMode3DefenderZoneConfigs(islandState.IslandId).NPCRebellionMax > 0;
			if (config.SpecialSuppressIsland.Contains(islandConfigData.Props.GDEData.Key))
			{
				actionEnabled = true;
			}
			hashSet.Add(new IslandUiAction
			{
				UiAction = eIslandUiAction.SuppressRebellion,
				ActionEnabled = actionEnabled,
				ActionType = "SuppressRebellion"
			});
		}
		if (type == eIslandType.MainMoon || type == eIslandType.Moon)
		{
			hashSet.Add(new IslandUiAction
			{
				UiAction = eIslandUiAction.FillUpSoldier,
				ActionEnabled = true,
				ActionType = "FillUpSoldier"
			});
		}
		if (npcStatus == eGvGMode3IslandNPCStatus.Obedience && type == eIslandType.Star)
		{
			bool actionEnabled2 = islandState.DetailInfo.CollectingGroup != null && islandState.DetailInfo.CollectingGroup.Count > 0;
			hashSet.Add(new IslandUiAction
			{
				UiAction = eIslandUiAction.Collect,
				ActionEnabled = actionEnabled2,
				ActionType = "Collect"
			});
		}
		hashSet.Add(new IslandUiAction
		{
			UiAction = eIslandUiAction.GoTo,
			ActionEnabled = !flag6,
			ActionType = "GoTo"
		});
		return new List<IslandUiAction>(hashSet);
	}

	public static bool IsBossIsland(this IslandStateModel islandState)
	{
		if (WorldMapConfigHelper.Configs.IsBrawlEvent())
		{
			return false;
		}
		List<int> list = "GvGMode3FinalProgressIsland".ToConfiguration<Dictionary<string, List<int>>>()[Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.IZConfigId];
		return list.Contains(islandState.IslandId);
	}

	public static bool CanArrive(this IslandStateModel islandState)
	{
		bool result = false;
		int obCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
		List<int> conn = WorldMapConfigHelper.Configs.TryGetIsland(islandState.IslandId).Props.Conn;
		for (int i = 0; i < conn.Count; i++)
		{
			int campId = Singleton<WorldStateManager>.Instance.TryGetIsland(conn[i]).CampId;
			if (campId == obCampId)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public static bool IsIslandFullOfShips(this IslandStateModel islandState)
	{
		int obCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
		(int, int) tuple = (0, 0);
		if (islandState.CampShipCount != null)
		{
			foreach (var item2 in islandState.CampShipCount)
			{
				if (item2.Item1 != obCampId)
				{
					continue;
				}
				tuple = item2;
				break;
			}
		}
		int item = tuple.Item2;
		return item >= WorldMapConfigHelper.Configs.TryGetIsland(islandState.IslandId).CampMaxShipCount;
	}

	public static eGvGMode3IslandNPCStatus GetNpcStatus(this IslandStateModel islandState)
	{
		if (islandState == null)
		{
			return eGvGMode3IslandNPCStatus.Obedience;
		}
		if (islandState.CampId == 0)
		{
			return eGvGMode3IslandNPCStatus.Obedience;
		}
		if (islandState.ObedienceValue < 0f)
		{
			return eGvGMode3IslandNPCStatus.Obedience;
		}
		return (islandState.ObedienceValue > 0f) ? eGvGMode3IslandNPCStatus.Obedience : eGvGMode3IslandNPCStatus.Rebellion;
	}

	public static eGvGMode3IslandBelongStatus GetBelongStatus(this IslandStateModel islandState)
	{
		if (islandState != null && islandState.CampId <= 0)
		{
			return eGvGMode3IslandBelongStatus.Neutral;
		}
		if (islandState?.CampId == Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId)
		{
			return eGvGMode3IslandBelongStatus.OwnSide;
		}
		return eGvGMode3IslandBelongStatus.Enemy;
	}

	public static bool IslandAttackActionCheck(eIslandAction action = eIslandAction.Attack)
	{
		if (!_checkedActions.Contains(action))
		{
			return true;
		}
		int timeStamp = DateTimeHelper.GetTimeStamp(DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.ServerNow, DateTimeHelper.TimezoneOffset, TimeSpan.FromHours(0.0)));
		int num = timeStamp + 28800;
		int timeStamp2 = DateTimeHelper.GetTimeStamp(DateTimeHelper.ServerNow);
		return timeStamp2 >= num || timeStamp2 <= timeStamp;
	}
}
