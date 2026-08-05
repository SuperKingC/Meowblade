using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Friends;

[ProtoContract]
public class DeleteFriendResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_DELETE_FRIEND;
}
