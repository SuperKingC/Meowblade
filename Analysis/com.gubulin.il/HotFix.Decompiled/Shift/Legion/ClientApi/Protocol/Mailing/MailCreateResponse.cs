using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Mailing;

[ProtoContract]
public class MailCreateResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public string Message;

	public int PacketId => PacketIds.MAIL_CREATE_REQUEST;
}
