using System.Collections.Generic;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;

public class BrawlEventYesterdayReviewData
{
	public int Day { get; set; }

	public int StepIdx { get; set; }

	public List<ReviewTotal> ReviewTotal { get; set; }

	public List<ReviewResult> ReviewResults { get; set; }
}
