using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class PlaceOrderRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public string StoreItemId;

	[ProtoMember(2)]
	public string PaymentType;

	[ProtoMember(3)]
	public int PriceIndex;

	[ProtoMember(4)]
	public int Qty;

	[ProtoMember(6)]
	public string PayParams;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.PLACE_ORDER_REQUEST;
}
