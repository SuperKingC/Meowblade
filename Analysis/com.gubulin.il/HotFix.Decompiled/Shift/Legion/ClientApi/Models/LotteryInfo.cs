using System.Collections.Generic;

namespace Shift.Legion.ClientApi.Models;

public class LotteryInfo
{
	public List<WarGroupLottery> WarGroupLotteried;

	public WarStageLotterySettlement WarStageLotterySettlement;

	public int WinUserCnt { get; set; }

	public int WinCoinCnt { get; set; }
}
