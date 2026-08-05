using System.Collections.Generic;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;

public class BrawlEventSettleResult
{
	public int Day { get; set; }

	public int StepIdx { get; set; }

	public int UserId { get; set; }

	public List<BrawlEventSettleInfo> Infos { get; set; }
}
