using System.Collections.Generic;
using Entitas;
using GameMaths;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Interfaces;
using Shift.Legion.Common.Models;

public sealed class GameStateEntity : Entity
{
	private static readonly BattleDurationUpdatedComponent battleDurationUpdatedComponent = new BattleDurationUpdatedComponent();

	private static readonly BattleStartedComponent battleStartedComponent = new BattleStartedComponent();

	private static readonly BattleStopComponent battleStopComponent = new BattleStopComponent();

	private static readonly CameraFollowingUnitComponent cameraFollowingUnitComponent = new CameraFollowingUnitComponent();

	private static readonly CurrentLevelBattleStartedComponent currentLevelBattleStartedComponent = new CurrentLevelBattleStartedComponent();

	private static readonly DataReadyComponent dataReadyComponent = new DataReadyComponent();

	private static readonly FreeBattleModeComponent freeBattleModeComponent = new FreeBattleModeComponent();

	private static readonly GameDataLoadedComponent gameDataLoadedComponent = new GameDataLoadedComponent();

	private static readonly GameEnteredComponent gameEnteredComponent = new GameEnteredComponent();

	private static readonly LoadingShowAllSoldierComponent loadingShowAllSoldierComponent = new LoadingShowAllSoldierComponent();

	private static readonly MainCityInitializedComponent mainCityInitializedComponent = new MainCityInitializedComponent();

	private static readonly NextLevelComingComponent nextLevelComingComponent = new NextLevelComingComponent();

	private static readonly RetreatComponent retreatComponent = new RetreatComponent();

	private static readonly ShowBattleWaveCountdownComponent showBattleWaveCountdownComponent = new ShowBattleWaveCountdownComponent();

	private static readonly UserDataLoadedComponent userDataLoadedComponent = new UserDataLoadedComponent();

	private static readonly WorldMapInitializedComponent worldMapInitializedComponent = new WorldMapInitializedComponent();

	public AnyBattleDurationListenerComponent anyBattleDurationListener => (AnyBattleDurationListenerComponent)(object)((Entity)this).GetComponent(0);

	public bool hasAnyBattleDurationListener => ((Entity)this).HasComponent(0);

	public AnyBattleFieldLengthListenerComponent anyBattleFieldLengthListener => (AnyBattleFieldLengthListenerComponent)(object)((Entity)this).GetComponent(1);

	public bool hasAnyBattleFieldLengthListener => ((Entity)this).HasComponent(1);

	public AnyBattleFieldLevelListenerComponent anyBattleFieldLevelListener => (AnyBattleFieldLevelListenerComponent)(object)((Entity)this).GetComponent(2);

	public bool hasAnyBattleFieldLevelListener => ((Entity)this).HasComponent(2);

	public AnyBattleFieldMapIdentifierListenerComponent anyBattleFieldMapIdentifierListener => (AnyBattleFieldMapIdentifierListenerComponent)(object)((Entity)this).GetComponent(3);

	public bool hasAnyBattleFieldMapIdentifierListener => ((Entity)this).HasComponent(3);

	public AnyBattleFieldSubLevelIndexListenerComponent anyBattleFieldSubLevelIndexListener => (AnyBattleFieldSubLevelIndexListenerComponent)(object)((Entity)this).GetComponent(4);

	public bool hasAnyBattleFieldSubLevelIndexListener => ((Entity)this).HasComponent(4);

	public AnyBattleStartedListenerComponent anyBattleStartedListener => (AnyBattleStartedListenerComponent)(object)((Entity)this).GetComponent(5);

	public bool hasAnyBattleStartedListener => ((Entity)this).HasComponent(5);

	public AnyBattleStartedRemovedListenerComponent anyBattleStartedRemovedListener => (AnyBattleStartedRemovedListenerComponent)(object)((Entity)this).GetComponent(6);

	public bool hasAnyBattleStartedRemovedListener => ((Entity)this).HasComponent(6);

	public AnyBattleTimeLeftListenerComponent anyBattleTimeLeftListener => (AnyBattleTimeLeftListenerComponent)(object)((Entity)this).GetComponent(7);

	public bool hasAnyBattleTimeLeftListener => ((Entity)this).HasComponent(7);

	public AnyBattleWaveDurationListenerComponent anyBattleWaveDurationListener => (AnyBattleWaveDurationListenerComponent)(object)((Entity)this).GetComponent(8);

	public bool hasAnyBattleWaveDurationListener => ((Entity)this).HasComponent(8);

	public AnyBattleWaveTimeLeftListenerComponent anyBattleWaveTimeLeftListener => (AnyBattleWaveTimeLeftListenerComponent)(object)((Entity)this).GetComponent(9);

	public bool hasAnyBattleWaveTimeLeftListener => ((Entity)this).HasComponent(9);

	public AnyBlueTeamCampPositionListenerComponent anyBlueTeamCampPositionListener => (AnyBlueTeamCampPositionListenerComponent)(object)((Entity)this).GetComponent(10);

	public bool hasAnyBlueTeamCampPositionListener => ((Entity)this).HasComponent(10);

	public AnyBlueTeamCombatPowerListenerComponent anyBlueTeamCombatPowerListener => (AnyBlueTeamCombatPowerListenerComponent)(object)((Entity)this).GetComponent(11);

	public bool hasAnyBlueTeamCombatPowerListener => ((Entity)this).HasComponent(11);

	public AnyBlueTeamStagingAreaPositionListenerComponent anyBlueTeamStagingAreaPositionListener => (AnyBlueTeamStagingAreaPositionListenerComponent)(object)((Entity)this).GetComponent(12);

	public bool hasAnyBlueTeamStagingAreaPositionListener => ((Entity)this).HasComponent(12);

	public AnyCameraActiveListenerComponent anyCameraActiveListener => (AnyCameraActiveListenerComponent)(object)((Entity)this).GetComponent(13);

	public bool hasAnyCameraActiveListener => ((Entity)this).HasComponent(13);

	public AnyCameraAspectListenerComponent anyCameraAspectListener => (AnyCameraAspectListenerComponent)(object)((Entity)this).GetComponent(14);

	public bool hasAnyCameraAspectListener => ((Entity)this).HasComponent(14);

	public AnyCameraFollowingUnitListenerComponent anyCameraFollowingUnitListener => (AnyCameraFollowingUnitListenerComponent)(object)((Entity)this).GetComponent(15);

	public bool hasAnyCameraFollowingUnitListener => ((Entity)this).HasComponent(15);

	public AnyCameraFollowTeamListenerComponent anyCameraFollowTeamListener => (AnyCameraFollowTeamListenerComponent)(object)((Entity)this).GetComponent(16);

	public bool hasAnyCameraFollowTeamListener => ((Entity)this).HasComponent(16);

	public AnyCameraMoveLimitListenerComponent anyCameraMoveLimitListener => (AnyCameraMoveLimitListenerComponent)(object)((Entity)this).GetComponent(17);

	public bool hasAnyCameraMoveLimitListener => ((Entity)this).HasComponent(17);

	public AnyCameraPositionListenerComponent anyCameraPositionListener => (AnyCameraPositionListenerComponent)(object)((Entity)this).GetComponent(18);

	public bool hasAnyCameraPositionListener => ((Entity)this).HasComponent(18);

	public AnyCameraRotationListenerComponent anyCameraRotationListener => (AnyCameraRotationListenerComponent)(object)((Entity)this).GetComponent(19);

	public bool hasAnyCameraRotationListener => ((Entity)this).HasComponent(19);

	public AnyCameraSizeListenerComponent anyCameraSizeListener => (AnyCameraSizeListenerComponent)(object)((Entity)this).GetComponent(20);

	public bool hasAnyCameraSizeListener => ((Entity)this).HasComponent(20);

	public AnyCurrentLevelBattleStartedListenerComponent anyCurrentLevelBattleStartedListener => (AnyCurrentLevelBattleStartedListenerComponent)(object)((Entity)this).GetComponent(21);

	public bool hasAnyCurrentLevelBattleStartedListener => ((Entity)this).HasComponent(21);

	public AnyCurrentLevelBattleStartedRemovedListenerComponent anyCurrentLevelBattleStartedRemovedListener => (AnyCurrentLevelBattleStartedRemovedListenerComponent)(object)((Entity)this).GetComponent(22);

	public bool hasAnyCurrentLevelBattleStartedRemovedListener => ((Entity)this).HasComponent(22);

	public AnyDataReadyListenerComponent anyDataReadyListener => (AnyDataReadyListenerComponent)(object)((Entity)this).GetComponent(23);

	public bool hasAnyDataReadyListener => ((Entity)this).HasComponent(23);

	public AnyFreeBattleModeListenerComponent anyFreeBattleModeListener => (AnyFreeBattleModeListenerComponent)(object)((Entity)this).GetComponent(24);

	public bool hasAnyFreeBattleModeListener => ((Entity)this).HasComponent(24);

	public AnyFreeBattleModeRemovedListenerComponent anyFreeBattleModeRemovedListener => (AnyFreeBattleModeRemovedListenerComponent)(object)((Entity)this).GetComponent(25);

	public bool hasAnyFreeBattleModeRemovedListener => ((Entity)this).HasComponent(25);

	public AnyGameDataLoadedListenerComponent anyGameDataLoadedListener => (AnyGameDataLoadedListenerComponent)(object)((Entity)this).GetComponent(26);

	public bool hasAnyGameDataLoadedListener => ((Entity)this).HasComponent(26);

	public AnyGameEnteredListenerComponent anyGameEnteredListener => (AnyGameEnteredListenerComponent)(object)((Entity)this).GetComponent(27);

	public bool hasAnyGameEnteredListener => ((Entity)this).HasComponent(27);

	public AnyLoadingAnimationDirectionListenerComponent anyLoadingAnimationDirectionListener => (AnyLoadingAnimationDirectionListenerComponent)(object)((Entity)this).GetComponent(28);

	public bool hasAnyLoadingAnimationDirectionListener => ((Entity)this).HasComponent(28);

	public AnyLoadingPanelListenerComponent anyLoadingPanelListener => (AnyLoadingPanelListenerComponent)(object)((Entity)this).GetComponent(29);

	public bool hasAnyLoadingPanelListener => ((Entity)this).HasComponent(29);

	public AnyLoadingPanelStatusListenerComponent anyLoadingPanelStatusListener => (AnyLoadingPanelStatusListenerComponent)(object)((Entity)this).GetComponent(30);

	public bool hasAnyLoadingPanelStatusListener => ((Entity)this).HasComponent(30);

	public AnyLoadingProgressListenerComponent anyLoadingProgressListener => (AnyLoadingProgressListenerComponent)(object)((Entity)this).GetComponent(31);

	public bool hasAnyLoadingProgressListener => ((Entity)this).HasComponent(31);

	public AnyLoadingShowAllSoldierListenerComponent anyLoadingShowAllSoldierListener => (AnyLoadingShowAllSoldierListenerComponent)(object)((Entity)this).GetComponent(32);

	public bool hasAnyLoadingShowAllSoldierListener => ((Entity)this).HasComponent(32);

	public AnyLoadingTotalListenerComponent anyLoadingTotalListener => (AnyLoadingTotalListenerComponent)(object)((Entity)this).GetComponent(33);

	public bool hasAnyLoadingTotalListener => ((Entity)this).HasComponent(33);

	public AnyLoserListenerComponent anyLoserListener => (AnyLoserListenerComponent)(object)((Entity)this).GetComponent(34);

	public bool hasAnyLoserListener => ((Entity)this).HasComponent(34);

	public AnyNextLevelComingListenerComponent anyNextLevelComingListener => (AnyNextLevelComingListenerComponent)(object)((Entity)this).GetComponent(35);

	public bool hasAnyNextLevelComingListener => ((Entity)this).HasComponent(35);

	public AnyNextLevelComingRemovedListenerComponent anyNextLevelComingRemovedListener => (AnyNextLevelComingRemovedListenerComponent)(object)((Entity)this).GetComponent(36);

	public bool hasAnyNextLevelComingRemovedListener => ((Entity)this).HasComponent(36);

	public AnyOfflineBonusesListenerComponent anyOfflineBonusesListener => (AnyOfflineBonusesListenerComponent)(object)((Entity)this).GetComponent(37);

	public bool hasAnyOfflineBonusesListener => ((Entity)this).HasComponent(37);

	public AnyOfflineSecondsListenerComponent anyOfflineSecondsListener => (AnyOfflineSecondsListenerComponent)(object)((Entity)this).GetComponent(38);

	public bool hasAnyOfflineSecondsListener => ((Entity)this).HasComponent(38);

	public AnyRedTeamCampPositionListenerComponent anyRedTeamCampPositionListener => (AnyRedTeamCampPositionListenerComponent)(object)((Entity)this).GetComponent(39);

	public bool hasAnyRedTeamCampPositionListener => ((Entity)this).HasComponent(39);

	public AnyRedTeamCombatPowerListenerComponent anyRedTeamCombatPowerListener => (AnyRedTeamCombatPowerListenerComponent)(object)((Entity)this).GetComponent(40);

	public bool hasAnyRedTeamCombatPowerListener => ((Entity)this).HasComponent(40);

	public AnyRedTeamStagingAreaPositionListenerComponent anyRedTeamStagingAreaPositionListener => (AnyRedTeamStagingAreaPositionListenerComponent)(object)((Entity)this).GetComponent(41);

	public bool hasAnyRedTeamStagingAreaPositionListener => ((Entity)this).HasComponent(41);

	public AnyReplayModeListenerComponent anyReplayModeListener => (AnyReplayModeListenerComponent)(object)((Entity)this).GetComponent(42);

	public bool hasAnyReplayModeListener => ((Entity)this).HasComponent(42);

	public AnyReplayModeRemovedListenerComponent anyReplayModeRemovedListener => (AnyReplayModeRemovedListenerComponent)(object)((Entity)this).GetComponent(43);

	public bool hasAnyReplayModeRemovedListener => ((Entity)this).HasComponent(43);

	public AnyReplayStateListenerComponent anyReplayStateListener => (AnyReplayStateListenerComponent)(object)((Entity)this).GetComponent(44);

	public bool hasAnyReplayStateListener => ((Entity)this).HasComponent(44);

	public AnyReplayStateRemovedListenerComponent anyReplayStateRemovedListener => (AnyReplayStateRemovedListenerComponent)(object)((Entity)this).GetComponent(45);

	public bool hasAnyReplayStateRemovedListener => ((Entity)this).HasComponent(45);

	public AnyShowBattleWaveCountdownListenerComponent anyShowBattleWaveCountdownListener => (AnyShowBattleWaveCountdownListenerComponent)(object)((Entity)this).GetComponent(46);

	public bool hasAnyShowBattleWaveCountdownListener => ((Entity)this).HasComponent(46);

	public AnyShowBattleWaveCountdownRemovedListenerComponent anyShowBattleWaveCountdownRemovedListener => (AnyShowBattleWaveCountdownRemovedListenerComponent)(object)((Entity)this).GetComponent(47);

	public bool hasAnyShowBattleWaveCountdownRemovedListener => ((Entity)this).HasComponent(47);

	public AnySubLevelWinnerListenerComponent anySubLevelWinnerListener => (AnySubLevelWinnerListenerComponent)(object)((Entity)this).GetComponent(48);

	public bool hasAnySubLevelWinnerListener => ((Entity)this).HasComponent(48);

	public AnyTeamHealthPointsTotalListenerComponent anyTeamHealthPointsTotalListener => (AnyTeamHealthPointsTotalListenerComponent)(object)((Entity)this).GetComponent(49);

	public bool hasAnyTeamHealthPointsTotalListener => ((Entity)this).HasComponent(49);

	public AnyUnlockedSoldiersListenerComponent anyUnlockedSoldiersListener => (AnyUnlockedSoldiersListenerComponent)(object)((Entity)this).GetComponent(50);

	public bool hasAnyUnlockedSoldiersListener => ((Entity)this).HasComponent(50);

	public AnyUserDataLoadedListenerComponent anyUserDataLoadedListener => (AnyUserDataLoadedListenerComponent)(object)((Entity)this).GetComponent(51);

	public bool hasAnyUserDataLoadedListener => ((Entity)this).HasComponent(51);

	public AnyUserListenerComponent anyUserListener => (AnyUserListenerComponent)(object)((Entity)this).GetComponent(52);

	public bool hasAnyUserListener => ((Entity)this).HasComponent(52);

	public AnyWinnerListenerComponent anyWinnerListener => (AnyWinnerListenerComponent)(object)((Entity)this).GetComponent(53);

	public bool hasAnyWinnerListener => ((Entity)this).HasComponent(53);

	public BattleDamageStatsComponent battleDamageStats => (BattleDamageStatsComponent)(object)((Entity)this).GetComponent(54);

	public bool hasBattleDamageStats => ((Entity)this).HasComponent(54);

	public BattleDurationComponent battleDuration => (BattleDurationComponent)(object)((Entity)this).GetComponent(55);

	public bool hasBattleDuration => ((Entity)this).HasComponent(55);

	public bool isBattleDurationUpdated
	{
		get
		{
			return ((Entity)this).HasComponent(56);
		}
		set
		{
			if (value == isBattleDurationUpdated)
			{
				return;
			}
			int num = 56;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)battleDurationUpdatedComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public BattleElapsedTimeComponent battleElapsedTime => (BattleElapsedTimeComponent)(object)((Entity)this).GetComponent(57);

	public bool hasBattleElapsedTime => ((Entity)this).HasComponent(57);

	public BattleFieldLengthComponent battleFieldLength => (BattleFieldLengthComponent)(object)((Entity)this).GetComponent(58);

	public bool hasBattleFieldLength => ((Entity)this).HasComponent(58);

	public BattleFieldLevelComponent battleFieldLevel => (BattleFieldLevelComponent)(object)((Entity)this).GetComponent(59);

	public bool hasBattleFieldLevel => ((Entity)this).HasComponent(59);

	public BattleFieldMapIdentifierComponent battleFieldMapIdentifier => (BattleFieldMapIdentifierComponent)(object)((Entity)this).GetComponent(60);

	public bool hasBattleFieldMapIdentifier => ((Entity)this).HasComponent(60);

	public BattleFieldSubLevelIndexComponent battleFieldSubLevelIndex => (BattleFieldSubLevelIndexComponent)(object)((Entity)this).GetComponent(61);

	public bool hasBattleFieldSubLevelIndex => ((Entity)this).HasComponent(61);

	public BattleIdComponent battleId => (BattleIdComponent)(object)((Entity)this).GetComponent(62);

	public bool hasBattleId => ((Entity)this).HasComponent(62);

	public BattleProgressStatsComponent battleProgressStats => (BattleProgressStatsComponent)(object)((Entity)this).GetComponent(63);

	public bool hasBattleProgressStats => ((Entity)this).HasComponent(63);

	public bool isBattleStarted
	{
		get
		{
			return ((Entity)this).HasComponent(64);
		}
		set
		{
			if (value == isBattleStarted)
			{
				return;
			}
			int num = 64;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)battleStartedComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public BattleStatsComponent battleStats => (BattleStatsComponent)(object)((Entity)this).GetComponent(65);

	public bool hasBattleStats => ((Entity)this).HasComponent(65);

	public bool isBattleStop
	{
		get
		{
			return ((Entity)this).HasComponent(66);
		}
		set
		{
			if (value == isBattleStop)
			{
				return;
			}
			int num = 66;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)battleStopComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public BattleTimeLeftComponent battleTimeLeft => (BattleTimeLeftComponent)(object)((Entity)this).GetComponent(67);

	public bool hasBattleTimeLeft => ((Entity)this).HasComponent(67);

	public BattleWaveDurationComponent battleWaveDuration => (BattleWaveDurationComponent)(object)((Entity)this).GetComponent(68);

	public bool hasBattleWaveDuration => ((Entity)this).HasComponent(68);

	public BattleWaveElapsedTimeComponent battleWaveElapsedTime => (BattleWaveElapsedTimeComponent)(object)((Entity)this).GetComponent(69);

	public bool hasBattleWaveElapsedTime => ((Entity)this).HasComponent(69);

	public BattleWaveTimeLeftComponent battleWaveTimeLeft => (BattleWaveTimeLeftComponent)(object)((Entity)this).GetComponent(70);

	public bool hasBattleWaveTimeLeft => ((Entity)this).HasComponent(70);

	public BattleWaveUnSpawnCountComponent battleWaveUnSpawnCount => (BattleWaveUnSpawnCountComponent)(object)((Entity)this).GetComponent(71);

	public bool hasBattleWaveUnSpawnCount => ((Entity)this).HasComponent(71);

	public BlueTeamCampPositionComponent blueTeamCampPosition => (BlueTeamCampPositionComponent)(object)((Entity)this).GetComponent(72);

	public bool hasBlueTeamCampPosition => ((Entity)this).HasComponent(72);

	public BlueTeamCombatPowerComponent blueTeamCombatPower => (BlueTeamCombatPowerComponent)(object)((Entity)this).GetComponent(73);

	public bool hasBlueTeamCombatPower => ((Entity)this).HasComponent(73);

	public BlueTeamStagingAreaPositionComponent blueTeamStagingAreaPosition => (BlueTeamStagingAreaPositionComponent)(object)((Entity)this).GetComponent(74);

	public bool hasBlueTeamStagingAreaPosition => ((Entity)this).HasComponent(74);

	public CameraActiveComponent cameraActive => (CameraActiveComponent)(object)((Entity)this).GetComponent(75);

	public bool hasCameraActive => ((Entity)this).HasComponent(75);

	public CameraAspectComponent cameraAspect => (CameraAspectComponent)(object)((Entity)this).GetComponent(76);

	public bool hasCameraAspect => ((Entity)this).HasComponent(76);

	public bool isCameraFollowingUnit
	{
		get
		{
			return ((Entity)this).HasComponent(77);
		}
		set
		{
			if (value == isCameraFollowingUnit)
			{
				return;
			}
			int num = 77;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)cameraFollowingUnitComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public CameraFollowTeamComponent cameraFollowTeam => (CameraFollowTeamComponent)(object)((Entity)this).GetComponent(78);

	public bool hasCameraFollowTeam => ((Entity)this).HasComponent(78);

	public CameraMoveLimitComponent cameraMoveLimit => (CameraMoveLimitComponent)(object)((Entity)this).GetComponent(79);

	public bool hasCameraMoveLimit => ((Entity)this).HasComponent(79);

	public CameraPositionComponent cameraPosition => (CameraPositionComponent)(object)((Entity)this).GetComponent(80);

	public bool hasCameraPosition => ((Entity)this).HasComponent(80);

	public CameraRotationComponent cameraRotation => (CameraRotationComponent)(object)((Entity)this).GetComponent(81);

	public bool hasCameraRotation => ((Entity)this).HasComponent(81);

	public CameraSizeComponent cameraSize => (CameraSizeComponent)(object)((Entity)this).GetComponent(82);

	public bool hasCameraSize => ((Entity)this).HasComponent(82);

	public CharacterArchiveComponent characterArchive => (CharacterArchiveComponent)(object)((Entity)this).GetComponent(83);

	public bool hasCharacterArchive => ((Entity)this).HasComponent(83);

	public bool isCurrentLevelBattleStarted
	{
		get
		{
			return ((Entity)this).HasComponent(84);
		}
		set
		{
			if (value == isCurrentLevelBattleStarted)
			{
				return;
			}
			int num = 84;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)currentLevelBattleStartedComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public bool isDataReady
	{
		get
		{
			return ((Entity)this).HasComponent(85);
		}
		set
		{
			if (value == isDataReady)
			{
				return;
			}
			int num = 85;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)dataReadyComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public bool isFreeBattleMode
	{
		get
		{
			return ((Entity)this).HasComponent(86);
		}
		set
		{
			if (value == isFreeBattleMode)
			{
				return;
			}
			int num = 86;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)freeBattleModeComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public bool isGameDataLoaded
	{
		get
		{
			return ((Entity)this).HasComponent(87);
		}
		set
		{
			if (value == isGameDataLoaded)
			{
				return;
			}
			int num = 87;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)gameDataLoadedComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public bool isGameEntered
	{
		get
		{
			return ((Entity)this).HasComponent(88);
		}
		set
		{
			if (value == isGameEntered)
			{
				return;
			}
			int num = 88;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)gameEnteredComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public LoadingAnimationDirectionComponent loadingAnimationDirection => (LoadingAnimationDirectionComponent)(object)((Entity)this).GetComponent(89);

	public bool hasLoadingAnimationDirection => ((Entity)this).HasComponent(89);

	public LoadingPanelComponent loadingPanel => (LoadingPanelComponent)(object)((Entity)this).GetComponent(90);

	public bool hasLoadingPanel => ((Entity)this).HasComponent(90);

	public LoadingPanelStatusComponent loadingPanelStatus => (LoadingPanelStatusComponent)(object)((Entity)this).GetComponent(91);

	public bool hasLoadingPanelStatus => ((Entity)this).HasComponent(91);

	public LoadingProgressComponent loadingProgress => (LoadingProgressComponent)(object)((Entity)this).GetComponent(92);

	public bool hasLoadingProgress => ((Entity)this).HasComponent(92);

	public bool isLoadingShowAllSoldier
	{
		get
		{
			return ((Entity)this).HasComponent(93);
		}
		set
		{
			if (value == isLoadingShowAllSoldier)
			{
				return;
			}
			int num = 93;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)loadingShowAllSoldierComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public LoadingTotalComponent loadingTotal => (LoadingTotalComponent)(object)((Entity)this).GetComponent(94);

	public bool hasLoadingTotal => ((Entity)this).HasComponent(94);

	public LoserComponent loser => (LoserComponent)(object)((Entity)this).GetComponent(95);

	public bool hasLoser => ((Entity)this).HasComponent(95);

	public bool isMainCityInitialized
	{
		get
		{
			return ((Entity)this).HasComponent(96);
		}
		set
		{
			if (value == isMainCityInitialized)
			{
				return;
			}
			int num = 96;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)mainCityInitializedComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public bool isNextLevelComing
	{
		get
		{
			return ((Entity)this).HasComponent(97);
		}
		set
		{
			if (value == isNextLevelComing)
			{
				return;
			}
			int num = 97;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)nextLevelComingComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public OfflineBonusesComponent offlineBonuses => (OfflineBonusesComponent)(object)((Entity)this).GetComponent(98);

	public bool hasOfflineBonuses => ((Entity)this).HasComponent(98);

	public OfflineSecondsComponent offlineSeconds => (OfflineSecondsComponent)(object)((Entity)this).GetComponent(99);

	public bool hasOfflineSeconds => ((Entity)this).HasComponent(99);

	public RedTeamCampPositionComponent redTeamCampPosition => (RedTeamCampPositionComponent)(object)((Entity)this).GetComponent(100);

	public bool hasRedTeamCampPosition => ((Entity)this).HasComponent(100);

	public RedTeamCombatPowerComponent redTeamCombatPower => (RedTeamCombatPowerComponent)(object)((Entity)this).GetComponent(101);

	public bool hasRedTeamCombatPower => ((Entity)this).HasComponent(101);

	public RedTeamStagingAreaPositionComponent redTeamStagingAreaPosition => (RedTeamStagingAreaPositionComponent)(object)((Entity)this).GetComponent(102);

	public bool hasRedTeamStagingAreaPosition => ((Entity)this).HasComponent(102);

	public RefreshTeamHealthPointsTotalComponent refreshTeamHealthPointsTotal => (RefreshTeamHealthPointsTotalComponent)(object)((Entity)this).GetComponent(103);

	public bool hasRefreshTeamHealthPointsTotal => ((Entity)this).HasComponent(103);

	public ReplayBattleIdComponent replayBattleId => (ReplayBattleIdComponent)(object)((Entity)this).GetComponent(104);

	public bool hasReplayBattleId => ((Entity)this).HasComponent(104);

	public ReplayModeComponent replayMode => (ReplayModeComponent)(object)((Entity)this).GetComponent(105);

	public bool hasReplayMode => ((Entity)this).HasComponent(105);

	public ReplayStateComponent replayState => (ReplayStateComponent)(object)((Entity)this).GetComponent(106);

	public bool hasReplayState => ((Entity)this).HasComponent(106);

	public bool isRetreat
	{
		get
		{
			return ((Entity)this).HasComponent(107);
		}
		set
		{
			if (value == isRetreat)
			{
				return;
			}
			int num = 107;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)retreatComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public bool isShowBattleWaveCountdown
	{
		get
		{
			return ((Entity)this).HasComponent(108);
		}
		set
		{
			if (value == isShowBattleWaveCountdown)
			{
				return;
			}
			int num = 108;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)showBattleWaveCountdownComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public SubLevelWinnerComponent subLevelWinner => (SubLevelWinnerComponent)(object)((Entity)this).GetComponent(109);

	public bool hasSubLevelWinner => ((Entity)this).HasComponent(109);

	public TeamHealthPointsTotalComponent teamHealthPointsTotal => (TeamHealthPointsTotalComponent)(object)((Entity)this).GetComponent(110);

	public bool hasTeamHealthPointsTotal => ((Entity)this).HasComponent(110);

	public UnlockedSoldiersComponent unlockedSoldiers => (UnlockedSoldiersComponent)(object)((Entity)this).GetComponent(111);

	public bool hasUnlockedSoldiers => ((Entity)this).HasComponent(111);

	public UserComponent user => (UserComponent)(object)((Entity)this).GetComponent(112);

	public bool hasUser => ((Entity)this).HasComponent(112);

	public bool isUserDataLoaded
	{
		get
		{
			return ((Entity)this).HasComponent(113);
		}
		set
		{
			if (value == isUserDataLoaded)
			{
				return;
			}
			int num = 113;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)userDataLoadedComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public WinnerComponent winner => (WinnerComponent)(object)((Entity)this).GetComponent(114);

	public bool hasWinner => ((Entity)this).HasComponent(114);

	public bool isWorldMapInitialized
	{
		get
		{
			return ((Entity)this).HasComponent(115);
		}
		set
		{
			if (value == isWorldMapInitialized)
			{
				return;
			}
			int num = 115;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)worldMapInitializedComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public void AddAnyBattleDurationListener(List<IAnyBattleDurationListener> newValue)
	{
		int num = 0;
		AnyBattleDurationListenerComponent anyBattleDurationListenerComponent = (AnyBattleDurationListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleDurationListenerComponent));
		anyBattleDurationListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyBattleDurationListenerComponent);
	}

	public void ReplaceAnyBattleDurationListener(List<IAnyBattleDurationListener> newValue)
	{
		int num = 0;
		AnyBattleDurationListenerComponent anyBattleDurationListenerComponent = (AnyBattleDurationListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleDurationListenerComponent));
		anyBattleDurationListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyBattleDurationListenerComponent);
	}

	public void RemoveAnyBattleDurationListener()
	{
		((Entity)this).RemoveComponent(0);
	}

	public void AddAnyBattleDurationListener(IAnyBattleDurationListener value)
	{
		List<IAnyBattleDurationListener> list = (hasAnyBattleDurationListener ? anyBattleDurationListener.value : new List<IAnyBattleDurationListener>());
		list.Add(value);
		ReplaceAnyBattleDurationListener(list);
	}

	public void RemoveAnyBattleDurationListener(IAnyBattleDurationListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyBattleDurationListener> value2 = anyBattleDurationListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyBattleDurationListener();
		}
		else
		{
			ReplaceAnyBattleDurationListener(value2);
		}
	}

	public void AddAnyBattleFieldLengthListener(List<IAnyBattleFieldLengthListener> newValue)
	{
		int num = 1;
		AnyBattleFieldLengthListenerComponent anyBattleFieldLengthListenerComponent = (AnyBattleFieldLengthListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleFieldLengthListenerComponent));
		anyBattleFieldLengthListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyBattleFieldLengthListenerComponent);
	}

	public void ReplaceAnyBattleFieldLengthListener(List<IAnyBattleFieldLengthListener> newValue)
	{
		int num = 1;
		AnyBattleFieldLengthListenerComponent anyBattleFieldLengthListenerComponent = (AnyBattleFieldLengthListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleFieldLengthListenerComponent));
		anyBattleFieldLengthListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyBattleFieldLengthListenerComponent);
	}

	public void RemoveAnyBattleFieldLengthListener()
	{
		((Entity)this).RemoveComponent(1);
	}

	public void AddAnyBattleFieldLengthListener(IAnyBattleFieldLengthListener value)
	{
		List<IAnyBattleFieldLengthListener> list = (hasAnyBattleFieldLengthListener ? anyBattleFieldLengthListener.value : new List<IAnyBattleFieldLengthListener>());
		list.Add(value);
		ReplaceAnyBattleFieldLengthListener(list);
	}

	public void RemoveAnyBattleFieldLengthListener(IAnyBattleFieldLengthListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyBattleFieldLengthListener> value2 = anyBattleFieldLengthListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyBattleFieldLengthListener();
		}
		else
		{
			ReplaceAnyBattleFieldLengthListener(value2);
		}
	}

	public void AddAnyBattleFieldLevelListener(List<IAnyBattleFieldLevelListener> newValue)
	{
		int num = 2;
		AnyBattleFieldLevelListenerComponent anyBattleFieldLevelListenerComponent = (AnyBattleFieldLevelListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleFieldLevelListenerComponent));
		anyBattleFieldLevelListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyBattleFieldLevelListenerComponent);
	}

	public void ReplaceAnyBattleFieldLevelListener(List<IAnyBattleFieldLevelListener> newValue)
	{
		int num = 2;
		AnyBattleFieldLevelListenerComponent anyBattleFieldLevelListenerComponent = (AnyBattleFieldLevelListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleFieldLevelListenerComponent));
		anyBattleFieldLevelListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyBattleFieldLevelListenerComponent);
	}

	public void RemoveAnyBattleFieldLevelListener()
	{
		((Entity)this).RemoveComponent(2);
	}

	public void AddAnyBattleFieldLevelListener(IAnyBattleFieldLevelListener value)
	{
		List<IAnyBattleFieldLevelListener> list = (hasAnyBattleFieldLevelListener ? anyBattleFieldLevelListener.value : new List<IAnyBattleFieldLevelListener>());
		list.Add(value);
		ReplaceAnyBattleFieldLevelListener(list);
	}

	public void RemoveAnyBattleFieldLevelListener(IAnyBattleFieldLevelListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyBattleFieldLevelListener> value2 = anyBattleFieldLevelListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyBattleFieldLevelListener();
		}
		else
		{
			ReplaceAnyBattleFieldLevelListener(value2);
		}
	}

	public void AddAnyBattleFieldMapIdentifierListener(List<IAnyBattleFieldMapIdentifierListener> newValue)
	{
		int num = 3;
		AnyBattleFieldMapIdentifierListenerComponent anyBattleFieldMapIdentifierListenerComponent = (AnyBattleFieldMapIdentifierListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleFieldMapIdentifierListenerComponent));
		anyBattleFieldMapIdentifierListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyBattleFieldMapIdentifierListenerComponent);
	}

	public void ReplaceAnyBattleFieldMapIdentifierListener(List<IAnyBattleFieldMapIdentifierListener> newValue)
	{
		int num = 3;
		AnyBattleFieldMapIdentifierListenerComponent anyBattleFieldMapIdentifierListenerComponent = (AnyBattleFieldMapIdentifierListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleFieldMapIdentifierListenerComponent));
		anyBattleFieldMapIdentifierListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyBattleFieldMapIdentifierListenerComponent);
	}

	public void RemoveAnyBattleFieldMapIdentifierListener()
	{
		((Entity)this).RemoveComponent(3);
	}

	public void AddAnyBattleFieldMapIdentifierListener(IAnyBattleFieldMapIdentifierListener value)
	{
		List<IAnyBattleFieldMapIdentifierListener> list = (hasAnyBattleFieldMapIdentifierListener ? anyBattleFieldMapIdentifierListener.value : new List<IAnyBattleFieldMapIdentifierListener>());
		list.Add(value);
		ReplaceAnyBattleFieldMapIdentifierListener(list);
	}

	public void RemoveAnyBattleFieldMapIdentifierListener(IAnyBattleFieldMapIdentifierListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyBattleFieldMapIdentifierListener> value2 = anyBattleFieldMapIdentifierListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyBattleFieldMapIdentifierListener();
		}
		else
		{
			ReplaceAnyBattleFieldMapIdentifierListener(value2);
		}
	}

	public void AddAnyBattleFieldSubLevelIndexListener(List<IAnyBattleFieldSubLevelIndexListener> newValue)
	{
		int num = 4;
		AnyBattleFieldSubLevelIndexListenerComponent anyBattleFieldSubLevelIndexListenerComponent = (AnyBattleFieldSubLevelIndexListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleFieldSubLevelIndexListenerComponent));
		anyBattleFieldSubLevelIndexListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyBattleFieldSubLevelIndexListenerComponent);
	}

	public void ReplaceAnyBattleFieldSubLevelIndexListener(List<IAnyBattleFieldSubLevelIndexListener> newValue)
	{
		int num = 4;
		AnyBattleFieldSubLevelIndexListenerComponent anyBattleFieldSubLevelIndexListenerComponent = (AnyBattleFieldSubLevelIndexListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleFieldSubLevelIndexListenerComponent));
		anyBattleFieldSubLevelIndexListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyBattleFieldSubLevelIndexListenerComponent);
	}

	public void RemoveAnyBattleFieldSubLevelIndexListener()
	{
		((Entity)this).RemoveComponent(4);
	}

	public void AddAnyBattleFieldSubLevelIndexListener(IAnyBattleFieldSubLevelIndexListener value)
	{
		List<IAnyBattleFieldSubLevelIndexListener> list = (hasAnyBattleFieldSubLevelIndexListener ? anyBattleFieldSubLevelIndexListener.value : new List<IAnyBattleFieldSubLevelIndexListener>());
		list.Add(value);
		ReplaceAnyBattleFieldSubLevelIndexListener(list);
	}

	public void RemoveAnyBattleFieldSubLevelIndexListener(IAnyBattleFieldSubLevelIndexListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyBattleFieldSubLevelIndexListener> value2 = anyBattleFieldSubLevelIndexListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyBattleFieldSubLevelIndexListener();
		}
		else
		{
			ReplaceAnyBattleFieldSubLevelIndexListener(value2);
		}
	}

	public void AddAnyBattleStartedListener(List<IAnyBattleStartedListener> newValue)
	{
		int num = 5;
		AnyBattleStartedListenerComponent anyBattleStartedListenerComponent = (AnyBattleStartedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleStartedListenerComponent));
		anyBattleStartedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyBattleStartedListenerComponent);
	}

	public void ReplaceAnyBattleStartedListener(List<IAnyBattleStartedListener> newValue)
	{
		int num = 5;
		AnyBattleStartedListenerComponent anyBattleStartedListenerComponent = (AnyBattleStartedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleStartedListenerComponent));
		anyBattleStartedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyBattleStartedListenerComponent);
	}

	public void RemoveAnyBattleStartedListener()
	{
		((Entity)this).RemoveComponent(5);
	}

	public void AddAnyBattleStartedListener(IAnyBattleStartedListener value)
	{
		List<IAnyBattleStartedListener> list = (hasAnyBattleStartedListener ? anyBattleStartedListener.value : new List<IAnyBattleStartedListener>());
		list.Add(value);
		ReplaceAnyBattleStartedListener(list);
	}

	public void RemoveAnyBattleStartedListener(IAnyBattleStartedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyBattleStartedListener> value2 = anyBattleStartedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyBattleStartedListener();
		}
		else
		{
			ReplaceAnyBattleStartedListener(value2);
		}
	}

	public void AddAnyBattleStartedRemovedListener(List<IAnyBattleStartedRemovedListener> newValue)
	{
		int num = 6;
		AnyBattleStartedRemovedListenerComponent anyBattleStartedRemovedListenerComponent = (AnyBattleStartedRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleStartedRemovedListenerComponent));
		anyBattleStartedRemovedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyBattleStartedRemovedListenerComponent);
	}

	public void ReplaceAnyBattleStartedRemovedListener(List<IAnyBattleStartedRemovedListener> newValue)
	{
		int num = 6;
		AnyBattleStartedRemovedListenerComponent anyBattleStartedRemovedListenerComponent = (AnyBattleStartedRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleStartedRemovedListenerComponent));
		anyBattleStartedRemovedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyBattleStartedRemovedListenerComponent);
	}

	public void RemoveAnyBattleStartedRemovedListener()
	{
		((Entity)this).RemoveComponent(6);
	}

	public void AddAnyBattleStartedRemovedListener(IAnyBattleStartedRemovedListener value)
	{
		List<IAnyBattleStartedRemovedListener> list = (hasAnyBattleStartedRemovedListener ? anyBattleStartedRemovedListener.value : new List<IAnyBattleStartedRemovedListener>());
		list.Add(value);
		ReplaceAnyBattleStartedRemovedListener(list);
	}

	public void RemoveAnyBattleStartedRemovedListener(IAnyBattleStartedRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyBattleStartedRemovedListener> value2 = anyBattleStartedRemovedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyBattleStartedRemovedListener();
		}
		else
		{
			ReplaceAnyBattleStartedRemovedListener(value2);
		}
	}

	public void AddAnyBattleTimeLeftListener(List<IAnyBattleTimeLeftListener> newValue)
	{
		int num = 7;
		AnyBattleTimeLeftListenerComponent anyBattleTimeLeftListenerComponent = (AnyBattleTimeLeftListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleTimeLeftListenerComponent));
		anyBattleTimeLeftListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyBattleTimeLeftListenerComponent);
	}

	public void ReplaceAnyBattleTimeLeftListener(List<IAnyBattleTimeLeftListener> newValue)
	{
		int num = 7;
		AnyBattleTimeLeftListenerComponent anyBattleTimeLeftListenerComponent = (AnyBattleTimeLeftListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleTimeLeftListenerComponent));
		anyBattleTimeLeftListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyBattleTimeLeftListenerComponent);
	}

	public void RemoveAnyBattleTimeLeftListener()
	{
		((Entity)this).RemoveComponent(7);
	}

	public void AddAnyBattleTimeLeftListener(IAnyBattleTimeLeftListener value)
	{
		List<IAnyBattleTimeLeftListener> list = (hasAnyBattleTimeLeftListener ? anyBattleTimeLeftListener.value : new List<IAnyBattleTimeLeftListener>());
		list.Add(value);
		ReplaceAnyBattleTimeLeftListener(list);
	}

	public void RemoveAnyBattleTimeLeftListener(IAnyBattleTimeLeftListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyBattleTimeLeftListener> value2 = anyBattleTimeLeftListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyBattleTimeLeftListener();
		}
		else
		{
			ReplaceAnyBattleTimeLeftListener(value2);
		}
	}

	public void AddAnyBattleWaveDurationListener(List<IAnyBattleWaveDurationListener> newValue)
	{
		int num = 8;
		AnyBattleWaveDurationListenerComponent anyBattleWaveDurationListenerComponent = (AnyBattleWaveDurationListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleWaveDurationListenerComponent));
		anyBattleWaveDurationListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyBattleWaveDurationListenerComponent);
	}

	public void ReplaceAnyBattleWaveDurationListener(List<IAnyBattleWaveDurationListener> newValue)
	{
		int num = 8;
		AnyBattleWaveDurationListenerComponent anyBattleWaveDurationListenerComponent = (AnyBattleWaveDurationListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleWaveDurationListenerComponent));
		anyBattleWaveDurationListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyBattleWaveDurationListenerComponent);
	}

	public void RemoveAnyBattleWaveDurationListener()
	{
		((Entity)this).RemoveComponent(8);
	}

	public void AddAnyBattleWaveDurationListener(IAnyBattleWaveDurationListener value)
	{
		List<IAnyBattleWaveDurationListener> list = (hasAnyBattleWaveDurationListener ? anyBattleWaveDurationListener.value : new List<IAnyBattleWaveDurationListener>());
		list.Add(value);
		ReplaceAnyBattleWaveDurationListener(list);
	}

	public void RemoveAnyBattleWaveDurationListener(IAnyBattleWaveDurationListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyBattleWaveDurationListener> value2 = anyBattleWaveDurationListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyBattleWaveDurationListener();
		}
		else
		{
			ReplaceAnyBattleWaveDurationListener(value2);
		}
	}

	public void AddAnyBattleWaveTimeLeftListener(List<IAnyBattleWaveTimeLeftListener> newValue)
	{
		int num = 9;
		AnyBattleWaveTimeLeftListenerComponent anyBattleWaveTimeLeftListenerComponent = (AnyBattleWaveTimeLeftListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleWaveTimeLeftListenerComponent));
		anyBattleWaveTimeLeftListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyBattleWaveTimeLeftListenerComponent);
	}

	public void ReplaceAnyBattleWaveTimeLeftListener(List<IAnyBattleWaveTimeLeftListener> newValue)
	{
		int num = 9;
		AnyBattleWaveTimeLeftListenerComponent anyBattleWaveTimeLeftListenerComponent = (AnyBattleWaveTimeLeftListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleWaveTimeLeftListenerComponent));
		anyBattleWaveTimeLeftListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyBattleWaveTimeLeftListenerComponent);
	}

	public void RemoveAnyBattleWaveTimeLeftListener()
	{
		((Entity)this).RemoveComponent(9);
	}

	public void AddAnyBattleWaveTimeLeftListener(IAnyBattleWaveTimeLeftListener value)
	{
		List<IAnyBattleWaveTimeLeftListener> list = (hasAnyBattleWaveTimeLeftListener ? anyBattleWaveTimeLeftListener.value : new List<IAnyBattleWaveTimeLeftListener>());
		list.Add(value);
		ReplaceAnyBattleWaveTimeLeftListener(list);
	}

	public void RemoveAnyBattleWaveTimeLeftListener(IAnyBattleWaveTimeLeftListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyBattleWaveTimeLeftListener> value2 = anyBattleWaveTimeLeftListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyBattleWaveTimeLeftListener();
		}
		else
		{
			ReplaceAnyBattleWaveTimeLeftListener(value2);
		}
	}

	public void AddAnyBlueTeamCampPositionListener(List<IAnyBlueTeamCampPositionListener> newValue)
	{
		int num = 10;
		AnyBlueTeamCampPositionListenerComponent anyBlueTeamCampPositionListenerComponent = (AnyBlueTeamCampPositionListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBlueTeamCampPositionListenerComponent));
		anyBlueTeamCampPositionListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyBlueTeamCampPositionListenerComponent);
	}

	public void ReplaceAnyBlueTeamCampPositionListener(List<IAnyBlueTeamCampPositionListener> newValue)
	{
		int num = 10;
		AnyBlueTeamCampPositionListenerComponent anyBlueTeamCampPositionListenerComponent = (AnyBlueTeamCampPositionListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBlueTeamCampPositionListenerComponent));
		anyBlueTeamCampPositionListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyBlueTeamCampPositionListenerComponent);
	}

	public void RemoveAnyBlueTeamCampPositionListener()
	{
		((Entity)this).RemoveComponent(10);
	}

	public void AddAnyBlueTeamCampPositionListener(IAnyBlueTeamCampPositionListener value)
	{
		List<IAnyBlueTeamCampPositionListener> list = (hasAnyBlueTeamCampPositionListener ? anyBlueTeamCampPositionListener.value : new List<IAnyBlueTeamCampPositionListener>());
		list.Add(value);
		ReplaceAnyBlueTeamCampPositionListener(list);
	}

	public void RemoveAnyBlueTeamCampPositionListener(IAnyBlueTeamCampPositionListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyBlueTeamCampPositionListener> value2 = anyBlueTeamCampPositionListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyBlueTeamCampPositionListener();
		}
		else
		{
			ReplaceAnyBlueTeamCampPositionListener(value2);
		}
	}

	public void AddAnyBlueTeamCombatPowerListener(List<IAnyBlueTeamCombatPowerListener> newValue)
	{
		int num = 11;
		AnyBlueTeamCombatPowerListenerComponent anyBlueTeamCombatPowerListenerComponent = (AnyBlueTeamCombatPowerListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBlueTeamCombatPowerListenerComponent));
		anyBlueTeamCombatPowerListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyBlueTeamCombatPowerListenerComponent);
	}

	public void ReplaceAnyBlueTeamCombatPowerListener(List<IAnyBlueTeamCombatPowerListener> newValue)
	{
		int num = 11;
		AnyBlueTeamCombatPowerListenerComponent anyBlueTeamCombatPowerListenerComponent = (AnyBlueTeamCombatPowerListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBlueTeamCombatPowerListenerComponent));
		anyBlueTeamCombatPowerListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyBlueTeamCombatPowerListenerComponent);
	}

	public void RemoveAnyBlueTeamCombatPowerListener()
	{
		((Entity)this).RemoveComponent(11);
	}

	public void AddAnyBlueTeamCombatPowerListener(IAnyBlueTeamCombatPowerListener value)
	{
		List<IAnyBlueTeamCombatPowerListener> list = (hasAnyBlueTeamCombatPowerListener ? anyBlueTeamCombatPowerListener.value : new List<IAnyBlueTeamCombatPowerListener>());
		list.Add(value);
		ReplaceAnyBlueTeamCombatPowerListener(list);
	}

	public void RemoveAnyBlueTeamCombatPowerListener(IAnyBlueTeamCombatPowerListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyBlueTeamCombatPowerListener> value2 = anyBlueTeamCombatPowerListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyBlueTeamCombatPowerListener();
		}
		else
		{
			ReplaceAnyBlueTeamCombatPowerListener(value2);
		}
	}

	public void AddAnyBlueTeamStagingAreaPositionListener(List<IAnyBlueTeamStagingAreaPositionListener> newValue)
	{
		int num = 12;
		AnyBlueTeamStagingAreaPositionListenerComponent anyBlueTeamStagingAreaPositionListenerComponent = (AnyBlueTeamStagingAreaPositionListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBlueTeamStagingAreaPositionListenerComponent));
		anyBlueTeamStagingAreaPositionListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyBlueTeamStagingAreaPositionListenerComponent);
	}

	public void ReplaceAnyBlueTeamStagingAreaPositionListener(List<IAnyBlueTeamStagingAreaPositionListener> newValue)
	{
		int num = 12;
		AnyBlueTeamStagingAreaPositionListenerComponent anyBlueTeamStagingAreaPositionListenerComponent = (AnyBlueTeamStagingAreaPositionListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBlueTeamStagingAreaPositionListenerComponent));
		anyBlueTeamStagingAreaPositionListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyBlueTeamStagingAreaPositionListenerComponent);
	}

	public void RemoveAnyBlueTeamStagingAreaPositionListener()
	{
		((Entity)this).RemoveComponent(12);
	}

	public void AddAnyBlueTeamStagingAreaPositionListener(IAnyBlueTeamStagingAreaPositionListener value)
	{
		List<IAnyBlueTeamStagingAreaPositionListener> list = (hasAnyBlueTeamStagingAreaPositionListener ? anyBlueTeamStagingAreaPositionListener.value : new List<IAnyBlueTeamStagingAreaPositionListener>());
		list.Add(value);
		ReplaceAnyBlueTeamStagingAreaPositionListener(list);
	}

	public void RemoveAnyBlueTeamStagingAreaPositionListener(IAnyBlueTeamStagingAreaPositionListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyBlueTeamStagingAreaPositionListener> value2 = anyBlueTeamStagingAreaPositionListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyBlueTeamStagingAreaPositionListener();
		}
		else
		{
			ReplaceAnyBlueTeamStagingAreaPositionListener(value2);
		}
	}

	public void AddAnyCameraActiveListener(List<IAnyCameraActiveListener> newValue)
	{
		int num = 13;
		AnyCameraActiveListenerComponent anyCameraActiveListenerComponent = (AnyCameraActiveListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCameraActiveListenerComponent));
		anyCameraActiveListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyCameraActiveListenerComponent);
	}

	public void ReplaceAnyCameraActiveListener(List<IAnyCameraActiveListener> newValue)
	{
		int num = 13;
		AnyCameraActiveListenerComponent anyCameraActiveListenerComponent = (AnyCameraActiveListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCameraActiveListenerComponent));
		anyCameraActiveListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyCameraActiveListenerComponent);
	}

	public void RemoveAnyCameraActiveListener()
	{
		((Entity)this).RemoveComponent(13);
	}

	public void AddAnyCameraActiveListener(IAnyCameraActiveListener value)
	{
		List<IAnyCameraActiveListener> list = (hasAnyCameraActiveListener ? anyCameraActiveListener.value : new List<IAnyCameraActiveListener>());
		list.Add(value);
		ReplaceAnyCameraActiveListener(list);
	}

	public void RemoveAnyCameraActiveListener(IAnyCameraActiveListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyCameraActiveListener> value2 = anyCameraActiveListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyCameraActiveListener();
		}
		else
		{
			ReplaceAnyCameraActiveListener(value2);
		}
	}

	public void AddAnyCameraAspectListener(List<IAnyCameraAspectListener> newValue)
	{
		int num = 14;
		AnyCameraAspectListenerComponent anyCameraAspectListenerComponent = (AnyCameraAspectListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCameraAspectListenerComponent));
		anyCameraAspectListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyCameraAspectListenerComponent);
	}

	public void ReplaceAnyCameraAspectListener(List<IAnyCameraAspectListener> newValue)
	{
		int num = 14;
		AnyCameraAspectListenerComponent anyCameraAspectListenerComponent = (AnyCameraAspectListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCameraAspectListenerComponent));
		anyCameraAspectListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyCameraAspectListenerComponent);
	}

	public void RemoveAnyCameraAspectListener()
	{
		((Entity)this).RemoveComponent(14);
	}

	public void AddAnyCameraAspectListener(IAnyCameraAspectListener value)
	{
		List<IAnyCameraAspectListener> list = (hasAnyCameraAspectListener ? anyCameraAspectListener.value : new List<IAnyCameraAspectListener>());
		list.Add(value);
		ReplaceAnyCameraAspectListener(list);
	}

	public void RemoveAnyCameraAspectListener(IAnyCameraAspectListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyCameraAspectListener> value2 = anyCameraAspectListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyCameraAspectListener();
		}
		else
		{
			ReplaceAnyCameraAspectListener(value2);
		}
	}

	public void AddAnyCameraFollowingUnitListener(List<IAnyCameraFollowingUnitListener> newValue)
	{
		int num = 15;
		AnyCameraFollowingUnitListenerComponent anyCameraFollowingUnitListenerComponent = (AnyCameraFollowingUnitListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCameraFollowingUnitListenerComponent));
		anyCameraFollowingUnitListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyCameraFollowingUnitListenerComponent);
	}

	public void ReplaceAnyCameraFollowingUnitListener(List<IAnyCameraFollowingUnitListener> newValue)
	{
		int num = 15;
		AnyCameraFollowingUnitListenerComponent anyCameraFollowingUnitListenerComponent = (AnyCameraFollowingUnitListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCameraFollowingUnitListenerComponent));
		anyCameraFollowingUnitListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyCameraFollowingUnitListenerComponent);
	}

	public void RemoveAnyCameraFollowingUnitListener()
	{
		((Entity)this).RemoveComponent(15);
	}

	public void AddAnyCameraFollowingUnitListener(IAnyCameraFollowingUnitListener value)
	{
		List<IAnyCameraFollowingUnitListener> list = (hasAnyCameraFollowingUnitListener ? anyCameraFollowingUnitListener.value : new List<IAnyCameraFollowingUnitListener>());
		list.Add(value);
		ReplaceAnyCameraFollowingUnitListener(list);
	}

	public void RemoveAnyCameraFollowingUnitListener(IAnyCameraFollowingUnitListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyCameraFollowingUnitListener> value2 = anyCameraFollowingUnitListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyCameraFollowingUnitListener();
		}
		else
		{
			ReplaceAnyCameraFollowingUnitListener(value2);
		}
	}

	public void AddAnyCameraFollowTeamListener(List<IAnyCameraFollowTeamListener> newValue)
	{
		int num = 16;
		AnyCameraFollowTeamListenerComponent anyCameraFollowTeamListenerComponent = (AnyCameraFollowTeamListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCameraFollowTeamListenerComponent));
		anyCameraFollowTeamListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyCameraFollowTeamListenerComponent);
	}

	public void ReplaceAnyCameraFollowTeamListener(List<IAnyCameraFollowTeamListener> newValue)
	{
		int num = 16;
		AnyCameraFollowTeamListenerComponent anyCameraFollowTeamListenerComponent = (AnyCameraFollowTeamListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCameraFollowTeamListenerComponent));
		anyCameraFollowTeamListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyCameraFollowTeamListenerComponent);
	}

	public void RemoveAnyCameraFollowTeamListener()
	{
		((Entity)this).RemoveComponent(16);
	}

	public void AddAnyCameraFollowTeamListener(IAnyCameraFollowTeamListener value)
	{
		List<IAnyCameraFollowTeamListener> list = (hasAnyCameraFollowTeamListener ? anyCameraFollowTeamListener.value : new List<IAnyCameraFollowTeamListener>());
		list.Add(value);
		ReplaceAnyCameraFollowTeamListener(list);
	}

	public void RemoveAnyCameraFollowTeamListener(IAnyCameraFollowTeamListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyCameraFollowTeamListener> value2 = anyCameraFollowTeamListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyCameraFollowTeamListener();
		}
		else
		{
			ReplaceAnyCameraFollowTeamListener(value2);
		}
	}

	public void AddAnyCameraMoveLimitListener(List<IAnyCameraMoveLimitListener> newValue)
	{
		int num = 17;
		AnyCameraMoveLimitListenerComponent anyCameraMoveLimitListenerComponent = (AnyCameraMoveLimitListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCameraMoveLimitListenerComponent));
		anyCameraMoveLimitListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyCameraMoveLimitListenerComponent);
	}

	public void ReplaceAnyCameraMoveLimitListener(List<IAnyCameraMoveLimitListener> newValue)
	{
		int num = 17;
		AnyCameraMoveLimitListenerComponent anyCameraMoveLimitListenerComponent = (AnyCameraMoveLimitListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCameraMoveLimitListenerComponent));
		anyCameraMoveLimitListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyCameraMoveLimitListenerComponent);
	}

	public void RemoveAnyCameraMoveLimitListener()
	{
		((Entity)this).RemoveComponent(17);
	}

	public void AddAnyCameraMoveLimitListener(IAnyCameraMoveLimitListener value)
	{
		List<IAnyCameraMoveLimitListener> list = (hasAnyCameraMoveLimitListener ? anyCameraMoveLimitListener.value : new List<IAnyCameraMoveLimitListener>());
		list.Add(value);
		ReplaceAnyCameraMoveLimitListener(list);
	}

	public void RemoveAnyCameraMoveLimitListener(IAnyCameraMoveLimitListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyCameraMoveLimitListener> value2 = anyCameraMoveLimitListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyCameraMoveLimitListener();
		}
		else
		{
			ReplaceAnyCameraMoveLimitListener(value2);
		}
	}

	public void AddAnyCameraPositionListener(List<IAnyCameraPositionListener> newValue)
	{
		int num = 18;
		AnyCameraPositionListenerComponent anyCameraPositionListenerComponent = (AnyCameraPositionListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCameraPositionListenerComponent));
		anyCameraPositionListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyCameraPositionListenerComponent);
	}

	public void ReplaceAnyCameraPositionListener(List<IAnyCameraPositionListener> newValue)
	{
		int num = 18;
		AnyCameraPositionListenerComponent anyCameraPositionListenerComponent = (AnyCameraPositionListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCameraPositionListenerComponent));
		anyCameraPositionListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyCameraPositionListenerComponent);
	}

	public void RemoveAnyCameraPositionListener()
	{
		((Entity)this).RemoveComponent(18);
	}

	public void AddAnyCameraPositionListener(IAnyCameraPositionListener value)
	{
		List<IAnyCameraPositionListener> list = (hasAnyCameraPositionListener ? anyCameraPositionListener.value : new List<IAnyCameraPositionListener>());
		list.Add(value);
		ReplaceAnyCameraPositionListener(list);
	}

	public void RemoveAnyCameraPositionListener(IAnyCameraPositionListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyCameraPositionListener> value2 = anyCameraPositionListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyCameraPositionListener();
		}
		else
		{
			ReplaceAnyCameraPositionListener(value2);
		}
	}

	public void AddAnyCameraRotationListener(List<IAnyCameraRotationListener> newValue)
	{
		int num = 19;
		AnyCameraRotationListenerComponent anyCameraRotationListenerComponent = (AnyCameraRotationListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCameraRotationListenerComponent));
		anyCameraRotationListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyCameraRotationListenerComponent);
	}

	public void ReplaceAnyCameraRotationListener(List<IAnyCameraRotationListener> newValue)
	{
		int num = 19;
		AnyCameraRotationListenerComponent anyCameraRotationListenerComponent = (AnyCameraRotationListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCameraRotationListenerComponent));
		anyCameraRotationListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyCameraRotationListenerComponent);
	}

	public void RemoveAnyCameraRotationListener()
	{
		((Entity)this).RemoveComponent(19);
	}

	public void AddAnyCameraRotationListener(IAnyCameraRotationListener value)
	{
		List<IAnyCameraRotationListener> list = (hasAnyCameraRotationListener ? anyCameraRotationListener.value : new List<IAnyCameraRotationListener>());
		list.Add(value);
		ReplaceAnyCameraRotationListener(list);
	}

	public void RemoveAnyCameraRotationListener(IAnyCameraRotationListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyCameraRotationListener> value2 = anyCameraRotationListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyCameraRotationListener();
		}
		else
		{
			ReplaceAnyCameraRotationListener(value2);
		}
	}

	public void AddAnyCameraSizeListener(List<IAnyCameraSizeListener> newValue)
	{
		int num = 20;
		AnyCameraSizeListenerComponent anyCameraSizeListenerComponent = (AnyCameraSizeListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCameraSizeListenerComponent));
		anyCameraSizeListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyCameraSizeListenerComponent);
	}

	public void ReplaceAnyCameraSizeListener(List<IAnyCameraSizeListener> newValue)
	{
		int num = 20;
		AnyCameraSizeListenerComponent anyCameraSizeListenerComponent = (AnyCameraSizeListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCameraSizeListenerComponent));
		anyCameraSizeListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyCameraSizeListenerComponent);
	}

	public void RemoveAnyCameraSizeListener()
	{
		((Entity)this).RemoveComponent(20);
	}

	public void AddAnyCameraSizeListener(IAnyCameraSizeListener value)
	{
		List<IAnyCameraSizeListener> list = (hasAnyCameraSizeListener ? anyCameraSizeListener.value : new List<IAnyCameraSizeListener>());
		list.Add(value);
		ReplaceAnyCameraSizeListener(list);
	}

	public void RemoveAnyCameraSizeListener(IAnyCameraSizeListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyCameraSizeListener> value2 = anyCameraSizeListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyCameraSizeListener();
		}
		else
		{
			ReplaceAnyCameraSizeListener(value2);
		}
	}

	public void AddAnyCurrentLevelBattleStartedListener(List<IAnyCurrentLevelBattleStartedListener> newValue)
	{
		int num = 21;
		AnyCurrentLevelBattleStartedListenerComponent anyCurrentLevelBattleStartedListenerComponent = (AnyCurrentLevelBattleStartedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCurrentLevelBattleStartedListenerComponent));
		anyCurrentLevelBattleStartedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyCurrentLevelBattleStartedListenerComponent);
	}

	public void ReplaceAnyCurrentLevelBattleStartedListener(List<IAnyCurrentLevelBattleStartedListener> newValue)
	{
		int num = 21;
		AnyCurrentLevelBattleStartedListenerComponent anyCurrentLevelBattleStartedListenerComponent = (AnyCurrentLevelBattleStartedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCurrentLevelBattleStartedListenerComponent));
		anyCurrentLevelBattleStartedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyCurrentLevelBattleStartedListenerComponent);
	}

	public void RemoveAnyCurrentLevelBattleStartedListener()
	{
		((Entity)this).RemoveComponent(21);
	}

	public void AddAnyCurrentLevelBattleStartedListener(IAnyCurrentLevelBattleStartedListener value)
	{
		List<IAnyCurrentLevelBattleStartedListener> list = (hasAnyCurrentLevelBattleStartedListener ? anyCurrentLevelBattleStartedListener.value : new List<IAnyCurrentLevelBattleStartedListener>());
		list.Add(value);
		ReplaceAnyCurrentLevelBattleStartedListener(list);
	}

	public void RemoveAnyCurrentLevelBattleStartedListener(IAnyCurrentLevelBattleStartedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyCurrentLevelBattleStartedListener> value2 = anyCurrentLevelBattleStartedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyCurrentLevelBattleStartedListener();
		}
		else
		{
			ReplaceAnyCurrentLevelBattleStartedListener(value2);
		}
	}

	public void AddAnyCurrentLevelBattleStartedRemovedListener(List<IAnyCurrentLevelBattleStartedRemovedListener> newValue)
	{
		int num = 22;
		AnyCurrentLevelBattleStartedRemovedListenerComponent anyCurrentLevelBattleStartedRemovedListenerComponent = (AnyCurrentLevelBattleStartedRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCurrentLevelBattleStartedRemovedListenerComponent));
		anyCurrentLevelBattleStartedRemovedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyCurrentLevelBattleStartedRemovedListenerComponent);
	}

	public void ReplaceAnyCurrentLevelBattleStartedRemovedListener(List<IAnyCurrentLevelBattleStartedRemovedListener> newValue)
	{
		int num = 22;
		AnyCurrentLevelBattleStartedRemovedListenerComponent anyCurrentLevelBattleStartedRemovedListenerComponent = (AnyCurrentLevelBattleStartedRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCurrentLevelBattleStartedRemovedListenerComponent));
		anyCurrentLevelBattleStartedRemovedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyCurrentLevelBattleStartedRemovedListenerComponent);
	}

	public void RemoveAnyCurrentLevelBattleStartedRemovedListener()
	{
		((Entity)this).RemoveComponent(22);
	}

	public void AddAnyCurrentLevelBattleStartedRemovedListener(IAnyCurrentLevelBattleStartedRemovedListener value)
	{
		List<IAnyCurrentLevelBattleStartedRemovedListener> list = (hasAnyCurrentLevelBattleStartedRemovedListener ? anyCurrentLevelBattleStartedRemovedListener.value : new List<IAnyCurrentLevelBattleStartedRemovedListener>());
		list.Add(value);
		ReplaceAnyCurrentLevelBattleStartedRemovedListener(list);
	}

	public void RemoveAnyCurrentLevelBattleStartedRemovedListener(IAnyCurrentLevelBattleStartedRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyCurrentLevelBattleStartedRemovedListener> value2 = anyCurrentLevelBattleStartedRemovedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyCurrentLevelBattleStartedRemovedListener();
		}
		else
		{
			ReplaceAnyCurrentLevelBattleStartedRemovedListener(value2);
		}
	}

	public void AddAnyDataReadyListener(List<IAnyDataReadyListener> newValue)
	{
		int num = 23;
		AnyDataReadyListenerComponent anyDataReadyListenerComponent = (AnyDataReadyListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyDataReadyListenerComponent));
		anyDataReadyListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyDataReadyListenerComponent);
	}

	public void ReplaceAnyDataReadyListener(List<IAnyDataReadyListener> newValue)
	{
		int num = 23;
		AnyDataReadyListenerComponent anyDataReadyListenerComponent = (AnyDataReadyListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyDataReadyListenerComponent));
		anyDataReadyListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyDataReadyListenerComponent);
	}

	public void RemoveAnyDataReadyListener()
	{
		((Entity)this).RemoveComponent(23);
	}

	public void AddAnyDataReadyListener(IAnyDataReadyListener value)
	{
		List<IAnyDataReadyListener> list = (hasAnyDataReadyListener ? anyDataReadyListener.value : new List<IAnyDataReadyListener>());
		list.Add(value);
		ReplaceAnyDataReadyListener(list);
	}

	public void RemoveAnyDataReadyListener(IAnyDataReadyListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyDataReadyListener> value2 = anyDataReadyListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyDataReadyListener();
		}
		else
		{
			ReplaceAnyDataReadyListener(value2);
		}
	}

	public void AddAnyFreeBattleModeListener(List<IAnyFreeBattleModeListener> newValue)
	{
		int num = 24;
		AnyFreeBattleModeListenerComponent anyFreeBattleModeListenerComponent = (AnyFreeBattleModeListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyFreeBattleModeListenerComponent));
		anyFreeBattleModeListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyFreeBattleModeListenerComponent);
	}

	public void ReplaceAnyFreeBattleModeListener(List<IAnyFreeBattleModeListener> newValue)
	{
		int num = 24;
		AnyFreeBattleModeListenerComponent anyFreeBattleModeListenerComponent = (AnyFreeBattleModeListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyFreeBattleModeListenerComponent));
		anyFreeBattleModeListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyFreeBattleModeListenerComponent);
	}

	public void RemoveAnyFreeBattleModeListener()
	{
		((Entity)this).RemoveComponent(24);
	}

	public void AddAnyFreeBattleModeListener(IAnyFreeBattleModeListener value)
	{
		List<IAnyFreeBattleModeListener> list = (hasAnyFreeBattleModeListener ? anyFreeBattleModeListener.value : new List<IAnyFreeBattleModeListener>());
		list.Add(value);
		ReplaceAnyFreeBattleModeListener(list);
	}

	public void RemoveAnyFreeBattleModeListener(IAnyFreeBattleModeListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyFreeBattleModeListener> value2 = anyFreeBattleModeListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyFreeBattleModeListener();
		}
		else
		{
			ReplaceAnyFreeBattleModeListener(value2);
		}
	}

	public void AddAnyFreeBattleModeRemovedListener(List<IAnyFreeBattleModeRemovedListener> newValue)
	{
		int num = 25;
		AnyFreeBattleModeRemovedListenerComponent anyFreeBattleModeRemovedListenerComponent = (AnyFreeBattleModeRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyFreeBattleModeRemovedListenerComponent));
		anyFreeBattleModeRemovedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyFreeBattleModeRemovedListenerComponent);
	}

	public void ReplaceAnyFreeBattleModeRemovedListener(List<IAnyFreeBattleModeRemovedListener> newValue)
	{
		int num = 25;
		AnyFreeBattleModeRemovedListenerComponent anyFreeBattleModeRemovedListenerComponent = (AnyFreeBattleModeRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyFreeBattleModeRemovedListenerComponent));
		anyFreeBattleModeRemovedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyFreeBattleModeRemovedListenerComponent);
	}

	public void RemoveAnyFreeBattleModeRemovedListener()
	{
		((Entity)this).RemoveComponent(25);
	}

	public void AddAnyFreeBattleModeRemovedListener(IAnyFreeBattleModeRemovedListener value)
	{
		List<IAnyFreeBattleModeRemovedListener> list = (hasAnyFreeBattleModeRemovedListener ? anyFreeBattleModeRemovedListener.value : new List<IAnyFreeBattleModeRemovedListener>());
		list.Add(value);
		ReplaceAnyFreeBattleModeRemovedListener(list);
	}

	public void RemoveAnyFreeBattleModeRemovedListener(IAnyFreeBattleModeRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyFreeBattleModeRemovedListener> value2 = anyFreeBattleModeRemovedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyFreeBattleModeRemovedListener();
		}
		else
		{
			ReplaceAnyFreeBattleModeRemovedListener(value2);
		}
	}

	public void AddAnyGameDataLoadedListener(List<IAnyGameDataLoadedListener> newValue)
	{
		int num = 26;
		AnyGameDataLoadedListenerComponent anyGameDataLoadedListenerComponent = (AnyGameDataLoadedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyGameDataLoadedListenerComponent));
		anyGameDataLoadedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyGameDataLoadedListenerComponent);
	}

	public void ReplaceAnyGameDataLoadedListener(List<IAnyGameDataLoadedListener> newValue)
	{
		int num = 26;
		AnyGameDataLoadedListenerComponent anyGameDataLoadedListenerComponent = (AnyGameDataLoadedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyGameDataLoadedListenerComponent));
		anyGameDataLoadedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyGameDataLoadedListenerComponent);
	}

	public void RemoveAnyGameDataLoadedListener()
	{
		((Entity)this).RemoveComponent(26);
	}

	public void AddAnyGameDataLoadedListener(IAnyGameDataLoadedListener value)
	{
		List<IAnyGameDataLoadedListener> list = (hasAnyGameDataLoadedListener ? anyGameDataLoadedListener.value : new List<IAnyGameDataLoadedListener>());
		list.Add(value);
		ReplaceAnyGameDataLoadedListener(list);
	}

	public void RemoveAnyGameDataLoadedListener(IAnyGameDataLoadedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyGameDataLoadedListener> value2 = anyGameDataLoadedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyGameDataLoadedListener();
		}
		else
		{
			ReplaceAnyGameDataLoadedListener(value2);
		}
	}

	public void AddAnyGameEnteredListener(List<IAnyGameEnteredListener> newValue)
	{
		int num = 27;
		AnyGameEnteredListenerComponent anyGameEnteredListenerComponent = (AnyGameEnteredListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyGameEnteredListenerComponent));
		anyGameEnteredListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyGameEnteredListenerComponent);
	}

	public void ReplaceAnyGameEnteredListener(List<IAnyGameEnteredListener> newValue)
	{
		int num = 27;
		AnyGameEnteredListenerComponent anyGameEnteredListenerComponent = (AnyGameEnteredListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyGameEnteredListenerComponent));
		anyGameEnteredListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyGameEnteredListenerComponent);
	}

	public void RemoveAnyGameEnteredListener()
	{
		((Entity)this).RemoveComponent(27);
	}

	public void AddAnyGameEnteredListener(IAnyGameEnteredListener value)
	{
		List<IAnyGameEnteredListener> list = (hasAnyGameEnteredListener ? anyGameEnteredListener.value : new List<IAnyGameEnteredListener>());
		list.Add(value);
		ReplaceAnyGameEnteredListener(list);
	}

	public void RemoveAnyGameEnteredListener(IAnyGameEnteredListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyGameEnteredListener> value2 = anyGameEnteredListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyGameEnteredListener();
		}
		else
		{
			ReplaceAnyGameEnteredListener(value2);
		}
	}

	public void AddAnyLoadingAnimationDirectionListener(List<IAnyLoadingAnimationDirectionListener> newValue)
	{
		int num = 28;
		AnyLoadingAnimationDirectionListenerComponent anyLoadingAnimationDirectionListenerComponent = (AnyLoadingAnimationDirectionListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyLoadingAnimationDirectionListenerComponent));
		anyLoadingAnimationDirectionListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyLoadingAnimationDirectionListenerComponent);
	}

	public void ReplaceAnyLoadingAnimationDirectionListener(List<IAnyLoadingAnimationDirectionListener> newValue)
	{
		int num = 28;
		AnyLoadingAnimationDirectionListenerComponent anyLoadingAnimationDirectionListenerComponent = (AnyLoadingAnimationDirectionListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyLoadingAnimationDirectionListenerComponent));
		anyLoadingAnimationDirectionListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyLoadingAnimationDirectionListenerComponent);
	}

	public void RemoveAnyLoadingAnimationDirectionListener()
	{
		((Entity)this).RemoveComponent(28);
	}

	public void AddAnyLoadingAnimationDirectionListener(IAnyLoadingAnimationDirectionListener value)
	{
		List<IAnyLoadingAnimationDirectionListener> list = (hasAnyLoadingAnimationDirectionListener ? anyLoadingAnimationDirectionListener.value : new List<IAnyLoadingAnimationDirectionListener>());
		list.Add(value);
		ReplaceAnyLoadingAnimationDirectionListener(list);
	}

	public void RemoveAnyLoadingAnimationDirectionListener(IAnyLoadingAnimationDirectionListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyLoadingAnimationDirectionListener> value2 = anyLoadingAnimationDirectionListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyLoadingAnimationDirectionListener();
		}
		else
		{
			ReplaceAnyLoadingAnimationDirectionListener(value2);
		}
	}

	public void AddAnyLoadingPanelListener(List<IAnyLoadingPanelListener> newValue)
	{
		int num = 29;
		AnyLoadingPanelListenerComponent anyLoadingPanelListenerComponent = (AnyLoadingPanelListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyLoadingPanelListenerComponent));
		anyLoadingPanelListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyLoadingPanelListenerComponent);
	}

	public void ReplaceAnyLoadingPanelListener(List<IAnyLoadingPanelListener> newValue)
	{
		int num = 29;
		AnyLoadingPanelListenerComponent anyLoadingPanelListenerComponent = (AnyLoadingPanelListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyLoadingPanelListenerComponent));
		anyLoadingPanelListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyLoadingPanelListenerComponent);
	}

	public void RemoveAnyLoadingPanelListener()
	{
		((Entity)this).RemoveComponent(29);
	}

	public void AddAnyLoadingPanelListener(IAnyLoadingPanelListener value)
	{
		List<IAnyLoadingPanelListener> list = (hasAnyLoadingPanelListener ? anyLoadingPanelListener.value : new List<IAnyLoadingPanelListener>());
		list.Add(value);
		ReplaceAnyLoadingPanelListener(list);
	}

	public void RemoveAnyLoadingPanelListener(IAnyLoadingPanelListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyLoadingPanelListener> value2 = anyLoadingPanelListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyLoadingPanelListener();
		}
		else
		{
			ReplaceAnyLoadingPanelListener(value2);
		}
	}

	public void AddAnyLoadingPanelStatusListener(List<IAnyLoadingPanelStatusListener> newValue)
	{
		int num = 30;
		AnyLoadingPanelStatusListenerComponent anyLoadingPanelStatusListenerComponent = (AnyLoadingPanelStatusListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyLoadingPanelStatusListenerComponent));
		anyLoadingPanelStatusListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyLoadingPanelStatusListenerComponent);
	}

	public void ReplaceAnyLoadingPanelStatusListener(List<IAnyLoadingPanelStatusListener> newValue)
	{
		int num = 30;
		AnyLoadingPanelStatusListenerComponent anyLoadingPanelStatusListenerComponent = (AnyLoadingPanelStatusListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyLoadingPanelStatusListenerComponent));
		anyLoadingPanelStatusListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyLoadingPanelStatusListenerComponent);
	}

	public void RemoveAnyLoadingPanelStatusListener()
	{
		((Entity)this).RemoveComponent(30);
	}

	public void AddAnyLoadingPanelStatusListener(IAnyLoadingPanelStatusListener value)
	{
		List<IAnyLoadingPanelStatusListener> list = (hasAnyLoadingPanelStatusListener ? anyLoadingPanelStatusListener.value : new List<IAnyLoadingPanelStatusListener>());
		list.Add(value);
		ReplaceAnyLoadingPanelStatusListener(list);
	}

	public void RemoveAnyLoadingPanelStatusListener(IAnyLoadingPanelStatusListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyLoadingPanelStatusListener> value2 = anyLoadingPanelStatusListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyLoadingPanelStatusListener();
		}
		else
		{
			ReplaceAnyLoadingPanelStatusListener(value2);
		}
	}

	public void AddAnyLoadingProgressListener(List<IAnyLoadingProgressListener> newValue)
	{
		int num = 31;
		AnyLoadingProgressListenerComponent anyLoadingProgressListenerComponent = (AnyLoadingProgressListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyLoadingProgressListenerComponent));
		anyLoadingProgressListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyLoadingProgressListenerComponent);
	}

	public void ReplaceAnyLoadingProgressListener(List<IAnyLoadingProgressListener> newValue)
	{
		int num = 31;
		AnyLoadingProgressListenerComponent anyLoadingProgressListenerComponent = (AnyLoadingProgressListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyLoadingProgressListenerComponent));
		anyLoadingProgressListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyLoadingProgressListenerComponent);
	}

	public void RemoveAnyLoadingProgressListener()
	{
		((Entity)this).RemoveComponent(31);
	}

	public void AddAnyLoadingProgressListener(IAnyLoadingProgressListener value)
	{
		List<IAnyLoadingProgressListener> list = (hasAnyLoadingProgressListener ? anyLoadingProgressListener.value : new List<IAnyLoadingProgressListener>());
		list.Add(value);
		ReplaceAnyLoadingProgressListener(list);
	}

	public void RemoveAnyLoadingProgressListener(IAnyLoadingProgressListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyLoadingProgressListener> value2 = anyLoadingProgressListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyLoadingProgressListener();
		}
		else
		{
			ReplaceAnyLoadingProgressListener(value2);
		}
	}

	public void AddAnyLoadingShowAllSoldierListener(List<IAnyLoadingShowAllSoldierListener> newValue)
	{
		int num = 32;
		AnyLoadingShowAllSoldierListenerComponent anyLoadingShowAllSoldierListenerComponent = (AnyLoadingShowAllSoldierListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyLoadingShowAllSoldierListenerComponent));
		anyLoadingShowAllSoldierListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyLoadingShowAllSoldierListenerComponent);
	}

	public void ReplaceAnyLoadingShowAllSoldierListener(List<IAnyLoadingShowAllSoldierListener> newValue)
	{
		int num = 32;
		AnyLoadingShowAllSoldierListenerComponent anyLoadingShowAllSoldierListenerComponent = (AnyLoadingShowAllSoldierListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyLoadingShowAllSoldierListenerComponent));
		anyLoadingShowAllSoldierListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyLoadingShowAllSoldierListenerComponent);
	}

	public void RemoveAnyLoadingShowAllSoldierListener()
	{
		((Entity)this).RemoveComponent(32);
	}

	public void AddAnyLoadingShowAllSoldierListener(IAnyLoadingShowAllSoldierListener value)
	{
		List<IAnyLoadingShowAllSoldierListener> list = (hasAnyLoadingShowAllSoldierListener ? anyLoadingShowAllSoldierListener.value : new List<IAnyLoadingShowAllSoldierListener>());
		list.Add(value);
		ReplaceAnyLoadingShowAllSoldierListener(list);
	}

	public void RemoveAnyLoadingShowAllSoldierListener(IAnyLoadingShowAllSoldierListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyLoadingShowAllSoldierListener> value2 = anyLoadingShowAllSoldierListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyLoadingShowAllSoldierListener();
		}
		else
		{
			ReplaceAnyLoadingShowAllSoldierListener(value2);
		}
	}

	public void AddAnyLoadingTotalListener(List<IAnyLoadingTotalListener> newValue)
	{
		int num = 33;
		AnyLoadingTotalListenerComponent anyLoadingTotalListenerComponent = (AnyLoadingTotalListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyLoadingTotalListenerComponent));
		anyLoadingTotalListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyLoadingTotalListenerComponent);
	}

	public void ReplaceAnyLoadingTotalListener(List<IAnyLoadingTotalListener> newValue)
	{
		int num = 33;
		AnyLoadingTotalListenerComponent anyLoadingTotalListenerComponent = (AnyLoadingTotalListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyLoadingTotalListenerComponent));
		anyLoadingTotalListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyLoadingTotalListenerComponent);
	}

	public void RemoveAnyLoadingTotalListener()
	{
		((Entity)this).RemoveComponent(33);
	}

	public void AddAnyLoadingTotalListener(IAnyLoadingTotalListener value)
	{
		List<IAnyLoadingTotalListener> list = (hasAnyLoadingTotalListener ? anyLoadingTotalListener.value : new List<IAnyLoadingTotalListener>());
		list.Add(value);
		ReplaceAnyLoadingTotalListener(list);
	}

	public void RemoveAnyLoadingTotalListener(IAnyLoadingTotalListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyLoadingTotalListener> value2 = anyLoadingTotalListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyLoadingTotalListener();
		}
		else
		{
			ReplaceAnyLoadingTotalListener(value2);
		}
	}

	public void AddAnyLoserListener(List<IAnyLoserListener> newValue)
	{
		int num = 34;
		AnyLoserListenerComponent anyLoserListenerComponent = (AnyLoserListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyLoserListenerComponent));
		anyLoserListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyLoserListenerComponent);
	}

	public void ReplaceAnyLoserListener(List<IAnyLoserListener> newValue)
	{
		int num = 34;
		AnyLoserListenerComponent anyLoserListenerComponent = (AnyLoserListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyLoserListenerComponent));
		anyLoserListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyLoserListenerComponent);
	}

	public void RemoveAnyLoserListener()
	{
		((Entity)this).RemoveComponent(34);
	}

	public void AddAnyLoserListener(IAnyLoserListener value)
	{
		List<IAnyLoserListener> list = (hasAnyLoserListener ? anyLoserListener.value : new List<IAnyLoserListener>());
		list.Add(value);
		ReplaceAnyLoserListener(list);
	}

	public void RemoveAnyLoserListener(IAnyLoserListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyLoserListener> value2 = anyLoserListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyLoserListener();
		}
		else
		{
			ReplaceAnyLoserListener(value2);
		}
	}

	public void AddAnyNextLevelComingListener(List<IAnyNextLevelComingListener> newValue)
	{
		int num = 35;
		AnyNextLevelComingListenerComponent anyNextLevelComingListenerComponent = (AnyNextLevelComingListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyNextLevelComingListenerComponent));
		anyNextLevelComingListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyNextLevelComingListenerComponent);
	}

	public void ReplaceAnyNextLevelComingListener(List<IAnyNextLevelComingListener> newValue)
	{
		int num = 35;
		AnyNextLevelComingListenerComponent anyNextLevelComingListenerComponent = (AnyNextLevelComingListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyNextLevelComingListenerComponent));
		anyNextLevelComingListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyNextLevelComingListenerComponent);
	}

	public void RemoveAnyNextLevelComingListener()
	{
		((Entity)this).RemoveComponent(35);
	}

	public void AddAnyNextLevelComingListener(IAnyNextLevelComingListener value)
	{
		List<IAnyNextLevelComingListener> list = (hasAnyNextLevelComingListener ? anyNextLevelComingListener.value : new List<IAnyNextLevelComingListener>());
		list.Add(value);
		ReplaceAnyNextLevelComingListener(list);
	}

	public void RemoveAnyNextLevelComingListener(IAnyNextLevelComingListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyNextLevelComingListener> value2 = anyNextLevelComingListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyNextLevelComingListener();
		}
		else
		{
			ReplaceAnyNextLevelComingListener(value2);
		}
	}

	public void AddAnyNextLevelComingRemovedListener(List<IAnyNextLevelComingRemovedListener> newValue)
	{
		int num = 36;
		AnyNextLevelComingRemovedListenerComponent anyNextLevelComingRemovedListenerComponent = (AnyNextLevelComingRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyNextLevelComingRemovedListenerComponent));
		anyNextLevelComingRemovedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyNextLevelComingRemovedListenerComponent);
	}

	public void ReplaceAnyNextLevelComingRemovedListener(List<IAnyNextLevelComingRemovedListener> newValue)
	{
		int num = 36;
		AnyNextLevelComingRemovedListenerComponent anyNextLevelComingRemovedListenerComponent = (AnyNextLevelComingRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyNextLevelComingRemovedListenerComponent));
		anyNextLevelComingRemovedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyNextLevelComingRemovedListenerComponent);
	}

	public void RemoveAnyNextLevelComingRemovedListener()
	{
		((Entity)this).RemoveComponent(36);
	}

	public void AddAnyNextLevelComingRemovedListener(IAnyNextLevelComingRemovedListener value)
	{
		List<IAnyNextLevelComingRemovedListener> list = (hasAnyNextLevelComingRemovedListener ? anyNextLevelComingRemovedListener.value : new List<IAnyNextLevelComingRemovedListener>());
		list.Add(value);
		ReplaceAnyNextLevelComingRemovedListener(list);
	}

	public void RemoveAnyNextLevelComingRemovedListener(IAnyNextLevelComingRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyNextLevelComingRemovedListener> value2 = anyNextLevelComingRemovedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyNextLevelComingRemovedListener();
		}
		else
		{
			ReplaceAnyNextLevelComingRemovedListener(value2);
		}
	}

	public void AddAnyOfflineBonusesListener(List<IAnyOfflineBonusesListener> newValue)
	{
		int num = 37;
		AnyOfflineBonusesListenerComponent anyOfflineBonusesListenerComponent = (AnyOfflineBonusesListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyOfflineBonusesListenerComponent));
		anyOfflineBonusesListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyOfflineBonusesListenerComponent);
	}

	public void ReplaceAnyOfflineBonusesListener(List<IAnyOfflineBonusesListener> newValue)
	{
		int num = 37;
		AnyOfflineBonusesListenerComponent anyOfflineBonusesListenerComponent = (AnyOfflineBonusesListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyOfflineBonusesListenerComponent));
		anyOfflineBonusesListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyOfflineBonusesListenerComponent);
	}

	public void RemoveAnyOfflineBonusesListener()
	{
		((Entity)this).RemoveComponent(37);
	}

	public void AddAnyOfflineBonusesListener(IAnyOfflineBonusesListener value)
	{
		List<IAnyOfflineBonusesListener> list = (hasAnyOfflineBonusesListener ? anyOfflineBonusesListener.value : new List<IAnyOfflineBonusesListener>());
		list.Add(value);
		ReplaceAnyOfflineBonusesListener(list);
	}

	public void RemoveAnyOfflineBonusesListener(IAnyOfflineBonusesListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyOfflineBonusesListener> value2 = anyOfflineBonusesListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyOfflineBonusesListener();
		}
		else
		{
			ReplaceAnyOfflineBonusesListener(value2);
		}
	}

	public void AddAnyOfflineSecondsListener(List<IAnyOfflineSecondsListener> newValue)
	{
		int num = 38;
		AnyOfflineSecondsListenerComponent anyOfflineSecondsListenerComponent = (AnyOfflineSecondsListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyOfflineSecondsListenerComponent));
		anyOfflineSecondsListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyOfflineSecondsListenerComponent);
	}

	public void ReplaceAnyOfflineSecondsListener(List<IAnyOfflineSecondsListener> newValue)
	{
		int num = 38;
		AnyOfflineSecondsListenerComponent anyOfflineSecondsListenerComponent = (AnyOfflineSecondsListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyOfflineSecondsListenerComponent));
		anyOfflineSecondsListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyOfflineSecondsListenerComponent);
	}

	public void RemoveAnyOfflineSecondsListener()
	{
		((Entity)this).RemoveComponent(38);
	}

	public void AddAnyOfflineSecondsListener(IAnyOfflineSecondsListener value)
	{
		List<IAnyOfflineSecondsListener> list = (hasAnyOfflineSecondsListener ? anyOfflineSecondsListener.value : new List<IAnyOfflineSecondsListener>());
		list.Add(value);
		ReplaceAnyOfflineSecondsListener(list);
	}

	public void RemoveAnyOfflineSecondsListener(IAnyOfflineSecondsListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyOfflineSecondsListener> value2 = anyOfflineSecondsListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyOfflineSecondsListener();
		}
		else
		{
			ReplaceAnyOfflineSecondsListener(value2);
		}
	}

	public void AddAnyRedTeamCampPositionListener(List<IAnyRedTeamCampPositionListener> newValue)
	{
		int num = 39;
		AnyRedTeamCampPositionListenerComponent anyRedTeamCampPositionListenerComponent = (AnyRedTeamCampPositionListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyRedTeamCampPositionListenerComponent));
		anyRedTeamCampPositionListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyRedTeamCampPositionListenerComponent);
	}

	public void ReplaceAnyRedTeamCampPositionListener(List<IAnyRedTeamCampPositionListener> newValue)
	{
		int num = 39;
		AnyRedTeamCampPositionListenerComponent anyRedTeamCampPositionListenerComponent = (AnyRedTeamCampPositionListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyRedTeamCampPositionListenerComponent));
		anyRedTeamCampPositionListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyRedTeamCampPositionListenerComponent);
	}

	public void RemoveAnyRedTeamCampPositionListener()
	{
		((Entity)this).RemoveComponent(39);
	}

	public void AddAnyRedTeamCampPositionListener(IAnyRedTeamCampPositionListener value)
	{
		List<IAnyRedTeamCampPositionListener> list = (hasAnyRedTeamCampPositionListener ? anyRedTeamCampPositionListener.value : new List<IAnyRedTeamCampPositionListener>());
		list.Add(value);
		ReplaceAnyRedTeamCampPositionListener(list);
	}

	public void RemoveAnyRedTeamCampPositionListener(IAnyRedTeamCampPositionListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyRedTeamCampPositionListener> value2 = anyRedTeamCampPositionListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyRedTeamCampPositionListener();
		}
		else
		{
			ReplaceAnyRedTeamCampPositionListener(value2);
		}
	}

	public void AddAnyRedTeamCombatPowerListener(List<IAnyRedTeamCombatPowerListener> newValue)
	{
		int num = 40;
		AnyRedTeamCombatPowerListenerComponent anyRedTeamCombatPowerListenerComponent = (AnyRedTeamCombatPowerListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyRedTeamCombatPowerListenerComponent));
		anyRedTeamCombatPowerListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyRedTeamCombatPowerListenerComponent);
	}

	public void ReplaceAnyRedTeamCombatPowerListener(List<IAnyRedTeamCombatPowerListener> newValue)
	{
		int num = 40;
		AnyRedTeamCombatPowerListenerComponent anyRedTeamCombatPowerListenerComponent = (AnyRedTeamCombatPowerListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyRedTeamCombatPowerListenerComponent));
		anyRedTeamCombatPowerListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyRedTeamCombatPowerListenerComponent);
	}

	public void RemoveAnyRedTeamCombatPowerListener()
	{
		((Entity)this).RemoveComponent(40);
	}

	public void AddAnyRedTeamCombatPowerListener(IAnyRedTeamCombatPowerListener value)
	{
		List<IAnyRedTeamCombatPowerListener> list = (hasAnyRedTeamCombatPowerListener ? anyRedTeamCombatPowerListener.value : new List<IAnyRedTeamCombatPowerListener>());
		list.Add(value);
		ReplaceAnyRedTeamCombatPowerListener(list);
	}

	public void RemoveAnyRedTeamCombatPowerListener(IAnyRedTeamCombatPowerListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyRedTeamCombatPowerListener> value2 = anyRedTeamCombatPowerListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyRedTeamCombatPowerListener();
		}
		else
		{
			ReplaceAnyRedTeamCombatPowerListener(value2);
		}
	}

	public void AddAnyRedTeamStagingAreaPositionListener(List<IAnyRedTeamStagingAreaPositionListener> newValue)
	{
		int num = 41;
		AnyRedTeamStagingAreaPositionListenerComponent anyRedTeamStagingAreaPositionListenerComponent = (AnyRedTeamStagingAreaPositionListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyRedTeamStagingAreaPositionListenerComponent));
		anyRedTeamStagingAreaPositionListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyRedTeamStagingAreaPositionListenerComponent);
	}

	public void ReplaceAnyRedTeamStagingAreaPositionListener(List<IAnyRedTeamStagingAreaPositionListener> newValue)
	{
		int num = 41;
		AnyRedTeamStagingAreaPositionListenerComponent anyRedTeamStagingAreaPositionListenerComponent = (AnyRedTeamStagingAreaPositionListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyRedTeamStagingAreaPositionListenerComponent));
		anyRedTeamStagingAreaPositionListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyRedTeamStagingAreaPositionListenerComponent);
	}

	public void RemoveAnyRedTeamStagingAreaPositionListener()
	{
		((Entity)this).RemoveComponent(41);
	}

	public void AddAnyRedTeamStagingAreaPositionListener(IAnyRedTeamStagingAreaPositionListener value)
	{
		List<IAnyRedTeamStagingAreaPositionListener> list = (hasAnyRedTeamStagingAreaPositionListener ? anyRedTeamStagingAreaPositionListener.value : new List<IAnyRedTeamStagingAreaPositionListener>());
		list.Add(value);
		ReplaceAnyRedTeamStagingAreaPositionListener(list);
	}

	public void RemoveAnyRedTeamStagingAreaPositionListener(IAnyRedTeamStagingAreaPositionListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyRedTeamStagingAreaPositionListener> value2 = anyRedTeamStagingAreaPositionListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyRedTeamStagingAreaPositionListener();
		}
		else
		{
			ReplaceAnyRedTeamStagingAreaPositionListener(value2);
		}
	}

	public void AddAnyReplayModeListener(List<IAnyReplayModeListener> newValue)
	{
		int num = 42;
		AnyReplayModeListenerComponent anyReplayModeListenerComponent = (AnyReplayModeListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyReplayModeListenerComponent));
		anyReplayModeListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyReplayModeListenerComponent);
	}

	public void ReplaceAnyReplayModeListener(List<IAnyReplayModeListener> newValue)
	{
		int num = 42;
		AnyReplayModeListenerComponent anyReplayModeListenerComponent = (AnyReplayModeListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyReplayModeListenerComponent));
		anyReplayModeListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyReplayModeListenerComponent);
	}

	public void RemoveAnyReplayModeListener()
	{
		((Entity)this).RemoveComponent(42);
	}

	public void AddAnyReplayModeListener(IAnyReplayModeListener value)
	{
		List<IAnyReplayModeListener> list = (hasAnyReplayModeListener ? anyReplayModeListener.value : new List<IAnyReplayModeListener>());
		list.Add(value);
		ReplaceAnyReplayModeListener(list);
	}

	public void RemoveAnyReplayModeListener(IAnyReplayModeListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyReplayModeListener> value2 = anyReplayModeListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyReplayModeListener();
		}
		else
		{
			ReplaceAnyReplayModeListener(value2);
		}
	}

	public void AddAnyReplayModeRemovedListener(List<IAnyReplayModeRemovedListener> newValue)
	{
		int num = 43;
		AnyReplayModeRemovedListenerComponent anyReplayModeRemovedListenerComponent = (AnyReplayModeRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyReplayModeRemovedListenerComponent));
		anyReplayModeRemovedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyReplayModeRemovedListenerComponent);
	}

	public void ReplaceAnyReplayModeRemovedListener(List<IAnyReplayModeRemovedListener> newValue)
	{
		int num = 43;
		AnyReplayModeRemovedListenerComponent anyReplayModeRemovedListenerComponent = (AnyReplayModeRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyReplayModeRemovedListenerComponent));
		anyReplayModeRemovedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyReplayModeRemovedListenerComponent);
	}

	public void RemoveAnyReplayModeRemovedListener()
	{
		((Entity)this).RemoveComponent(43);
	}

	public void AddAnyReplayModeRemovedListener(IAnyReplayModeRemovedListener value)
	{
		List<IAnyReplayModeRemovedListener> list = (hasAnyReplayModeRemovedListener ? anyReplayModeRemovedListener.value : new List<IAnyReplayModeRemovedListener>());
		list.Add(value);
		ReplaceAnyReplayModeRemovedListener(list);
	}

	public void RemoveAnyReplayModeRemovedListener(IAnyReplayModeRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyReplayModeRemovedListener> value2 = anyReplayModeRemovedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyReplayModeRemovedListener();
		}
		else
		{
			ReplaceAnyReplayModeRemovedListener(value2);
		}
	}

	public void AddAnyReplayStateListener(List<IAnyReplayStateListener> newValue)
	{
		int num = 44;
		AnyReplayStateListenerComponent anyReplayStateListenerComponent = (AnyReplayStateListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyReplayStateListenerComponent));
		anyReplayStateListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyReplayStateListenerComponent);
	}

	public void ReplaceAnyReplayStateListener(List<IAnyReplayStateListener> newValue)
	{
		int num = 44;
		AnyReplayStateListenerComponent anyReplayStateListenerComponent = (AnyReplayStateListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyReplayStateListenerComponent));
		anyReplayStateListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyReplayStateListenerComponent);
	}

	public void RemoveAnyReplayStateListener()
	{
		((Entity)this).RemoveComponent(44);
	}

	public void AddAnyReplayStateListener(IAnyReplayStateListener value)
	{
		List<IAnyReplayStateListener> list = (hasAnyReplayStateListener ? anyReplayStateListener.value : new List<IAnyReplayStateListener>());
		list.Add(value);
		ReplaceAnyReplayStateListener(list);
	}

	public void RemoveAnyReplayStateListener(IAnyReplayStateListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyReplayStateListener> value2 = anyReplayStateListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyReplayStateListener();
		}
		else
		{
			ReplaceAnyReplayStateListener(value2);
		}
	}

	public void AddAnyReplayStateRemovedListener(List<IAnyReplayStateRemovedListener> newValue)
	{
		int num = 45;
		AnyReplayStateRemovedListenerComponent anyReplayStateRemovedListenerComponent = (AnyReplayStateRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyReplayStateRemovedListenerComponent));
		anyReplayStateRemovedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyReplayStateRemovedListenerComponent);
	}

	public void ReplaceAnyReplayStateRemovedListener(List<IAnyReplayStateRemovedListener> newValue)
	{
		int num = 45;
		AnyReplayStateRemovedListenerComponent anyReplayStateRemovedListenerComponent = (AnyReplayStateRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyReplayStateRemovedListenerComponent));
		anyReplayStateRemovedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyReplayStateRemovedListenerComponent);
	}

	public void RemoveAnyReplayStateRemovedListener()
	{
		((Entity)this).RemoveComponent(45);
	}

	public void AddAnyReplayStateRemovedListener(IAnyReplayStateRemovedListener value)
	{
		List<IAnyReplayStateRemovedListener> list = (hasAnyReplayStateRemovedListener ? anyReplayStateRemovedListener.value : new List<IAnyReplayStateRemovedListener>());
		list.Add(value);
		ReplaceAnyReplayStateRemovedListener(list);
	}

	public void RemoveAnyReplayStateRemovedListener(IAnyReplayStateRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyReplayStateRemovedListener> value2 = anyReplayStateRemovedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyReplayStateRemovedListener();
		}
		else
		{
			ReplaceAnyReplayStateRemovedListener(value2);
		}
	}

	public void AddAnyShowBattleWaveCountdownListener(List<IAnyShowBattleWaveCountdownListener> newValue)
	{
		int num = 46;
		AnyShowBattleWaveCountdownListenerComponent anyShowBattleWaveCountdownListenerComponent = (AnyShowBattleWaveCountdownListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyShowBattleWaveCountdownListenerComponent));
		anyShowBattleWaveCountdownListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyShowBattleWaveCountdownListenerComponent);
	}

	public void ReplaceAnyShowBattleWaveCountdownListener(List<IAnyShowBattleWaveCountdownListener> newValue)
	{
		int num = 46;
		AnyShowBattleWaveCountdownListenerComponent anyShowBattleWaveCountdownListenerComponent = (AnyShowBattleWaveCountdownListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyShowBattleWaveCountdownListenerComponent));
		anyShowBattleWaveCountdownListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyShowBattleWaveCountdownListenerComponent);
	}

	public void RemoveAnyShowBattleWaveCountdownListener()
	{
		((Entity)this).RemoveComponent(46);
	}

	public void AddAnyShowBattleWaveCountdownListener(IAnyShowBattleWaveCountdownListener value)
	{
		List<IAnyShowBattleWaveCountdownListener> list = (hasAnyShowBattleWaveCountdownListener ? anyShowBattleWaveCountdownListener.value : new List<IAnyShowBattleWaveCountdownListener>());
		list.Add(value);
		ReplaceAnyShowBattleWaveCountdownListener(list);
	}

	public void RemoveAnyShowBattleWaveCountdownListener(IAnyShowBattleWaveCountdownListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyShowBattleWaveCountdownListener> value2 = anyShowBattleWaveCountdownListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyShowBattleWaveCountdownListener();
		}
		else
		{
			ReplaceAnyShowBattleWaveCountdownListener(value2);
		}
	}

	public void AddAnyShowBattleWaveCountdownRemovedListener(List<IAnyShowBattleWaveCountdownRemovedListener> newValue)
	{
		int num = 47;
		AnyShowBattleWaveCountdownRemovedListenerComponent anyShowBattleWaveCountdownRemovedListenerComponent = (AnyShowBattleWaveCountdownRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyShowBattleWaveCountdownRemovedListenerComponent));
		anyShowBattleWaveCountdownRemovedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyShowBattleWaveCountdownRemovedListenerComponent);
	}

	public void ReplaceAnyShowBattleWaveCountdownRemovedListener(List<IAnyShowBattleWaveCountdownRemovedListener> newValue)
	{
		int num = 47;
		AnyShowBattleWaveCountdownRemovedListenerComponent anyShowBattleWaveCountdownRemovedListenerComponent = (AnyShowBattleWaveCountdownRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyShowBattleWaveCountdownRemovedListenerComponent));
		anyShowBattleWaveCountdownRemovedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyShowBattleWaveCountdownRemovedListenerComponent);
	}

	public void RemoveAnyShowBattleWaveCountdownRemovedListener()
	{
		((Entity)this).RemoveComponent(47);
	}

	public void AddAnyShowBattleWaveCountdownRemovedListener(IAnyShowBattleWaveCountdownRemovedListener value)
	{
		List<IAnyShowBattleWaveCountdownRemovedListener> list = (hasAnyShowBattleWaveCountdownRemovedListener ? anyShowBattleWaveCountdownRemovedListener.value : new List<IAnyShowBattleWaveCountdownRemovedListener>());
		list.Add(value);
		ReplaceAnyShowBattleWaveCountdownRemovedListener(list);
	}

	public void RemoveAnyShowBattleWaveCountdownRemovedListener(IAnyShowBattleWaveCountdownRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyShowBattleWaveCountdownRemovedListener> value2 = anyShowBattleWaveCountdownRemovedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyShowBattleWaveCountdownRemovedListener();
		}
		else
		{
			ReplaceAnyShowBattleWaveCountdownRemovedListener(value2);
		}
	}

	public void AddAnySubLevelWinnerListener(List<IAnySubLevelWinnerListener> newValue)
	{
		int num = 48;
		AnySubLevelWinnerListenerComponent anySubLevelWinnerListenerComponent = (AnySubLevelWinnerListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnySubLevelWinnerListenerComponent));
		anySubLevelWinnerListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anySubLevelWinnerListenerComponent);
	}

	public void ReplaceAnySubLevelWinnerListener(List<IAnySubLevelWinnerListener> newValue)
	{
		int num = 48;
		AnySubLevelWinnerListenerComponent anySubLevelWinnerListenerComponent = (AnySubLevelWinnerListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnySubLevelWinnerListenerComponent));
		anySubLevelWinnerListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anySubLevelWinnerListenerComponent);
	}

	public void RemoveAnySubLevelWinnerListener()
	{
		((Entity)this).RemoveComponent(48);
	}

	public void AddAnySubLevelWinnerListener(IAnySubLevelWinnerListener value)
	{
		List<IAnySubLevelWinnerListener> list = (hasAnySubLevelWinnerListener ? anySubLevelWinnerListener.value : new List<IAnySubLevelWinnerListener>());
		list.Add(value);
		ReplaceAnySubLevelWinnerListener(list);
	}

	public void RemoveAnySubLevelWinnerListener(IAnySubLevelWinnerListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnySubLevelWinnerListener> value2 = anySubLevelWinnerListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnySubLevelWinnerListener();
		}
		else
		{
			ReplaceAnySubLevelWinnerListener(value2);
		}
	}

	public void AddAnyTeamHealthPointsTotalListener(List<IAnyTeamHealthPointsTotalListener> newValue)
	{
		int num = 49;
		AnyTeamHealthPointsTotalListenerComponent anyTeamHealthPointsTotalListenerComponent = (AnyTeamHealthPointsTotalListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyTeamHealthPointsTotalListenerComponent));
		anyTeamHealthPointsTotalListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyTeamHealthPointsTotalListenerComponent);
	}

	public void ReplaceAnyTeamHealthPointsTotalListener(List<IAnyTeamHealthPointsTotalListener> newValue)
	{
		int num = 49;
		AnyTeamHealthPointsTotalListenerComponent anyTeamHealthPointsTotalListenerComponent = (AnyTeamHealthPointsTotalListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyTeamHealthPointsTotalListenerComponent));
		anyTeamHealthPointsTotalListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyTeamHealthPointsTotalListenerComponent);
	}

	public void RemoveAnyTeamHealthPointsTotalListener()
	{
		((Entity)this).RemoveComponent(49);
	}

	public void AddAnyTeamHealthPointsTotalListener(IAnyTeamHealthPointsTotalListener value)
	{
		List<IAnyTeamHealthPointsTotalListener> list = (hasAnyTeamHealthPointsTotalListener ? anyTeamHealthPointsTotalListener.value : new List<IAnyTeamHealthPointsTotalListener>());
		list.Add(value);
		ReplaceAnyTeamHealthPointsTotalListener(list);
	}

	public void RemoveAnyTeamHealthPointsTotalListener(IAnyTeamHealthPointsTotalListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyTeamHealthPointsTotalListener> value2 = anyTeamHealthPointsTotalListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyTeamHealthPointsTotalListener();
		}
		else
		{
			ReplaceAnyTeamHealthPointsTotalListener(value2);
		}
	}

	public void AddAnyUnlockedSoldiersListener(List<IAnyUnlockedSoldiersListener> newValue)
	{
		int num = 50;
		AnyUnlockedSoldiersListenerComponent anyUnlockedSoldiersListenerComponent = (AnyUnlockedSoldiersListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyUnlockedSoldiersListenerComponent));
		anyUnlockedSoldiersListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyUnlockedSoldiersListenerComponent);
	}

	public void ReplaceAnyUnlockedSoldiersListener(List<IAnyUnlockedSoldiersListener> newValue)
	{
		int num = 50;
		AnyUnlockedSoldiersListenerComponent anyUnlockedSoldiersListenerComponent = (AnyUnlockedSoldiersListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyUnlockedSoldiersListenerComponent));
		anyUnlockedSoldiersListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyUnlockedSoldiersListenerComponent);
	}

	public void RemoveAnyUnlockedSoldiersListener()
	{
		((Entity)this).RemoveComponent(50);
	}

	public void AddAnyUnlockedSoldiersListener(IAnyUnlockedSoldiersListener value)
	{
		List<IAnyUnlockedSoldiersListener> list = (hasAnyUnlockedSoldiersListener ? anyUnlockedSoldiersListener.value : new List<IAnyUnlockedSoldiersListener>());
		list.Add(value);
		ReplaceAnyUnlockedSoldiersListener(list);
	}

	public void RemoveAnyUnlockedSoldiersListener(IAnyUnlockedSoldiersListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyUnlockedSoldiersListener> value2 = anyUnlockedSoldiersListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyUnlockedSoldiersListener();
		}
		else
		{
			ReplaceAnyUnlockedSoldiersListener(value2);
		}
	}

	public void AddAnyUserDataLoadedListener(List<IAnyUserDataLoadedListener> newValue)
	{
		int num = 51;
		AnyUserDataLoadedListenerComponent anyUserDataLoadedListenerComponent = (AnyUserDataLoadedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyUserDataLoadedListenerComponent));
		anyUserDataLoadedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyUserDataLoadedListenerComponent);
	}

	public void ReplaceAnyUserDataLoadedListener(List<IAnyUserDataLoadedListener> newValue)
	{
		int num = 51;
		AnyUserDataLoadedListenerComponent anyUserDataLoadedListenerComponent = (AnyUserDataLoadedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyUserDataLoadedListenerComponent));
		anyUserDataLoadedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyUserDataLoadedListenerComponent);
	}

	public void RemoveAnyUserDataLoadedListener()
	{
		((Entity)this).RemoveComponent(51);
	}

	public void AddAnyUserDataLoadedListener(IAnyUserDataLoadedListener value)
	{
		List<IAnyUserDataLoadedListener> list = (hasAnyUserDataLoadedListener ? anyUserDataLoadedListener.value : new List<IAnyUserDataLoadedListener>());
		list.Add(value);
		ReplaceAnyUserDataLoadedListener(list);
	}

	public void RemoveAnyUserDataLoadedListener(IAnyUserDataLoadedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyUserDataLoadedListener> value2 = anyUserDataLoadedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyUserDataLoadedListener();
		}
		else
		{
			ReplaceAnyUserDataLoadedListener(value2);
		}
	}

	public void AddAnyUserListener(List<IAnyUserListener> newValue)
	{
		int num = 52;
		AnyUserListenerComponent anyUserListenerComponent = (AnyUserListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyUserListenerComponent));
		anyUserListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyUserListenerComponent);
	}

	public void ReplaceAnyUserListener(List<IAnyUserListener> newValue)
	{
		int num = 52;
		AnyUserListenerComponent anyUserListenerComponent = (AnyUserListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyUserListenerComponent));
		anyUserListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyUserListenerComponent);
	}

	public void RemoveAnyUserListener()
	{
		((Entity)this).RemoveComponent(52);
	}

	public void AddAnyUserListener(IAnyUserListener value)
	{
		List<IAnyUserListener> list = (hasAnyUserListener ? anyUserListener.value : new List<IAnyUserListener>());
		list.Add(value);
		ReplaceAnyUserListener(list);
	}

	public void RemoveAnyUserListener(IAnyUserListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyUserListener> value2 = anyUserListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyUserListener();
		}
		else
		{
			ReplaceAnyUserListener(value2);
		}
	}

	public void AddAnyWinnerListener(List<IAnyWinnerListener> newValue)
	{
		int num = 53;
		AnyWinnerListenerComponent anyWinnerListenerComponent = (AnyWinnerListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyWinnerListenerComponent));
		anyWinnerListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyWinnerListenerComponent);
	}

	public void ReplaceAnyWinnerListener(List<IAnyWinnerListener> newValue)
	{
		int num = 53;
		AnyWinnerListenerComponent anyWinnerListenerComponent = (AnyWinnerListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyWinnerListenerComponent));
		anyWinnerListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyWinnerListenerComponent);
	}

	public void RemoveAnyWinnerListener()
	{
		((Entity)this).RemoveComponent(53);
	}

	public void AddAnyWinnerListener(IAnyWinnerListener value)
	{
		List<IAnyWinnerListener> list = (hasAnyWinnerListener ? anyWinnerListener.value : new List<IAnyWinnerListener>());
		list.Add(value);
		ReplaceAnyWinnerListener(list);
	}

	public void RemoveAnyWinnerListener(IAnyWinnerListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyWinnerListener> value2 = anyWinnerListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyWinnerListener();
		}
		else
		{
			ReplaceAnyWinnerListener(value2);
		}
	}

	public void AddBattleDamageStats(Dictionary<string, float> newRed, Dictionary<string, float> newBlue)
	{
		int num = 54;
		BattleDamageStatsComponent battleDamageStatsComponent = (BattleDamageStatsComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleDamageStatsComponent));
		battleDamageStatsComponent.red = newRed;
		battleDamageStatsComponent.blue = newBlue;
		((Entity)this).AddComponent(num, (IComponent)(object)battleDamageStatsComponent);
	}

	public void ReplaceBattleDamageStats(Dictionary<string, float> newRed, Dictionary<string, float> newBlue)
	{
		int num = 54;
		BattleDamageStatsComponent battleDamageStatsComponent = (BattleDamageStatsComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleDamageStatsComponent));
		battleDamageStatsComponent.red = newRed;
		battleDamageStatsComponent.blue = newBlue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleDamageStatsComponent);
	}

	public void RemoveBattleDamageStats()
	{
		((Entity)this).RemoveComponent(54);
	}

	public void AddBattleDuration(int newValue)
	{
		int num = 55;
		BattleDurationComponent battleDurationComponent = (BattleDurationComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleDurationComponent));
		battleDurationComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)battleDurationComponent);
	}

	public void ReplaceBattleDuration(int newValue)
	{
		int num = 55;
		BattleDurationComponent battleDurationComponent = (BattleDurationComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleDurationComponent));
		battleDurationComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleDurationComponent);
	}

	public void RemoveBattleDuration()
	{
		((Entity)this).RemoveComponent(55);
	}

	public void AddBattleElapsedTime(float newValue)
	{
		int num = 57;
		BattleElapsedTimeComponent battleElapsedTimeComponent = (BattleElapsedTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleElapsedTimeComponent));
		battleElapsedTimeComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)battleElapsedTimeComponent);
	}

	public void ReplaceBattleElapsedTime(float newValue)
	{
		int num = 57;
		BattleElapsedTimeComponent battleElapsedTimeComponent = (BattleElapsedTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleElapsedTimeComponent));
		battleElapsedTimeComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleElapsedTimeComponent);
	}

	public void RemoveBattleElapsedTime()
	{
		((Entity)this).RemoveComponent(57);
	}

	public void AddBattleFieldLength(float newValue)
	{
		int num = 58;
		BattleFieldLengthComponent battleFieldLengthComponent = (BattleFieldLengthComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleFieldLengthComponent));
		battleFieldLengthComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)battleFieldLengthComponent);
	}

	public void ReplaceBattleFieldLength(float newValue)
	{
		int num = 58;
		BattleFieldLengthComponent battleFieldLengthComponent = (BattleFieldLengthComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleFieldLengthComponent));
		battleFieldLengthComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleFieldLengthComponent);
	}

	public void RemoveBattleFieldLength()
	{
		((Entity)this).RemoveComponent(58);
	}

	public void AddBattleFieldLevel(Level newValue)
	{
		int num = 59;
		BattleFieldLevelComponent battleFieldLevelComponent = (BattleFieldLevelComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleFieldLevelComponent));
		battleFieldLevelComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)battleFieldLevelComponent);
	}

	public void ReplaceBattleFieldLevel(Level newValue)
	{
		int num = 59;
		BattleFieldLevelComponent battleFieldLevelComponent = (BattleFieldLevelComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleFieldLevelComponent));
		battleFieldLevelComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleFieldLevelComponent);
	}

	public void RemoveBattleFieldLevel()
	{
		((Entity)this).RemoveComponent(59);
	}

	public void AddBattleFieldMapIdentifier(string newValue)
	{
		int num = 60;
		BattleFieldMapIdentifierComponent battleFieldMapIdentifierComponent = (BattleFieldMapIdentifierComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleFieldMapIdentifierComponent));
		battleFieldMapIdentifierComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)battleFieldMapIdentifierComponent);
	}

	public void ReplaceBattleFieldMapIdentifier(string newValue)
	{
		int num = 60;
		BattleFieldMapIdentifierComponent battleFieldMapIdentifierComponent = (BattleFieldMapIdentifierComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleFieldMapIdentifierComponent));
		battleFieldMapIdentifierComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleFieldMapIdentifierComponent);
	}

	public void RemoveBattleFieldMapIdentifier()
	{
		((Entity)this).RemoveComponent(60);
	}

	public void AddBattleFieldSubLevelIndex(int newValue)
	{
		int num = 61;
		BattleFieldSubLevelIndexComponent battleFieldSubLevelIndexComponent = (BattleFieldSubLevelIndexComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleFieldSubLevelIndexComponent));
		battleFieldSubLevelIndexComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)battleFieldSubLevelIndexComponent);
	}

	public void ReplaceBattleFieldSubLevelIndex(int newValue)
	{
		int num = 61;
		BattleFieldSubLevelIndexComponent battleFieldSubLevelIndexComponent = (BattleFieldSubLevelIndexComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleFieldSubLevelIndexComponent));
		battleFieldSubLevelIndexComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleFieldSubLevelIndexComponent);
	}

	public void RemoveBattleFieldSubLevelIndex()
	{
		((Entity)this).RemoveComponent(61);
	}

	public void AddBattleId(string newValue)
	{
		int num = 62;
		BattleIdComponent battleIdComponent = (BattleIdComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleIdComponent));
		battleIdComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)battleIdComponent);
	}

	public void ReplaceBattleId(string newValue)
	{
		int num = 62;
		BattleIdComponent battleIdComponent = (BattleIdComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleIdComponent));
		battleIdComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleIdComponent);
	}

	public void RemoveBattleId()
	{
		((Entity)this).RemoveComponent(62);
	}

	public void AddBattleProgressStats(List<Bonus> newBonusRecord, int newClearStages)
	{
		int num = 63;
		BattleProgressStatsComponent battleProgressStatsComponent = (BattleProgressStatsComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleProgressStatsComponent));
		battleProgressStatsComponent.bonusRecord = newBonusRecord;
		battleProgressStatsComponent.clearStages = newClearStages;
		((Entity)this).AddComponent(num, (IComponent)(object)battleProgressStatsComponent);
	}

	public void ReplaceBattleProgressStats(List<Bonus> newBonusRecord, int newClearStages)
	{
		int num = 63;
		BattleProgressStatsComponent battleProgressStatsComponent = (BattleProgressStatsComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleProgressStatsComponent));
		battleProgressStatsComponent.bonusRecord = newBonusRecord;
		battleProgressStatsComponent.clearStages = newClearStages;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleProgressStatsComponent);
	}

	public void RemoveBattleProgressStats()
	{
		((Entity)this).RemoveComponent(63);
	}

	public void AddBattleStats(Dictionary<Team, TeamUnitStats> newValue)
	{
		int num = 65;
		BattleStatsComponent battleStatsComponent = (BattleStatsComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleStatsComponent));
		battleStatsComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)battleStatsComponent);
	}

	public void ReplaceBattleStats(Dictionary<Team, TeamUnitStats> newValue)
	{
		int num = 65;
		BattleStatsComponent battleStatsComponent = (BattleStatsComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleStatsComponent));
		battleStatsComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleStatsComponent);
	}

	public void RemoveBattleStats()
	{
		((Entity)this).RemoveComponent(65);
	}

	public void AddBattleTimeLeft(int newValue)
	{
		int num = 67;
		BattleTimeLeftComponent battleTimeLeftComponent = (BattleTimeLeftComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleTimeLeftComponent));
		battleTimeLeftComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)battleTimeLeftComponent);
	}

	public void ReplaceBattleTimeLeft(int newValue)
	{
		int num = 67;
		BattleTimeLeftComponent battleTimeLeftComponent = (BattleTimeLeftComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleTimeLeftComponent));
		battleTimeLeftComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleTimeLeftComponent);
	}

	public void RemoveBattleTimeLeft()
	{
		((Entity)this).RemoveComponent(67);
	}

	public void AddBattleWaveDuration(int newValue)
	{
		int num = 68;
		BattleWaveDurationComponent battleWaveDurationComponent = (BattleWaveDurationComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleWaveDurationComponent));
		battleWaveDurationComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)battleWaveDurationComponent);
	}

	public void ReplaceBattleWaveDuration(int newValue)
	{
		int num = 68;
		BattleWaveDurationComponent battleWaveDurationComponent = (BattleWaveDurationComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleWaveDurationComponent));
		battleWaveDurationComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleWaveDurationComponent);
	}

	public void RemoveBattleWaveDuration()
	{
		((Entity)this).RemoveComponent(68);
	}

	public void AddBattleWaveElapsedTime(float newValue)
	{
		int num = 69;
		BattleWaveElapsedTimeComponent battleWaveElapsedTimeComponent = (BattleWaveElapsedTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleWaveElapsedTimeComponent));
		battleWaveElapsedTimeComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)battleWaveElapsedTimeComponent);
	}

	public void ReplaceBattleWaveElapsedTime(float newValue)
	{
		int num = 69;
		BattleWaveElapsedTimeComponent battleWaveElapsedTimeComponent = (BattleWaveElapsedTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleWaveElapsedTimeComponent));
		battleWaveElapsedTimeComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleWaveElapsedTimeComponent);
	}

	public void RemoveBattleWaveElapsedTime()
	{
		((Entity)this).RemoveComponent(69);
	}

	public void AddBattleWaveTimeLeft(int newValue)
	{
		int num = 70;
		BattleWaveTimeLeftComponent battleWaveTimeLeftComponent = (BattleWaveTimeLeftComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleWaveTimeLeftComponent));
		battleWaveTimeLeftComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)battleWaveTimeLeftComponent);
	}

	public void ReplaceBattleWaveTimeLeft(int newValue)
	{
		int num = 70;
		BattleWaveTimeLeftComponent battleWaveTimeLeftComponent = (BattleWaveTimeLeftComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleWaveTimeLeftComponent));
		battleWaveTimeLeftComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleWaveTimeLeftComponent);
	}

	public void RemoveBattleWaveTimeLeft()
	{
		((Entity)this).RemoveComponent(70);
	}

	public void AddBattleWaveUnSpawnCount(int newValue)
	{
		int num = 71;
		BattleWaveUnSpawnCountComponent battleWaveUnSpawnCountComponent = (BattleWaveUnSpawnCountComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleWaveUnSpawnCountComponent));
		battleWaveUnSpawnCountComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)battleWaveUnSpawnCountComponent);
	}

	public void ReplaceBattleWaveUnSpawnCount(int newValue)
	{
		int num = 71;
		BattleWaveUnSpawnCountComponent battleWaveUnSpawnCountComponent = (BattleWaveUnSpawnCountComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleWaveUnSpawnCountComponent));
		battleWaveUnSpawnCountComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleWaveUnSpawnCountComponent);
	}

	public void RemoveBattleWaveUnSpawnCount()
	{
		((Entity)this).RemoveComponent(71);
	}

	public void AddBlueTeamCampPosition(Vector3 newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 72;
		BlueTeamCampPositionComponent blueTeamCampPositionComponent = (BlueTeamCampPositionComponent)(object)((Entity)this).CreateComponent(num, typeof(BlueTeamCampPositionComponent));
		blueTeamCampPositionComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)blueTeamCampPositionComponent);
	}

	public void ReplaceBlueTeamCampPosition(Vector3 newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 72;
		BlueTeamCampPositionComponent blueTeamCampPositionComponent = (BlueTeamCampPositionComponent)(object)((Entity)this).CreateComponent(num, typeof(BlueTeamCampPositionComponent));
		blueTeamCampPositionComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)blueTeamCampPositionComponent);
	}

	public void RemoveBlueTeamCampPosition()
	{
		((Entity)this).RemoveComponent(72);
	}

	public void AddBlueTeamCombatPower(int newValue)
	{
		int num = 73;
		BlueTeamCombatPowerComponent blueTeamCombatPowerComponent = (BlueTeamCombatPowerComponent)(object)((Entity)this).CreateComponent(num, typeof(BlueTeamCombatPowerComponent));
		blueTeamCombatPowerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)blueTeamCombatPowerComponent);
	}

	public void ReplaceBlueTeamCombatPower(int newValue)
	{
		int num = 73;
		BlueTeamCombatPowerComponent blueTeamCombatPowerComponent = (BlueTeamCombatPowerComponent)(object)((Entity)this).CreateComponent(num, typeof(BlueTeamCombatPowerComponent));
		blueTeamCombatPowerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)blueTeamCombatPowerComponent);
	}

	public void RemoveBlueTeamCombatPower()
	{
		((Entity)this).RemoveComponent(73);
	}

	public void AddBlueTeamStagingAreaPosition(Vector3[] newValue)
	{
		int num = 74;
		BlueTeamStagingAreaPositionComponent blueTeamStagingAreaPositionComponent = (BlueTeamStagingAreaPositionComponent)(object)((Entity)this).CreateComponent(num, typeof(BlueTeamStagingAreaPositionComponent));
		blueTeamStagingAreaPositionComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)blueTeamStagingAreaPositionComponent);
	}

	public void ReplaceBlueTeamStagingAreaPosition(Vector3[] newValue)
	{
		int num = 74;
		BlueTeamStagingAreaPositionComponent blueTeamStagingAreaPositionComponent = (BlueTeamStagingAreaPositionComponent)(object)((Entity)this).CreateComponent(num, typeof(BlueTeamStagingAreaPositionComponent));
		blueTeamStagingAreaPositionComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)blueTeamStagingAreaPositionComponent);
	}

	public void RemoveBlueTeamStagingAreaPosition()
	{
		((Entity)this).RemoveComponent(74);
	}

	public void AddCameraActive(bool newValue)
	{
		int num = 75;
		CameraActiveComponent cameraActiveComponent = (CameraActiveComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraActiveComponent));
		cameraActiveComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)cameraActiveComponent);
	}

	public void ReplaceCameraActive(bool newValue)
	{
		int num = 75;
		CameraActiveComponent cameraActiveComponent = (CameraActiveComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraActiveComponent));
		cameraActiveComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)cameraActiveComponent);
	}

	public void RemoveCameraActive()
	{
		((Entity)this).RemoveComponent(75);
	}

	public void AddCameraAspect(float newValue)
	{
		int num = 76;
		CameraAspectComponent cameraAspectComponent = (CameraAspectComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraAspectComponent));
		cameraAspectComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)cameraAspectComponent);
	}

	public void ReplaceCameraAspect(float newValue)
	{
		int num = 76;
		CameraAspectComponent cameraAspectComponent = (CameraAspectComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraAspectComponent));
		cameraAspectComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)cameraAspectComponent);
	}

	public void RemoveCameraAspect()
	{
		((Entity)this).RemoveComponent(76);
	}

	public void AddCameraFollowTeam(Team newValue)
	{
		int num = 78;
		CameraFollowTeamComponent cameraFollowTeamComponent = (CameraFollowTeamComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraFollowTeamComponent));
		cameraFollowTeamComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)cameraFollowTeamComponent);
	}

	public void ReplaceCameraFollowTeam(Team newValue)
	{
		int num = 78;
		CameraFollowTeamComponent cameraFollowTeamComponent = (CameraFollowTeamComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraFollowTeamComponent));
		cameraFollowTeamComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)cameraFollowTeamComponent);
	}

	public void RemoveCameraFollowTeam()
	{
		((Entity)this).RemoveComponent(78);
	}

	public void AddCameraMoveLimit(Vector3 newPosition, Vector3 newSize)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		int num = 79;
		CameraMoveLimitComponent cameraMoveLimitComponent = (CameraMoveLimitComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraMoveLimitComponent));
		cameraMoveLimitComponent.position = newPosition;
		cameraMoveLimitComponent.size = newSize;
		((Entity)this).AddComponent(num, (IComponent)(object)cameraMoveLimitComponent);
	}

	public void ReplaceCameraMoveLimit(Vector3 newPosition, Vector3 newSize)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		int num = 79;
		CameraMoveLimitComponent cameraMoveLimitComponent = (CameraMoveLimitComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraMoveLimitComponent));
		cameraMoveLimitComponent.position = newPosition;
		cameraMoveLimitComponent.size = newSize;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)cameraMoveLimitComponent);
	}

	public void RemoveCameraMoveLimit()
	{
		((Entity)this).RemoveComponent(79);
	}

	public void AddCameraPosition(Vector3 newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 80;
		CameraPositionComponent cameraPositionComponent = (CameraPositionComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraPositionComponent));
		cameraPositionComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)cameraPositionComponent);
	}

	public void ReplaceCameraPosition(Vector3 newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 80;
		CameraPositionComponent cameraPositionComponent = (CameraPositionComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraPositionComponent));
		cameraPositionComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)cameraPositionComponent);
	}

	public void RemoveCameraPosition()
	{
		((Entity)this).RemoveComponent(80);
	}

	public void AddCameraRotation(Quaternion newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 81;
		CameraRotationComponent cameraRotationComponent = (CameraRotationComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraRotationComponent));
		cameraRotationComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)cameraRotationComponent);
	}

	public void ReplaceCameraRotation(Quaternion newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 81;
		CameraRotationComponent cameraRotationComponent = (CameraRotationComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraRotationComponent));
		cameraRotationComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)cameraRotationComponent);
	}

	public void RemoveCameraRotation()
	{
		((Entity)this).RemoveComponent(81);
	}

	public void AddCameraSize(float newValue)
	{
		int num = 82;
		CameraSizeComponent cameraSizeComponent = (CameraSizeComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraSizeComponent));
		cameraSizeComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)cameraSizeComponent);
	}

	public void ReplaceCameraSize(float newValue)
	{
		int num = 82;
		CameraSizeComponent cameraSizeComponent = (CameraSizeComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraSizeComponent));
		cameraSizeComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)cameraSizeComponent);
	}

	public void RemoveCameraSize()
	{
		((Entity)this).RemoveComponent(82);
	}

	public void AddCharacterArchive(CharacterArchive newValue)
	{
		int num = 83;
		CharacterArchiveComponent characterArchiveComponent = (CharacterArchiveComponent)(object)((Entity)this).CreateComponent(num, typeof(CharacterArchiveComponent));
		characterArchiveComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)characterArchiveComponent);
	}

	public void ReplaceCharacterArchive(CharacterArchive newValue)
	{
		int num = 83;
		CharacterArchiveComponent characterArchiveComponent = (CharacterArchiveComponent)(object)((Entity)this).CreateComponent(num, typeof(CharacterArchiveComponent));
		characterArchiveComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)characterArchiveComponent);
	}

	public void RemoveCharacterArchive()
	{
		((Entity)this).RemoveComponent(83);
	}

	public void AddLoadingAnimationDirection(LoadingAnimationDirection newValue)
	{
		int num = 89;
		LoadingAnimationDirectionComponent loadingAnimationDirectionComponent = (LoadingAnimationDirectionComponent)(object)((Entity)this).CreateComponent(num, typeof(LoadingAnimationDirectionComponent));
		loadingAnimationDirectionComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)loadingAnimationDirectionComponent);
	}

	public void ReplaceLoadingAnimationDirection(LoadingAnimationDirection newValue)
	{
		int num = 89;
		LoadingAnimationDirectionComponent loadingAnimationDirectionComponent = (LoadingAnimationDirectionComponent)(object)((Entity)this).CreateComponent(num, typeof(LoadingAnimationDirectionComponent));
		loadingAnimationDirectionComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)loadingAnimationDirectionComponent);
	}

	public void RemoveLoadingAnimationDirection()
	{
		((Entity)this).RemoveComponent(89);
	}

	public void AddLoadingPanel(IUiPanel newValue)
	{
		int num = 90;
		LoadingPanelComponent loadingPanelComponent = (LoadingPanelComponent)(object)((Entity)this).CreateComponent(num, typeof(LoadingPanelComponent));
		loadingPanelComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)loadingPanelComponent);
	}

	public void ReplaceLoadingPanel(IUiPanel newValue)
	{
		int num = 90;
		LoadingPanelComponent loadingPanelComponent = (LoadingPanelComponent)(object)((Entity)this).CreateComponent(num, typeof(LoadingPanelComponent));
		loadingPanelComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)loadingPanelComponent);
	}

	public void RemoveLoadingPanel()
	{
		((Entity)this).RemoveComponent(90);
	}

	public void AddLoadingPanelStatus(LoadingPanelStatus newValue)
	{
		int num = 91;
		LoadingPanelStatusComponent loadingPanelStatusComponent = (LoadingPanelStatusComponent)(object)((Entity)this).CreateComponent(num, typeof(LoadingPanelStatusComponent));
		loadingPanelStatusComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)loadingPanelStatusComponent);
	}

	public void ReplaceLoadingPanelStatus(LoadingPanelStatus newValue)
	{
		int num = 91;
		LoadingPanelStatusComponent loadingPanelStatusComponent = (LoadingPanelStatusComponent)(object)((Entity)this).CreateComponent(num, typeof(LoadingPanelStatusComponent));
		loadingPanelStatusComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)loadingPanelStatusComponent);
	}

	public void RemoveLoadingPanelStatus()
	{
		((Entity)this).RemoveComponent(91);
	}

	public void AddLoadingProgress(int newValue)
	{
		int num = 92;
		LoadingProgressComponent loadingProgressComponent = (LoadingProgressComponent)(object)((Entity)this).CreateComponent(num, typeof(LoadingProgressComponent));
		loadingProgressComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)loadingProgressComponent);
	}

	public void ReplaceLoadingProgress(int newValue)
	{
		int num = 92;
		LoadingProgressComponent loadingProgressComponent = (LoadingProgressComponent)(object)((Entity)this).CreateComponent(num, typeof(LoadingProgressComponent));
		loadingProgressComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)loadingProgressComponent);
	}

	public void RemoveLoadingProgress()
	{
		((Entity)this).RemoveComponent(92);
	}

	public void AddLoadingTotal(int newValue)
	{
		int num = 94;
		LoadingTotalComponent loadingTotalComponent = (LoadingTotalComponent)(object)((Entity)this).CreateComponent(num, typeof(LoadingTotalComponent));
		loadingTotalComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)loadingTotalComponent);
	}

	public void ReplaceLoadingTotal(int newValue)
	{
		int num = 94;
		LoadingTotalComponent loadingTotalComponent = (LoadingTotalComponent)(object)((Entity)this).CreateComponent(num, typeof(LoadingTotalComponent));
		loadingTotalComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)loadingTotalComponent);
	}

	public void RemoveLoadingTotal()
	{
		((Entity)this).RemoveComponent(94);
	}

	public void AddLoser(Team newValue)
	{
		int num = 95;
		LoserComponent loserComponent = (LoserComponent)(object)((Entity)this).CreateComponent(num, typeof(LoserComponent));
		loserComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)loserComponent);
	}

	public void ReplaceLoser(Team newValue)
	{
		int num = 95;
		LoserComponent loserComponent = (LoserComponent)(object)((Entity)this).CreateComponent(num, typeof(LoserComponent));
		loserComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)loserComponent);
	}

	public void RemoveLoser()
	{
		((Entity)this).RemoveComponent(95);
	}

	public void AddOfflineBonuses(List<Bonus> newValue)
	{
		int num = 98;
		OfflineBonusesComponent offlineBonusesComponent = (OfflineBonusesComponent)(object)((Entity)this).CreateComponent(num, typeof(OfflineBonusesComponent));
		offlineBonusesComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)offlineBonusesComponent);
	}

	public void ReplaceOfflineBonuses(List<Bonus> newValue)
	{
		int num = 98;
		OfflineBonusesComponent offlineBonusesComponent = (OfflineBonusesComponent)(object)((Entity)this).CreateComponent(num, typeof(OfflineBonusesComponent));
		offlineBonusesComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)offlineBonusesComponent);
	}

	public void RemoveOfflineBonuses()
	{
		((Entity)this).RemoveComponent(98);
	}

	public void AddOfflineSeconds(int newValue)
	{
		int num = 99;
		OfflineSecondsComponent offlineSecondsComponent = (OfflineSecondsComponent)(object)((Entity)this).CreateComponent(num, typeof(OfflineSecondsComponent));
		offlineSecondsComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)offlineSecondsComponent);
	}

	public void ReplaceOfflineSeconds(int newValue)
	{
		int num = 99;
		OfflineSecondsComponent offlineSecondsComponent = (OfflineSecondsComponent)(object)((Entity)this).CreateComponent(num, typeof(OfflineSecondsComponent));
		offlineSecondsComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)offlineSecondsComponent);
	}

	public void RemoveOfflineSeconds()
	{
		((Entity)this).RemoveComponent(99);
	}

	public void AddRedTeamCampPosition(Vector3 newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 100;
		RedTeamCampPositionComponent redTeamCampPositionComponent = (RedTeamCampPositionComponent)(object)((Entity)this).CreateComponent(num, typeof(RedTeamCampPositionComponent));
		redTeamCampPositionComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)redTeamCampPositionComponent);
	}

	public void ReplaceRedTeamCampPosition(Vector3 newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 100;
		RedTeamCampPositionComponent redTeamCampPositionComponent = (RedTeamCampPositionComponent)(object)((Entity)this).CreateComponent(num, typeof(RedTeamCampPositionComponent));
		redTeamCampPositionComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)redTeamCampPositionComponent);
	}

	public void RemoveRedTeamCampPosition()
	{
		((Entity)this).RemoveComponent(100);
	}

	public void AddRedTeamCombatPower(int newValue)
	{
		int num = 101;
		RedTeamCombatPowerComponent redTeamCombatPowerComponent = (RedTeamCombatPowerComponent)(object)((Entity)this).CreateComponent(num, typeof(RedTeamCombatPowerComponent));
		redTeamCombatPowerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)redTeamCombatPowerComponent);
	}

	public void ReplaceRedTeamCombatPower(int newValue)
	{
		int num = 101;
		RedTeamCombatPowerComponent redTeamCombatPowerComponent = (RedTeamCombatPowerComponent)(object)((Entity)this).CreateComponent(num, typeof(RedTeamCombatPowerComponent));
		redTeamCombatPowerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)redTeamCombatPowerComponent);
	}

	public void RemoveRedTeamCombatPower()
	{
		((Entity)this).RemoveComponent(101);
	}

	public void AddRedTeamStagingAreaPosition(Vector3[] newValue)
	{
		int num = 102;
		RedTeamStagingAreaPositionComponent redTeamStagingAreaPositionComponent = (RedTeamStagingAreaPositionComponent)(object)((Entity)this).CreateComponent(num, typeof(RedTeamStagingAreaPositionComponent));
		redTeamStagingAreaPositionComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)redTeamStagingAreaPositionComponent);
	}

	public void ReplaceRedTeamStagingAreaPosition(Vector3[] newValue)
	{
		int num = 102;
		RedTeamStagingAreaPositionComponent redTeamStagingAreaPositionComponent = (RedTeamStagingAreaPositionComponent)(object)((Entity)this).CreateComponent(num, typeof(RedTeamStagingAreaPositionComponent));
		redTeamStagingAreaPositionComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)redTeamStagingAreaPositionComponent);
	}

	public void RemoveRedTeamStagingAreaPosition()
	{
		((Entity)this).RemoveComponent(102);
	}

	public void AddRefreshTeamHealthPointsTotal(Team newValue)
	{
		int num = 103;
		RefreshTeamHealthPointsTotalComponent refreshTeamHealthPointsTotalComponent = (RefreshTeamHealthPointsTotalComponent)(object)((Entity)this).CreateComponent(num, typeof(RefreshTeamHealthPointsTotalComponent));
		refreshTeamHealthPointsTotalComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)refreshTeamHealthPointsTotalComponent);
	}

	public void ReplaceRefreshTeamHealthPointsTotal(Team newValue)
	{
		int num = 103;
		RefreshTeamHealthPointsTotalComponent refreshTeamHealthPointsTotalComponent = (RefreshTeamHealthPointsTotalComponent)(object)((Entity)this).CreateComponent(num, typeof(RefreshTeamHealthPointsTotalComponent));
		refreshTeamHealthPointsTotalComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)refreshTeamHealthPointsTotalComponent);
	}

	public void RemoveRefreshTeamHealthPointsTotal()
	{
		((Entity)this).RemoveComponent(103);
	}

	public void AddReplayBattleId(string newValue)
	{
		int num = 104;
		ReplayBattleIdComponent replayBattleIdComponent = (ReplayBattleIdComponent)(object)((Entity)this).CreateComponent(num, typeof(ReplayBattleIdComponent));
		replayBattleIdComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)replayBattleIdComponent);
	}

	public void ReplaceReplayBattleId(string newValue)
	{
		int num = 104;
		ReplayBattleIdComponent replayBattleIdComponent = (ReplayBattleIdComponent)(object)((Entity)this).CreateComponent(num, typeof(ReplayBattleIdComponent));
		replayBattleIdComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)replayBattleIdComponent);
	}

	public void RemoveReplayBattleId()
	{
		((Entity)this).RemoveComponent(104);
	}

	public void AddReplayMode(int newValue)
	{
		int num = 105;
		ReplayModeComponent replayModeComponent = (ReplayModeComponent)(object)((Entity)this).CreateComponent(num, typeof(ReplayModeComponent));
		replayModeComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)replayModeComponent);
	}

	public void ReplaceReplayMode(int newValue)
	{
		int num = 105;
		ReplayModeComponent replayModeComponent = (ReplayModeComponent)(object)((Entity)this).CreateComponent(num, typeof(ReplayModeComponent));
		replayModeComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)replayModeComponent);
	}

	public void RemoveReplayMode()
	{
		((Entity)this).RemoveComponent(105);
	}

	public void AddReplayState(int newValue)
	{
		int num = 106;
		ReplayStateComponent replayStateComponent = (ReplayStateComponent)(object)((Entity)this).CreateComponent(num, typeof(ReplayStateComponent));
		replayStateComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)replayStateComponent);
	}

	public void ReplaceReplayState(int newValue)
	{
		int num = 106;
		ReplayStateComponent replayStateComponent = (ReplayStateComponent)(object)((Entity)this).CreateComponent(num, typeof(ReplayStateComponent));
		replayStateComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)replayStateComponent);
	}

	public void RemoveReplayState()
	{
		((Entity)this).RemoveComponent(106);
	}

	public void AddSubLevelWinner(Team newValue)
	{
		int num = 109;
		SubLevelWinnerComponent subLevelWinnerComponent = (SubLevelWinnerComponent)(object)((Entity)this).CreateComponent(num, typeof(SubLevelWinnerComponent));
		subLevelWinnerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)subLevelWinnerComponent);
	}

	public void ReplaceSubLevelWinner(Team newValue)
	{
		int num = 109;
		SubLevelWinnerComponent subLevelWinnerComponent = (SubLevelWinnerComponent)(object)((Entity)this).CreateComponent(num, typeof(SubLevelWinnerComponent));
		subLevelWinnerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)subLevelWinnerComponent);
	}

	public void RemoveSubLevelWinner()
	{
		((Entity)this).RemoveComponent(109);
	}

	public void AddTeamHealthPointsTotal(float newRedCurrent, float newRedTotal, float newBlueCurrent, float newBlueTotal)
	{
		int num = 110;
		TeamHealthPointsTotalComponent teamHealthPointsTotalComponent = (TeamHealthPointsTotalComponent)(object)((Entity)this).CreateComponent(num, typeof(TeamHealthPointsTotalComponent));
		teamHealthPointsTotalComponent.redCurrent = newRedCurrent;
		teamHealthPointsTotalComponent.redTotal = newRedTotal;
		teamHealthPointsTotalComponent.blueCurrent = newBlueCurrent;
		teamHealthPointsTotalComponent.blueTotal = newBlueTotal;
		((Entity)this).AddComponent(num, (IComponent)(object)teamHealthPointsTotalComponent);
	}

	public void ReplaceTeamHealthPointsTotal(float newRedCurrent, float newRedTotal, float newBlueCurrent, float newBlueTotal)
	{
		int num = 110;
		TeamHealthPointsTotalComponent teamHealthPointsTotalComponent = (TeamHealthPointsTotalComponent)(object)((Entity)this).CreateComponent(num, typeof(TeamHealthPointsTotalComponent));
		teamHealthPointsTotalComponent.redCurrent = newRedCurrent;
		teamHealthPointsTotalComponent.redTotal = newRedTotal;
		teamHealthPointsTotalComponent.blueCurrent = newBlueCurrent;
		teamHealthPointsTotalComponent.blueTotal = newBlueTotal;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)teamHealthPointsTotalComponent);
	}

	public void RemoveTeamHealthPointsTotal()
	{
		((Entity)this).RemoveComponent(110);
	}

	public void AddUnlockedSoldiers(List<string> newValue)
	{
		int num = 111;
		UnlockedSoldiersComponent unlockedSoldiersComponent = (UnlockedSoldiersComponent)(object)((Entity)this).CreateComponent(num, typeof(UnlockedSoldiersComponent));
		unlockedSoldiersComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)unlockedSoldiersComponent);
	}

	public void ReplaceUnlockedSoldiers(List<string> newValue)
	{
		int num = 111;
		UnlockedSoldiersComponent unlockedSoldiersComponent = (UnlockedSoldiersComponent)(object)((Entity)this).CreateComponent(num, typeof(UnlockedSoldiersComponent));
		unlockedSoldiersComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)unlockedSoldiersComponent);
	}

	public void RemoveUnlockedSoldiers()
	{
		((Entity)this).RemoveComponent(111);
	}

	public void AddUser(User newValue)
	{
		int num = 112;
		UserComponent userComponent = (UserComponent)(object)((Entity)this).CreateComponent(num, typeof(UserComponent));
		userComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)userComponent);
	}

	public void ReplaceUser(User newValue)
	{
		int num = 112;
		UserComponent userComponent = (UserComponent)(object)((Entity)this).CreateComponent(num, typeof(UserComponent));
		userComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)userComponent);
	}

	public void RemoveUser()
	{
		((Entity)this).RemoveComponent(112);
	}

	public void AddWinner(Team newValue)
	{
		int num = 114;
		WinnerComponent winnerComponent = (WinnerComponent)(object)((Entity)this).CreateComponent(num, typeof(WinnerComponent));
		winnerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)winnerComponent);
	}

	public void ReplaceWinner(Team newValue)
	{
		int num = 114;
		WinnerComponent winnerComponent = (WinnerComponent)(object)((Entity)this).CreateComponent(num, typeof(WinnerComponent));
		winnerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)winnerComponent);
	}

	public void RemoveWinner()
	{
		((Entity)this).RemoveComponent(114);
	}
}
