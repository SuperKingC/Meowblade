using System.Collections.Generic;

namespace Shift.Legion.Common.Models;

public class MissionStats
{
	public Dictionary<string, int> MissionClaimRecords;

	public Dictionary<string, int> MissionCompleteRecords;

	public MissionStats()
	{
		MissionClaimRecords = new Dictionary<string, int>();
		MissionCompleteRecords = new Dictionary<string, int>();
	}
}
