using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class DeviceIdentifierResponse : IPacketBody
{
	public int PacketId => PacketIds.DEVICE_IDENTIFIER_REQUEST;
}
