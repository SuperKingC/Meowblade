using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ExchangeSpinWeeklyResponse : IPacketBody
{
	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public int ConsumedExchangePoint { get; set; }

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public List<StockChangeRecord> StockChangeRecords { get; set; }

	public int PacketId => PacketIds.USER_ACTION_EXCHANGE_SPINWEEKLY_REQUEST;
}
