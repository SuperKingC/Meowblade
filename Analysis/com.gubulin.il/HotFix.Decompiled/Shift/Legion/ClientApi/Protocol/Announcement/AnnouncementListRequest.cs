using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Announcement;

[ProtoContract]
public class AnnouncementListRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int Id { get; set; }

	public int PacketId => PacketIds.ANNOUNCEMENT_LIST_REQUEST;
}
