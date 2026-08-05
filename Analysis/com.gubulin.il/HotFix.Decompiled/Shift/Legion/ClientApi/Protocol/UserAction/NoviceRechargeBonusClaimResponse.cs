using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class NoviceRechargeBonusClaimResponse : IPacketBody
{
	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_ACTIVITY_CLAIM_RECHARGE_BONUS_REQUEST;
}
