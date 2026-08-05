using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class NoData : IPacketBody
{
	public int PacketId => PacketIds.INVALID;
}
