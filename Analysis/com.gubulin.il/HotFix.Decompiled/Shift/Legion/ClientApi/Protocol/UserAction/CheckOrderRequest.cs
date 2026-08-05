using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class CheckOrderRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public string OrderId;

	[ProtoMember(2)]
	public string TransactionId;

	[ProtoMember(3)]
	public string OrderMsg;

	[ProtoMember(4)]
	public string OpenId;

	[ProtoMember(5)]
	public string OpenKey;

	[ProtoMember(6)]
	public string Pf;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.CHECK_ORDER_REQUEST;
}
