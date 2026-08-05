namespace UI.ReturningRewards;

public interface IRecallWelfarePrize
{
	int Index { get; }

	string ItemId { get; }

	int Qty { get; }

	int Rarity { get; }
}
