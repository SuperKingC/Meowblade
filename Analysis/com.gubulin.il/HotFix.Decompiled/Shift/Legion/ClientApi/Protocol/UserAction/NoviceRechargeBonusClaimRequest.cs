using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class NoviceRechargeBonusClaimRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public string ActivityId;

	[ProtoMember(5)]
	public string Score;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_ACTIVITY_CLAIM_RECHARGE_BONUS_REQUEST;
}
