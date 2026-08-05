using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class UserDeviceInfoRequest : IPacketBody
{
	[ProtoMember(1)]
	public DeviceInfo Info;

	public int PacketId => PacketIds.USER_DEVICE_INFO_REQUEST;
}
