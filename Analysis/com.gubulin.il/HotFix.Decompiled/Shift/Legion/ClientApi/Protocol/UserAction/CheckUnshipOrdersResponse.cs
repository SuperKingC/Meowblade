using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Store;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class CheckUnshipOrdersResponse
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public string Message;

	[ProtoMember(10, TypeName = "Shift.Legion.ClientApi.Protocol.Store.Order")]
	public List<Order> Orders;

	[ProtoMember(11)]
	public float RechargeTotal;

	public int PacketId => PacketIds.CHECK_UNSHIP_ORDERS_REQUEST;
}
