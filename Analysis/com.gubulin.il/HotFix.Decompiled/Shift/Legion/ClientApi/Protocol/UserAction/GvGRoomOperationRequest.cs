using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGRoomOperationRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string Op { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVG_ROOM_OPERATION;
}
