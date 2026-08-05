using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode3DestroyShipRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string ShipId { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_DESTORY_SHIP;
}
