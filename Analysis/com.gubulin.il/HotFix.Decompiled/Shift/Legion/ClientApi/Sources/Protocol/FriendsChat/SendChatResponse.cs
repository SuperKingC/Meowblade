using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;

namespace Shift.Legion.ClientApi.Sources.Protocol.FriendsChat;

[ProtoContract]
public class SendChatResponse : IPacketBody
{
	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Sources.Protocol.FriendsChat.ChatLog")]
	public ChatLog Chat { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_SEND_CHATMESSAGE;
}
