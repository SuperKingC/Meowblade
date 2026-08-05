using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class DeviceLogResponse : IPacketBody
{
	public int PacketId => PacketIds.DEVICE_LOG_REQUEST;
}
