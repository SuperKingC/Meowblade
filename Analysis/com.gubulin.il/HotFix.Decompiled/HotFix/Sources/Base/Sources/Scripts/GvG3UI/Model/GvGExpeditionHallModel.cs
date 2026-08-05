using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FairyGUI;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.Map;
using Shift.Legion.Helpers;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class GvGExpeditionHallModel
{
	public bool IsInit;

	public GvGMode3ObserverRecord GvGMode3Record;

	public List<GvGIZConfigModel> IZConfigs;

	public GvGStoreDescription GvGStoreDesc;

	public GvGIZConfigModel SignedInIZ;

	public GvGProcessInfo SignedInRoom;

	public int SignedCampId;

	public int SignedIZId;

	public int SelectedIZIndex = 0;

	public const int UserCountThreshold = 300;

	public bool IsSigned => SignedInIZ != null && SignedInRoom != null;

	public bool IsIZInSettlement => Singleton<GvGMode3RoomManager>.Instance.IsIZInSettlement;

	public eSignInPeriodState SignInPeriodState
	{
		get
		{
			if (IsIZInSettlement)
			{
				return eSignInPeriodState.SettlementPeriod;
			}
			if (SignedInRoom == null)
			{
				return eSignInPeriodState.FirstSignInPeriod;
			}
			GvGMode3IslandManagerInfo gvGMode3IslandManagerInfo = (GvGMode3IslandManagerInfo)SignedInRoom.GetInfo();
			if (gvGMode3IslandManagerInfo == null)
			{
				return eSignInPeriodState.FirstSignInPeriod;
			}
			int num = (int)GameController.Instance.GetServerTime();
			if (num <= gvGMode3IslandManagerInfo.IZInfo.SignUp_CancellationForbidden)
			{
				return eSignInPeriodState.FirstSignInPeriod;
			}
			if (num < gvGMode3IslandManagerInfo.IZInfo.Start || !IsReady)
			{
				return eSignInPeriodState.RoomNorShipNotReady;
			}
			if (!GvGMode3Record.HasEnterIZ)
			{
				return eSignInPeriodState.AllowToEnterRoom;
			}
			return eSignInPeriodState.EnteredRoomBefore;
		}
	}

	public bool IsRoomStarted
	{
		get
		{
			if (SignedInRoom == null)
			{
				return false;
			}
			GvGMode3IslandManagerInfo gvGMode3IslandManagerInfo = (GvGMode3IslandManagerInfo)SignedInRoom.GetInfo();
			if (gvGMode3IslandManagerInfo == null)
			{
				return false;
			}
			return (int)GameController.Instance.GetServerTime() > gvGMode3IslandManagerInfo.IZInfo.Start;
		}
	}

	public bool EnterIZBefore => GvGMode3Record.LastIZIdCloseTimestamp != -1;

	public bool IsTechReady => !Singleton<GvGOuterTechManager>.Instance.IsAvailable || !Singleton<GvGOuterTechManager>.Instance.HasDrawChance;

	public bool IsSpeedPlanReady => GvGMode3Record.HasEnterIZ || GvGMode3Record.LastIZId != -1 || !Singleton<GvGOuterTechManager>.Instance.IsSpeedPlanAvailable || Singleton<GvGOuterTechManager>.Instance.SpeedPlan.Claimed || Singleton<GvGOuterTechManager>.Instance.SpeedPlan.CouldClaimCount < 1;

	public bool IsReady => IsShipReady && NewWorkShopState == eUIBuildingMissionState.Built && SkyPortalState == eUIBuildingMissionState.Built && IsTechReady && IsSpeedPlanReady;

	public bool IsShipReady
	{
		get
		{
			bool flag = GvGMode3Record.Ships != null && GvGMode3Record.Ships.Count != 0;
			bool hasEnterIZ = GvGMode3Record.HasEnterIZ;
			if (flag)
			{
				foreach (GvGMode3ShipModel ship in GvGMode3Record.Ships)
				{
					if (ship.PermanentData == null)
					{
						throw new Exception("[GvGExpeditionHallModel.IsShipReady] ship.PermanentData = null");
					}
					if (!hasEnterIZ && ship.PermanentData.ShipBuildState == 0)
					{
						return true;
					}
					if (hasEnterIZ)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	public bool IsSettlementBonusClaimed => IsIZInSettlement && Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.IsSettlementBonusClaimed;

	public bool IsBattlePassClosed
	{
		get
		{
			if (!IsIZInSettlement)
			{
				return false;
			}
			SkyIslandPlayerSettlementModel playerSettlement = Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement;
			return playerSettlement.GvGBattlePassRecordIsClosed;
		}
	}

	public bool IsIZReadyToClose => IsSettlementBonusClaimed && IsBattlePassClosed;

	public eUIBuildingMissionState SkyPortalState => TryGetBuildingStatus("12");

	public eUIBuildingMissionState NewWorkShopState => TryGetBuildingStatus("9");

	public void ClearCache()
	{
		IsInit = false;
		GvGMode3Record = null;
		IZConfigs = null;
		SignedInIZ = null;
		SignedInRoom = null;
		SignedCampId = 0;
		SignedIZId = 0;
		SelectedIZIndex = 0;
	}

	public void SignIn(int campId, int izId, string izConfigId)
	{
		SignedCampId = campId;
		SignedIZId = izId;
		foreach (GvGIZConfigModel iZConfig in IZConfigs)
		{
			if (!(iZConfig.IZConfigId == izConfigId))
			{
				continue;
			}
			SignedInIZ = iZConfig;
			foreach (GvGProcessInfo process in iZConfig.Processes)
			{
				if (process.IZId == izId.ToString())
				{
					SignedInRoom = process;
					return;
				}
			}
		}
		ILRuntimeDebug.LogError($"[GvGExpeditionHallModel.SignIn] 无效 izId = {izId} 或无效 izConfigId = {izConfigId}");
	}

	public void CancelSignIn()
	{
		SignedInIZ = null;
		SignedInRoom = null;
	}

	public void SyncRecordData(Action onSynced)
	{
		GvGMode3Record = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord;
		onSynced?.Invoke();
	}

	public void GetData(Action onSuccess)
	{
		IsInit = false;
		Singleton<GvGMode3RoomManager>.Instance.GetGSObserverRecord(delegate
		{
			GvGMode3Record = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord_OnGS;
			GetIZConfigsAndSignInState(delegate
			{
				IsInit = true;
				onSuccess?.Invoke();
				if (GvGMode3Record.HasEnterIZ)
				{
					((MonoBehaviour)FGUIManager.Instance).StartCoroutine(ConnectToRoomNextFrame());
				}
			});
		});
	}

	private IEnumerator ConnectToRoomNextFrame()
	{
		yield return null;
		Singleton<GvGMode3RoomManager>.Instance.TryConnectToRoom();
	}

	private void GetIZConfigsAndSignInState(Action onSuccess)
	{
		ILRequestHelper<GetGvGMode3DescriptionsResponse>.Request((EventContext)null, (Func<Task<GetGvGMode3DescriptionsResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetGvGMode3Descriptions()), (Action<GetGvGMode3DescriptionsResponse>)delegate(GetGvGMode3DescriptionsResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Dictionary<string, GvGMode3Description> dictionary = JsonHelper.ToObject<Dictionary<string, GvGMode3Description>>(response.GvGMode3Descriptions);
				IZConfigs = new List<GvGIZConfigModel>();
				GvGStoreDesc = JsonHelper.ToObject<GvGStoreDescription>(response.GvGStoreDescription);
				bool flag = GvGMode3Record.CurIZId > 0;
				foreach (KeyValuePair<string, GvGMode3Description> item in dictionary)
				{
					GvGMode3Description value = item.Value;
					GvGIZConfigModel gvGIZConfigModel = new GvGIZConfigModel
					{
						IZConfigId = item.Key,
						Title = value.Title.ToLanguage(),
						Desc = value.Desc.ToLanguage(),
						CostTime = value.CostTime.ToLanguage(),
						LevelDegree = value.LevelDegree,
						ProfitDegree = value.ProfitDegree,
						Rewards = value.Rewards,
						SpecialRewards = value.SpecialRewards,
						SpecialRewards2 = value.SpecialRewards2,
						ProcessCount = value.ProcessCount
					};
					IZConfigs.Add(gvGIZConfigModel);
					if (flag && gvGIZConfigModel.IZConfigId == GvGMode3Record.IZConfigId)
					{
						gvGIZConfigModel.UpdateRoomsData(delegate
						{
							SignIn(GvGMode3Record.ObCampId, GvGMode3Record.CurIZId, GvGMode3Record.IZConfigId);
							onSuccess?.Invoke();
						});
					}
				}
				if (!flag)
				{
					onSuccess?.Invoke();
				}
			}
		});
	}

	public void Release()
	{
		Singleton<GvGMode3RoomManager>.Instance.TryDelayDisconnectRoom();
	}

	public void UpdateSignedRoomData(Action onSuccess)
	{
		if (SignedInIZ == null)
		{
			return;
		}
		SignedInIZ.UpdateRoomsData(delegate
		{
			if (SignedInIZ != null)
			{
				SignedInRoom = null;
				foreach (GvGProcessInfo process in SignedInIZ.Processes)
				{
					if (process.IZId == SignedIZId.ToString())
					{
						SignedInRoom = process;
					}
				}
				if (SignedInRoom == null)
				{
					ILRuntimeDebug.LogError($"[GvGExpeditionHallModel.UpdateRoomsData] 刷新当前报名的房间时，IZId={SignedIZId}的房间丢失，不在返回的列表中");
				}
				else
				{
					onSuccess?.Invoke();
				}
			}
		});
	}

	private eUIBuildingMissionState TryGetBuildingStatus(string buildingType)
	{
		Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType(buildingType);
		if (buildingByType == null)
		{
			ILRuntimeDebug.LogError("[GvGExpeditionHallModel] 找不到 buildingType = " + buildingType + " 对应的建筑配置");
			return eUIBuildingMissionState.GoToBuild;
		}
		if (buildingByType.Level > 0)
		{
			return eUIBuildingMissionState.Built;
		}
		if (buildingByType.Status == BuildingStatus.Constructing)
		{
			return eUIBuildingMissionState.Constructing;
		}
		if (buildingByType.Status == BuildingStatus.Ready)
		{
			return eUIBuildingMissionState.GoToAccept;
		}
		if (buildingByType.Status == BuildingStatus.Running)
		{
			return eUIBuildingMissionState.Built;
		}
		return eUIBuildingMissionState.GoToBuild;
	}

	public List<SpecialRewardItem> GetGvGStoreRewardsPreview()
	{
		if (HasActiveGvGStoreDesc())
		{
			return GvGStoreDesc.SpecialRewards;
		}
		List<SpecialRewardItem> list = new List<SpecialRewardItem>();
		if (SelectedIZIndex >= 0 && IZConfigs.Count > SelectedIZIndex && IZConfigs[SelectedIZIndex].SpecialRewards != null)
		{
			foreach (RItem specialReward in IZConfigs[SelectedIZIndex].SpecialRewards)
			{
				list.Add(new SpecialRewardItem
				{
					ItemId = specialReward.ItemId,
					cnt = specialReward.cnt
				});
			}
		}
		return list;
	}

	public int GetGvGStoreRemainingSeconds()
	{
		if (HasActiveGvGStoreDesc())
		{
			return Math.Max(GvGStoreDesc.EndTime - DateTimeHelper.TimeStamp, 0);
		}
		return 0;
	}

	public bool HasActiveGvGStoreDesc()
	{
		return GvGStoreDesc != null;
	}
}
