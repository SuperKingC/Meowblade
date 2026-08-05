using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Friends;

[ProtoContract]
public class AddFriendResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public string Message;

	public int PacketId => PacketIds.USER_ACTION_ADD_FRIEND;
}
