using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Store;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class PlaceOrderResponse : IPacketBody
{
	[ProtoMember(1)]
	public Order Order;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(4)]
	public string JumpContext;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.PLACE_ORDER_REQUEST;
}
