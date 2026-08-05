using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Interface.Brawl;

public interface IBrawlPreviewBonuses
{
	int[] Rank { get; }

	List<IBrawlPreviewBonusItem> Bonuses { get; }
}
