using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class BindMobileRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public string Mobile;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_BIND_MOBILE_REQUEST;
}
