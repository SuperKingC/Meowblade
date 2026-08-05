using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

public interface IIslandEvent
{
	int MUID { get; set; }

	int IconIdx { get; set; }

	string MissionConfigId { get; }

	bool HasClaimed { get; set; }

	eIslandEvent EventType { get; set; }

	eIslandEventUiType UiType { get; set; }

	GvGMode3EventMissionConfigModel EventConfig { get; }

	void UpdateProgress(MissionStateRecordWithProgress progress);

	bool StillValid(int timestamp);

	int RemainingTime(int timestamp);

	bool HasTimeLimit();
}
