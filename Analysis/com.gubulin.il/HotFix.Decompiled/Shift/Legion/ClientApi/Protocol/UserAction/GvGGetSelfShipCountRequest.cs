using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGGetSelfShipCountRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string IZId { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVG_GET_SELF_SHIP_COUNT;
}
