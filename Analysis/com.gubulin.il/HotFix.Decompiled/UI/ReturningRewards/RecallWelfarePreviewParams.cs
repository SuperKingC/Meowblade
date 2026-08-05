using System;
using System.Collections.Generic;

namespace UI.ReturningRewards;

public class RecallWelfarePreviewParams
{
	public List<IRecallWelfarePreviewReward> Rewards { get; set; } = new List<IRecallWelfarePreviewReward>();

	public bool IsFirst { get; set; }

	public Action OnFirstChecked { get; set; }
}
