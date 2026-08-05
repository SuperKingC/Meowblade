using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class LoginRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_LOGIN_REQUEST;
}
