using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class PingRequest : IPacketBody
{
	[ProtoMember(1)]
	public int Id { get; set; }

	public int PacketId => PacketIds.USER_PING;
}
