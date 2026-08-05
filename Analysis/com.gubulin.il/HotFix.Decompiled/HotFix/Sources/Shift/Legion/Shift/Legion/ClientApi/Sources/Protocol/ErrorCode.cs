namespace HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol;

public static class ErrorCode
{
	public const int DefaultError = -1;

	public const int Sucess = 0;

	public const int UserCredentials_GetSucess = 1001;

	public const int UserCredentials_CreateSucess = 1002;

	public const int UserCredentials_WrongType = 1003;

	public const int UserCredentials_GetFailed = 1004;

	public const int UserCredentials_WrongOp = 1005;

	public const int UserCredentials_OpSucess = 1006;

	public const int UserCredentials_ResetFailed_Max = 1007;

	public const int UserCredentials_ResetSucess = 1008;

	public const int UserCredentials_ChangeCurrentSucess = 1009;

	public const int UserCredentials_DeleteSucess = 1010;

	public const int UserCredentials_ChangeCurrentFailed_NoThisUserId = 1011;

	public const int UserCredentials_DeleteFailed_NoThisUserId = 1012;

	public const int UserCredentials_DeleteFailed_UserIdIsInUse = 1013;

	public const int UserCredentials_OpFailed_WrongSession = 1014;

	public const int UserCredentials_OpFailed_NoSession = 1015;

	public const int UserCredentials_OpFailed_ParseUserIdInvalid = 1016;

	public const int UserCredentials_UpdateSessionFailed = 1017;

	public const int UserCredentials_UpdateSessionSucess = 1018;

	public const int UserCredentials_DeleteFailed_CanNotFindUserInfo = 1019;

	public const int UserCredentials_WrongValueWhenGetOrCreateCredentials = 1020;

	public const int UserCredentials_WrongZoneWhenGetOrCreateCredentials = 1022;

	public const int UserCredentials_DeleteFailed_GuestUnable = 1023;

	public const int UserCredentials_ResetByOldPlayer = 1024;

	public const int UserCredentials_ResetByOldPlayerSucess = 1025;

	public const int DrawCard_InventoryFull = 10401001;

	public const int UseItem_InvnetoryFull = 10014001;

	public const int CheckOrder_OrderNotFound = 4002001;

	public const int CheckOrder_TransactionIdDuplicated = 4002002;

	public const int CheckOrder_ShipOrderException = 4002003;

	public const int CheckOrder_MismatchedTransactionId = 4002004;

	public const int CheckOrder_TransactionClosed = 4002005;

	public const int CheckOrder_MismatchedUserId = 4002006;

	public const int VerifyIdentity_UnknownError = 1005000;

	public const int VerifyIdentity_IdNoIllegal = 1005001;

	public const int VerifyIdentity_AuthCodeNotFound = 1005003;

	public const int VerifyIdentity_AuthCodeInUse = 1005004;

	public const int VerifyIdentity_U18Warning = 1005005;

	public const int VerifyIdentity_VerifyFailed = 1005006;

	public const int VerifyIdentity_OutOfRetryCnt = 1005007;

	public const int VerifyIdentity_OnVerifying = 1005008;

	public const int DrawCard_InvalidGetDrawCntParams = 10402001;

	public const int ClaimAchievemnet_Incomplete = 10901001;

	public const int ClaimAchievemnet_Duplicate = 10901002;

	public const int ClaimAchievement_AchievementNotFount = 10901003;

	public const int StartBattle_ErrorWhenCommunicateWithBattleServer = 10101000;

	public const int StartBattle_FindAnotherBattling = 10101001;

	public const int StartBattle_QuickBattleNotSupported = 10101002;

	public const int StartBattle_LevelNotUnlock = 10101003;

	public const int StartBattle_LevelCannotRepeat = 10101004;

	public const int StartBattle_TreasureHuntNeedGoToBossLevel = 10101005;

	public const int StartBattle_LevelNotExistedInActivity = 10101006;

	public const int StartBattle_TreasureHuntCannotGoToBossLevel = 10101007;

	public const int StartBattle_InvalidSoldierQtyOnFormation = 10101008;

	public const int StartBattle_NotEnoughTicket = 10101009;

	public const int StartBattle_CannotStartBattleWithoutSoldier = 10101010;

	public const int StartBattle_SoldierFilterNotPassed = 10101011;

	public const int StartBattle_LevelFilterNotPassed = 10102012;

	public const int GetBattleBonus_BattleNotFount = 10105001;

	public const int GetBattleBonus_MainStoryRetreat = 10105002;

	public const int ConfirmBattleBonus_BattleNotFount = 10108001;

	public const int ConfirmBattleBonus_RepeatClaim = 10108002;

	public const int ConfirmBattleBonus_BattleNotWin = 10108003;

	public const int ConfirmBattleBonus_MainStoryRetreat = 10108004;

	public const int StartPvPRankBattle_RankDataExpired = 10114000;

	public const int StartPvPRankBattle_FindAnotherBattling = 10114001;

	public const int StartPvPRankBattle_CoolingDown = 10114002;

	public const int StartPvPRankBattle_CannotChallengeRank = 10114003;

	public const int StartPvPRankBattle_InvalidRedTeamFormationConfig = 10114004;

	public const int StartPvPRankBattle_InvalidBlueTeamFormationConfig = 10114005;

	public const int StartPvPRankBattle_ErrorWhenCommunicateWithBattleServer = 10114006;

	public const int StartPvPRankBattle_ErrorWhenCommunicateWithRankServer = 10114007;

	public const int StartPvPRankBattle_InvalidRankRecord = 10114008;

	public const int StartPvPRankBattle_NotFoundRankConfig = 10114009;

	public const int StartPvPRankBattle_CannotChallengeSelf = 10114010;

	public const int StartPvPRankBattle_NotInChallengingTime = 10114011;

	public const int StartPvPRankBattle_TargetRankIsLocked = 10114016;

	public const int StartPvPRankBattle_TargetRankUserIdChanged = 10114017;

	public const int StartPvPRankBattle_RankUserIdChanged = 10114018;

	public const int GetSelfPvPRank_ErrorWhenCommunicateWithRankServer = 10037001;

	public const int GetSelfPvPRank_InvalidRankData = 10037002;

	public const int GetPvPRankList_ErrorWhenCommunicateWithRankServer = 10038001;

	public const int GetPvPRankList_InvalidRankData = 10038002;

	public const int GetPvPRankList_GetSelfRankFailed = 10038003;

	public const int GetPvPRankList_NotInValidTime = 10038004;

	public const int GetDetailPvPRankInfo_ErrorWhenCommunicateWithRankServer = 10039001;

	public const int GetDetailPvPRankInfo_InvalidRankData = 10039002;

	public const int GetDetailPvPRankInfo_RankDataExpired = 10039003;

	public const int SyncPvPRankFormationUnits_InvalidFormationConfig = 10034001;

	public const int OnBattleResultUpdated_ErrorWhenCommunicateWithRankServer = 99001001;

	public const int GetPvPScoreRankList_ErrorWhenCommunicateWithRankServer = 10037001;

	public const int GeneralErrorCode_ActivityNotExisted = 10122009;

	public const int GiftRedeemPreview_BackendCommunicationError = 10160001;

	public const int GiftRedeemPreview_InvalidParams = 10160002;

	public const int GiftRedeemPreview_InvalidRedeemCode = 10160003;

	public const int GiftRedeemPreview_RedeemCodeExpired = 10160004;

	public const int GiftRedeemPreview_NoMoreGift = 10160005;

	public const int GiftRedeemPreview_HasClaimd = 10160006;

	public const int GiftRedeemPreview_GetGiftPreviewFailed = 10160007;

	public const int GiftRedeemClaim_BackendCommunicationError = 10161001;

	public const int GiftRedeemClaim_InvalidParams = 10161002;

	public const int GiftRedeemClaim_InvalidRedeemCode = 10161003;

	public const int GiftRedeemClaim_RedeemCodeExpired = 10161004;

	public const int GiftRedeemClaim_NoMoreGift = 10161005;

	public const int GiftRedeemClaim_HasClaimd = 10161006;

	public const int GiftRedeemClaim_GiftClaimFailed = 10161007;

	public const int Battle_Sucess = 20000000;

	public const int Battle_BattleServerHasMaxProcesses = 20000001;

	public const int Battle_BattleIDIsCalculating = 20000002;

	public const int Battle_RecordRedisFailed = 20000003;

	public const int Battle_BattleServerIsBusy = 20000004;

	public const int Battle_EmptyBattleId = 20000005;

	public const int Battle_HttpUnknowError = 20999008;

	public const int Battle_ResultUnknowError = 20999008;

	public const int Battle_InternalError = 20999009;

	public const int LegendItemEnhanceFoodInPVPProgress = 22001011;

	public const int CheckTreasureHuntPresetFormation_Empty = 24001001;

	public const int CheckTreasureHuntPresetFormation_WrongFormationCount = 24001002;

	public const int CheckTreasureHuntPresetFormation_WrongTeamCount = 24001003;

	public const int CheckTreasureHuntPresetFormation_WrongUnitsCount = 24001004;

	public const int CheckTreasureHuntPresetFormation_UnitsCountIsZero = 24001005;

	public const int CheckTreasureHuntPresetFormation_DuplicateSoldierId = 24001006;

	public const int RemoveUserCache_HasNotThisUserId = 500000001;

	public const int RankGame_FromRankIsNotIdle = 80000012;

	public const int RankGame_RankIsNotIdle = 80000013;

	public const int SignInClaim_NoThisActivity = 10801001;

	public const int SignInClaim_ActivityIsNotStart = 10801002;

	public const int SignInClaim_ActivityHasEnd = 10801003;

	public const int RankGame_NoGameInfo = 80000000;

	public const int RankGame_GameNotRunning = 80000001;

	public const int RankGame_GameNotInBattling = 80000002;

	public const int RankGame_GameNotInSettlement = 80000003;

	public const int RankGame_NoInfo = 80000004;

	public const int RankGame_WrongState = 80000005;

	public const int RankGame_PVPIsInCeasefire = 80000006;

	public const int RankGame_InvalidUserId = 80000007;

	public const int RankGame_RecordIsNull = 80000008;

	public const int RankGame_InvalidRank = 80000009;

	public const int RankGame_IsInSettlement = 80000010;

	public const int RankGame_GameIsClsoe = 80000011;

	public const int RankGame_UserHasNotChoosenZone = 80000014;

	public const int RankGame_UserIsEnough = 80000015;

	public const int RankGame_Wrong_RankConfig = 80000016;

	public const int RankGame_CheckPvPTopTournamentFormation_WrongFormationCount = 80000100;

	public const int RankGame_CheckPvPTopTournamentFormation_WrongTeamCount = 80000101;

	public const int RankGame_CheckPvPTopTournamentFormation_WrongUnitsCount = 80000102;

	public const int RankGame_CheckPvPTopTournamentFormation_DuplicateSoldierId = 80000103;

	public const int RankGame_CheckPvPTopTournamentFormation_DuplicateLegendItemId = 80000104;

	public const int RankGame_CheckPvPTopTournamentFormation_HaveNotThisItem = 80000105;

	public const int RankGame_CheckPvPTopTournamentFormation_InvalidItem = 80000105;

	public const int RankGame_CheckPvPTopTournamentFormation_CanHasSameNameItem = 80000106;

	public const int RankGame_CheckPvPTopTournamentFormation_MaxItemCount = 80000107;

	public const int RankGame_CheckPvPTopTournamentFormation_UnitsCountIsZero = 80000108;

	public const int RankGame_Unknow = 80000999;

	public const int RankGame_NoRunning = 80000998;

	public const int RankGameStart_InvalidRequestParams = 80001001;

	public const int RankGameStart_LoadRankGameFailed = 80001002;

	public const int GetPvPRankBattleResult_NoThisBattleRecord = 80032001;

	public const int GetPvPRankBattleResult_BattleRunning = 80032002;

	public const int RankGameSeason_ErrorWhenCommunicate = 81000001;

	public const int RankGameSeason_WrongRS = 81001002;

	public const int RankGameSeason_ErrorWhenCommunicate_RS = 81001003;

	public const int MainLevelRetreat_IsNotMainLevel = 81300001;

	public const int MainLevelRetreat_NoBattleId = 81300002;

	public const int MainLevelRetreat_NoLevelId = 81300003;

	public const int BattlePass_HasNotPaidCret = 81310001;

	public const int BattlePass_ScoreIsNotEnough = 81310002;

	public const int BattlePass_WrongActivityId = 81310003;

	public const int BattlePass_WrongType = 81310004;

	public const int BattlePass_WrongStatus = 81310005;

	public const int NewbieGACHA_WrongProgress = 81320001;

	public const int NewbieGACHA_ProgressIsEnd = 81320002;

	public const int NewbieGACHA_WrongActivityId = 81320003;

	public const int NewbieGACHA_WrongType = 81310004;

	public const int NewbieGACHA_TicketsIsNotEnough = 81310005;

	public const int NewbieGACHA_UnknowProgress = 81310006;

	public const int NewbieGACHA_NoProgressKey = 81310007;

	public const int NewbieGACHA_NoSelectKey = 81310008;

	public const int NewbieGACHA_InvalidSelectValue = 81310009;

	public const int GvG_IslandComeAgain_ServerDisabled = 81310400;

	public const int GvG_IslandComeAgain_JoinFailed_TimeLimit = 813104117;

	public const int Chat_NotFriend = 81201000;

	public const int Chat_ErrorType = 81201001;

	public const int Chat_ErrorContent = 81201002;

	public const int Chat_ExceedTimesLimit = 81201003;

	public const int Chat_ExceedLengthLimit = 81201004;

	public const int GvG_OuterTech_NoSpeedPlan = 81200122;

	public const int Soldier_NoUnlocked = 90000000;

	public const int GvGClaimUserCampMission_NoIZId = 81310200;

	public const int GvGClaimUserCampMission_NoCampId = 81310201;

	public const int GvGClaimUserCampMission_NoMissionConfigId = 81310202;

	public const int GvGClaimUserCampMission_CanNotClaimed = 81310203;

	public const int GvG_WorldBoss_StartBattleFailed_SoldierCountIsNotEnough = 81310100;

	public const int GvG_WorldBoss_StartBattleFailed_HasShip = 81310101;

	public const int GvG_WorldBoss_StartBattleFailed_WBConfigError = 81310102;

	public const int GvG_WorldBoss_StartBattleFailed_WrongSoldierConfig = 81310103;

	public const int LegendItemsBlueprint_CostItemsOccupied = 81311511;

	public const int WarOfRealm_GetInfo_ActivityNotExist = 81311550;

	public const int WarOfRealm_ClaimMissionBonus_ActivityNotExist = 81311551;

	public const int WarOfRealm_ClaimMissionBonus_ActivityExpired = 81311552;

	public const int WarOfRealm_ClaimMissionBonus_AlreadyClaimed = 81311553;

	public const int WarOfRealm_ClaimMissionBonus_ErrorConfig = 81311554;

	public const int WarOfRealm_ClaimMissionBonus_ScoreNotEnough = 81311555;

	public const int WarOfRealm_Lottery_ActivityNotExist = 81311556;

	public const int WarOfRealm_Lottery_ErrorStageStatus = 81311557;

	public const int WarOfRealm_Lottery_ErrorGroupInfo = 81311558;

	public const int WarOfRealm_Lottery_ErrorGroupIndex = 81311559;

	public const int WarOfRealm_Lottery_ErrorGroupMember = 81311560;

	public const int WarOfRealm_Lottery_ErrorLotteryAmount = 81311561;

	public const int WarOfRealm_Lottery_ErrorConfig = 81311562;

	public const int WarOfRealm_Lottery_ScoreNotEnough = 81311563;

	public const int WarOfRealm_GetLotteryInfo_ActivityNotExist = 81311564;

	public const int WarOfRealm_GetLotteryInfo_ActivityExpired = 81311565;

	public const int WarOfRealm_GetLotteryInfo_ErrorStageStatus = 81311566;

	public const int WarOfRealm_ClaimRankBonus_ActivityNotExist = 81311567;

	public const int WarOfRealm_ClaimRankBonus_ActivityExpired = 81311568;

	public const int WarOfRealm_ClaimRankBonus_ErrorStageStatus = 81311569;

	public const int WarOfRealm_ClaimRankBonus_ErrorGroupInfo = 81311570;

	public const int WarOfRealm_ClaimRankBonus_AlreadyClaimed = 81311571;

	public const int WarOfRealm_ClaimRankBonus_NoneBonus = 81311572;

	public const int WarOfRealm_GetStageRecord_ActivityNotExist = 81311573;

	public const int WarOfRealm_GetStageRecord_ActivityExpired = 81311574;

	public const int WarOfRealm_GetStageRecord_StageNotValid = 81311575;

	public const int WarOfRealm_GetStageRecord_StageParamError = 81311576;

	public const int WarOfRealm_GetStageRecord_StageNotInCache = 81311577;

	public const int WarOfRealm_GetWarBattleRecord_ActivityNotExist = 81311578;

	public const int WarOfRealm_GetWarBattleRecord_ActivityExpired = 81311579;

	public const int WarOfRealm_GetWarBattleRecord_StageNotValid = 81311580;

	public const int WarOfRealm_GetWarBattleRecord_NotInValidPeriod = 81311581;

	public const int WarOfRealm_GetWarBattleRecord_ServerNotFound = 81311582;

	public const int WarOfRealm_GetWarBattleRecord_ServerCommunicateError = 81311583;

	public const int WarOfRealm_GetWarBattleRecord_NotInValidTime = 81311584;

	public const int WarOfRealm_GetWarBattleRecord_ErrorResult = 81311585;

	public const int WarOfRealm_GetStageBattleRecord_ActivityNotExist = 81311590;

	public const int WarOfRealm_GetStageBattleRecord_ActivityExpired = 81311591;

	public const int WarOfRealm_GetStageBattleRecord_StageNotValid = 81311592;

	public const int WarOfRealm_GetStageBattleRecord_NotInValidPeriod = 81311593;

	public const int WarOfRealm_GetStageBattleRecord_ServerNotFound = 81311594;

	public const int WarOfRealm_GetStageBattleRecord_ServerCommunicateError = 81311595;

	public const int WarOfRealm_GetStageBattleRecord_NotInValidTime = 81311596;

	public const int WarOfRealm_GetStageBattleRecord_ErrorResult = 81311597;

	public const int WarOfRealm_GetFormation_ErrorConfig = 81311600;

	public const int WarOfRealm_SetFormation_ActivityNotExist = 81311610;

	public const int WarOfRealm_SetFormation_ActivityExpired = 81311611;

	public const int WarOfRealm_SetFormation_ErrorStageStatus = 81311612;

	public const int WarOfRealm_SetFormation_NotInValidPeriod = 81311613;

	public const int WarOfRealm_SetFormation_ErrorConfig = 81311614;

	public const int WarOfRealm_SetFormation_ErrorFormationCount = 81311615;

	public const int WarOfRealm_SetFormation_ErrorSoldierCount = 81311616;

	public const int WarOfRealm_SetFormation_DumpSoldier = 81311617;

	public const int WarOfRealm_SetFormation_ErrorLegendItemCount = 81311618;

	public const int WarOfRealm_SetFormation_SlotLock = 81311619;

	public const int WarOfRealm_SetFormation_DumpLegendItem = 81311620;

	public const int WarOfRealm_SetFormation_NotOwnLegendItem = 81311621;

	public const int WarOfRealm_SetFormation_ErrorLegendItemConfig = 81311622;

	public const int WarOfRealm_SetFormation_UnlegalLegendItem = 81311623;

	public const int WarOfRealm_GetReplay_ActivityNotExist = 81311630;

	public const int WarOfRealm_GetReplay_NotInValidPeriod = 81311631;

	public const int WarOfRealm_GetReplay_NotInValidTime = 81311632;

	public const int WarOfRealm_GetReplay_ErrorResult = 81311633;

	public const int SoldierCamp_SelectedSameSoldier = 82000001;

	public const int UseItem_TimeMachineNoBonus = 82000002;

	public const int GvG_FailedToMatchRoom = 82000003;

	public const int AssignWorkers_ZeroWorkers = 82000004;

	public const int AssignWorkers_NumExceeded = 82000005;

	public const int NotEnoughGem = 82000006;

	public const int ActivityReset_Failed = 82000007;

	public const int AuthException_GetCertFailed = 82000008;

	public const int AuthException_GetOAIDFailed = 82000009;

	public const int AuthException_LoginFailed = 82000010;

	public const int AuthException_UIGetCertFailed = 82000011;

	public const int SyncFormation_WrongLevelData = 82100000;

	public const int SyncFormation_WrongInstZoneData = 82100001;

	public const int SyncFormation_WrongSoldierData = 82100002;

	public const int SyncFormation = 82100003;

	public const int ActivityClaim_NotSameId = 82100004;

	public const int GvGMode3_OnGvGServerChangeUserItem_Failed_NotEnoughStock = 813107030;

	public const int GvGMode3_OnGvGServerChangeUserItem_Failed_NoRequestedItemsk = 813107031;

	public const int GvGMode3_BrawlEventError_NoMission = -9525;

	public const int GvGMode3_BrawlEventError_GetResultFailed_NoMessageIdData = -9517;

	public const int GvGMode3_BrawlEventError_ClaimResultByDay_HasClaimed = -9516;

	public const int GvGMode3_BrawlEventError_DestroyShipFailed = -9526;

	public const int GvGMode3_ProfileChange_UnableShow = 81100006;

	public const int ProfileChange_NoSlot = 81100009;
}
