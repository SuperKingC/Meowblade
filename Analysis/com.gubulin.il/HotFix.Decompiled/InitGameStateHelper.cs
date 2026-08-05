using GameMaths;

public class InitGameStateHelper
{
	public static void Init(GameStateContext state)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		state.ReplaceCameraActive(newValue: true);
		state.ReplaceCameraPosition(new Vector3(0f, 200f, -50f));
		state.ReplaceCameraRotation(Quaternion.identity);
		state.ReplaceCameraSize(5.4f);
		state.ReplaceCameraAspect(1.7777778f);
		state.ReplaceBattleFieldLength(51.6f);
		state.ReplaceBattleFieldMapIdentifier("");
		state.isBattleStarted = false;
		state.isCurrentLevelBattleStarted = false;
		state.isCameraFollowingUnit = true;
		state.ReplaceTeamHealthPointsTotal(0f, 0f, 0f, 0f);
		state.ReplaceBattleDamageStats(null, null);
	}
}
