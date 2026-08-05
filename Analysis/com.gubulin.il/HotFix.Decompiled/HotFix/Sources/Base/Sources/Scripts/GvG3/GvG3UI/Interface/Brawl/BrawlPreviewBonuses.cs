using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Interface.Brawl;

public class BrawlPreviewBonuses : IBrawlPreviewBonuses
{
	public int[] Rank { get; }

	public List<IBrawlPreviewBonusItem> Bonuses { get; }

	public BrawlPreviewBonuses(int[] rank, List<IBrawlPreviewBonusItem> bonuses)
	{
		Rank = rank;
		Bonuses = bonuses;
	}
}
