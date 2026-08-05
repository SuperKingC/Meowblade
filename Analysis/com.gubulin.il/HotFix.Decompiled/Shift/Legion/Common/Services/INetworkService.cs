using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol;
using HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol.UserAction;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.Archive;
using Shift.Legion.ClientApi.Protocol.Friends;
using Shift.Legion.ClientApi.Protocol.Mailing;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItemEnhancement;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierItemSlot;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierLegendItem;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.RPC;
using Shift.Legion.ClientApi.RPC.Api;
using Shift.Legion.ClientApi.Sources.Protocol;
using Shift.Legion.ClientApi.Sources.Protocol.FriendsChat;
using Shift.Legion.ClientApi.Sources.Protocol.UserAction;
using Shift.Legion.ClientApi.Sources.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Model;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.Common.Services;

public interface INetworkService : IService
{
	void AddLoginCompleteHandler(EventHandler<LoginResponse> handler);

	void RemoveLoginCompleteHandler(EventHandler<LoginResponse> handler);

	void AddLoginFailHandler(EventHandler<object> handler);

	void RemoveLoginFailHandler(EventHandler<object> handler);

	void ClearCookie();

	void SetToken(string token);

	void SaveToken(string token);

	bool IsStop();

	string GetToken();

	Task<UserDeviceInfoResponse> SubmitDeviceInfo(DeviceInfo info);

	Task SubmitDeviceIdentifier(string deviceIdentifier, string idfa);

	Task SubmitDeviceLog(GameEvent gameEvent, string deviceIdentifier, Dictionary<string, string> content = null);

	void Update();

	void Stop();

	void Resume();

	RPCConnection.WaitingGamePacket[] GetWaitingGamePackets();

	Task<GetOaidCertTextResult> GetOaidCertTextOperation(long timestamp);

	Task<UserLoginCredentialsResult> GetUserCredentialsAsync(string TypeStr, string Value, string zone);

	Task<CredentialsOperationResult> UserCredentialsOperation(string typeStr, UserLoginCredentialsOperation op, int userId);

	Task<UserLoginCredentialsResult> GetUserCredentialsOperation(string typeStr, int userId);

	void GetCredentialTypeAndValue(string jsonUserInfo, string platformType, out string typeString, out string credentialVal);

	string GetCredentialValueByTypeStr(string jsonUserInfo, string typeStr);

	Task Authenticate(string name, string pwd, IdentityType identityType = IdentityType.Nickname);

	Task<UserTokenInfo> AuthenticateAsync(string name, string pwd, IdentityType identityType, int userId);

	Task AuthenticateByPlatform(string jsonUserInfo, string platformType, string channelCode);

	Task<UserTokenInfo> AuthenticateByPlatformAsync(string jsonUserInfo, string platformType, int userId, string channelCode);

	Task WechatLoginByCode(string code, string channelCode);

	Task<string> GetWechatQRCodeSignature(string nonceStr, string timestamp);

	Task<LoginResponse> Login(string token);

	Task<PreCheckResponse> PreCheck();

	void Logout();

	Task<GetServerStatusResponse> GetServerStatus();

	Task<EnterGameResponse> EnterGame();

	Task GetAnnouncements();

	Task<PullDataResponse> PullData();

	Task<MailListResponse> GetMails();

	Task<bool> MarkMailAsRead(int mailId);

	Task<bool> MarkAllMailsAsRead();

	Task<bool> DeleteMail(int mailId);

	Task<bool> DeleteAllMails();

	Task<MailOperateResponse> ClaimMailPayload(int mailId);

	Task<MailOperateResponse> ClaimAllMailsPayload();

	Task<GvGGetSelfShipCountResponse> GvGGetSelfShipCount(string _IZId);

	Task<GvGClaimUserCampMissionResponse> GvGClaimUserCampMission(string _IZId, string campId, string missionId);

	Task<GvGGetIZInfosResponse> GvGGetIZInfos(bool needCustomizeTables);

	Task<GvGWorldBossRecordRankingResponse> GvGWorldBossRecordRanking(string _IZId, string _WBId, string key);

	Task<GvGWorldBossRecordRanking2Response> GvGWorldBossRecordRanking2(string _IZId, string _WBId, string key);

	Task<GvGGetWorldBossInfoResponse> GvGGetWorldBossInfo(eGvGProcessType type);

	Task<GvGGetShipRecordsResponse> GvGGetShipRecords(string _IZConfigId, string _IZId, int _Idx);

	Task<GvGWorldBossGetBattleResultListResponse> GvGWorldBossGetBattleResultList();

	Task<GvGWorldBossStartBattleResponse> GvGWorldBossStartBattle(string wbId, string formationId, List<string> soldierIds, string _IZId);

	Task<GvGGetWorldBossKeyInfoResponse> GvGGetWorldBossKeyInfo(string _IZId);

	Task<DownloadArchiveResponse> DownloadArchive();

	Task<SetAsNewGuideModeResponse> SetAsNewGuideMode();

	Task<GetMissionOf7Foreign.Response> GetMissionOf7ForeignRequest();

	Task<ClaimMissionOf7Foreign.Response> ClaimMissionOf7Foreign(int score, bool isAdvance);

	Task<GetCreateAccountDay.Response> GetCreateAccountDay();

	Task<PlayStoryResponse> PlayStory(long tick, string storyId);

	Task<TriggerStoryResponse> TriggerStory(long tick, string storyKey);

	Task<SkipCurrentStoryResponse> SkipCurrentStory(long tick, string uiName);

	Task<ChangeCampProduceConfigResponse> ChangeCampProduceConfig(long tick, Dictionary<int, string> config);

	Task<ChangeWorkshopProduceConfigResponse> ChangeWorkshopProduceConfig(long tick, string buildingType, Dictionary<int, int> workers, Dictionary<int, List<string>> products);

	Task<ChangeStrongholdProduceConfigResponse> ChangeStrongholdProduceConfig(long tick, string strongholdId, string soldierId);

	Task<ChangeFormationResponse> ChangeFormation(long tick, string ctx, string mode, string formationId);

	Task<ChangeFormationUnitResponse> ChangeFormationUnit(long tick, string ctx, string mode, int portalId, string unitId);

	Task<SyncFormationUnitsResponse> SyncFormationUnits(long tick, string ctx, string mode, List<string> unitsId);

	Task<SyncRankFormationUnitsResponse> SyncRankFormationUnits(long tick, List<string> formationsId, List<List<string>> unitsId);

	Task<SetFormationUnitsOfRankResponse> SetFormationUnitsOfRank(int rank, List<string> formationsId, List<List<string>> unitsId);

	Task<UpgradeBuildingResponse> UpgradeBuilding(long tick, string buildingType, int workers, List<UserData> data);

	Task<FinishUpgradeBuildingResponse> FinishUpgradeBuilding(long tick, string buildingType);

	Task<GetFormationInfoResponse> GetFormationInfo(long tick, string levelId);

	Task<CheckCanQuickBattleResponse> CheckCanQuickBattle(long tick, string levelId);

	Task<StartBattleResponse> StartBattle(long tick, string levelId, string formationId, string[] soldierIds, int[] nums, bool quickBattle);

	Task<DownloadBattleReplayResponse> DownloadBattleReplay(string battleId, int replayIndex);

	Task<SubmitBattleOperationResponse> SubmitBattleOperation(string battleId, int subLevelIndex, string formationId, string[] units);

	Task<RetreatResponse> Retreat(string battleId);

	Task<GetBattleResultResponse> GetBattleResult(long tick, string battleId, string currentLevelId);

	Task<GetBattleBonusResponse> GetBattleBonus(string battleId, string currentLevelId);

	Task<ConfirmBattleBonusResponse> ConfirmBattleBonus(string battleId, int selectIndex);

	Task<GetLevelReplaysResponse> GetLevelReplays(string levelId, bool random, string battleid);

	Task<RevokeBattleResponse> RevokeBattle(string battleId);

	Task<GetRecentReplaysResponse> GetRecentReplays();

	Task<CheckBattleFailedProcessResponse> CheckBattleFailedProcess(long tick, string battleId, string subLevelId);

	Task<GetGvGStoreroomStockLimitResponse> GetGvGStoreroomStockLimit(bool isLevelUp = false);

	Task<GetGvGStoreItemsResponse> GetGvGStoreItems(bool manual = false);

	Task<GetGvGStoreInfoResponse> GetGvGStoreInfo();

	Task<GetGvGStoreGuaranteedItemsResponse> GetGvGStoreGuaranteedItems();

	Task<ExchangeGvGStoreGuaranteedTicketResponse> ExchangeGvGStoreGuaranteedTicket();

	Task<UnlockRegionResponse> UnlockRegion(long tick, string regionId);

	Task<UpdateSoldierMythResponse> UpdateSoldierMyth(string soldierId, int level);

	Task<UpdateGVGStoreLimitedFormulasResponse> GetGVGStoreLimitedFormulas();

	Task<UseGVGStoreFormulaResponse> UseGVGStoreFormula(string formulaId, int inputIndex = 0, int outputIndex = 0, int storeItemIndex = 0);

	Task<OpenSoldierMythResponse> OpenSoldierMyth(string soldierId);

	Task<CheckLegendItemSlotResponse> CheckLegendItemSlot(List<string> soldierId);

	Task<UnlockFormationResponse> UnlockFormation(long tick, string formationId);

	Task<StartRankBattleResponse> StartRankBattle(long tick, int targetRank, long rankDataTimestamp, bool isQuick = false);

	Task<GetRankBattleResultResponse> GetRankBattleResult(long tick, string battleId);

	Task<GetPvPScoreRankListResponse> GetScoreRank();

	Task<GetPvPRankBattleRecordsResponse> GetRankBattleRecords(int cutoffat, int offset);

	Task<GetOAIDCertPemResponse> GetOAIDCertPem();

	Task<InformWatchingReplayResponse> InformWatchingReplay(string battleId);

	Task<GetGvGMedalRecordResponse> GetGvGMedalRecord();

	Task<GetGvGMedalRankResponse> GetGvGMedalRank(string medalId);

	Task<ProfileChangeMedalResponse> ProfileChangeMedal(string changeContext);

	Task<LegendItemBlueprintGetResponse> LegendItemBlueprintGet();

	Task<LockLegendItemBlueprintResponse> SetLockLegendItemBlueprint(string bpId, bool isLocked);

	Task<SplitBlueprintResponse> SplitBlueprint(string bpId);

	Task<LegendItemEvolvedByBlueprintResponse> LegendItemEvolvedByBlueprint(string bluePrintId, string mainId, List<string> randomIds, List<string> anyIds, List<RItem> universalLegendItem);

	Task<InformWatchingPvPRankReplayResponse> InformWatchingPvPRankReplay(string battleId);

	Task<InformWatchingStoryMainReplayResponse> InformWatchingStoryMainReplay(string battleId);

	Task<NewbieGACHAResponse> UpdateNewbieGACHAProgress(string activityId, int nextProgress, int select);

	Task<ProfileChangeNicknameResponse> GetProfileChangeNickname(string Nickname);

	Task<GetBBSKeyResponse> GetBBSKey();

	Task<DrawOuterTechResponse> DrawOuterTech(string ActivityId);

	Task<ExchangeOuterTechResponse> ExchangeOuterTech(string ActivityId, string ItemId);

	Task<GetOuterTechGiftResponse> GetOuterTechGift(string ActivityId);

	Task<GetOuterTechSpeedPlanResponse> GetOuterTechSpeedPlan();

	Task<ClaimOuterTechSpeedPlanResponse> ClaimOuterTechSpeedPlan();

	Task<GetDecorativeObjectsResponse> GetDecorativeObjects(int type);

	Task<UseDecorativeObjectsResponse> GetUseDecorativeObjects(int type, string itemid);

	Task<ProfileChangeAvatarResponse> ProfileChangeAvatar(byte[] newAvatarData132, byte[] newAvatarData450);

	Task<PvPRankAddAttackBuffResponse> AddRankAttackBuff(int addBuffCnt);

	Task<GetSimplePvPRankListResponse> GetSimplePvPRank(long tick);

	Task<GetPVPRankSeasonInfoResponse> GetPVPRankSeasonInfo(long tick);

	Task<GetPvPRankLastTurnLast10SelfRankRecordResponse> GetPvPRankLastTurnLast10SelfRankRecord(int seasonId, int turnId);

	Task<GetUserProfileUrlResponse> GetUserProfileUrl();

	Task<GetPvPTopTournamentRankResponse> GetPvPTopTournamentRankInfo();

	Task<GetPvPRankLastTurnResultResponse> GetPvPRankLastTurnResult(int seasonId, int turnId);

	Task<GetPvPTopTournamentRecordSinglePlayerResponse> GetPvPTopTournamentRecordSinglePlayer(int day, int userId);

	Task<GetPvPRankLastTurnLastDaySinglePlayerRecordResultResponse> GetPvPRankLastTurnLastDaySinglePlayerRecordResult(int userId);

	Task<GetPvPTopTournamentReplayResponse> GetPvPTopTournamentReplay(string battleId);

	Task<GetPvPRankLastTurnLastDayDetailsResultResponse> GetPvPRankLastTurnLastDayDetailsResult(string battleId);

	Task<GetPvPTopTournamentPlayersInfoResponse> GetPvPTopTournamentPlayersInfo();

	Task<GetPvPTopTournamentRecordResponse> GetPvPTopTournamentRecord(int day);

	Task<GetPvPRankLastTurnLastDayResultResponse> GetPvPRankLastTurnLastDayResult();

	Task<ClaimPvPRankScoreResponse> ClaimPvPRankScore(long tick);

	Task<GetDynamicLimitedTimeTotalRechargeItemsResponse> GetDynamicLimitedTimeTotalRechargeItems(long tick);

	Task<ClaimDynamicActivityLTTRResponse> ClaimDynamicActivityLTTR(string activityId, int RMB_Level);

	Task<GetDynamicDiscountActivityItemsResponse> GetDynamicDiscountActivityItems(long tick);

	Task<GetDynamicSigninActivityItemsResponse> GetDynamicSigninActivityData(long tick);

	Task<GetDynamicStarKeyStoreExchangeBonusWithKeyResponse> GetDynamicStarKeyStoreExchangeBonusWithKey(string ItemId, string ActivityId);

	Task<GetDynamicStarKeyStoreExchangeKeyResponse> GetDynamicStarKeyStoreExchangeKey(string FormulaId);

	Task<GetDynamicStarKeyStoreIsNewPeriodResponse> GetDynamicStarKeyStoreIsNewPeriod();

	Task<GetDynamicStarKeyStoreResponse> GetDynamicStarKeyStore();

	Task<GetDynamicCardPoolResponse> GetDynamicCardPool(long tick);

	Task<GetDynamicCardPoolActivityResponse> GetDynamicCardPoolActivities(long tick);

	Task<GetStoreContentConfigResponse> GetStoreContentConfig();

	Task<GetDynamicWorldBossResponse> GetDynamicWorldBoss(long tick);

	Task<GetDynamicIslandComeAgainResponse> GetDynamicIslandComeAgain(long tick);

	Task<GetRecallPlayerDynamicActivityResponse> GetRecallPlayerDynamicActivity();

	Task<ClaimRecallPlayerResponse> ClaimRecallPlayer(string InviteCode);

	Task<GetDynamicIslandComeAgainRewardResponse> GetDynamicIslandComeAgainReward(long tick, int prizePoolId, int prizePoolIndex);

	Task<ClaimIslandComeAgainDailyMissionBonusResponse> ClaimIslandComeAgainDailyMissionBonus(int missionId);

	Task<GetNeutralInstanceResponse> GetNeutralDungeonActivity(long tick, string activityId);

	Task<GetNeutralInstanceAdInfoResponse> GetNeutralDungeonActivityAdInfo(long tick);

	Task<NoviceRechargeResponse> GetNoviceRechargeProgress(long tick, string activityId);

	Task<NoviceRechargeBonusClaimResponse> ClaimNoviceRechargeBonus(long tick, string activityId, string score);

	Task<GetTreasureHouseRechargeInfoResponse> GetTreasureHouseRechargeInfo(long tick, string activityId);

	Task<TreasureHouseBonusClaimResponse> TreasureHouseBonusClaim(long tick, string activityId, int score);

	Task<GetDynamicSecretTreasuryResponse> GetDynamicSecretTreasury();

	Task<ClaimDynamicSecretTreasuryResponse> ClaimDynamicSecretTreasury(int level);

	Task<ActivateStoryResponse> ActivateStory(long tick, string storyId, bool playZBossExtraScene = false);

	Task<DynamicIslandComeAgainExchangeResponse> DynamicIslandComeAgainExchange(long tick);

	Task<PVPRankSeasonChooseZoneResponse> PVPRankSeasonChooseZone(long tick, int bigZoneId);

	Task<GetPvPTopTournamentFormationResponse> GetPvPTopTournamentFormation();

	Task<GetTreasureHuntBattlePresetFormationResponse> GetTreasureHuntBattlePresetFormation();

	Task<SetPvPTopTournamentFormationResponse> SetPvPTopTournamentFormation(RankBattleTopTournamentConfig formation, bool Weekend);

	Task<SetTreasureHuntBattlePresetFormationResponse> SetTreasureHuntBattlePresetFormation(TreasureHuntBattleFormationConfig formation);

	Task<PvPRankAddDefenseBuffResponse> AddDefenseBuff(int addTime);

	Task<PvPRankClearCdResponse> ClearRankCd(int addTime);

	Task<GetCurrentPvPRankGameResponse> GetCurrentPvPRankGameInfo();

	Task<GetRankListResponse> GetRankList();

	Task<GetDetailRankInfoResponse> GetDetailRankInfo(long tick, int rank, long rankDataTimestamp);

	Task<GetSelfRankResponse> GetSelfRank(long tick);

	Task<UseItemResponse> UseItem(long tick, string itemId, int qty, object context);

	Task<UpgradeItemResponse> UpgradeItem(long tick, string itemId);

	Task<PiecesCompositeResponse> PiecesComposite(long tick, string itemId, int qty);

	Task<SoulStoneMaxCompositeToResponse> SoulStoneMaxCompositeTo(long tick, string soldierId, int targetPotentialLevel);

	Task<SoldierEvoluteResponse> SoldierEvolute(long tick, string soldierId);

	Task<SoldierPotentialBreakthroughResponse> SoldierPotentialBreakthrough(long tick, string soldierId);

	Task<SoldierAddPotentialProgressResponse> SoldierAddPotentialProgress(long tick, string soldierId, int position, int num);

	Task<DrawCardResponse> DrawCard(string activityId, string drawOption, int costOption = -1);

	Task<DrawDynamicCardPoolResponse> DrawCardFromDynamicPool(string activityId, string drawOption, int costOption = -1);

	Task<GetAllSoldiersCombatPowerResponse> GetAllSoldiersCombatPower(long tick);

	Task<GetDrawCardCntResponse> GetDrawCardCnt(string activityId, string drawOption);

	Task<PendingLotteryResultClaimResponse> ClaimPendingLottery(List<int> chosenList);

	Task<ClaimVerifyIdentityBonusResponse> ClaimVerifyIdentityBonus();

	Task<MainLevelRetreatResponse> MainLevelRetreat(string battleId);

	Task<MissionClaimResponse> MissionClaim(string missionId);

	Task<ActivityClaimResponse> ActivityClaim(string activityId);

	Task<ClaimDynamicCardPoolBonusResponse> DynamicActivityClaim(string activityId);

	Task<ActivityResetResponse> ActivityReset(string activityId);

	Task<ActivityReviewResponse> ActivitiesReview(List<string> activityIds);

	Task<CheckActivitiesOverPeriodResponse> CheckActivitiesOverPeriod(List<string> activityIds = null, List<ActivityType> activityTypes = null);

	Task<CheckActivitiesAutoFillResponse> CheckActivitiesAutoFill(string activityId = null);

	Task<AchievementClaimResponse> AchievementClaim(string achievementId);

	Task<SignInClaimResponse> SignInClaim(string activityId, int target = 0);

	Task<LeaseholdDailyBonusClaimResponse> ClaimLeaseholdDailyBonus(string leaseholdItemId);

	Task<GetStoreActivityItemsResponse> GetStoreActivityItems(string activityId, string pageName);

	Task<GetShadowDemonActivityResponse> GetShadowDemonActivity(string activityId);

	Task<GetMissionActivityStoreItemsResponse> GetMissionActivityStoreItems(string activityId, string pageName);

	Task<ResetTechnologyResponse> ResetTechnology(long tick);

	Task<UpgradeTechnologyResponse> UpgradeTechnology(long tick, string techId);

	Task<SyncProduceResponse> SyncProduce(long tick, bool getAllProduceStates = false);

	Task<SyncGvGProduceResponse> SyncGvGProduce(long tick, bool getAllProduceStates = false);

	Task<GetCollectingInfoResponse> GetCollectingInfo();

	Task<SyncStockResponse> SyncStock(long tick, bool syncAllStock = false, List<string> itemIds = null);

	Task<SyncWeeklyMissionScoreResponse> SyncWeeklyMissionScore();

	Task<GetOfflineYieldBonusResponse> GetOfflineYieldBonuses();

	Task<PlaceOrderResponse> PlaceOrder(string storeItemId, string paymentType, int priceIndex = -1, int quantity = 1, string payParams = "");

	Task<VerifyIdentityTapTapResponse> VerifyIdentityTapTap(string token);

	Task<VerifyIdentityTapTapV4Response> VerifyIdentityTapTapV4();

	Task<VerifyIdentityBilibiliResponse> VerifyIdentityBiliBili(string accessKey);

	Task<VerifyIdentityXipuResponse> VerifyIdentityXipu();

	Task<VerifyIdentityResponse> VerifyIdentity(string idNo, string name);

	Task<bool> GetTelVerifyCode(string telNo);

	Task<CheckOrderResponse> CheckOrder(string orderId, string transactionId, string orderMsg = "");

	Task<SyncPendingReceiptsResponse> SyncPendingReceipts(string productId, string receipt);

	Task<SyncTimeResponse> SyncTimeFromServer();

	Task<ServerInfoResponse> ServerInfo();

	Task<GetRecycleProductsResponse> GetRecycleProducts(int userId);

	Task<RecycleExportToResponse> RecycleExportTo(int userId);

	Task<GetFriendsCanExportRecycleResponse> GetFriendsCanExportRecycle();

	Task<GetRecycleStatsResponse> GetRecycleStats(int userId);

	Task<SwitchRecycleMultiplayerEnableResponse> SwitchRecycleMultiplayerEnable(bool enable);

	Task<GetSelfRecycleStatsResponse> GetSelfRecycleStats();

	Task<GetRecycleRebateResponse> GetRecycleRebate();

	Task<ClaimRecycleRebateResponse> ClaimRecycleRebate(int qty);

	Task<GetTotalRecycleExportRequestResponse> GetTotalRecycleExportRequest();

	Task<GiftRedeemPreviewResponse> GiftRedeemPreview(string redeemCode);

	Task<GiftRedeemClaimResponse> GiftRedeemClaim(string redeemCode);

	Task<SetInvitedFromResponse> SetInvitedFrom(string invitingCode);

	Task<ActivateInvitedWorkerResponse> ActivateInvitedWorker(int workerUserId);

	Task<ReviewInvitedWorkersResponse> ReviewInvitedWorkers();

	Task<AssignInvitedWorkerResponse> AssignInvitedWorker(int slotIndex, int workerUserId, string buildingType, int workbenchIndex);

	Task<ChangeInvitingSlotsConfigResponse> ChangeInvitingSlotsConfig(Dictionary<int, Tuple<int, string, int>> invitingSlotsConfig);

	Task<GetInvitedWorkersResponse> GetInvitedWorkers();

	Task<AddFriendResponse> AddFriend(int friendId);

	Task<DeleteFriendResponse> DeleteFriend(int friendId);

	Task<GetFriendsResponse> GetFriends(bool getNew);

	Task<SendChatResponse> SendFriendsChat(int friendId, string contents);

	Task<ReadMessageResponse> ReadFriendsChat(int friendId);

	Task<GetUnreadMessageResponse> GetUnreadFriendsChat();

	Task<GetFriendsApplyInfoResponse> GetFriendsApplyInfo();

	Task<SendFriendsApplyResponse> SendFriendsApply(string invitingCode);

	Task<ModifyFriendsApplyResponse> ModifyFriendsApply(int requestId, bool isAgree);

	Task<BattlePassActivityClaimResponse> BattlePassActivityClaim(string activity, string level);

	Task<BindMobileResponse> BindMobile(string mobile);

	Task<BindMobileVerifyResponse> BindMobileVerify(string mobile, string code);

	Task<ResetArchiveResponse> ResetArchive();

	Task<ConfirmResetArchiveResponse> ConfirmResetArchive(string token);

	Task<LegendItemAllResponse> LegendItemAll();

	Task<SelfSelectionBluePrintResponse> SelfSelectionBluePrintUse(string itemId, string mainItemPool, string fxPool, string setAliasPool);

	Task<SpecialSelectionBluePrintConfigResponse> GetSpecialSelectionBluePrintConfig();

	Task<SpecialSelectionBluePrintResponse> SpecialSelectionBluePrintUse(int sbpIndex, string mainItemPool, string fxPool, string setAliasPool);

	Task<SoldierEquippedItemsAllResponse> SoldierEquippedItemsAll();

	Task<SoldierWearLegendItemResponse> SoldierWearLegendItem(string soldierId, int slotId, long instanceId);

	Task<SoldierTakeOffLegendItemResponse> SoldierTakeOffLegendItem(string soldierId, int slotId);

	Task<SoldierItemSlotAllResponse> SoldierItemSlotAll();

	Task<SoldierItemSlotUnlockResponse> SoldierItemSlotUnlock(string soldierId, int slotId);

	Task<LegendItemEnhancementEnhanceResponse> EnhanceLegendItem(long enhanceTargetId, List<long> foodIds);

	Task<LegendItemLockResponse> LegendItemLock(long instanceId, bool lockStatus);

	Task<LegendItemEnhancementSwitchFxResponse> LegendItemEnhancementSwitchFx(long instanceId, int fxIndex);

	Task<LegendItemEnhancementSwapMainResponse> LegendItemEnhancementSwapMain(long instanceId, long swapInstanceId);

	Task<LegendItemEnhancementSwitchMainResponse> LegendItemEnhancementSwitchMain(long instanceId, string entryId);

	Task<LegendItemChangePropertyResponse> LegendItemChangeProperty(long instanceId, int entryType, int entryIndex, int costIndex = -1);

	Task<LegendItemConfirmChangePropertyResponse> LegendItemConfirmChangeProperty(long instanceId, int entryType, int entryIndex, bool confirm);

	Task<LegendItemReforgeResponse> LegendItemReforge(long instanceId, List<int> subEntryIndexList, int costIndex = -1, int lockCostIndex = -1);

	Task<LegendItemConfirmReforgeResponse> LegendItemConfirmReforge(long instanceId, bool confirm);

	Task<AssignSoldierToTreasureHuntActivityResponse> AssignSoldierToTreasureHuntActivity(List<KeyValuePair<string, int>> soldiers);

	Task<GetTreasureHuntActivityProgressResponse> GetTreasureHuntActivityProgress();

	Task<GetTreasureHuntBossInsuranceResponse> GetTreasureHuntBossInsurance();

	Task<GetLegendItemLotteryActivityProgressesResponse> GetLegendItemLotteryActivityProgresses();

	Task<CheckUnshipOrdersResponse> CheckUnshipOrders();

	Task<CheckUnshipOrders_IOS_Response> CheckUnshipOrders_IOS();

	Task<CheckUnshipOrders_Intl_Response> CheckUnshipOrders_Intl();

	Task<GetLevelEnemyTemplateResponse> GetLevelEnemyTemplate(string levelId, string activityId = null);

	Task<CheckMissionStatusResponse> CheckMissionStatus(string mid, int status);

	Task<CheckReviewPointResponse> CheckReviewPoint();

	Task<StatsTapTapReviewResponse> StatsTapTapReview(string openid, string name);

	Task<StatsReviewResponse> StatsReview(string channel, int action);

	Task<StatsAppStoreReviewResponse> StatsAppStoreReview(string channel, int action);

	Task<GvGMode2CreateShipSummaryResponse> GvGMode2CreateShipSummary(List<string> soldiers, string formationId);

	Task<GvGMode2ShipFillUpResponse> GvGMode2ShipFillUp(List<string> soldiers, string formationId, string shipId);

	Task<GvGRoomOperationResponse> GvGRoomOperation(string op);

	Task<GvGRoomOperationDisabledResponse> GvGRoomOperationDisabled();

	Task<GvGMode3RoomOperationDiabledResponse> GvGMode3RoomOperationDisabled();

	Task<GvGMode2SyncBattleConfigResponse> GvGMode2SyncBattleConfig(List<string> soldiers, string formationId, string shipId);

	Task<GvGMode2GetUserIZBattleSummaryResponse> GvGMode2GetUserIZBattleSummary(int[] IZIds);

	Task<GvGMode2GetBattleRecordsResponse> GvGMode2GetBattleRecords(int IZId, int summaryId);

	Task<GvGMode3AcceptShipResponse> GvGMode3AcceptShip(string shipId);

	Task<GvGMode3BuildShipResponse> GvGMode3BuildShip(string shipRace, int workers, bool fastBuild);

	Task<GvGMode3DestroyShipResponse> GvGMode3DestroyShip(string shipId);

	Task<GvGMode3ShipChangeOrderResponse> GvGMode3ShipChangeOrder(Dictionary<int, string> order);

	Task<GetGvGMode3DescriptionsResponse> GetGvGMode3Descriptions();

	Task<GetGvGMode3ProcessByIZConfigIdResponse> GetGvGMode3ProcessByIZConfigId(string IZConfigId);

	Task<GvGMode3ClaimSettlementResponse> GvGMode3ClaimSettlement(int _IZId, List<int> _RewardType);

	Task<GvGMode3CloseBattlePassResponse> GvGMode3CloseBattlePass(int izId);

	Task<GvGMode3ClaimBattlePassBonusResponse> GvGMode3ClaimBattlePassBonus(int izId, string activityId, string node);

	Task<GvGMode3GetBattlePassDataResponse> GvGMode3GetBattlePassData(int izId);

	Task<GvGMode3CloseLastIZResponse> GvGMode3CloseLastIZ(int _IZId);

	Task<GvGMode3GetIZSettlementRecordResponse> GvGMode3GetIZSettlementRecord(int _IZId);

	Task<GvGMode3ChangeShipConfigResponse> GvGMode3ChangeShipConfig(string ShipId, int changeShipConfigAction, string json);

	Task<GvGMode3JoinShipToRoomResponse> GvGMode3JoinShipToRoom(string IZConfigId, int IZId, List<string> ShipIds);

	Task<GvGMode3ShipGetRecordResponse> GvGMode3ShipGetRecord();

	Task<GvGMode3SignUpActionResponse> GvGMode3SignUpAction(int CampId, int IZId, string IZConfigId, string SignUpAction);

	Task<GvGMode3LoadDefaultFormationResponse> GvGMode3LoadDefaultFormation(int shipRace);

	Task<GetRecallWelfareResponse> GetRecallWelfare();

	Task<DrawRecallWelfareResponse> DrawRecallWelfare(List<int> index);

	Task<ClaimRecallWelfareBonusResponse> ClaimRecallWelfareBonus(string missionId);

	Task<ExchangeRecallWelfareResponse> ExchangeRecallWelfare();

	Task<GetWeeklyActivityResponse> GetWeeklyActivity();

	Task<DrawSpinWeeklyResponse> DrawSpinWeekly(int drawRepeat);

	Task<ExchangeSpinWeeklyResponse> ExchangeSpinWeekly(int index, int repeat);

	Task<ClaimSpinWeeklyLotteryResponse> ClaimSpinWeeklyLottery(int day, bool free);

	Task<SyncDailyMissionScoreResponse> SyncDailyMissionScore();

	Task<MoonBattlePassActivityClaimResponse> MoonBattlePassActivityClaim(string actId, string node);

	Task<WarOfRealmClaimResponse> ClaimWarOfRealm(int score);

	Task<WarOfRealmGetInfoResponse> GetWarOfRealmInfo();

	Task<GetWarOfRealmFormationResponse> GetWarOfRealmFormation();

	Task<SetWarOfRealmFormationResponse> SetWarOfRealmFormation(WarOfRealmConfig formation);

	Task<WarOfRealmClaimMissionBonusResponse> ClaimWarOfRealmMissionBonus(int score);

	Task<WarOfRealmClaimRankBonusResponse> ClaimWarOfRealmRankBonus(string activityId);

	Task<WarOfRealmGetStageRecordResponse> GetWarOfRealmStageRecord(string activityId, int stageStatus);

	Task<WarOfRealmGetWarBattleRecordResponse> GetWarOfRealmWarBattleRecord(int stageStatus, int userId);

	Task<WarOfRealmLotteryResponse> LotteryWarOfRealm(int stageStatus, int groupIdx, List<WarLottery> lotteries);

	Task<WarOfRealmSettlementResponse> SettlementWarOfRealm(string activityId, int stageStatus);

	Task<WarOfRealmGetStageBattleRecordResponse> GetWarOfRealmStageBattleRecord(int groupId, int stageStatus);

	Task<WarOfRealmReplayResponse> WarOfRealmReplay(string battleId);

	Task<WarOfRealmGetScoreHistoryResponse> WarOfRealmScoreHistory();

	Task<GetAccessoryInfoResponse> GetAccessoryInfo();

	Task<EquipAccessoryResponse> EquipAccessory(string itemId, int type);
}
