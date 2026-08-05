using System.Collections.Generic;
using Shift.Legion.GvG.Common.Models;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Interface.Brawl;

public class BrawlPreviewBonusItem : IBrawlPreviewBonusItem
{
	public string ItemId { get; }

	public int Cnt { get; }

	public bool IsExtra { get; private set; }

	public BrawlPreviewBonusItem(RItem item)
	{
		ItemId = item.ItemId;
		Cnt = item.cnt;
	}

	public BrawlPreviewBonusItem(KeyValuePair<string, int> kv)
	{
		ItemId = kv.Key;
		Cnt = kv.Value;
	}

	public void SetExtra(bool isExtra)
	{
		IsExtra = isExtra;
	}
}
