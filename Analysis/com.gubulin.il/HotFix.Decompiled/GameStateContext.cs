using System;
using System.Collections.Generic;
using Entitas;
using GameMaths;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Interfaces;
using Shift.Legion.Common.Models;

public sealed class GameStateContext : Context<GameStateEntity>
{
	public GameStateEntity battleDamageStatsEntity => base.GetGroup(GameStateMatcher.BattleDamageStats).GetSingleEntity();

	public BattleDamageStatsComponent battleDamageStats => battleDamageStatsEntity.battleDamageStats;

	public bool hasBattleDamageStats => battleDamageStatsEntity != null;

	public GameStateEntity battleDurationEntity => base.GetGroup(GameStateMatcher.BattleDuration).GetSingleEntity();

	public BattleDurationComponent battleDuration => battleDurationEntity.battleDuration;

	public bool hasBattleDuration => battleDurationEntity != null;

	public GameStateEntity battleDurationUpdatedEntity => base.GetGroup(GameStateMatcher.BattleDurationUpdated).GetSingleEntity();

	public bool isBattleDurationUpdated
	{
		get
		{
			return battleDurationUpdatedEntity != null;
		}
		set
		{
			GameStateEntity gameStateEntity = battleDurationUpdatedEntity;
			if (value != (gameStateEntity != null))
			{
				if (value)
				{
					base.CreateEntity().isBattleDurationUpdated = true;
				}
				else
				{
					((Entity)gameStateEntity).Destroy();
				}
			}
		}
	}

	public GameStateEntity battleElapsedTimeEntity => base.GetGroup(GameStateMatcher.BattleElapsedTime).GetSingleEntity();

	public BattleElapsedTimeComponent battleElapsedTime => battleElapsedTimeEntity.battleElapsedTime;

	public bool hasBattleElapsedTime => battleElapsedTimeEntity != null;

	public GameStateEntity battleFieldLengthEntity => base.GetGroup(GameStateMatcher.BattleFieldLength).GetSingleEntity();

	public BattleFieldLengthComponent battleFieldLength => battleFieldLengthEntity.battleFieldLength;

	public bool hasBattleFieldLength => battleFieldLengthEntity != null;

	public GameStateEntity battleFieldLevelEntity => base.GetGroup(GameStateMatcher.BattleFieldLevel).GetSingleEntity();

	public BattleFieldLevelComponent battleFieldLevel => battleFieldLevelEntity.battleFieldLevel;

	public bool hasBattleFieldLevel => battleFieldLevelEntity != null;

	public GameStateEntity battleFieldMapIdentifierEntity => base.GetGroup(GameStateMatcher.BattleFieldMapIdentifier).GetSingleEntity();

	public BattleFieldMapIdentifierComponent battleFieldMapIdentifier => battleFieldMapIdentifierEntity.battleFieldMapIdentifier;

	public bool hasBattleFieldMapIdentifier => battleFieldMapIdentifierEntity != null;

	public GameStateEntity battleFieldSubLevelIndexEntity => base.GetGroup(GameStateMatcher.BattleFieldSubLevelIndex).GetSingleEntity();

	public BattleFieldSubLevelIndexComponent battleFieldSubLevelIndex => battleFieldSubLevelIndexEntity.battleFieldSubLevelIndex;

	public bool hasBattleFieldSubLevelIndex => battleFieldSubLevelIndexEntity != null;

	public GameStateEntity battleIdEntity => base.GetGroup(GameStateMatcher.BattleId).GetSingleEntity();

	public BattleIdComponent battleId => battleIdEntity.battleId;

	public bool hasBattleId => battleIdEntity != null;

	public GameStateEntity battleProgressStatsEntity => base.GetGroup(GameStateMatcher.BattleProgressStats).GetSingleEntity();

	public BattleProgressStatsComponent battleProgressStats => battleProgressStatsEntity.battleProgressStats;

	public bool hasBattleProgressStats => battleProgressStatsEntity != null;

	public GameStateEntity battleStartedEntity => base.GetGroup(GameStateMatcher.BattleStarted).GetSingleEntity();

	public bool isBattleStarted
	{
		get
		{
			return battleStartedEntity != null;
		}
		set
		{
			GameStateEntity gameStateEntity = battleStartedEntity;
			if (value != (gameStateEntity != null))
			{
				if (value)
				{
					base.CreateEntity().isBattleStarted = true;
				}
				else
				{
					((Entity)gameStateEntity).Destroy();
				}
			}
		}
	}

	public GameStateEntity battleStatsEntity => base.GetGroup(GameStateMatcher.BattleStats).GetSingleEntity();

	public BattleStatsComponent battleStats => battleStatsEntity.battleStats;

	public bool hasBattleStats => battleStatsEntity != null;

	public GameStateEntity battleStopEntity => base.GetGroup(GameStateMatcher.BattleStop).GetSingleEntity();

	public bool isBattleStop
	{
		get
		{
			return battleStopEntity != null;
		}
		set
		{
			GameStateEntity gameStateEntity = battleStopEntity;
			if (value != (gameStateEntity != null))
			{
				if (value)
				{
					base.CreateEntity().isBattleStop = true;
				}
				else
				{
					((Entity)gameStateEntity).Destroy();
				}
			}
		}
	}

	public GameStateEntity battleTimeLeftEntity => base.GetGroup(GameStateMatcher.BattleTimeLeft).GetSingleEntity();

	public BattleTimeLeftComponent battleTimeLeft => battleTimeLeftEntity.battleTimeLeft;

	public bool hasBattleTimeLeft => battleTimeLeftEntity != null;

	public GameStateEntity battleWaveDurationEntity => base.GetGroup(GameStateMatcher.BattleWaveDuration).GetSingleEntity();

	public BattleWaveDurationComponent battleWaveDuration => battleWaveDurationEntity.battleWaveDuration;

	public bool hasBattleWaveDuration => battleWaveDurationEntity != null;

	public GameStateEntity battleWaveElapsedTimeEntity => base.GetGroup(GameStateMatcher.BattleWaveElapsedTime).GetSingleEntity();

	public BattleWaveElapsedTimeComponent battleWaveElapsedTime => battleWaveElapsedTimeEntity.battleWaveElapsedTime;

	public bool hasBattleWaveElapsedTime => battleWaveElapsedTimeEntity != null;

	public GameStateEntity battleWaveTimeLeftEntity => base.GetGroup(GameStateMatcher.BattleWaveTimeLeft).GetSingleEntity();

	public BattleWaveTimeLeftComponent battleWaveTimeLeft => battleWaveTimeLeftEntity.battleWaveTimeLeft;

	public bool hasBattleWaveTimeLeft => battleWaveTimeLeftEntity != null;

	public GameStateEntity battleWaveUnSpawnCountEntity => base.GetGroup(GameStateMatcher.BattleWaveUnSpawnCount).GetSingleEntity();

	public BattleWaveUnSpawnCountComponent battleWaveUnSpawnCount => battleWaveUnSpawnCountEntity.battleWaveUnSpawnCount;

	public bool hasBattleWaveUnSpawnCount => battleWaveUnSpawnCountEntity != null;

	public GameStateEntity blueTeamCampPositionEntity => base.GetGroup(GameStateMatcher.BlueTeamCampPosition).GetSingleEntity();

	public BlueTeamCampPositionComponent blueTeamCampPosition => blueTeamCampPositionEntity.blueTeamCampPosition;

	public bool hasBlueTeamCampPosition => blueTeamCampPositionEntity != null;

	public GameStateEntity blueTeamCombatPowerEntity => base.GetGroup(GameStateMatcher.BlueTeamCombatPower).GetSingleEntity();

	public BlueTeamCombatPowerComponent blueTeamCombatPower => blueTeamCombatPowerEntity.blueTeamCombatPower;

	public bool hasBlueTeamCombatPower => blueTeamCombatPowerEntity != null;

	public GameStateEntity blueTeamStagingAreaPositionEntity => base.GetGroup(GameStateMatcher.BlueTeamStagingAreaPosition).GetSingleEntity();

	public BlueTeamStagingAreaPositionComponent blueTeamStagingAreaPosition => blueTeamStagingAreaPositionEntity.blueTeamStagingAreaPosition;

	public bool hasBlueTeamStagingAreaPosition => blueTeamStagingAreaPositionEntity != null;

	public GameStateEntity cameraActiveEntity => base.GetGroup(GameStateMatcher.CameraActive).GetSingleEntity();

	public CameraActiveComponent cameraActive => cameraActiveEntity.cameraActive;

	public bool hasCameraActive => cameraActiveEntity != null;

	public GameStateEntity cameraAspectEntity => base.GetGroup(GameStateMatcher.CameraAspect).GetSingleEntity();

	public CameraAspectComponent cameraAspect => cameraAspectEntity.cameraAspect;

	public bool hasCameraAspect => cameraAspectEntity != null;

	public GameStateEntity cameraFollowingUnitEntity => base.GetGroup(GameStateMatcher.CameraFollowingUnit).GetSingleEntity();

	public bool isCameraFollowingUnit
	{
		get
		{
			return cameraFollowingUnitEntity != null;
		}
		set
		{
			GameStateEntity gameStateEntity = cameraFollowingUnitEntity;
			if (value != (gameStateEntity != null))
			{
				if (value)
				{
					base.CreateEntity().isCameraFollowingUnit = true;
				}
				else
				{
					((Entity)gameStateEntity).Destroy();
				}
			}
		}
	}

	public GameStateEntity cameraFollowTeamEntity => base.GetGroup(GameStateMatcher.CameraFollowTeam).GetSingleEntity();

	public CameraFollowTeamComponent cameraFollowTeam => cameraFollowTeamEntity.cameraFollowTeam;

	public bool hasCameraFollowTeam => cameraFollowTeamEntity != null;

	public GameStateEntity cameraMoveLimitEntity => base.GetGroup(GameStateMatcher.CameraMoveLimit).GetSingleEntity();

	public CameraMoveLimitComponent cameraMoveLimit => cameraMoveLimitEntity.cameraMoveLimit;

	public bool hasCameraMoveLimit => cameraMoveLimitEntity != null;

	public GameStateEntity cameraPositionEntity => base.GetGroup(GameStateMatcher.CameraPosition).GetSingleEntity();

	public CameraPositionComponent cameraPosition => cameraPositionEntity.cameraPosition;

	public bool hasCameraPosition => cameraPositionEntity != null;

	public GameStateEntity cameraRotationEntity => base.GetGroup(GameStateMatcher.CameraRotation).GetSingleEntity();

	public CameraRotationComponent cameraRotation => cameraRotationEntity.cameraRotation;

	public bool hasCameraRotation => cameraRotationEntity != null;

	public GameStateEntity cameraSizeEntity => base.GetGroup(GameStateMatcher.CameraSize).GetSingleEntity();

	public CameraSizeComponent cameraSize => cameraSizeEntity.cameraSize;

	public bool hasCameraSize => cameraSizeEntity != null;

	public GameStateEntity characterArchiveEntity => base.GetGroup(GameStateMatcher.CharacterArchive).GetSingleEntity();

	public CharacterArchiveComponent characterArchive => characterArchiveEntity.characterArchive;

	public bool hasCharacterArchive => characterArchiveEntity != null;

	public GameStateEntity currentLevelBattleStartedEntity => base.GetGroup(GameStateMatcher.CurrentLevelBattleStarted).GetSingleEntity();

	public bool isCurrentLevelBattleStarted
	{
		get
		{
			return currentLevelBattleStartedEntity != null;
		}
		set
		{
			GameStateEntity gameStateEntity = currentLevelBattleStartedEntity;
			if (value != (gameStateEntity != null))
			{
				if (value)
				{
					base.CreateEntity().isCurrentLevelBattleStarted = true;
				}
				else
				{
					((Entity)gameStateEntity).Destroy();
				}
			}
		}
	}

	public GameStateEntity dataReadyEntity => base.GetGroup(GameStateMatcher.DataReady).GetSingleEntity();

	public bool isDataReady
	{
		get
		{
			return dataReadyEntity != null;
		}
		set
		{
			GameStateEntity gameStateEntity = dataReadyEntity;
			if (value != (gameStateEntity != null))
			{
				if (value)
				{
					base.CreateEntity().isDataReady = true;
				}
				else
				{
					((Entity)gameStateEntity).Destroy();
				}
			}
		}
	}

	public GameStateEntity freeBattleModeEntity => base.GetGroup(GameStateMatcher.FreeBattleMode).GetSingleEntity();

	public bool isFreeBattleMode
	{
		get
		{
			return freeBattleModeEntity != null;
		}
		set
		{
			GameStateEntity gameStateEntity = freeBattleModeEntity;
			if (value != (gameStateEntity != null))
			{
				if (value)
				{
					base.CreateEntity().isFreeBattleMode = true;
				}
				else
				{
					((Entity)gameStateEntity).Destroy();
				}
			}
		}
	}

	public GameStateEntity gameDataLoadedEntity => base.GetGroup(GameStateMatcher.GameDataLoaded).GetSingleEntity();

	public bool isGameDataLoaded
	{
		get
		{
			return gameDataLoadedEntity != null;
		}
		set
		{
			GameStateEntity gameStateEntity = gameDataLoadedEntity;
			if (value != (gameStateEntity != null))
			{
				if (value)
				{
					base.CreateEntity().isGameDataLoaded = true;
				}
				else
				{
					((Entity)gameStateEntity).Destroy();
				}
			}
		}
	}

	public GameStateEntity gameEnteredEntity => base.GetGroup(GameStateMatcher.GameEntered).GetSingleEntity();

	public bool isGameEntered
	{
		get
		{
			return gameEnteredEntity != null;
		}
		set
		{
			GameStateEntity gameStateEntity = gameEnteredEntity;
			if (value != (gameStateEntity != null))
			{
				if (value)
				{
					base.CreateEntity().isGameEntered = true;
				}
				else
				{
					((Entity)gameStateEntity).Destroy();
				}
			}
		}
	}

	public GameStateEntity loadingAnimationDirectionEntity => base.GetGroup(GameStateMatcher.LoadingAnimationDirection).GetSingleEntity();

	public LoadingAnimationDirectionComponent loadingAnimationDirection => loadingAnimationDirectionEntity.loadingAnimationDirection;

	public bool hasLoadingAnimationDirection => loadingAnimationDirectionEntity != null;

	public GameStateEntity loadingPanelEntity => base.GetGroup(GameStateMatcher.LoadingPanel).GetSingleEntity();

	public LoadingPanelComponent loadingPanel => loadingPanelEntity.loadingPanel;

	public bool hasLoadingPanel => loadingPanelEntity != null;

	public GameStateEntity loadingPanelStatusEntity => base.GetGroup(GameStateMatcher.LoadingPanelStatus).GetSingleEntity();

	public LoadingPanelStatusComponent loadingPanelStatus => loadingPanelStatusEntity.loadingPanelStatus;

	public bool hasLoadingPanelStatus => loadingPanelStatusEntity != null;

	public GameStateEntity loadingProgressEntity => base.GetGroup(GameStateMatcher.LoadingProgress).GetSingleEntity();

	public LoadingProgressComponent loadingProgress => loadingProgressEntity.loadingProgress;

	public bool hasLoadingProgress => loadingProgressEntity != null;

	public GameStateEntity loadingShowAllSoldierEntity => base.GetGroup(GameStateMatcher.LoadingShowAllSoldier).GetSingleEntity();

	public bool isLoadingShowAllSoldier
	{
		get
		{
			return loadingShowAllSoldierEntity != null;
		}
		set
		{
			GameStateEntity gameStateEntity = loadingShowAllSoldierEntity;
			if (value != (gameStateEntity != null))
			{
				if (value)
				{
					base.CreateEntity().isLoadingShowAllSoldier = true;
				}
				else
				{
					((Entity)gameStateEntity).Destroy();
				}
			}
		}
	}

	public GameStateEntity loadingTotalEntity => base.GetGroup(GameStateMatcher.LoadingTotal).GetSingleEntity();

	public LoadingTotalComponent loadingTotal => loadingTotalEntity.loadingTotal;

	public bool hasLoadingTotal => loadingTotalEntity != null;

	public GameStateEntity loserEntity => base.GetGroup(GameStateMatcher.Loser).GetSingleEntity();

	public LoserComponent loser => loserEntity.loser;

	public bool hasLoser => loserEntity != null;

	public GameStateEntity mainCityInitializedEntity => base.GetGroup(GameStateMatcher.MainCityInitialized).GetSingleEntity();

	public bool isMainCityInitialized
	{
		get
		{
			return mainCityInitializedEntity != null;
		}
		set
		{
			GameStateEntity gameStateEntity = mainCityInitializedEntity;
			if (value != (gameStateEntity != null))
			{
				if (value)
				{
					base.CreateEntity().isMainCityInitialized = true;
				}
				else
				{
					((Entity)gameStateEntity).Destroy();
				}
			}
		}
	}

	public GameStateEntity nextLevelComingEntity => base.GetGroup(GameStateMatcher.NextLevelComing).GetSingleEntity();

	public bool isNextLevelComing
	{
		get
		{
			return nextLevelComingEntity != null;
		}
		set
		{
			GameStateEntity gameStateEntity = nextLevelComingEntity;
			if (value != (gameStateEntity != null))
			{
				if (value)
				{
					base.CreateEntity().isNextLevelComing = true;
				}
				else
				{
					((Entity)gameStateEntity).Destroy();
				}
			}
		}
	}

	public GameStateEntity offlineBonusesEntity => base.GetGroup(GameStateMatcher.OfflineBonuses).GetSingleEntity();

	public OfflineBonusesComponent offlineBonuses => offlineBonusesEntity.offlineBonuses;

	public bool hasOfflineBonuses => offlineBonusesEntity != null;

	public GameStateEntity offlineSecondsEntity => base.GetGroup(GameStateMatcher.OfflineSeconds).GetSingleEntity();

	public OfflineSecondsComponent offlineSeconds => offlineSecondsEntity.offlineSeconds;

	public bool hasOfflineSeconds => offlineSecondsEntity != null;

	public GameStateEntity redTeamCampPositionEntity => base.GetGroup(GameStateMatcher.RedTeamCampPosition).GetSingleEntity();

	public RedTeamCampPositionComponent redTeamCampPosition => redTeamCampPositionEntity.redTeamCampPosition;

	public bool hasRedTeamCampPosition => redTeamCampPositionEntity != null;

	public GameStateEntity redTeamCombatPowerEntity => base.GetGroup(GameStateMatcher.RedTeamCombatPower).GetSingleEntity();

	public RedTeamCombatPowerComponent redTeamCombatPower => redTeamCombatPowerEntity.redTeamCombatPower;

	public bool hasRedTeamCombatPower => redTeamCombatPowerEntity != null;

	public GameStateEntity redTeamStagingAreaPositionEntity => base.GetGroup(GameStateMatcher.RedTeamStagingAreaPosition).GetSingleEntity();

	public RedTeamStagingAreaPositionComponent redTeamStagingAreaPosition => redTeamStagingAreaPositionEntity.redTeamStagingAreaPosition;

	public bool hasRedTeamStagingAreaPosition => redTeamStagingAreaPositionEntity != null;

	public GameStateEntity refreshTeamHealthPointsTotalEntity => base.GetGroup(GameStateMatcher.RefreshTeamHealthPointsTotal).GetSingleEntity();

	public RefreshTeamHealthPointsTotalComponent refreshTeamHealthPointsTotal => refreshTeamHealthPointsTotalEntity.refreshTeamHealthPointsTotal;

	public bool hasRefreshTeamHealthPointsTotal => refreshTeamHealthPointsTotalEntity != null;

	public GameStateEntity replayBattleIdEntity => base.GetGroup(GameStateMatcher.ReplayBattleId).GetSingleEntity();

	public ReplayBattleIdComponent replayBattleId => replayBattleIdEntity.replayBattleId;

	public bool hasReplayBattleId => replayBattleIdEntity != null;

	public GameStateEntity replayModeEntity => base.GetGroup(GameStateMatcher.ReplayMode).GetSingleEntity();

	public ReplayModeComponent replayMode => replayModeEntity.replayMode;

	public bool hasReplayMode => replayModeEntity != null;

	public GameStateEntity replayStateEntity => base.GetGroup(GameStateMatcher.ReplayState).GetSingleEntity();

	public ReplayStateComponent replayState => replayStateEntity.replayState;

	public bool hasReplayState => replayStateEntity != null;

	public GameStateEntity retreatEntity => base.GetGroup(GameStateMatcher.Retreat).GetSingleEntity();

	public bool isRetreat
	{
		get
		{
			return retreatEntity != null;
		}
		set
		{
			GameStateEntity gameStateEntity = retreatEntity;
			if (value != (gameStateEntity != null))
			{
				if (value)
				{
					base.CreateEntity().isRetreat = true;
				}
				else
				{
					((Entity)gameStateEntity).Destroy();
				}
			}
		}
	}

	public GameStateEntity showBattleWaveCountdownEntity => base.GetGroup(GameStateMatcher.ShowBattleWaveCountdown).GetSingleEntity();

	public bool isShowBattleWaveCountdown
	{
		get
		{
			return showBattleWaveCountdownEntity != null;
		}
		set
		{
			GameStateEntity gameStateEntity = showBattleWaveCountdownEntity;
			if (value != (gameStateEntity != null))
			{
				if (value)
				{
					base.CreateEntity().isShowBattleWaveCountdown = true;
				}
				else
				{
					((Entity)gameStateEntity).Destroy();
				}
			}
		}
	}

	public GameStateEntity subLevelWinnerEntity => base.GetGroup(GameStateMatcher.SubLevelWinner).GetSingleEntity();

	public SubLevelWinnerComponent subLevelWinner => subLevelWinnerEntity.subLevelWinner;

	public bool hasSubLevelWinner => subLevelWinnerEntity != null;

	public GameStateEntity teamHealthPointsTotalEntity => base.GetGroup(GameStateMatcher.TeamHealthPointsTotal).GetSingleEntity();

	public TeamHealthPointsTotalComponent teamHealthPointsTotal => teamHealthPointsTotalEntity.teamHealthPointsTotal;

	public bool hasTeamHealthPointsTotal => teamHealthPointsTotalEntity != null;

	public GameStateEntity unlockedSoldiersEntity => base.GetGroup(GameStateMatcher.UnlockedSoldiers).GetSingleEntity();

	public UnlockedSoldiersComponent unlockedSoldiers => unlockedSoldiersEntity.unlockedSoldiers;

	public bool hasUnlockedSoldiers => unlockedSoldiersEntity != null;

	public GameStateEntity userEntity => base.GetGroup(GameStateMatcher.User).GetSingleEntity();

	public UserComponent user => userEntity.user;

	public bool hasUser => userEntity != null;

	public GameStateEntity userDataLoadedEntity => base.GetGroup(GameStateMatcher.UserDataLoaded).GetSingleEntity();

	public bool isUserDataLoaded
	{
		get
		{
			return userDataLoadedEntity != null;
		}
		set
		{
			GameStateEntity gameStateEntity = userDataLoadedEntity;
			if (value != (gameStateEntity != null))
			{
				if (value)
				{
					base.CreateEntity().isUserDataLoaded = true;
				}
				else
				{
					((Entity)gameStateEntity).Destroy();
				}
			}
		}
	}

	public GameStateEntity winnerEntity => base.GetGroup(GameStateMatcher.Winner).GetSingleEntity();

	public WinnerComponent winner => winnerEntity.winner;

	public bool hasWinner => winnerEntity != null;

	public GameStateEntity worldMapInitializedEntity => base.GetGroup(GameStateMatcher.WorldMapInitialized).GetSingleEntity();

	public bool isWorldMapInitialized
	{
		get
		{
			return worldMapInitializedEntity != null;
		}
		set
		{
			GameStateEntity gameStateEntity = worldMapInitializedEntity;
			if (value != (gameStateEntity != null))
			{
				if (value)
				{
					base.CreateEntity().isWorldMapInitialized = true;
				}
				else
				{
					((Entity)gameStateEntity).Destroy();
				}
			}
		}
	}

	public GameStateEntity SetBattleDamageStats(Dictionary<string, float> newRed, Dictionary<string, float> newBlue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBattleDamageStats)
		{
			throw new EntitasException("Could not set BattleDamageStats!\n" + ((object)this)?.ToString() + " already has an entity with BattleDamageStatsComponent!", "You should check if the context already has a battleDamageStatsEntity before setting it or use context.ReplaceBattleDamageStats().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddBattleDamageStats(newRed, newBlue);
		return gameStateEntity;
	}

	public void ReplaceBattleDamageStats(Dictionary<string, float> newRed, Dictionary<string, float> newBlue)
	{
		GameStateEntity gameStateEntity = battleDamageStatsEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetBattleDamageStats(newRed, newBlue);
		}
		else
		{
			gameStateEntity.ReplaceBattleDamageStats(newRed, newBlue);
		}
	}

	public void RemoveBattleDamageStats()
	{
		((Entity)battleDamageStatsEntity).Destroy();
	}

	public GameStateEntity SetBattleDuration(int newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBattleDuration)
		{
			throw new EntitasException("Could not set BattleDuration!\n" + ((object)this)?.ToString() + " already has an entity with BattleDurationComponent!", "You should check if the context already has a battleDurationEntity before setting it or use context.ReplaceBattleDuration().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddBattleDuration(newValue);
		return gameStateEntity;
	}

	public void ReplaceBattleDuration(int newValue)
	{
		GameStateEntity gameStateEntity = battleDurationEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetBattleDuration(newValue);
		}
		else
		{
			gameStateEntity.ReplaceBattleDuration(newValue);
		}
	}

	public void RemoveBattleDuration()
	{
		((Entity)battleDurationEntity).Destroy();
	}

	public GameStateEntity SetBattleElapsedTime(float newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBattleElapsedTime)
		{
			throw new EntitasException("Could not set BattleElapsedTime!\n" + ((object)this)?.ToString() + " already has an entity with BattleElapsedTimeComponent!", "You should check if the context already has a battleElapsedTimeEntity before setting it or use context.ReplaceBattleElapsedTime().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddBattleElapsedTime(newValue);
		return gameStateEntity;
	}

	public void ReplaceBattleElapsedTime(float newValue)
	{
		GameStateEntity gameStateEntity = battleElapsedTimeEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetBattleElapsedTime(newValue);
		}
		else
		{
			gameStateEntity.ReplaceBattleElapsedTime(newValue);
		}
	}

	public void RemoveBattleElapsedTime()
	{
		((Entity)battleElapsedTimeEntity).Destroy();
	}

	public GameStateEntity SetBattleFieldLength(float newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBattleFieldLength)
		{
			throw new EntitasException("Could not set BattleFieldLength!\n" + ((object)this)?.ToString() + " already has an entity with BattleFieldLengthComponent!", "You should check if the context already has a battleFieldLengthEntity before setting it or use context.ReplaceBattleFieldLength().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddBattleFieldLength(newValue);
		return gameStateEntity;
	}

	public void ReplaceBattleFieldLength(float newValue)
	{
		GameStateEntity gameStateEntity = battleFieldLengthEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetBattleFieldLength(newValue);
		}
		else
		{
			gameStateEntity.ReplaceBattleFieldLength(newValue);
		}
	}

	public void RemoveBattleFieldLength()
	{
		((Entity)battleFieldLengthEntity).Destroy();
	}

	public GameStateEntity SetBattleFieldLevel(Level newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBattleFieldLevel)
		{
			throw new EntitasException("Could not set BattleFieldLevel!\n" + ((object)this)?.ToString() + " already has an entity with BattleFieldLevelComponent!", "You should check if the context already has a battleFieldLevelEntity before setting it or use context.ReplaceBattleFieldLevel().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddBattleFieldLevel(newValue);
		return gameStateEntity;
	}

	public void ReplaceBattleFieldLevel(Level newValue)
	{
		GameStateEntity gameStateEntity = battleFieldLevelEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetBattleFieldLevel(newValue);
		}
		else
		{
			gameStateEntity.ReplaceBattleFieldLevel(newValue);
		}
	}

	public void RemoveBattleFieldLevel()
	{
		((Entity)battleFieldLevelEntity).Destroy();
	}

	public GameStateEntity SetBattleFieldMapIdentifier(string newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBattleFieldMapIdentifier)
		{
			throw new EntitasException("Could not set BattleFieldMapIdentifier!\n" + ((object)this)?.ToString() + " already has an entity with BattleFieldMapIdentifierComponent!", "You should check if the context already has a battleFieldMapIdentifierEntity before setting it or use context.ReplaceBattleFieldMapIdentifier().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddBattleFieldMapIdentifier(newValue);
		return gameStateEntity;
	}

	public void ReplaceBattleFieldMapIdentifier(string newValue)
	{
		GameStateEntity gameStateEntity = battleFieldMapIdentifierEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetBattleFieldMapIdentifier(newValue);
		}
		else
		{
			gameStateEntity.ReplaceBattleFieldMapIdentifier(newValue);
		}
	}

	public void RemoveBattleFieldMapIdentifier()
	{
		((Entity)battleFieldMapIdentifierEntity).Destroy();
	}

	public GameStateEntity SetBattleFieldSubLevelIndex(int newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBattleFieldSubLevelIndex)
		{
			throw new EntitasException("Could not set BattleFieldSubLevelIndex!\n" + ((object)this)?.ToString() + " already has an entity with BattleFieldSubLevelIndexComponent!", "You should check if the context already has a battleFieldSubLevelIndexEntity before setting it or use context.ReplaceBattleFieldSubLevelIndex().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddBattleFieldSubLevelIndex(newValue);
		return gameStateEntity;
	}

	public void ReplaceBattleFieldSubLevelIndex(int newValue)
	{
		GameStateEntity gameStateEntity = battleFieldSubLevelIndexEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetBattleFieldSubLevelIndex(newValue);
		}
		else
		{
			gameStateEntity.ReplaceBattleFieldSubLevelIndex(newValue);
		}
	}

	public void RemoveBattleFieldSubLevelIndex()
	{
		((Entity)battleFieldSubLevelIndexEntity).Destroy();
	}

	public GameStateEntity SetBattleId(string newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBattleId)
		{
			throw new EntitasException("Could not set BattleId!\n" + ((object)this)?.ToString() + " already has an entity with BattleIdComponent!", "You should check if the context already has a battleIdEntity before setting it or use context.ReplaceBattleId().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddBattleId(newValue);
		return gameStateEntity;
	}

	public void ReplaceBattleId(string newValue)
	{
		GameStateEntity gameStateEntity = battleIdEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetBattleId(newValue);
		}
		else
		{
			gameStateEntity.ReplaceBattleId(newValue);
		}
	}

	public void RemoveBattleId()
	{
		((Entity)battleIdEntity).Destroy();
	}

	public GameStateEntity SetBattleProgressStats(List<Bonus> newBonusRecord, int newClearStages)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBattleProgressStats)
		{
			throw new EntitasException("Could not set BattleProgressStats!\n" + ((object)this)?.ToString() + " already has an entity with BattleProgressStatsComponent!", "You should check if the context already has a battleProgressStatsEntity before setting it or use context.ReplaceBattleProgressStats().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddBattleProgressStats(newBonusRecord, newClearStages);
		return gameStateEntity;
	}

	public void ReplaceBattleProgressStats(List<Bonus> newBonusRecord, int newClearStages)
	{
		GameStateEntity gameStateEntity = battleProgressStatsEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetBattleProgressStats(newBonusRecord, newClearStages);
		}
		else
		{
			gameStateEntity.ReplaceBattleProgressStats(newBonusRecord, newClearStages);
		}
	}

	public void RemoveBattleProgressStats()
	{
		((Entity)battleProgressStatsEntity).Destroy();
	}

	public GameStateEntity SetBattleStats(Dictionary<Team, TeamUnitStats> newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBattleStats)
		{
			throw new EntitasException("Could not set BattleStats!\n" + ((object)this)?.ToString() + " already has an entity with BattleStatsComponent!", "You should check if the context already has a battleStatsEntity before setting it or use context.ReplaceBattleStats().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddBattleStats(newValue);
		return gameStateEntity;
	}

	public void ReplaceBattleStats(Dictionary<Team, TeamUnitStats> newValue)
	{
		GameStateEntity gameStateEntity = battleStatsEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetBattleStats(newValue);
		}
		else
		{
			gameStateEntity.ReplaceBattleStats(newValue);
		}
	}

	public void RemoveBattleStats()
	{
		((Entity)battleStatsEntity).Destroy();
	}

	public GameStateEntity SetBattleTimeLeft(int newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBattleTimeLeft)
		{
			throw new EntitasException("Could not set BattleTimeLeft!\n" + ((object)this)?.ToString() + " already has an entity with BattleTimeLeftComponent!", "You should check if the context already has a battleTimeLeftEntity before setting it or use context.ReplaceBattleTimeLeft().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddBattleTimeLeft(newValue);
		return gameStateEntity;
	}

	public void ReplaceBattleTimeLeft(int newValue)
	{
		GameStateEntity gameStateEntity = battleTimeLeftEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetBattleTimeLeft(newValue);
		}
		else
		{
			gameStateEntity.ReplaceBattleTimeLeft(newValue);
		}
	}

	public void RemoveBattleTimeLeft()
	{
		((Entity)battleTimeLeftEntity).Destroy();
	}

	public GameStateEntity SetBattleWaveDuration(int newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBattleWaveDuration)
		{
			throw new EntitasException("Could not set BattleWaveDuration!\n" + ((object)this)?.ToString() + " already has an entity with BattleWaveDurationComponent!", "You should check if the context already has a battleWaveDurationEntity before setting it or use context.ReplaceBattleWaveDuration().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddBattleWaveDuration(newValue);
		return gameStateEntity;
	}

	public void ReplaceBattleWaveDuration(int newValue)
	{
		GameStateEntity gameStateEntity = battleWaveDurationEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetBattleWaveDuration(newValue);
		}
		else
		{
			gameStateEntity.ReplaceBattleWaveDuration(newValue);
		}
	}

	public void RemoveBattleWaveDuration()
	{
		((Entity)battleWaveDurationEntity).Destroy();
	}

	public GameStateEntity SetBattleWaveElapsedTime(float newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBattleWaveElapsedTime)
		{
			throw new EntitasException("Could not set BattleWaveElapsedTime!\n" + ((object)this)?.ToString() + " already has an entity with BattleWaveElapsedTimeComponent!", "You should check if the context already has a battleWaveElapsedTimeEntity before setting it or use context.ReplaceBattleWaveElapsedTime().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddBattleWaveElapsedTime(newValue);
		return gameStateEntity;
	}

	public void ReplaceBattleWaveElapsedTime(float newValue)
	{
		GameStateEntity gameStateEntity = battleWaveElapsedTimeEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetBattleWaveElapsedTime(newValue);
		}
		else
		{
			gameStateEntity.ReplaceBattleWaveElapsedTime(newValue);
		}
	}

	public void RemoveBattleWaveElapsedTime()
	{
		((Entity)battleWaveElapsedTimeEntity).Destroy();
	}

	public GameStateEntity SetBattleWaveTimeLeft(int newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBattleWaveTimeLeft)
		{
			throw new EntitasException("Could not set BattleWaveTimeLeft!\n" + ((object)this)?.ToString() + " already has an entity with BattleWaveTimeLeftComponent!", "You should check if the context already has a battleWaveTimeLeftEntity before setting it or use context.ReplaceBattleWaveTimeLeft().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddBattleWaveTimeLeft(newValue);
		return gameStateEntity;
	}

	public void ReplaceBattleWaveTimeLeft(int newValue)
	{
		GameStateEntity gameStateEntity = battleWaveTimeLeftEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetBattleWaveTimeLeft(newValue);
		}
		else
		{
			gameStateEntity.ReplaceBattleWaveTimeLeft(newValue);
		}
	}

	public void RemoveBattleWaveTimeLeft()
	{
		((Entity)battleWaveTimeLeftEntity).Destroy();
	}

	public GameStateEntity SetBattleWaveUnSpawnCount(int newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBattleWaveUnSpawnCount)
		{
			throw new EntitasException("Could not set BattleWaveUnSpawnCount!\n" + ((object)this)?.ToString() + " already has an entity with BattleWaveUnSpawnCountComponent!", "You should check if the context already has a battleWaveUnSpawnCountEntity before setting it or use context.ReplaceBattleWaveUnSpawnCount().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddBattleWaveUnSpawnCount(newValue);
		return gameStateEntity;
	}

	public void ReplaceBattleWaveUnSpawnCount(int newValue)
	{
		GameStateEntity gameStateEntity = battleWaveUnSpawnCountEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetBattleWaveUnSpawnCount(newValue);
		}
		else
		{
			gameStateEntity.ReplaceBattleWaveUnSpawnCount(newValue);
		}
	}

	public void RemoveBattleWaveUnSpawnCount()
	{
		((Entity)battleWaveUnSpawnCountEntity).Destroy();
	}

	public GameStateEntity SetBlueTeamCampPosition(Vector3 newValue)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBlueTeamCampPosition)
		{
			throw new EntitasException("Could not set BlueTeamCampPosition!\n" + ((object)this)?.ToString() + " already has an entity with BlueTeamCampPositionComponent!", "You should check if the context already has a blueTeamCampPositionEntity before setting it or use context.ReplaceBlueTeamCampPosition().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddBlueTeamCampPosition(newValue);
		return gameStateEntity;
	}

	public void ReplaceBlueTeamCampPosition(Vector3 newValue)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		GameStateEntity gameStateEntity = blueTeamCampPositionEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetBlueTeamCampPosition(newValue);
		}
		else
		{
			gameStateEntity.ReplaceBlueTeamCampPosition(newValue);
		}
	}

	public void RemoveBlueTeamCampPosition()
	{
		((Entity)blueTeamCampPositionEntity).Destroy();
	}

	public GameStateEntity SetBlueTeamCombatPower(int newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBlueTeamCombatPower)
		{
			throw new EntitasException("Could not set BlueTeamCombatPower!\n" + ((object)this)?.ToString() + " already has an entity with BlueTeamCombatPowerComponent!", "You should check if the context already has a blueTeamCombatPowerEntity before setting it or use context.ReplaceBlueTeamCombatPower().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddBlueTeamCombatPower(newValue);
		return gameStateEntity;
	}

	public void ReplaceBlueTeamCombatPower(int newValue)
	{
		GameStateEntity gameStateEntity = blueTeamCombatPowerEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetBlueTeamCombatPower(newValue);
		}
		else
		{
			gameStateEntity.ReplaceBlueTeamCombatPower(newValue);
		}
	}

	public void RemoveBlueTeamCombatPower()
	{
		((Entity)blueTeamCombatPowerEntity).Destroy();
	}

	public GameStateEntity SetBlueTeamStagingAreaPosition(Vector3[] newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBlueTeamStagingAreaPosition)
		{
			throw new EntitasException("Could not set BlueTeamStagingAreaPosition!\n" + ((object)this)?.ToString() + " already has an entity with BlueTeamStagingAreaPositionComponent!", "You should check if the context already has a blueTeamStagingAreaPositionEntity before setting it or use context.ReplaceBlueTeamStagingAreaPosition().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddBlueTeamStagingAreaPosition(newValue);
		return gameStateEntity;
	}

	public void ReplaceBlueTeamStagingAreaPosition(Vector3[] newValue)
	{
		GameStateEntity gameStateEntity = blueTeamStagingAreaPositionEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetBlueTeamStagingAreaPosition(newValue);
		}
		else
		{
			gameStateEntity.ReplaceBlueTeamStagingAreaPosition(newValue);
		}
	}

	public void RemoveBlueTeamStagingAreaPosition()
	{
		((Entity)blueTeamStagingAreaPositionEntity).Destroy();
	}

	public GameStateEntity SetCameraActive(bool newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasCameraActive)
		{
			throw new EntitasException("Could not set CameraActive!\n" + ((object)this)?.ToString() + " already has an entity with CameraActiveComponent!", "You should check if the context already has a cameraActiveEntity before setting it or use context.ReplaceCameraActive().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddCameraActive(newValue);
		return gameStateEntity;
	}

	public void ReplaceCameraActive(bool newValue)
	{
		GameStateEntity gameStateEntity = cameraActiveEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetCameraActive(newValue);
		}
		else
		{
			gameStateEntity.ReplaceCameraActive(newValue);
		}
	}

	public void RemoveCameraActive()
	{
		((Entity)cameraActiveEntity).Destroy();
	}

	public GameStateEntity SetCameraAspect(float newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasCameraAspect)
		{
			throw new EntitasException("Could not set CameraAspect!\n" + ((object)this)?.ToString() + " already has an entity with CameraAspectComponent!", "You should check if the context already has a cameraAspectEntity before setting it or use context.ReplaceCameraAspect().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddCameraAspect(newValue);
		return gameStateEntity;
	}

	public void ReplaceCameraAspect(float newValue)
	{
		GameStateEntity gameStateEntity = cameraAspectEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetCameraAspect(newValue);
		}
		else
		{
			gameStateEntity.ReplaceCameraAspect(newValue);
		}
	}

	public void RemoveCameraAspect()
	{
		((Entity)cameraAspectEntity).Destroy();
	}

	public GameStateEntity SetCameraFollowTeam(Team newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasCameraFollowTeam)
		{
			throw new EntitasException("Could not set CameraFollowTeam!\n" + ((object)this)?.ToString() + " already has an entity with CameraFollowTeamComponent!", "You should check if the context already has a cameraFollowTeamEntity before setting it or use context.ReplaceCameraFollowTeam().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddCameraFollowTeam(newValue);
		return gameStateEntity;
	}

	public void ReplaceCameraFollowTeam(Team newValue)
	{
		GameStateEntity gameStateEntity = cameraFollowTeamEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetCameraFollowTeam(newValue);
		}
		else
		{
			gameStateEntity.ReplaceCameraFollowTeam(newValue);
		}
	}

	public void RemoveCameraFollowTeam()
	{
		((Entity)cameraFollowTeamEntity).Destroy();
	}

	public GameStateEntity SetCameraMoveLimit(Vector3 newPosition, Vector3 newSize)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasCameraMoveLimit)
		{
			throw new EntitasException("Could not set CameraMoveLimit!\n" + ((object)this)?.ToString() + " already has an entity with CameraMoveLimitComponent!", "You should check if the context already has a cameraMoveLimitEntity before setting it or use context.ReplaceCameraMoveLimit().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddCameraMoveLimit(newPosition, newSize);
		return gameStateEntity;
	}

	public void ReplaceCameraMoveLimit(Vector3 newPosition, Vector3 newSize)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		GameStateEntity gameStateEntity = cameraMoveLimitEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetCameraMoveLimit(newPosition, newSize);
		}
		else
		{
			gameStateEntity.ReplaceCameraMoveLimit(newPosition, newSize);
		}
	}

	public void RemoveCameraMoveLimit()
	{
		((Entity)cameraMoveLimitEntity).Destroy();
	}

	public GameStateEntity SetCameraPosition(Vector3 newValue)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasCameraPosition)
		{
			throw new EntitasException("Could not set CameraPosition!\n" + ((object)this)?.ToString() + " already has an entity with CameraPositionComponent!", "You should check if the context already has a cameraPositionEntity before setting it or use context.ReplaceCameraPosition().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddCameraPosition(newValue);
		return gameStateEntity;
	}

	public void ReplaceCameraPosition(Vector3 newValue)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		GameStateEntity gameStateEntity = cameraPositionEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetCameraPosition(newValue);
		}
		else
		{
			gameStateEntity.ReplaceCameraPosition(newValue);
		}
	}

	public void RemoveCameraPosition()
	{
		((Entity)cameraPositionEntity).Destroy();
	}

	public GameStateEntity SetCameraRotation(Quaternion newValue)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasCameraRotation)
		{
			throw new EntitasException("Could not set CameraRotation!\n" + ((object)this)?.ToString() + " already has an entity with CameraRotationComponent!", "You should check if the context already has a cameraRotationEntity before setting it or use context.ReplaceCameraRotation().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddCameraRotation(newValue);
		return gameStateEntity;
	}

	public void ReplaceCameraRotation(Quaternion newValue)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		GameStateEntity gameStateEntity = cameraRotationEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetCameraRotation(newValue);
		}
		else
		{
			gameStateEntity.ReplaceCameraRotation(newValue);
		}
	}

	public void RemoveCameraRotation()
	{
		((Entity)cameraRotationEntity).Destroy();
	}

	public GameStateEntity SetCameraSize(float newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasCameraSize)
		{
			throw new EntitasException("Could not set CameraSize!\n" + ((object)this)?.ToString() + " already has an entity with CameraSizeComponent!", "You should check if the context already has a cameraSizeEntity before setting it or use context.ReplaceCameraSize().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddCameraSize(newValue);
		return gameStateEntity;
	}

	public void ReplaceCameraSize(float newValue)
	{
		GameStateEntity gameStateEntity = cameraSizeEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetCameraSize(newValue);
		}
		else
		{
			gameStateEntity.ReplaceCameraSize(newValue);
		}
	}

	public void RemoveCameraSize()
	{
		((Entity)cameraSizeEntity).Destroy();
	}

	public GameStateEntity SetCharacterArchive(CharacterArchive newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasCharacterArchive)
		{
			throw new EntitasException("Could not set CharacterArchive!\n" + ((object)this)?.ToString() + " already has an entity with CharacterArchiveComponent!", "You should check if the context already has a characterArchiveEntity before setting it or use context.ReplaceCharacterArchive().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddCharacterArchive(newValue);
		return gameStateEntity;
	}

	public void ReplaceCharacterArchive(CharacterArchive newValue)
	{
		GameStateEntity gameStateEntity = characterArchiveEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetCharacterArchive(newValue);
		}
		else
		{
			gameStateEntity.ReplaceCharacterArchive(newValue);
		}
	}

	public void RemoveCharacterArchive()
	{
		((Entity)characterArchiveEntity).Destroy();
	}

	public GameStateEntity SetLoadingAnimationDirection(LoadingAnimationDirection newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasLoadingAnimationDirection)
		{
			throw new EntitasException("Could not set LoadingAnimationDirection!\n" + ((object)this)?.ToString() + " already has an entity with LoadingAnimationDirectionComponent!", "You should check if the context already has a loadingAnimationDirectionEntity before setting it or use context.ReplaceLoadingAnimationDirection().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddLoadingAnimationDirection(newValue);
		return gameStateEntity;
	}

	public void ReplaceLoadingAnimationDirection(LoadingAnimationDirection newValue)
	{
		GameStateEntity gameStateEntity = loadingAnimationDirectionEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetLoadingAnimationDirection(newValue);
		}
		else
		{
			gameStateEntity.ReplaceLoadingAnimationDirection(newValue);
		}
	}

	public void RemoveLoadingAnimationDirection()
	{
		((Entity)loadingAnimationDirectionEntity).Destroy();
	}

	public GameStateEntity SetLoadingPanel(IUiPanel newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasLoadingPanel)
		{
			throw new EntitasException("Could not set LoadingPanel!\n" + ((object)this)?.ToString() + " already has an entity with LoadingPanelComponent!", "You should check if the context already has a loadingPanelEntity before setting it or use context.ReplaceLoadingPanel().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddLoadingPanel(newValue);
		return gameStateEntity;
	}

	public void ReplaceLoadingPanel(IUiPanel newValue)
	{
		GameStateEntity gameStateEntity = loadingPanelEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetLoadingPanel(newValue);
		}
		else
		{
			gameStateEntity.ReplaceLoadingPanel(newValue);
		}
	}

	public void RemoveLoadingPanel()
	{
		((Entity)loadingPanelEntity).Destroy();
	}

	public GameStateEntity SetLoadingPanelStatus(LoadingPanelStatus newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasLoadingPanelStatus)
		{
			throw new EntitasException("Could not set LoadingPanelStatus!\n" + ((object)this)?.ToString() + " already has an entity with LoadingPanelStatusComponent!", "You should check if the context already has a loadingPanelStatusEntity before setting it or use context.ReplaceLoadingPanelStatus().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddLoadingPanelStatus(newValue);
		return gameStateEntity;
	}

	public void ReplaceLoadingPanelStatus(LoadingPanelStatus newValue)
	{
		GameStateEntity gameStateEntity = loadingPanelStatusEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetLoadingPanelStatus(newValue);
		}
		else
		{
			gameStateEntity.ReplaceLoadingPanelStatus(newValue);
		}
	}

	public void RemoveLoadingPanelStatus()
	{
		((Entity)loadingPanelStatusEntity).Destroy();
	}

	public GameStateEntity SetLoadingProgress(int newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasLoadingProgress)
		{
			throw new EntitasException("Could not set LoadingProgress!\n" + ((object)this)?.ToString() + " already has an entity with LoadingProgressComponent!", "You should check if the context already has a loadingProgressEntity before setting it or use context.ReplaceLoadingProgress().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddLoadingProgress(newValue);
		return gameStateEntity;
	}

	public void ReplaceLoadingProgress(int newValue)
	{
		GameStateEntity gameStateEntity = loadingProgressEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetLoadingProgress(newValue);
		}
		else
		{
			gameStateEntity.ReplaceLoadingProgress(newValue);
		}
	}

	public void RemoveLoadingProgress()
	{
		((Entity)loadingProgressEntity).Destroy();
	}

	public GameStateEntity SetLoadingTotal(int newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasLoadingTotal)
		{
			throw new EntitasException("Could not set LoadingTotal!\n" + ((object)this)?.ToString() + " already has an entity with LoadingTotalComponent!", "You should check if the context already has a loadingTotalEntity before setting it or use context.ReplaceLoadingTotal().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddLoadingTotal(newValue);
		return gameStateEntity;
	}

	public void ReplaceLoadingTotal(int newValue)
	{
		GameStateEntity gameStateEntity = loadingTotalEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetLoadingTotal(newValue);
		}
		else
		{
			gameStateEntity.ReplaceLoadingTotal(newValue);
		}
	}

	public void RemoveLoadingTotal()
	{
		((Entity)loadingTotalEntity).Destroy();
	}

	public GameStateEntity SetLoser(Team newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasLoser)
		{
			throw new EntitasException("Could not set Loser!\n" + ((object)this)?.ToString() + " already has an entity with LoserComponent!", "You should check if the context already has a loserEntity before setting it or use context.ReplaceLoser().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddLoser(newValue);
		return gameStateEntity;
	}

	public void ReplaceLoser(Team newValue)
	{
		GameStateEntity gameStateEntity = loserEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetLoser(newValue);
		}
		else
		{
			gameStateEntity.ReplaceLoser(newValue);
		}
	}

	public void RemoveLoser()
	{
		((Entity)loserEntity).Destroy();
	}

	public GameStateEntity SetOfflineBonuses(List<Bonus> newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasOfflineBonuses)
		{
			throw new EntitasException("Could not set OfflineBonuses!\n" + ((object)this)?.ToString() + " already has an entity with OfflineBonusesComponent!", "You should check if the context already has a offlineBonusesEntity before setting it or use context.ReplaceOfflineBonuses().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddOfflineBonuses(newValue);
		return gameStateEntity;
	}

	public void ReplaceOfflineBonuses(List<Bonus> newValue)
	{
		GameStateEntity gameStateEntity = offlineBonusesEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetOfflineBonuses(newValue);
		}
		else
		{
			gameStateEntity.ReplaceOfflineBonuses(newValue);
		}
	}

	public void RemoveOfflineBonuses()
	{
		((Entity)offlineBonusesEntity).Destroy();
	}

	public GameStateEntity SetOfflineSeconds(int newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasOfflineSeconds)
		{
			throw new EntitasException("Could not set OfflineSeconds!\n" + ((object)this)?.ToString() + " already has an entity with OfflineSecondsComponent!", "You should check if the context already has a offlineSecondsEntity before setting it or use context.ReplaceOfflineSeconds().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddOfflineSeconds(newValue);
		return gameStateEntity;
	}

	public void ReplaceOfflineSeconds(int newValue)
	{
		GameStateEntity gameStateEntity = offlineSecondsEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetOfflineSeconds(newValue);
		}
		else
		{
			gameStateEntity.ReplaceOfflineSeconds(newValue);
		}
	}

	public void RemoveOfflineSeconds()
	{
		((Entity)offlineSecondsEntity).Destroy();
	}

	public GameStateEntity SetRedTeamCampPosition(Vector3 newValue)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasRedTeamCampPosition)
		{
			throw new EntitasException("Could not set RedTeamCampPosition!\n" + ((object)this)?.ToString() + " already has an entity with RedTeamCampPositionComponent!", "You should check if the context already has a redTeamCampPositionEntity before setting it or use context.ReplaceRedTeamCampPosition().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddRedTeamCampPosition(newValue);
		return gameStateEntity;
	}

	public void ReplaceRedTeamCampPosition(Vector3 newValue)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		GameStateEntity gameStateEntity = redTeamCampPositionEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetRedTeamCampPosition(newValue);
		}
		else
		{
			gameStateEntity.ReplaceRedTeamCampPosition(newValue);
		}
	}

	public void RemoveRedTeamCampPosition()
	{
		((Entity)redTeamCampPositionEntity).Destroy();
	}

	public GameStateEntity SetRedTeamCombatPower(int newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasRedTeamCombatPower)
		{
			throw new EntitasException("Could not set RedTeamCombatPower!\n" + ((object)this)?.ToString() + " already has an entity with RedTeamCombatPowerComponent!", "You should check if the context already has a redTeamCombatPowerEntity before setting it or use context.ReplaceRedTeamCombatPower().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddRedTeamCombatPower(newValue);
		return gameStateEntity;
	}

	public void ReplaceRedTeamCombatPower(int newValue)
	{
		GameStateEntity gameStateEntity = redTeamCombatPowerEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetRedTeamCombatPower(newValue);
		}
		else
		{
			gameStateEntity.ReplaceRedTeamCombatPower(newValue);
		}
	}

	public void RemoveRedTeamCombatPower()
	{
		((Entity)redTeamCombatPowerEntity).Destroy();
	}

	public GameStateEntity SetRedTeamStagingAreaPosition(Vector3[] newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasRedTeamStagingAreaPosition)
		{
			throw new EntitasException("Could not set RedTeamStagingAreaPosition!\n" + ((object)this)?.ToString() + " already has an entity with RedTeamStagingAreaPositionComponent!", "You should check if the context already has a redTeamStagingAreaPositionEntity before setting it or use context.ReplaceRedTeamStagingAreaPosition().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddRedTeamStagingAreaPosition(newValue);
		return gameStateEntity;
	}

	public void ReplaceRedTeamStagingAreaPosition(Vector3[] newValue)
	{
		GameStateEntity gameStateEntity = redTeamStagingAreaPositionEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetRedTeamStagingAreaPosition(newValue);
		}
		else
		{
			gameStateEntity.ReplaceRedTeamStagingAreaPosition(newValue);
		}
	}

	public void RemoveRedTeamStagingAreaPosition()
	{
		((Entity)redTeamStagingAreaPositionEntity).Destroy();
	}

	public GameStateEntity SetRefreshTeamHealthPointsTotal(Team newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasRefreshTeamHealthPointsTotal)
		{
			throw new EntitasException("Could not set RefreshTeamHealthPointsTotal!\n" + ((object)this)?.ToString() + " already has an entity with RefreshTeamHealthPointsTotalComponent!", "You should check if the context already has a refreshTeamHealthPointsTotalEntity before setting it or use context.ReplaceRefreshTeamHealthPointsTotal().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddRefreshTeamHealthPointsTotal(newValue);
		return gameStateEntity;
	}

	public void ReplaceRefreshTeamHealthPointsTotal(Team newValue)
	{
		GameStateEntity gameStateEntity = refreshTeamHealthPointsTotalEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetRefreshTeamHealthPointsTotal(newValue);
		}
		else
		{
			gameStateEntity.ReplaceRefreshTeamHealthPointsTotal(newValue);
		}
	}

	public void RemoveRefreshTeamHealthPointsTotal()
	{
		((Entity)refreshTeamHealthPointsTotalEntity).Destroy();
	}

	public GameStateEntity SetReplayBattleId(string newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasReplayBattleId)
		{
			throw new EntitasException("Could not set ReplayBattleId!\n" + ((object)this)?.ToString() + " already has an entity with ReplayBattleIdComponent!", "You should check if the context already has a replayBattleIdEntity before setting it or use context.ReplaceReplayBattleId().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddReplayBattleId(newValue);
		return gameStateEntity;
	}

	public void ReplaceReplayBattleId(string newValue)
	{
		GameStateEntity gameStateEntity = replayBattleIdEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetReplayBattleId(newValue);
		}
		else
		{
			gameStateEntity.ReplaceReplayBattleId(newValue);
		}
	}

	public void RemoveReplayBattleId()
	{
		((Entity)replayBattleIdEntity).Destroy();
	}

	public GameStateEntity SetReplayMode(int newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasReplayMode)
		{
			throw new EntitasException("Could not set ReplayMode!\n" + ((object)this)?.ToString() + " already has an entity with ReplayModeComponent!", "You should check if the context already has a replayModeEntity before setting it or use context.ReplaceReplayMode().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddReplayMode(newValue);
		return gameStateEntity;
	}

	public void ReplaceReplayMode(int newValue)
	{
		GameStateEntity gameStateEntity = replayModeEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetReplayMode(newValue);
		}
		else
		{
			gameStateEntity.ReplaceReplayMode(newValue);
		}
	}

	public void RemoveReplayMode()
	{
		((Entity)replayModeEntity).Destroy();
	}

	public GameStateEntity SetReplayState(int newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasReplayState)
		{
			throw new EntitasException("Could not set ReplayState!\n" + ((object)this)?.ToString() + " already has an entity with ReplayStateComponent!", "You should check if the context already has a replayStateEntity before setting it or use context.ReplaceReplayState().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddReplayState(newValue);
		return gameStateEntity;
	}

	public void ReplaceReplayState(int newValue)
	{
		GameStateEntity gameStateEntity = replayStateEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetReplayState(newValue);
		}
		else
		{
			gameStateEntity.ReplaceReplayState(newValue);
		}
	}

	public void RemoveReplayState()
	{
		((Entity)replayStateEntity).Destroy();
	}

	public GameStateEntity SetSubLevelWinner(Team newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasSubLevelWinner)
		{
			throw new EntitasException("Could not set SubLevelWinner!\n" + ((object)this)?.ToString() + " already has an entity with SubLevelWinnerComponent!", "You should check if the context already has a subLevelWinnerEntity before setting it or use context.ReplaceSubLevelWinner().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddSubLevelWinner(newValue);
		return gameStateEntity;
	}

	public void ReplaceSubLevelWinner(Team newValue)
	{
		GameStateEntity gameStateEntity = subLevelWinnerEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetSubLevelWinner(newValue);
		}
		else
		{
			gameStateEntity.ReplaceSubLevelWinner(newValue);
		}
	}

	public void RemoveSubLevelWinner()
	{
		((Entity)subLevelWinnerEntity).Destroy();
	}

	public GameStateEntity SetTeamHealthPointsTotal(float newRedCurrent, float newRedTotal, float newBlueCurrent, float newBlueTotal)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasTeamHealthPointsTotal)
		{
			throw new EntitasException("Could not set TeamHealthPointsTotal!\n" + ((object)this)?.ToString() + " already has an entity with TeamHealthPointsTotalComponent!", "You should check if the context already has a teamHealthPointsTotalEntity before setting it or use context.ReplaceTeamHealthPointsTotal().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddTeamHealthPointsTotal(newRedCurrent, newRedTotal, newBlueCurrent, newBlueTotal);
		return gameStateEntity;
	}

	public void ReplaceTeamHealthPointsTotal(float newRedCurrent, float newRedTotal, float newBlueCurrent, float newBlueTotal)
	{
		GameStateEntity gameStateEntity = teamHealthPointsTotalEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetTeamHealthPointsTotal(newRedCurrent, newRedTotal, newBlueCurrent, newBlueTotal);
		}
		else
		{
			gameStateEntity.ReplaceTeamHealthPointsTotal(newRedCurrent, newRedTotal, newBlueCurrent, newBlueTotal);
		}
	}

	public void RemoveTeamHealthPointsTotal()
	{
		((Entity)teamHealthPointsTotalEntity).Destroy();
	}

	public GameStateEntity SetUnlockedSoldiers(List<string> newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasUnlockedSoldiers)
		{
			throw new EntitasException("Could not set UnlockedSoldiers!\n" + ((object)this)?.ToString() + " already has an entity with UnlockedSoldiersComponent!", "You should check if the context already has a unlockedSoldiersEntity before setting it or use context.ReplaceUnlockedSoldiers().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddUnlockedSoldiers(newValue);
		return gameStateEntity;
	}

	public void ReplaceUnlockedSoldiers(List<string> newValue)
	{
		GameStateEntity gameStateEntity = unlockedSoldiersEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetUnlockedSoldiers(newValue);
		}
		else
		{
			gameStateEntity.ReplaceUnlockedSoldiers(newValue);
		}
	}

	public void RemoveUnlockedSoldiers()
	{
		((Entity)unlockedSoldiersEntity).Destroy();
	}

	public GameStateEntity SetUser(User newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasUser)
		{
			throw new EntitasException("Could not set User!\n" + ((object)this)?.ToString() + " already has an entity with UserComponent!", "You should check if the context already has a userEntity before setting it or use context.ReplaceUser().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddUser(newValue);
		return gameStateEntity;
	}

	public void ReplaceUser(User newValue)
	{
		GameStateEntity gameStateEntity = userEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetUser(newValue);
		}
		else
		{
			gameStateEntity.ReplaceUser(newValue);
		}
	}

	public void RemoveUser()
	{
		((Entity)userEntity).Destroy();
	}

	public GameStateEntity SetWinner(Team newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasWinner)
		{
			throw new EntitasException("Could not set Winner!\n" + ((object)this)?.ToString() + " already has an entity with WinnerComponent!", "You should check if the context already has a winnerEntity before setting it or use context.ReplaceWinner().");
		}
		GameStateEntity gameStateEntity = base.CreateEntity();
		gameStateEntity.AddWinner(newValue);
		return gameStateEntity;
	}

	public void ReplaceWinner(Team newValue)
	{
		GameStateEntity gameStateEntity = winnerEntity;
		if (gameStateEntity == null)
		{
			gameStateEntity = SetWinner(newValue);
		}
		else
		{
			gameStateEntity.ReplaceWinner(newValue);
		}
	}

	public void RemoveWinner()
	{
		((Entity)winnerEntity).Destroy();
	}

	public GameStateContext()
		: base(116, 0, new ContextInfo("GameState", GameStateComponentsLookup.componentNames, GameStateComponentsLookup.componentTypes), (Func<IEntity, IAERC>)((IEntity entity) => (IAERC)new UnsafeAERC()), (Func<GameStateEntity>)(() => new GameStateEntity()))
	{
	}//IL_0013: Unknown result type (might be due to invalid IL or missing references)
	//IL_005b: Expected O, but got Unknown

}
