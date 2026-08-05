using System.Collections.Generic;

namespace HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models;

public class BonusConfig
{
	public int RequiredScore;

	public Dictionary<string, int> Bonus;

	public Dictionary<string, int> PayBonus;

	public bool IsAdvance => PayBonus != null;
}
