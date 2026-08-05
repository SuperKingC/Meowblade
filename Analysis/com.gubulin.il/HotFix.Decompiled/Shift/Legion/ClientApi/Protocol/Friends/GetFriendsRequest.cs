using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Friends;

[ProtoContract]
public class GetFriendsRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public bool GetNew { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_FRIENDS;
}
