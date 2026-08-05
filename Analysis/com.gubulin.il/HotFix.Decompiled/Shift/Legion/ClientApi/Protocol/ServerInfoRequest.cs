using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class ServerInfoRequest : IPacketBody
{
	public int PacketId => PacketIds.SERVER_INFO;
}
