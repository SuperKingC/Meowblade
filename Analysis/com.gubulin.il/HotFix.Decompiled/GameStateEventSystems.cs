using Entitas;

public sealed class GameStateEventSystems : Feature
{
	public GameStateEventSystems(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new AnyBattleDurationEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyBattleFieldLengthEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyBattleFieldLevelEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyBattleFieldMapIdentifierEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyBattleFieldSubLevelIndexEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyBattleStartedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyBattleStartedRemovedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyBattleTimeLeftEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyBattleWaveDurationEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyBattleWaveTimeLeftEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyBlueTeamCampPositionEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyBlueTeamCombatPowerEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyBlueTeamStagingAreaPositionEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyCameraActiveEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyCameraAspectEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyCameraFollowingUnitEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyCameraFollowTeamEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyCameraMoveLimitEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyCameraPositionEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyCameraRotationEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyCameraSizeEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyCurrentLevelBattleStartedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyCurrentLevelBattleStartedRemovedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyDataReadyEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyFreeBattleModeEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyFreeBattleModeRemovedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyGameDataLoadedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyGameEnteredEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyLoadingAnimationDirectionEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyLoadingPanelEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyLoadingPanelStatusEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyLoadingProgressEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyLoadingShowAllSoldierEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyLoadingTotalEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyLoserEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyNextLevelComingEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyNextLevelComingRemovedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyOfflineBonusesEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyOfflineSecondsEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyRedTeamCampPositionEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyRedTeamCombatPowerEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyRedTeamStagingAreaPositionEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyReplayModeEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyReplayModeRemovedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyReplayStateEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyReplayStateRemovedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyShowBattleWaveCountdownEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyShowBattleWaveCountdownRemovedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnySubLevelWinnerEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyTeamHealthPointsTotalEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyUnlockedSoldiersEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyUserEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyUserDataLoadedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyWinnerEventSystem(contexts));
	}
}
