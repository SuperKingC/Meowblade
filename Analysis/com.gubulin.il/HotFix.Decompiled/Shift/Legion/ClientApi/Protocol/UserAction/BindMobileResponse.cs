using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class BindMobileResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(3)]
	public int Cd;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_BIND_MOBILE_REQUEST;
}
