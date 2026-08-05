namespace Shift.Legion.ClientApi.Protocol;

public enum GameEvent
{
	GameLaunched = 1001,
	ResourceUpdateStarted,
	ResourceUpdateEnded,
	Loading,
	OpenLoginUi,
	RegisterStarted,
	RegisterEnded,
	Login,
	SwitchAccount,
	EnterGame,
	OpenPanel,
	ClosePanel
}
