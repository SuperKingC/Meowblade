using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;

namespace Shift.Legion.ClientApi.Sources.Protocol.FriendsChat;

[ProtoContract]
public class ReadMessageRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int FriendId { get; set; }

	[ProtoMember(2)]
	public long Timestamp { get; set; }

	public int PacketId => PacketIds.USER_ACTION_READ_MESSAGE;
}
