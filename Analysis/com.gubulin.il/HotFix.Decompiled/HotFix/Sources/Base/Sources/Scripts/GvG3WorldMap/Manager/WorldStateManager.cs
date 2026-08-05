using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FairyGUI;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.S2C;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.Talent;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Helper;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.BattlePass;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Ship;
using Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;
using Shift.Legion.Helpers;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;

public class WorldStateManager : Singleton<WorldStateManager>
{
	public bool IsLoadingEOIData = false;

	public Action OnCampProgressChange = delegate
	{
	};

	public Action<TreasureMapInfo> OnTreasureMapInfoChange = delegate
	{
	};

	public Action<ContributionPointsChanged> OnContributionPointsChanged = delegate
	{
	};

	public Action<ContributionPointsChanged> OnGainPointsThroughMission = delegate
	{
	};

	public Action<int> OnTotalContributionPointsChanged = delegate
	{
	};

	public Action<bool> OnAdvancedPaidCertChanged = delegate
	{
	};

	public Action<bool> OnPremiumPaidCertChanged = delegate
	{
	};

	public Action<bool> OnBattleResultRedDotChange = delegate
	{
	};

	public Action<IslandStateModel> UpdateFlagShipIslandCardOnArrival = delegate
	{
	};

	public Action OnCampFlagshipStayIslandChange = delegate
	{
	};

	private WorldStateModel _Data;

	private bool IsEventRegistered = false;

	private Action<bool> ShipJumpCallback;

	private Dictionary<int, int> LocalIslandVersions_Dict;

	private HashSet<int> WaitToUpdateIslandIds;

	private bool NeedToSaveLocalData;

	private Vector2 LastRequestedCamPos;

	public HashSet<int> AdditionalIslandIds = new HashSet<int>();

	public HashSet<int> BrawlFinalIslandIds = new HashSet<int>();

	private OuterTechHelper.Jump努力加餐饭Cost _jump努力加餐饭Cost;

	public WorldStateModel Data => _Data;

	public bool IsOurCampIslandVisible { get; private set; } = true;

	public void Init(GvGMode3ObserverRecord observerRecord)
	{
		if (_Data == null)
		{
			_Data = new WorldStateModel();
			_Data.MyCampId = observerRecord.ObCampId;
			_Data.CurIZId = observerRecord.CurIZId;
			_Data.IZConfigId = observerRecord.IZConfigId;
		}
		SyncMyOwnState(observerRecord);
	}

	public void InitBaseInfo_MiniData(C2S_GetGvGMode3BaseInfo.Response baseInfo)
	{
		Data.OuterTechModel = baseInfo.OuterTechModel;
		Data.RealTimeFoodOnBoardModel = baseInfo.RealTimeFoodOnBoardModel;
		Data.IZEndTimestamp = baseInfo.IZEndTimestamp;
		Data.IZBeginTimestamp = baseInfo.IZBeginTimestamp;
		Data.FinalProgressBegin = baseInfo.FinalProgressBegin;
		Data.WaitToClaimSystemMessageIdsCount = baseInfo.WaitToClaimSystemMessageIdsCount;
		Data.BattlePassInsuranceTimes = baseInfo.BattlePassInsuranceTimes;
		Data.DailySuppressBonusModel = baseInfo.DailySuppressBonusModel;
		SyncUnreachableIslands(baseInfo.UnreachableIslands);
		SyncUserPlayDays(baseInfo.UserPlayDays);
		SyncBattlePassDataVersion(baseInfo.BattlePassVersion);
		SyncBattlePassClaimedBonus(baseInfo.BattlePassClaimedBonusDic);
		SyncBattlePassBuyAdvancedPaidCert(baseInfo.HasBattlePassPaidCert);
		SyncBattlePassBuyPremiumPaidCert(baseInfo.HasBattlePassPremiumPaidCert);
		SyncTotalContributionPointsChange(baseInfo.TotalContributionPoints);
		SyncInsuranceShipId(baseInfo.InsuranceShipId);
		WaitToUpdateIslandIds = new HashSet<int>();
	}

	public IEnumerator InitBaseInfo_BigData(C2S_GetGvGMode3BaseInfo.Response baseInfo)
	{
		Sync地貌勘探ObDetectedIslandsByData(baseInfo.DetectedIslands);
		SyncTalents(baseInfo.ActiveTalents, baseInfo.SpecialTalents);
		SyncTreasureMapInfo(baseInfo.TreasureMap_MUID, baseInfo.TreasureMap_MConfigId, baseInfo.TreasureMap_Timestamp_ms, baseInfo.TreasureMap_IslandId);
		SyncFlagshipInfo(new PlayerFlagshipInfo
		{
			FlagShipCurFood = baseInfo.FlagShipCurFood,
			FlagShipMaxFood = baseInfo.FlagShipMaxFood,
			DailyContributionBoxClaimed = baseInfo.DailyContributionBoxClaimed,
			DailySupplyPackClaimed = baseInfo.DailySupplyPackClaimed,
			OEMAmplifiersCanBeReceived = baseInfo.OEMAmplifiersCanBeReceived,
			OEMAmplifiersHasFailed = baseInfo.OEMAmplifiersHasFailed,
			FlagShipMissionLastRefreshTimestamp = baseInfo.FlagShipMissionLastRefreshTimestamp,
			PollutantsCanBePurified = baseInfo.PollutantsCanBePurified
		});
		foreach (FlagShipStateInfo info in baseInfo.FlagShipStateInfo)
		{
			AddFlagShipByCampId(info.CampId);
			SyncFlagShipStayIslandId(info);
			if (info.CampId == Data.MyCampId)
			{
				SyncCampProgress(info.Progress, info.Step, baseInfo.HasSettlement, baseInfo.SettlementTimestamp, baseInfo.jsonPlayerBuffQueue);
			}
		}
		foreach (FlagShipAttackEvent attackEvent in baseInfo.FlagShipAttackEvent)
		{
			SyncFlagShipAttackEvent(attackEvent);
		}
		if (LoadingHelper.ShouldYield_EnterIZ())
		{
			yield return null;
		}
		using (List<int>.Enumerator enumerator3 = baseInfo.UserIds.GetEnumerator())
		{
			while (enumerator3.MoveNext())
			{
				GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions(userId: enumerator3.Current, cacheVersion: $"{Data.CurIZId}"));
			}
		}
		if (LoadingHelper.ShouldYield_EnterIZ())
		{
			yield return null;
		}
		LocalIslandVersions_Dict = GetLocalIslandVersions();
		WaitToUpdateIslandIds.UnionWith(GetWaitToUpdateIslandId(LocalIslandVersions_Dict, baseInfo.IslandDataVersion));
	}

	public void ClearData()
	{
		_Data = null;
		FieldInfo[] fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		FieldInfo[] array = fields;
		foreach (FieldInfo fieldInfo in array)
		{
			if (fieldInfo.FieldType == typeof(Action) || (fieldInfo.FieldType.IsGenericType && fieldInfo.FieldType.GetGenericTypeDefinition() == typeof(Action<>)))
			{
				fieldInfo.SetValue(this, null);
			}
		}
	}

	[Obsolete]
	public IEnumerator InitCoroutine()
	{
		if (_Data != null)
		{
			yield break;
		}
		_Data = new WorldStateModel();
		Dictionary<int, IslandConfigData> configs = WorldMapConfigHelper.Configs.Islands_Dict;
		foreach (IslandConfigData island in configs.Values)
		{
			IslandProps props = island.Props;
			IslandStateModel model = new IslandStateModel
			{
				IslandId = props.Id,
				CampId = 0
			};
			_Data.Islands.Add(props.Id, model);
			if (LoadingHelper.ShouldYield_EnterIZ())
			{
				yield return null;
			}
		}
	}

	public void RegisterSocketEvents()
	{
		//IL_0429: Unknown result type (might be due to invalid IL or missing references)
		//IL_0433: Expected O, but got Unknown
		if (!IsEventRegistered)
		{
			IsEventRegistered = true;
			S2C_IslandAction.OnPushEvent = (Action<S2C_IslandAction.Request>)Delegate.Combine(S2C_IslandAction.OnPushEvent, new Action<S2C_IslandAction.Request>(OnPushIslandAction));
			S2C_StayIsland.OnPushEvent = (Action<S2C_StayIsland.Request>)Delegate.Combine(S2C_StayIsland.OnPushEvent, new Action<S2C_StayIsland.Request>(OnPushStayIsland));
			S2C_GvGMode3ShipSummarySpeed.OnPushEvent = (Action<S2C_GvGMode3ShipSummarySpeed.Request>)Delegate.Combine(S2C_GvGMode3ShipSummarySpeed.OnPushEvent, new Action<S2C_GvGMode3ShipSummarySpeed.Request>(OnPushShipSummary));
			S2C_SyncSoldierInfo.OnPushEvent = (Action<S2C_SyncSoldierInfo.Request>)Delegate.Combine(S2C_SyncSoldierInfo.OnPushEvent, new Action<S2C_SyncSoldierInfo.Request>(OnPushSoldierInfo));
			S2C_GvGMode3IslandEntityInfo.OnPushEvent = (Action<S2C_GvGMode3IslandEntityInfo.Request>)Delegate.Combine(S2C_GvGMode3IslandEntityInfo.OnPushEvent, new Action<S2C_GvGMode3IslandEntityInfo.Request>(OnPushIslandInfo));
			S2C_FillupSoldiers.OnPushEvent = (Action<S2C_FillupSoldiers.Request>)Delegate.Combine(S2C_FillupSoldiers.OnPushEvent, new Action<S2C_FillupSoldiers.Request>(OnPushFillUpShipSoldiers));
			S2C_SyncSoldierCount.OnPushEvent = (Action<S2C_SyncSoldierCount.Request>)Delegate.Combine(S2C_SyncSoldierCount.OnPushEvent, new Action<S2C_SyncSoldierCount.Request>(OnPushSoldierCount));
			S2C_GroupCountLimit.OnPushEvent = (Action<S2C_GroupCountLimit.Request>)Delegate.Combine(S2C_GroupCountLimit.OnPushEvent, new Action<S2C_GroupCountLimit.Request>(OnPushGroupCountLimitChange));
			S2C_BackupGroupSlotLimit.OnPushEvent = (Action<S2C_BackupGroupSlotLimit.Request>)Delegate.Combine(S2C_BackupGroupSlotLimit.OnPushEvent, new Action<S2C_BackupGroupSlotLimit.Request>(OnPushBackupGroupSlotLimitChange));
			S2C_ShipSightRange.OnPushEvent = (Action<S2C_ShipSightRange.Request>)Delegate.Combine(S2C_ShipSightRange.OnPushEvent, new Action<S2C_ShipSightRange.Request>(OnPushShipSightRange));
			S2C_地貌勘探ObDetectedIslands.OnPushEvent = (Action<S2C_地貌勘探ObDetectedIslands.Request>)Delegate.Combine(S2C_地貌勘探ObDetectedIslands.OnPushEvent, new Action<S2C_地貌勘探ObDetectedIslands.Request>(OnPush地貌勘探ObDetectedIslands));
			S2C_FlagShipState.OnPushEvent = (Action<S2C_FlagShipState.Request>)Delegate.Combine(S2C_FlagShipState.OnPushEvent, new Action<S2C_FlagShipState.Request>(OnPushFlagShipState));
			S2C_FoodOnBoard.OnPushEvent = (Action<S2C_FoodOnBoard.Request>)Delegate.Combine(S2C_FoodOnBoard.OnPushEvent, new Action<S2C_FoodOnBoard.Request>(OnPushFoodOnBoard));
			S2C_SyncRunningTreasureMapEvent.OnPushEvent = (Action<S2C_SyncRunningTreasureMapEvent.Request>)Delegate.Combine(S2C_SyncRunningTreasureMapEvent.OnPushEvent, new Action<S2C_SyncRunningTreasureMapEvent.Request>(OnPushTreasureMapInfo));
			S2C_ContributionPointsChanged.OnPushEvent = (Action<S2C_ContributionPointsChanged.Request>)Delegate.Combine(S2C_ContributionPointsChanged.OnPushEvent, new Action<S2C_ContributionPointsChanged.Request>(OnPushContributionPointsChanged));
			S2C_BattlePassPaidCertChanged.OnPushEvent = (Action<S2C_BattlePassPaidCertChanged.Request>)Delegate.Combine(S2C_BattlePassPaidCertChanged.OnPushEvent, new Action<S2C_BattlePassPaidCertChanged.Request>(OnPushBattlePassPaidCertChanged));
			S2C_BattlePassPaidCertChanged.OnPushEvent = (Action<S2C_BattlePassPaidCertChanged.Request>)Delegate.Combine(S2C_BattlePassPaidCertChanged.OnPushEvent, new Action<S2C_BattlePassPaidCertChanged.Request>(OnPushBattlePassInsuranceTimesChanged));
			S2C_ShipJump.OnPushEvent = (Action<S2C_ShipJump.Request>)Delegate.Combine(S2C_ShipJump.OnPushEvent, new Action<S2C_ShipJump.Request>(OnPushShipJump));
			S2C_GvGMode3NewIOI.OnPushEvent = (Action<S2C_GvGMode3NewIOI.Request>)Delegate.Combine(S2C_GvGMode3NewIOI.OnPushEvent, new Action<S2C_GvGMode3NewIOI.Request>(OnPushNewIOI));
			S2C_WaitToClaimSystemMessageIdsCount.OnPushEvent = (Action<S2C_WaitToClaimSystemMessageIdsCount.Request>)Delegate.Combine(S2C_WaitToClaimSystemMessageIdsCount.OnPushEvent, new Action<S2C_WaitToClaimSystemMessageIdsCount.Request>(OnPushWaitToClaim));
			S2C_SyncFinalProgressInfo.OnPushEvent = (Action<S2C_SyncFinalProgressInfo.Request>)Delegate.Combine(S2C_SyncFinalProgressInfo.OnPushEvent, new Action<S2C_SyncFinalProgressInfo.Request>(OnSyncFinalProgressInfo));
			S2C_AttackEvent.OnPushEvent = (Action<S2C_AttackEvent.Request>)Delegate.Combine(S2C_AttackEvent.OnPushEvent, new Action<S2C_AttackEvent.Request>(OnPushFlagShipAttackEvent));
			S2C_SoulGuideCooldown.OnPushEvent = (Action<S2C_SoulGuideCooldown.Request>)Delegate.Combine(S2C_SoulGuideCooldown.OnPushEvent, new Action<S2C_SoulGuideCooldown.Request>(OnPushSoulGuideCooldown));
			S2C_SelfOEMMissionChanged.OnPushEvent = (Action<S2C_SelfOEMMissionChanged.Request>)Delegate.Combine(S2C_SelfOEMMissionChanged.OnPushEvent, new Action<S2C_SelfOEMMissionChanged.Request>(OnPushUpdateSelfOEMMissions));
			S2C_GvGMode3UnreachableIslands.OnPushEvent = (Action<S2C_GvGMode3UnreachableIslands.Request>)Delegate.Combine(S2C_GvGMode3UnreachableIslands.OnPushEvent, new Action<S2C_GvGMode3UnreachableIslands.Request>(OnPushUnreachableIslands));
			S2C_RealTime火力支援MaxTimeOfUsageModel.OnPushEvent = (Action<S2C_RealTime火力支援MaxTimeOfUsageModel.Request>)Delegate.Combine(S2C_RealTime火力支援MaxTimeOfUsageModel.OnPushEvent, new Action<S2C_RealTime火力支援MaxTimeOfUsageModel.Request>(OnPush火力支援MaxTimeOfUsageModel));
			S2C_SoldierLegendItem.OnPushEvent = (Action<S2C_SoldierLegendItem.Request>)Delegate.Combine(S2C_SoldierLegendItem.OnPushEvent, new Action<S2C_SoldierLegendItem.Request>(OnPushSoldierLegendItem));
			S2C_ShipContinueExecutePlan.OnPushEvent = (Action<S2C_ShipContinueExecutePlan.Request>)Delegate.Combine(S2C_ShipContinueExecutePlan.OnPushEvent, new Action<S2C_ShipContinueExecutePlan.Request>(OnShipContinueExecutePlan));
			S2C_ShipPlanChangeSoldier.OnPushEvent = (Action<S2C_ShipPlanChangeSoldier.Request>)Delegate.Combine(S2C_ShipPlanChangeSoldier.OnPushEvent, new Action<S2C_ShipPlanChangeSoldier.Request>(OnSoldierStockLimitChange));
			S2C_ResetOuterTech.OnPushEvent = (Action<S2C_ResetOuterTech.Request>)Delegate.Combine(S2C_ResetOuterTech.OnPushEvent, new Action<S2C_ResetOuterTech.Request>(OnPushResetOuterTech));
			S2C_OuterTechHideRefresh.OnPushEvent = (Action<S2C_OuterTechHideRefresh.Request>)Delegate.Combine(S2C_OuterTechHideRefresh.OnPushEvent, new Action<S2C_OuterTechHideRefresh.Request>(OnPushOuterTechHideRefresh));
			S2C_DailySuppressBonusTimesChange.OnPushEvent = (Action<S2C_DailySuppressBonusTimesChange.Request>)Delegate.Combine(S2C_DailySuppressBonusTimesChange.OnPushEvent, new Action<S2C_DailySuppressBonusTimesChange.Request>(OnPushDailySuppressBonusTimesChange));
			Timers.inst.Add(5f, 0, new TimerCallback(OnTrySaveLocalData));
		}
	}

	public void UnregisterSocketEvents()
	{
		//IL_0406: Unknown result type (might be due to invalid IL or missing references)
		//IL_0410: Expected O, but got Unknown
		if (!IsEventRegistered)
		{
			return;
		}
		IsEventRegistered = false;
		S2C_IslandAction.OnPushEvent = (Action<S2C_IslandAction.Request>)Delegate.Remove(S2C_IslandAction.OnPushEvent, new Action<S2C_IslandAction.Request>(OnPushIslandAction));
		S2C_StayIsland.OnPushEvent = (Action<S2C_StayIsland.Request>)Delegate.Remove(S2C_StayIsland.OnPushEvent, new Action<S2C_StayIsland.Request>(OnPushStayIsland));
		S2C_GvGMode3ShipSummarySpeed.OnPushEvent = (Action<S2C_GvGMode3ShipSummarySpeed.Request>)Delegate.Remove(S2C_GvGMode3ShipSummarySpeed.OnPushEvent, new Action<S2C_GvGMode3ShipSummarySpeed.Request>(OnPushShipSummary));
		S2C_SyncSoldierInfo.OnPushEvent = (Action<S2C_SyncSoldierInfo.Request>)Delegate.Remove(S2C_SyncSoldierInfo.OnPushEvent, new Action<S2C_SyncSoldierInfo.Request>(OnPushSoldierInfo));
		S2C_GvGMode3IslandEntityInfo.OnPushEvent = (Action<S2C_GvGMode3IslandEntityInfo.Request>)Delegate.Remove(S2C_GvGMode3IslandEntityInfo.OnPushEvent, new Action<S2C_GvGMode3IslandEntityInfo.Request>(OnPushIslandInfo));
		S2C_FillupSoldiers.OnPushEvent = (Action<S2C_FillupSoldiers.Request>)Delegate.Remove(S2C_FillupSoldiers.OnPushEvent, new Action<S2C_FillupSoldiers.Request>(OnPushFillUpShipSoldiers));
		S2C_SyncSoldierCount.OnPushEvent = (Action<S2C_SyncSoldierCount.Request>)Delegate.Remove(S2C_SyncSoldierCount.OnPushEvent, new Action<S2C_SyncSoldierCount.Request>(OnPushSoldierCount));
		S2C_GroupCountLimit.OnPushEvent = (Action<S2C_GroupCountLimit.Request>)Delegate.Remove(S2C_GroupCountLimit.OnPushEvent, new Action<S2C_GroupCountLimit.Request>(OnPushGroupCountLimitChange));
		S2C_BackupGroupSlotLimit.OnPushEvent = (Action<S2C_BackupGroupSlotLimit.Request>)Delegate.Remove(S2C_BackupGroupSlotLimit.OnPushEvent, new Action<S2C_BackupGroupSlotLimit.Request>(OnPushBackupGroupSlotLimitChange));
		S2C_ShipSightRange.OnPushEvent = (Action<S2C_ShipSightRange.Request>)Delegate.Remove(S2C_ShipSightRange.OnPushEvent, new Action<S2C_ShipSightRange.Request>(OnPushShipSightRange));
		S2C_地貌勘探ObDetectedIslands.OnPushEvent = (Action<S2C_地貌勘探ObDetectedIslands.Request>)Delegate.Remove(S2C_地貌勘探ObDetectedIslands.OnPushEvent, new Action<S2C_地貌勘探ObDetectedIslands.Request>(OnPush地貌勘探ObDetectedIslands));
		S2C_FlagShipState.OnPushEvent = (Action<S2C_FlagShipState.Request>)Delegate.Remove(S2C_FlagShipState.OnPushEvent, new Action<S2C_FlagShipState.Request>(OnPushFlagShipState));
		S2C_FoodOnBoard.OnPushEvent = (Action<S2C_FoodOnBoard.Request>)Delegate.Remove(S2C_FoodOnBoard.OnPushEvent, new Action<S2C_FoodOnBoard.Request>(OnPushFoodOnBoard));
		S2C_SyncRunningTreasureMapEvent.OnPushEvent = (Action<S2C_SyncRunningTreasureMapEvent.Request>)Delegate.Remove(S2C_SyncRunningTreasureMapEvent.OnPushEvent, new Action<S2C_SyncRunningTreasureMapEvent.Request>(OnPushTreasureMapInfo));
		S2C_ContributionPointsChanged.OnPushEvent = (Action<S2C_ContributionPointsChanged.Request>)Delegate.Remove(S2C_ContributionPointsChanged.OnPushEvent, new Action<S2C_ContributionPointsChanged.Request>(OnPushContributionPointsChanged));
		S2C_BattlePassPaidCertChanged.OnPushEvent = (Action<S2C_BattlePassPaidCertChanged.Request>)Delegate.Remove(S2C_BattlePassPaidCertChanged.OnPushEvent, new Action<S2C_BattlePassPaidCertChanged.Request>(OnPushBattlePassPaidCertChanged));
		S2C_BattlePassPaidCertChanged.OnPushEvent = (Action<S2C_BattlePassPaidCertChanged.Request>)Delegate.Remove(S2C_BattlePassPaidCertChanged.OnPushEvent, new Action<S2C_BattlePassPaidCertChanged.Request>(OnPushBattlePassInsuranceTimesChanged));
		S2C_ShipJump.OnPushEvent = (Action<S2C_ShipJump.Request>)Delegate.Remove(S2C_ShipJump.OnPushEvent, new Action<S2C_ShipJump.Request>(OnPushShipJump));
		S2C_GvGMode3NewIOI.OnPushEvent = (Action<S2C_GvGMode3NewIOI.Request>)Delegate.Remove(S2C_GvGMode3NewIOI.OnPushEvent, new Action<S2C_GvGMode3NewIOI.Request>(OnPushNewIOI));
		S2C_WaitToClaimSystemMessageIdsCount.OnPushEvent = (Action<S2C_WaitToClaimSystemMessageIdsCount.Request>)Delegate.Remove(S2C_WaitToClaimSystemMessageIdsCount.OnPushEvent, new Action<S2C_WaitToClaimSystemMessageIdsCount.Request>(OnPushWaitToClaim));
		S2C_SyncFinalProgressInfo.OnPushEvent = (Action<S2C_SyncFinalProgressInfo.Request>)Delegate.Remove(S2C_SyncFinalProgressInfo.OnPushEvent, new Action<S2C_SyncFinalProgressInfo.Request>(OnSyncFinalProgressInfo));
		S2C_AttackEvent.OnPushEvent = (Action<S2C_AttackEvent.Request>)Delegate.Remove(S2C_AttackEvent.OnPushEvent, new Action<S2C_AttackEvent.Request>(OnPushFlagShipAttackEvent));
		S2C_SoulGuideCooldown.OnPushEvent = (Action<S2C_SoulGuideCooldown.Request>)Delegate.Remove(S2C_SoulGuideCooldown.OnPushEvent, new Action<S2C_SoulGuideCooldown.Request>(OnPushSoulGuideCooldown));
		S2C_SelfOEMMissionChanged.OnPushEvent = (Action<S2C_SelfOEMMissionChanged.Request>)Delegate.Remove(S2C_SelfOEMMissionChanged.OnPushEvent, new Action<S2C_SelfOEMMissionChanged.Request>(OnPushUpdateSelfOEMMissions));
		S2C_GvGMode3UnreachableIslands.OnPushEvent = (Action<S2C_GvGMode3UnreachableIslands.Request>)Delegate.Remove(S2C_GvGMode3UnreachableIslands.OnPushEvent, new Action<S2C_GvGMode3UnreachableIslands.Request>(OnPushUnreachableIslands));
		S2C_RealTime火力支援MaxTimeOfUsageModel.OnPushEvent = (Action<S2C_RealTime火力支援MaxTimeOfUsageModel.Request>)Delegate.Remove(S2C_RealTime火力支援MaxTimeOfUsageModel.OnPushEvent, new Action<S2C_RealTime火力支援MaxTimeOfUsageModel.Request>(OnPush火力支援MaxTimeOfUsageModel));
		S2C_ShipContinueExecutePlan.OnPushEvent = (Action<S2C_ShipContinueExecutePlan.Request>)Delegate.Remove(S2C_ShipContinueExecutePlan.OnPushEvent, new Action<S2C_ShipContinueExecutePlan.Request>(OnShipContinueExecutePlan));
		S2C_ShipPlanChangeSoldier.OnPushEvent = (Action<S2C_ShipPlanChangeSoldier.Request>)Delegate.Remove(S2C_ShipPlanChangeSoldier.OnPushEvent, new Action<S2C_ShipPlanChangeSoldier.Request>(OnSoldierStockLimitChange));
		S2C_ResetOuterTech.OnPushEvent = (Action<S2C_ResetOuterTech.Request>)Delegate.Remove(S2C_ResetOuterTech.OnPushEvent, new Action<S2C_ResetOuterTech.Request>(OnPushResetOuterTech));
		S2C_OuterTechHideRefresh.OnPushEvent = (Action<S2C_OuterTechHideRefresh.Request>)Delegate.Remove(S2C_OuterTechHideRefresh.OnPushEvent, new Action<S2C_OuterTechHideRefresh.Request>(OnPushOuterTechHideRefresh));
		S2C_DailySuppressBonusTimesChange.OnPushEvent = (Action<S2C_DailySuppressBonusTimesChange.Request>)Delegate.Remove(S2C_DailySuppressBonusTimesChange.OnPushEvent, new Action<S2C_DailySuppressBonusTimesChange.Request>(OnPushDailySuppressBonusTimesChange));
		Timers.inst.Remove(new TimerCallback(OnTrySaveLocalData));
		foreach (ShipStateModel value in Data.Ships.Values)
		{
			value.UnregisterOnChangeEvents();
		}
		foreach (IslandStateModel value2 in Data.Islands.Values)
		{
			value2.UnregisterOnChangeEvents();
		}
	}

	public void Acrivate火力支援ToIsland(int islandId, Action<int> onFinished = null)
	{
		if (Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.火力支援TimeOfUsage > 0)
		{
			Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.火力支援TimeOfUsage--;
		}
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_Activate火力支援
		{
			Req = new C2S_Activate火力支援.Request
			{
				IslandId = islandId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_Activate火力支援.Response response = (C2S_Activate火力支援.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFinished?.Invoke(response.ErrorCode);
			}
			else
			{
				Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.火力支援TimeOfUsage = response.TimeOfUsage_Base;
				onFinished?.Invoke(response.ErrorCode);
			}
		});
	}

	public void ShipReturnToLastIsland(int entityId, Action onSuccess = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_ShipReturnToLastIsland
		{
			Req = new C2S_ShipReturnToLastIsland.Request
			{
				ShipEntityId = entityId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_ShipReturnToLastIsland.Response response = (C2S_ShipReturnToLastIsland.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				ShipStateModel shipStateModel = TryGetShip(entityId);
				shipStateModel.ReturningCDTimestamp = (int)GameController.Instance.GetServerTime() + 60;
				onSuccess?.Invoke();
			}
		});
	}

	public void UseTalent勘探强化Detect(int entityId, Action<C2S_UseTalent勘探强化Detect.Response> onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_UseTalent勘探强化Detect
		{
			Req = new C2S_UseTalent勘探强化Detect.Request
			{
				ShipEntityId = entityId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_UseTalent勘探强化Detect.Response response = (C2S_UseTalent勘探强化Detect.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			onFinished?.Invoke(response);
		});
	}

	public void GetTalent勘探强化CountDown(Action<C2S_GetTalent勘探强化CountDown.Response> onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetTalent勘探强化CountDown
		{
			Req = new C2S_GetTalent勘探强化CountDown.Request()
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetTalent勘探强化CountDown.Response response = (C2S_GetTalent勘探强化CountDown.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				onFinished?.Invoke(response);
			}
		});
	}

	public void FillUpShipSoldiers(int shipEntityId, Action onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_FillupSoldiers
		{
			Req = new C2S_FillupSoldiers.Request
			{
				ShipEntityId = shipEntityId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_FillupSoldiers.Response response = (C2S_FillupSoldiers.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				onFinished?.Invoke();
			}
		});
	}

	public void GetIslandShipsForDisplay(List<int> islandIds, Action onSuccess = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetIslandShipsForDisplay
		{
			Req = new C2S_GetIslandShipsForDisplay.Request
			{
				IslandIds = islandIds
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetIslandShipsForDisplay.Response response = (C2S_GetIslandShipsForDisplay.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (response.IslandShips != null)
				{
					foreach (EOI_IslandShipInfoOnIsland islandShip in response.IslandShips)
					{
						IslandStateModel islandStateModel = TryGetIsland(islandShip.IslandId);
						islandStateModel.SyncCampShips(islandShip);
					}
				}
				onSuccess?.Invoke();
			}
		});
	}

	public void GetEOIEntityIdsByCameraPos(Vec2 camPos2d, Action onFinished = null)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		IsLoadingEOIData = true;
		int num = (int)(camPos2d.x * 1000f);
		int num2 = (int)(camPos2d.y * 1000f);
		LastRequestedCamPos = new Vector2((float)num, (float)num2);
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_ChangeCameraPos
		{
			Req = new C2S_ChangeCameraPos.Request
			{
				X = num,
				Z = num2
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_ChangeCameraPos.Response response = (C2S_ChangeCameraPos.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				IsLoadingEOIData = false;
				onFinished?.Invoke();
			}
			else if (LastRequestedCamPos.x == (float)response.X && LastRequestedCamPos.y == (float)response.Z)
			{
				if (response.EOI_ShipEntityIds != null)
				{
					Data.EOI_ShipEntityIds = response.EOI_ShipEntityIds;
					List<int> list = new List<int>();
					foreach (EOI_ShipInfo eOI_ShipEntityId in response.EOI_ShipEntityIds)
					{
						list.Add(eOI_ShipEntityId.ShipEntityId);
						TryAddShip(eOI_ShipEntityId.ShipEntityId, eOI_ShipEntityId.CampId, eOI_ShipEntityId.UserId, (eRace)eOI_ShipEntityId.ShipRace);
					}
					Data.EOI_ShipSimpleEntityIds = list.Distinct().ToList();
				}
				else
				{
					Data.EOI_ShipEntityIds = new List<EOI_ShipInfo>();
					Data.EOI_ShipSimpleEntityIds = new List<int>();
				}
				IsLoadingEOIData = false;
				onFinished?.Invoke();
			}
		});
	}

	public void GetNeedToSyncEOIEntityIdsByCameraPos(Vec2 camPos2d, Action onFinished = null)
	{
		if (!Singleton<GvGMode3RoomManager>.Instance.IsConnecting)
		{
			IsLoadingEOIData = false;
			Data.EOI_ShipEntityIds = new List<EOI_ShipInfo>();
			Data.EOI_ShipSimpleEntityIds = new List<int>();
			onFinished?.Invoke();
			return;
		}
		IsLoadingEOIData = true;
		int x = (int)(camPos2d.x * 1000f);
		int z = (int)(camPos2d.y * 1000f);
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetNeedToSyncEOIShips
		{
			Req = new C2S_GetNeedToSyncEOIShips.Request
			{
				X = x,
				Z = z
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetNeedToSyncEOIShips.Response response = (C2S_GetNeedToSyncEOIShips.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				IsLoadingEOIData = false;
				onFinished?.Invoke();
			}
			else
			{
				if (response.NeedToSyncShips != null)
				{
					Data.EOI_ShipEntityIds = response.NeedToSyncShips;
					List<int> list = new List<int>();
					foreach (EOI_ShipInfo needToSyncShip in response.NeedToSyncShips)
					{
						list.Add(needToSyncShip.ShipEntityId);
						TryAddShip(needToSyncShip.ShipEntityId, needToSyncShip.CampId, needToSyncShip.UserId, (eRace)needToSyncShip.ShipRace);
					}
					Data.EOI_ShipSimpleEntityIds = list.Distinct().ToList();
				}
				else
				{
					Data.EOI_ShipEntityIds = new List<EOI_ShipInfo>();
					Data.EOI_ShipSimpleEntityIds = new List<int>();
				}
				IsLoadingEOIData = false;
				onFinished?.Invoke();
			}
		});
	}

	public void GetIslandsState(List<int> islandIds, Action onFinished = null, bool isForceSync = false)
	{
		List<int> list = islandIds;
		if (!isForceSync)
		{
			if (WaitToUpdateIslandIds.Count == 0)
			{
				onFinished?.Invoke();
				return;
			}
			list = new List<int>();
			foreach (int islandId in islandIds)
			{
				if (WaitToUpdateIslandIds.Contains(islandId))
				{
					list.Add(islandId);
				}
			}
		}
		if (list.Count == 0)
		{
			onFinished?.Invoke();
			return;
		}
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetGvGMode3IslandEntityInfos
		{
			Req = new C2S_GetGvGMode3IslandEntityInfos.Request
			{
				ExceptIslandIds = list
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetGvGMode3IslandEntityInfos.Response response = (C2S_GetGvGMode3IslandEntityInfos.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFinished?.Invoke();
			}
			else
			{
				foreach (GvGMode3IslandEntityInfo info in response.Infos)
				{
					UpdateIslandState(info);
				}
				onFinished?.Invoke();
			}
		});
	}

	public void GetShipsState(List<int> shipEntityIds, Action onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GvGMode3GetShipSummaryAndFlightScheduleInfo
		{
			Req = new C2S_GvGMode3GetShipSummaryAndFlightScheduleInfo.Request
			{
				ShipEntityIds = shipEntityIds
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GvGMode3GetShipSummaryAndFlightScheduleInfo.Response response = (C2S_GvGMode3GetShipSummaryAndFlightScheduleInfo.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFinished?.Invoke();
			}
			else
			{
				int userId = GameController.Contexts.gameState.user.value.UserId;
				foreach (GvGMode3GetShipSummaryAndFlightScheduleInfo info in response.Infos)
				{
					ShipStateModel shipStateModel = TryGetShip(info.EntityId);
					shipStateModel.SyncInfo(info);
				}
				onFinished?.Invoke();
			}
		});
	}

	public void GetUnitDetailInfo(int shipEntityId, string soldierId, Action onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetUnitDetailInfo
		{
			Req = new C2S_GetUnitDetailInfo.Request
			{
				ShipEntityId = shipEntityId,
				SoldierId = soldierId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetUnitDetailInfo.Response response = (C2S_GetUnitDetailInfo.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFinished?.Invoke();
			}
			else
			{
				TryGetShip(shipEntityId).SyncInfoFromGetUnitDetailInfo(soldierId, response);
				onFinished?.Invoke();
			}
		});
	}

	public void ChangeShipCollectingInfo(int shipEntityId, List<string> stockModelIds, Action onFinished = null)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_ChangeShipCollectingInfo
		{
			Req = new C2S_ChangeShipCollectingInfo.Request
			{
				ShipEntityId = shipEntityId,
				StockModelIds = stockModelIds
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_ChangeShipCollectingInfo.Response response = (C2S_ChangeShipCollectingInfo.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				TryGetShip(shipEntityId).SyncInfoFromChangeShipCollecting(response);
				onFinished?.Invoke();
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			}
		});
	}

	public void GetIslandDetail(int islandId, Action<IslandStateModel> onSuccess = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetGvGMode3IslandDetailInfo
		{
			Req = new C2S_GetGvGMode3IslandDetailInfo.Request
			{
				IslandId = islandId,
				ShipId = string.Empty
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetGvGMode3IslandDetailInfo.Response response = (C2S_GetGvGMode3IslandDetailInfo.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(islandId);
				islandStateModel.SyncDetailInfo(response.Info);
				islandStateModel.SyncIslandEvents(response.Info.IslandEventsProgress);
				onSuccess?.Invoke(islandStateModel);
			}
		});
	}

	public void GetShipNearestFlagShipOrMoonIsland(int shipEntityId, Action<int> onSuccess = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetShipNearestFlagShipOrMoonIsland
		{
			Req = new C2S_GetShipNearestFlagShipOrMoonIsland.Request
			{
				ShipEntityId = shipEntityId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetShipNearestFlagShipOrMoonIsland.Response response = (C2S_GetShipNearestFlagShipOrMoonIsland.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				onSuccess?.Invoke(response.IslandId);
			}
		});
	}

	public void GetAllContributionExcludingBuy(Action<List<Contribution>> onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetAllContributionExcludingBuy
		{
			Req = new C2S_GetAllContributionExcludingBuy.Request
			{
				non = 0
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetAllContributionExcludingBuy.Response response = (C2S_GetAllContributionExcludingBuy.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				onFinished?.Invoke(response.ContributionInfo);
			}
		});
	}

	public void ClaimBattlePassBonus(string activityId, string node, Action onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_ClaimBattlePassBonus
		{
			Req = new C2S_ClaimBattlePassBonus.Request
			{
				ActivityId = activityId,
				Node = node
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_ClaimBattlePassBonus.Response response = (C2S_ClaimBattlePassBonus.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				List<int> value = (string.IsNullOrEmpty(response.BattlePassClaimedBonus) ? new List<int>() : JsonHelper.ToObject<List<int>>(response.BattlePassClaimedBonus));
				if (Data.BattlePassClaimedBonus == null)
				{
					Data.BattlePassClaimedBonus = new Dictionary<string, List<int>>();
				}
				Data.BattlePassClaimedBonus[activityId] = value;
				onFinished?.Invoke();
			}
		});
	}

	public void SaveShipGroupConfig(ShipStateModel shipState, Action onFinished = null)
	{
		GvGMode3ShipModel gvGMode3ShipModel = TryGetRecordShip(shipState.ShipId);
		if (gvGMode3ShipModel.TemporaryData == null)
		{
			return;
		}
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_SaveShipGroupConfig
		{
			Req = new C2S_SaveShipGroupConfig.Request
			{
				ShipId = shipState.ShipId,
				FormationId = shipState.FormationIdTemp,
				SoldierIds = shipState.GroupInfoTemp,
				BackupSoldierIds = shipState.BackupGroupInfoTemp
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_SaveShipGroupConfig.Response response = (C2S_SaveShipGroupConfig.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				ShipStateModel shipStateModel = TryGetShip(shipState.EntityId);
				shipStateModel.SyncInfoFromSaveGroupConfig(response);
				onFinished?.Invoke();
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				GetShipsState(new List<int> { shipState.EntityId });
				Singleton<WorldStateManager>.Instance.Data.RefreshCache_Group_SoldierId_ShipEntityId = true;
			}
		});
	}

	public void SendIslandAction(C2S_IslandAction.Request req, Action onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_IslandAction
		{
			Req = req
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_IslandAction.Response response = (C2S_IslandAction.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				onFinished?.Invoke();
			}
		});
	}

	public void Share伟大航路DiscoveredIsland(int islandId, Action onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_Share伟大航路DiscoveredIsland
		{
			Req = new C2S_Share伟大航路DiscoveredIsland.Request
			{
				IslandId = islandId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_Share伟大航路DiscoveredIsland.Response response = (C2S_Share伟大航路DiscoveredIsland.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				onFinished?.Invoke();
			}
		});
	}

	public void Share额外发现CollectingGroup(int islandId, Action onSuccess = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_Share额外发现CollectingGroup
		{
			Req = new C2S_Share额外发现CollectingGroup.Request
			{
				IslandId = islandId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_Share额外发现CollectingGroup.Response response = (C2S_Share额外发现CollectingGroup.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				onSuccess?.Invoke();
			}
		});
	}

	public void ShipJumpToIsland(int shipEntityId, int targetIslandId, Action<bool> onFinished = null, OuterTechHelper.Jump努力加餐饭Cost cost = null)
	{
		ShipJumpCallback = onFinished;
		_jump努力加餐饭Cost = cost;
		bool useOuterTech = cost?.Use努力加餐饭 ?? false;
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_ShipJump
		{
			Req = new C2S_ShipJump.Request
			{
				ShipEntityId = shipEntityId,
				JumpEnd = targetIslandId,
				UseOuterTech = useOuterTech
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_ShipJump.Response response = (C2S_ShipJump.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				ShipJumpCallback?.Invoke(obj: false);
				ShipJumpCallback = null;
				_jump努力加餐饭Cost = null;
			}
		});
	}

	public void DoSoulGuide(int entityId, Action<bool> onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_DoSoulGuide
		{
			Req = new C2S_DoSoulGuide.Request
			{
				EntityId = entityId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_DoSoulGuide.Response response = (C2S_DoSoulGuide.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFinished?.Invoke(obj: false);
			}
			ShipStateModel shipStateModel = TryGetShip(entityId);
			shipStateModel.SyncSoulGuideCDTimestamp(response.SoulGuideCDTimestamp);
			Singleton<GvGMode3RoomManager>.Instance.SyncShipSoulGuideCDTimestamp(entityId, response.SoulGuideCDTimestamp);
			onFinished?.Invoke(obj: true);
		});
	}

	public void GVGSolidierTakeOff(string soldierId, int slotId, int shipEntityId, Action onSuccess = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_SolidierTakeOff
		{
			Req = new C2S_SolidierTakeOff.Request
			{
				SoldierId = soldierId,
				SlotId = slotId,
				ShipEntityId = shipEntityId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_SolidierTakeOff.Response response = (C2S_SolidierTakeOff.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				onSuccess?.Invoke();
			}
		});
	}

	public void GVGSoldierWear(string soldierId, int slotId, long instanceId, int shipEntityId, Action onSuccess = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_SoldierWear
		{
			Req = new C2S_SoldierWear.Request
			{
				SoldierId = soldierId,
				SlotId = slotId,
				InstanceId = instanceId,
				ShipEntityId = shipEntityId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_SoldierWear.Response response = (C2S_SoldierWear.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				onSuccess?.Invoke();
			}
		});
	}

	private void OnPushSoldierLegendItem(S2C_SoldierLegendItem.Request request)
	{
		if (request.ErrorCode != 0)
		{
			ILRequestHelper.ShowErrorCode(request.ErrorCode);
			return;
		}
		foreach (SoldierLegendItem soldierLegendItem in request.SoldierLegendItems)
		{
			GameManagers.Instance.SetGvGSoldiersEquippedItemIds(soldierLegendItem.SoldierId, soldierLegendItem.Items);
		}
		SharedMessenger.Broadcast("ON_SHIP_LEGEND_ITEM_CHANGE");
	}

	private void OnPush火力支援MaxTimeOfUsageModel(S2C_RealTime火力支援MaxTimeOfUsageModel.Request request)
	{
		Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.火力支援TimeOfUsage = request.火力支援TimeOfUsage;
		Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.RealTime火力支援MaxTimeOfUsageModel = request.Model;
	}

	public void OnPushTreasureMapInfo(S2C_SyncRunningTreasureMapEvent.Request request)
	{
		if (Data.SelfTreasureMapInfo == null)
		{
			Data.SelfTreasureMapInfo = new TreasureMapInfo();
		}
		Data.SelfTreasureMapInfo.TreasureMap_MUID = request.MUID;
		Data.SelfTreasureMapInfo.TreasureMap_IslandId = request.IslandId;
		Data.SelfTreasureMapInfo.TreasureMap_MConfigId = request.MConfigId;
		Data.SelfTreasureMapInfo.TreasureMap_Timestamp_ms = request.Timestamp_ms;
		OnTreasureMapInfoChange?.Invoke(Data.SelfTreasureMapInfo);
	}

	private void OnPushContributionPointsChanged(S2C_ContributionPointsChanged.Request request)
	{
		SyncTotalContributionPointsChange((int)request.CurTotal);
		OnTotalContributionPointsChanged?.Invoke(Data.TotalContributionPoints);
		ContributionPointsChanged obj = new ContributionPointsChanged
		{
			ContributionKey = request.ContributionKey,
			ChangedValue = request.ChangedValue,
			Per = request.Per
		};
		eContributionKey contributionKey = (eContributionKey)request.ContributionKey;
		eContributionKey eContributionKey = contributionKey;
		eContributionKey eContributionKey2 = eContributionKey;
		if ((uint)(eContributionKey2 - 17) <= 2u || eContributionKey2 == eContributionKey.FlagShipMission)
		{
			OnGainPointsThroughMission?.Invoke(obj);
		}
		if (contributionKey != eContributionKey.BuyForBattlePass && contributionKey != eContributionKey.Invalid)
		{
			OnContributionPointsChanged?.Invoke(obj);
		}
	}

	private void OnPushBattlePassPaidCertChanged(S2C_BattlePassPaidCertChanged.Request request)
	{
		SyncBattlePassBuyAdvancedPaidCert(request.HasPaidCert);
		SyncBattlePassBuyPremiumPaidCert(request.HasPremiumPaidCert);
		OnAdvancedPaidCertChanged?.Invoke(request.HasPaidCert);
		OnPremiumPaidCertChanged?.Invoke(request.HasPremiumPaidCert);
	}

	private void OnPushBattlePassInsuranceTimesChanged(S2C_BattlePassPaidCertChanged.Request request)
	{
		Data.BattlePassInsuranceTimes = request.BattlePassInsuranceTimes;
	}

	private void OnPushShipJump(S2C_ShipJump.Request req)
	{
		if (req.ErrorCode != 0)
		{
			ILRequestHelper.ShowErrorCode(req.ErrorCode);
			ShipJumpCallback?.Invoke(obj: false);
			ShipJumpCallback = null;
			_jump努力加餐饭Cost = null;
		}
		else
		{
			Sync努力加餐饭Change(req);
			ShipJumpCallback?.Invoke(obj: true);
			ShipJumpCallback = null;
		}
	}

	private void Sync努力加餐饭Change(S2C_ShipJump.Request req)
	{
		int o努力加餐饭_LimitTime = Singleton<WorldStateManager>.Instance.Data.OuterTechModel.o努力加餐饭_LimitTime;
		int num = o努力加餐饭_LimitTime - req.OuterTechLeftTime;
		Singleton<WorldStateManager>.Instance.Data.OuterTechModel.o努力加餐饭_LimitTime = req.OuterTechLeftTime;
		if (_jump努力加餐饭Cost != null)
		{
			bool flag = StorehouseHelper.IsGvGItem(_jump努力加餐饭Cost.努力加餐饭CostItemId);
			if (num > 0 && !flag)
			{
				StockChangeRecord[] stockChangeRecords = _jump努力加餐饭Cost.CreateStockChangeRecord(num);
				GameManagers.Instance.StockController.ReadStockChangeRecords(stockChangeRecords);
			}
			_jump努力加餐饭Cost = null;
		}
	}

	private void OnPushSoldierCount(S2C_SyncSoldierCount.Request req)
	{
		TryGetMyShip(req.ShipId).SyncSoldierCount(req);
	}

	private void OnPushFillUpShipSoldiers(S2C_FillupSoldiers.Request req)
	{
		if (req.ErrorCode != 0)
		{
			ILRequestHelper.ShowErrorCode(req.ErrorCode);
			return;
		}
		if (req.ReasonPackageId != 100546)
		{
			if (req.IsFull)
			{
				"GvGMode3SoldiersFull".ToShowLanguageTip();
				if (!req.CanFillNextTime)
				{
					"GvG_Mode3_System_UserType16_Light".ToShowLanguageTip();
				}
			}
			else
			{
				"GvGMode3SoldiersNotFull".ToShowLanguageTip();
			}
		}
		TryGetShip(req.ShipEntityId).SyncInfoFromFillUpSoldiers(req);
		SharedMessenger.Broadcast("ON_GVG3_ISLAND_ACTION_SUCCESS", 5);
	}

	private void OnPushIslandAction(S2C_IslandAction.Request req)
	{
		ShipStateModel shipStateModel = TryGetShip(req.EntityId);
		shipStateModel.SyncIslandAction(req);
	}

	private void OnPushResetOuterTech(S2C_ResetOuterTech.Request req)
	{
		if (req.OuterTechName == 604)
		{
			Data.OuterTechModel.o邪魔外道_LimitTime = req.Times;
		}
		if (req.OuterTechName == 510)
		{
			Data.OuterTechModel.o远程通信_LimitTime = req.Times;
		}
		SharedMessenger.Broadcast("ON_GVG3_OUTTERTECH_RESET", req.OuterTechName);
	}

	private void OnPushOuterTechHideRefresh(S2C_OuterTechHideRefresh.Request req)
	{
		Data.OuterTechModel.o蛰伏_LimitTime = req.Times;
		Data.OuterTechModel.o蛰伏_Valid = req.Valid;
		SharedMessenger.Broadcast("ON_GVG3_OUTTERTECH_RESET", 605);
	}

	private void OnPushDailySuppressBonusTimesChange(S2C_DailySuppressBonusTimesChange.Request req)
	{
		Data.DailySuppressBonusModel = req.DailySuppressBonusModel;
	}

	private void OnShipContinueExecutePlan(S2C_ShipContinueExecutePlan.Request req)
	{
		TryGetShip(req.EntityId)?.SyncPlanStatus(req);
	}

	public void OnSoldierStockLimitChange(S2C_ShipPlanChangeSoldier.Request req)
	{
		foreach (RItem item in req.SoldierStockLimitChange)
		{
			if (req.IsReturnSoldier)
			{
				GameManagers.Instance.UserArchiveManager.ClearGvGShipPlanSoldierStockChangeInfo(item.ItemId);
			}
			else
			{
				GameManagers.Instance.UserArchiveManager.SetGvGShipPlanSoldierStockChangeInfo(item.ItemId, item.cnt);
			}
		}
		foreach (RItem item2 in req.CurStock)
		{
			GameManagers.Instance.StockController.SetStock(item2.ItemId, item2.cnt, StockInContext.AutoFill);
		}
	}

	private void OnPushWaitToClaim(S2C_WaitToClaimSystemMessageIdsCount.Request request)
	{
		int waitToClaimSystemMessageIdsCount = Data.WaitToClaimSystemMessageIdsCount;
		if (waitToClaimSystemMessageIdsCount != request.Count)
		{
			Data.WaitToClaimSystemMessageIdsCount = request.Count;
			OnBattleResultRedDotChange?.Invoke(request.Count > 0);
		}
	}

	private void OnPushStayIsland(S2C_StayIsland.Request req)
	{
		if (HasShip(req.EntityId))
		{
			ShipStateModel shipStateModel = TryGetShip(req.EntityId);
			shipStateModel.SyncStayIsland(req);
			if (IsMyShip(shipStateModel.ShipId) && req.ShipTargetIslandId == Data.OurFlagShipStayIslandId)
			{
				UpdateFlagShipIslandCardOnArrival?.Invoke(TryGetIsland(req.ShipTargetIslandId));
			}
		}
	}

	private void OnPushShipSummary(S2C_GvGMode3ShipSummarySpeed.Request req)
	{
		TryGetMyShip(req.ShipId)?.SyncShipSummary(req);
	}

	private void OnPushShipSightRange(S2C_ShipSightRange.Request req)
	{
		Singleton<GvGMode3RoomManager>.Instance.SyncShipSightRange(req.ShipSightRange);
		foreach (GvGMode3ShipModel ship in Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.Ships)
		{
			TryGetMyShip(ship.ShipId).SyncShipSightRange(req.ShipSightRange);
		}
	}

	private void OnPushIslandInfo(S2C_GvGMode3IslandEntityInfo.Request req)
	{
		UpdateIslandState(req.Info);
	}

	private void OnPushSoldierInfo(S2C_SyncSoldierInfo.Request request)
	{
		if (request.ErrorCode != 0)
		{
			ILRequestHelper.ShowErrorCode(request.ErrorCode);
		}
	}

	private void OnSyncFinalProgressInfo(S2C_SyncFinalProgressInfo.Request req)
	{
		SyncCampProgress(req.Progress, req.Step, req.HasSettlement, req.SettlementTimestamp);
	}

	private void OnPushGroupCountLimitChange(S2C_GroupCountLimit.Request request)
	{
		Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GroupCountLimit = request.GroupCountLimit;
		foreach (ShipStateModel myShip in Data.MyShips)
		{
			myShip.UpdateUnitTotal(request.GroupCountLimit);
		}
		SharedMessenger.Broadcast("ON_SHIP_GROUP_COUNT_LIMIT_CHANGE");
	}

	private void OnPushBackupGroupSlotLimitChange(S2C_BackupGroupSlotLimit.Request request)
	{
		Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.BackupGroupSlotLimit = request.BackupGroupSlotLimit;
		foreach (ShipStateModel myShip in Data.MyShips)
		{
			myShip.UpdateBackupGroupSlotLimit(request.BackupGroupSlotLimit);
		}
	}

	private void OnPushFlagShipState(S2C_FlagShipState.Request request)
	{
		FlagShipStateInfo info = request.Info;
		SyncFlagShipStayIslandId(info);
		if (info.CampId == Data.MyCampId)
		{
			SyncCampProgress(info.Progress, info.Step);
		}
	}

	private void OnPushFoodOnBoard(S2C_FoodOnBoard.Request request)
	{
		Data.RealTimeFoodOnBoardModel = request.Model;
	}

	private void OnPush地貌勘探ObDetectedIslands(S2C_地貌勘探ObDetectedIslands.Request req)
	{
		Sync地貌勘探ObDetectedIslandsByData(req.DetectedIslands);
	}

	private void OnPushNewIOI(S2C_GvGMode3NewIOI.Request req)
	{
		if (req.IslandIds != null && req.IslandIds.Count != 0)
		{
			WaitToUpdateIslandIds.UnionWith(req.IslandIds);
			GvGWorldMapController.Instance.LoaderManager.ReloadIslands();
		}
	}

	private void OnPushFlagShipAttackEvent(S2C_AttackEvent.Request req)
	{
		req.AttackEvent.WaitForJumpAnimation = true;
		SyncFlagShipAttackEvent(req.AttackEvent);
	}

	private void OnPushSoulGuideCooldown(S2C_SoulGuideCooldown.Request req)
	{
		ShipStateModel shipStateModel = TryGetShip(req.EntityId);
		if (shipStateModel != null)
		{
			shipStateModel.SyncSoulGuideCDTimestamp(req.SoulGuideCDTimestamp);
			Singleton<GvGMode3RoomManager>.Instance.SyncShipSoulGuideCDTimestamp(req.EntityId, req.SoulGuideCDTimestamp);
		}
	}

	private void OnPushUpdateSelfOEMMissions(S2C_SelfOEMMissionChanged.Request request)
	{
		if (request.SelfOEMMission.State == 5)
		{
			Singleton<WorldStateManager>.Instance.Data.PlayerFlagshipInfo.UpdateOEMAmplifiersHasFailed(hasFailed: true);
		}
		if (request.SelfOEMMission.State == 4)
		{
			Singleton<WorldStateManager>.Instance.Data.PlayerFlagshipInfo.UpdateOEMAmplifiersCanBeReceived(received: true);
		}
	}

	private void OnPushUnreachableIslands(S2C_GvGMode3UnreachableIslands.Request request)
	{
		SyncUnreachableIslands(request.UnreachableIslands);
	}

	public void SyncMyOwnState(GvGMode3ObserverRecord observerRecord)
	{
		int userId = GameController.Contexts.gameState.user.value.UserId;
		foreach (GvGMode3ShipModel ship in observerRecord.Ships)
		{
			if (ship.TemporaryData != null && ship.TemporaryData.EntityId > 0)
			{
				ShipStateModel shipStateModel = TryAddShip(ship.TemporaryData.EntityId, ship.TemporaryData.CampId, userId, (eRace)ship.TemporaryData.ShipRace);
				shipStateModel.SyncInfoFromRecord(ship, observerRecord);
			}
		}
	}

	public void SyncNewShipFromRecord(string shipId, GvGMode3ObserverRecord observerRecord)
	{
		int userId = GameController.Contexts.gameState.user.value.UserId;
		GvGMode3ShipModel gvGMode3ShipModel = observerRecord.Ships.Find((GvGMode3ShipModel s) => s.ShipId == shipId);
		ShipStateModel shipStateModel = TryAddShip(gvGMode3ShipModel.TemporaryData.EntityId, gvGMode3ShipModel.TemporaryData.CampId, userId, (eRace)gvGMode3ShipModel.TemporaryData.ShipRace);
		shipStateModel.SyncInfoFromRecord(gvGMode3ShipModel, observerRecord);
	}

	private void SyncTreasureMapInfo(int muid, string configId, long timestamp_ms, int islandId)
	{
		if (Data.SelfTreasureMapInfo == null)
		{
			Data.SelfTreasureMapInfo = new TreasureMapInfo();
		}
		Data.SelfTreasureMapInfo.TreasureMap_MUID = muid;
		Data.SelfTreasureMapInfo.TreasureMap_IslandId = islandId;
		Data.SelfTreasureMapInfo.TreasureMap_MConfigId = configId;
		Data.SelfTreasureMapInfo.TreasureMap_Timestamp_ms = timestamp_ms;
	}

	public void SyncBattlePassDataVersion(int version)
	{
		Data.BattlePassDataVersion = version;
	}

	public void SyncBattlePassClaimedBonus(Dictionary<string, List<int>> record)
	{
		Data.BattlePassClaimedBonus = new Dictionary<string, List<int>>(record);
	}

	public void SyncBattlePassBuyAdvancedPaidCert(bool paid)
	{
		Data.HasBattlePassPaidCert = paid;
	}

	public void SyncBattlePassBuyPremiumPaidCert(bool paid)
	{
		Data.HasBattlePassPremiumPaidCert = paid;
	}

	public void SyncInsuranceShipId(string shipId)
	{
		Data.InsuranceShipId = shipId;
	}

	public void ClearInsuranceShip(string shipId)
	{
		if (Data.InsuranceShipId == shipId)
		{
			Data.InsuranceShipId = string.Empty;
		}
	}

	public void SyncLimitOccupiedSoldiers(List<string> occupied)
	{
		GameManagers.Instance.UserArchiveManager.ClearPeriodSoldiersLimitOccupied(occupied);
	}

	public void SyncTotalContributionPointsChange(int totalContributionPoints)
	{
		Data.TotalContributionPoints = totalContributionPoints;
	}

	private void SyncUserPlayDays(int userPlayDays)
	{
		Data.UserPlayDays = userPlayDays;
	}

	private void SyncUnreachableIslands(List<int> unreachableIslands)
	{
		if (unreachableIslands == null)
		{
			unreachableIslands = new List<int>();
		}
		Data.UnreachableIslands = new HashSet<int>(unreachableIslands);
	}

	private void SyncCampProgress(int progress, int step)
	{
		if (Data.ProgressData == null)
		{
			Data.ProgressData = new CampProgressData();
		}
		bool flag = false;
		if (progress != Data.ProgressData.CampProgress)
		{
			flag = true;
		}
		else if (step != Data.ProgressData.CampStep)
		{
			flag = true;
		}
		Data.ProgressData.CampProgress = progress;
		Data.ProgressData.CampStep = step;
		if (flag)
		{
			OnCampProgressChange?.Invoke();
		}
	}

	private void SyncCampProgress(int progress, int step, bool hasSettlement, int settlementTimestamp, string jsonPlayerBuffQueue = null)
	{
		if (Data.ProgressData == null)
		{
			Data.ProgressData = new CampProgressData();
		}
		Data.ProgressData.CampProgress = progress;
		Data.ProgressData.CampStep = step;
		Data.ProgressData.HasSettlement = hasSettlement;
		Data.ProgressData.SettlementTimestamp = settlementTimestamp;
		if (jsonPlayerBuffQueue != null)
		{
			Data.ProgressData.JsonPlayerBuffQueue = jsonPlayerBuffQueue;
		}
		OnCampProgressChange?.Invoke();
	}

	private void SyncTalents(List<int> activeTalents, List<int> specialTalents)
	{
		if (Data.Talents == null)
		{
			Data.Talents = new TalentEvent(activeTalents, specialTalents);
		}
	}

	public void Sync地貌勘探ObDetectedIslandsByData(List<int> _newDetectedIslands)
	{
		HashSet<int> hashSet = new HashSet<int>(_newDetectedIslands ?? new List<int>());
		foreach (int item in Data.DetectedIslandsWithHiddenRC)
		{
			if (!hashSet.Contains(item))
			{
				TryGetIsland(item).SyncHiddenResourceNote(isShow: false);
			}
		}
		foreach (int item2 in hashSet)
		{
			TryGetIsland(item2).SyncHiddenResourceNote(isShow: true);
		}
		Data.DetectedIslandsWithHiddenRC = hashSet;
	}

	public void SyncFlagShipStayIslandId(FlagShipStateInfo info)
	{
		if (info.CampId == Data.MyCampId)
		{
			bool flag = Data.OurFlagShipStayIslandId != info.ShipTargetIslandId;
			Data.OurFlagShipStayIslandId = info.ShipTargetIslandId;
			Data.MainMissionGroupId = info.MainMissionGroupId;
			if (flag)
			{
				OnCampFlagshipStayIslandChange?.Invoke();
			}
		}
		FlagShipStateModel flagShipStateModel = TryGetFlagShipByCampId(info.CampId);
		flagShipStateModel.SyncFlagShipStayIslandId(info);
	}

	public void SyncFlagShipAttackEvent(FlagShipAttackEvent attackEvent)
	{
		FlagShipStateModel flagShipStateModel = TryGetFlagShipByCampId(attackEvent.CampId);
		FlagShipAttackEvent attackEvent2 = flagShipStateModel.AttackEvent;
		if (attackEvent2 != null)
		{
			int missileDest = attackEvent2.MissileDest;
			IslandStateModel islandStateModel = TryGetIsland(missileDest);
			islandStateModel.SyncAttackEventFromFlagShip(null);
		}
		if (attackEvent.MissileDest > 0 && attackEvent.EndTimestamp_ms > 0)
		{
			flagShipStateModel.SyncFlagShipAttackEvent(attackEvent);
		}
		else
		{
			flagShipStateModel.SyncFlagShipAttackEvent(null);
		}
	}

	private void SyncFlagshipInfo(PlayerFlagshipInfo info)
	{
		Data.PlayerFlagshipInfo = info;
	}

	public void SelectMyShip(string shipId = null)
	{
		foreach (ShipStateModel myShip in Data.MyShips)
		{
			myShip.SetMyShipSelected(shipId == myShip.ShipId);
		}
	}

	public string GetIslandVersionKey()
	{
		return typeof(GvGMode3LocalIslandVersions).Name + "_";
	}

	public string GetIslandLocalDataKey(int IslandId)
	{
		return $"GvGIsland_{IslandId}";
	}

	private void OnTrySaveLocalData(object param)
	{
		if (!NeedToSaveLocalData)
		{
			return;
		}
		NeedToSaveLocalData = false;
		List<IslandDataVersionModel> list = new List<IslandDataVersionModel>();
		foreach (KeyValuePair<int, int> item in LocalIslandVersions_Dict)
		{
			list.Add(new IslandDataVersionModel
			{
				IslandId = item.Key,
				Num = item.Value
			});
		}
		GameLocalDataManager.SetTypeToProtoBase64(GetIslandVersionKey(), new GvGMode3LocalIslandVersions
		{
			IZId = Data.CurIZId,
			IslandVesionsList = list
		});
		PlayerPrefs.Save();
	}

	private Dictionary<int, int> GetLocalIslandVersions()
	{
		GvGMode3LocalIslandVersions typeFromProtoBase = GameLocalDataManager.GetTypeFromProtoBase64(GetIslandVersionKey(), () => new GvGMode3LocalIslandVersions());
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		if (typeFromProtoBase.IZId == Data.CurIZId)
		{
			foreach (IslandDataVersionModel islandVesions in typeFromProtoBase.IslandVesionsList)
			{
				dictionary.Add(islandVesions.IslandId, islandVesions.Num);
			}
		}
		return dictionary;
	}

	private static HashSet<int> GetWaitToUpdateIslandId(Dictionary<int, int> localIslandVersions, List<IslandDataVersionModel> serverIslandVersions)
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (IslandDataVersionModel serverIslandVersion in serverIslandVersions)
		{
			if (!localIslandVersions.TryGetValue(serverIslandVersion.IslandId, out var value) || value != serverIslandVersion.Num)
			{
				hashSet.Add(serverIslandVersion.IslandId);
			}
		}
		return hashSet;
	}

	private void UpdateIslandState(GvGMode3IslandEntityInfo info)
	{
		IslandStateModel islandStateModel = TryGetIsland(info.IslandId);
		if (!LocalIslandVersions_Dict.TryGetValue(info.IslandId, out var value) || value < info.VersionNumber)
		{
			LocalIslandVersions_Dict[info.IslandId] = info.VersionNumber;
			GvGMode3LocalIslandData value2 = new GvGMode3LocalIslandData
			{
				IZId = Data.CurIZId,
				Info = info
			};
			string islandLocalDataKey = GetIslandLocalDataKey(info.IslandId);
			GameLocalDataManager.SetTypeToProtoBase64(islandLocalDataKey, value2);
			NeedToSaveLocalData = true;
			if (WaitToUpdateIslandIds.Count != 0)
			{
				WaitToUpdateIslandIds.Remove(info.IslandId);
			}
			islandStateModel.SyncInfo(info);
		}
	}

	private void LoadIslandState(ref IslandStateModel islandState)
	{
		string islandLocalDataKey = GetIslandLocalDataKey(islandState.IslandId);
		GvGMode3LocalIslandData typeFromProtoBase = GameLocalDataManager.GetTypeFromProtoBase64(islandLocalDataKey, () => (GvGMode3LocalIslandData)null);
		if (typeFromProtoBase != null && typeFromProtoBase.IZId == Data.CurIZId)
		{
			islandState.SyncInfo(typeFromProtoBase.Info);
		}
	}

	public GvGMode3ShipModel TryGetRecordShip(string shipId)
	{
		foreach (GvGMode3ShipModel ship in Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.Ships)
		{
			if (ship.ShipId == shipId)
			{
				return ship;
			}
		}
		ILRuntimeDebug.LogError("[SaveShipGroupConfig] 找不到 shipId = " + shipId);
		return null;
	}

	public void RemoveMyShip(string shipId)
	{
		ShipStateModel shipStateModel = Data.MyShips.Find((ShipStateModel ship) => ship.ShipId == shipId);
		if (shipStateModel != null)
		{
			int entityId = shipStateModel.EntityId;
			Data.MyShips.Remove(shipStateModel);
			if (Data.Ships.ContainsKey(entityId))
			{
				Data.Ships.Remove(entityId);
			}
		}
	}

	public void SetMyCampIslandVisible(bool isVisible)
	{
		if (IsOurCampIslandVisible == isVisible)
		{
			return;
		}
		IsOurCampIslandVisible = isVisible;
		int myCampId = Data.MyCampId;
		foreach (IslandStateModel value in Data.Islands.Values)
		{
			if (value.CampId == myCampId)
			{
				value.OnFogAreaChange?.Invoke(value);
			}
		}
		foreach (ShipStateModel value2 in Data.Ships.Values)
		{
			if (value2.CampId == myCampId)
			{
				value2.OnFogAreaChange?.Invoke(value2);
			}
		}
	}

	public void SetIslandHideNameAndState(List<int> islandIds, bool hide)
	{
		foreach (int islandId in islandIds)
		{
			IslandStateModel islandStateModel = TryGetIsland(islandId);
			islandStateModel.HideNameAndState = hide;
			islandStateModel.OnHideNameAndStateChange?.Invoke(islandStateModel);
		}
	}

	public void SetAdditionalVisibleIslands(List<int> islandIds)
	{
		List<int> list = AdditionalIslandIds.ToList();
		if (islandIds == null)
		{
			AdditionalIslandIds.Clear();
		}
		else
		{
			AdditionalIslandIds = new HashSet<int>(islandIds);
		}
		foreach (int item in list)
		{
			IslandStateModel islandStateModel = TryGetIsland(item);
			islandStateModel.OnFogAreaChange?.Invoke(islandStateModel);
		}
		if (islandIds == null)
		{
			return;
		}
		foreach (int islandId in islandIds)
		{
			IslandStateModel islandStateModel2 = TryGetIsland(islandId);
			islandStateModel2.OnFogAreaChange?.Invoke(islandStateModel2);
		}
	}

	public bool HasShip(int id)
	{
		return Data.Ships.ContainsKey(id);
	}

	private ShipStateModel GetMyShip(string shipId)
	{
		return Data.MyShips.FirstOrDefault((ShipStateModel t) => shipId == t.ShipId);
	}

	public ShipStateModel TryGetMyShip(string shipId)
	{
		return GetMyShip(shipId);
	}

	public FlagShipStateModel TryGetFlagShipByCampId(int campId)
	{
		return Data.TryGet(Data.FlagShips, campId);
	}

	public ShipStateModel TryGetShip(int entityId)
	{
		return Data.TryGet(Data.Ships, entityId);
	}

	public ShipStateModel TryAddShip(int entityId, int campId, int userId, eRace shipRace)
	{
		if (!Data.Ships.ContainsKey(entityId))
		{
			int userId2 = GameController.Contexts.gameState.user.value.UserId;
			ShipStateModel shipStateModel = new ShipStateModel
			{
				EntityId = entityId,
				CampId = campId,
				UserId = userId,
				ShipRace = shipRace
			};
			Data.Ships.Add(entityId, shipStateModel);
			if (userId2 == userId)
			{
				Data.MyShips.Add(shipStateModel);
			}
		}
		return Data.Ships[entityId];
	}

	public IslandStateModel TryGetIsland(int id)
	{
		if (Data == null)
		{
			return null;
		}
		IslandStateModel islandState = Data.TryGet(Data.Islands, id);
		if (islandState == null && id > 0)
		{
			islandState = new IslandStateModel
			{
				IslandId = id,
				CampId = 0
			};
			LoadIslandState(ref islandState);
			_Data.Islands.Add(id, islandState);
		}
		return islandState;
	}

	public FlagShipStateModel GetOurFlagShip()
	{
		return TryGetFlagShipByCampId(Data.MyCampId);
	}

	public void AddFlagShipByCampId(int campId)
	{
		if (!Data.FlagShips.ContainsKey(campId))
		{
			Data.FlagShips.Add(campId, new FlagShipStateModel());
		}
	}

	private bool IsMyShip(string shipId)
	{
		return Data.MyShips.Any((ShipStateModel ship) => ship.ShipId == shipId);
	}

	public void AfterConfigInit()
	{
		if (WorldMapConfigHelper.Configs.IsBrawlEvent())
		{
			OnCampProgressChange = (Action)Delegate.Remove(OnCampProgressChange, new Action(BrawlFightOnCampProgressChange));
			OnCampProgressChange = (Action)Delegate.Combine(OnCampProgressChange, new Action(BrawlFightOnCampProgressChange));
			BrawlFightOnCampProgressChange();
		}
	}

	private void BrawlFightOnCampProgressChange()
	{
		if (Data.ProgressData.CampProgress != 6)
		{
			return;
		}
		int stepIdx = 100 + Data.ProgressData.CampStep - 1;
		List<int> effectIslandIds = WorldMapConfigHelper.Configs.TryGetBrawlEvent(stepIdx).EffectIslandIds;
		BrawlFinalIslandIds.Clear();
		foreach (int item in effectIslandIds)
		{
			BrawlFinalIslandIds.Add(item);
		}
		foreach (int brawlFinalIslandId in BrawlFinalIslandIds)
		{
			IslandStateModel islandStateModel = TryGetIsland(brawlFinalIslandId);
			islandStateModel.OnChange?.Invoke(islandStateModel);
		}
	}
}
