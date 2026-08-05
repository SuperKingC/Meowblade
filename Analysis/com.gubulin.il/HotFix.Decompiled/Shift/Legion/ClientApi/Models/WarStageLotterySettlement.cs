using System.Collections.Generic;
using System.Linq;
using ProtoBuf;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class WarStageLotterySettlement
{
	[ProtoMember(1)]
	public int StageStatus { get; set; }

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Models.WarGroupLotterySettlement")]
	public List<WarGroupLotterySettlement> WarGroupLotterySettlements { get; set; }

	[ProtoMember(3)]
	public int ChampionUserId { get; set; }

	[ProtoMember(4)]
	public List<int> GroupUserIds { get; set; }

	[ProtoMember(5)]
	public List<int> WinUserId { get; set; }

	[ProtoMember(6, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
	public List<RItem> RItemBonus { get; set; }

	[ProtoMember(7)]
	public List<int> LossUserId { get; set; }

	public int TotalLotteryCnt => (WarGroupLotterySettlements != null) ? WarGroupLotterySettlements.Sum((WarGroupLotterySettlement k) => k.TotalLotteryCnt) : ((WinUserId?.Count ?? 0) + (LossUserId?.Count ?? 0));

	public int TotalWinCnt => (WarGroupLotterySettlements != null) ? WarGroupLotterySettlements.Sum((WarGroupLotterySettlement k) => k.TotalWinCnt) : (WinUserId?.Count ?? 0);

	public float WinRate => (TotalLotteryCnt > 0) ? ((float)TotalWinCnt / (float)TotalLotteryCnt) : 0f;
}
