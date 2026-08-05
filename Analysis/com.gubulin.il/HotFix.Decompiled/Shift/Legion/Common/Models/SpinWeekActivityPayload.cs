using System.Collections.Generic;
using Shift.Legion.Common.Models.Store;

namespace Shift.Legion.Common.Models;

public class SpinWeekActivityPayload
{
	public class ExhibitPrize
	{
		public int Index { get; set; }

		public Dictionary<string, int> PrizeContent { get; set; }

		public int Rarity { get; set; }

		public bool IsLottery { get; set; }

		public bool IsNotice { get; set; }

		public string FromPoolConfig { get; set; }
	}

	public class SpinWeekExchangePrize
	{
		public int Index { get; set; }

		public int Priority { get; set; }

		public Dictionary<string, int> PrizeContent { get; set; }

		public int ExchangeLimit { get; set; }

		public int ExchangePoint { get; set; }

		public int UnlockExchangePoint { get; set; }

		public string ShowLevelCase { get; set; }

		public int ShowUserLevelCase { get; set; }
	}

	public class StoreContent
	{
		public int Index { get; set; }

		public string StoreItemId { get; set; }
	}

	public class SpinWeekStoreItem
	{
		public int Index { get; set; }

		public StoreItem StoreItem { get; set; }
	}

	public class SpinWeekCard
	{
		public int Day { get; set; }

		public Dictionary<string, int> Free { get; set; } = new Dictionary<string, int>();

		public Dictionary<string, int> Pay { get; set; } = new Dictionary<string, int>();

		public bool ClaimedFree { get; set; } = false;

		public bool ClaimedPay { get; set; } = false;
	}
}
