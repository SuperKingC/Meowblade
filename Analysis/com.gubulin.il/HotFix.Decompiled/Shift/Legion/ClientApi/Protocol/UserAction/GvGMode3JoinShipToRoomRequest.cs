using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode3JoinShipToRoomRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public string IZConfigId;

	[ProtoMember(2)]
	public int IZId;

	[ProtoMember(3)]
	public List<string> ShipIds;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_JOIN_SHIP_TO_ROOM;
}
