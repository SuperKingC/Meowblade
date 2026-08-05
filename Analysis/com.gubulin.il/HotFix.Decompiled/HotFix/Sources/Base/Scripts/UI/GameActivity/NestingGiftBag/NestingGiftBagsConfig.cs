using System.Collections.Generic;

namespace HotFix.Sources.Base.Scripts.UI.GameActivity.NestingGiftBag;

public class NestingGiftBagsConfig
{
	public string UnlockChapterId { get; set; }

	public string UnlockLevelId { get; set; }

	public string UnlockTip { get; set; }

	public string UnlockTitle { get; set; }

	public List<NestingGiftConfig> FreeGiftBags { get; set; } = new List<NestingGiftConfig>(1);

	public List<NestingGiftConfig> PaidGiftBags { get; set; } = new List<NestingGiftConfig>(1);
}
