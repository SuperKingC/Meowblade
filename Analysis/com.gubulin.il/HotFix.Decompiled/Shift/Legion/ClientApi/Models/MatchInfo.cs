using System.Collections.Generic;

namespace Shift.Legion.ClientApi.Models;

public class MatchInfo
{
	public Dictionary<int, List<int>> WarGroupPlayers;

	public Dictionary<int, List<WarRankData>> SettlementInfoList;

	public List<WarRankData> UserInTop8 { get; set; }

	public WarRankDataInfo WarRankDataInfo { get; set; }
}
