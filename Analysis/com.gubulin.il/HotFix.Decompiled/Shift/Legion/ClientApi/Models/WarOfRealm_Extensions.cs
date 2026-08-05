namespace Shift.Legion.ClientApi.Models;

public static class WarOfRealm_Extensions
{
	public enum StagePhase
	{
		NotBegin,
		Preparing,
		Battling,
		Settled
	}

	public static StagePhase GetStagePhase(this StageInfo stageInfo, int timestamp)
	{
		if (timestamp >= stageInfo.BeginTime && timestamp < stageInfo.SettleTime)
		{
			return StagePhase.Preparing;
		}
		if (timestamp >= stageInfo.SettleTime && timestamp < stageInfo.DisplayTime)
		{
			return StagePhase.Battling;
		}
		if (timestamp >= stageInfo.EndTime)
		{
			return StagePhase.Settled;
		}
		return StagePhase.NotBegin;
	}

	public static bool IsPreparing(this StageInfo stageInfo, int timestamp)
	{
		return timestamp >= stageInfo.BeginTime && timestamp < stageInfo.SettleTime;
	}

	public static bool IsBattling(this StageInfo stageInfo, int timestamp)
	{
		return timestamp >= stageInfo.SettleTime && timestamp < stageInfo.DisplayTime;
	}

	public static bool IsSettled(this StageInfo stageInfo, int timestamp)
	{
		return timestamp >= stageInfo.DisplayTime;
	}
}
