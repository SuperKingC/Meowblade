using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class VerifyIdentityTapTapRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string token { get; set; }

	[ProtoMember(2)]
	public string userIdentifier { get; set; }

	public int PacketId => PacketIds.USER_VERIFY_IDENTITY_TAPTAP_REQUEST;
}
