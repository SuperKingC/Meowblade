using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace UI.ReturningRewards;

public class RecallWelfarePreviewReward : IRecallWelfarePreviewReward
{
	public string ItemId { get; set; }

	public string Name { get; set; }

	public int NotObtainNum { get; set; }

	public int Qty { get; set; }

	public int Rarity { get; set; }

	public RecallWelfarePreviewReward(string itemId, int notObtainNum, int qty, int rarity)
	{
		ItemId = itemId;
		Name = Item.Name(GameManagers.Instance, itemId);
		NotObtainNum = notObtainNum;
		Qty = qty;
		Rarity = rarity;
	}
}
