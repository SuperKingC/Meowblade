using System.Collections.Generic;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

public class DailyMission
{
	public int MissionId { get; set; }

	public int OnComplete { get; set; }

	public Dictionary<string, int> Reward { get; set; }
}
