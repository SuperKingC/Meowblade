using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class GvGStoreDescription
{
	public int BeginTime { get; set; }

	public int EndTime { get; set; }

	public List<SpecialRewardItem> SpecialRewards { get; set; }
}
