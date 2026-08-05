using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class WarOfRealmSettlementResponse : IPacketBody
{
	public int PacketId => PacketIds.USER_ACTION_WAROFREALM_GET_LOTTERYINFO;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Models.WarGroupLottery")]
	public List<WarGroupLottery> WarGroupLotteried { get; set; }

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Models.WarStageLotterySettlement")]
	public WarStageLotterySettlement WarStageLotterySettlement { get; set; }

	[ProtoMember(3, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public List<StockChangeRecord> StockChangeRecords { get; set; }

	[ProtoMember(4)]
	public int WinUserCnt { get; set; }

	[ProtoMember(5)]
	public int WinCoinCnt { get; set; }
}
