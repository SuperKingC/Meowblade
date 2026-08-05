using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Friends;

[ProtoContract]
public class DeleteFriendRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public int FriendId;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_DELETE_FRIEND;
}
