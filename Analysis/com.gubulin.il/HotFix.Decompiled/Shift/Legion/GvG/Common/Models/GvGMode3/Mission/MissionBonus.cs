using System.Collections.Generic;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.Mission;

public class MissionBonus
{
	public Dictionary<string, int> Giver = null;

	public Dictionary<string, int> Taker = null;

	public Dictionary<string, int> OEMBaseBonus = null;

	public Dictionary<string, int> OEMExtraBonus = null;

	public Dictionary<string, int> OEMCriticalBonus = null;

	public Dictionary<string, int> OEMTitanBonus = null;

	public float ContributionPoint = 0f;

	public string BonusByRank = string.Empty;
}
