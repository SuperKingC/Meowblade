using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class UseDecorativeObjectsRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int Type { get; set; }

	[ProtoMember(2)]
	public string ItemId { get; set; }

	public int PacketId => PacketIds.USER_ACTION_PROFILE_USE_DECORATIVE_OBJECTS_INFO;
}
