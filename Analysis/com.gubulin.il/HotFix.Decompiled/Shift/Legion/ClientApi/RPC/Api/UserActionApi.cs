using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using HotFix;
using HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol;
using HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol.UserAction;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.Archive;
using Shift.Legion.ClientApi.Protocol.Friends;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItemEnhancement;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierItemSlot;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierLegendItem;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.Sources.Protocol;
using Shift.Legion.ClientApi.Sources.Protocol.FriendsChat;
using Shift.Legion.ClientApi.Sources.Protocol.UserAction;
using Shift.Legion.ClientApi.Sources.UserAction;
using Shift.Legion.GvG.Common.Model;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.RPC.Api;

public class UserActionApi : Api
{
	private int _requestIndex;

	public int RequestIndex => _requestIndex++;

	public Task<GvGGetSelfShipCountResponse> GvGGetSelfShipCount(string _IZId)
	{
		TaskCompletionSource<GvGGetSelfShipCountResponse> tcs = new TaskCompletionSource<GvGGetSelfShipCountResponse>();
		RPCConnection.QueueRequest(new GvGGetSelfShipCountRequest
		{
			IZId = _IZId
		}, delegate(RPCContext context)
		{
			try
			{
				GvGGetSelfShipCountResponse result = context.Payload.As<GvGGetSelfShipCountResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGClaimUserCampMissionResponse> GvGClaimUserCampMission(string _IZId, string campId, string missionId)
	{
		TaskCompletionSource<GvGClaimUserCampMissionResponse> tcs = new TaskCompletionSource<GvGClaimUserCampMissionResponse>();
		RPCConnection.QueueRequest(new GvGClaimUserCampMissionRequest
		{
			IZId = _IZId,
			CampId = campId,
			MissionId = missionId
		}, delegate(RPCContext context)
		{
			try
			{
				GvGClaimUserCampMissionResponse result = context.Payload.As<GvGClaimUserCampMissionResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGGetIZInfosResponse> GvGGetIZInfos(bool needCustomizeTables)
	{
		TaskCompletionSource<GvGGetIZInfosResponse> tcs = new TaskCompletionSource<GvGGetIZInfosResponse>();
		RPCConnection.QueueRequest(new GvGGetIZInfosRequest
		{
			NeedCustomizeTables = needCustomizeTables
		}, delegate(RPCContext context)
		{
			try
			{
				GvGGetIZInfosResponse result = context.Payload.As<GvGGetIZInfosResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode2CreateShipSummaryResponse> GvGMode2CreateShipSummary(List<string> soldiers, string formationId)
	{
		TaskCompletionSource<GvGMode2CreateShipSummaryResponse> tcs = new TaskCompletionSource<GvGMode2CreateShipSummaryResponse>();
		RPCConnection.QueueRequest(new GvGMode2CreateShipSummaryRequest
		{
			Soldiers = soldiers,
			FormationId = formationId
		}, delegate(RPCContext context)
		{
			try
			{
				GvGMode2CreateShipSummaryResponse result = context.Payload.As<GvGMode2CreateShipSummaryResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode2ShipFillUpResponse> GvGMode2ShipFillUp(List<string> soldiers, string formationId, string shipId)
	{
		TaskCompletionSource<GvGMode2ShipFillUpResponse> tcs = new TaskCompletionSource<GvGMode2ShipFillUpResponse>();
		RPCConnection.QueueRequest(new GvGMode2ShipFillUpRequest
		{
			Soldiers = soldiers,
			FormationId = formationId,
			ShipId = shipId
		}, delegate(RPCContext context)
		{
			try
			{
				GvGMode2ShipFillUpResponse result = context.Payload.As<GvGMode2ShipFillUpResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode2GetUserIZBattleSummaryResponse> GvGMode2GetUserIZBattleSummary(int[] IZIds)
	{
		TaskCompletionSource<GvGMode2GetUserIZBattleSummaryResponse> tcs = new TaskCompletionSource<GvGMode2GetUserIZBattleSummaryResponse>();
		RPCConnection.QueueRequest(new GvGMode2GetUserIZBattleSummaryRequest
		{
			IZIds = IZIds,
			test_userId = -1
		}, delegate(RPCContext context)
		{
			try
			{
				GvGMode2GetUserIZBattleSummaryResponse result = context.Payload.As<GvGMode2GetUserIZBattleSummaryResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode2GetBattleRecordsResponse> GvGMode2GetBattleRecords(int IZId, int summaryId)
	{
		TaskCompletionSource<GvGMode2GetBattleRecordsResponse> tcs = new TaskCompletionSource<GvGMode2GetBattleRecordsResponse>();
		RPCConnection.QueueRequest(new GvGMode2GetBattleRecordsRequest
		{
			IZId = IZId,
			SummaryId = summaryId
		}, delegate(RPCContext context)
		{
			try
			{
				GvGMode2GetBattleRecordsResponse result = context.Payload.As<GvGMode2GetBattleRecordsResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGRoomOperationResponse> GvGRoomOperation(string op)
	{
		TaskCompletionSource<GvGRoomOperationResponse> tcs = new TaskCompletionSource<GvGRoomOperationResponse>();
		RPCConnection.QueueRequest(new GvGRoomOperationRequest
		{
			Op = op
		}, delegate(RPCContext context)
		{
			try
			{
				GvGRoomOperationResponse result = context.Payload.As<GvGRoomOperationResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGRoomOperationDisabledResponse> GvGRoomOperationDisabled()
	{
		TaskCompletionSource<GvGRoomOperationDisabledResponse> tcs = new TaskCompletionSource<GvGRoomOperationDisabledResponse>();
		RPCConnection.QueueRequest(new GvGRoomOperationDisabledRequest(), delegate(RPCContext context)
		{
			try
			{
				GvGRoomOperationDisabledResponse result = context.Payload.As<GvGRoomOperationDisabledResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode3RoomOperationDiabledResponse> GvGMode3RoomOperationDisabled()
	{
		TaskCompletionSource<GvGMode3RoomOperationDiabledResponse> tcs = new TaskCompletionSource<GvGMode3RoomOperationDiabledResponse>();
		RPCConnection.QueueRequest(new GvGMode3RoomOperationDiabledRequest(), delegate(RPCContext context)
		{
			try
			{
				GvGMode3RoomOperationDiabledResponse result = context.Payload.As<GvGMode3RoomOperationDiabledResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode2SyncBattleConfigResponse> GvGMode2SyncBattleConfig(List<string> soldiers, string formationId, string shipId)
	{
		TaskCompletionSource<GvGMode2SyncBattleConfigResponse> tcs = new TaskCompletionSource<GvGMode2SyncBattleConfigResponse>();
		RPCConnection.QueueRequest(new GvGMode2SyncBattleConfigRequest
		{
			Soldiers = soldiers,
			FormationId = formationId,
			ShipId = shipId
		}, delegate(RPCContext context)
		{
			try
			{
				GvGMode2SyncBattleConfigResponse result = context.Payload.As<GvGMode2SyncBattleConfigResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGWorldBossRecordRanking2Response> GvGWorldBossRecordRanking2(string _IZId, string _WBId, string key)
	{
		TaskCompletionSource<GvGWorldBossRecordRanking2Response> tcs = new TaskCompletionSource<GvGWorldBossRecordRanking2Response>();
		RPCConnection.QueueRequest(new GvGWorldBossRecordRanking2Request
		{
			IZId = _IZId,
			WBId = _WBId,
			Key = key
		}, delegate(RPCContext context)
		{
			try
			{
				GvGWorldBossRecordRanking2Response result = context.Payload.As<GvGWorldBossRecordRanking2Response>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGWorldBossRecordRankingResponse> GvGWorldBossRecordRanking(string _IZId, string _WBId, string key)
	{
		TaskCompletionSource<GvGWorldBossRecordRankingResponse> tcs = new TaskCompletionSource<GvGWorldBossRecordRankingResponse>();
		RPCConnection.QueueRequest(new GvGWorldBossRecordRankingRequest
		{
			IZId = _IZId,
			WBId = _WBId,
			Key = key
		}, delegate(RPCContext context)
		{
			try
			{
				GvGWorldBossRecordRankingResponse result = context.Payload.As<GvGWorldBossRecordRankingResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGWorldBossGetBattleResultListResponse> GvGWorldBossGetBattleResultList()
	{
		TaskCompletionSource<GvGWorldBossGetBattleResultListResponse> tcs = new TaskCompletionSource<GvGWorldBossGetBattleResultListResponse>();
		RPCConnection.QueueRequest(new GvGWorldBossGetBattleResultListRequest(), delegate(RPCContext context)
		{
			try
			{
				GvGWorldBossGetBattleResultListResponse result = context.Payload.As<GvGWorldBossGetBattleResultListResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGGetWorldBossInfoResponse> GvGGetWorldBossInfo(eGvGProcessType type)
	{
		TaskCompletionSource<GvGGetWorldBossInfoResponse> tcs = new TaskCompletionSource<GvGGetWorldBossInfoResponse>();
		RPCConnection.QueueRequest(new GvGGetWorldBossInfoRequest
		{
			ProcessType = (int)type
		}, delegate(RPCContext context)
		{
			try
			{
				GvGGetWorldBossInfoResponse result = context.Payload.As<GvGGetWorldBossInfoResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGGetShipRecordsResponse> GvGGetShipRecords(string _IZConfigId, string _IZId, int _Idx)
	{
		TaskCompletionSource<GvGGetShipRecordsResponse> tcs = new TaskCompletionSource<GvGGetShipRecordsResponse>();
		RPCConnection.QueueRequest(new GvGGetShipRecordsRequest
		{
			IZConfigId = _IZConfigId,
			IZId = _IZId,
			Idx = _Idx
		}, delegate(RPCContext context)
		{
			try
			{
				GvGGetShipRecordsResponse result = context.Payload.As<GvGGetShipRecordsResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGWorldBossStartBattleResponse> GvGWorldBossStartBattle(string wbId, string formationId, List<string> soldierIds, string _IZId)
	{
		TaskCompletionSource<GvGWorldBossStartBattleResponse> tcs = new TaskCompletionSource<GvGWorldBossStartBattleResponse>();
		RPCConnection.QueueRequest(new GvGWorldBossStartBattleRequest
		{
			WBId = wbId,
			FormationId = formationId,
			SoldierIds = soldierIds,
			IZId = _IZId
		}, delegate(RPCContext context)
		{
			try
			{
				GvGWorldBossStartBattleResponse result = context.Payload.As<GvGWorldBossStartBattleResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGGetWorldBossKeyInfoResponse> GvGGetWorldBossKeyInfo(string _IZId)
	{
		TaskCompletionSource<GvGGetWorldBossKeyInfoResponse> tcs = new TaskCompletionSource<GvGGetWorldBossKeyInfoResponse>();
		RPCConnection.QueueRequest(new GvGGetWorldBossKeyInfoRequest
		{
			IZId = _IZId
		}, delegate(RPCContext context)
		{
			try
			{
				GvGGetWorldBossKeyInfoResponse result = context.Payload.As<GvGGetWorldBossKeyInfoResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<DownloadArchiveResponse> DownloadArchive()
	{
		TaskCompletionSource<DownloadArchiveResponse> tcs = new TaskCompletionSource<DownloadArchiveResponse>();
		RPCConnection.QueueRequest(new DownloadArchiveRequest(), delegate(RPCContext context)
		{
			try
			{
				DownloadArchiveResponse result = context.Payload.As<DownloadArchiveResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SetAsNewGuideModeResponse> SetAsNewGuideMode()
	{
		TaskCompletionSource<SetAsNewGuideModeResponse> tcs = new TaskCompletionSource<SetAsNewGuideModeResponse>();
		string text = HotUpdateProcess.Instance.Configs["NewGuideMode"];
		if (text == "1")
		{
			text = (HotUpdateProcess.Instance.IsRegionOutCN ? "NewForeign" : "New");
		}
		string value;
		string storyNodeConfigVersion = (HotUpdateProcess.Instance.Configs.TryGetValue("StoryNodeConfigVersion", out value) ? value : string.Empty);
		RPCConnection.QueueRequest(new SetAsNewGuideModeRequest
		{
			GuideMode = text,
			StoryNodeConfigVersion = storyNodeConfigVersion
		}, delegate(RPCContext context)
		{
			try
			{
				SetAsNewGuideModeResponse result = context.Payload.As<SetAsNewGuideModeResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetMissionOf7Foreign.Response> GetMissionOf7ForeignRequest()
	{
		TaskCompletionSource<GetMissionOf7Foreign.Response> tcs = new TaskCompletionSource<GetMissionOf7Foreign.Response>();
		RPCConnection.QueueRequest(new GetMissionOf7Foreign.Request
		{
			ActivityId = "MissionsOf7Days2"
		}, delegate(RPCContext context)
		{
			try
			{
				GetMissionOf7Foreign.Response result = context.Payload.As<GetMissionOf7Foreign.Response>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ClaimMissionOf7Foreign.Response> ClaimMissionOf7Foreign(int score, bool isAdvance)
	{
		TaskCompletionSource<ClaimMissionOf7Foreign.Response> tcs = new TaskCompletionSource<ClaimMissionOf7Foreign.Response>();
		RPCConnection.QueueRequest(new ClaimMissionOf7Foreign.Request
		{
			ActivityId = "MissionsOf7Days2",
			Score = score,
			ClaimPayBonus = isAdvance
		}, delegate(RPCContext context)
		{
			try
			{
				ClaimMissionOf7Foreign.Response result = context.Payload.As<ClaimMissionOf7Foreign.Response>();
				tcs.SetResult(result);
			}
			catch (Exception ex)
			{
				ILRuntimeDebug.LogError(ex.ToString());
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<EnterGameResponse> EnterGame()
	{
		TaskCompletionSource<EnterGameResponse> tcs = new TaskCompletionSource<EnterGameResponse>();
		RPCConnection.QueueRequest(new EnterGameRequest(), delegate(RPCContext context)
		{
			try
			{
				tcs.SetResult(context.Payload.As<EnterGameResponse>());
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<PlayStoryResponse> PlayStory(long tick, string storyId)
	{
		Stopwatch stopWatch = new Stopwatch();
		stopWatch.Start();
		int requestIndex = RequestIndex;
		TaskCompletionSource<PlayStoryResponse> tcs = new TaskCompletionSource<PlayStoryResponse>();
		RPCConnection.QueueRequest(new PlayStoryRequest
		{
			Tick = tick,
			StoryId = storyId
		}, delegate(RPCContext context)
		{
			try
			{
				stopWatch.Stop();
				PlayStoryResponse result = context.Payload.As<PlayStoryResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<TriggerStoryResponse> TriggerStory(long tick, string storyKey)
	{
		Stopwatch stopWatch = new Stopwatch();
		stopWatch.Start();
		int requestIndex = RequestIndex;
		TaskCompletionSource<TriggerStoryResponse> tcs = new TaskCompletionSource<TriggerStoryResponse>();
		RPCConnection.QueueRequest(new TriggerStoryRequest
		{
			Tick = tick,
			StoryKey = storyKey
		}, delegate(RPCContext context)
		{
			try
			{
				stopWatch.Stop();
				TriggerStoryResponse result = context.Payload.As<TriggerStoryResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SkipCurrentStoryResponse> SkipCurrentStory(long tick, string uiName)
	{
		TaskCompletionSource<SkipCurrentStoryResponse> tcs = new TaskCompletionSource<SkipCurrentStoryResponse>();
		RPCConnection.QueueRequest(new SkipCurrentStoryRequest
		{
			Tick = tick,
			UiName = uiName
		}, delegate(RPCContext context)
		{
			try
			{
				SkipCurrentStoryResponse result = context.Payload.As<SkipCurrentStoryResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ChangeCampProduceConfigResponse> ChangeCampProduceConfig(long tick, Dictionary<int, string> config)
	{
		TaskCompletionSource<ChangeCampProduceConfigResponse> tcs = new TaskCompletionSource<ChangeCampProduceConfigResponse>();
		RPCConnection.QueueRequest(new ChangeCampProduceConfigRequest
		{
			Tick = tick,
			Config = config
		}, delegate(RPCContext context)
		{
			try
			{
				ChangeCampProduceConfigResponse result = context.Payload.As<ChangeCampProduceConfigResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ChangeWorkshopProduceConfigResponse> ChangeWorkshopProduceConfig(long tick, string buildingType, Dictionary<int, int> workers, Dictionary<int, List<string>> products)
	{
		TaskCompletionSource<ChangeWorkshopProduceConfigResponse> tcs = new TaskCompletionSource<ChangeWorkshopProduceConfigResponse>();
		RPCConnection.QueueRequest(new ChangeWorkshopProduceConfigRequest
		{
			Tick = tick,
			BuildingType = buildingType,
			Workers = workers,
			Products = products
		}, delegate(RPCContext context)
		{
			try
			{
				ChangeWorkshopProduceConfigResponse result = context.Payload.As<ChangeWorkshopProduceConfigResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ChangeStrongholdProduceConfigResponse> ChangeStrongholdProduceConfig(long tick, string strongholdId, string soldierId)
	{
		TaskCompletionSource<ChangeStrongholdProduceConfigResponse> tcs = new TaskCompletionSource<ChangeStrongholdProduceConfigResponse>();
		RPCConnection.QueueRequest(new ChangeStrongholdProduceConfigRequest
		{
			Tick = tick,
			StrongholdId = strongholdId,
			SoldierId = soldierId
		}, delegate(RPCContext context)
		{
			try
			{
				ChangeStrongholdProduceConfigResponse result = context.Payload.As<ChangeStrongholdProduceConfigResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<UpgradeBuildingResponse> UpgradeBuilding(long tick, string buildingType, int workers, List<UserData> data)
	{
		TaskCompletionSource<UpgradeBuildingResponse> tcs = new TaskCompletionSource<UpgradeBuildingResponse>();
		RPCConnection.QueueRequest(new UpgradeBuildingRequest
		{
			Tick = tick,
			BuildingType = buildingType,
			Workers = workers,
			Data = data
		}, delegate(RPCContext context)
		{
			try
			{
				UpgradeBuildingResponse result = context.Payload.As<UpgradeBuildingResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<FinishUpgradeBuildingResponse> FinishUpgradeBuilding(long tick, string buildingType)
	{
		TaskCompletionSource<FinishUpgradeBuildingResponse> tcs = new TaskCompletionSource<FinishUpgradeBuildingResponse>();
		RPCConnection.QueueRequest(new FinishUpgradeBuildingRequest
		{
			Tick = tick,
			BuildingType = buildingType
		}, delegate(RPCContext context)
		{
			try
			{
				FinishUpgradeBuildingResponse result = context.Payload.As<FinishUpgradeBuildingResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetFormationInfoResponse> GetFormationInfo(long tick, string levelId)
	{
		TaskCompletionSource<GetFormationInfoResponse> tcs = new TaskCompletionSource<GetFormationInfoResponse>();
		RPCConnection.QueueRequest(new GetFormationInfoRequest
		{
			Tick = tick,
			LevelId = levelId
		}, delegate(RPCContext context)
		{
			try
			{
				GetFormationInfoResponse result = context.Payload.As<GetFormationInfoResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<CheckCanQuickBattleResponse> CheckCanQuickBattle(long tick, string levelId)
	{
		TaskCompletionSource<CheckCanQuickBattleResponse> tcs = new TaskCompletionSource<CheckCanQuickBattleResponse>();
		RPCConnection.QueueRequest(new CheckCanQuickBattleRequest
		{
			Tick = tick,
			LevelId = levelId
		}, delegate(RPCContext context)
		{
			try
			{
				CheckCanQuickBattleResponse result = context.Payload.As<CheckCanQuickBattleResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<StartBattleResponse> StartBattle(long tick, string levelId, string formationId, string[] soldierIds, int[] nums, bool quickBattle)
	{
		TaskCompletionSource<StartBattleResponse> tcs = new TaskCompletionSource<StartBattleResponse>();
		RPCConnection.QueueRequest(new StartBattleRequest
		{
			Tick = tick,
			LevelId = levelId,
			FormationId = formationId,
			SoldierIds = soldierIds,
			Nums = nums,
			QuickBattle = quickBattle
		}, delegate(RPCContext context)
		{
			try
			{
				StartBattleResponse result = context.Payload.As<StartBattleResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<DownloadBattleReplayResponse> DownloadBattleReplay(string battleId, int replayIndex)
	{
		TaskCompletionSource<DownloadBattleReplayResponse> tcs = new TaskCompletionSource<DownloadBattleReplayResponse>();
		RPCConnection.QueueRequest(new DownloadBattleReplayRequest
		{
			BattleId = battleId,
			ReplayIndex = replayIndex
		}, delegate(RPCContext context)
		{
			try
			{
				DownloadBattleReplayResponse result = context.Payload.As<DownloadBattleReplayResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetBattleResultResponse> GetBattleResult(long tick, string battleId, string subLevelId)
	{
		TaskCompletionSource<GetBattleResultResponse> tcs = new TaskCompletionSource<GetBattleResultResponse>();
		RPCConnection.QueueRequest(new GetBattleResultRequest
		{
			Tick = tick,
			BattleId = battleId,
			CurrentLevelId = subLevelId
		}, delegate(RPCContext context)
		{
			try
			{
				GetBattleResultResponse result = context.Payload.As<GetBattleResultResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<CheckBattleFailedProcessResponse> CheckBattleFailedProcess(long tick, string battleId, string subLevelId)
	{
		TaskCompletionSource<CheckBattleFailedProcessResponse> tcs = new TaskCompletionSource<CheckBattleFailedProcessResponse>();
		RPCConnection.QueueRequest(new CheckBattleFailedProcessRequest
		{
			Tick = tick,
			BattleId = battleId,
			CurrentLevelId = subLevelId
		}, delegate(RPCContext context)
		{
			try
			{
				CheckBattleFailedProcessResponse result = context.Payload.As<CheckBattleFailedProcessResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ChangeFormationResponse> ChangeFormation(long tick, string ctx, string mode, string formationId)
	{
		TaskCompletionSource<ChangeFormationResponse> tcs = new TaskCompletionSource<ChangeFormationResponse>();
		RPCConnection.QueueRequest(new ChangeFormationRequest
		{
			Tick = tick,
			Context = ctx,
			Mode = mode,
			FormationId = formationId
		}, delegate(RPCContext context)
		{
			try
			{
				ChangeFormationResponse result = context.Payload.As<ChangeFormationResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ChangeFormationUnitResponse> ChangeFormationUnit(long tick, string ctx, string mode, int portalId, string unidId)
	{
		TaskCompletionSource<ChangeFormationUnitResponse> tcs = new TaskCompletionSource<ChangeFormationUnitResponse>();
		RPCConnection.QueueRequest(new ChangeFormationUnitRequest
		{
			Tick = tick,
			Context = ctx,
			Mode = mode,
			PortalId = portalId,
			UnitId = unidId
		}, delegate(RPCContext context)
		{
			try
			{
				ChangeFormationUnitResponse result = context.Payload.As<ChangeFormationUnitResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SyncFormationUnitsResponse> SyncFormationUnits(long tick, string ctx, string mode, List<string> unitsId)
	{
		TaskCompletionSource<SyncFormationUnitsResponse> tcs = new TaskCompletionSource<SyncFormationUnitsResponse>();
		RPCConnection.QueueRequest(new SyncFormationUnitsRequest
		{
			Tick = tick,
			Context = ctx,
			Mode = mode,
			UnitsId = unitsId
		}, delegate(RPCContext context)
		{
			try
			{
				SyncFormationUnitsResponse result = context.Payload.As<SyncFormationUnitsResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SyncRankFormationUnitsResponse> SyncRankFormationUnits(long tick, List<string> formationsId, List<List<string>> unitsId)
	{
		TaskCompletionSource<SyncRankFormationUnitsResponse> tcs = new TaskCompletionSource<SyncRankFormationUnitsResponse>();
		RPCConnection.QueueRequest(new SyncRankFormationUnitsRequest
		{
			Tick = tick,
			FormationsId = JsonHelper.ToJson(formationsId),
			UnitsId = JsonHelper.ToJson(unitsId)
		}, delegate(RPCContext context)
		{
			try
			{
				SyncRankFormationUnitsResponse result = context.Payload.As<SyncRankFormationUnitsResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SetFormationUnitsOfRankResponse> SetFormationUnitsOfRank(int rank, List<string> formationsId, List<List<string>> unitsId)
	{
		TaskCompletionSource<SetFormationUnitsOfRankResponse> tcs = new TaskCompletionSource<SetFormationUnitsOfRankResponse>();
		RPCConnection.QueueRequest(new SetFormationUnitsOfRankRequest
		{
			Tick = -1L,
			Rank = rank,
			FormationsId = JsonHelper.ToJson(formationsId),
			UnitsId = JsonHelper.ToJson(unitsId)
		}, delegate(RPCContext context)
		{
			try
			{
				SetFormationUnitsOfRankResponse result = context.Payload.As<SetFormationUnitsOfRankResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SubmitBattleOperationResponse> SubmitBattleOperation(long tick, string battleId, int subLevelIndex, string formationId, string[] units)
	{
		TaskCompletionSource<SubmitBattleOperationResponse> tcs = new TaskCompletionSource<SubmitBattleOperationResponse>();
		RPCConnection.QueueRequest(new SubmitBattleOperationRequest
		{
			Tick = tick,
			BattleId = battleId,
			SubLevelIndex = subLevelIndex,
			FormationId = formationId,
			Units = units
		}, delegate(RPCContext context)
		{
			try
			{
				SubmitBattleOperationResponse result = context.Payload.As<SubmitBattleOperationResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<RetreatResponse> Retreat(long tick, string battleId)
	{
		TaskCompletionSource<RetreatResponse> tcs = new TaskCompletionSource<RetreatResponse>();
		RPCConnection.QueueRequest(new RetreatRequest
		{
			Tick = tick,
			BattleId = battleId
		}, delegate(RPCContext context)
		{
			try
			{
				RetreatResponse result = context.Payload.As<RetreatResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetBattleBonusResponse> GetBattleBonus(string battleId, string currentLevelId)
	{
		TaskCompletionSource<GetBattleBonusResponse> tcs = new TaskCompletionSource<GetBattleBonusResponse>();
		RPCConnection.QueueRequest(new GetBattleBonusRequest
		{
			BattleId = battleId,
			CurrentLevelId = currentLevelId
		}, delegate(RPCContext context)
		{
			try
			{
				GetBattleBonusResponse result = context.Payload.As<GetBattleBonusResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ConfirmBattleBonusResponse> ConfirmBattleBonus(string battleId, int selectIndex)
	{
		TaskCompletionSource<ConfirmBattleBonusResponse> tcs = new TaskCompletionSource<ConfirmBattleBonusResponse>();
		RPCConnection.QueueRequest(new ConfirmBattleBonusRequest
		{
			BattleId = battleId,
			SelectIndex = selectIndex
		}, delegate(RPCContext context)
		{
			try
			{
				ConfirmBattleBonusResponse result = context.Payload.As<ConfirmBattleBonusResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetLevelReplaysResponse> GetLevelReplays(string levelId, bool random, string battleid)
	{
		TaskCompletionSource<GetLevelReplaysResponse> tcs = new TaskCompletionSource<GetLevelReplaysResponse>();
		RPCConnection.QueueRequest(new GetLevelReplaysRequest
		{
			LevelId = levelId,
			Random = random,
			BattleId = battleid
		}, delegate(RPCContext context)
		{
			try
			{
				GetLevelReplaysResponse result = context.Payload.As<GetLevelReplaysResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<RevokeBattleResponse> RevokeBattle(string battleId)
	{
		TaskCompletionSource<RevokeBattleResponse> tcs = new TaskCompletionSource<RevokeBattleResponse>();
		RPCConnection.QueueRequest(new RevokeBattleRequest
		{
			BattleId = battleId
		}, delegate(RPCContext context)
		{
			try
			{
				RevokeBattleResponse result = context.Payload.As<RevokeBattleResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetRecentReplaysResponse> GetRecentReplays()
	{
		TaskCompletionSource<GetRecentReplaysResponse> tcs = new TaskCompletionSource<GetRecentReplaysResponse>();
		RPCConnection.QueueRequest(new GetRecentReplaysRequest(), delegate(RPCContext context)
		{
			try
			{
				GetRecentReplaysResponse result = context.Payload.As<GetRecentReplaysResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<StartRankBattleResponse> StartRankBattle(long tick, int targetRank, long rankDataTimestamp, bool isQuick = false)
	{
		TaskCompletionSource<StartRankBattleResponse> tcs = new TaskCompletionSource<StartRankBattleResponse>();
		RPCConnection.QueueRequest(new StartRankBattleRequest
		{
			Tick = tick,
			TargetRank = targetRank,
			LastBattleFinishAt = rankDataTimestamp,
			ThumbnailMode = isQuick
		}, delegate(RPCContext context)
		{
			try
			{
				StartRankBattleResponse result = context.Payload.As<StartRankBattleResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetRankBattleResultResponse> GetRankBattleResult(long tick, string battleId)
	{
		TaskCompletionSource<GetRankBattleResultResponse> tcs = new TaskCompletionSource<GetRankBattleResultResponse>();
		RPCConnection.QueueRequest(new GetRankBattleResultRequest
		{
			Tick = tick,
			BattleId = battleId
		}, delegate(RPCContext context)
		{
			try
			{
				GetRankBattleResultResponse result = context.Payload.As<GetRankBattleResultResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetSelfRankResponse> GetSelfRank(long tick)
	{
		TaskCompletionSource<GetSelfRankResponse> tcs = new TaskCompletionSource<GetSelfRankResponse>();
		RPCConnection.QueueRequest(new GetSelfRankRequest
		{
			Tick = tick
		}, delegate(RPCContext context)
		{
			try
			{
				GetSelfRankResponse result = context.Payload.As<GetSelfRankResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetDetailRankInfoResponse> GetDetailRankInfo(long tick, int rank, long rankDataTimestamp)
	{
		TaskCompletionSource<GetDetailRankInfoResponse> tcs = new TaskCompletionSource<GetDetailRankInfoResponse>();
		RPCConnection.QueueRequest(new GetDetailRankInfoRequest
		{
			Tick = tick,
			Rank = rank,
			LastBattleFinishAt = rankDataTimestamp
		}, delegate(RPCContext context)
		{
			try
			{
				GetDetailRankInfoResponse result = context.Payload.As<GetDetailRankInfoResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetPvPScoreRankListResponse> GetScoreRank()
	{
		TaskCompletionSource<GetPvPScoreRankListResponse> tcs = new TaskCompletionSource<GetPvPScoreRankListResponse>();
		RPCConnection.QueueRequest(new GetPvPScoreRankListRequest(), delegate(RPCContext context)
		{
			try
			{
				GetPvPScoreRankListResponse result = context.Payload.As<GetPvPScoreRankListResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetOAIDCertPemResponse> GetOAIDCertPem()
	{
		TaskCompletionSource<GetOAIDCertPemResponse> tcs = new TaskCompletionSource<GetOAIDCertPemResponse>();
		RPCConnection.QueueRequest(new GetOAIDCertPemRequest(), delegate(RPCContext context)
		{
			try
			{
				GetOAIDCertPemResponse result = context.Payload.As<GetOAIDCertPemResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetAllSoldiersCombatPowerResponse> GetAllSoldiersCombatPower(long tick)
	{
		TaskCompletionSource<GetAllSoldiersCombatPowerResponse> tcs = new TaskCompletionSource<GetAllSoldiersCombatPowerResponse>();
		RPCConnection.QueueRequest(new GetAllSoldiersCombatPowerRequest
		{
			Tick = tick
		}, delegate(RPCContext context)
		{
			try
			{
				GetAllSoldiersCombatPowerResponse result = context.Payload.As<GetAllSoldiersCombatPowerResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetPvPRankBattleRecordsResponse> GetRankBattleRecords(int cutoffat, int offset)
	{
		TaskCompletionSource<GetPvPRankBattleRecordsResponse> tcs = new TaskCompletionSource<GetPvPRankBattleRecordsResponse>();
		RPCConnection.QueueRequest(new GetPvPRankBattleRecordsRequest
		{
			Offset = offset,
			CutOffAt = cutoffat
		}, delegate(RPCContext context)
		{
			try
			{
				GetPvPRankBattleRecordsResponse result = context.Payload.As<GetPvPRankBattleRecordsResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<InformWatchingReplayResponse> InformWatchingReplay(string battleId)
	{
		TaskCompletionSource<InformWatchingReplayResponse> tcs = new TaskCompletionSource<InformWatchingReplayResponse>();
		RPCConnection.QueueRequest(new InformWatchingReplayRequest
		{
			BattleId = battleId
		}, delegate(RPCContext context)
		{
			try
			{
				InformWatchingReplayResponse result = context.Payload.As<InformWatchingReplayResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetGvGMedalRecordResponse> GetGvGMedalRecord()
	{
		TaskCompletionSource<GetGvGMedalRecordResponse> tcs = new TaskCompletionSource<GetGvGMedalRecordResponse>();
		RPCConnection.QueueRequest(new GetGvGMedalRecordRequest(), delegate(RPCContext context)
		{
			try
			{
				GetGvGMedalRecordResponse result = context.Payload.As<GetGvGMedalRecordResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetGvGMedalRankResponse> GetGvGMedalRank(string medalId)
	{
		TaskCompletionSource<GetGvGMedalRankResponse> tcs = new TaskCompletionSource<GetGvGMedalRankResponse>();
		RPCConnection.QueueRequest(new GetGvGMedalRankRequest
		{
			MedalId = medalId
		}, delegate(RPCContext context)
		{
			try
			{
				GetGvGMedalRankResponse result = context.Payload.As<GetGvGMedalRankResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ProfileChangeMedalResponse> ProfileChangeMedal(string changeContext)
	{
		TaskCompletionSource<ProfileChangeMedalResponse> tcs = new TaskCompletionSource<ProfileChangeMedalResponse>();
		RPCConnection.QueueRequest(new ProfileChangeMedalRequest
		{
			ChangeContext = changeContext
		}, delegate(RPCContext context)
		{
			try
			{
				ProfileChangeMedalResponse result = context.Payload.As<ProfileChangeMedalResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<LegendItemBlueprintGetResponse> LegendItemBlueprintGet()
	{
		TaskCompletionSource<LegendItemBlueprintGetResponse> tcs = new TaskCompletionSource<LegendItemBlueprintGetResponse>();
		RPCConnection.QueueRequest(new LegendItemBlueprintGetRequest(), delegate(RPCContext context)
		{
			try
			{
				LegendItemBlueprintGetResponse result = context.Payload.As<LegendItemBlueprintGetResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<LockLegendItemBlueprintResponse> SetLockLegendItemBlueprint(string bpId, bool isLocked)
	{
		TaskCompletionSource<LockLegendItemBlueprintResponse> tcs = new TaskCompletionSource<LockLegendItemBlueprintResponse>();
		RPCConnection.QueueRequest(new LockLegendItemBlueprintRequest
		{
			BlueprintId = bpId,
			Lock = isLocked
		}, delegate(RPCContext context)
		{
			try
			{
				LockLegendItemBlueprintResponse result = context.Payload.As<LockLegendItemBlueprintResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SplitBlueprintResponse> SplitBlueprint(string bpId)
	{
		TaskCompletionSource<SplitBlueprintResponse> tcs = new TaskCompletionSource<SplitBlueprintResponse>();
		RPCConnection.QueueRequest(new SplitBlueprintRequest
		{
			BlueprintId = bpId
		}, delegate(RPCContext context)
		{
			try
			{
				SplitBlueprintResponse result = context.Payload.As<SplitBlueprintResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<LegendItemEvolvedByBlueprintResponse> LegendItemEvolvedByBlueprint(string bluePrintId, string mainId, List<string> randomIds, List<string> anyIds, List<RItem> universalLegendItem)
	{
		TaskCompletionSource<LegendItemEvolvedByBlueprintResponse> tcs = new TaskCompletionSource<LegendItemEvolvedByBlueprintResponse>();
		RPCConnection.QueueRequest(new LegendItemEvolvedByBlueprintRequest
		{
			BluePrintId = bluePrintId,
			MainId = mainId,
			RandomIds = randomIds,
			AnyIds = anyIds,
			UniversalLegendItem = universalLegendItem
		}, delegate(RPCContext context)
		{
			try
			{
				LegendItemEvolvedByBlueprintResponse result = context.Payload.As<LegendItemEvolvedByBlueprintResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<InformWatchingPvPRankReplayResponse> InformWatchingPvPRankReplay(string battleId)
	{
		TaskCompletionSource<InformWatchingPvPRankReplayResponse> tcs = new TaskCompletionSource<InformWatchingPvPRankReplayResponse>();
		RPCConnection.QueueRequest(new InformWatchingPvPRankReplayRequest
		{
			BattleId = battleId
		}, delegate(RPCContext context)
		{
			try
			{
				InformWatchingPvPRankReplayResponse result = context.Payload.As<InformWatchingPvPRankReplayResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<InformWatchingStoryMainReplayResponse> InformWatchingStoryMainReplay(string battleId)
	{
		TaskCompletionSource<InformWatchingStoryMainReplayResponse> tcs = new TaskCompletionSource<InformWatchingStoryMainReplayResponse>();
		RPCConnection.QueueRequest(new InformWatchingStoryMainReplayRequest
		{
			BattleId = battleId
		}, delegate(RPCContext context)
		{
			try
			{
				InformWatchingStoryMainReplayResponse result = context.Payload.As<InformWatchingStoryMainReplayResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<NewbieGACHAResponse> UpdateNewbieGACHAProgress(string activityId, int nextProgress, int select)
	{
		TaskCompletionSource<NewbieGACHAResponse> tcs = new TaskCompletionSource<NewbieGACHAResponse>();
		RPCConnection.QueueRequest(new NewbieGACHARequest
		{
			ActivityId = activityId,
			NextProgress = nextProgress,
			Select = select
		}, delegate(RPCContext context)
		{
			try
			{
				NewbieGACHAResponse result = context.Payload.As<NewbieGACHAResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ProfileChangeNicknameResponse> GetProfileChangeNickname(string Nickname)
	{
		TaskCompletionSource<ProfileChangeNicknameResponse> tcs = new TaskCompletionSource<ProfileChangeNicknameResponse>();
		ProfileChangeNicknameRequest message = new ProfileChangeNicknameRequest
		{
			NewNickname = Nickname
		};
		RPCConnection.QueueRequest(message, delegate(RPCContext context)
		{
			try
			{
				ProfileChangeNicknameResponse result = context.Payload.As<ProfileChangeNicknameResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<DrawOuterTechResponse> DrawOuterTech(string activityId)
	{
		TaskCompletionSource<DrawOuterTechResponse> tcs = new TaskCompletionSource<DrawOuterTechResponse>();
		RPCConnection.QueueRequest(new DrawOuterTechRequest
		{
			ActivityId = activityId
		}, delegate(RPCContext context)
		{
			try
			{
				DrawOuterTechResponse result = context.Payload.As<DrawOuterTechResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ExchangeOuterTechResponse> ExchangeOuterTech(string activityId, string itemId)
	{
		TaskCompletionSource<ExchangeOuterTechResponse> tcs = new TaskCompletionSource<ExchangeOuterTechResponse>();
		RPCConnection.QueueRequest(new ExchangeOuterTechRequest
		{
			ActivityId = activityId,
			ItemId = itemId
		}, delegate(RPCContext context)
		{
			try
			{
				ExchangeOuterTechResponse result = context.Payload.As<ExchangeOuterTechResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetOuterTechGiftResponse> GetOuterTechGift(string activityId)
	{
		TaskCompletionSource<GetOuterTechGiftResponse> tcs = new TaskCompletionSource<GetOuterTechGiftResponse>();
		RPCConnection.QueueRequest(new GetOuterTechGiftRequest
		{
			ActivityId = activityId
		}, delegate(RPCContext context)
		{
			try
			{
				GetOuterTechGiftResponse result = context.Payload.As<GetOuterTechGiftResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetOuterTechSpeedPlanResponse> GetOuterTechSpeedPlan()
	{
		TaskCompletionSource<GetOuterTechSpeedPlanResponse> tcs = new TaskCompletionSource<GetOuterTechSpeedPlanResponse>();
		RPCConnection.QueueRequest(new GetOuterTechSpeedPlanRequest(), delegate(RPCContext context)
		{
			try
			{
				GetOuterTechSpeedPlanResponse result = context.Payload.As<GetOuterTechSpeedPlanResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ClaimOuterTechSpeedPlanResponse> ClaimOuterTechSpeedPlan()
	{
		TaskCompletionSource<ClaimOuterTechSpeedPlanResponse> tcs = new TaskCompletionSource<ClaimOuterTechSpeedPlanResponse>();
		RPCConnection.QueueRequest(new ClaimOuterTechSpeedPlanRequest(), delegate(RPCContext context)
		{
			try
			{
				ClaimOuterTechSpeedPlanResponse result = context.Payload.As<ClaimOuterTechSpeedPlanResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetBBSKeyResponse> GetBBSKey()
	{
		TaskCompletionSource<GetBBSKeyResponse> tcs = new TaskCompletionSource<GetBBSKeyResponse>();
		RPCConnection.QueueRequest(new GetBBSKeyRequest(), delegate(RPCContext context)
		{
			try
			{
				GetBBSKeyResponse result = context.Payload.As<GetBBSKeyResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ProfileChangeAvatarResponse> ProfileChangeAvatar(byte[] newAvatarData132, byte[] newAvatarData450)
	{
		TaskCompletionSource<ProfileChangeAvatarResponse> tcs = new TaskCompletionSource<ProfileChangeAvatarResponse>();
		RPCConnection.QueueRequest(new ProfileChangeAvatarRequest
		{
			NewAvatarData132 = newAvatarData132,
			NewAvatarData450 = newAvatarData450
		}, delegate(RPCContext context)
		{
			try
			{
				ProfileChangeAvatarResponse result = context.Payload.As<ProfileChangeAvatarResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetDecorativeObjectsResponse> GetDecorativeObjects(int type)
	{
		TaskCompletionSource<GetDecorativeObjectsResponse> tcs = new TaskCompletionSource<GetDecorativeObjectsResponse>();
		RPCConnection.QueueRequest(new GetDecorativeObjectsRequest
		{
			Type = type
		}, delegate(RPCContext context)
		{
			try
			{
				GetDecorativeObjectsResponse result = context.Payload.As<GetDecorativeObjectsResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<UseDecorativeObjectsResponse> GetUseDecorativeObjects(int type, string itemid)
	{
		TaskCompletionSource<UseDecorativeObjectsResponse> tcs = new TaskCompletionSource<UseDecorativeObjectsResponse>();
		RPCConnection.QueueRequest(new UseDecorativeObjectsRequest
		{
			Type = type,
			ItemId = itemid
		}, delegate(RPCContext context)
		{
			try
			{
				UseDecorativeObjectsResponse result = context.Payload.As<UseDecorativeObjectsResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<PvPRankAddAttackBuffResponse> AddRankAttackBuff(int addBuffCnt)
	{
		TaskCompletionSource<PvPRankAddAttackBuffResponse> tcs = new TaskCompletionSource<PvPRankAddAttackBuffResponse>();
		RPCConnection.QueueRequest(new PvPRankAddAttackBuffRequest
		{
			AddBuffCount = addBuffCnt
		}, delegate(RPCContext context)
		{
			try
			{
				PvPRankAddAttackBuffResponse result = context.Payload.As<PvPRankAddAttackBuffResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetSimplePvPRankListResponse> GetSimplePvPRank(long tick)
	{
		TaskCompletionSource<GetSimplePvPRankListResponse> tcs = new TaskCompletionSource<GetSimplePvPRankListResponse>();
		RPCConnection.QueueRequest(new GetSimplePvPRankListRequest
		{
			Tick = tick
		}, delegate(RPCContext context)
		{
			try
			{
				GetSimplePvPRankListResponse result = context.Payload.As<GetSimplePvPRankListResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetPVPRankSeasonInfoResponse> GetPVPRankSeasonInfo(long tick)
	{
		TaskCompletionSource<GetPVPRankSeasonInfoResponse> tcs = new TaskCompletionSource<GetPVPRankSeasonInfoResponse>();
		RPCConnection.QueueRequest(new GetPVPRankSeasonInfoRequest
		{
			Tick = tick
		}, delegate(RPCContext context)
		{
			try
			{
				GetPVPRankSeasonInfoResponse result = context.Payload.As<GetPVPRankSeasonInfoResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetPvPRankLastTurnLast10SelfRankRecordResponse> GetPvPRankLastTurnLast10SelfRankRecord(int seasonId, int turnId)
	{
		TaskCompletionSource<GetPvPRankLastTurnLast10SelfRankRecordResponse> tcs = new TaskCompletionSource<GetPvPRankLastTurnLast10SelfRankRecordResponse>();
		RPCConnection.QueueRequest(new GetPvPRankLastTurnLast10SelfRankRecordRequest
		{
			SeasonId = seasonId,
			TurnId = turnId
		}, delegate(RPCContext context)
		{
			try
			{
				GetPvPRankLastTurnLast10SelfRankRecordResponse result = context.Payload.As<GetPvPRankLastTurnLast10SelfRankRecordResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetUserProfileUrlResponse> GetUserProfileUrl()
	{
		TaskCompletionSource<GetUserProfileUrlResponse> tcs = new TaskCompletionSource<GetUserProfileUrlResponse>();
		RPCConnection.QueueRequest(new GetUserProfileUrlRequest(), delegate(RPCContext context)
		{
			try
			{
				GetUserProfileUrlResponse result = context.Payload.As<GetUserProfileUrlResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetPvPTopTournamentRankResponse> GetPvPTopTournamentRankInfo()
	{
		TaskCompletionSource<GetPvPTopTournamentRankResponse> tcs = new TaskCompletionSource<GetPvPTopTournamentRankResponse>();
		RPCConnection.QueueRequest(new GetPvPTopTournamentRankRequest(), delegate(RPCContext context)
		{
			try
			{
				GetPvPTopTournamentRankResponse result = context.Payload.As<GetPvPTopTournamentRankResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetPvPRankLastTurnResultResponse> GetPvPRankLastTurnResult(int seasonId, int turnId)
	{
		TaskCompletionSource<GetPvPRankLastTurnResultResponse> tcs = new TaskCompletionSource<GetPvPRankLastTurnResultResponse>();
		RPCConnection.QueueRequest(new GetPvPRankLastTurnResultRequest
		{
			SeasonId = seasonId,
			TurnId = turnId
		}, delegate(RPCContext context)
		{
			try
			{
				GetPvPRankLastTurnResultResponse result = context.Payload.As<GetPvPRankLastTurnResultResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetPvPTopTournamentRecordSinglePlayerResponse> GetPvPTopTournamentRecordSinglePlayer(int day, int userId)
	{
		TaskCompletionSource<GetPvPTopTournamentRecordSinglePlayerResponse> tcs = new TaskCompletionSource<GetPvPTopTournamentRecordSinglePlayerResponse>();
		RPCConnection.QueueRequest(new GetPvPTopTournamentRecordSinglePlayerRequest
		{
			Day = day,
			UserId = userId
		}, delegate(RPCContext context)
		{
			try
			{
				GetPvPTopTournamentRecordSinglePlayerResponse result = context.Payload.As<GetPvPTopTournamentRecordSinglePlayerResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetPvPTopTournamentReplayResponse> GetPvPTopTournamentReplay(string battle)
	{
		TaskCompletionSource<GetPvPTopTournamentReplayResponse> tcs = new TaskCompletionSource<GetPvPTopTournamentReplayResponse>();
		RPCConnection.QueueRequest(new GetPvPTopTournamentReplayRequest
		{
			BattleId = battle
		}, delegate(RPCContext context)
		{
			try
			{
				GetPvPTopTournamentReplayResponse result = context.Payload.As<GetPvPTopTournamentReplayResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetPvPRankLastTurnLastDaySinglePlayerRecordResultResponse> GetPvPRankLastTurnLastDaySinglePlayerRecordResult(int userId)
	{
		TaskCompletionSource<GetPvPRankLastTurnLastDaySinglePlayerRecordResultResponse> tcs = new TaskCompletionSource<GetPvPRankLastTurnLastDaySinglePlayerRecordResultResponse>();
		RPCConnection.QueueRequest(new GetPvPRankLastTurnLastDaySinglePlayerRecordResultRequest
		{
			UserId = userId
		}, delegate(RPCContext context)
		{
			try
			{
				GetPvPRankLastTurnLastDaySinglePlayerRecordResultResponse result = context.Payload.As<GetPvPRankLastTurnLastDaySinglePlayerRecordResultResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetPvPRankLastTurnLastDayDetailsResultResponse> GetPvPRankLastTurnLastDayDetailsResult(string battle)
	{
		TaskCompletionSource<GetPvPRankLastTurnLastDayDetailsResultResponse> tcs = new TaskCompletionSource<GetPvPRankLastTurnLastDayDetailsResultResponse>();
		RPCConnection.QueueRequest(new GetPvPRankLastTurnLastDayDetailsResultRequest
		{
			BattleId = battle
		}, delegate(RPCContext context)
		{
			try
			{
				GetPvPRankLastTurnLastDayDetailsResultResponse result = context.Payload.As<GetPvPRankLastTurnLastDayDetailsResultResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetPvPTopTournamentPlayersInfoResponse> GetPvPTopTournamentPlayersInfo()
	{
		TaskCompletionSource<GetPvPTopTournamentPlayersInfoResponse> tcs = new TaskCompletionSource<GetPvPTopTournamentPlayersInfoResponse>();
		RPCConnection.QueueRequest(new GetPvPTopTournamentPlayersInfoRequest(), delegate(RPCContext context)
		{
			try
			{
				GetPvPTopTournamentPlayersInfoResponse result = context.Payload.As<GetPvPTopTournamentPlayersInfoResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetPvPTopTournamentRecordResponse> GetPvPTopTournamentRecord(int day)
	{
		TaskCompletionSource<GetPvPTopTournamentRecordResponse> tcs = new TaskCompletionSource<GetPvPTopTournamentRecordResponse>();
		RPCConnection.QueueRequest(new GetPvPTopTournamentRecordRequest
		{
			Day = day
		}, delegate(RPCContext context)
		{
			try
			{
				GetPvPTopTournamentRecordResponse result = context.Payload.As<GetPvPTopTournamentRecordResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetPvPRankLastTurnLastDayResultResponse> GetPvPRankLastTurnLastDayResult()
	{
		TaskCompletionSource<GetPvPRankLastTurnLastDayResultResponse> tcs = new TaskCompletionSource<GetPvPRankLastTurnLastDayResultResponse>();
		RPCConnection.QueueRequest(new GetPvPRankLastTurnLastDayResultRequest(), delegate(RPCContext context)
		{
			try
			{
				GetPvPRankLastTurnLastDayResultResponse result = context.Payload.As<GetPvPRankLastTurnLastDayResultResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ClaimPvPRankScoreResponse> ClaimPvPRankScore(long tick)
	{
		TaskCompletionSource<ClaimPvPRankScoreResponse> tcs = new TaskCompletionSource<ClaimPvPRankScoreResponse>();
		RPCConnection.QueueRequest(new ClaimPvPRankScoreRequest
		{
			Tick = tick
		}, delegate(RPCContext context)
		{
			try
			{
				ClaimPvPRankScoreResponse result = context.Payload.As<ClaimPvPRankScoreResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetDynamicLimitedTimeTotalRechargeItemsResponse> GetDynamicLimitedTimeTotalRechargeItems(long tick)
	{
		TaskCompletionSource<GetDynamicLimitedTimeTotalRechargeItemsResponse> tcs = new TaskCompletionSource<GetDynamicLimitedTimeTotalRechargeItemsResponse>();
		RPCConnection.QueueRequest(new GetDynamicLimitedTimeTotalRechargeItemsRequest
		{
			Tick = tick
		}, delegate(RPCContext context)
		{
			try
			{
				GetDynamicLimitedTimeTotalRechargeItemsResponse result = context.Payload.As<GetDynamicLimitedTimeTotalRechargeItemsResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ClaimDynamicActivityLTTRResponse> ClaimDynamicActivityLTTR(string activityId, int RMB_Level)
	{
		TaskCompletionSource<ClaimDynamicActivityLTTRResponse> tcs = new TaskCompletionSource<ClaimDynamicActivityLTTRResponse>();
		RPCConnection.QueueRequest(new ClaimDynamicActivityLTTRRequest
		{
			ActivityId = activityId,
			RMB_Level = RMB_Level
		}, delegate(RPCContext context)
		{
			try
			{
				ClaimDynamicActivityLTTRResponse result = context.Payload.As<ClaimDynamicActivityLTTRResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetDynamicDiscountActivityItemsResponse> GetDynamicDiscountActivityItems(long tick)
	{
		TaskCompletionSource<GetDynamicDiscountActivityItemsResponse> tcs = new TaskCompletionSource<GetDynamicDiscountActivityItemsResponse>();
		RPCConnection.QueueRequest(new GetDynamicDiscountActivityItemsRequest
		{
			Tick = tick
		}, delegate(RPCContext context)
		{
			try
			{
				GetDynamicDiscountActivityItemsResponse result = context.Payload.As<GetDynamicDiscountActivityItemsResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetDynamicSigninActivityItemsResponse> GetDynamicSigninActivityData(long tick)
	{
		TaskCompletionSource<GetDynamicSigninActivityItemsResponse> tcs = new TaskCompletionSource<GetDynamicSigninActivityItemsResponse>();
		RPCConnection.QueueRequest(new GetDynamicSigninActivityItemsRequest
		{
			Tick = tick
		}, delegate(RPCContext context)
		{
			try
			{
				GetDynamicSigninActivityItemsResponse result = context.Payload.As<GetDynamicSigninActivityItemsResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetDynamicStarKeyStoreExchangeBonusWithKeyResponse> GetDynamicStarKeyStoreExchangeBonusWithKey(string ItemId, string ActivityId)
	{
		TaskCompletionSource<GetDynamicStarKeyStoreExchangeBonusWithKeyResponse> tcs = new TaskCompletionSource<GetDynamicStarKeyStoreExchangeBonusWithKeyResponse>();
		RPCConnection.QueueRequest(new GetDynamicStarKeyStoreExchangeBonusWithKeyRequest
		{
			ItemId = ItemId,
			ActivityId = ActivityId
		}, delegate(RPCContext context)
		{
			try
			{
				GetDynamicStarKeyStoreExchangeBonusWithKeyResponse result = context.Payload.As<GetDynamicStarKeyStoreExchangeBonusWithKeyResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetDynamicStarKeyStoreExchangeKeyResponse> GetDynamicStarKeyStoreExchangeKey(string FormulaId)
	{
		TaskCompletionSource<GetDynamicStarKeyStoreExchangeKeyResponse> tcs = new TaskCompletionSource<GetDynamicStarKeyStoreExchangeKeyResponse>();
		RPCConnection.QueueRequest(new GetDynamicStarKeyStoreExchangeKeyRequest
		{
			FormulaId = FormulaId
		}, delegate(RPCContext context)
		{
			try
			{
				GetDynamicStarKeyStoreExchangeKeyResponse result = context.Payload.As<GetDynamicStarKeyStoreExchangeKeyResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetDynamicStarKeyStoreIsNewPeriodResponse> GetDynamicStarKeyStoreIsNewPeriod()
	{
		TaskCompletionSource<GetDynamicStarKeyStoreIsNewPeriodResponse> tcs = new TaskCompletionSource<GetDynamicStarKeyStoreIsNewPeriodResponse>();
		RPCConnection.QueueRequest(new GetDynamicStarKeyStoreIsNewPeriodRequest(), delegate(RPCContext context)
		{
			try
			{
				GetDynamicStarKeyStoreIsNewPeriodResponse result = context.Payload.As<GetDynamicStarKeyStoreIsNewPeriodResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetDynamicStarKeyStoreResponse> GetDynamicStarKeyStore()
	{
		TaskCompletionSource<GetDynamicStarKeyStoreResponse> tcs = new TaskCompletionSource<GetDynamicStarKeyStoreResponse>();
		RPCConnection.QueueRequest(new GetDynamicStarKeyStoreRequest(), delegate(RPCContext context)
		{
			try
			{
				GetDynamicStarKeyStoreResponse result = context.Payload.As<GetDynamicStarKeyStoreResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetDynamicCardPoolResponse> GetDynamicCardPool(long tick)
	{
		TaskCompletionSource<GetDynamicCardPoolResponse> tcs = new TaskCompletionSource<GetDynamicCardPoolResponse>();
		RPCConnection.QueueRequest(new GetDynamicCardPoolRequest
		{
			Tick = tick
		}, delegate(RPCContext context)
		{
			try
			{
				GetDynamicCardPoolResponse result = context.Payload.As<GetDynamicCardPoolResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetDynamicCardPoolActivityResponse> GetDynamicCardPoolActivities(long tick)
	{
		TaskCompletionSource<GetDynamicCardPoolActivityResponse> tcs = new TaskCompletionSource<GetDynamicCardPoolActivityResponse>();
		RPCConnection.QueueRequest(new GetDynamicCardPoolActivityRequest
		{
			Tick = tick
		}, delegate(RPCContext context)
		{
			try
			{
				GetDynamicCardPoolActivityResponse result = context.Payload.As<GetDynamicCardPoolActivityResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetStoreContentConfigResponse> GetStoreContentConfig()
	{
		TaskCompletionSource<GetStoreContentConfigResponse> tcs = new TaskCompletionSource<GetStoreContentConfigResponse>();
		RPCConnection.QueueRequest(new GetStoreContentConfigRequest(), delegate(RPCContext context)
		{
			try
			{
				GetStoreContentConfigResponse result = context.Payload.As<GetStoreContentConfigResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetDynamicWorldBossResponse> GetDynamicWorldBoss(long tick)
	{
		TaskCompletionSource<GetDynamicWorldBossResponse> tcs = new TaskCompletionSource<GetDynamicWorldBossResponse>();
		RPCConnection.QueueRequest(new GetDynamicWorldBossRequest
		{
			Tick = tick
		}, delegate(RPCContext context)
		{
			try
			{
				GetDynamicWorldBossResponse result = context.Payload.As<GetDynamicWorldBossResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetDynamicIslandComeAgainResponse> GetDynamicIslandComeAgain(long tick)
	{
		TaskCompletionSource<GetDynamicIslandComeAgainResponse> tcs = new TaskCompletionSource<GetDynamicIslandComeAgainResponse>();
		RPCConnection.QueueRequest(new GetDynamicIslandComeAgainRequest
		{
			Tick = tick
		}, delegate(RPCContext context)
		{
			try
			{
				GetDynamicIslandComeAgainResponse result = context.Payload.As<GetDynamicIslandComeAgainResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ClaimIslandComeAgainDailyMissionBonusResponse> ClaimIslandComeAgainDailyMissionBonus(int missionId)
	{
		TaskCompletionSource<ClaimIslandComeAgainDailyMissionBonusResponse> tcs = new TaskCompletionSource<ClaimIslandComeAgainDailyMissionBonusResponse>();
		RPCConnection.QueueRequest(new ClaimIslandComeAgainDailyMissionBonusRequest
		{
			MissionId = missionId
		}, delegate(RPCContext context)
		{
			try
			{
				ClaimIslandComeAgainDailyMissionBonusResponse result = context.Payload.As<ClaimIslandComeAgainDailyMissionBonusResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetRecallPlayerDynamicActivityResponse> GetRecallPlayerDynamicActivity()
	{
		TaskCompletionSource<GetRecallPlayerDynamicActivityResponse> tcs = new TaskCompletionSource<GetRecallPlayerDynamicActivityResponse>();
		RPCConnection.QueueRequest(new GetRecallPlayerDynamicActivityRequest(), delegate(RPCContext context)
		{
			try
			{
				GetRecallPlayerDynamicActivityResponse result = context.Payload.As<GetRecallPlayerDynamicActivityResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ClaimRecallPlayerResponse> ClaimRecallPlayer(string InviteCode)
	{
		TaskCompletionSource<ClaimRecallPlayerResponse> tcs = new TaskCompletionSource<ClaimRecallPlayerResponse>();
		RPCConnection.QueueRequest(new ClaimRecallPlayerRequest
		{
			InviteCode = InviteCode
		}, delegate(RPCContext context)
		{
			try
			{
				ClaimRecallPlayerResponse result = context.Payload.As<ClaimRecallPlayerResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetDynamicIslandComeAgainRewardResponse> GetDynamicIslandComeAgainReward(long tick, int prizePoolId, int prizePoolIndex)
	{
		TaskCompletionSource<GetDynamicIslandComeAgainRewardResponse> tcs = new TaskCompletionSource<GetDynamicIslandComeAgainRewardResponse>();
		RPCConnection.QueueRequest(new GetDynamicIslandComeAgainRewardRequest
		{
			Tick = tick,
			PrizePoolId = prizePoolId,
			PrizePoolIndex = prizePoolIndex
		}, delegate(RPCContext context)
		{
			try
			{
				GetDynamicIslandComeAgainRewardResponse result = context.Payload.As<GetDynamicIslandComeAgainRewardResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetNeutralInstanceResponse> GetNeutralDungeonActivity(long tick, string activityId)
	{
		TaskCompletionSource<GetNeutralInstanceResponse> tcs = new TaskCompletionSource<GetNeutralInstanceResponse>();
		RPCConnection.QueueRequest(new GetNeutralInstanceRequest
		{
			Tick = tick,
			ActivityId = activityId
		}, delegate(RPCContext context)
		{
			try
			{
				GetNeutralInstanceResponse result = context.Payload.As<GetNeutralInstanceResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetNeutralInstanceAdInfoResponse> GetNeutralDungeonActivityAdInfo(long tick)
	{
		TaskCompletionSource<GetNeutralInstanceAdInfoResponse> tcs = new TaskCompletionSource<GetNeutralInstanceAdInfoResponse>();
		RPCConnection.QueueRequest(new GetNeutralInstanceAdInfoRequest
		{
			Tick = tick
		}, delegate(RPCContext context)
		{
			try
			{
				GetNeutralInstanceAdInfoResponse result = context.Payload.As<GetNeutralInstanceAdInfoResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<NoviceRechargeResponse> GetNoviceRechargeProgress(long tick, string activityId)
	{
		TaskCompletionSource<NoviceRechargeResponse> tcs = new TaskCompletionSource<NoviceRechargeResponse>();
		RPCConnection.QueueRequest(new NoviceRechargeRequest
		{
			Tick = tick,
			ActivityId = activityId
		}, delegate(RPCContext context)
		{
			try
			{
				NoviceRechargeResponse result = context.Payload.As<NoviceRechargeResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<NoviceRechargeBonusClaimResponse> ClaimNoviceRechargeBonus(long tick, string activityId, string score)
	{
		TaskCompletionSource<NoviceRechargeBonusClaimResponse> tcs = new TaskCompletionSource<NoviceRechargeBonusClaimResponse>();
		RPCConnection.QueueRequest(new NoviceRechargeBonusClaimRequest
		{
			Tick = tick,
			ActivityId = activityId,
			Score = score
		}, delegate(RPCContext context)
		{
			try
			{
				NoviceRechargeBonusClaimResponse result = context.Payload.As<NoviceRechargeBonusClaimResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetTreasureHouseRechargeInfoResponse> GetTreasureHouseRechargeInfo(long tick, string activityId)
	{
		TaskCompletionSource<GetTreasureHouseRechargeInfoResponse> tcs = new TaskCompletionSource<GetTreasureHouseRechargeInfoResponse>();
		RPCConnection.QueueRequest(new GetTreasureHouseRechargeInfoRequest
		{
			Tick = tick,
			ActivityId = activityId
		}, delegate(RPCContext context)
		{
			try
			{
				GetTreasureHouseRechargeInfoResponse result = context.Payload.As<GetTreasureHouseRechargeInfoResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<TreasureHouseBonusClaimResponse> TreasureHouseBonusClaim(long tick, string activityId, int score)
	{
		TaskCompletionSource<TreasureHouseBonusClaimResponse> tcs = new TaskCompletionSource<TreasureHouseBonusClaimResponse>();
		RPCConnection.QueueRequest(new TreasureHouseBonusClaimRequest
		{
			Tick = tick,
			ActivityId = activityId,
			Amount = score
		}, delegate(RPCContext context)
		{
			try
			{
				TreasureHouseBonusClaimResponse result = context.Payload.As<TreasureHouseBonusClaimResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetDynamicSecretTreasuryResponse> GetDynamicSecretTreasury()
	{
		TaskCompletionSource<GetDynamicSecretTreasuryResponse> tcs = new TaskCompletionSource<GetDynamicSecretTreasuryResponse>();
		RPCConnection.QueueRequest(new GetDynamicSecretTreasuryRequest(), delegate(RPCContext context)
		{
			try
			{
				GetDynamicSecretTreasuryResponse result = context.Payload.As<GetDynamicSecretTreasuryResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ClaimDynamicSecretTreasuryResponse> ClaimDynamicSecretTreasury(int level)
	{
		TaskCompletionSource<ClaimDynamicSecretTreasuryResponse> tcs = new TaskCompletionSource<ClaimDynamicSecretTreasuryResponse>();
		RPCConnection.QueueRequest(new ClaimDynamicSecretTreasuryRequest
		{
			Level = level
		}, delegate(RPCContext context)
		{
			try
			{
				ClaimDynamicSecretTreasuryResponse result = context.Payload.As<ClaimDynamicSecretTreasuryResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ActivateStoryResponse> ActivateStory(long tick, string storyId, bool playZBossExtraScene = false)
	{
		TaskCompletionSource<ActivateStoryResponse> tcs = new TaskCompletionSource<ActivateStoryResponse>();
		RPCConnection.QueueRequest(new ActivateStoryRequest
		{
			Tick = tick,
			StoryId = storyId,
			PlayZBossExtraScene = playZBossExtraScene
		}, delegate(RPCContext context)
		{
			try
			{
				ActivateStoryResponse result = context.Payload.As<ActivateStoryResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<DynamicIslandComeAgainExchangeResponse> DynamicIslandComeAgainExchange(long tick)
	{
		TaskCompletionSource<DynamicIslandComeAgainExchangeResponse> tcs = new TaskCompletionSource<DynamicIslandComeAgainExchangeResponse>();
		RPCConnection.QueueRequest(new DynamicIslandComeAgainExchangeRequest
		{
			Tick = tick
		}, delegate(RPCContext context)
		{
			try
			{
				DynamicIslandComeAgainExchangeResponse result = context.Payload.As<DynamicIslandComeAgainExchangeResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<PVPRankSeasonChooseZoneResponse> PVPRankSeasonChooseZone(long tick, int bigZoneId)
	{
		TaskCompletionSource<PVPRankSeasonChooseZoneResponse> tcs = new TaskCompletionSource<PVPRankSeasonChooseZoneResponse>();
		RPCConnection.QueueRequest(new PVPRankSeasonChooseZoneRequest
		{
			Tick = tick,
			BigZoneId = bigZoneId
		}, delegate(RPCContext context)
		{
			try
			{
				PVPRankSeasonChooseZoneResponse result = context.Payload.As<PVPRankSeasonChooseZoneResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetPvPTopTournamentFormationResponse> GetPvPTopTournamentFormation()
	{
		TaskCompletionSource<GetPvPTopTournamentFormationResponse> tcs = new TaskCompletionSource<GetPvPTopTournamentFormationResponse>();
		RPCConnection.QueueRequest(new GetPvPTopTournamentFormationRequest(), delegate(RPCContext context)
		{
			try
			{
				GetPvPTopTournamentFormationResponse result = context.Payload.As<GetPvPTopTournamentFormationResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetTreasureHuntBattlePresetFormationResponse> GetTreasureHuntBattlePresetFormation()
	{
		TaskCompletionSource<GetTreasureHuntBattlePresetFormationResponse> tcs = new TaskCompletionSource<GetTreasureHuntBattlePresetFormationResponse>();
		RPCConnection.QueueRequest(new GetTreasureHuntBattlePresetFormationRequest(), delegate(RPCContext context)
		{
			try
			{
				GetTreasureHuntBattlePresetFormationResponse result = context.Payload.As<GetTreasureHuntBattlePresetFormationResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SetPvPTopTournamentFormationResponse> SetPvPTopTournamentFormation(RankBattleTopTournamentConfig Formation, bool Weekend)
	{
		TaskCompletionSource<SetPvPTopTournamentFormationResponse> tcs = new TaskCompletionSource<SetPvPTopTournamentFormationResponse>();
		RPCConnection.QueueRequest(new SetPvPTopTournamentFormationRequest
		{
			Formation = Formation,
			Weekend = Weekend
		}, delegate(RPCContext context)
		{
			try
			{
				SetPvPTopTournamentFormationResponse result = context.Payload.As<SetPvPTopTournamentFormationResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SetTreasureHuntBattlePresetFormationResponse> SetTreasureHuntBattlePresetFormation(TreasureHuntBattleFormationConfig Formation)
	{
		TaskCompletionSource<SetTreasureHuntBattlePresetFormationResponse> tcs = new TaskCompletionSource<SetTreasureHuntBattlePresetFormationResponse>();
		RPCConnection.QueueRequest(new SetTreasureHuntBattlePresetFormationRequest
		{
			Formation = Formation
		}, delegate(RPCContext context)
		{
			try
			{
				SetTreasureHuntBattlePresetFormationResponse result = context.Payload.As<SetTreasureHuntBattlePresetFormationResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<PvPRankAddDefenseBuffResponse> AddDefenseBuff(int addTime)
	{
		TaskCompletionSource<PvPRankAddDefenseBuffResponse> tcs = new TaskCompletionSource<PvPRankAddDefenseBuffResponse>();
		RPCConnection.QueueRequest(new PvPRankAddDefenseBuffRequest
		{
			AddTime = addTime
		}, delegate(RPCContext context)
		{
			try
			{
				PvPRankAddDefenseBuffResponse result = context.Payload.As<PvPRankAddDefenseBuffResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<PvPRankClearCdResponse> ClearRankCd(int targetId)
	{
		TaskCompletionSource<PvPRankClearCdResponse> tcs = new TaskCompletionSource<PvPRankClearCdResponse>();
		RPCConnection.QueueRequest(new PvPRankClearCdRequest
		{
			TargetUserId = targetId
		}, delegate(RPCContext context)
		{
			try
			{
				PvPRankClearCdResponse result = context.Payload.As<PvPRankClearCdResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetCurrentPvPRankGameResponse> GetCurrentPvPRankGameInfo()
	{
		TaskCompletionSource<GetCurrentPvPRankGameResponse> tcs = new TaskCompletionSource<GetCurrentPvPRankGameResponse>();
		RPCConnection.QueueRequest(new GetCurrentPvPRankGameRequest(), delegate(RPCContext context)
		{
			try
			{
				GetCurrentPvPRankGameResponse result = context.Payload.As<GetCurrentPvPRankGameResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetRankListResponse> GetRankList()
	{
		TaskCompletionSource<GetRankListResponse> tcs = new TaskCompletionSource<GetRankListResponse>();
		RPCConnection.QueueRequest(new GetRankListRequest(), delegate(RPCContext context)
		{
			try
			{
				GetRankListResponse result = context.Payload.As<GetRankListResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<DrawCardResponse> DrawCard(string activityId, string drawOption, int costOption = 0)
	{
		TaskCompletionSource<DrawCardResponse> tcs = new TaskCompletionSource<DrawCardResponse>();
		RPCConnection.QueueRequest(new DrawCardRequest
		{
			ActivityId = activityId,
			DrawOption = drawOption,
			CostOption = costOption
		}, delegate(RPCContext context)
		{
			try
			{
				DrawCardResponse result = context.Payload.As<DrawCardResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<DrawDynamicCardPoolResponse> DrawCardFromDynamicPool(string activityId, string drawOption, int costOption = 0)
	{
		TaskCompletionSource<DrawDynamicCardPoolResponse> tcs = new TaskCompletionSource<DrawDynamicCardPoolResponse>();
		RPCConnection.QueueRequest(new DrawDynamicCardPoolRequest
		{
			ActivityId = activityId,
			DrawOption = drawOption,
			CostOption = costOption
		}, delegate(RPCContext context)
		{
			try
			{
				DrawDynamicCardPoolResponse result = context.Payload.As<DrawDynamicCardPoolResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetDrawCardCntResponse> GetDrawCardCnt(string activityId, string drawOption)
	{
		TaskCompletionSource<GetDrawCardCntResponse> tcs = new TaskCompletionSource<GetDrawCardCntResponse>();
		RPCConnection.QueueRequest(new GetDrawCardCntRequest
		{
			ActivityId = activityId,
			DrawOption = drawOption
		}, delegate(RPCContext context)
		{
			try
			{
				GetDrawCardCntResponse result = context.Payload.As<GetDrawCardCntResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<PlaceOrderResponse> PlaceOrder(string storeItemId, int priceIndex = -1)
	{
		TaskCompletionSource<PlaceOrderResponse> tcs = new TaskCompletionSource<PlaceOrderResponse>();
		RPCConnection.QueueRequest(new PlaceOrderRequest
		{
			StoreItemId = storeItemId,
			PriceIndex = priceIndex
		}, delegate(RPCContext context)
		{
			try
			{
				PlaceOrderResponse result = context.Payload.As<PlaceOrderResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<PendingLotteryResultClaimResponse> ClaimPendingLottery(List<int> chosenList)
	{
		TaskCompletionSource<PendingLotteryResultClaimResponse> tcs = new TaskCompletionSource<PendingLotteryResultClaimResponse>();
		RPCConnection.QueueRequest(new PendingLotteryResultClaimRequest
		{
			ChosenList = chosenList
		}, delegate(RPCContext context)
		{
			try
			{
				PendingLotteryResultClaimResponse result = context.Payload.As<PendingLotteryResultClaimResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ClaimVerifyIdentityBonusResponse> ClaimVerifyIdentityBonus()
	{
		TaskCompletionSource<ClaimVerifyIdentityBonusResponse> tcs = new TaskCompletionSource<ClaimVerifyIdentityBonusResponse>();
		RPCConnection.QueueRequest(new ClaimVerifyIdentityBonusRequest(), delegate(RPCContext context)
		{
			try
			{
				ClaimVerifyIdentityBonusResponse result = context.Payload.As<ClaimVerifyIdentityBonusResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<MainLevelRetreatResponse> MainLevelRetreat(string battleId)
	{
		TaskCompletionSource<MainLevelRetreatResponse> tcs = new TaskCompletionSource<MainLevelRetreatResponse>();
		RPCConnection.QueueRequest(new MainLevelRetreatRequest
		{
			BattleId = battleId
		}, delegate(RPCContext context)
		{
			try
			{
				MainLevelRetreatResponse result = context.Payload.As<MainLevelRetreatResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<MissionClaimResponse> MissionClaim(string missionId)
	{
		TaskCompletionSource<MissionClaimResponse> tcs = new TaskCompletionSource<MissionClaimResponse>();
		RPCConnection.QueueRequest(new MissionClaimRequest
		{
			MissionId = missionId
		}, delegate(RPCContext context)
		{
			try
			{
				MissionClaimResponse result = context.Payload.As<MissionClaimResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ActivityClaimResponse> ActivityClaim(string activityId)
	{
		TaskCompletionSource<ActivityClaimResponse> tcs = new TaskCompletionSource<ActivityClaimResponse>();
		RPCConnection.QueueRequest(new ActivityClaimRequest
		{
			ActivityId = activityId
		}, delegate(RPCContext context)
		{
			try
			{
				ActivityClaimResponse result = context.Payload.As<ActivityClaimResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ClaimDynamicCardPoolBonusResponse> DynamicActivityClaim(string activityId)
	{
		TaskCompletionSource<ClaimDynamicCardPoolBonusResponse> tcs = new TaskCompletionSource<ClaimDynamicCardPoolBonusResponse>();
		RPCConnection.QueueRequest(new ClaimDynamicCardPoolBonusRequest
		{
			ActivityId = activityId
		}, delegate(RPCContext context)
		{
			try
			{
				ClaimDynamicCardPoolBonusResponse result = context.Payload.As<ClaimDynamicCardPoolBonusResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ActivityResetResponse> ActivityReset(string activityId)
	{
		TaskCompletionSource<ActivityResetResponse> tcs = new TaskCompletionSource<ActivityResetResponse>();
		RPCConnection.QueueRequest(new ActivityResetRequest
		{
			ActivityId = activityId
		}, delegate(RPCContext context)
		{
			try
			{
				ActivityResetResponse result = context.Payload.As<ActivityResetResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ActivityReviewResponse> ActivitiesReview(List<string> activityIds)
	{
		TaskCompletionSource<ActivityReviewResponse> tcs = new TaskCompletionSource<ActivityReviewResponse>();
		RPCConnection.QueueRequest(new ActivityReviewRequest
		{
			ActivityIds = activityIds
		}, delegate(RPCContext context)
		{
			try
			{
				ActivityReviewResponse result = context.Payload.As<ActivityReviewResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<CheckActivitiesOverPeriodResponse> CheckActivitiesOverPeriod(List<string> activityIds, List<int> activityTypes)
	{
		TaskCompletionSource<CheckActivitiesOverPeriodResponse> tcs = new TaskCompletionSource<CheckActivitiesOverPeriodResponse>();
		RPCConnection.QueueRequest(new CheckActivitiesOverPeriodRequest
		{
			ActivityIds = activityIds,
			ActivityTypes = activityTypes
		}, delegate(RPCContext context)
		{
			try
			{
				CheckActivitiesOverPeriodResponse result = context.Payload.As<CheckActivitiesOverPeriodResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<CheckActivitiesAutoFillResponse> CheckActivitiesAutoFill(string activityId = null)
	{
		TaskCompletionSource<CheckActivitiesAutoFillResponse> tcs = new TaskCompletionSource<CheckActivitiesAutoFillResponse>();
		RPCConnection.QueueRequest(new CheckActivitiesAutoFillRequest
		{
			ActivityId = activityId,
			Timestamp = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds
		}, delegate(RPCContext context)
		{
			try
			{
				CheckActivitiesAutoFillResponse result = context.Payload.As<CheckActivitiesAutoFillResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<AchievementClaimResponse> AchievementClaim(string achievementId)
	{
		TaskCompletionSource<AchievementClaimResponse> tcs = new TaskCompletionSource<AchievementClaimResponse>();
		RPCConnection.QueueRequest(new AchievementClaimRequest
		{
			AchievementId = achievementId
		}, delegate(RPCContext context)
		{
			try
			{
				AchievementClaimResponse result = context.Payload.As<AchievementClaimResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SignInClaimResponse> SignInClaim(string activityId, int dayTarget)
	{
		TaskCompletionSource<SignInClaimResponse> tcs = new TaskCompletionSource<SignInClaimResponse>();
		RPCConnection.QueueRequest(new SignInClaimRequest
		{
			ActivityId = activityId,
			DayTarget = dayTarget
		}, delegate(RPCContext context)
		{
			try
			{
				SignInClaimResponse result = context.Payload.As<SignInClaimResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<LeaseholdDailyBonusClaimResponse> ClaimLeaseholdDailyBonus(string leaseholdItemId)
	{
		TaskCompletionSource<LeaseholdDailyBonusClaimResponse> tcs = new TaskCompletionSource<LeaseholdDailyBonusClaimResponse>();
		RPCConnection.QueueRequest(new LeaseholdDailyBonusClaimRequest
		{
			LeaseholdItemId = leaseholdItemId
		}, delegate(RPCContext context)
		{
			try
			{
				LeaseholdDailyBonusClaimResponse result = context.Payload.As<LeaseholdDailyBonusClaimResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetStoreActivityItemsResponse> GetStoreActivityItems(string activityId, string pageName)
	{
		TaskCompletionSource<GetStoreActivityItemsResponse> tcs = new TaskCompletionSource<GetStoreActivityItemsResponse>();
		RPCConnection.QueueRequest(new GetStoreActivityItemsRequest
		{
			ActivityId = activityId,
			PageName = pageName
		}, delegate(RPCContext context)
		{
			try
			{
				GetStoreActivityItemsResponse result = context.Payload.As<GetStoreActivityItemsResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetShadowDemonActivityResponse> GetShadowDemonActivity(string activityId)
	{
		TaskCompletionSource<GetShadowDemonActivityResponse> tcs = new TaskCompletionSource<GetShadowDemonActivityResponse>();
		RPCConnection.QueueRequest(new GetShadowDemonActivityRequest
		{
			ActivityId = activityId
		}, delegate(RPCContext context)
		{
			try
			{
				GetShadowDemonActivityResponse result = context.Payload.As<GetShadowDemonActivityResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetMissionActivityStoreItemsResponse> GetMissionActivityStoreItems(string activityId, string pageName)
	{
		TaskCompletionSource<GetMissionActivityStoreItemsResponse> tcs = new TaskCompletionSource<GetMissionActivityStoreItemsResponse>();
		RPCConnection.QueueRequest(new GetMissionActivityStoreItemsRequest
		{
			ActivityId = activityId,
			PageName = pageName
		}, delegate(RPCContext context)
		{
			try
			{
				GetMissionActivityStoreItemsResponse result = context.Payload.As<GetMissionActivityStoreItemsResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<UnlockRegionResponse> UnlockRegion(long tick, string regionId)
	{
		TaskCompletionSource<UnlockRegionResponse> tcs = new TaskCompletionSource<UnlockRegionResponse>();
		RPCConnection.QueueRequest(new UnlockRegionRequest
		{
			Tick = tick,
			RegionId = regionId
		}, delegate(RPCContext context)
		{
			try
			{
				UnlockRegionResponse result = context.Payload.As<UnlockRegionResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<UpdateSoldierMythResponse> UpdateSoldierMyth(string soldierId, int level)
	{
		TaskCompletionSource<UpdateSoldierMythResponse> tcs = new TaskCompletionSource<UpdateSoldierMythResponse>();
		RPCConnection.QueueRequest(new UpdateSoldierMythRequest
		{
			SoldierId = soldierId,
			Level = level
		}, delegate(RPCContext context)
		{
			try
			{
				UpdateSoldierMythResponse result = context.Payload.As<UpdateSoldierMythResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<UpdateGVGStoreLimitedFormulasResponse> GetGVGStoreLimitedFormulas()
	{
		TaskCompletionSource<UpdateGVGStoreLimitedFormulasResponse> tcs = new TaskCompletionSource<UpdateGVGStoreLimitedFormulasResponse>();
		RPCConnection.QueueRequest(new UpdateGVGStoreLimitedFormulasRequest(), delegate(RPCContext context)
		{
			try
			{
				UpdateGVGStoreLimitedFormulasResponse result = context.Payload.As<UpdateGVGStoreLimitedFormulasResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<UseGVGStoreFormulaResponse> UseGVGStoreFormula(string formulaId, int inputIndex = 0, int outputIndex = 0, int storeItemIndex = 0)
	{
		TaskCompletionSource<UseGVGStoreFormulaResponse> tcs = new TaskCompletionSource<UseGVGStoreFormulaResponse>();
		RPCConnection.QueueRequest(new UseGVGStoreFormulaRequest
		{
			FormulaId = formulaId,
			InputIndex = inputIndex,
			OutputIndex = outputIndex,
			StoreItemIndex = storeItemIndex
		}, delegate(RPCContext context)
		{
			try
			{
				UseGVGStoreFormulaResponse result = context.Payload.As<UseGVGStoreFormulaResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetGvGStoreroomStockLimitResponse> GetGvGStoreroomStockLimit(bool isLevelUp = false)
	{
		TaskCompletionSource<GetGvGStoreroomStockLimitResponse> tcs = new TaskCompletionSource<GetGvGStoreroomStockLimitResponse>();
		RPCConnection.QueueRequest(new GetGvGStoreroomStockLimitRequest
		{
			IsEvo = isLevelUp
		}, delegate(RPCContext context)
		{
			try
			{
				GetGvGStoreroomStockLimitResponse result = context.Payload.As<GetGvGStoreroomStockLimitResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetGvGStoreItemsResponse> GetGvGStoreItems(bool manual = false)
	{
		TaskCompletionSource<GetGvGStoreItemsResponse> tcs = new TaskCompletionSource<GetGvGStoreItemsResponse>();
		RPCConnection.QueueRequest(new GetGvGStoreItemsRequest
		{
			Manual = manual
		}, delegate(RPCContext context)
		{
			try
			{
				GetGvGStoreItemsResponse result = context.Payload.As<GetGvGStoreItemsResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetGvGStoreInfoResponse> GetGvGStoreInfo()
	{
		TaskCompletionSource<GetGvGStoreInfoResponse> tcs = new TaskCompletionSource<GetGvGStoreInfoResponse>();
		RPCConnection.QueueRequest(new GetGvGStoreInfoRequest(), delegate(RPCContext context)
		{
			try
			{
				GetGvGStoreInfoResponse result = context.Payload.As<GetGvGStoreInfoResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetGvGStoreGuaranteedItemsResponse> GetGvGStoreGuaranteedItems()
	{
		TaskCompletionSource<GetGvGStoreGuaranteedItemsResponse> tcs = new TaskCompletionSource<GetGvGStoreGuaranteedItemsResponse>();
		RPCConnection.QueueRequest(new GetGvGStoreGuaranteedItemsRequest(), delegate(RPCContext context)
		{
			try
			{
				GetGvGStoreGuaranteedItemsResponse result = context.Payload.As<GetGvGStoreGuaranteedItemsResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ExchangeGvGStoreGuaranteedTicketResponse> ExchangeGvGStoreGuaranteedTicket()
	{
		TaskCompletionSource<ExchangeGvGStoreGuaranteedTicketResponse> tcs = new TaskCompletionSource<ExchangeGvGStoreGuaranteedTicketResponse>();
		RPCConnection.QueueRequest(new ExchangeGvGStoreGuaranteedTicketRequest(), delegate(RPCContext context)
		{
			try
			{
				ExchangeGvGStoreGuaranteedTicketResponse result = context.Payload.As<ExchangeGvGStoreGuaranteedTicketResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<OpenSoldierMythResponse> OpenSoldierMyth(string soldierId)
	{
		TaskCompletionSource<OpenSoldierMythResponse> tcs = new TaskCompletionSource<OpenSoldierMythResponse>();
		RPCConnection.QueueRequest(new OpenSoldierMythRequest
		{
			SoldierId = soldierId
		}, delegate(RPCContext context)
		{
			try
			{
				OpenSoldierMythResponse result = context.Payload.As<OpenSoldierMythResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<CheckLegendItemSlotResponse> CheckLegendItemSlot(List<string> soldierId)
	{
		TaskCompletionSource<CheckLegendItemSlotResponse> tcs = new TaskCompletionSource<CheckLegendItemSlotResponse>();
		RPCConnection.QueueRequest(new CheckLegendItemSlotRequest
		{
			SoldierId = soldierId
		}, delegate(RPCContext context)
		{
			try
			{
				CheckLegendItemSlotResponse result = context.Payload.As<CheckLegendItemSlotResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<UnlockFormationResponse> UnlockFormation(long tick, string formationId)
	{
		TaskCompletionSource<UnlockFormationResponse> tcs = new TaskCompletionSource<UnlockFormationResponse>();
		RPCConnection.QueueRequest(new UnlockFormationRequest
		{
			Tick = tick,
			FormationId = formationId
		}, delegate(RPCContext context)
		{
			try
			{
				UnlockFormationResponse result = context.Payload.As<UnlockFormationResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<UseItemResponse> UseItem(long tick, string itemId, int qty, object useItemContext = null)
	{
		TaskCompletionSource<UseItemResponse> tcs = new TaskCompletionSource<UseItemResponse>();
		RPCConnection.QueueRequest(new UseItemRequest
		{
			Tick = tick,
			ItemId = itemId,
			Qty = qty,
			Context = useItemContext
		}, delegate(RPCContext context)
		{
			try
			{
				UseItemResponse result = context.Payload.As<UseItemResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<UpgradeItemResponse> UpgradeItem(long tick, string itemId)
	{
		TaskCompletionSource<UpgradeItemResponse> tcs = new TaskCompletionSource<UpgradeItemResponse>();
		RPCConnection.QueueRequest(new UpgradeItemRequest
		{
			Tick = tick,
			ItemId = itemId
		}, delegate(RPCContext context)
		{
			try
			{
				UpgradeItemResponse result = context.Payload.As<UpgradeItemResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<PiecesCompositeResponse> PiecesComposite(long tick, string itemId, int qty)
	{
		TaskCompletionSource<PiecesCompositeResponse> tcs = new TaskCompletionSource<PiecesCompositeResponse>();
		RPCConnection.QueueRequest(new PiecesCompositeRequest
		{
			Tick = tick,
			ItemId = itemId,
			Qty = qty
		}, delegate(RPCContext context)
		{
			try
			{
				PiecesCompositeResponse result = context.Payload.As<PiecesCompositeResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SoulStoneMaxCompositeToResponse> SoulStoneMaxCompositeTo(long tick, string soldierId, int targetPotentialLevel)
	{
		TaskCompletionSource<SoulStoneMaxCompositeToResponse> tcs = new TaskCompletionSource<SoulStoneMaxCompositeToResponse>();
		RPCConnection.QueueRequest(new SoulStoneMaxCompositeToRequest
		{
			Tick = tick,
			SoldierId = soldierId,
			TargetPotentialLevel = targetPotentialLevel
		}, delegate(RPCContext context)
		{
			try
			{
				SoulStoneMaxCompositeToResponse result = context.Payload.As<SoulStoneMaxCompositeToResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SoldierEvoluteResponse> SoldierEvolute(long tick, string soldierId)
	{
		TaskCompletionSource<SoldierEvoluteResponse> tcs = new TaskCompletionSource<SoldierEvoluteResponse>();
		RPCConnection.QueueRequest(new SoldierEvoluteRequest
		{
			Tick = tick,
			SoldierId = soldierId
		}, delegate(RPCContext context)
		{
			try
			{
				SoldierEvoluteResponse result = context.Payload.As<SoldierEvoluteResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SoldierPotentialBreakthroughResponse> SoldierPotentialBreakthrough(long tick, string soldierId)
	{
		TaskCompletionSource<SoldierPotentialBreakthroughResponse> tcs = new TaskCompletionSource<SoldierPotentialBreakthroughResponse>();
		RPCConnection.QueueRequest(new SoldierPotentialBreakthroughRequest
		{
			Tick = tick,
			SoldierId = soldierId
		}, delegate(RPCContext context)
		{
			try
			{
				SoldierPotentialBreakthroughResponse result = context.Payload.As<SoldierPotentialBreakthroughResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SoldierAddPotentialProgressResponse> SoldierAddPotentialProgress(long tick, string soldierId, int position, int num)
	{
		TaskCompletionSource<SoldierAddPotentialProgressResponse> tcs = new TaskCompletionSource<SoldierAddPotentialProgressResponse>();
		RPCConnection.QueueRequest(new SoldierAddPotentialProgressRequest
		{
			Tick = tick,
			SoldierId = soldierId,
			Position = position,
			Num = num
		}, delegate(RPCContext context)
		{
			try
			{
				SoldierAddPotentialProgressResponse result = context.Payload.As<SoldierAddPotentialProgressResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<UpgradeTechnologyResponse> UpgradeTechnology(long tick, string techId)
	{
		TaskCompletionSource<UpgradeTechnologyResponse> tcs = new TaskCompletionSource<UpgradeTechnologyResponse>();
		RPCConnection.QueueRequest(new UpgradeTechnologyRequest
		{
			Tick = tick,
			TechId = techId
		}, delegate(RPCContext context)
		{
			try
			{
				UpgradeTechnologyResponse result = context.Payload.As<UpgradeTechnologyResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ResetTechnologyResponse> ResetTechnology(long tick)
	{
		TaskCompletionSource<ResetTechnologyResponse> tcs = new TaskCompletionSource<ResetTechnologyResponse>();
		RPCConnection.QueueRequest(new ResetTechnologyRequest
		{
			Tick = tick
		}, delegate(RPCContext context)
		{
			try
			{
				ResetTechnologyResponse result = context.Payload.As<ResetTechnologyResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SyncProduceResponse> SyncProduce(long tick, bool getAllProduceStates = false)
	{
		TaskCompletionSource<SyncProduceResponse> tcs = new TaskCompletionSource<SyncProduceResponse>();
		RPCConnection.QueueRequest(new SyncProduceRequest
		{
			Tick = tick,
			GetAllProduceStates = getAllProduceStates
		}, delegate(RPCContext context)
		{
			try
			{
				SyncProduceResponse result = context.Payload.As<SyncProduceResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SyncStockResponse> SyncStock(long tick, bool syncAllStock = false, List<string> itemIds = null)
	{
		TaskCompletionSource<SyncStockResponse> tcs = new TaskCompletionSource<SyncStockResponse>();
		RPCConnection.QueueRequest(new SyncStockRequest
		{
			Tick = tick,
			SyncAllStock = syncAllStock,
			ItemIds = itemIds
		}, delegate(RPCContext context)
		{
			try
			{
				SyncStockResponse result = context.Payload.As<SyncStockResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SyncWeeklyMissionScoreResponse> SyncWeeklyMissionScore()
	{
		TaskCompletionSource<SyncWeeklyMissionScoreResponse> tcs = new TaskCompletionSource<SyncWeeklyMissionScoreResponse>();
		RPCConnection.QueueRequest(new SyncWeeklyMissionScoreRequest(), delegate(RPCContext context)
		{
			try
			{
				SyncWeeklyMissionScoreResponse result = context.Payload.As<SyncWeeklyMissionScoreResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetOfflineYieldBonusResponse> GetOfflineYieldBonuses()
	{
		TaskCompletionSource<GetOfflineYieldBonusResponse> tcs = new TaskCompletionSource<GetOfflineYieldBonusResponse>();
		RPCConnection.QueueRequest(new GetOfflineYieldBonusRequest(), delegate(RPCContext context)
		{
			try
			{
				GetOfflineYieldBonusResponse result = context.Payload.As<GetOfflineYieldBonusResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetRecycleProductsResponse> GetRecycleProducts(int userId)
	{
		TaskCompletionSource<GetRecycleProductsResponse> tcs = new TaskCompletionSource<GetRecycleProductsResponse>();
		RPCConnection.QueueRequest(new GetRecycleProductsRequest
		{
			UserId = userId
		}, delegate(RPCContext context)
		{
			try
			{
				GetRecycleProductsResponse result = context.Payload.As<GetRecycleProductsResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<RecycleExportToResponse> RecycleExportTo(int userId)
	{
		TaskCompletionSource<RecycleExportToResponse> tcs = new TaskCompletionSource<RecycleExportToResponse>();
		RPCConnection.QueueRequest(new RecycleExportToRequest
		{
			TargetUserId = userId
		}, delegate(RPCContext context)
		{
			try
			{
				RecycleExportToResponse result = context.Payload.As<RecycleExportToResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetFriendsCanExportRecycleResponse> GetFriendsCanExportRecycle()
	{
		TaskCompletionSource<GetFriendsCanExportRecycleResponse> tcs = new TaskCompletionSource<GetFriendsCanExportRecycleResponse>();
		RPCConnection.QueueRequest(new GetFriendsCanExportRecycleRequest(), delegate(RPCContext context)
		{
			try
			{
				GetFriendsCanExportRecycleResponse result = context.Payload.As<GetFriendsCanExportRecycleResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetRecycleStatsResponse> GetRecycleStats(int userId)
	{
		TaskCompletionSource<GetRecycleStatsResponse> tcs = new TaskCompletionSource<GetRecycleStatsResponse>();
		RPCConnection.QueueRequest(new GetRecycleStatsRequest
		{
			TargetUserId = userId
		}, delegate(RPCContext context)
		{
			try
			{
				GetRecycleStatsResponse result = context.Payload.As<GetRecycleStatsResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SwitchRecycleMultiplayerEnableResponse> SwitchRecycleMultiplayerEnable(bool enable)
	{
		TaskCompletionSource<SwitchRecycleMultiplayerEnableResponse> tcs = new TaskCompletionSource<SwitchRecycleMultiplayerEnableResponse>();
		RPCConnection.QueueRequest(new SwitchRecycleMultiplayerEnableRequest
		{
			Enable = enable
		}, delegate(RPCContext context)
		{
			try
			{
				SwitchRecycleMultiplayerEnableResponse result = context.Payload.As<SwitchRecycleMultiplayerEnableResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetSelfRecycleStatsResponse> GetSelfRecycleStats()
	{
		TaskCompletionSource<GetSelfRecycleStatsResponse> tcs = new TaskCompletionSource<GetSelfRecycleStatsResponse>();
		RPCConnection.QueueRequest(new GetSelfRecycleStatsRequest(), delegate(RPCContext context)
		{
			try
			{
				GetSelfRecycleStatsResponse result = context.Payload.As<GetSelfRecycleStatsResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetRecycleRebateResponse> GetRecycleRebate()
	{
		TaskCompletionSource<GetRecycleRebateResponse> tcs = new TaskCompletionSource<GetRecycleRebateResponse>();
		RPCConnection.QueueRequest(new GetRecycleRebateRequest(), delegate(RPCContext context)
		{
			try
			{
				GetRecycleRebateResponse result = context.Payload.As<GetRecycleRebateResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ClaimRecycleRebateResponse> ClaimRecycleRebate(int qty)
	{
		TaskCompletionSource<ClaimRecycleRebateResponse> tcs = new TaskCompletionSource<ClaimRecycleRebateResponse>();
		RPCConnection.QueueRequest(new ClaimRecycleRebateRequest
		{
			ClaimQty = qty
		}, delegate(RPCContext context)
		{
			try
			{
				ClaimRecycleRebateResponse result = context.Payload.As<ClaimRecycleRebateResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetTotalRecycleExportRequestResponse> GetTotalRecycleExportRequest()
	{
		TaskCompletionSource<GetTotalRecycleExportRequestResponse> tcs = new TaskCompletionSource<GetTotalRecycleExportRequestResponse>();
		RPCConnection.QueueRequest(new GetTotalRecycleExportRequestRequest(), delegate(RPCContext context)
		{
			try
			{
				GetTotalRecycleExportRequestResponse result = context.Payload.As<GetTotalRecycleExportRequestResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GiftRedeemPreviewResponse> GiftRedeemPreview(string redeemCode)
	{
		TaskCompletionSource<GiftRedeemPreviewResponse> tcs = new TaskCompletionSource<GiftRedeemPreviewResponse>();
		RPCConnection.QueueRequest(new GiftRedeemPreviewRequest
		{
			RedeemCode = redeemCode
		}, delegate(RPCContext context)
		{
			try
			{
				GiftRedeemPreviewResponse result = context.Payload.As<GiftRedeemPreviewResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GiftRedeemClaimResponse> GiftRedeemClaim(string redeemCode)
	{
		TaskCompletionSource<GiftRedeemClaimResponse> tcs = new TaskCompletionSource<GiftRedeemClaimResponse>();
		RPCConnection.QueueRequest(new GiftRedeemClaimRequest
		{
			RedeemCode = redeemCode
		}, delegate(RPCContext context)
		{
			try
			{
				GiftRedeemClaimResponse result = context.Payload.As<GiftRedeemClaimResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SetInvitedFromResponse> SetInvitedFrom(string invitingCode)
	{
		TaskCompletionSource<SetInvitedFromResponse> tcs = new TaskCompletionSource<SetInvitedFromResponse>();
		RPCConnection.QueueRequest(new SetInvitedFromRequest
		{
			InvitingCode = invitingCode
		}, delegate(RPCContext context)
		{
			try
			{
				SetInvitedFromResponse result = context.Payload.As<SetInvitedFromResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<AssignInvitedWorkerResponse> AssignInvitedWorker(int slotIndex, int workerUserId, string buildingType, int workbenchIndex)
	{
		TaskCompletionSource<AssignInvitedWorkerResponse> tcs = new TaskCompletionSource<AssignInvitedWorkerResponse>();
		RPCConnection.QueueRequest(new AssignInvitedWorkerRequest
		{
			SlotIndex = slotIndex,
			WorkerUserId = workerUserId,
			BuildingType = buildingType,
			WorkbenchIndex = workbenchIndex
		}, delegate(RPCContext context)
		{
			try
			{
				AssignInvitedWorkerResponse result = context.Payload.As<AssignInvitedWorkerResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ActivateInvitedWorkerResponse> ActivateInvitedWorker(int workerUserId)
	{
		TaskCompletionSource<ActivateInvitedWorkerResponse> tcs = new TaskCompletionSource<ActivateInvitedWorkerResponse>();
		RPCConnection.QueueRequest(new ActivateInvitedWorkerRequest
		{
			WorkerUserId = workerUserId
		}, delegate(RPCContext context)
		{
			try
			{
				ActivateInvitedWorkerResponse result = context.Payload.As<ActivateInvitedWorkerResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ChangeInvitingSlotsConfigResponse> ChangeInvitingSlotsConfig(Dictionary<int, Tuple<int, string, int>> invitingSlotsConfig)
	{
		TaskCompletionSource<ChangeInvitingSlotsConfigResponse> tcs = new TaskCompletionSource<ChangeInvitingSlotsConfigResponse>();
		RPCConnection.QueueRequest(new ChangeInvitingSlotsConfigRequest
		{
			InvitingSlotsConfig = invitingSlotsConfig
		}, delegate(RPCContext context)
		{
			try
			{
				ChangeInvitingSlotsConfigResponse result = context.Payload.As<ChangeInvitingSlotsConfigResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetInvitedWorkersResponse> GetInvitedWorkers()
	{
		TaskCompletionSource<GetInvitedWorkersResponse> tcs = new TaskCompletionSource<GetInvitedWorkersResponse>();
		RPCConnection.QueueRequest(new GetInvitedWorkersRequest(), delegate(RPCContext context)
		{
			try
			{
				GetInvitedWorkersResponse result = context.Payload.As<GetInvitedWorkersResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ReviewInvitedWorkersResponse> ReviewInvitedWorkers()
	{
		TaskCompletionSource<ReviewInvitedWorkersResponse> tcs = new TaskCompletionSource<ReviewInvitedWorkersResponse>();
		RPCConnection.QueueRequest(new ReviewInvitedWorkersRequest(), delegate(RPCContext context)
		{
			try
			{
				ReviewInvitedWorkersResponse result = context.Payload.As<ReviewInvitedWorkersResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<AddFriendResponse> AddFriend(int friendId)
	{
		TaskCompletionSource<AddFriendResponse> tcs = new TaskCompletionSource<AddFriendResponse>();
		RPCConnection.QueueRequest(new AddFriendRequest
		{
			FriendId = friendId
		}, delegate(RPCContext context)
		{
			try
			{
				AddFriendResponse result = context.Payload.As<AddFriendResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<DeleteFriendResponse> DeleteFriend(int friendId)
	{
		TaskCompletionSource<DeleteFriendResponse> tcs = new TaskCompletionSource<DeleteFriendResponse>();
		RPCConnection.QueueRequest(new DeleteFriendRequest
		{
			FriendId = friendId
		}, delegate(RPCContext context)
		{
			try
			{
				DeleteFriendResponse result = context.Payload.As<DeleteFriendResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetFriendsResponse> GetFriends(bool getNew)
	{
		TaskCompletionSource<GetFriendsResponse> tcs = new TaskCompletionSource<GetFriendsResponse>();
		RPCConnection.QueueRequest(new GetFriendsRequest
		{
			GetNew = getNew
		}, delegate(RPCContext context)
		{
			try
			{
				GetFriendsResponse result = context.Payload.As<GetFriendsResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SendChatResponse> SendFriendsChat(int friendId, string contents)
	{
		TaskCompletionSource<SendChatResponse> tcs = new TaskCompletionSource<SendChatResponse>();
		SendChatRequest message = new SendChatRequest
		{
			Receiver = friendId,
			MsgType = 1,
			Content = contents
		};
		RPCConnection.QueueRequest(message, delegate(RPCContext context)
		{
			try
			{
				SendChatResponse result = context.Payload.As<SendChatResponse>();
				tcs.SetResult(result);
			}
			catch (Exception ex)
			{
				ILRuntimeDebug.LogError(ex.Message);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ReadMessageResponse> ReadFriendsChat(int friendId)
	{
		TaskCompletionSource<ReadMessageResponse> tcs = new TaskCompletionSource<ReadMessageResponse>();
		RPCConnection.QueueRequest(new ReadMessageRequest
		{
			FriendId = friendId,
			Timestamp = DateTimeHelper.Now_Milliseconds
		}, delegate(RPCContext context)
		{
			try
			{
				ReadMessageResponse result = context.Payload.As<ReadMessageResponse>();
				tcs.SetResult(result);
			}
			catch (Exception ex)
			{
				ILRuntimeDebug.LogError(ex.Message);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetUnreadMessageResponse> GetUnreadFriendsChat()
	{
		TaskCompletionSource<GetUnreadMessageResponse> tcs = new TaskCompletionSource<GetUnreadMessageResponse>();
		RPCConnection.QueueRequest(new GetUnreadMessageRequest(), delegate(RPCContext context)
		{
			try
			{
				GetUnreadMessageResponse result = context.Payload.As<GetUnreadMessageResponse>();
				tcs.SetResult(result);
			}
			catch (Exception ex)
			{
				ILRuntimeDebug.LogError(ex.Message);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetFriendsApplyInfoResponse> GetFriendsApplyInfo()
	{
		TaskCompletionSource<GetFriendsApplyInfoResponse> tcs = new TaskCompletionSource<GetFriendsApplyInfoResponse>();
		RPCConnection.QueueRequest(new GetFriendsApplyInfoRequest(), delegate(RPCContext context)
		{
			try
			{
				GetFriendsApplyInfoResponse result = context.Payload.As<GetFriendsApplyInfoResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SendFriendsApplyResponse> SendFriendsApply(string invitingCode)
	{
		TaskCompletionSource<SendFriendsApplyResponse> tcs = new TaskCompletionSource<SendFriendsApplyResponse>();
		RPCConnection.QueueRequest(new SendFriendsApplyRequest
		{
			InvitingCode = invitingCode
		}, delegate(RPCContext context)
		{
			try
			{
				SendFriendsApplyResponse result = context.Payload.As<SendFriendsApplyResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ModifyFriendsApplyResponse> ModifyFriendsApply(int requestId, bool isAgree)
	{
		TaskCompletionSource<ModifyFriendsApplyResponse> tcs = new TaskCompletionSource<ModifyFriendsApplyResponse>();
		RPCConnection.QueueRequest(new ModifyFriendsApplyRequest
		{
			Id = requestId,
			Agree = isAgree
		}, delegate(RPCContext context)
		{
			try
			{
				ModifyFriendsApplyResponse result = context.Payload.As<ModifyFriendsApplyResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<BattlePassActivityClaimResponse> BattlePassActivityClaim(string activity, string level)
	{
		TaskCompletionSource<BattlePassActivityClaimResponse> tcs = new TaskCompletionSource<BattlePassActivityClaimResponse>();
		RPCConnection.QueueRequest(new BattlePassActivityClaimRequest
		{
			ActivityId = activity,
			node = level
		}, delegate(RPCContext context)
		{
			try
			{
				BattlePassActivityClaimResponse result = context.Payload.As<BattlePassActivityClaimResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<BindMobileResponse> BindMobile(string mobile)
	{
		TaskCompletionSource<BindMobileResponse> tcs = new TaskCompletionSource<BindMobileResponse>();
		RPCConnection.QueueRequest(new BindMobileRequest
		{
			Mobile = mobile
		}, delegate(RPCContext context)
		{
			try
			{
				BindMobileResponse result = context.Payload.As<BindMobileResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<BindMobileVerifyResponse> BindMobileVerify(string mobile, string code)
	{
		TaskCompletionSource<BindMobileVerifyResponse> tcs = new TaskCompletionSource<BindMobileVerifyResponse>();
		RPCConnection.QueueRequest(new BindMobileVerifyRequest
		{
			Mobile = mobile,
			Code = code
		}, delegate(RPCContext context)
		{
			try
			{
				BindMobileVerifyResponse result = context.Payload.As<BindMobileVerifyResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ResetArchiveResponse> ResetArchive()
	{
		TaskCompletionSource<ResetArchiveResponse> tcs = new TaskCompletionSource<ResetArchiveResponse>();
		RPCConnection.QueueRequest(new ResetArchiveRequest(), delegate(RPCContext context)
		{
			try
			{
				ResetArchiveResponse result = context.Payload.As<ResetArchiveResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ConfirmResetArchiveResponse> ConfirmResetArchive(string token)
	{
		TaskCompletionSource<ConfirmResetArchiveResponse> tcs = new TaskCompletionSource<ConfirmResetArchiveResponse>();
		RPCConnection.QueueRequest(new ConfirmResetArchiveRequest
		{
			ResetToken = token
		}, delegate(RPCContext context)
		{
			try
			{
				ConfirmResetArchiveResponse result = context.Payload.As<ConfirmResetArchiveResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<LegendItemAllResponse> LegendItemAll()
	{
		TaskCompletionSource<LegendItemAllResponse> tcs = new TaskCompletionSource<LegendItemAllResponse>();
		RPCConnection.QueueRequest(new LegendItemAllRequest(), delegate(RPCContext context)
		{
			try
			{
				LegendItemAllResponse result = context.Payload.As<LegendItemAllResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SelfSelectionBluePrintResponse> SelfSelectionBluePrintUse(string itemId, string mainItemPool, string fxPool, string setAliasPool)
	{
		TaskCompletionSource<SelfSelectionBluePrintResponse> tcs = new TaskCompletionSource<SelfSelectionBluePrintResponse>();
		RPCConnection.QueueRequest(new SelfSelectionBluePrintRequest
		{
			ItemId = itemId,
			Main = mainItemPool,
			NewFxEntry = fxPool,
			SetAliaPool = setAliasPool
		}, delegate(RPCContext context)
		{
			try
			{
				SelfSelectionBluePrintResponse result = context.Payload.As<SelfSelectionBluePrintResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SpecialSelectionBluePrintConfigResponse> GetSpecialSelectionBluePrintConfig()
	{
		TaskCompletionSource<SpecialSelectionBluePrintConfigResponse> tcs = new TaskCompletionSource<SpecialSelectionBluePrintConfigResponse>();
		RPCConnection.QueueRequest(new SpecialSelectionBluePrintConfigRequest(), delegate(RPCContext context)
		{
			try
			{
				SpecialSelectionBluePrintConfigResponse result = context.Payload.As<SpecialSelectionBluePrintConfigResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SpecialSelectionBluePrintResponse> SpecialSelectionBluePrintUse(int sbpIndex, string mainItemPool, string fxPool, string setAliasPool)
	{
		TaskCompletionSource<SpecialSelectionBluePrintResponse> tcs = new TaskCompletionSource<SpecialSelectionBluePrintResponse>();
		RPCConnection.QueueRequest(new SpecialSelectionBluePrintRequest
		{
			Main = mainItemPool,
			NewFxEntry = fxPool,
			SetAliaPool = setAliasPool,
			Index = sbpIndex
		}, delegate(RPCContext context)
		{
			try
			{
				SpecialSelectionBluePrintResponse result = context.Payload.As<SpecialSelectionBluePrintResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SoldierEquippedItemsAllResponse> SoldierEquippedItemsAll()
	{
		TaskCompletionSource<SoldierEquippedItemsAllResponse> tcs = new TaskCompletionSource<SoldierEquippedItemsAllResponse>();
		RPCConnection.QueueRequest(new SoldierEquippedItemsAllRequest(), delegate(RPCContext context)
		{
			try
			{
				SoldierEquippedItemsAllResponse result = context.Payload.As<SoldierEquippedItemsAllResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SoldierWearLegendItemResponse> SoldierWearLegendItem(string soldierId, int slotId, long instanceId)
	{
		TaskCompletionSource<SoldierWearLegendItemResponse> tcs = new TaskCompletionSource<SoldierWearLegendItemResponse>();
		RPCConnection.QueueRequest(new SoldierWearLegendItemRequest
		{
			SoldierId = soldierId,
			SlotId = slotId,
			InstanceId = instanceId
		}, delegate(RPCContext context)
		{
			try
			{
				SoldierWearLegendItemResponse result = context.Payload.As<SoldierWearLegendItemResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SoldierTakeOffLegendItemResponse> SoldierTakeOffLegendItem(string soldierId, int slotId)
	{
		TaskCompletionSource<SoldierTakeOffLegendItemResponse> tcs = new TaskCompletionSource<SoldierTakeOffLegendItemResponse>();
		RPCConnection.QueueRequest(new SoldierTakeOffLegendItemRequest
		{
			SoldierId = soldierId,
			SlotId = slotId
		}, delegate(RPCContext context)
		{
			try
			{
				SoldierTakeOffLegendItemResponse result = context.Payload.As<SoldierTakeOffLegendItemResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SoldierItemSlotAllResponse> SoldierItemSlotAll()
	{
		TaskCompletionSource<SoldierItemSlotAllResponse> tcs = new TaskCompletionSource<SoldierItemSlotAllResponse>();
		RPCConnection.QueueRequest(new SoldierItemSlotAllRequest(), delegate(RPCContext context)
		{
			try
			{
				SoldierItemSlotAllResponse result = context.Payload.As<SoldierItemSlotAllResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SoldierItemSlotUnlockResponse> SoldierItemSlotUnlock(string soldierId, int slotId)
	{
		TaskCompletionSource<SoldierItemSlotUnlockResponse> tcs = new TaskCompletionSource<SoldierItemSlotUnlockResponse>();
		RPCConnection.QueueRequest(new SoldierItemSlotUnlockRequest
		{
			SoldierId = soldierId,
			SlotId = slotId
		}, delegate(RPCContext context)
		{
			try
			{
				SoldierItemSlotUnlockResponse result = context.Payload.As<SoldierItemSlotUnlockResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<LegendItemEnhancementEnhanceResponse> EnhanceLegendItem(long enhanceTargetId, List<long> foodIds)
	{
		TaskCompletionSource<LegendItemEnhancementEnhanceResponse> tcs = new TaskCompletionSource<LegendItemEnhancementEnhanceResponse>();
		RPCConnection.QueueRequest(new LegendItemEnhancementEnhanceRequest
		{
			EnhanceTargetId = enhanceTargetId,
			FoodIds = foodIds
		}, delegate(RPCContext context)
		{
			try
			{
				LegendItemEnhancementEnhanceResponse result = context.Payload.As<LegendItemEnhancementEnhanceResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<LegendItemLockResponse> LegendItemLock(long instanceId, bool lockStatus)
	{
		TaskCompletionSource<LegendItemLockResponse> tcs = new TaskCompletionSource<LegendItemLockResponse>();
		RPCConnection.QueueRequest(new LegendItemLockRequest
		{
			InstanceId = instanceId,
			LockStatus = lockStatus
		}, delegate(RPCContext context)
		{
			try
			{
				LegendItemLockResponse result = context.Payload.As<LegendItemLockResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<LegendItemEnhancementSwitchFxResponse> LegendItemEnhancementSwitchFx(long instanceId, int fxIndex)
	{
		TaskCompletionSource<LegendItemEnhancementSwitchFxResponse> tcs = new TaskCompletionSource<LegendItemEnhancementSwitchFxResponse>();
		RPCConnection.QueueRequest(new LegendItemEnhancementSwitchFxRequest
		{
			InstanceId = instanceId,
			FxIndex = fxIndex
		}, delegate(RPCContext context)
		{
			try
			{
				LegendItemEnhancementSwitchFxResponse result = context.Payload.As<LegendItemEnhancementSwitchFxResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<LegendItemEnhancementSwapMainResponse> LegendItemEnhancementSwapMain(long instanceId, long swapInstanceId)
	{
		TaskCompletionSource<LegendItemEnhancementSwapMainResponse> tcs = new TaskCompletionSource<LegendItemEnhancementSwapMainResponse>();
		RPCConnection.QueueRequest(new LegendItemEnhancementSwapMainRequest
		{
			InstanceId = instanceId,
			SwapInstanceId = swapInstanceId
		}, delegate(RPCContext context)
		{
			try
			{
				LegendItemEnhancementSwapMainResponse result = context.Payload.As<LegendItemEnhancementSwapMainResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<LegendItemEnhancementSwitchMainResponse> LegendItemEnhancementSwitchMain(long instanceId, string entryId)
	{
		TaskCompletionSource<LegendItemEnhancementSwitchMainResponse> tcs = new TaskCompletionSource<LegendItemEnhancementSwitchMainResponse>();
		RPCConnection.QueueRequest(new LegendItemEnhancementSwitchMainRequest
		{
			InstanceId = instanceId,
			EntryId = entryId
		}, delegate(RPCContext context)
		{
			try
			{
				LegendItemEnhancementSwitchMainResponse result = context.Payload.As<LegendItemEnhancementSwitchMainResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<LegendItemChangePropertyResponse> LegendItemChangeProperty(long instanceId, int entryType, int entryIndex, int costIndex = -1)
	{
		TaskCompletionSource<LegendItemChangePropertyResponse> tcs = new TaskCompletionSource<LegendItemChangePropertyResponse>();
		RPCConnection.QueueRequest(new LegendItemChangePropertyRequest
		{
			InstanceId = instanceId,
			EntryType = entryType,
			EntryIndex = entryIndex,
			CostIndex = costIndex
		}, delegate(RPCContext context)
		{
			try
			{
				LegendItemChangePropertyResponse result = context.Payload.As<LegendItemChangePropertyResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<LegendItemConfirmChangePropertyResponse> LegendItemConfirmChangeProperty(long instanceId, int entryType, int entryIndex, bool confirm)
	{
		TaskCompletionSource<LegendItemConfirmChangePropertyResponse> tcs = new TaskCompletionSource<LegendItemConfirmChangePropertyResponse>();
		RPCConnection.QueueRequest(new LegendItemConfirmChangePropertyRequest
		{
			InstanceId = instanceId,
			EntryType = entryType,
			EntryIndex = entryIndex,
			Confirm = confirm
		}, delegate(RPCContext context)
		{
			try
			{
				LegendItemConfirmChangePropertyResponse result = context.Payload.As<LegendItemConfirmChangePropertyResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<LegendItemReforgeLockPropertyResponse> LegendItemReforgeLockProperty(long instanceId, int entryType, int entryIndex)
	{
		TaskCompletionSource<LegendItemReforgeLockPropertyResponse> tcs = new TaskCompletionSource<LegendItemReforgeLockPropertyResponse>();
		RPCConnection.QueueRequest(new LegendItemReforgeLockPropertyRequest
		{
			InstanceId = instanceId,
			EntryType = entryType,
			EntryIndex = entryIndex
		}, delegate(RPCContext context)
		{
			try
			{
				LegendItemReforgeLockPropertyResponse result = context.Payload.As<LegendItemReforgeLockPropertyResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<LegendItemReforgeResponse> LegendItemReforge(long instanceId, List<int> subEntryIndexList, int costIndex = -1, int lockCostIndex = -1)
	{
		TaskCompletionSource<LegendItemReforgeResponse> tcs = new TaskCompletionSource<LegendItemReforgeResponse>();
		RPCConnection.QueueRequest(new LegendItemReforgeRequest
		{
			InstanceId = instanceId,
			LockedSubEntryIndexList = subEntryIndexList,
			CostIndex = costIndex,
			LockCostIndex = lockCostIndex
		}, delegate(RPCContext context)
		{
			try
			{
				LegendItemReforgeResponse result = context.Payload.As<LegendItemReforgeResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<LegendItemConfirmReforgeResponse> LegendItemConfirmReforge(long instanceId, bool confirm)
	{
		TaskCompletionSource<LegendItemConfirmReforgeResponse> tcs = new TaskCompletionSource<LegendItemConfirmReforgeResponse>();
		RPCConnection.QueueRequest(new LegendItemConfirmReforgeRequest
		{
			InstanceId = instanceId,
			Confirm = confirm
		}, delegate(RPCContext context)
		{
			try
			{
				LegendItemConfirmReforgeResponse result = context.Payload.As<LegendItemConfirmReforgeResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<AssignSoldierToTreasureHuntActivityResponse> AssignSoldierToTreasureHuntActivity(List<KeyValuePair<string, int>> soldiers)
	{
		TaskCompletionSource<AssignSoldierToTreasureHuntActivityResponse> tcs = new TaskCompletionSource<AssignSoldierToTreasureHuntActivityResponse>();
		RPCConnection.QueueRequest(new AssignSoldierToTreasureHuntActivityRequest
		{
			Soldiers = soldiers
		}, delegate(RPCContext context)
		{
			try
			{
				AssignSoldierToTreasureHuntActivityResponse result = context.Payload.As<AssignSoldierToTreasureHuntActivityResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetTreasureHuntActivityProgressResponse> GetTreasureHuntActivityProgress()
	{
		TaskCompletionSource<GetTreasureHuntActivityProgressResponse> tcs = new TaskCompletionSource<GetTreasureHuntActivityProgressResponse>();
		RPCConnection.QueueRequest(new GetTreasureHuntActivityProgressRequest(), delegate(RPCContext context)
		{
			try
			{
				GetTreasureHuntActivityProgressResponse result = context.Payload.As<GetTreasureHuntActivityProgressResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetTreasureHuntBossInsuranceResponse> GetTreasureHuntBossInsurance()
	{
		TaskCompletionSource<GetTreasureHuntBossInsuranceResponse> tcs = new TaskCompletionSource<GetTreasureHuntBossInsuranceResponse>();
		RPCConnection.QueueRequest(new GetTreasureHuntBossInsuranceRequest(), delegate(RPCContext context)
		{
			try
			{
				GetTreasureHuntBossInsuranceResponse result = context.Payload.As<GetTreasureHuntBossInsuranceResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetLegendItemLotteryActivityProgressesResponse> GetLegendItemLotteryActivityProgresses()
	{
		TaskCompletionSource<GetLegendItemLotteryActivityProgressesResponse> tcs = new TaskCompletionSource<GetLegendItemLotteryActivityProgressesResponse>();
		RPCConnection.QueueRequest(new GetLegendItemLotteryActivityProgressesRequest(), delegate(RPCContext context)
		{
			try
			{
				GetLegendItemLotteryActivityProgressesResponse result = context.Payload.As<GetLegendItemLotteryActivityProgressesResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<CheckUnshipOrdersResponse> CheckUnshipOrders()
	{
		TaskCompletionSource<CheckUnshipOrdersResponse> tcs = new TaskCompletionSource<CheckUnshipOrdersResponse>();
		RPCConnection.QueueRequest(new CheckUnshipOrdersRequest(), delegate(RPCContext context)
		{
			try
			{
				CheckUnshipOrdersResponse result = context.Payload.As<CheckUnshipOrdersResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<CheckUnshipOrders_IOS_Response> CheckUnshipOrders_IOS()
	{
		TaskCompletionSource<CheckUnshipOrders_IOS_Response> tcs = new TaskCompletionSource<CheckUnshipOrders_IOS_Response>();
		RPCConnection.QueueRequest(new CheckUnshipOrders_IOS_Request(), delegate(RPCContext context)
		{
			try
			{
				CheckUnshipOrders_IOS_Response result = context.Payload.As<CheckUnshipOrders_IOS_Response>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<CheckUnshipOrders_Intl_Response> CheckUnshipOrders_Intl()
	{
		TaskCompletionSource<CheckUnshipOrders_Intl_Response> tcs = new TaskCompletionSource<CheckUnshipOrders_Intl_Response>();
		RPCConnection.QueueRequest(new CheckUnshipOrders_Intl_Request(), delegate(RPCContext context)
		{
			try
			{
				CheckUnshipOrders_Intl_Response result = context.Payload.As<CheckUnshipOrders_Intl_Response>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetLevelEnemyTemplateResponse> GetLevelEnemyTemplate(string levelId, string activityId = null)
	{
		TaskCompletionSource<GetLevelEnemyTemplateResponse> tcs = new TaskCompletionSource<GetLevelEnemyTemplateResponse>();
		RPCConnection.QueueRequest(new GetLevelEnemyTemplateRequest
		{
			LevelId = levelId,
			ActivityId = activityId
		}, delegate(RPCContext context)
		{
			try
			{
				GetLevelEnemyTemplateResponse result = context.Payload.As<GetLevelEnemyTemplateResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<CheckMissionStatusResponse> CheckMissionStatus(string mid, int status)
	{
		TaskCompletionSource<CheckMissionStatusResponse> tcs = new TaskCompletionSource<CheckMissionStatusResponse>();
		RPCConnection.QueueRequest(new CheckMissionStatusRequest
		{
			MissionId = mid,
			MissionStatus = status
		}, delegate(RPCContext context)
		{
			try
			{
				CheckMissionStatusResponse result = context.Payload.As<CheckMissionStatusResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<CheckReviewPointResponse> CheckReviewPoint()
	{
		TaskCompletionSource<CheckReviewPointResponse> tcs = new TaskCompletionSource<CheckReviewPointResponse>();
		RPCConnection.QueueRequest(new CheckReviewPointRequest(), delegate(RPCContext context)
		{
			try
			{
				CheckReviewPointResponse result = context.Payload.As<CheckReviewPointResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<StatsTapTapReviewResponse> StatsTapTapReview(string openid, string name)
	{
		TaskCompletionSource<StatsTapTapReviewResponse> tcs = new TaskCompletionSource<StatsTapTapReviewResponse>();
		RPCConnection.QueueRequest(new StatsTapTapReviewRequest
		{
			OpenId = openid,
			Name = name
		}, delegate(RPCContext context)
		{
			try
			{
				StatsTapTapReviewResponse result = context.Payload.As<StatsTapTapReviewResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<StatsReviewResponse> StatsReview(string channel, int action)
	{
		TaskCompletionSource<StatsReviewResponse> tcs = new TaskCompletionSource<StatsReviewResponse>();
		RPCConnection.QueueRequest(new StatsReviewRequest
		{
			Action = action,
			Channel = channel
		}, delegate(RPCContext context)
		{
			try
			{
				StatsReviewResponse result = context.Payload.As<StatsReviewResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<StatsAppStoreReviewResponse> StatsAppStoreReview(string channel, int action)
	{
		TaskCompletionSource<StatsAppStoreReviewResponse> tcs = new TaskCompletionSource<StatsAppStoreReviewResponse>();
		RPCConnection.QueueRequest(new StatsAppStoreReviewRequest
		{
			Action = action,
			Channel = channel
		}, delegate(RPCContext context)
		{
			try
			{
				StatsAppStoreReviewResponse result = context.Payload.As<StatsAppStoreReviewResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode3AcceptShipResponse> GvGMode3AcceptShip(string shipId)
	{
		TaskCompletionSource<GvGMode3AcceptShipResponse> tcs = new TaskCompletionSource<GvGMode3AcceptShipResponse>();
		RPCConnection.QueueRequest(new GvGMode3AcceptShipRequest
		{
			ShipId = shipId
		}, delegate(RPCContext context)
		{
			try
			{
				GvGMode3AcceptShipResponse result = context.Payload.As<GvGMode3AcceptShipResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode3BuildShipResponse> GvGMode3BuildShip(string shipRace, int workers, bool fastBuild)
	{
		TaskCompletionSource<GvGMode3BuildShipResponse> tcs = new TaskCompletionSource<GvGMode3BuildShipResponse>();
		RPCConnection.QueueRequest(new GvGMode3BuildShipRequest
		{
			ShipRace = shipRace,
			Workers = workers,
			FastBuild = fastBuild
		}, delegate(RPCContext context)
		{
			try
			{
				GvGMode3BuildShipResponse result = context.Payload.As<GvGMode3BuildShipResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode3DestroyShipResponse> GvGMode3DestroyShip(string shipId)
	{
		TaskCompletionSource<GvGMode3DestroyShipResponse> tcs = new TaskCompletionSource<GvGMode3DestroyShipResponse>();
		RPCConnection.QueueRequest(new GvGMode3DestroyShipRequest
		{
			ShipId = shipId
		}, delegate(RPCContext context)
		{
			try
			{
				GvGMode3DestroyShipResponse result = context.Payload.As<GvGMode3DestroyShipResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode3ShipChangeOrderResponse> GvGMode3ShipChangeOrder(Dictionary<int, string> order)
	{
		TaskCompletionSource<GvGMode3ShipChangeOrderResponse> tcs = new TaskCompletionSource<GvGMode3ShipChangeOrderResponse>();
		RPCConnection.QueueRequest(new GvGMode3ShipChangeOrderRequest
		{
			Order = order
		}, delegate(RPCContext context)
		{
			try
			{
				GvGMode3ShipChangeOrderResponse result = context.Payload.As<GvGMode3ShipChangeOrderResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetGvGMode3DescriptionsResponse> GetGvGMode3Descriptions()
	{
		TaskCompletionSource<GetGvGMode3DescriptionsResponse> tcs = new TaskCompletionSource<GetGvGMode3DescriptionsResponse>();
		RPCConnection.QueueRequest(new GetGvGMode3DescriptionsRequest(), delegate(RPCContext context)
		{
			try
			{
				GetGvGMode3DescriptionsResponse result = context.Payload.As<GetGvGMode3DescriptionsResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetGvGMode3ProcessByIZConfigIdResponse> GetGvGMode3ProcessByIZConfigId(string iZConfigId)
	{
		TaskCompletionSource<GetGvGMode3ProcessByIZConfigIdResponse> tcs = new TaskCompletionSource<GetGvGMode3ProcessByIZConfigIdResponse>();
		RPCConnection.QueueRequest(new GetGvGMode3ProcessByIZConfigIdRequest
		{
			IZConfigId = iZConfigId
		}, delegate(RPCContext context)
		{
			try
			{
				GetGvGMode3ProcessByIZConfigIdResponse result = context.Payload.As<GetGvGMode3ProcessByIZConfigIdResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode3ChangeShipConfigResponse> GvGMode3ChangeShipConfig(string shipId, int changeShipConfigAction, string json)
	{
		TaskCompletionSource<GvGMode3ChangeShipConfigResponse> tcs = new TaskCompletionSource<GvGMode3ChangeShipConfigResponse>();
		RPCConnection.QueueRequest(new GvGMode3ChangeShipConfigRequest
		{
			ShipId = shipId,
			ChangeShipConfigAction = changeShipConfigAction,
			json = json
		}, delegate(RPCContext context)
		{
			try
			{
				GvGMode3ChangeShipConfigResponse result = context.Payload.As<GvGMode3ChangeShipConfigResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode3LoadDefaultFormationResponse> GvGMode3LoadDefaultFormation(int shipRace)
	{
		TaskCompletionSource<GvGMode3LoadDefaultFormationResponse> tcs = new TaskCompletionSource<GvGMode3LoadDefaultFormationResponse>();
		RPCConnection.QueueRequest(new GvGMode3LoadDefaultFormationRequest
		{
			ShipRace = shipRace
		}, delegate(RPCContext context)
		{
			try
			{
				GvGMode3LoadDefaultFormationResponse result = context.Payload.As<GvGMode3LoadDefaultFormationResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode3ClaimSettlementResponse> GvGMode3ClaimSettlement(int _IZId, List<int> _RewardType)
	{
		TaskCompletionSource<GvGMode3ClaimSettlementResponse> tcs = new TaskCompletionSource<GvGMode3ClaimSettlementResponse>();
		RPCConnection.QueueRequest(new GvGMode3ClaimSettlementRequest
		{
			IZId = _IZId,
			RewardType = _RewardType
		}, delegate(RPCContext context)
		{
			try
			{
				GvGMode3ClaimSettlementResponse result = context.Payload.As<GvGMode3ClaimSettlementResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode3CloseBattlePassResponse> GvGMode3CloseBattlePass(int izId)
	{
		TaskCompletionSource<GvGMode3CloseBattlePassResponse> tcs = new TaskCompletionSource<GvGMode3CloseBattlePassResponse>();
		RPCConnection.QueueRequest(new GvGMode3CloseBattlePassRequest
		{
			IZId = izId
		}, delegate(RPCContext context)
		{
			try
			{
				GvGMode3CloseBattlePassResponse result = context.Payload.As<GvGMode3CloseBattlePassResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode3ClaimBattlePassBonusResponse> GvGMode3ClaimBattlePassBonus(int izId, string activityId, string node)
	{
		TaskCompletionSource<GvGMode3ClaimBattlePassBonusResponse> tcs = new TaskCompletionSource<GvGMode3ClaimBattlePassBonusResponse>();
		RPCConnection.QueueRequest(new GvGMode3ClaimBattlePassBonusRequest
		{
			IZId = izId,
			ActivityId = activityId,
			Node = node
		}, delegate(RPCContext context)
		{
			try
			{
				GvGMode3ClaimBattlePassBonusResponse result = context.Payload.As<GvGMode3ClaimBattlePassBonusResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode3GetBattlePassDataResponse> GvGMode3GetBattlePassData(int izId)
	{
		TaskCompletionSource<GvGMode3GetBattlePassDataResponse> tcs = new TaskCompletionSource<GvGMode3GetBattlePassDataResponse>();
		RPCConnection.QueueRequest(new GvGMode3GetBattlePassDataRequest
		{
			IZId = izId
		}, delegate(RPCContext context)
		{
			try
			{
				GvGMode3GetBattlePassDataResponse result = context.Payload.As<GvGMode3GetBattlePassDataResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode3CloseLastIZResponse> GvGMode3CloseLastIZ(int _IZId)
	{
		TaskCompletionSource<GvGMode3CloseLastIZResponse> tcs = new TaskCompletionSource<GvGMode3CloseLastIZResponse>();
		RPCConnection.QueueRequest(new GvGMode3CloseLastIZRequest
		{
			IZId = _IZId
		}, delegate(RPCContext context)
		{
			try
			{
				GvGMode3CloseLastIZResponse result = context.Payload.As<GvGMode3CloseLastIZResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode3GetIZSettlementRecordResponse> GvGMode3GetIZSettlementRecord(int _IZId)
	{
		TaskCompletionSource<GvGMode3GetIZSettlementRecordResponse> tcs = new TaskCompletionSource<GvGMode3GetIZSettlementRecordResponse>();
		RPCConnection.QueueRequest(new GvGMode3GetIZSettlementRecordRequest
		{
			IZId = _IZId
		}, delegate(RPCContext context)
		{
			try
			{
				GvGMode3GetIZSettlementRecordResponse result = context.Payload.As<GvGMode3GetIZSettlementRecordResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode3JoinShipToRoomResponse> GvGMode3JoinShipToRoom(string iZConfigId, int iZId, List<string> shipIds)
	{
		TaskCompletionSource<GvGMode3JoinShipToRoomResponse> tcs = new TaskCompletionSource<GvGMode3JoinShipToRoomResponse>();
		RPCConnection.QueueRequest(new GvGMode3JoinShipToRoomRequest
		{
			IZConfigId = iZConfigId,
			IZId = iZId,
			ShipIds = shipIds
		}, delegate(RPCContext context)
		{
			try
			{
				GvGMode3JoinShipToRoomResponse result = context.Payload.As<GvGMode3JoinShipToRoomResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode3ShipGetRecordResponse> GvGMode3ShipGetRecord()
	{
		TaskCompletionSource<GvGMode3ShipGetRecordResponse> tcs = new TaskCompletionSource<GvGMode3ShipGetRecordResponse>();
		RPCConnection.QueueRequest(new GvGMode3ShipGetRecordRequest(), delegate(RPCContext context)
		{
			try
			{
				GvGMode3ShipGetRecordResponse result = context.Payload.As<GvGMode3ShipGetRecordResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GvGMode3SignUpActionResponse> GvGMode3SignUpAction(int CampId, int IZId, string IZConfigId, string SignUpAction)
	{
		TaskCompletionSource<GvGMode3SignUpActionResponse> tcs = new TaskCompletionSource<GvGMode3SignUpActionResponse>();
		RPCConnection.QueueRequest(new GvGMode3SignUpActionRequest
		{
			CampId = CampId,
			IZId = IZId,
			IZConfigId = IZConfigId,
			SignUpAction = SignUpAction
		}, delegate(RPCContext context)
		{
			try
			{
				GvGMode3SignUpActionResponse result = context.Payload.As<GvGMode3SignUpActionResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SyncGvGProduceResponse> SyncGvGProduce(long tick, bool getAllProduceStates = false)
	{
		TaskCompletionSource<SyncGvGProduceResponse> tcs = new TaskCompletionSource<SyncGvGProduceResponse>();
		RPCConnection.QueueRequest(new SyncGvGProduceRequest
		{
			Tick = tick,
			GetAllProduceStates = getAllProduceStates
		}, delegate(RPCContext context)
		{
			try
			{
				SyncGvGProduceResponse result = context.Payload.As<SyncGvGProduceResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetCollectingInfoResponse> GetCollectingInfo()
	{
		TaskCompletionSource<GetCollectingInfoResponse> tcs = new TaskCompletionSource<GetCollectingInfoResponse>();
		RPCConnection.QueueRequest(new GetCollectingInfoRequest(), delegate(RPCContext context)
		{
			try
			{
				GetCollectingInfoResponse result = context.Payload.As<GetCollectingInfoResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetCreateAccountDay.Response> GetCreateAccountDay()
	{
		TaskCompletionSource<GetCreateAccountDay.Response> tcs = new TaskCompletionSource<GetCreateAccountDay.Response>();
		RPCConnection.QueueRequest(new GetCreateAccountDay.Request(), delegate(RPCContext context)
		{
			try
			{
				GetCreateAccountDay.Response result = context.Payload.As<GetCreateAccountDay.Response>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetRecallWelfareResponse> GetRecallWelfare()
	{
		TaskCompletionSource<GetRecallWelfareResponse> tcs = new TaskCompletionSource<GetRecallWelfareResponse>();
		RPCConnection.QueueRequest(new GetRecallWelfareRequest(), delegate(RPCContext context)
		{
			try
			{
				GetRecallWelfareResponse result = context.Payload.As<GetRecallWelfareResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<DrawRecallWelfareResponse> DrawRecallWelfare(List<int> index)
	{
		TaskCompletionSource<DrawRecallWelfareResponse> tcs = new TaskCompletionSource<DrawRecallWelfareResponse>();
		RPCConnection.QueueRequest(new DrawRecallWelfareRequest
		{
			Indexs = index
		}, delegate(RPCContext context)
		{
			try
			{
				DrawRecallWelfareResponse result = context.Payload.As<DrawRecallWelfareResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ExchangeRecallWelfareResponse> ExchangeRecallWelfare()
	{
		TaskCompletionSource<ExchangeRecallWelfareResponse> tcs = new TaskCompletionSource<ExchangeRecallWelfareResponse>();
		RPCConnection.QueueRequest(new ExchangeRecallWelfareRequest(), delegate(RPCContext context)
		{
			try
			{
				ExchangeRecallWelfareResponse result = context.Payload.As<ExchangeRecallWelfareResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ClaimRecallWelfareBonusResponse> ClaimRecallWelfareBonus(string missionId)
	{
		TaskCompletionSource<ClaimRecallWelfareBonusResponse> tcs = new TaskCompletionSource<ClaimRecallWelfareBonusResponse>();
		RPCConnection.QueueRequest(new ClaimRecallWelfareBonusRequest
		{
			MissionId = missionId
		}, delegate(RPCContext context)
		{
			try
			{
				ClaimRecallWelfareBonusResponse result = context.Payload.As<ClaimRecallWelfareBonusResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetWeeklyActivityResponse> GetWeeklyActivity()
	{
		TaskCompletionSource<GetWeeklyActivityResponse> tcs = new TaskCompletionSource<GetWeeklyActivityResponse>();
		RPCConnection.QueueRequest(new GetWeeklyActivityRequest(), delegate(RPCContext context)
		{
			try
			{
				GetWeeklyActivityResponse result = context.Payload.As<GetWeeklyActivityResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<DrawSpinWeeklyResponse> DrawSpinWeekly(int drawRepeat)
	{
		TaskCompletionSource<DrawSpinWeeklyResponse> tcs = new TaskCompletionSource<DrawSpinWeeklyResponse>();
		RPCConnection.QueueRequest(new DrawSpinWeeklyRequest
		{
			DrawRepeat = drawRepeat
		}, delegate(RPCContext context)
		{
			try
			{
				DrawSpinWeeklyResponse result = context.Payload.As<DrawSpinWeeklyResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ExchangeSpinWeeklyResponse> ExchangeSpinWeekly(int index, int repeat)
	{
		TaskCompletionSource<ExchangeSpinWeeklyResponse> tcs = new TaskCompletionSource<ExchangeSpinWeeklyResponse>();
		RPCConnection.QueueRequest(new ExchangeSpinWeeklyRequest
		{
			Index = index,
			Repeat = repeat
		}, delegate(RPCContext context)
		{
			try
			{
				ExchangeSpinWeeklyResponse result = context.Payload.As<ExchangeSpinWeeklyResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ClaimSpinWeeklyLotteryResponse> ClaimSpinWeeklyLottery(int day, bool free)
	{
		TaskCompletionSource<ClaimSpinWeeklyLotteryResponse> tcs = new TaskCompletionSource<ClaimSpinWeeklyLotteryResponse>();
		RPCConnection.QueueRequest(new ClaimSpinWeeklyLotteryRequest
		{
			Day = day,
			Free = free
		}, delegate(RPCContext context)
		{
			try
			{
				ClaimSpinWeeklyLotteryResponse result = context.Payload.As<ClaimSpinWeeklyLotteryResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SyncDailyMissionScoreResponse> SyncDailyMissionScore()
	{
		TaskCompletionSource<SyncDailyMissionScoreResponse> tcs = new TaskCompletionSource<SyncDailyMissionScoreResponse>();
		RPCConnection.QueueRequest(new SyncDailyMissionScoreRequest(), delegate(RPCContext context)
		{
			try
			{
				SyncDailyMissionScoreResponse result = context.Payload.As<SyncDailyMissionScoreResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<MoonBattlePassActivityClaimResponse> MoonBattlePassActivityClaim(string actId, string node)
	{
		TaskCompletionSource<MoonBattlePassActivityClaimResponse> tcs = new TaskCompletionSource<MoonBattlePassActivityClaimResponse>();
		RPCConnection.QueueRequest(new MoonBattlePassActivityClaimRequest
		{
			ActivityId = actId,
			node = node
		}, delegate(RPCContext context)
		{
			try
			{
				MoonBattlePassActivityClaimResponse result = context.Payload.As<MoonBattlePassActivityClaimResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<WarOfRealmClaimResponse> ClaimWarOfRealm(int score)
	{
		TaskCompletionSource<WarOfRealmClaimResponse> tcs = new TaskCompletionSource<WarOfRealmClaimResponse>();
		RPCConnection.QueueRequest(new WarOfRealmClaimRequest
		{
			Score = score
		}, delegate(RPCContext context)
		{
			try
			{
				WarOfRealmClaimResponse result = context.Payload.As<WarOfRealmClaimResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<WarOfRealmGetInfoResponse> GetWarOfRealmInfo()
	{
		TaskCompletionSource<WarOfRealmGetInfoResponse> tcs = new TaskCompletionSource<WarOfRealmGetInfoResponse>();
		RPCConnection.QueueRequest(new WarOfRealmGetInfoRequest(), delegate(RPCContext context)
		{
			try
			{
				WarOfRealmGetInfoResponse result = context.Payload.As<WarOfRealmGetInfoResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetWarOfRealmFormationResponse> GetWarOfRealmFormation()
	{
		TaskCompletionSource<GetWarOfRealmFormationResponse> tcs = new TaskCompletionSource<GetWarOfRealmFormationResponse>();
		RPCConnection.QueueRequest(new GetWarOfRealmFormationResponse(), delegate(RPCContext context)
		{
			try
			{
				GetWarOfRealmFormationResponse result = context.Payload.As<GetWarOfRealmFormationResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SetWarOfRealmFormationResponse> SetWarOfRealmFormation(WarOfRealmConfig formation)
	{
		TaskCompletionSource<SetWarOfRealmFormationResponse> tcs = new TaskCompletionSource<SetWarOfRealmFormationResponse>();
		RPCConnection.QueueRequest(new SetWarOfRealmFormationRequest
		{
			Formation = formation
		}, delegate(RPCContext context)
		{
			try
			{
				SetWarOfRealmFormationResponse result = context.Payload.As<SetWarOfRealmFormationResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<WarOfRealmClaimMissionBonusResponse> ClaimWarOfRealmMissionBonus(int score)
	{
		TaskCompletionSource<WarOfRealmClaimMissionBonusResponse> tcs = new TaskCompletionSource<WarOfRealmClaimMissionBonusResponse>();
		RPCConnection.QueueRequest(new WarOfRealmClaimMissionBonusRequest
		{
			Score = score
		}, delegate(RPCContext context)
		{
			try
			{
				WarOfRealmClaimMissionBonusResponse result = context.Payload.As<WarOfRealmClaimMissionBonusResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<WarOfRealmClaimRankBonusResponse> ClaimWarOfRealmRankBonus(string activityId)
	{
		TaskCompletionSource<WarOfRealmClaimRankBonusResponse> tcs = new TaskCompletionSource<WarOfRealmClaimRankBonusResponse>();
		RPCConnection.QueueRequest(new WarOfRealmClaimRankBonusRequest
		{
			ActivityId = activityId
		}, delegate(RPCContext context)
		{
			try
			{
				WarOfRealmClaimRankBonusResponse result = context.Payload.As<WarOfRealmClaimRankBonusResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<WarOfRealmGetStageRecordResponse> GetWarOfRealmStageRecord(string activityId, int stageStatus)
	{
		TaskCompletionSource<WarOfRealmGetStageRecordResponse> tcs = new TaskCompletionSource<WarOfRealmGetStageRecordResponse>();
		RPCConnection.QueueRequest(new WarOfRealmGetStageRecordRequest
		{
			ActivityId = activityId,
			StageStatus = stageStatus
		}, delegate(RPCContext context)
		{
			try
			{
				WarOfRealmGetStageRecordResponse result = context.Payload.As<WarOfRealmGetStageRecordResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<WarOfRealmGetWarBattleRecordResponse> GetWarOfRealmWarBattleRecord(int stageStatus, int userId)
	{
		TaskCompletionSource<WarOfRealmGetWarBattleRecordResponse> tcs = new TaskCompletionSource<WarOfRealmGetWarBattleRecordResponse>();
		RPCConnection.QueueRequest(new WarOfRealmGetWarBattleRecordRequest
		{
			StageStatus = stageStatus,
			UserId = userId
		}, delegate(RPCContext context)
		{
			try
			{
				WarOfRealmGetWarBattleRecordResponse result = context.Payload.As<WarOfRealmGetWarBattleRecordResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<WarOfRealmLotteryResponse> LotteryWarOfRealm(int stageStatus, int groupIdx, List<WarLottery> lotteries)
	{
		TaskCompletionSource<WarOfRealmLotteryResponse> tcs = new TaskCompletionSource<WarOfRealmLotteryResponse>();
		RPCConnection.QueueRequest(new WarOfRealmLotteryRequest
		{
			StageStatus = stageStatus,
			GroupIndex = groupIdx,
			WarLottery = lotteries
		}, delegate(RPCContext context)
		{
			try
			{
				WarOfRealmLotteryResponse result = context.Payload.As<WarOfRealmLotteryResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<WarOfRealmSettlementResponse> SettlementWarOfRealm(string activityId, int stageStatus)
	{
		TaskCompletionSource<WarOfRealmSettlementResponse> tcs = new TaskCompletionSource<WarOfRealmSettlementResponse>();
		RPCConnection.QueueRequest(new WarOfRealmSettlementRequest
		{
			ActivityId = activityId,
			StageStatus = stageStatus
		}, delegate(RPCContext context)
		{
			try
			{
				WarOfRealmSettlementResponse result = context.Payload.As<WarOfRealmSettlementResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<WarOfRealmGetStageBattleRecordResponse> GetWarOfRealmStageBattleRecord(int groupId, int stageStatus)
	{
		TaskCompletionSource<WarOfRealmGetStageBattleRecordResponse> tcs = new TaskCompletionSource<WarOfRealmGetStageBattleRecordResponse>();
		RPCConnection.QueueRequest(new WarOfRealmGetStageBattleRecordRequest
		{
			GroupId = groupId,
			StageStatus = stageStatus
		}, delegate(RPCContext context)
		{
			try
			{
				WarOfRealmGetStageBattleRecordResponse result = context.Payload.As<WarOfRealmGetStageBattleRecordResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<WarOfRealmReplayResponse> WarOfRealmReplay(string battleId)
	{
		TaskCompletionSource<WarOfRealmReplayResponse> tcs = new TaskCompletionSource<WarOfRealmReplayResponse>();
		RPCConnection.QueueRequest(new WarOfRealmReplayRequest
		{
			BattleId = battleId
		}, delegate(RPCContext context)
		{
			try
			{
				WarOfRealmReplayResponse result = context.Payload.As<WarOfRealmReplayResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<WarOfRealmGetScoreHistoryResponse> WarOfRealmGetScoreHistory()
	{
		TaskCompletionSource<WarOfRealmGetScoreHistoryResponse> tcs = new TaskCompletionSource<WarOfRealmGetScoreHistoryResponse>();
		RPCConnection.QueueRequest(new WarOfRealmGetScoreHistoryRequest(), delegate(RPCContext context)
		{
			try
			{
				WarOfRealmGetScoreHistoryResponse result = context.Payload.As<WarOfRealmGetScoreHistoryResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetAccessoryInfoResponse> GetAccessoryInfo()
	{
		TaskCompletionSource<GetAccessoryInfoResponse> tcs = new TaskCompletionSource<GetAccessoryInfoResponse>();
		RPCConnection.QueueRequest(new GetAccessoryInfoRequest(), delegate(RPCContext context)
		{
			try
			{
				GetAccessoryInfoResponse result = context.Payload.As<GetAccessoryInfoResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<EquipAccessoryResponse> EquipAccessory(string itemId, int type)
	{
		TaskCompletionSource<EquipAccessoryResponse> tcs = new TaskCompletionSource<EquipAccessoryResponse>();
		RPCConnection.QueueRequest(new EquipAccessoryRequest
		{
			ItemId = itemId,
			Type = type
		}, delegate(RPCContext context)
		{
			try
			{
				EquipAccessoryResponse result = context.Payload.As<EquipAccessoryResponse>();
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}
}
