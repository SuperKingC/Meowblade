using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class DeviceIdentifierRequest : IPacketBody
{
	[ProtoMember(1)]
	public string DeviceIdentifier;

	[ProtoMember(2)]
	public string IDFA;

	public int PacketId => PacketIds.DEVICE_IDENTIFIER_REQUEST;
}
