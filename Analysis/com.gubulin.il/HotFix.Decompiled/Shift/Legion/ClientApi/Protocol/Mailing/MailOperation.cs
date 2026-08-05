using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Mailing;

[ProtoContract]
public class MailOperation : IRequestPacket, IPacketBody
{
	public enum MailOperationType
	{
		MarkAsRead,
		MarkAllAsRead,
		Delete,
		DeleteAll,
		ClaimPayload,
		ClaimAllPayloads
	}

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int Id { get; set; }

	[ProtoMember(2)]
	public int Operation { get; set; }

	public int PacketId => PacketIds.MAIL_OPERATION_REQUEST;
}
