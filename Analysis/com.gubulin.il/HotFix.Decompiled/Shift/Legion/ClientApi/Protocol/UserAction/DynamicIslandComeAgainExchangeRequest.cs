using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class DynamicIslandComeAgainExchangeRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_DYNAMIC_ACTIVITY_ISLAND_COME_AGAIN_EXCHANGE_MONEY;
}
