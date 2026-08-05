using System.Collections.Generic;

namespace Shift.Legion.Common.Models;

public struct PrizeConfig
{
	public string ItemId;

	public int Weight;

	public List<int> QtyRange;

	public bool IsUnlock;

	public int Rarity;
}
