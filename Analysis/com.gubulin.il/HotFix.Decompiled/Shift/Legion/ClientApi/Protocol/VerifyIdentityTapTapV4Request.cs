using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class VerifyIdentityTapTapV4Request : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_VERIFY_IDENTITY_TAPTAP_V4_REQUEST;
}
