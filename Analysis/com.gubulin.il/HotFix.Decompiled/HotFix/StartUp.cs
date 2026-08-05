using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using GameDataEditor;
using GvG2.Common.Models;
using GvG3;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3OnIsland.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.SystemMessageParser;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3WorldMap.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol;
using HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol.UserAction;
using ILRuntime.Runtime.Intepreter;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Models.LegendItemBlueprint;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.Announcement;
using Shift.Legion.ClientApi.Protocol.Archive;
using Shift.Legion.ClientApi.Protocol.Building;
using Shift.Legion.ClientApi.Protocol.Friends;
using Shift.Legion.ClientApi.Protocol.Mailing;
using Shift.Legion.ClientApi.Protocol.Modules.Inventory;
using Shift.Legion.ClientApi.Protocol.Modules.Inventory.Models;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItemEnhancement;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierItemSlot;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierItemSlot.Models;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierLegendItem;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierLegendItem.Models;
using Shift.Legion.ClientApi.Protocol.Store;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.Sources.Protocol;
using Shift.Legion.ClientApi.Sources.Protocol.FriendsChat;
using Shift.Legion.ClientApi.Sources.Protocol.UserAction;
using Shift.Legion.ClientApi.Sources.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common;
using Shift.Legion.GvG.Common.GvGMode2Island;
using Shift.Legion.GvG.Common.GvGMode3Island;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.BattleLog;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;
using Shift.Legion.GvG.Common.Models.GvGMode3.Collecting;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent;
using Shift.Legion.GvG.Common.Models.GvGMode3.RealTime;
using Shift.Legion.GvG.Common.Models.InstanceZoneModels;
using Shift.Legion.GvG.Common.Models.OuterTech;
using Shift.Legion.GvGServer.Models.GvGMode2IslandSocket;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;
using Shift.Legion.GvGServer.Models.IslandManagerSocket;
using Shift.Legion.GvGServer.Models.Map;
using Shift.Legion.GvGServer.Models.WorldBossSocket;
using Spine.Unity;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace HotFix;

public static class StartUp
{
	public static List<Type> Protobuf_Type = new List<Type>
	{
		typeof(List<byte[]>),
		typeof(GDESoldierData),
		typeof(GDELevelData),
		typeof(GDELevelBonusData),
		typeof(GDEAbilityData),
		typeof(GDEStoreContentConfigData),
		typeof(GDEPrizePoolData),
		typeof(GDEDecorativeObjectsData),
		typeof(GDEStoryData),
		typeof(GDERankConfigData),
		typeof(GDEFormulaData),
		typeof(CheckUnshipOrdersRequest),
		typeof(CheckUnshipOrdersResponse),
		typeof(CheckUnshipOrders_IOS_Request),
		typeof(CheckUnshipOrders_IOS_Response),
		typeof(CheckUnshipOrders_Intl_Request),
		typeof(CheckUnshipOrders_Intl_Response),
		typeof(ResourceRequirement),
		typeof(LegendItemData),
		typeof(ItemEntryData),
		typeof(ItemAbility),
		typeof(InventoryItem),
		typeof(ItemEntry),
		typeof(FxEntryGroup),
		typeof(LegendItem),
		typeof(SoldiersItemSlots),
		typeof(SoldiersEquippedItems),
		typeof(InventoryGetAllRequest),
		typeof(InventoryGetAllResponse),
		typeof(InventoryRetrieveRequest),
		typeof(InventoryRetrieveResponse),
		typeof(InventoryUpdateRequest),
		typeof(InventoryUpdateResponse),
		typeof(LegendItemAllRequest),
		typeof(LegendItemAllResponse),
		typeof(LegendItemChangePropertyRequest),
		typeof(LegendItemChangePropertyResponse),
		typeof(LegendItemConfirmChangePropertyRequest),
		typeof(LegendItemConfirmChangePropertyResponse),
		typeof(LegendItemConfirmReforgeRequest),
		typeof(LegendItemConfirmReforgeResponse),
		typeof(LegendItemEnhancementSwapMainRequest),
		typeof(LegendItemEnhancementSwapMainResponse),
		typeof(LegendItemEnhancementSwitchMainRequest),
		typeof(LegendItemEnhancementSwitchMainResponse),
		typeof(LegendItemEnhancementSwitchFxRequest),
		typeof(LegendItemEnhancementSwitchFxResponse),
		typeof(LegendItemCreateRequest),
		typeof(LegendItemCreateResponse),
		typeof(LegendItemDestroyRequest),
		typeof(LegendItemDestroyResponse),
		typeof(LegendItemLockRequest),
		typeof(LegendItemLockResponse),
		typeof(LegendItemReforgeLockPropertyRequest),
		typeof(LegendItemReforgeLockPropertyResponse),
		typeof(LegendItemReforgeRequest),
		typeof(LegendItemReforgeResponse),
		typeof(LegendItemRetrieveRequest),
		typeof(LegendItemRetrieveResponse),
		typeof(SelfSelectionBluePrintRequest),
		typeof(SelfSelectionBluePrintResponse),
		typeof(SpecialSelectionBluePrintConfigRequest),
		typeof(SpecialSelectionBluePrintConfigResponse),
		typeof(SpecialSelectionBluePrintRequest),
		typeof(SpecialSelectionBluePrintResponse),
		typeof(GetTreasureHuntActivityProgressResponse),
		typeof(AssignSoldierToTreasureHuntActivityResponse),
		typeof(GetTreasureHuntActivityProgressRequest),
		typeof(GetLegendItemLotteryActivityProgressesRequest),
		typeof(GetLegendItemLotteryActivityProgressesResponse),
		typeof(AssignSoldierToTreasureHuntActivityRequest),
		typeof(TreasureHuntLevelInfo),
		typeof(EnemyTemplate),
		typeof(LegendItemEnhancementEnhanceRequest),
		typeof(LegendItemEnhancementEnhanceResponse),
		typeof(SoldierItemSlotAllRequest),
		typeof(SoldierItemSlotAllResponse),
		typeof(SoldierItemSlotUnlockRequest),
		typeof(SoldierItemSlotUnlockResponse),
		typeof(SoldierEquippedItemsAllRequest),
		typeof(SoldierEquippedItemsAllResponse),
		typeof(SoldierTakeOffLegendItemRequest),
		typeof(SoldierTakeOffLegendItemResponse),
		typeof(SoldierWearLegendItemRequest),
		typeof(SoldierWearLegendItemResponse),
		typeof(DrawCardTestRequest),
		typeof(DrawCardTestResponse),
		typeof(RandomLevelTestRequest),
		typeof(RandomLevelTestResponse),
		typeof(Header),
		typeof(GetLevelReplaysResponse),
		typeof(GetLevelReplaysRequest),
		typeof(RevokeBattleResponse),
		typeof(RevokeBattleRequest),
		typeof(LevelBattleReplay),
		typeof(BattleRecordDetail),
		typeof(Shift.Legion.ClientApi.Models.SoldierDetail),
		typeof(LegendItemBrief),
		typeof(ItemEntryBrief),
		typeof(TechLevel),
		typeof(ItemLevel),
		typeof(GetRecentReplaysRequest),
		typeof(GetRecentReplaysResponse),
		typeof(ProduceState),
		typeof(Shift.Legion.ClientApi.Protocol.Item),
		typeof(Shift.Legion.ClientApi.Protocol.Archive.UserData),
		typeof(ProtocolBonus),
		typeof(ModelsBonus),
		typeof(Shift.Legion.ClientApi.Models.LotteryPendingResult),
		typeof(CompositeInformData),
		typeof(ErrorInfo),
		typeof(NoData),
		typeof(PingRequest),
		typeof(PingResponse),
		typeof(PushItem),
		typeof(SyncTimeRequest),
		typeof(SyncTimeResponse),
		typeof(ServerInfoRequest),
		typeof(ServerInfoResponse),
		typeof(StockChangedRequest),
		typeof(MailListRequest),
		typeof(DeviceLogRequest),
		typeof(AnnouncementListRequest),
		typeof(AnnouncementListResponse),
		typeof(GetInvitedWorkersResponse),
		typeof(UserInfo),
		typeof(RecycleDailyProduceStat),
		typeof(CheckActivitiesOverPeriodResponse),
		typeof(UseItemResponse),
		typeof(StoreItem),
		typeof(StoreItemList),
		typeof(StartBattleRequest),
		typeof(PullDataResponse),
		typeof(LevelExtraInfo),
		typeof(Shift.Legion.ClientApi.Protocol.Friends.InvitedWorker),
		typeof(GetBattleResultResponse),
		typeof(CheckBattleFailedProcessResponse),
		typeof(ChangeInvitingSlotsConfigRequest),
		typeof(UpgradeBuildingRequest),
		typeof(SwitchRecycleMultiplayerEnableRequest),
		typeof(SoulStoneMaxCompositeToResponse),
		typeof(SetInvitedFromResponse),
		typeof(RecycleExportToResponse),
		typeof(PendingLotteryResultClaimResponse),
		typeof(Shift.Legion.ClientApi.Protocol.Mailing.Mail),
		typeof(GetTotalRecycleExportRequestRequest),
		typeof(GetSelfRecycleStatsRequest),
		typeof(GetRecycleStatsRequest),
		typeof(GetRecycleRebateRequest),
		typeof(GetRecycleProductsResponse),
		typeof(GetMissionActivityStoreItemsResponse),
		typeof(GetFriendsResponse),
		typeof(GetFriendsCanExportRecycleRequest),
		typeof(GetBattleResultRequest),
		typeof(DownloadBattleReplayResponse),
		typeof(ClaimRecycleRebateRequest),
		typeof(CheckBattleFailedProcessRequest),
		typeof(ChangeWorkshopProduceConfigRequest),
		typeof(ChangeInvitingSlotsConfigResponse),
		typeof(ChangeCampProduceConfigRequest),
		typeof(BindMobileVerifyResponse),
		typeof(Shift.Legion.ClientApi.Protocol.Announcement.Announcement),
		typeof(ActivityReviewResponse),
		typeof(ActivityResetResponse),
		typeof(ActivityClaimResponse),
		typeof(User),
		typeof(UseItemRequest),
		typeof(SwitchRecycleMultiplayerEnableResponse),
		typeof(StockChangedResponse),
		typeof(ReviewInvitedWorkersResponse),
		typeof(ReviewInvitedWorkersRequest),
		typeof(RecycleExportToRequest),
		typeof(QueryIAPResultResponse),
		typeof(Shift.Legion.ClientApi.Protocol.Building.ProductionConfig),
		typeof(PlaceOrderResponse),
		typeof(PendingLotteryResultClaimRequest),
		typeof(Order),
		typeof(MissionClaimResponse),
		typeof(MailOperation),
		typeof(MailListResponse),
		typeof(MailCreateResponse),
		typeof(LoginResponse),
		typeof(GetTotalRecycleExportRequestResponse),
		typeof(GetStoreActivityItemsResponse),
		typeof(GetSelfRecycleStatsResponse),
		typeof(GetRecycleStatsResponse),
		typeof(GetRecycleRebateResponse),
		typeof(GetRecycleProductsRequest),
		typeof(GetOfflineYieldBonusResponse),
		typeof(GetFriendsCanExportRecycleResponse),
		typeof(GetBattleBonusResponse),
		typeof(DrawCardResponse),
		typeof(GetDrawCardCntRequest),
		typeof(GetDrawCardCntResponse),
		typeof(DownloadArchiveResponse),
		typeof(DeleteFriendResponse),
		typeof(ConfirmBattleBonusResponse),
		typeof(ClaimVerifyIdentityBonusResponse),
		typeof(ClaimRecycleRebateResponse),
		typeof(CheckOrderResponse),
		typeof(CheckActivitiesOverPeriodRequest),
		typeof(CheckActivitiesAutoFillResponse),
		typeof(Shift.Legion.ClientApi.Protocol.Building.BuildingConstructingConfig),
		typeof(AssignInvitedWorkerResponse),
		typeof(AddFriendResponse),
		typeof(ActivityReviewRequest),
		typeof(ActivateInvitedWorkerResponse),
		typeof(ActivateInvitedWorkerRequest),
		typeof(StockChangeRecord),
		typeof(VerifyIdentityResponse),
		typeof(VerifyIdentityRequest),
		typeof(UserDeviceInfoResponse),
		typeof(UserDeviceInfoRequest),
		typeof(UpgradeTechnologyResponse),
		typeof(UpgradeTechnologyRequest),
		typeof(UpgradeItemResponse),
		typeof(UpgradeItemRequest),
		typeof(UpgradeBuildingResponse),
		typeof(UnlockRegionResponse),
		typeof(UnlockRegionRequest),
		typeof(UnlockFormationResponse),
		typeof(UnlockFormationRequest),
		typeof(TriggerStoryResponse),
		typeof(TriggerStoryRequest),
		typeof(TelVerifyCodeRequest),
		typeof(SubmitBattleOperationResponse),
		typeof(SubmitBattleOperationRequest),
		typeof(StatsPurchaseResponse),
		typeof(StatsPurchaseRequest),
		typeof(StartBattleResponse),
		typeof(SoulStoneMaxCompositeToRequest),
		typeof(SoldierPotentialBreakthroughResponse),
		typeof(SoldierPotentialBreakthroughRequest),
		typeof(SoldierEvoluteResponse),
		typeof(SoldierEvoluteRequest),
		typeof(SoldierAddPotentialProgressResponse),
		typeof(SoldierAddPotentialProgressRequest),
		typeof(SkipCurrentStoryResponse),
		typeof(SkipCurrentStoryRequest),
		typeof(SignInClaimResponse),
		typeof(SignInClaimRequest),
		typeof(SetInvitedFromRequest),
		typeof(RetreatResponse),
		typeof(RetreatRequest),
		typeof(ResetTechnologyResponse),
		typeof(ResetTechnologyRequest),
		typeof(ResetArchiveResponse),
		typeof(ResetArchiveRequest),
		typeof(QueryIAPResultRequest),
		typeof(PullDataRequest),
		typeof(PlayStoryResponse),
		typeof(PlayStoryRequest),
		typeof(PlaceOrderRequest),
		typeof(PiecesCompositeResponse),
		typeof(PiecesCompositeRequest),
		typeof(NewsTicker),
		typeof(MarqueeContent),
		typeof(NeedRestartResponse),
		typeof(NeedReLoginResponse),
		typeof(MissionClaimRequest),
		typeof(MainLevelRetreatRequest),
		typeof(MainLevelRetreatResponse),
		typeof(MailOperateResponse),
		typeof(MailCreateRequest),
		typeof(LoginRequest),
		typeof(PreCheckRequest),
		typeof(PreCheckResponse),
		typeof(LeaseholdDailyBonusClaimResponse),
		typeof(LeaseholdDailyBonusClaimRequest),
		typeof(GetStoreActivityItemsRequest),
		typeof(GetServerStatusResponse),
		typeof(GvGGetWorldBossInfoRequest),
		typeof(GvGWorldBossRecordRankingRequest),
		typeof(GvGWorldBossRecordRanking2Request),
		typeof(GvGWorldBossRecordRankingResponse),
		typeof(GvGWorldBossRecordRanking2Response),
		typeof(WBRankingModel),
		typeof(RankModel),
		typeof(GvGGetSelfShipCountRequest),
		typeof(GvGGetSelfShipCountResponse),
		typeof(GvGGetWorldBossInfoResponse),
		typeof(GvGWorldBossGetBattleResultListResponse),
		typeof(GvGGetIZInfosRequest),
		typeof(GvGGetIZInfosResponse),
		typeof(InstanceZone_Protocol),
		typeof(CampMission),
		typeof(CampMissionConfig),
		typeof(GvGClaimUserCampMissionRequest),
		typeof(GvGClaimUserCampMissionResponse),
		typeof(GvGWorldBossGetBattleResultListRequest),
		typeof(GvGWorldBossStartBattleRequest),
		typeof(GvGWorldBossStartBattleResponse),
		typeof(GvGWorldBosPlayerTeamInfo),
		typeof(Shift.Legion.GvGServer.Models.Map.GvGProcessInfo),
		typeof(GvG2.Common.Models.GvGProcessInfo),
		typeof(GvGGetWorldBossKeyInfoRequest),
		typeof(GvGGetWorldBossKeyInfoResponse),
		typeof(GvGRoomOperationRequest),
		typeof(GvGRoomOperationResponse),
		typeof(GvGRoomOperationDisabledRequest),
		typeof(GvGRoomOperationDisabledResponse),
		typeof(GvGMode2SyncBattleConfigRequest),
		typeof(GvGMode2SyncBattleConfigResponse),
		typeof(GvGMode2CreateShipSummaryRequest),
		typeof(GvGMode2CreateShipSummaryResponse),
		typeof(GetServerStatusRequest),
		typeof(GetOfflineYieldBonusRequest),
		typeof(GetMissionActivityStoreItemsRequest),
		typeof(GetInvitedWorkersRequest),
		typeof(GetFriendsRequest),
		typeof(GetBattleBonusRequest),
		typeof(FinishUpgradeBuildingResponse),
		typeof(FinishUpgradeBuildingRequest),
		typeof(EnterGameResponse),
		typeof(EnterGameRequest),
		typeof(DrawCardRequest),
		typeof(DownloadBattleReplayRequest),
		typeof(DownloadArchiveRequest),
		typeof(DeviceLogResponse),
		typeof(DeviceInfo),
		typeof(DeviceIdentifierResponse),
		typeof(DeviceIdentifierRequest),
		typeof(DeleteFriendRequest),
		typeof(ConfirmResetArchiveResponse),
		typeof(ConfirmResetArchiveRequest),
		typeof(ConfirmBattleBonusRequest),
		typeof(ClaimVerifyIdentityBonusRequest),
		typeof(CheckOrderRequest),
		typeof(CheckActivitiesAutoFillRequest),
		typeof(ChangeWorkshopProduceConfigResponse),
		typeof(ChangeStrongholdProduceConfigResponse),
		typeof(ChangeStrongholdProduceConfigRequest),
		typeof(ChangeFormationUnitResponse),
		typeof(ChangeFormationUnitRequest),
		typeof(ChangeFormationResponse),
		typeof(ChangeFormationRequest),
		typeof(ChangeCampProduceConfigResponse),
		typeof(BindMobileVerifyRequest),
		typeof(BindMobileResponse),
		typeof(BindMobileRequest),
		typeof(AssignInvitedWorkerRequest),
		typeof(AddFriendRequest),
		typeof(ActivityResetRequest),
		typeof(ActivityClaimRequest),
		typeof(AchievementClaimResponse),
		typeof(AchievementClaimRequest),
		typeof(SyncProduceRequest),
		typeof(SyncProduceResponse),
		typeof(SyncStockRequest),
		typeof(SyncStockResponse),
		typeof(SyncWeeklyMissionScoreRequest),
		typeof(SyncWeeklyMissionScoreResponse),
		typeof(BonusList),
		typeof(GetFormationInfoRequest),
		typeof(GetFormationInfoResponse),
		typeof(SyncFormationUnitsRequest),
		typeof(SyncFormationUnitsResponse),
		typeof(SyncRankFormationUnitsRequest),
		typeof(SyncRankFormationUnitsResponse),
		typeof(SetFormationUnitsOfRankRequest),
		typeof(SetFormationUnitsOfRankResponse),
		typeof(StartRankBattleRequest),
		typeof(StartRankBattleResponse),
		typeof(GetRankBattleResultRequest),
		typeof(GetRankBattleResultResponse),
		typeof(RankRecord),
		typeof(GetDetailRankInfoResponse),
		typeof(GetDetailRankInfoRequest),
		typeof(GetRankListResponse),
		typeof(GetRankListRequest),
		typeof(GetSelfRankResponse),
		typeof(GetSelfRankRequest),
		typeof(PvPRankAddAttackBuffResponse),
		typeof(PvPRankAddAttackBuffRequest),
		typeof(PvPRankAddDefenseBuffResponse),
		typeof(PvPRankAddDefenseBuffRequest),
		typeof(PvPRankClearCdResponse),
		typeof(PvPRankClearCdRequest),
		typeof(GetPvPScoreRankListResponse),
		typeof(GetPvPScoreRankListRequest),
		typeof(GetPvPRankBattleRecordsResponse),
		typeof(GetPvPRankBattleRecordsRequest),
		typeof(GetSimplePvPRankListResponse),
		typeof(GetSimplePvPRankListRequest),
		typeof(GetPVPRankSeasonInfoResponse),
		typeof(GetPVPRankSeasonInfoRequest),
		typeof(PVPRankSeasonChooseZoneResponse),
		typeof(PVPRankSeasonChooseZoneRequest),
		typeof(GetDecorativeObjectsResponse),
		typeof(GetDecorativeObjectsRequest),
		typeof(ProfileChangeNicknameResponse),
		typeof(ProfileChangeNicknameRequest),
		typeof(ProfileChangeAvatarRequest),
		typeof(ProfileChangeAvatarResponse),
		typeof(UseDecorativeObjectsRequest),
		typeof(UseDecorativeObjectsResponse),
		typeof(GetCurrentPvPRankGameResponse),
		typeof(GetCurrentPvPRankGameRequest),
		typeof(PvPRankGame),
		typeof(GetDynamicLimitedTimeTotalRechargeItemsRequest),
		typeof(GetDynamicLimitedTimeTotalRechargeItemsResponse),
		typeof(ClaimDynamicActivityLTTRRequest),
		typeof(ClaimDynamicActivityLTTRResponse),
		typeof(GetDynamicDiscountActivityItemsResponse),
		typeof(GetDynamicDiscountActivityItemsRequest),
		typeof(SimpleDynamicPromotionActivity),
		typeof(GetDynamicSigninActivityItemsResponse),
		typeof(GetDynamicSigninActivityItemsRequest),
		typeof(SimpleDynamicSigninActivity),
		typeof(GetDynamicStarKeyStoreExchangeBonusWithKeyRequest),
		typeof(GetDynamicStarKeyStoreExchangeBonusWithKeyResponse),
		typeof(GetDynamicStarKeyStoreExchangeKeyRequest),
		typeof(GetDynamicStarKeyStoreExchangeKeyResponse),
		typeof(GetDynamicStarKeyStoreIsNewPeriodRequest),
		typeof(GetDynamicStarKeyStoreIsNewPeriodResponse),
		typeof(GetDynamicStarKeyStoreRequest),
		typeof(GetDynamicStarKeyStoreResponse),
		typeof(JsonActivityData),
		typeof(GetDynamicCardPoolRequest),
		typeof(GetDynamicCardPoolResponse),
		typeof(SimpleDynamicCardPoolActivity),
		typeof(UserProfile),
		typeof(UserProfileAvatar),
		typeof(GvGMode3ProfileModel),
		typeof(ArchiveExtension_DecorativeObjects.DecorativeObjects),
		typeof(ArchiveExtension_DecorativeObjects.ListDecorativeObjects),
		typeof(ShipCanDestroyStatus),
		typeof(GetBBSKeyRequest),
		typeof(GetBBSKeyResponse),
		typeof(DrawOuterTechRequest),
		typeof(DrawOuterTechResponse),
		typeof(ExchangeOuterTechRequest),
		typeof(ExchangeOuterTechResponse),
		typeof(GetOuterTechGiftRequest),
		typeof(GetOuterTechGiftResponse),
		typeof(GetOuterTechSpeedPlanRequest),
		typeof(GetOuterTechSpeedPlanResponse),
		typeof(ClaimOuterTechSpeedPlanRequest),
		typeof(ClaimOuterTechSpeedPlanResponse),
		typeof(GetPvPTopTournamentFormationRequest),
		typeof(GetPvPTopTournamentFormationResponse),
		typeof(SetPvPTopTournamentFormationRequest),
		typeof(SetPvPTopTournamentFormationResponse),
		typeof(RankBattleTopTournamentConfig),
		typeof(SoldierWithLegendItemId),
		typeof(ClaimPvPRankScoreResponse),
		typeof(ClaimPvPRankScoreRequest),
		typeof(GetPvPTopTournamentRankRequest),
		typeof(GetPvPTopTournamentRankResponse),
		typeof(GetPvPTopTournamentRecordRequest),
		typeof(GetPvPTopTournamentRecordResponse),
		typeof(GetPvPTopTournamentPlayersInfoRequest),
		typeof(GetPvPTopTournamentPlayersInfoResponse),
		typeof(GetPvPTopTournamentRecordSinglePlayerRequest),
		typeof(GetPvPTopTournamentRecordSinglePlayerResponse),
		typeof(GetPvPTopTournamentReplayRequest),
		typeof(GetPvPTopTournamentReplayResponse),
		typeof(GetTreasureHuntBossInsuranceRequest),
		typeof(GetTreasureHuntBossInsuranceResponse),
		typeof(GetPvPRankLastTurnResultRequest),
		typeof(GetPvPRankLastTurnResultResponse),
		typeof(GetPvPRankLastTurnLastDayResultRequest),
		typeof(GetPvPRankLastTurnLastDayResultResponse),
		typeof(GetPvPRankLastTurnLastDayDetailsResultRequest),
		typeof(GetPvPRankLastTurnLastDayDetailsResultResponse),
		typeof(GetPvPRankLastTurnLastDaySinglePlayerRecordResultRequest),
		typeof(GetPvPRankLastTurnLastDaySinglePlayerRecordResultResponse),
		typeof(GetFriendsApplyInfoRequest),
		typeof(GetFriendsApplyInfoResponse),
		typeof(FriendsApplyProto),
		typeof(BattlePassActivityClaimRequest),
		typeof(BattlePassActivityClaimResponse),
		typeof(SendFriendsApplyRequest),
		typeof(SendFriendsApplyResponse),
		typeof(ModifyFriendsApplyRequest),
		typeof(ModifyFriendsApplyResponse),
		typeof(NewbieGACHAResponse),
		typeof(NewbieGACHARequest),
		typeof(InformWatchingReplayResponse),
		typeof(InformWatchingReplayRequest),
		typeof(InformWatchingPvPRankReplayResponse),
		typeof(InformWatchingPvPRankReplayRequest),
		typeof(InformWatchingStoryMainReplayResponse),
		typeof(InformWatchingStoryMainReplayRequest),
		typeof(GetAllSoldiersCombatPowerResponse),
		typeof(GetAllSoldiersCombatPowerRequest),
		typeof(GetUserProfileUrlResponse),
		typeof(GetUserProfileUrlRequest),
		typeof(GetOAIDCertPemResponse),
		typeof(GetOAIDCertPemRequest),
		typeof(GetPvPRankLastTurnLast10SelfRankRecordResponse),
		typeof(GetPvPRankLastTurnLast10SelfRankRecordRequest),
		typeof(VerifyIdentityTapTapResponse),
		typeof(VerifyIdentityTapTapRequest),
		typeof(VerifyIdentityTapTapV4Response),
		typeof(VerifyIdentityTapTapV4Request),
		typeof(VerifyIdentityBilibiliResponse),
		typeof(VerifyIdentityBilibiliRequest),
		typeof(VerifyIdentityXipuRequest),
		typeof(VerifyIdentityXipuResponse),
		typeof(BroadcastGroupInfo),
		typeof(BroadcastGroupInitInfo),
		typeof(BroadcastGroupUpdateInfo),
		typeof(BroadcastGroupDetailInfo),
		typeof(MarchingCommandInfo),
		typeof(FightingCommandInfo),
		typeof(Shift.Legion.GvGServer.Models.WorldBossSocket.UnitInfo_Protocol),
		typeof(GetNeutralInstanceRequest),
		typeof(GetNeutralInstanceResponse),
		typeof(GetNeutralInstanceAdInfoRequest),
		typeof(GetNeutralInstanceAdInfoResponse),
		typeof(NoviceRechargeRequest),
		typeof(NoviceRechargeResponse),
		typeof(NoviceRechargeBonusClaimRequest),
		typeof(NoviceRechargeBonusClaimResponse),
		typeof(GetTreasureHouseRechargeInfoRequest),
		typeof(GetTreasureHouseRechargeInfoResponse),
		typeof(TreasureHouseBonusClaimRequest),
		typeof(TreasureHouseBonusClaimResponse),
		typeof(GetDynamicSecretTreasuryRequest),
		typeof(GetDynamicSecretTreasuryResponse),
		typeof(SecretTreasuryBonus),
		typeof(DateTimeOffset),
		typeof(ClaimDynamicSecretTreasuryRequest),
		typeof(ClaimDynamicSecretTreasuryResponse),
		typeof(GetDynamicWorldBossRequest),
		typeof(GetDynamicWorldBossResponse),
		typeof(GetDynamicIslandComeAgainRequest),
		typeof(GetDynamicIslandComeAgainResponse),
		typeof(ClaimIslandComeAgainDailyMissionBonusRequest),
		typeof(ClaimIslandComeAgainDailyMissionBonusResponse),
		typeof(GetDynamicIslandComeAgainRewardRequest),
		typeof(GetDynamicIslandComeAgainRewardResponse),
		typeof(ActivateStoryRequest),
		typeof(ActivateStoryResponse),
		typeof(DynamicIslandComeAgainExchangeRequest),
		typeof(DynamicIslandComeAgainExchangeResponse),
		typeof(GvGGetShipRecordsRequest),
		typeof(GvGGetShipRecordsResponse),
		typeof(GvGShipRecord),
		typeof(GvGShipRecords),
		typeof(GetGvGBattleResultResponse),
		typeof(GvG2.Common.Models.WBKeyInfo),
		typeof(Shift.Legion.GvGServer.Models.Map.WBKeyInfo),
		typeof(GvGBossHealthInfo),
		typeof(DamageInfo),
		typeof(CheckReviewPointRequest),
		typeof(CheckReviewPointResponse),
		typeof(StatsTapTapReviewRequest),
		typeof(StatsTapTapReviewResponse),
		typeof(StatsAppStoreReviewRequest),
		typeof(StatsAppStoreReviewResponse),
		typeof(CheckMissionStatusRequest),
		typeof(CheckMissionStatusResponse),
		typeof(SetAsNewGuideModeRequest),
		typeof(SetAsNewGuideModeResponse),
		typeof(GetMissionOf7Foreign.Request),
		typeof(GetMissionOf7Foreign.Response),
		typeof(ClaimMissionOf7Foreign.Request),
		typeof(ClaimMissionOf7Foreign.Response),
		typeof(GetCreateAccountDay.Request),
		typeof(GetCreateAccountDay.Response),
		typeof(TreasureHuntBattleFormationConfig),
		typeof(GetTreasureHuntBattlePresetFormationResponse),
		typeof(GetTreasureHuntBattlePresetFormationRequest),
		typeof(SetTreasureHuntBattlePresetFormationResponse),
		typeof(SetTreasureHuntBattlePresetFormationRequest),
		typeof(C2S_GetEOIEntitiesInfo),
		typeof(GvG2.Common.Models.FlightSchedule),
		typeof(IslandSummary),
		typeof(IslandCampSummary),
		typeof(C2S_GetShipSummaryAndFlightScheduleInfo),
		typeof(ShipSummaryUnitInfo),
		typeof(GvGMode2ShipFillUpResponse),
		typeof(GvGMode2ShipFillUpRequest),
		typeof(Shift.Legion.GvG.Common.GvGMode2Island.EntityInfo),
		typeof(Shift.Legion.GvG.Common.GvGMode2Island.EntityKeyInfo),
		typeof(GvGMode2BattleResult),
		typeof(GvGMode2BattleReportBattleRecord),
		typeof(UserIslandEntityBattleRecordSummary),
		typeof(GvGMode2GetBattleRecordsResponse),
		typeof(GvGMode2GetBattleRecordsRequest),
		typeof(GvGMode2GetUserIZBattleSummaryResponse),
		typeof(GvGMode2GetUserIZBattleSummaryRequest),
		typeof(SyncPendingReceiptsRequest),
		typeof(SyncPendingReceiptsResponse),
		typeof(Blueprint),
		typeof(LegendItemBlueprintGetResponse),
		typeof(LegendItemBlueprintGetRequest),
		typeof(LegendItemEvolvedByBlueprintResponse),
		typeof(LegendItemEvolvedByBlueprintRequest),
		typeof(LockLegendItemBlueprintRequest),
		typeof(LockLegendItemBlueprintResponse),
		typeof(SplitBlueprintRequest),
		typeof(SplitBlueprintResponse),
		typeof(UpdateSoldierMythResponse),
		typeof(UpdateSoldierMythRequest),
		typeof(OpenSoldierMythResponse),
		typeof(OpenSoldierMythRequest),
		typeof(CheckLegendItemSlotResponse),
		typeof(CheckLegendItemSlotRequest),
		typeof(GetRecallPlayerDynamicActivityRequest),
		typeof(GetRecallPlayerDynamicActivityResponse),
		typeof(ClaimRecallPlayerRequest),
		typeof(ClaimRecallPlayerResponse),
		typeof(GvGMode3RoomOperationDiabledResponse),
		typeof(GvGMode3RoomOperationDiabledRequest),
		typeof(GvGMode3AcceptShipRequest),
		typeof(GvGMode3AcceptShipResponse),
		typeof(GvGMode3BuildShipRequest),
		typeof(GvGMode3BuildShipResponse),
		typeof(GvGMode3DestroyShipRequest),
		typeof(GvGMode3DestroyShipResponse),
		typeof(GvGMode3ShipChangeOrderRequest),
		typeof(GvGMode3ShipChangeOrderResponse),
		typeof(UpdateGVGStoreLimitedFormulasRequest),
		typeof(UpdateGVGStoreLimitedFormulasResponse),
		typeof(UseGVGStoreFormulaRequest),
		typeof(UseGVGStoreFormulaResponse),
		typeof(GetGvGStoreroomStockLimitRequest),
		typeof(GetGvGStoreroomStockLimitResponse),
		typeof(GetGvGStoreItemsRequest),
		typeof(GetGvGStoreItemsResponse),
		typeof(GetGvGMode3DescriptionsRequest),
		typeof(GetGvGMode3DescriptionsResponse),
		typeof(GetGvGStoreInfoRequest),
		typeof(GetGvGStoreInfoResponse),
		typeof(GetGvGStoreGuaranteedItemsRequest),
		typeof(GetGvGStoreGuaranteedItemsResponse),
		typeof(ExchangeGvGStoreGuaranteedTicketRequest),
		typeof(ExchangeGvGStoreGuaranteedTicketResponse),
		typeof(GetGvGMode3ProcessByIZConfigIdRequest),
		typeof(GetGvGMode3ProcessByIZConfigIdResponse),
		typeof(GvGMode3ChangeShipConfigRequest),
		typeof(GvGMode3ChangeShipConfigResponse),
		typeof(GvGMode3LoadDefaultFormationRequest),
		typeof(GvGMode3LoadDefaultFormationResponse),
		typeof(GvGMode3JoinShipToRoomRequest),
		typeof(GvGMode3JoinShipToRoomResponse),
		typeof(GvGMode3ShipGetRecordRequest),
		typeof(GvGMode3ShipGetRecordResponse),
		typeof(GvGMode3SignUpActionRequest),
		typeof(GvGMode3SignUpActionResponse),
		typeof(GvGMode3UnitInfo),
		typeof(EOI_ShipInfo),
		typeof(HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model.FlightSchedule),
		typeof(ShipPlanStatusInfo),
		typeof(GvGMode3GetShipSummaryAndFlightScheduleInfo),
		typeof(GvGMode3IslandEntityInfo),
		typeof(RItem),
		typeof(TalentRItem),
		typeof(RItemInt),
		typeof(SyncGvGProduceRequest),
		typeof(SyncGvGProduceResponse),
		typeof(GvGMode3IslandDetailInfo),
		typeof(GvGMode3IslandDetailInfo_PlayerInfos),
		typeof(CollectingStockModel),
		typeof(HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.UnitInfo_Protocol),
		typeof(IslandBossInfo),
		typeof(GetCollectingInfoRequest),
		typeof(GetCollectingInfoResponse),
		typeof(RealTimeCollectingEfficiencyModel),
		typeof(RealTimeShipSummarySpeedModel),
		typeof(RealTimeFoodCostReduceModel),
		typeof(CollectingInfo),
		typeof(CollectingItemInfo),
		typeof(CollectingInfoPerShip),
		typeof(RealTimeStorehouseLimitParModel),
		typeof(RealTimeCombatPowerModel),
		typeof(RealTime火力支援MaxTimeOfUsageModel),
		typeof(DailySuppressBonusModel),
		typeof(DailySuppressBonusTimesPerZone),
		typeof(IslandLogBrief_Ship),
		typeof(IslandLogBrief),
		typeof(IslandLog),
		typeof(GvGMode3ChatRecord),
		typeof(C2S_GetSystemMessages_IslandBattleLog.RunningBattleLog),
		typeof(BattleLogShipInfo),
		typeof(BattleLog_Big),
		typeof(BattleLog_Small),
		typeof(RunningBattleLogItem),
		typeof(BattleRecordDetailModel),
		typeof(Shift.Legion.GvG.Common.GvGMode3Island.EntityInfo),
		typeof(Shift.Legion.GvG.Common.GvGMode3Island.EntityKeyInfo),
		typeof(GvGMode3BestKill),
		typeof(GvGMode3IslandRankInfo),
		typeof(GvGMode3BattleResult),
		typeof(GvGStateChange_Fighting),
		typeof(GvGStateChange_ForcePos),
		typeof(GvGStateChange_Holding),
		typeof(GvGStateChange_InReborn),
		typeof(IslandBuff),
		typeof(Shift.Legion.GvG.Common.Models.GvGMode3.Ability),
		typeof(ForgedExtraAmplifier),
		typeof(ForgedExtraItem),
		typeof(RealTimeAmplifierTalentModel),
		typeof(FlagShipReqMission_ToProtocol),
		typeof(OemMissionToProtocol),
		typeof(SelfOEMMission_ToProtocol),
		typeof(OEMGiverBonus),
		typeof(OEMTakerBonus),
		typeof(OEMGiverClaimBonus),
		typeof(GetStoreContentConfigRequest),
		typeof(GetStoreContentConfigResponse),
		typeof(GetDynamicCardPoolActivityRequest),
		typeof(GetDynamicCardPoolActivityResponse),
		typeof(DrawDynamicCardPoolRequest),
		typeof(DrawDynamicCardPoolResponse),
		typeof(ClaimDynamicCardPoolBonusRequest),
		typeof(ClaimDynamicCardPoolBonusResponse),
		typeof(OEMMissionState_ToProtocol),
		typeof(ContributionBoxConfig),
		typeof(GvGMode3IslandEvents),
		typeof(IslandEventInfo),
		typeof(IEvent_伟大航路),
		typeof(IEvent_额外发现),
		typeof(IEvent_火力支援),
		typeof(CampEnergyDetailInfo),
		typeof(CampUserInfo),
		typeof(MissionStateRecordWithProgress),
		typeof(CampMainProgress),
		typeof(IEvent_TreasureMap),
		typeof(IEvent_TreasureMap_FindIslandBase),
		typeof(IEvent_TreasureMap_FindIsland),
		typeof(IEvent_RandomEvent_Base),
		typeof(TreasureMapInfo),
		typeof(NPCShopModel_ToProtocol),
		typeof(LastestBuyRecord),
		typeof(GvGMode3PlayerRankInfo),
		typeof(GvGMode3PlayerRankDataDetail),
		typeof(GvGMode3LeaderboardData),
		typeof(IEvent_PlayerCommand),
		typeof(GvGMode3CampRankInfo),
		typeof(C2S_GetFinalProgressInfo.FinalProgressBossInfo),
		typeof(FinalProgressBossDamageInfo),
		typeof(GvGMode3ClaimSettlementRequest),
		typeof(GvGMode3ClaimSettlementResponse),
		typeof(GvGMode3CloseLastIZRequest),
		typeof(GvGMode3CloseLastIZResponse),
		typeof(GvGMode3GetIZSettlementRecordRequest),
		typeof(GvGMode3GetIZSettlementRecordResponse),
		typeof(GvGMode3CloseBattlePassResponse),
		typeof(GvGMode3CloseBattlePassRequest),
		typeof(GvGMode3ClaimBattlePassBonusResponse),
		typeof(GvGMode3ClaimBattlePassBonusRequest),
		typeof(GvGMode3GetBattlePassDataResponse),
		typeof(GvGMode3GetBattlePassDataRequest),
		typeof(IslandDataVersionModel),
		typeof(GvGMode3LocalIslandData),
		typeof(GvGMode3LocalIslandVersions),
		typeof(FlagShipAttackEvent),
		typeof(FlagShipStateInfo),
		typeof(GiftRedeemPreviewRequest),
		typeof(GiftRedeemPreviewResponse),
		typeof(GiftRedeemClaimRequest),
		typeof(GiftRedeemClaimResponse),
		typeof(GetGvGMedalRecordRequest),
		typeof(GetGvGMedalRecordResponse),
		typeof(GetGvGMedalRankRequest),
		typeof(GetGvGMedalRankResponse),
		typeof(ProfileChangeMedalRequest),
		typeof(ProfileChangeMedalResponse),
		typeof(GvGTalent勘探强化Manager.SaveData),
		typeof(ShipCountDown_勘探强化),
		typeof(IslandResource_勘探强化),
		typeof(GvGAnnouncement),
		typeof(OuterTechModel),
		typeof(RealTimeGroupCountLimitModel),
		typeof(RealTimeFoodOnBoardModel),
		typeof(FormulaOemMissionsFilter),
		typeof(FormulaOEMMissionsSelfRecord),
		typeof(FormulaOEMMissionsDetail),
		typeof(FormulaOEMBonus),
		typeof(OEMResult),
		typeof(EOI_IslandShipInfoOnIsland),
		typeof(EOI_ShipInfoOnIsland),
		typeof(SendChatRequest),
		typeof(SendChatResponse),
		typeof(ReadMessageRequest),
		typeof(ReadMessageResponse),
		typeof(GetUnreadMessageRequest),
		typeof(GetUnreadMessageResponse),
		typeof(ChatLog),
		typeof(SoldierLegendItem),
		typeof(TakeOutSoldierInfo),
		typeof(GvG3SettlementSoldierReturn),
		typeof(FrameBrawlReplay),
		typeof(BaseBrawlReplay),
		typeof(ScoreChangeInfo),
		typeof(BE_SignUpDataModel_ToProtocol),
		typeof(BE_SignUpDataModel_ToProtocol2),
		typeof(BE_SignUpDataModel_ToProtocol3),
		typeof(BrawlEventSettleClaimedInfo),
		typeof(IEvent_Brawl),
		typeof(IEvent_Brawl_Icon),
		typeof(BrawlEventRankRewardsConfig_ToProtocol),
		typeof(ReviewResult),
		typeof(ReviewTotal),
		typeof(CampSignUpInfo),
		typeof(BrawlCampRankInfos),
		typeof(GetRecallWelfareRequest),
		typeof(GetRecallWelfareResponse),
		typeof(RecallWelfarePrize),
		typeof(RecallWelfareMission),
		typeof(ERItem),
		typeof(DrawRecallWelfareRequest),
		typeof(DrawRecallWelfareResponse),
		typeof(ClaimRecallWelfareBonusRequest),
		typeof(ClaimRecallWelfareBonusResponse),
		typeof(RecallWelfareMissionProgress),
		typeof(RecallWelfarePacket),
		typeof(ExchangeRecallWelfareResponse),
		typeof(ExchangeRecallWelfareRequest),
		typeof(GetWeeklyActivityRequest),
		typeof(GetWeeklyActivityResponse),
		typeof(DrawSpinWeeklyRequest),
		typeof(DrawSpinWeeklyResponse),
		typeof(ExchangeSpinWeeklyRequest),
		typeof(ExchangeSpinWeeklyResponse),
		typeof(ClaimSpinWeeklyLotteryRequest),
		typeof(ClaimSpinWeeklyLotteryResponse),
		typeof(MoonBattlePassActivityClaimResponse),
		typeof(MoonBattlePassActivityClaimRequest),
		typeof(SyncDailyMissionScoreResponse),
		typeof(SyncDailyMissionScoreRequest),
		typeof(GetQQInfoRequest),
		typeof(GetQQInfoResponse),
		typeof(GetQQDawankaInfoRequest),
		typeof(GetQQDawankaInfoResponse),
		typeof(QQClaimRequest),
		typeof(QQClaimResponse),
		typeof(QQClaimDawankaRequest),
		typeof(QQClaimDawankaResponse),
		typeof(QQGameRecord),
		typeof(DawankaBonusClaimRecord),
		typeof(QQDawankaInfo),
		typeof(VerifyIdentityQQGameRequest),
		typeof(VerifyIdentityQQGameResponse),
		typeof(GetShadowDemonActivityRequest),
		typeof(GetShadowDemonActivityResponse),
		typeof(WarOfRealmClaimRequest),
		typeof(WarOfRealmClaimResponse),
		typeof(WarOfRealmGetInfoRequest),
		typeof(WarOfRealmGetInfoResponse),
		typeof(GetWarOfRealmFormationRequest),
		typeof(GetWarOfRealmFormationResponse),
		typeof(SetWarOfRealmFormationRequest),
		typeof(SetWarOfRealmFormationResponse),
		typeof(WarOfRealmClaimMissionBonusRequest),
		typeof(WarOfRealmClaimMissionBonusResponse),
		typeof(WarOfRealmClaimRankBonusRequest),
		typeof(WarOfRealmClaimRankBonusResponse),
		typeof(WarOfRealmGetStageRecordRequest),
		typeof(WarOfRealmGetStageRecordResponse),
		typeof(WarOfRealmGetWarBattleRecordRequest),
		typeof(WarOfRealmGetWarBattleRecordResponse),
		typeof(WarOfRealmLotteryRequest),
		typeof(WarOfRealmLotteryResponse),
		typeof(WarOfRealmSettlementRequest),
		typeof(WarOfRealmSettlementResponse),
		typeof(WarOfRealmGetStageBattleRecordRequest),
		typeof(WarOfRealmGetStageBattleRecordResponse),
		typeof(WarOfRealmReplayRequest),
		typeof(WarOfRealmReplayResponse),
		typeof(WarOfRealmGetScoreHistoryRequest),
		typeof(WarOfRealmGetScoreHistoryResponse),
		typeof(GetAccessoryInfoRequest),
		typeof(GetAccessoryInfoResponse),
		typeof(EquipAccessoryRequest),
		typeof(EquipAccessoryResponse)
	};

	private static Dictionary<string, Action<object[]>> DicResponse = new Dictionary<string, Action<object[]>>
	{
		{ "OnReplayDownloaded", Response_OnReplayDownloaded },
		{ "OnReplayDownloaded_False", Response_OnReplayDownloaded_False },
		{ "OnReplayDownloaded_True", Response_OnReplayDownloaded_True },
		{ "LoadAssetAsync_Sucess", LoadAssetAsync_Sucess },
		{ "SyncUnityGameObjectPool", SyncUnityGameObjectPool },
		{ "CameraFollowUnitSystem_TargetX", CameraFollowUnitSystem_TargetX },
		{ "OnApplicationFocus", _OnApplicationFocus },
		{ "OnApplicationPause", _OnApplicationPause },
		{ "OnApplicationQuit", _OnApplicationQuit },
		{ "InvokedFromAndroid", _InvokedFromAndroid },
		{ "AliPayResult", _AliPayResult },
		{ "SyncInterestedSoldierInfo", SyncInterestedSoldierInfo },
		{ "InvokedFromIOS", _InvokedFromIOS }
	};

	private static Dictionary<string, Func<object[], object>> DicResponseWithVal = new Dictionary<string, Func<object[], object>>
	{
		{ "AnimationManager_IsCurrentAnimationLoop", AnimationManager_IsCurrentAnimationLoop },
		{ "GameEntityData_GetEntityTags", GameEntityData_GetEntityTags },
		{ "GameParticleModel_FullScreenPos", GameParticleModel_FullScreenPos },
		{ "Get_Translate_Particle_Info", Get_Translate_Particle_Info },
		{ "Get_BattleModelQualityString", Get_BattleModelQualityString },
		{ "Get_BattleModelQualityScaleLimit", Get_BattleModelQualityScaleLimit }
	};

	[STAThread]
	public static void Init()
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		Screen.orientation = (ScreenOrientation)5;
		Application.targetFrameRate = UiHelper.FrameRate;
		if (!PlayerPrefs.HasKey("BattleModelQualityStringSetting"))
		{
			if (SystemInfo.operatingSystem.IndexOf("iOS") >= 0)
			{
				if (SystemInfo.systemMemorySize > 2500)
				{
					HotFix_Utils.SetBattleModelQualityStringSetting("");
				}
				else
				{
					HotFix_Utils.SetBattleModelQualityStringSetting("_low");
				}
			}
			else if (SystemInfo.systemMemorySize > 3500)
			{
				HotFix_Utils.SetBattleModelQualityStringSetting("");
			}
			else
			{
				HotFix_Utils.SetBattleModelQualityStringSetting("_low");
			}
		}
		RegistDelegate();
		ProtoBuf_RegisterType();
		GameObject val = new GameObject();
		((Object)val).name = "HotFix.StartUp";
		val.AddComponent<HotUpdateProcess>();
		Object.DontDestroyOnLoad((Object)(object)val);
	}

	private static void RegistDelegate()
	{
		HotFixManager.Instance.appdomain.DelegateManager.RegisterMethodDelegate<AsyncOperationHandle<IList<TextAsset>>>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterMethodDelegate<AsyncOperationHandle<GameObject>>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterMethodDelegate<ILTypeInstance, bool>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterMethodDelegate<ILTypeInstance, ILTypeInstance>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterMethodDelegate<AsyncOperationHandle<SkeletonDataAsset>>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterMethodDelegate<AsyncOperationHandle<Texture2D>>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterMethodDelegate<(SkeletonDataAsset, Action)>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterFunctionDelegate<KeyValuePair<string, ILTypeInstance>, int>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterMethodDelegate<byte[]>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterFunctionDelegate<IEnumerator>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterFunctionDelegate<Task>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterFunctionDelegate<KeyValuePair<string, ILTypeInstance>, ILTypeInstance>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterFunctionDelegate<KeyValuePair<string, ILTypeInstance>, bool>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterMethodDelegate<GameObject, bool>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterMethodDelegate<List<int>>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterFunctionDelegate<KeyValuePair<int, List<ILTypeInstance>>, string>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterFunctionDelegate<KeyValuePair<int, List<ILTypeInstance>>, List<ILTypeInstance>>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterFunctionDelegate<KeyValuePair<string, List<ILTypeInstance>>, int>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterFunctionDelegate<KeyValuePair<string, List<ILTypeInstance>>, List<ILTypeInstance>>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterFunctionDelegate<KeyValuePair<string, int>, string>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterFunctionDelegate<ILTypeInstance, KeyValuePair<string, int>>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterFunctionDelegate<string, string>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterFunctionDelegate<AssetBundle, AssetBundle>();
		HotFixManager.Instance.appdomain.DelegateManager.RegisterFunctionDelegate<AssetBundle, string>();
	}

	private static void ProtoBuf_RegisterType()
	{
		foreach (SocketManager.MapPackageIdTypes value in SocketManager.Map_PackageId_PackageIdTypes.Values)
		{
			Protobuf_Type.Add(value.Request);
			Protobuf_Type.Add(value.Response);
		}
		Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
		for (int i = 0; i < Protobuf_Type.Count; i++)
		{
			dictionary.Add(Protobuf_Type[i].FullName, Protobuf_Type[i]);
		}
		Protobuf_ILRuntime_Init.RegisterTypeBatch(dictionary);
	}

	public static void Response(string _cmd, params object[] _params)
	{
		DicResponse[_cmd](_params);
	}

	private static void CameraFollowUnitSystem_TargetX(object[] _params)
	{
		float redTeamTargetX = (float)_params[0];
		PlayFrameService.GetInstance().SetRedTeamTargetX(redTeamTargetX);
	}

	private static void _OnApplicationFocus(object[] _params)
	{
		FGUIManager.Instance?.FGUI_OnApplicationFocus((bool)_params[0]);
	}

	private static void _OnApplicationPause(object[] _params)
	{
		FGUIManager.Instance?.FGUI_OnApplicationPause((bool)_params[0]);
	}

	private static void _OnApplicationQuit(object[] _params)
	{
		FGUIManager.Instance?.FGUI_OnApplicationQuit();
	}

	private static void _InvokedFromAndroid(object[] _params)
	{
		SDKHelper.InvokedFromAndroid(_params[0].ToString());
	}

	private static void _InvokedFromIOS(object[] _params)
	{
		SDKHelper.InvokedFromIOS(_params[0].ToString());
	}

	private static void _AliPayResult(object[] _params)
	{
		PurchaseManager.Instance.AliPayResult(_params[0].ToString());
	}

	private static void SyncInterestedSoldierInfo(object[] _params)
	{
		int entityId = (int)_params[0];
		long totalDamage = (long)_params[1];
		int hpCount = (int)_params[2];
		GameManagers.Instance.Messenger.Broadcast("UPDATE_GVG_RECORD_WORLD_BOSS_INFO", new GvGBossHealthInfo
		{
			EntityId = entityId,
			TotalDamage = totalDamage,
			HpCount = hpCount
		});
	}

	private static void Response_OnReplayDownloaded(object[] _params)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		string text = (string)_params[0];
		BattleReplay replay = (BattleReplay)_params[1];
		if (QuickPlayReplayService.info.BattleId == text)
		{
			QuickPlayReplayService.Instance.Add_Index_Downloading(replay);
		}
		else
		{
			GameController.Contexts.Service<ReplayPlayerService>().OnReplayDownloaded(text, replay);
		}
	}

	private static void Response_OnReplayDownloaded_False(object[] _params)
	{
		string text = (string)_params[0];
		if (QuickPlayReplayService.info.BattleId == text)
		{
			QuickPlayReplayService.Instance.TryDownloadReplay();
		}
		else
		{
			GameController.Contexts.Service<ReplayPlayerService>().SetDownloading(b: false);
		}
	}

	private static void Response_OnReplayDownloaded_True(object[] _params)
	{
		GameController.Contexts.Service<ReplayPlayerService>().SetDownloading(b: true);
	}

	private static void LoadAssetAsync_Sucess(object[] _params)
	{
		GameController.Contexts.Service<IGameDataService>().LoadGameDataSucess((byte[])_params[0]);
	}

	private static void SyncUnityGameObjectPool(object[] _params)
	{
	}

	public static object ResponseWithVal(string _cmd, params object[] _params)
	{
		return DicResponseWithVal[_cmd](_params);
	}

	private static object GameEntityData_GetEntityTags(object[] _params)
	{
		List<string> entityTags = GameEntityData.GetEntityTags((string)_params[0]);
		return entityTags.ToArray();
	}

	private static object GameParticleModel_FullScreenPos(object[] _params)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		string text = _params[0].ToString();
		bool flag = true;
		SharedMessenger.Broadcast("ON_FULL_SCREEN_EFFECT_SHOW", text);
		Dictionary<string, Vector3> fullScreenParticlePos = GameController.Contexts.Service<ReplayPlayerService>().Get_FullScreenParticlePos();
		if (fullScreenParticlePos.ContainsKey(text))
		{
			return fullScreenParticlePos[text];
		}
		return null;
	}

	private static object Get_Translate_Particle_Info(object[] _params)
	{
		return GameController.Contexts.Service<ReplayPlayerService>().Get_Translate_Particle_Info();
	}

	private static object Get_BattleModelQualityString(object[] _params)
	{
		return HotFix_Utils.GetBattleModelQualityStringSetting();
	}

	private static object Get_BattleModelQualityScaleLimit(object[] _params)
	{
		return 1.5f;
	}

	private static object AnimationManager_IsCurrentAnimationLoop(object[] _params)
	{
		AnimationName key = (AnimationName)_params[0];
		Dictionary<AnimationName, GDEAnimationData> animationsForModel = Singleton<AnimationManager>.Instance.GetAnimationsForModel((string)_params[1]);
		if (animationsForModel == null)
		{
			return true;
		}
		if (animationsForModel.ContainsKey(key))
		{
			return animationsForModel[key].Loop;
		}
		return true;
	}
}
