using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGGetSelfShipCountResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(3)]
	public int Count { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVG_GET_SELF_SHIP_COUNT;
}
