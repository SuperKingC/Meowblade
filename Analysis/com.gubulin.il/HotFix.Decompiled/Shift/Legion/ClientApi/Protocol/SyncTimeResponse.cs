using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class SyncTimeResponse : IPacketBody
{
	[ProtoMember(1)]
	public int Timestamp { get; set; }

	public int PacketId => PacketIds.SYNC_TIME;
}
