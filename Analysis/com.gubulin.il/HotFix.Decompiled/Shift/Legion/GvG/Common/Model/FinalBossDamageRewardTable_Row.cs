using System.Collections.Generic;

namespace Shift.Legion.GvG.Common.Model;

public class FinalBossDamageRewardTable_Row
{
	public string min { get; set; }

	public string max { get; set; }

	public List<FinalBossDamageRewardTable_Row_R> r { get; set; }
}
