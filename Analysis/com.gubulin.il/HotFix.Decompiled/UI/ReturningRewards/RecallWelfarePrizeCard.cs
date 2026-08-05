using Shift.Legion.ClientApi.Models;

namespace UI.ReturningRewards;

public class RecallWelfarePrizeCard : IRecallWelfarePrize
{
	private readonly RecallWelfarePrize _prize;

	public int Index { get; }

	public string ItemId => _prize.ItemId;

	public int Qty => _prize.Qty;

	public int Rarity => _prize.Rarity;

	public RecallWelfarePrizeCard(int index, RecallWelfarePrize prize)
	{
		Index = index;
		_prize = prize;
	}
}
