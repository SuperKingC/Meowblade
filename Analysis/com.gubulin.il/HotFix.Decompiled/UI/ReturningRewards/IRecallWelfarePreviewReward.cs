namespace UI.ReturningRewards;

public interface IRecallWelfarePreviewReward
{
	string ItemId { get; set; }

	string Name { get; set; }

	int NotObtainNum { get; set; }

	int Qty { get; set; }

	int Rarity { get; set; }
}
