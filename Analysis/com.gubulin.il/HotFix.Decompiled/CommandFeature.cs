using Entitas;

public class CommandFeature : Feature
{
	public CommandFeature(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new AddEnterMarkToUnitsCommandSystem(contexts));
		((Systems)this).Add((ISystem)(object)new ClearAllUnitsCommandSystem(contexts));
		((Systems)this).Add((ISystem)(object)new ExitReplayCommandSystem(contexts));
		((Systems)this).Add((ISystem)(object)new PauseReplayCommandSystem(contexts));
		((Systems)this).Add((ISystem)(object)new PlayReplayCommandSystem(contexts));
		((Systems)this).Add((ISystem)(object)new RetreatCommandSystem(contexts));
		((Systems)this).Add((ISystem)(object)new StartBattleCommandSystem(contexts));
		((Systems)this).Add((ISystem)(object)new CalcOfflineBonusCommandSystem(contexts));
		((Systems)this).Add((ISystem)(object)new ChangeCurrentFormationUnitCommandSystem(contexts));
		((Systems)this).Add((ISystem)(object)new CloseLoadingUiCommandSystem(contexts));
		((Systems)this).Add((ISystem)(object)new EnterGameCommandSystem(contexts));
		((Systems)this).Add((ISystem)(object)new GameDataLoadedCommandSystem(contexts));
		((Systems)this).Add((ISystem)(object)new GameUserDataLoadedCommandSystem(contexts));
		((Systems)this).Add((ISystem)(object)new LoginCompleteCommandSystem(contexts));
		((Systems)this).Add((ISystem)(object)new OpenLoadingUiCommandSystem(contexts));
		((Systems)this).Add((ISystem)(object)new OpenSceneCommandSystem(contexts));
		((Systems)this).Add((ISystem)(object)new TakeItemsCommandSystem(contexts));
		((Systems)this).Add((ISystem)(object)new UnlockSoldierCommandSystem(contexts));
	}
}
