using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ExchangeGvGStoreGuaranteedTicketResponse : IPacketBody
{
	[ProtoMember(99)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public int RemainingExchangeableRefreshCount { get; set; }

	[ProtoMember(2)]
	public StockChangeRecord[] StockChangeRecords { get; set; }

	public int PacketId => PacketIds.USER_ACTION_EXCHANGE_GVG_STORE_GUARANTEED_TICKET;
}
