using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Store;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class CheckOrderResponse : IPacketBody
{
	[ProtoMember(1)]
	public Order Order;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(11)]
	public float RechargeTotal;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.CHECK_ORDER_REQUEST;
}
