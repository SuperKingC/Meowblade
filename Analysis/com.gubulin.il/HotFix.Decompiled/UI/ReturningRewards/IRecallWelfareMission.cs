using Shift.Legion.ClientApi.Models;

namespace UI.ReturningRewards;

public interface IRecallWelfareMission
{
	eMissionType Type { get; }

	string Description { get; }

	string LevelCase { get; }

	string MissionId { get; }

	RecallWelfareMissionUiState State { get; }

	int Score { get; }

	int TargetValue { get; }

	int CurrentValue { get; }

	RecallWelfareMissionJumpContext GetJumpContext();

	void OnMissionRewardClaimed(string missionId);
}
