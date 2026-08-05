using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class CheckUnshipOrders_IOS_Request : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.CHECK_UNSHIP_ORDERS_IOS_REQUEST;
}
