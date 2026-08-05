using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class ClaimVerifyIdentityBonusRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_CLAIM_VERIFY_IDENTITY_BONUS_REQUEST;
}
