using System;

public static class GameStateComponentsLookup
{
	public const int AnyBattleDurationListener = 0;

	public const int AnyBattleFieldLengthListener = 1;

	public const int AnyBattleFieldLevelListener = 2;

	public const int AnyBattleFieldMapIdentifierListener = 3;

	public const int AnyBattleFieldSubLevelIndexListener = 4;

	public const int AnyBattleStartedListener = 5;

	public const int AnyBattleStartedRemovedListener = 6;

	public const int AnyBattleTimeLeftListener = 7;

	public const int AnyBattleWaveDurationListener = 8;

	public const int AnyBattleWaveTimeLeftListener = 9;

	public const int AnyBlueTeamCampPositionListener = 10;

	public const int AnyBlueTeamCombatPowerListener = 11;

	public const int AnyBlueTeamStagingAreaPositionListener = 12;

	public const int AnyCameraActiveListener = 13;

	public const int AnyCameraAspectListener = 14;

	public const int AnyCameraFollowingUnitListener = 15;

	public const int AnyCameraFollowTeamListener = 16;

	public const int AnyCameraMoveLimitListener = 17;

	public const int AnyCameraPositionListener = 18;

	public const int AnyCameraRotationListener = 19;

	public const int AnyCameraSizeListener = 20;

	public const int AnyCurrentLevelBattleStartedListener = 21;

	public const int AnyCurrentLevelBattleStartedRemovedListener = 22;

	public const int AnyDataReadyListener = 23;

	public const int AnyFreeBattleModeListener = 24;

	public const int AnyFreeBattleModeRemovedListener = 25;

	public const int AnyGameDataLoadedListener = 26;

	public const int AnyGameEnteredListener = 27;

	public const int AnyLoadingAnimationDirectionListener = 28;

	public const int AnyLoadingPanelListener = 29;

	public const int AnyLoadingPanelStatusListener = 30;

	public const int AnyLoadingProgressListener = 31;

	public const int AnyLoadingShowAllSoldierListener = 32;

	public const int AnyLoadingTotalListener = 33;

	public const int AnyLoserListener = 34;

	public const int AnyNextLevelComingListener = 35;

	public const int AnyNextLevelComingRemovedListener = 36;

	public const int AnyOfflineBonusesListener = 37;

	public const int AnyOfflineSecondsListener = 38;

	public const int AnyRedTeamCampPositionListener = 39;

	public const int AnyRedTeamCombatPowerListener = 40;

	public const int AnyRedTeamStagingAreaPositionListener = 41;

	public const int AnyReplayModeListener = 42;

	public const int AnyReplayModeRemovedListener = 43;

	public const int AnyReplayStateListener = 44;

	public const int AnyReplayStateRemovedListener = 45;

	public const int AnyShowBattleWaveCountdownListener = 46;

	public const int AnyShowBattleWaveCountdownRemovedListener = 47;

	public const int AnySubLevelWinnerListener = 48;

	public const int AnyTeamHealthPointsTotalListener = 49;

	public const int AnyUnlockedSoldiersListener = 50;

	public const int AnyUserDataLoadedListener = 51;

	public const int AnyUserListener = 52;

	public const int AnyWinnerListener = 53;

	public const int BattleDamageStats = 54;

	public const int BattleDuration = 55;

	public const int BattleDurationUpdated = 56;

	public const int BattleElapsedTime = 57;

	public const int BattleFieldLength = 58;

	public const int BattleFieldLevel = 59;

	public const int BattleFieldMapIdentifier = 60;

	public const int BattleFieldSubLevelIndex = 61;

	public const int BattleId = 62;

	public const int BattleProgressStats = 63;

	public const int BattleStarted = 64;

	public const int BattleStats = 65;

	public const int BattleStop = 66;

	public const int BattleTimeLeft = 67;

	public const int BattleWaveDuration = 68;

	public const int BattleWaveElapsedTime = 69;

	public const int BattleWaveTimeLeft = 70;

	public const int BattleWaveUnSpawnCount = 71;

	public const int BlueTeamCampPosition = 72;

	public const int BlueTeamCombatPower = 73;

	public const int BlueTeamStagingAreaPosition = 74;

	public const int CameraActive = 75;

	public const int CameraAspect = 76;

	public const int CameraFollowingUnit = 77;

	public const int CameraFollowTeam = 78;

	public const int CameraMoveLimit = 79;

	public const int CameraPosition = 80;

	public const int CameraRotation = 81;

	public const int CameraSize = 82;

	public const int CharacterArchive = 83;

	public const int CurrentLevelBattleStarted = 84;

	public const int DataReady = 85;

	public const int FreeBattleMode = 86;

	public const int GameDataLoaded = 87;

	public const int GameEntered = 88;

	public const int LoadingAnimationDirection = 89;

	public const int LoadingPanel = 90;

	public const int LoadingPanelStatus = 91;

	public const int LoadingProgress = 92;

	public const int LoadingShowAllSoldier = 93;

	public const int LoadingTotal = 94;

	public const int Loser = 95;

	public const int MainCityInitialized = 96;

	public const int NextLevelComing = 97;

	public const int OfflineBonuses = 98;

	public const int OfflineSeconds = 99;

	public const int RedTeamCampPosition = 100;

	public const int RedTeamCombatPower = 101;

	public const int RedTeamStagingAreaPosition = 102;

	public const int RefreshTeamHealthPointsTotal = 103;

	public const int ReplayBattleId = 104;

	public const int ReplayMode = 105;

	public const int ReplayState = 106;

	public const int Retreat = 107;

	public const int ShowBattleWaveCountdown = 108;

	public const int SubLevelWinner = 109;

	public const int TeamHealthPointsTotal = 110;

	public const int UnlockedSoldiers = 111;

	public const int User = 112;

	public const int UserDataLoaded = 113;

	public const int Winner = 114;

	public const int WorldMapInitialized = 115;

	public const int TotalComponents = 116;

	public static readonly string[] componentNames = new string[116]
	{
		"AnyBattleDurationListener", "AnyBattleFieldLengthListener", "AnyBattleFieldLevelListener", "AnyBattleFieldMapIdentifierListener", "AnyBattleFieldSubLevelIndexListener", "AnyBattleStartedListener", "AnyBattleStartedRemovedListener", "AnyBattleTimeLeftListener", "AnyBattleWaveDurationListener", "AnyBattleWaveTimeLeftListener",
		"AnyBlueTeamCampPositionListener", "AnyBlueTeamCombatPowerListener", "AnyBlueTeamStagingAreaPositionListener", "AnyCameraActiveListener", "AnyCameraAspectListener", "AnyCameraFollowingUnitListener", "AnyCameraFollowTeamListener", "AnyCameraMoveLimitListener", "AnyCameraPositionListener", "AnyCameraRotationListener",
		"AnyCameraSizeListener", "AnyCurrentLevelBattleStartedListener", "AnyCurrentLevelBattleStartedRemovedListener", "AnyDataReadyListener", "AnyFreeBattleModeListener", "AnyFreeBattleModeRemovedListener", "AnyGameDataLoadedListener", "AnyGameEnteredListener", "AnyLoadingAnimationDirectionListener", "AnyLoadingPanelListener",
		"AnyLoadingPanelStatusListener", "AnyLoadingProgressListener", "AnyLoadingShowAllSoldierListener", "AnyLoadingTotalListener", "AnyLoserListener", "AnyNextLevelComingListener", "AnyNextLevelComingRemovedListener", "AnyOfflineBonusesListener", "AnyOfflineSecondsListener", "AnyRedTeamCampPositionListener",
		"AnyRedTeamCombatPowerListener", "AnyRedTeamStagingAreaPositionListener", "AnyReplayModeListener", "AnyReplayModeRemovedListener", "AnyReplayStateListener", "AnyReplayStateRemovedListener", "AnyShowBattleWaveCountdownListener", "AnyShowBattleWaveCountdownRemovedListener", "AnySubLevelWinnerListener", "AnyTeamHealthPointsTotalListener",
		"AnyUnlockedSoldiersListener", "AnyUserDataLoadedListener", "AnyUserListener", "AnyWinnerListener", "BattleDamageStats", "BattleDuration", "BattleDurationUpdated", "BattleElapsedTime", "BattleFieldLength", "BattleFieldLevel",
		"BattleFieldMapIdentifier", "BattleFieldSubLevelIndex", "BattleId", "BattleProgressStats", "BattleStarted", "BattleStats", "BattleStop", "BattleTimeLeft", "BattleWaveDuration", "BattleWaveElapsedTime",
		"BattleWaveTimeLeft", "BattleWaveUnSpawnCount", "BlueTeamCampPosition", "BlueTeamCombatPower", "BlueTeamStagingAreaPosition", "CameraActive", "CameraAspect", "CameraFollowingUnit", "CameraFollowTeam", "CameraMoveLimit",
		"CameraPosition", "CameraRotation", "CameraSize", "CharacterArchive", "CurrentLevelBattleStarted", "DataReady", "FreeBattleMode", "GameDataLoaded", "GameEntered", "LoadingAnimationDirection",
		"LoadingPanel", "LoadingPanelStatus", "LoadingProgress", "LoadingShowAllSoldier", "LoadingTotal", "Loser", "MainCityInitialized", "NextLevelComing", "OfflineBonuses", "OfflineSeconds",
		"RedTeamCampPosition", "RedTeamCombatPower", "RedTeamStagingAreaPosition", "RefreshTeamHealthPointsTotal", "ReplayBattleId", "ReplayMode", "ReplayState", "Retreat", "ShowBattleWaveCountdown", "SubLevelWinner",
		"TeamHealthPointsTotal", "UnlockedSoldiers", "User", "UserDataLoaded", "Winner", "WorldMapInitialized"
	};

	public static readonly Type[] componentTypes = new Type[116]
	{
		typeof(AnyBattleDurationListenerComponent),
		typeof(AnyBattleFieldLengthListenerComponent),
		typeof(AnyBattleFieldLevelListenerComponent),
		typeof(AnyBattleFieldMapIdentifierListenerComponent),
		typeof(AnyBattleFieldSubLevelIndexListenerComponent),
		typeof(AnyBattleStartedListenerComponent),
		typeof(AnyBattleStartedRemovedListenerComponent),
		typeof(AnyBattleTimeLeftListenerComponent),
		typeof(AnyBattleWaveDurationListenerComponent),
		typeof(AnyBattleWaveTimeLeftListenerComponent),
		typeof(AnyBlueTeamCampPositionListenerComponent),
		typeof(AnyBlueTeamCombatPowerListenerComponent),
		typeof(AnyBlueTeamStagingAreaPositionListenerComponent),
		typeof(AnyCameraActiveListenerComponent),
		typeof(AnyCameraAspectListenerComponent),
		typeof(AnyCameraFollowingUnitListenerComponent),
		typeof(AnyCameraFollowTeamListenerComponent),
		typeof(AnyCameraMoveLimitListenerComponent),
		typeof(AnyCameraPositionListenerComponent),
		typeof(AnyCameraRotationListenerComponent),
		typeof(AnyCameraSizeListenerComponent),
		typeof(AnyCurrentLevelBattleStartedListenerComponent),
		typeof(AnyCurrentLevelBattleStartedRemovedListenerComponent),
		typeof(AnyDataReadyListenerComponent),
		typeof(AnyFreeBattleModeListenerComponent),
		typeof(AnyFreeBattleModeRemovedListenerComponent),
		typeof(AnyGameDataLoadedListenerComponent),
		typeof(AnyGameEnteredListenerComponent),
		typeof(AnyLoadingAnimationDirectionListenerComponent),
		typeof(AnyLoadingPanelListenerComponent),
		typeof(AnyLoadingPanelStatusListenerComponent),
		typeof(AnyLoadingProgressListenerComponent),
		typeof(AnyLoadingShowAllSoldierListenerComponent),
		typeof(AnyLoadingTotalListenerComponent),
		typeof(AnyLoserListenerComponent),
		typeof(AnyNextLevelComingListenerComponent),
		typeof(AnyNextLevelComingRemovedListenerComponent),
		typeof(AnyOfflineBonusesListenerComponent),
		typeof(AnyOfflineSecondsListenerComponent),
		typeof(AnyRedTeamCampPositionListenerComponent),
		typeof(AnyRedTeamCombatPowerListenerComponent),
		typeof(AnyRedTeamStagingAreaPositionListenerComponent),
		typeof(AnyReplayModeListenerComponent),
		typeof(AnyReplayModeRemovedListenerComponent),
		typeof(AnyReplayStateListenerComponent),
		typeof(AnyReplayStateRemovedListenerComponent),
		typeof(AnyShowBattleWaveCountdownListenerComponent),
		typeof(AnyShowBattleWaveCountdownRemovedListenerComponent),
		typeof(AnySubLevelWinnerListenerComponent),
		typeof(AnyTeamHealthPointsTotalListenerComponent),
		typeof(AnyUnlockedSoldiersListenerComponent),
		typeof(AnyUserDataLoadedListenerComponent),
		typeof(AnyUserListenerComponent),
		typeof(AnyWinnerListenerComponent),
		typeof(BattleDamageStatsComponent),
		typeof(BattleDurationComponent),
		typeof(BattleDurationUpdatedComponent),
		typeof(BattleElapsedTimeComponent),
		typeof(BattleFieldLengthComponent),
		typeof(BattleFieldLevelComponent),
		typeof(BattleFieldMapIdentifierComponent),
		typeof(BattleFieldSubLevelIndexComponent),
		typeof(BattleIdComponent),
		typeof(BattleProgressStatsComponent),
		typeof(BattleStartedComponent),
		typeof(BattleStatsComponent),
		typeof(BattleStopComponent),
		typeof(BattleTimeLeftComponent),
		typeof(BattleWaveDurationComponent),
		typeof(BattleWaveElapsedTimeComponent),
		typeof(BattleWaveTimeLeftComponent),
		typeof(BattleWaveUnSpawnCountComponent),
		typeof(BlueTeamCampPositionComponent),
		typeof(BlueTeamCombatPowerComponent),
		typeof(BlueTeamStagingAreaPositionComponent),
		typeof(CameraActiveComponent),
		typeof(CameraAspectComponent),
		typeof(CameraFollowingUnitComponent),
		typeof(CameraFollowTeamComponent),
		typeof(CameraMoveLimitComponent),
		typeof(CameraPositionComponent),
		typeof(CameraRotationComponent),
		typeof(CameraSizeComponent),
		typeof(CharacterArchiveComponent),
		typeof(CurrentLevelBattleStartedComponent),
		typeof(DataReadyComponent),
		typeof(FreeBattleModeComponent),
		typeof(GameDataLoadedComponent),
		typeof(GameEnteredComponent),
		typeof(LoadingAnimationDirectionComponent),
		typeof(LoadingPanelComponent),
		typeof(LoadingPanelStatusComponent),
		typeof(LoadingProgressComponent),
		typeof(LoadingShowAllSoldierComponent),
		typeof(LoadingTotalComponent),
		typeof(LoserComponent),
		typeof(MainCityInitializedComponent),
		typeof(NextLevelComingComponent),
		typeof(OfflineBonusesComponent),
		typeof(OfflineSecondsComponent),
		typeof(RedTeamCampPositionComponent),
		typeof(RedTeamCombatPowerComponent),
		typeof(RedTeamStagingAreaPositionComponent),
		typeof(RefreshTeamHealthPointsTotalComponent),
		typeof(ReplayBattleIdComponent),
		typeof(ReplayModeComponent),
		typeof(ReplayStateComponent),
		typeof(RetreatComponent),
		typeof(ShowBattleWaveCountdownComponent),
		typeof(SubLevelWinnerComponent),
		typeof(TeamHealthPointsTotalComponent),
		typeof(UnlockedSoldiersComponent),
		typeof(UserComponent),
		typeof(UserDataLoadedComponent),
		typeof(WinnerComponent),
		typeof(WorldMapInitializedComponent)
	};
}
