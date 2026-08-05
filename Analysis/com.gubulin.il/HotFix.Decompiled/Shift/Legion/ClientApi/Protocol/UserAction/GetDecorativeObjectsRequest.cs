using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetDecorativeObjectsRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int Type { get; set; }

	public int PacketId => PacketIds.USER_ACTION_PROFILE_GET_DECORATIVE_OBJECTS_INFO;
}
