using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;

namespace Shift.Legion.ClientApi.Sources.Protocol.FriendsChat;

[ProtoContract]
public class SendChatRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(5)]
	public string OpenId;

	[ProtoMember(6)]
	public string OpenKey;

	[ProtoMember(7)]
	public string Pf;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int Receiver { get; set; }

	[ProtoMember(2)]
	public int MsgType { get; set; }

	[ProtoMember(3)]
	public string Content { get; set; }

	public int PacketId => PacketIds.USER_ACTION_SEND_CHATMESSAGE;
}
