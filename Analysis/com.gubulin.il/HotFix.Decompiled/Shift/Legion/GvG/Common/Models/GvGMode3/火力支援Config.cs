using System.Collections.Generic;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

public class 火力支援Config
{
	public string BuffAbilityId { get; set; }

	public int MaxTimeOfUsage_Base { get; set; }

	public int BuffDuration { get; set; }

	public HashSet<string> SpecialSuppress { get; set; }
}
