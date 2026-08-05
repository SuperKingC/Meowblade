using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Mailing;

[ProtoContract]
public class MailListRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int Id { get; set; }

	public int PacketId => PacketIds.MAIL_LIST_REQUEST;
}
