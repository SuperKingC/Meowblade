using Entitas;

public sealed class GameStateMatcher
{
	private static IMatcher<GameStateEntity> _matcherAnyBattleDurationListener;

	private static IMatcher<GameStateEntity> _matcherAnyBattleFieldLengthListener;

	private static IMatcher<GameStateEntity> _matcherAnyBattleFieldLevelListener;

	private static IMatcher<GameStateEntity> _matcherAnyBattleFieldMapIdentifierListener;

	private static IMatcher<GameStateEntity> _matcherAnyBattleFieldSubLevelIndexListener;

	private static IMatcher<GameStateEntity> _matcherAnyBattleStartedListener;

	private static IMatcher<GameStateEntity> _matcherAnyBattleStartedRemovedListener;

	private static IMatcher<GameStateEntity> _matcherAnyBattleTimeLeftListener;

	private static IMatcher<GameStateEntity> _matcherAnyBattleWaveDurationListener;

	private static IMatcher<GameStateEntity> _matcherAnyBattleWaveTimeLeftListener;

	private static IMatcher<GameStateEntity> _matcherAnyBlueTeamCampPositionListener;

	private static IMatcher<GameStateEntity> _matcherAnyBlueTeamCombatPowerListener;

	private static IMatcher<GameStateEntity> _matcherAnyBlueTeamStagingAreaPositionListener;

	private static IMatcher<GameStateEntity> _matcherAnyCameraActiveListener;

	private static IMatcher<GameStateEntity> _matcherAnyCameraAspectListener;

	private static IMatcher<GameStateEntity> _matcherAnyCameraFollowingUnitListener;

	private static IMatcher<GameStateEntity> _matcherAnyCameraFollowTeamListener;

	private static IMatcher<GameStateEntity> _matcherAnyCameraMoveLimitListener;

	private static IMatcher<GameStateEntity> _matcherAnyCameraPositionListener;

	private static IMatcher<GameStateEntity> _matcherAnyCameraRotationListener;

	private static IMatcher<GameStateEntity> _matcherAnyCameraSizeListener;

	private static IMatcher<GameStateEntity> _matcherAnyCurrentLevelBattleStartedListener;

	private static IMatcher<GameStateEntity> _matcherAnyCurrentLevelBattleStartedRemovedListener;

	private static IMatcher<GameStateEntity> _matcherAnyDataReadyListener;

	private static IMatcher<GameStateEntity> _matcherAnyFreeBattleModeListener;

	private static IMatcher<GameStateEntity> _matcherAnyFreeBattleModeRemovedListener;

	private static IMatcher<GameStateEntity> _matcherAnyGameDataLoadedListener;

	private static IMatcher<GameStateEntity> _matcherAnyGameEnteredListener;

	private static IMatcher<GameStateEntity> _matcherAnyLoadingAnimationDirectionListener;

	private static IMatcher<GameStateEntity> _matcherAnyLoadingPanelListener;

	private static IMatcher<GameStateEntity> _matcherAnyLoadingPanelStatusListener;

	private static IMatcher<GameStateEntity> _matcherAnyLoadingProgressListener;

	private static IMatcher<GameStateEntity> _matcherAnyLoadingShowAllSoldierListener;

	private static IMatcher<GameStateEntity> _matcherAnyLoadingTotalListener;

	private static IMatcher<GameStateEntity> _matcherAnyLoserListener;

	private static IMatcher<GameStateEntity> _matcherAnyNextLevelComingListener;

	private static IMatcher<GameStateEntity> _matcherAnyNextLevelComingRemovedListener;

	private static IMatcher<GameStateEntity> _matcherAnyOfflineBonusesListener;

	private static IMatcher<GameStateEntity> _matcherAnyOfflineSecondsListener;

	private static IMatcher<GameStateEntity> _matcherAnyRedTeamCampPositionListener;

	private static IMatcher<GameStateEntity> _matcherAnyRedTeamCombatPowerListener;

	private static IMatcher<GameStateEntity> _matcherAnyRedTeamStagingAreaPositionListener;

	private static IMatcher<GameStateEntity> _matcherAnyReplayModeListener;

	private static IMatcher<GameStateEntity> _matcherAnyReplayModeRemovedListener;

	private static IMatcher<GameStateEntity> _matcherAnyReplayStateListener;

	private static IMatcher<GameStateEntity> _matcherAnyReplayStateRemovedListener;

	private static IMatcher<GameStateEntity> _matcherAnyShowBattleWaveCountdownListener;

	private static IMatcher<GameStateEntity> _matcherAnyShowBattleWaveCountdownRemovedListener;

	private static IMatcher<GameStateEntity> _matcherAnySubLevelWinnerListener;

	private static IMatcher<GameStateEntity> _matcherAnyTeamHealthPointsTotalListener;

	private static IMatcher<GameStateEntity> _matcherAnyUnlockedSoldiersListener;

	private static IMatcher<GameStateEntity> _matcherAnyUserDataLoadedListener;

	private static IMatcher<GameStateEntity> _matcherAnyUserListener;

	private static IMatcher<GameStateEntity> _matcherAnyWinnerListener;

	private static IMatcher<GameStateEntity> _matcherBattleDamageStats;

	private static IMatcher<GameStateEntity> _matcherBattleDuration;

	private static IMatcher<GameStateEntity> _matcherBattleDurationUpdated;

	private static IMatcher<GameStateEntity> _matcherBattleElapsedTime;

	private static IMatcher<GameStateEntity> _matcherBattleFieldLength;

	private static IMatcher<GameStateEntity> _matcherBattleFieldLevel;

	private static IMatcher<GameStateEntity> _matcherBattleFieldMapIdentifier;

	private static IMatcher<GameStateEntity> _matcherBattleFieldSubLevelIndex;

	private static IMatcher<GameStateEntity> _matcherBattleId;

	private static IMatcher<GameStateEntity> _matcherBattleProgressStats;

	private static IMatcher<GameStateEntity> _matcherBattleStarted;

	private static IMatcher<GameStateEntity> _matcherBattleStats;

	private static IMatcher<GameStateEntity> _matcherBattleStop;

	private static IMatcher<GameStateEntity> _matcherBattleTimeLeft;

	private static IMatcher<GameStateEntity> _matcherBattleWaveDuration;

	private static IMatcher<GameStateEntity> _matcherBattleWaveElapsedTime;

	private static IMatcher<GameStateEntity> _matcherBattleWaveTimeLeft;

	private static IMatcher<GameStateEntity> _matcherBattleWaveUnSpawnCount;

	private static IMatcher<GameStateEntity> _matcherBlueTeamCampPosition;

	private static IMatcher<GameStateEntity> _matcherBlueTeamCombatPower;

	private static IMatcher<GameStateEntity> _matcherBlueTeamStagingAreaPosition;

	private static IMatcher<GameStateEntity> _matcherCameraActive;

	private static IMatcher<GameStateEntity> _matcherCameraAspect;

	private static IMatcher<GameStateEntity> _matcherCameraFollowingUnit;

	private static IMatcher<GameStateEntity> _matcherCameraFollowTeam;

	private static IMatcher<GameStateEntity> _matcherCameraMoveLimit;

	private static IMatcher<GameStateEntity> _matcherCameraPosition;

	private static IMatcher<GameStateEntity> _matcherCameraRotation;

	private static IMatcher<GameStateEntity> _matcherCameraSize;

	private static IMatcher<GameStateEntity> _matcherCharacterArchive;

	private static IMatcher<GameStateEntity> _matcherCurrentLevelBattleStarted;

	private static IMatcher<GameStateEntity> _matcherDataReady;

	private static IMatcher<GameStateEntity> _matcherFreeBattleMode;

	private static IMatcher<GameStateEntity> _matcherGameDataLoaded;

	private static IMatcher<GameStateEntity> _matcherGameEntered;

	private static IMatcher<GameStateEntity> _matcherLoadingAnimationDirection;

	private static IMatcher<GameStateEntity> _matcherLoadingPanel;

	private static IMatcher<GameStateEntity> _matcherLoadingPanelStatus;

	private static IMatcher<GameStateEntity> _matcherLoadingProgress;

	private static IMatcher<GameStateEntity> _matcherLoadingShowAllSoldier;

	private static IMatcher<GameStateEntity> _matcherLoadingTotal;

	private static IMatcher<GameStateEntity> _matcherLoser;

	private static IMatcher<GameStateEntity> _matcherMainCityInitialized;

	private static IMatcher<GameStateEntity> _matcherNextLevelComing;

	private static IMatcher<GameStateEntity> _matcherOfflineBonuses;

	private static IMatcher<GameStateEntity> _matcherOfflineSeconds;

	private static IMatcher<GameStateEntity> _matcherRedTeamCampPosition;

	private static IMatcher<GameStateEntity> _matcherRedTeamCombatPower;

	private static IMatcher<GameStateEntity> _matcherRedTeamStagingAreaPosition;

	private static IMatcher<GameStateEntity> _matcherRefreshTeamHealthPointsTotal;

	private static IMatcher<GameStateEntity> _matcherReplayBattleId;

	private static IMatcher<GameStateEntity> _matcherReplayMode;

	private static IMatcher<GameStateEntity> _matcherReplayState;

	private static IMatcher<GameStateEntity> _matcherRetreat;

	private static IMatcher<GameStateEntity> _matcherShowBattleWaveCountdown;

	private static IMatcher<GameStateEntity> _matcherSubLevelWinner;

	private static IMatcher<GameStateEntity> _matcherTeamHealthPointsTotal;

	private static IMatcher<GameStateEntity> _matcherUnlockedSoldiers;

	private static IMatcher<GameStateEntity> _matcherUser;

	private static IMatcher<GameStateEntity> _matcherUserDataLoaded;

	private static IMatcher<GameStateEntity> _matcherWinner;

	private static IMatcher<GameStateEntity> _matcherWorldMapInitialized;

	public static IMatcher<GameStateEntity> AnyBattleDurationListener
	{
		get
		{
			if (_matcherAnyBattleDurationListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1]);
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyBattleDurationListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyBattleDurationListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyBattleFieldLengthListener
	{
		get
		{
			if (_matcherAnyBattleFieldLengthListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 1 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyBattleFieldLengthListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyBattleFieldLengthListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyBattleFieldLevelListener
	{
		get
		{
			if (_matcherAnyBattleFieldLevelListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 2 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyBattleFieldLevelListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyBattleFieldLevelListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyBattleFieldMapIdentifierListener
	{
		get
		{
			if (_matcherAnyBattleFieldMapIdentifierListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 3 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyBattleFieldMapIdentifierListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyBattleFieldMapIdentifierListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyBattleFieldSubLevelIndexListener
	{
		get
		{
			if (_matcherAnyBattleFieldSubLevelIndexListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 4 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyBattleFieldSubLevelIndexListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyBattleFieldSubLevelIndexListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyBattleStartedListener
	{
		get
		{
			if (_matcherAnyBattleStartedListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 5 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyBattleStartedListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyBattleStartedListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyBattleStartedRemovedListener
	{
		get
		{
			if (_matcherAnyBattleStartedRemovedListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 6 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyBattleStartedRemovedListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyBattleStartedRemovedListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyBattleTimeLeftListener
	{
		get
		{
			if (_matcherAnyBattleTimeLeftListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 7 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyBattleTimeLeftListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyBattleTimeLeftListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyBattleWaveDurationListener
	{
		get
		{
			if (_matcherAnyBattleWaveDurationListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 8 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyBattleWaveDurationListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyBattleWaveDurationListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyBattleWaveTimeLeftListener
	{
		get
		{
			if (_matcherAnyBattleWaveTimeLeftListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 9 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyBattleWaveTimeLeftListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyBattleWaveTimeLeftListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyBlueTeamCampPositionListener
	{
		get
		{
			if (_matcherAnyBlueTeamCampPositionListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 10 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyBlueTeamCampPositionListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyBlueTeamCampPositionListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyBlueTeamCombatPowerListener
	{
		get
		{
			if (_matcherAnyBlueTeamCombatPowerListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 11 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyBlueTeamCombatPowerListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyBlueTeamCombatPowerListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyBlueTeamStagingAreaPositionListener
	{
		get
		{
			if (_matcherAnyBlueTeamStagingAreaPositionListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 12 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyBlueTeamStagingAreaPositionListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyBlueTeamStagingAreaPositionListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyCameraActiveListener
	{
		get
		{
			if (_matcherAnyCameraActiveListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 13 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyCameraActiveListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyCameraActiveListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyCameraAspectListener
	{
		get
		{
			if (_matcherAnyCameraAspectListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 14 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyCameraAspectListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyCameraAspectListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyCameraFollowingUnitListener
	{
		get
		{
			if (_matcherAnyCameraFollowingUnitListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 15 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyCameraFollowingUnitListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyCameraFollowingUnitListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyCameraFollowTeamListener
	{
		get
		{
			if (_matcherAnyCameraFollowTeamListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 16 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyCameraFollowTeamListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyCameraFollowTeamListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyCameraMoveLimitListener
	{
		get
		{
			if (_matcherAnyCameraMoveLimitListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 17 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyCameraMoveLimitListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyCameraMoveLimitListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyCameraPositionListener
	{
		get
		{
			if (_matcherAnyCameraPositionListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 18 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyCameraPositionListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyCameraPositionListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyCameraRotationListener
	{
		get
		{
			if (_matcherAnyCameraRotationListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 19 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyCameraRotationListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyCameraRotationListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyCameraSizeListener
	{
		get
		{
			if (_matcherAnyCameraSizeListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 20 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyCameraSizeListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyCameraSizeListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyCurrentLevelBattleStartedListener
	{
		get
		{
			if (_matcherAnyCurrentLevelBattleStartedListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 21 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyCurrentLevelBattleStartedListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyCurrentLevelBattleStartedListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyCurrentLevelBattleStartedRemovedListener
	{
		get
		{
			if (_matcherAnyCurrentLevelBattleStartedRemovedListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 22 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyCurrentLevelBattleStartedRemovedListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyCurrentLevelBattleStartedRemovedListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyDataReadyListener
	{
		get
		{
			if (_matcherAnyDataReadyListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 23 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyDataReadyListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyDataReadyListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyFreeBattleModeListener
	{
		get
		{
			if (_matcherAnyFreeBattleModeListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 24 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyFreeBattleModeListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyFreeBattleModeListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyFreeBattleModeRemovedListener
	{
		get
		{
			if (_matcherAnyFreeBattleModeRemovedListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 25 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyFreeBattleModeRemovedListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyFreeBattleModeRemovedListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyGameDataLoadedListener
	{
		get
		{
			if (_matcherAnyGameDataLoadedListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 26 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyGameDataLoadedListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyGameDataLoadedListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyGameEnteredListener
	{
		get
		{
			if (_matcherAnyGameEnteredListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 27 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyGameEnteredListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyGameEnteredListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyLoadingAnimationDirectionListener
	{
		get
		{
			if (_matcherAnyLoadingAnimationDirectionListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 28 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyLoadingAnimationDirectionListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyLoadingAnimationDirectionListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyLoadingPanelListener
	{
		get
		{
			if (_matcherAnyLoadingPanelListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 29 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyLoadingPanelListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyLoadingPanelListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyLoadingPanelStatusListener
	{
		get
		{
			if (_matcherAnyLoadingPanelStatusListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 30 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyLoadingPanelStatusListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyLoadingPanelStatusListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyLoadingProgressListener
	{
		get
		{
			if (_matcherAnyLoadingProgressListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 31 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyLoadingProgressListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyLoadingProgressListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyLoadingShowAllSoldierListener
	{
		get
		{
			if (_matcherAnyLoadingShowAllSoldierListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 32 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyLoadingShowAllSoldierListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyLoadingShowAllSoldierListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyLoadingTotalListener
	{
		get
		{
			if (_matcherAnyLoadingTotalListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 33 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyLoadingTotalListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyLoadingTotalListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyLoserListener
	{
		get
		{
			if (_matcherAnyLoserListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 34 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyLoserListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyLoserListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyNextLevelComingListener
	{
		get
		{
			if (_matcherAnyNextLevelComingListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 35 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyNextLevelComingListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyNextLevelComingListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyNextLevelComingRemovedListener
	{
		get
		{
			if (_matcherAnyNextLevelComingRemovedListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 36 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyNextLevelComingRemovedListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyNextLevelComingRemovedListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyOfflineBonusesListener
	{
		get
		{
			if (_matcherAnyOfflineBonusesListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 37 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyOfflineBonusesListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyOfflineBonusesListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyOfflineSecondsListener
	{
		get
		{
			if (_matcherAnyOfflineSecondsListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 38 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyOfflineSecondsListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyOfflineSecondsListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyRedTeamCampPositionListener
	{
		get
		{
			if (_matcherAnyRedTeamCampPositionListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 39 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyRedTeamCampPositionListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyRedTeamCampPositionListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyRedTeamCombatPowerListener
	{
		get
		{
			if (_matcherAnyRedTeamCombatPowerListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 40 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyRedTeamCombatPowerListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyRedTeamCombatPowerListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyRedTeamStagingAreaPositionListener
	{
		get
		{
			if (_matcherAnyRedTeamStagingAreaPositionListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 41 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyRedTeamStagingAreaPositionListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyRedTeamStagingAreaPositionListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyReplayModeListener
	{
		get
		{
			if (_matcherAnyReplayModeListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 42 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyReplayModeListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyReplayModeListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyReplayModeRemovedListener
	{
		get
		{
			if (_matcherAnyReplayModeRemovedListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 43 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyReplayModeRemovedListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyReplayModeRemovedListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyReplayStateListener
	{
		get
		{
			if (_matcherAnyReplayStateListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 44 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyReplayStateListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyReplayStateListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyReplayStateRemovedListener
	{
		get
		{
			if (_matcherAnyReplayStateRemovedListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 45 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyReplayStateRemovedListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyReplayStateRemovedListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyShowBattleWaveCountdownListener
	{
		get
		{
			if (_matcherAnyShowBattleWaveCountdownListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 46 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyShowBattleWaveCountdownListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyShowBattleWaveCountdownListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyShowBattleWaveCountdownRemovedListener
	{
		get
		{
			if (_matcherAnyShowBattleWaveCountdownRemovedListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 47 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyShowBattleWaveCountdownRemovedListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyShowBattleWaveCountdownRemovedListener;
		}
	}

	public static IMatcher<GameStateEntity> AnySubLevelWinnerListener
	{
		get
		{
			if (_matcherAnySubLevelWinnerListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 48 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnySubLevelWinnerListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnySubLevelWinnerListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyTeamHealthPointsTotalListener
	{
		get
		{
			if (_matcherAnyTeamHealthPointsTotalListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 49 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyTeamHealthPointsTotalListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyTeamHealthPointsTotalListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyUnlockedSoldiersListener
	{
		get
		{
			if (_matcherAnyUnlockedSoldiersListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 50 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyUnlockedSoldiersListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyUnlockedSoldiersListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyUserDataLoadedListener
	{
		get
		{
			if (_matcherAnyUserDataLoadedListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 51 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyUserDataLoadedListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyUserDataLoadedListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyUserListener
	{
		get
		{
			if (_matcherAnyUserListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 52 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyUserListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyUserListener;
		}
	}

	public static IMatcher<GameStateEntity> AnyWinnerListener
	{
		get
		{
			if (_matcherAnyWinnerListener == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 53 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherAnyWinnerListener = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherAnyWinnerListener;
		}
	}

	public static IMatcher<GameStateEntity> BattleDamageStats
	{
		get
		{
			if (_matcherBattleDamageStats == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 54 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBattleDamageStats = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBattleDamageStats;
		}
	}

	public static IMatcher<GameStateEntity> BattleDuration
	{
		get
		{
			if (_matcherBattleDuration == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 55 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBattleDuration = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBattleDuration;
		}
	}

	public static IMatcher<GameStateEntity> BattleDurationUpdated
	{
		get
		{
			if (_matcherBattleDurationUpdated == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 56 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBattleDurationUpdated = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBattleDurationUpdated;
		}
	}

	public static IMatcher<GameStateEntity> BattleElapsedTime
	{
		get
		{
			if (_matcherBattleElapsedTime == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 57 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBattleElapsedTime = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBattleElapsedTime;
		}
	}

	public static IMatcher<GameStateEntity> BattleFieldLength
	{
		get
		{
			if (_matcherBattleFieldLength == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 58 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBattleFieldLength = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBattleFieldLength;
		}
	}

	public static IMatcher<GameStateEntity> BattleFieldLevel
	{
		get
		{
			if (_matcherBattleFieldLevel == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 59 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBattleFieldLevel = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBattleFieldLevel;
		}
	}

	public static IMatcher<GameStateEntity> BattleFieldMapIdentifier
	{
		get
		{
			if (_matcherBattleFieldMapIdentifier == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 60 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBattleFieldMapIdentifier = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBattleFieldMapIdentifier;
		}
	}

	public static IMatcher<GameStateEntity> BattleFieldSubLevelIndex
	{
		get
		{
			if (_matcherBattleFieldSubLevelIndex == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 61 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBattleFieldSubLevelIndex = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBattleFieldSubLevelIndex;
		}
	}

	public static IMatcher<GameStateEntity> BattleId
	{
		get
		{
			if (_matcherBattleId == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 62 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBattleId = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBattleId;
		}
	}

	public static IMatcher<GameStateEntity> BattleProgressStats
	{
		get
		{
			if (_matcherBattleProgressStats == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 63 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBattleProgressStats = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBattleProgressStats;
		}
	}

	public static IMatcher<GameStateEntity> BattleStarted
	{
		get
		{
			if (_matcherBattleStarted == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 64 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBattleStarted = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBattleStarted;
		}
	}

	public static IMatcher<GameStateEntity> BattleStats
	{
		get
		{
			if (_matcherBattleStats == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 65 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBattleStats = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBattleStats;
		}
	}

	public static IMatcher<GameStateEntity> BattleStop
	{
		get
		{
			if (_matcherBattleStop == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 66 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBattleStop = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBattleStop;
		}
	}

	public static IMatcher<GameStateEntity> BattleTimeLeft
	{
		get
		{
			if (_matcherBattleTimeLeft == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 67 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBattleTimeLeft = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBattleTimeLeft;
		}
	}

	public static IMatcher<GameStateEntity> BattleWaveDuration
	{
		get
		{
			if (_matcherBattleWaveDuration == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 68 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBattleWaveDuration = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBattleWaveDuration;
		}
	}

	public static IMatcher<GameStateEntity> BattleWaveElapsedTime
	{
		get
		{
			if (_matcherBattleWaveElapsedTime == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 69 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBattleWaveElapsedTime = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBattleWaveElapsedTime;
		}
	}

	public static IMatcher<GameStateEntity> BattleWaveTimeLeft
	{
		get
		{
			if (_matcherBattleWaveTimeLeft == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 70 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBattleWaveTimeLeft = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBattleWaveTimeLeft;
		}
	}

	public static IMatcher<GameStateEntity> BattleWaveUnSpawnCount
	{
		get
		{
			if (_matcherBattleWaveUnSpawnCount == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 71 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBattleWaveUnSpawnCount = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBattleWaveUnSpawnCount;
		}
	}

	public static IMatcher<GameStateEntity> BlueTeamCampPosition
	{
		get
		{
			if (_matcherBlueTeamCampPosition == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 72 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBlueTeamCampPosition = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBlueTeamCampPosition;
		}
	}

	public static IMatcher<GameStateEntity> BlueTeamCombatPower
	{
		get
		{
			if (_matcherBlueTeamCombatPower == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 73 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBlueTeamCombatPower = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBlueTeamCombatPower;
		}
	}

	public static IMatcher<GameStateEntity> BlueTeamStagingAreaPosition
	{
		get
		{
			if (_matcherBlueTeamStagingAreaPosition == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 74 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherBlueTeamStagingAreaPosition = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherBlueTeamStagingAreaPosition;
		}
	}

	public static IMatcher<GameStateEntity> CameraActive
	{
		get
		{
			if (_matcherCameraActive == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 75 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherCameraActive = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherCameraActive;
		}
	}

	public static IMatcher<GameStateEntity> CameraAspect
	{
		get
		{
			if (_matcherCameraAspect == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 76 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherCameraAspect = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherCameraAspect;
		}
	}

	public static IMatcher<GameStateEntity> CameraFollowingUnit
	{
		get
		{
			if (_matcherCameraFollowingUnit == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 77 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherCameraFollowingUnit = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherCameraFollowingUnit;
		}
	}

	public static IMatcher<GameStateEntity> CameraFollowTeam
	{
		get
		{
			if (_matcherCameraFollowTeam == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 78 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherCameraFollowTeam = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherCameraFollowTeam;
		}
	}

	public static IMatcher<GameStateEntity> CameraMoveLimit
	{
		get
		{
			if (_matcherCameraMoveLimit == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 79 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherCameraMoveLimit = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherCameraMoveLimit;
		}
	}

	public static IMatcher<GameStateEntity> CameraPosition
	{
		get
		{
			if (_matcherCameraPosition == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 80 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherCameraPosition = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherCameraPosition;
		}
	}

	public static IMatcher<GameStateEntity> CameraRotation
	{
		get
		{
			if (_matcherCameraRotation == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 81 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherCameraRotation = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherCameraRotation;
		}
	}

	public static IMatcher<GameStateEntity> CameraSize
	{
		get
		{
			if (_matcherCameraSize == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 82 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherCameraSize = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherCameraSize;
		}
	}

	public static IMatcher<GameStateEntity> CharacterArchive
	{
		get
		{
			if (_matcherCharacterArchive == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 83 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherCharacterArchive = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherCharacterArchive;
		}
	}

	public static IMatcher<GameStateEntity> CurrentLevelBattleStarted
	{
		get
		{
			if (_matcherCurrentLevelBattleStarted == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 84 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherCurrentLevelBattleStarted = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherCurrentLevelBattleStarted;
		}
	}

	public static IMatcher<GameStateEntity> DataReady
	{
		get
		{
			if (_matcherDataReady == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 85 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherDataReady = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherDataReady;
		}
	}

	public static IMatcher<GameStateEntity> FreeBattleMode
	{
		get
		{
			if (_matcherFreeBattleMode == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 86 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherFreeBattleMode = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherFreeBattleMode;
		}
	}

	public static IMatcher<GameStateEntity> GameDataLoaded
	{
		get
		{
			if (_matcherGameDataLoaded == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 87 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherGameDataLoaded = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherGameDataLoaded;
		}
	}

	public static IMatcher<GameStateEntity> GameEntered
	{
		get
		{
			if (_matcherGameEntered == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 88 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherGameEntered = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherGameEntered;
		}
	}

	public static IMatcher<GameStateEntity> LoadingAnimationDirection
	{
		get
		{
			if (_matcherLoadingAnimationDirection == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 89 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherLoadingAnimationDirection = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherLoadingAnimationDirection;
		}
	}

	public static IMatcher<GameStateEntity> LoadingPanel
	{
		get
		{
			if (_matcherLoadingPanel == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 90 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherLoadingPanel = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherLoadingPanel;
		}
	}

	public static IMatcher<GameStateEntity> LoadingPanelStatus
	{
		get
		{
			if (_matcherLoadingPanelStatus == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 91 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherLoadingPanelStatus = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherLoadingPanelStatus;
		}
	}

	public static IMatcher<GameStateEntity> LoadingProgress
	{
		get
		{
			if (_matcherLoadingProgress == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 92 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherLoadingProgress = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherLoadingProgress;
		}
	}

	public static IMatcher<GameStateEntity> LoadingShowAllSoldier
	{
		get
		{
			if (_matcherLoadingShowAllSoldier == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 93 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherLoadingShowAllSoldier = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherLoadingShowAllSoldier;
		}
	}

	public static IMatcher<GameStateEntity> LoadingTotal
	{
		get
		{
			if (_matcherLoadingTotal == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 94 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherLoadingTotal = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherLoadingTotal;
		}
	}

	public static IMatcher<GameStateEntity> Loser
	{
		get
		{
			if (_matcherLoser == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 95 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherLoser = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherLoser;
		}
	}

	public static IMatcher<GameStateEntity> MainCityInitialized
	{
		get
		{
			if (_matcherMainCityInitialized == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 96 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherMainCityInitialized = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherMainCityInitialized;
		}
	}

	public static IMatcher<GameStateEntity> NextLevelComing
	{
		get
		{
			if (_matcherNextLevelComing == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 97 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherNextLevelComing = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherNextLevelComing;
		}
	}

	public static IMatcher<GameStateEntity> OfflineBonuses
	{
		get
		{
			if (_matcherOfflineBonuses == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 98 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherOfflineBonuses = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherOfflineBonuses;
		}
	}

	public static IMatcher<GameStateEntity> OfflineSeconds
	{
		get
		{
			if (_matcherOfflineSeconds == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 99 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherOfflineSeconds = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherOfflineSeconds;
		}
	}

	public static IMatcher<GameStateEntity> RedTeamCampPosition
	{
		get
		{
			if (_matcherRedTeamCampPosition == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 100 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherRedTeamCampPosition = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherRedTeamCampPosition;
		}
	}

	public static IMatcher<GameStateEntity> RedTeamCombatPower
	{
		get
		{
			if (_matcherRedTeamCombatPower == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 101 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherRedTeamCombatPower = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherRedTeamCombatPower;
		}
	}

	public static IMatcher<GameStateEntity> RedTeamStagingAreaPosition
	{
		get
		{
			if (_matcherRedTeamStagingAreaPosition == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 102 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherRedTeamStagingAreaPosition = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherRedTeamStagingAreaPosition;
		}
	}

	public static IMatcher<GameStateEntity> RefreshTeamHealthPointsTotal
	{
		get
		{
			if (_matcherRefreshTeamHealthPointsTotal == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 103 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherRefreshTeamHealthPointsTotal = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherRefreshTeamHealthPointsTotal;
		}
	}

	public static IMatcher<GameStateEntity> ReplayBattleId
	{
		get
		{
			if (_matcherReplayBattleId == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 104 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherReplayBattleId = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherReplayBattleId;
		}
	}

	public static IMatcher<GameStateEntity> ReplayMode
	{
		get
		{
			if (_matcherReplayMode == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 105 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherReplayMode = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherReplayMode;
		}
	}

	public static IMatcher<GameStateEntity> ReplayState
	{
		get
		{
			if (_matcherReplayState == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 106 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherReplayState = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherReplayState;
		}
	}

	public static IMatcher<GameStateEntity> Retreat
	{
		get
		{
			if (_matcherRetreat == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 107 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherRetreat = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherRetreat;
		}
	}

	public static IMatcher<GameStateEntity> ShowBattleWaveCountdown
	{
		get
		{
			if (_matcherShowBattleWaveCountdown == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 108 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherShowBattleWaveCountdown = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherShowBattleWaveCountdown;
		}
	}

	public static IMatcher<GameStateEntity> SubLevelWinner
	{
		get
		{
			if (_matcherSubLevelWinner == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 109 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherSubLevelWinner = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherSubLevelWinner;
		}
	}

	public static IMatcher<GameStateEntity> TeamHealthPointsTotal
	{
		get
		{
			if (_matcherTeamHealthPointsTotal == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 110 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherTeamHealthPointsTotal = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherTeamHealthPointsTotal;
		}
	}

	public static IMatcher<GameStateEntity> UnlockedSoldiers
	{
		get
		{
			if (_matcherUnlockedSoldiers == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 111 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherUnlockedSoldiers = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherUnlockedSoldiers;
		}
	}

	public static IMatcher<GameStateEntity> User
	{
		get
		{
			if (_matcherUser == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 112 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherUser = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherUser;
		}
	}

	public static IMatcher<GameStateEntity> UserDataLoaded
	{
		get
		{
			if (_matcherUserDataLoaded == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 113 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherUserDataLoaded = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherUserDataLoaded;
		}
	}

	public static IMatcher<GameStateEntity> Winner
	{
		get
		{
			if (_matcherWinner == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 114 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherWinner = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherWinner;
		}
	}

	public static IMatcher<GameStateEntity> WorldMapInitialized
	{
		get
		{
			if (_matcherWorldMapInitialized == null)
			{
				Matcher<GameStateEntity> val = (Matcher<GameStateEntity>)(object)Matcher<GameStateEntity>.AllOf(new int[1] { 115 });
				val.componentNames = GameStateComponentsLookup.componentNames;
				_matcherWorldMapInitialized = (IMatcher<GameStateEntity>)(object)val;
			}
			return _matcherWorldMapInitialized;
		}
	}

	public static IAllOfMatcher<GameStateEntity> AllOf(params int[] indices)
	{
		return Matcher<GameStateEntity>.AllOf(indices);
	}

	public static IAllOfMatcher<GameStateEntity> AllOf(params IMatcher<GameStateEntity>[] matchers)
	{
		return Matcher<GameStateEntity>.AllOf(matchers);
	}

	public static IAnyOfMatcher<GameStateEntity> AnyOf(params int[] indices)
	{
		return Matcher<GameStateEntity>.AnyOf(indices);
	}

	public static IAnyOfMatcher<GameStateEntity> AnyOf(params IMatcher<GameStateEntity>[] matchers)
	{
		return Matcher<GameStateEntity>.AnyOf(matchers);
	}
}
