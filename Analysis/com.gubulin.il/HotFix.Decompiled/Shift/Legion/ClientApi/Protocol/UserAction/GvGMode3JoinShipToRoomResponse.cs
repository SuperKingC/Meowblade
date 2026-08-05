using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode3JoinShipToRoomResponse : IPacketBody
{
	[ProtoMember(2)]
	public string jsonGvGSoldiersEquippedItems;

	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_JOIN_SHIP_TO_ROOM;
}
