using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class UseDecorativeObjectsResponse : IPacketBody
{
	[ProtoMember(99)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public string Message { get; set; }

	[ProtoMember(2)]
	public byte[] Data { get; set; }

	public int PacketId => PacketIds.USER_ACTION_PROFILE_USE_DECORATIVE_OBJECTS_INFO;
}
