using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class UserDeviceInfoResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(10)]
	public string Source;

	public int PacketId => PacketIds.USER_DEVICE_INFO_REQUEST;
}
