using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class DynamicIslandComeAgainExchangeResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(3)]
	public int Money { get; set; }

	[ProtoMember(4)]
	public int CurrencyCost { get; set; }

	[ProtoMember(5)]
	public int ScoreItemCost { get; set; }

	public int PacketId => PacketIds.USER_ACTION_DYNAMIC_ACTIVITY_ISLAND_COME_AGAIN_EXCHANGE_MONEY;
}
