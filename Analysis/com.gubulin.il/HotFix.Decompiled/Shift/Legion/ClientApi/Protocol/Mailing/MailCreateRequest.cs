using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Mailing;

[ProtoContract]
public class MailCreateRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public int UserId;

	[ProtoMember(2)]
	public string Title;

	[ProtoMember(3)]
	public string Content;

	[ProtoMember(4)]
	public string PayloadConf;

	[ProtoMember(5)]
	public string ExtraPayloadConf;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.MAIL_CREATE_REQUEST;
}
