using Shift.Legion.Common.Enums;

public class StartBattleCommandExecutor
{
	private readonly Contexts _contexts;

	public StartBattleCommandExecutor(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Prepare()
	{
	}

	public void Execute(StartBattleCommand cmd)
	{
		GameStateContext gameState = _contexts.gameState;
		BattleConfigComponent battleConfig = _contexts.config.battleConfig;
		gameState.isBattleStarted = true;
		gameState.isCurrentLevelBattleStarted = true;
		if (gameState.hasWinner)
		{
			gameState.RemoveWinner();
		}
		if (gameState.hasLoser)
		{
			gameState.RemoveLoser();
		}
		if (battleConfig.Red.BattleMode == BattleMode.DefenceMode)
		{
			gameState.ReplaceBattleDuration(300);
		}
		else if (battleConfig.Red.BattleMode == BattleMode.MultiWaveAttackMode)
		{
			gameState.ReplaceBattleDuration(360);
		}
		else
		{
			gameState.ReplaceBattleDuration(180);
		}
		gameState.isBattleDurationUpdated = true;
		if (battleConfig.Red.BattleMode == BattleMode.MultiWaveAttackMode || battleConfig.Blue.BattleMode == BattleMode.MultiWaveAttackMode)
		{
			gameState.ReplaceBattleWaveDuration(30);
			gameState.ReplaceBattleWaveElapsedTime((float)gameState.battleWaveDuration.value - 2f + _contexts.input.fixedDeltaTime.value * 2f);
			gameState.ReplaceBattleWaveTimeLeft(2);
			gameState.ReplaceBattleWaveUnSpawnCount(0);
			gameState.isShowBattleWaveCountdown = false;
		}
		gameState.isCameraFollowingUnit = true;
		BattleMode battleMode = battleConfig.Red.BattleMode;
		if (battleMode == BattleMode.MultiWaveAttackMode)
		{
			gameState.ReplaceCameraFollowTeam(Team.Red);
		}
		else
		{
			gameState.ReplaceCameraFollowTeam((battleMode == BattleMode.DefenceMode) ? Team.Blue : Team.Red);
		}
		gameState.isRetreat = false;
		gameState.ReplaceTeamHealthPointsTotal(1f, 1f, 1f, 1f);
	}
}
