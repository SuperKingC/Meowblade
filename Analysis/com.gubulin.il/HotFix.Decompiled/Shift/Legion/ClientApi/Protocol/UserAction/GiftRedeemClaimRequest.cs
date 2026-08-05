using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GiftRedeemClaimRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string RedeemCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GIFT_REDEEM_CLAIM;
}
