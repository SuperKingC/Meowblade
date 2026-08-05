using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class SyncTimeRequest : IPacketBody
{
	public int PacketId => PacketIds.SYNC_TIME;
}
