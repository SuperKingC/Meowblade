using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;

namespace Shift.Legion.ClientApi.Sources.Protocol.FriendsChat;

[ProtoContract]
public class GetUnreadMessageRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_UNREADMESSAGE;
}
