using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode3ChangeShipConfigRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string ShipId { get; set; }

	[ProtoMember(2)]
	public int ChangeShipConfigAction { get; set; }

	[ProtoMember(3)]
	public string json { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_CHANGE_SHIP_CONFIG;
}
