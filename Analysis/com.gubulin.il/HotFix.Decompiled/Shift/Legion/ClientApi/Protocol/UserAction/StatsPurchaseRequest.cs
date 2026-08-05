using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class StatsPurchaseRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public int UserId;

	[ProtoMember(2)]
	public int OrderId;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.STATS_PURCHASE_REQUEST;
}
