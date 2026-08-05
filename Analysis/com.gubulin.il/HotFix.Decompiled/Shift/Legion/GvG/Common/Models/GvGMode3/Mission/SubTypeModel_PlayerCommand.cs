using System.Collections.Generic;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.Mission;

public class SubTypeModel_PlayerCommand
{
	public Dictionary<string, float> ContributionPointAdd { get; set; } = new Dictionary<string, float>();

	public Dictionary<string, int> TimerAdd { get; set; } = new Dictionary<string, int>();

	public Dictionary<string, int> BaseCost { get; set; } = new Dictionary<string, int>();
}
