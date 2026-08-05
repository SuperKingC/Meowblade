using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ClaimRecallWelfareBonusResponse : IPacketBody
{
	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public int TotalScore { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CLAIM_RECALLWELFARE_REQUEST;
}
