using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class ServerInfoResponse : IPacketBody
{
	[ProtoMember(1)]
	public string Version { get; set; }

	[ProtoMember(2)]
	public string Name { get; set; }

	[ProtoMember(3)]
	public string CustomerServiceQQ { get; set; }

	public int PacketId => PacketIds.SERVER_INFO;
}
