using System;

public static class CommandComponentsLookup
{
	public const int AddEnterMarkToUnitsCommand = 0;

	public const int CalcOfflineBonusCommand = 1;

	public const int ChangeCurrentFormationUnitCommand = 2;

	public const int ClearAllUnitsCommand = 3;

	public const int CloseLoadingUiCommand = 4;

	public const int CommandDelay = 5;

	public const int CommandDestroyedListener = 6;

	public const int Destroyed = 7;

	public const int EnterGameCommand = 8;

	public const int ExitReplayCommand = 9;

	public const int GameDataLoadedCommand = 10;

	public const int GameUserDataLoadedCommand = 11;

	public const int LoginCompleteCommand = 12;

	public const int OpenLoadingUiCommand = 13;

	public const int OpenSceneCommand = 14;

	public const int PauseReplayCommand = 15;

	public const int PlayReplayCommand = 16;

	public const int RetreatCommand = 17;

	public const int StartBattleCommand = 18;

	public const int TakeItemsCommand = 19;

	public const int UnlockSoldierCommand = 20;

	public const int TotalComponents = 21;

	public static readonly string[] componentNames = new string[21]
	{
		"AddEnterMarkToUnitsCommand", "CalcOfflineBonusCommand", "ChangeCurrentFormationUnitCommand", "ClearAllUnitsCommand", "CloseLoadingUiCommand", "CommandDelay", "CommandDestroyedListener", "Destroyed", "EnterGameCommand", "ExitReplayCommand",
		"GameDataLoadedCommand", "GameUserDataLoadedCommand", "LoginCompleteCommand", "OpenLoadingUiCommand", "OpenSceneCommand", "PauseReplayCommand", "PlayReplayCommand", "RetreatCommand", "StartBattleCommand", "TakeItemsCommand",
		"UnlockSoldierCommand"
	};

	public static readonly Type[] componentTypes = new Type[21]
	{
		typeof(AddEnterMarkToUnitsCommand),
		typeof(CalcOfflineBonusCommand),
		typeof(ChangeCurrentFormationUnitCommand),
		typeof(ClearAllUnitsCommand),
		typeof(CloseLoadingUiCommand),
		typeof(CommandDelayComponent),
		typeof(CommandDestroyedListenerComponent),
		typeof(DestroyedComponent),
		typeof(EnterGameCommand),
		typeof(ExitReplayCommand),
		typeof(GameDataLoadedCommand),
		typeof(GameUserDataLoadedCommand),
		typeof(LoginCompleteCommand),
		typeof(OpenLoadingUiCommand),
		typeof(OpenSceneCommand),
		typeof(PauseReplayCommand),
		typeof(PlayReplayCommand),
		typeof(RetreatCommand),
		typeof(StartBattleCommand),
		typeof(TakeItemsCommand),
		typeof(UnlockSoldierCommand)
	};
}
