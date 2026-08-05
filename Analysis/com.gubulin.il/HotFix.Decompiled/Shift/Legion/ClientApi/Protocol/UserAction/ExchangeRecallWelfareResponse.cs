using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ExchangeRecallWelfareResponse : IPacketBody
{
	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public int TotalScore { get; set; }

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public List<StockChangeRecord> StockChangeRecords { get; set; } = new List<StockChangeRecord>();

	[ProtoMember(3)]
	public int Money { get; set; }

	public int PacketId => PacketIds.USER_ACTION_EXCHANGE_RECALLWELFARE_REQUEST;
}
