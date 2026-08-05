using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Archive;

[ProtoContract]
public class DownloadArchiveRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_DOWNLOAD_ARCHIVE_REQUEST;
}
